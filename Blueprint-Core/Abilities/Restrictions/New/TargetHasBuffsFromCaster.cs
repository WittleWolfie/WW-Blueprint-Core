using System.Linq;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UI.Log;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using UnityEngine;

namespace BlueprintCore.Abilities.Restrictions.New
{
  /// <summary>
  /// Requires the target to have specific buffs applied by the caster.
  /// </summary>
  [AllowedOn(typeof(BlueprintAbility), false)]
  public class TargetHasBuffsFromCaster : BlueprintComponent, IAbilityTargetRestriction
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("TargetHasBuff");

    private ReferenceArrayProxy<BlueprintBuff, BlueprintBuffReference> CheckedBuffs
    {
      get
      {
        return m_CheckedBuffs;
      }
    }

    public bool IsTargetRestrictionPassed(UnitEntityData caster, TargetWrapper target)
    {
      UnitEntityData targetUnit = target.Unit;
      if (targetUnit == null)
      {
        Logger.Warn("No target");
        return false;
      }
      if (caster == null)
      {
        Logger.Warn("No caster");
        return false;
      }

      foreach (BlueprintBuff blueprint in CheckedBuffs)
      {
        foreach (Buff buff in targetUnit.Buffs)
        {
          if (buff.Blueprint == blueprint && buff.Context.MaybeCaster == caster)
          {
            return true;
          }
        }
      }
      return false;
    }

    public string GetAbilityTargetRestrictionUIText(UnitEntityData caster, TargetWrapper target)
    {
      string facts =
          string.Join(
              ", ",
              m_CheckedBuffs.Select(
                  delegate (BlueprintBuffReference i)
                  {
                    BlueprintBuff blueprintBuff = i.Get();
                    if (blueprintBuff == null)
                    {
                      return null;
                    }
                    return blueprintBuff.Name;
                  }).NotNull<string>());
      return
          BlueprintRoot.Instance.LocalizedTexts.Reasons.TargetHasNoFact.ToString(
              delegate () { GameLogContext.Text = facts; });
    }

    [SerializeField]
    public BlueprintBuffReference[] m_CheckedBuffs;
  }

}