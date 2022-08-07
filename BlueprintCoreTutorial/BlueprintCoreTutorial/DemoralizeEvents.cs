using BlueprintCore.Utils;
using BlueprintCoreTutorial.Solutions.Feats;
using HarmonyLib;
using Kingmaker.Designers;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreTutorial
{
  /// <summary>
  /// Event subscriber for events related to use of the Demoralize action.
  /// </summary>
  public interface IDemoralizeSubscriber : IGlobalSubscriber
  {
    /// <summary>
    /// Triggers when Demoralize finishes.
    /// </summary>
    /// <param name="demoralize">The component executing demoralize</param>
    /// <param name="intimidateCheck">The intimidate skill check</param>
    void OnDemoralizeCompleted(Demoralize demoralize, RuleSkillCheck intimidateCheck);
  }

  /// <summary>
  /// Event handler for IDemoralizeSubscriber. Register IDemoralizerSubscribers using
  /// <see cref="Subscribe(IDemoralizeSubscriber)"/>.
  /// </summary>
  public class DemoralizeEvents
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("DemoralizeEvents");
    private static readonly List<IDemoralizeSubscriber> Subscribers = new();

    public static void Subscribe(IDemoralizeSubscriber subscriber)
    {
      Subscribers.Add(subscriber);
    }

    public static void Unsubscribe(IDemoralizeSubscriber subscriber)
    {
      Subscribers.Remove(subscriber);
    }

    public static void NotifySubscribers()//Demoralize demoralize, RuleSkillCheck intimidateCheck)
    {
      Logger.Info($"Notifying Demoralize Subscribers:");
    }

    [HarmonyPatch(typeof(Demoralize))]
    static class Demoralize_Patch
    {
      [HarmonyPatch(nameof(Demoralize.RunAction)), HarmonyTranspiler]
      static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
      {
        try
        {
          var code = new List<CodeInstruction>(instructions);

          // To call NotifySubscribers requires the current object and the result of TriggerSkillCheck. First loop
          // through the code and find the operand for the skill check (the next operation after TriggerSkillCheck).
          object intimidateCheck = null;
          var index = 0;
          for (; index < code.Count - 1; index++)
          {
            if (code[index].Calls(AccessTools.Method(typeof(GameHelper), nameof(GameHelper.TriggerSkillCheck))))
            {
              Logger.Info($"Found intimidate skill check at {index + 1}: {code[index + 1]}");
              intimidateCheck = code[index + 1].operand;
              break;
            }
          }
          if (intimidateCheck is null)
          {
            throw new InvalidOperationException("Unable to find intimidate skill check.");
          }

          // The Leave_S opcode is used twice, once in the foreach loop early in the method and again at the end of the
          // try block. Our code should be inserted just before the second Leave_S.
          for (; index < code.Count; index++)
          {
            if (code[index].opcode == OpCodes.Leave_S)
            {
              Logger.Info($"Found OpCodes.Leave_S at {index}");
              break;
            }
          }
          if (index == code.Count)
          {
            throw new InvalidOperationException("Unable to find leave statement.");
          }

          // More or less copied from dnSpy. Load the intimidate check, then this, then call NotifySubscribers.
          var newCode =
            new List<CodeInstruction>()
            {
              CodeInstruction.Call(typeof(DemoralizeEvents), nameof(DemoralizeEvents.NotifySubscribers)),
            };

          // Insert the new call into the instructions just before the leave statement, which is the exit for the try
          // statement.
          code.InsertRange(0, newCode);
          return code;
        }
        catch (Exception e)
        {
          Logger.Error("Transpiler failed.", e);
          return instructions;
        }
      }
    }
  }
}
