using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Armies.TacticalCombat.Parts;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System.Linq;

namespace BlueprintCore.Blueprints.Components.Replacements
{
  /// <summary>
  /// Working replacement for Owlcat's AddOutgoingDamageTrigger.
  /// Instantiate using <see cref="New(ActionsBuilder, bool, bool, bool, bool, bool, bool)"/> and configure using its
  /// methods.
  /// </summary>
  /// 
  /// <remarks>
  /// Based on AddOutgoingDamageTriggerTTT from
  /// <see href="https://github.com/Vek17/TabletopTweaks-Core/blob/master/TabletopTweaks-Core/">TabletopTweaks-Core</see>
  /// </remarks>
  [AllowMultipleComponents]
  // These blueprints are the only types whith facts that implement IFactContextOwner
  [AllowedOn(typeof(BlueprintBuff))]
  [AllowedOn(typeof(BlueprintFeature))]
  [AllowedOn(typeof(BlueprintItemEnchantment))]
  [AllowedOn(typeof(BlueprintUnit))]
  [TypeId("d085f1af-4790-4597-a024-ae9aad966a40")]
  public class AddOutgoingDamageTriggerFixed : UnitFactComponentDelegate<AddOutgoingDamageTriggerFixed.ComponentData>,
      IInitiatorRulebookHandler<RuleDealDamage>,
      IRulebookHandler<RuleDealDamage>,
      IInitiatorRulebookHandler<RuleDealStatDamage>,
      IRulebookHandler<RuleDealStatDamage>,
      IInitiatorRulebookHandler<RuleDrainEnergy>,
      IRulebookHandler<RuleDrainEnergy>,
      ISubscriber, IInitiatorRulebookSubscriber
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("AddOutgoingDamageTriggerFixed");

    public BlueprintWeaponType? WeaponType
    {
      get
      {
        BlueprintWeaponTypeReference weaponType = m_WeaponType;
        if (weaponType == null)
        {
          return null;
        }
        return weaponType.Get();
      }
    }

    public ReferenceArrayProxy<BlueprintAbility, BlueprintAbilityReference> AbilityList
    {
      get
      {
        return m_AbilityList;
      }
    }

    private void RunAction(RulebookEvent e, UnitEntityData target)
    {
      // Damage is from this fact and should be ignored
      if (!ApplyToDamageFromThisFact && e.Reason.Fact == Fact) { return; }

      if (UseContextFromReason)
      {
        MechanicsContext context = e.Reason.Context;
        using (context?.GetDataScope(target))
        {
          Logger.Verbose($"Running actions in reason context.");
          Actions.Run();
          return;
        }
      }

      // If Fact is not a FactContextOwner then the actions have no context to run in
      if (Actions.HasActions && Fact is IFactContextOwner factContextOwner)
      {
        Logger.Verbose($"Running actions in Fact context: {Fact.Name}");
        factContextOwner.RunActionInContext(Actions, target);
      }
      else
      {
        // This shouldn't happen, but if it does log a warning.
        Logger.Warn(
          $"Failed to trigger. Has Actions: {Actions.HasActions} - Is IFactContextOwner: {Fact is IFactContextOwner}");
      }
    }

    public void OnEventAboutToTrigger(RuleDealDamage evt)
    {
      if (!TacticalCombatHelper.IsActive)
      {
        Data.WasTargetAlive = !evt.Target.Descriptor.State.IsDead;
        return;
      }

      UnitPartTacticalCombat unitPartTacticalCombat = evt.Target.Get<UnitPartTacticalCombat>();
      int unitsCount = unitPartTacticalCombat?.Count ?? 1;
      Data.WasTargetAlive = unitsCount > TacticalCombatHelper.GetDeathCount(evt.Target, evt.Target.HPLeft, unitsCount);
    }

    public void OnEventAboutToTrigger(RuleDealStatDamage evt)
    {
    }

    public void OnEventAboutToTrigger(RuleDrainEnergy evt)
    {
    }

