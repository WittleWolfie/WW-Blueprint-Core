using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Designers;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlueprintCoreTutorial.Feats
{
  /// <summary>
  /// Event subscriber for events related to use of the Demoralize action.
  /// </summary>
  public interface IDemoralizeHandler : IGlobalSubscriber
  {
    /// <summary>
    /// Triggers when Demoralize finishes resolving.
    /// </summary>
    /// <param name="demoralize">The component executing demoralize</param>
    /// <param name="intimidateCheck">The intimidate skill check</param>
    void OnDemoralizeResolved(Demoralize demoralize, RuleSkillCheck intimidateCheck);
  }

  /// <summary>
  /// Event system for IDemoralizeHandler.
  /// </summary>
  public class DemoralizeEvents
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("DemoralizeEvents");
    public static void NotifySubscribers(Demoralize demoralize, RuleSkillCheck intimidateCheck)
    {
      Logger.Verbose($"Notifying Demoralize Subscribers: {demoralize.Owner.name}, {intimidateCheck.RollResult}");
      EventBus.RaiseEvent<IDemoralizeHandler>(h => h.OnDemoralizeResolved(demoralize, intimidateCheck));
    }

    [HarmonyPatch(typeof(Demoralize))]
    static class Demoralize_Patch
    {
      [HarmonyPatch(nameof(Demoralize.RunAction)), HarmonyTranspiler]
      static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
      {
        try
        {
          var code = new List<CodeInstruction>(instructions);
          Label newJumpTarget = il.DefineLabel();

          // Search back to front for OpCodes.Leave_S which is where the new code is inserted. In the next loop the
          // any code before Leave_S and after the skill check that jumps to either Leave_S or Ret will be redirected
          // to newJumpTarget.
          var index = code.Count - 1;
          var insertIndex = 0;
          List<Label> leaveLabel = new();
          var retLabel = code[index].labels;
          for (; index >= 0; index--)
          {
            if (code[index].opcode == OpCodes.Leave_S)
            {
              Logger.Info($"Found OpCodes.Leave_S at {index}: {code[index]}");
              insertIndex = index;
              leaveLabel = code[index].labels;
              break;
            }
          }
          if (insertIndex == 0)
          {
            throw new InvalidOperationException("Unable to find the insertion index.");
          }

          // Keep searching backwards replacing all jumps to retLabel / leaveLable, until TriggerSkillCheck is found.
          // Capture the operand for referencing the result which will be passed to NotifySubscribers.
          object skillCheckResult = null;
          index--; // Make sure we don't redirect Leave_S or there's an infinite loop
          for (; index >= 0; index--)
          {
            if (code[index].Calls(AccessTools.Method(typeof(GameHelper), nameof(GameHelper.TriggerSkillCheck))))
            {
              Logger.Info($"Found skill check result at {index + 1}: {code[index + 1]}");
              skillCheckResult = code[index + 1].operand;
              break; // Don't mess w/ jumps before the skill check result is generated
            }

            // Doesn't matter what the operation is, if the operand is a Label it's some kind of jump
            if (code[index].operand is Label jumpTarget)
            {
              if (leaveLabel.Contains(jumpTarget))
              {
                Logger.Info($"Found jump to OpCodes.Leave_S at {index}: {code[index]}");
                code[index].operand = newJumpTarget;
              }
              if (retLabel.Contains(jumpTarget))
              {
                Logger.Info($"Found jump to OpCodes.Ret at {index}: {code[index]}");
                code[index].operand = newJumpTarget;
              }
            }
          }

          // More or less copied from dnSpy
          var newCode =
            new List<CodeInstruction>()
            {
              // Load Demoralize instance, jumps redirect here
              new CodeInstruction(OpCodes.Ldarg_0).WithLabels(newJumpTarget),
              // Load the resulting RuleSkillCheck
              new CodeInstruction(OpCodes.Ldloc_S, skillCheckResult),
              // Call NotifySubscribers
              CodeInstruction.Call(typeof(DemoralizeEvents), nameof(DemoralizeEvents.NotifySubscribers)),
            };
          code.InsertRange(insertIndex, newCode);
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
