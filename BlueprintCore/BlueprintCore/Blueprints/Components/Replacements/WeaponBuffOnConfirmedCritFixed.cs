using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using Kingmaker.Visual.Particles;
using Owlcat.QA.Validation;
using UnityEngine;

namespace BlueprintCore.Blueprints.Components.Replacements
{
  /// <summary>
  /// Working replacement for Owlcat's WeaponBuffOnConfirmedCrit. Instantiate using <see cref="New(bool)"/> and
  /// configure using its methods.
  /// </summary>
  /// 
  /// <remarks>
  /// Based on WeaponBuffOnConfirmedCritTTT from
  /// <see href="https://github.com/Vek17/TabletopTweaks-Core/blob/master/TabletopTweaks-Core/">TabletopTweaks-Core</see>
  /// </remarks>
  [AllowMultipleComponents]
  [TypeId("91b77a2e-a14d-4593-99eb-13a82128d21f")]
  public class WeaponBuffOnConfirmedCritFixed : WeaponEnchantmentLogic,
      IInitiatorRulebookHandler<RuleAttackWithWeapon>,
      IRulebookHandler<RuleAttackWithWeapon>,
      ISubscriber,IInitiatorRulebookSubscriber, IResourcesHolder
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("AddStatBonusIfHasFactFixed");

    public BlueprintBuff? TargetBuff
    {
      get
      {
        BlueprintBuffReference buff = m_TargetBuff;
        if (buff == null)
        {
          return null;
        }
        return buff.Get();
      }
    }
    public BlueprintBuff? WielderBuff
    {
      get
      {
        BlueprintBuffReference buff = m_WielderBuff;
        if (buff == null)
        {
          return null;
        }
        return buff.Get();
      }
    }

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
      if (RequireNatural20 && !(evt.AttackRoll.D20.Result == 20 && evt.AttackRoll.IsCriticalConfirmed))
      {
        return;
      }

      if (TargetBuff is not null)
      {
        Logger.Verbose($"Applying buff to target.");
        evt.Target.Descriptor.AddBuff(TargetBuff, Owner.Wielder.Unit, TargetDuration.Seconds);
        FxHelper.SpawnFxOnUnit(TargetFx.Load(), evt.Target.View);
      }

      if (WielderBuff is not null)
      {
        Logger.Verbose($"Applying buff to Wielder.");
        evt.Initiator.Descriptor.AddBuff(WielderBuff, Owner.Wielder.Unit, WielderDuration.Seconds);
        FxHelper.SpawnFxOnUnit(WielderFx.Load(), evt.Initiator.View);
      }
    }

    private WeaponBuffOnConfirmedCritFixed() { }

    public static WeaponBuffOnConfirmedCritFixed New(bool requireNatural20 = false)
    {
      return new()
      {
        RequireNatural20 = requireNatural20
      };
    }

    public WeaponBuffOnConfirmedCritFixed ApplyBuffToTarget(
      Blueprint<BlueprintBuffReference> buff, Rounds duration, PrefabLink? fx = null)
    {
      m_TargetBuff = buff.Reference;
      TargetDuration = duration;
      TargetFx = fx ?? Constants.Empty.PrefabLink;
      return this;
    }

    public WeaponBuffOnConfirmedCritFixed ApplyBuffToWielder(
      Blueprint<BlueprintBuffReference> buff, Rounds duration, PrefabLink? fx = null)
    {
      m_WielderBuff = buff.Reference;
      WielderDuration = duration;
      WielderFx = fx ?? Constants.Empty.PrefabLink;
      return this;
    }

    [SerializeField]
    [ValidateNotNull]
    public BlueprintBuffReference m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
    [ValidateNotNull]
    public PrefabLink TargetFx = Constants.Empty.PrefabLink;
    public Rounds TargetDuration;

    [SerializeField]
    [ValidateNotNull]
    public BlueprintBuffReference m_WielderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
    [ValidateNotNull]
    public PrefabLink WielderFx = Constants.Empty.PrefabLink;
    public Rounds WielderDuration;

    public bool RequireNatural20;
  }
}