    public void OnEventDidTrigger(RuleDealDamage evt)
    {
      if (CheckDamageValue(evt.Result))
      {
        Apply(evt);
      }
      Data.LastAttack = evt.AttackRoll;
    }

    public void OnEventDidTrigger(RuleDealStatDamage evt)
    {
      if (ApplyToStatDamageAndEnergyDrain && CheckDamageValue(evt.Result))
      {
        RunAction(evt, evt.Target);
      }
    }

    public void OnEventDidTrigger(RuleDrainEnergy evt)
    {
      if (ApplyToStatDamageAndEnergyDrain && CheckDamageValue(evt.DrainValue))
      {
        RunAction(evt, evt.Target);
      }
    }

    private void Apply(RuleDealDamage evt)
    {
      if (ApplyOncePerAttackRoll && Data.LastAttack is not null && Data.LastAttack == evt.AttackRoll)
      {
        Logger.Verbose($"Skipping: Apply only once per attack roll.");
        return;
      }

      if (WeaponType is not null && evt.DamageBundle.Weapon?.Blueprint?.Type != WeaponType)
      {
        Logger.Verbose($"Skipping due to weapon type mismatch: {evt.DamageBundle.Weapon?.Blueprint?.Type?.name}");
        return;
      }

      if (AbilityType is not null)
      {
        AbilityType? evtAbilityType = evt.Reason.Ability?.Blueprint?.Type ?? evt.Reason.Context?.SourceAbility?.Type;
        if (evtAbilityType == AbilityType)
        {
          Logger.Verbose($"Skipping due to ability type mismatch: {evtAbilityType}");
          return;
        }
      }

      if (SpellDescriptors is not null
        && (evt.Reason.Ability is null
          || !evt.Reason.Ability.Blueprint.SpellDescriptor.HasFlag(SpellDescriptors.Value)))
      {
        Logger.Verbose($"Skipping due to spell descriptor mismatch: {evt.Reason.Ability?.Blueprint?.SpellDescriptor}");
        return;
      }

      if (EnergyType is not null)
      {
        bool energyTypeMatches = false;
        foreach (BaseDamage baseDamage in evt.DamageBundle)
        {
          if (baseDamage.Type == DamageType.Energy && (baseDamage as EnergyDamage)!.EnergyType == EnergyType)
          {
            energyTypeMatches = true;
            break;
          }
        }
        if (!energyTypeMatches)
        {
          Logger.Verbose($"Skipping due to energy type mismatch.");
          return;
        }
      }

      if (!ApplyToAreaEffectDamage && evt.SourceArea)
      {
        Logger.Verbose($"Skipping due to AoE.");
        return;
      }

      
      if (AbilityList.Any())
      {
        bool abilityReasonMatches =
          evt.Reason.Ability is not null
            && (AbilityList.Contains(evt.Reason.Ability.Blueprint)
              || AbilityList.Contains(evt.Reason.Ability.Blueprint.Parent));
        bool abilitySourceMatches =
          evt.SourceAbility is not null
            && (AbilityList.Contains(evt.SourceAbility)
              || AbilityList.Contains(evt.SourceAbility.Parent));
        if (!abilityReasonMatches && !abilitySourceMatches)
        {
          Logger.Verbose(
            $"Skipping due ability mismatch: abilityReasonMatches - {abilityReasonMatches} abilitySourceMatches - {abilitySourceMatches}");
          return;
        }
      }

      if (!ApplyToDeadTarget)
      {
        bool isTargetAlive;
        if (TacticalCombatHelper.IsActive)
        {
          UnitPartTacticalCombat unitPartTacticalCombat = evt.Target.Get<UnitPartTacticalCombat>();
          int unitsCount = unitPartTacticalCombat?.Count ?? 1;
          isTargetAlive = unitsCount <= TacticalCombatHelper.GetDeathCount(evt.Target, evt.Target.HPLeft, unitsCount);
        }
        else
        {
          isTargetAlive = evt.Target.Descriptor.Stats.HitPoints <= evt.Target.Descriptor.Damage;
        }

        if (!Data.WasTargetAlive || !isTargetAlive)
        {
          Logger.Verbose($"Skipping due to dead target.");
          return;
        }
      }
      RunAction(evt, evt.Target);
    }

