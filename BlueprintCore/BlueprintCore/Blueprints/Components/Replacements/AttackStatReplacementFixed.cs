using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Components.Replacements
{
  /// <summary>
  /// Working replacement for Owlcat's AttackStatReplacement.
  /// </summary>
  /// 
  /// <remarks>
  /// Based on AttackStatReplacementTTT from
  /// <see href="https://github.com/Vek17/TabletopTweaks-Core/blob/master/TabletopTweaks-Core/">TabletopTweaks-Core</see>
  /// </remarks>
  [ComponentName("Replace attack stat")]
  [TypeId("574986d1-510c-40d7-ba51-92dd3b6d057d")]
  public class AttackStatReplacementFixed : UnitFactComponentDelegate,
      IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>,
      IRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, ISubscriber,
      IInitiatorRulebookSubscriber
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("AttackStatReplacementFixed");

    public ReferenceArrayProxy<BlueprintWeaponType, BlueprintWeaponTypeReference> WeaponTypes
    {
      get
      {
        return m_WeaponTypes;
      }
    }

    public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt)
    {
      var attackBonus = Owner.Stats.GetStat(evt.AttackBonusStat) as ModifiableValueAttributeStat;
      var replacementBonus = Owner.Stats.GetStat(ReplacementStat) as ModifiableValueAttributeStat;
      bool shouldReplace =
        attackBonus is not null && replacementBonus is not null && replacementBonus.Bonus >= attackBonus.Bonus;
      if (!shouldReplace)
      {
        Logger.Verbose($"Replacement skipped: Current - {attackBonus} Replacement - {replacementBonus}");
        return;
      }

      shouldReplace =
        m_WeaponTypes.Any()
          ? WeaponTypes.HasReference(evt.Weapon.Blueprint.Type)
          : evt.Weapon.Blueprint.Category.HasSubCategory(SubCategory);
      if (shouldReplace)
      {
        evt.AttackBonusStat = ReplacementStat;
      }
      else
      {
        Logger.Verbose(
          $"Replacement skipped: Weapon Type - {evt.Weapon.Blueprint.Type} Weapon Category - {evt.Weapon.Blueprint.Category}");
      }
    }

    public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt)
    {
    }

    public StatType ReplacementStat;

    public WeaponSubCategory SubCategory;

    [SerializeField]
    public BlueprintWeaponTypeReference[] m_WeaponTypes = new BlueprintWeaponTypeReference[0];

    public AttackStatReplacementFixed(
      StatType replacementStat, params Blueprint<BlueprintWeaponTypeReference>[] weaponTypes)
    {
      ReplacementStat = replacementStat;
      m_WeaponTypes = weaponTypes.Select(bp => bp.Reference).ToArray();
    }

    public AttackStatReplacementFixed(StatType replacementStat, WeaponSubCategory weaponSubcategory)
    {
      ReplacementStat = replacementStat;
      SubCategory = weaponSubcategory;
    }
  }
}