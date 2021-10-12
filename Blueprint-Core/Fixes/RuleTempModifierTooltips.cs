using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;

namespace BlueprintCore.Fixes
{
  /**
   * Temporary modifiers for rules don't show up in tooltips because they are removed before the
   * tooltip is generated. This fixes the issue by returning temporary modifiers when queried by
   * the tooltip.
   */
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