    private bool CheckDamageValue(int damageValue)
    {
      return TargetValue is null || CompareType.CheckCondition(damageValue, TargetValue.Calculate(Fact.MaybeContext));
    }

    public class ComponentData
    {
      public bool WasTargetAlive;
      public RuleAttackRoll? LastAttack;
    }

    // Enforce use of New()
    private AddOutgoingDamageTriggerFixed() { }

    /// <param name="useContextFromReason">
    /// If set to true the actions run in the context of whatever triggered the damage event. For an example see
    /// SithhudsRodBuff - 568b3b13328f4de192547bf145b7a3a4.
    /// </param>
    public static AddOutgoingDamageTriggerFixed New(
      ActionsBuilder actions,
      bool applyOncePerAttackRoll = false,
      bool applyToAreaEffectDamage = false,
      bool applyToDamageFromThisFact = false,
      bool applyToDeadTarget = false,
      bool applyToStatDamageAndEnergyDrain = false,
      bool useContextFromReason = false)
    {
      return new AddOutgoingDamageTriggerFixed
      {
        Actions = actions.Build(),
        ApplyOncePerAttackRoll = applyOncePerAttackRoll,
        ApplyToAreaEffectDamage = applyToAreaEffectDamage,
        ApplyToDamageFromThisFact = applyToDamageFromThisFact,
        ApplyToDeadTarget = applyToDeadTarget,
        ApplyToStatDamageAndEnergyDrain = applyToStatDamageAndEnergyDrain,
        UseContextFromReason = useContextFromReason
      };
    }

    public AddOutgoingDamageTriggerFixed RestrictToWeaponType(Blueprint<BlueprintWeaponTypeReference> weaponType)
    {
      m_WeaponType = weaponType.Reference;
      return this;
    }

    public AddOutgoingDamageTriggerFixed RestrictToAbilityType(AbilityType abilityType)
    {
      AbilityType = abilityType;
      return this;
    }

    public AddOutgoingDamageTriggerFixed RestrictToAbilities(params Blueprint<BlueprintAbilityReference>[] abilities)
    {
      m_AbilityList = abilities.Select(a => a.Reference).ToArray();
      return this;
    }

    public AddOutgoingDamageTriggerFixed RestrictToEnergyType(DamageEnergyType energyType)
    {
      EnergyType = energyType;
      return this;
    }

    public AddOutgoingDamageTriggerFixed RestrictToSpellDescriptors(params SpellDescriptor[] spellDescriptors)
    {
      SpellDescriptors = spellDescriptors.Aggregate((SpellDescriptor)0, (s1, s2) => s1 | s2);
      return this;
    }

    public AddOutgoingDamageTriggerFixed RestrictToDamageValue(
      ContextValue damageValue, CompareOperation.Type comparisonType = CompareOperation.Type.Equal)
    {
      TargetValue = damageValue;
      CompareType = comparisonType;
      return this;
    }

    public ActionList Actions;

    public bool ApplyOncePerAttackRoll;
    public bool ApplyToAreaEffectDamage;
    public bool ApplyToDamageFromThisFact;
    public bool ApplyToDeadTarget;
    public bool ApplyToStatDamageAndEnergyDrain;
    public bool UseContextFromReason;

    public BlueprintWeaponTypeReference? m_WeaponType;
    public AbilityType? AbilityType;
    public BlueprintAbilityReference[] m_AbilityList = new BlueprintAbilityReference[0];
    public DamageEnergyType? EnergyType;
    public SpellDescriptorWrapper? SpellDescriptors;

    public ContextValue? TargetValue;
    public CompareOperation.Type CompareType;
  }
}