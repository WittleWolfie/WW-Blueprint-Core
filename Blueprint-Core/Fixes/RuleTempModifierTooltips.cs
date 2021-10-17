using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;

namespace BlueprintCore.Fixes
{
  /// <summary>
  /// Fix to ensure temporary modifiers are displayed on tooltips.
  /// </summary>
  /// 
  /// <remarks>
  /// In the base game, temporary modifiers are removed from the rule modifiers before the tooltip is generated. This
  /// patches <see cref="RulebookEvent.AllBonuses"/> and concatenates any temporary modifiers. It works because the
  /// temporary modifiers are removed only from the rule modifiers, but are still stored in the rule as temporary
  /// modifiers.
  /// </remarks>
  public static class RuleTempModifierTooltips
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("TempModifierTooltips");

    [HarmonyPatch(typeof(RulebookEvent), "AllBonuses", MethodType.Getter)]
    static class RulebookEvent_GetAllBonuses_Patch
    {
      [HarmonyPriority(Priority.First)]
      static void Postfix(RulebookEvent __instance, ref IEnumerable<Modifier> __result)
      {
        if (__instance.m_TemporaryModifiers?.Count() > 0)
        {
          Logger.Verbose("Including temp modifiers.");
          __result =
              __result.Concat(
                  __instance.m_TemporaryModifiers.Select(
                      mod => new Modifier(mod.ModValue, mod.Source, mod.ModDescriptor)));
        }
      }
    }
  }
}