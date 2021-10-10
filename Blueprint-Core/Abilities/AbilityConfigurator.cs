using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Abilities.Restrictions.New;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints;
using BlueprintCore.Conditions;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace BlueprintCore.Abilities
{
  public class AbilityConfigurator
      : BlueprintUnitFactConfigurator<BlueprintAbility, AbilityConfigurator>
  {
    private Metamagic EnableMetamagics;
    private Metamagic DisableMetamagics;

    private readonly List<BlueprintAbility> EnableVariants = new();
    private readonly List<BlueprintAbility> DisableVariants = new();

    private AbilityConfigurator(string name) : base(name) { }

    public static AbilityConfigurator For(string name)
    {
      return new AbilityConfigurator(name);
    }


    /**
     * (Field) m_DefaultAiAction
     *
     * @param aiAction BlueprintAiCastSpell Sets the Ability field to this blueprint.
     */
    public AbilityConfigurator SetAiAction(string aiAction)
    {
      OnConfigure.Add(
          blueprint =>
          {
            var aiBlueprint = BlueprintTool.Get<BlueprintAiCastSpell>(aiAction);
            aiBlueprint.m_Ability = Blueprint.ToReference<BlueprintAbilityReference>();
            blueprint.m_DefaultAiAction = aiBlueprint.ToReference<BlueprintAiCastSpell.Reference>();
          });
      return this;
    }

    /** (Field) Type */
    public AbilityConfigurator SetType(AbilityType type)
    {
      OnConfigure.Add(blueprint => blueprint.Type = type);
      return this;
    }

    /**
     * (Field) Range
     *
     * @param range AbilityRange; use SetCustomRange() for AbilityRange.Custom
     */
    public AbilityConfigurator SetRange(AbilityRange range)
    {
      if (range == AbilityRange.Custom)
      {
        throw new InvalidOperationException("Use SetCustomRange() for AbilityRange.Custom.");
      }
      OnConfigure.Add(blueprint => blueprint.Range = range);
      return this;
    }

    /** (Fields) Range, CustomRange */
    public AbilityConfigurator SetCustomRange(int rangeInFeet)
    {
      OnConfigure.Add(
          blueprint =>
          {
            blueprint.Range = AbilityRange.Custom;
            blueprint.CustomRange = new Feet(rangeInFeet);
          });
      return this;
    }

    /** (Fields) ShowNameForVariant, OnlyForAllyCaster */
    public AbilityConfigurator ShowNameForVariant(bool showName = true, bool onlyForAlly = false)
    {
      OnConfigure.Add(
          blueprint =>
          {
            blueprint.ShowNameForVariant = showName;
            blueprint.OnlyForAllyCaster = onlyForAlly;
          });
      return this;
    }

    /** (Fields) CanTargetPoint, CanTargetEnemies, CanTargetFriends, CanTargetSelf */
    public AbilityConfigurator AllowTargeting(
        bool? point = null, bool? enemies = null, bool? friends = null, bool? self = null)
    {
      OnConfigure.Add(
          blueprint =>
          {
            blueprint.CanTargetPoint = point ?? blueprint.CanTargetPoint;
            blueprint.CanTargetEnemies = enemies ?? blueprint.CanTargetEnemies;
            blueprint.CanTargetFriends = friends ?? blueprint.CanTargetFriends;
            blueprint.CanTargetSelf = self ?? blueprint.CanTargetSelf;
          });
      return this;
    }

    /** (Field) SpellResistance) */
    public AbilityConfigurator ApplySpellResistance(bool applySR = true)
    {
      OnConfigure.Add(blueprint => blueprint.SpellResistance = applySR);
      return this;
    }

    /** (Field) ActionBarAutoFillIgnored */
    public AbilityConfigurator AutoFillActionBar(bool autoFill = true)
    {
      OnConfigure.Add(blueprint => blueprint.ActionBarAutoFillIgnored = !autoFill);
      return this;
    }

    /** (Field) Hidden */
    public AbilityConfigurator HideInUi(bool hide = true)
    {
      OnConfigure.Add(blueprint => blueprint.Hidden = hide);
      return this;
    }

    /** (Field) NeedEquipWeapons */
    public AbilityConfigurator RequireWeapon(bool requireWeapon = true)
    {
      OnConfigure.Add(blueprint => blueprint.NeedEquipWeapons = requireWeapon);
      return this;
    }

    /** (Field) NotOffensive */
    public AbilityConfigurator IsOffensive(bool offensive = true)
    {
      OnConfigure.Add(blueprint => blueprint.NotOffensive = !offensive);
      return this;
    }

    /** (Fields) EffectOnAlly, EffectOnEnemy */
    public AbilityConfigurator SetEffectOn(
        AbilityEffectOnUnit? onAlly = null, AbilityEffectOnUnit? onEnemy = null)
    {
      OnConfigure.Add(
          blueprint =>
          {
            blueprint.EffectOnAlly = onAlly ?? blueprint.EffectOnAlly;
            blueprint.EffectOnEnemy = onEnemy ?? blueprint.EffectOnEnemy;
          });
      return this;
    }

    /**
     * (Field) m_Parent
     *
     * @param name BlueprintAbility Will be updated to include this config blueprint as a variant.
     */
    public AbilityConfigurator SetParent(string name)
    {
      OnConfigure.Add(blueprint => SetParent(BlueprintTool.Get<BlueprintAbility>(name)));
      return this;
    }

    /**
     * (Field) m_Parent
     *
     * @param name BlueprintAbility Will be updated to remove this config blueprint as a variant.
     */
    public AbilityConfigurator ClearParent()
    {
      OnConfigure.Add(blueprint => RemoveParent());
      return this;
    }

    /** (Fields) Animation */
    public AbilityConfigurator SetAnimationStyle(
        UnitAnimationActionCastSpell.CastAnimationStyle style)
    {
      OnConfigure.Add(blueprint => blueprint.Animation = style);
      return this;
    }

    /** (Fields) ActionType, HasFastAnimation */
    public AbilityConfigurator SetActionType(
        UnitCommand.CommandType type, bool? hasFastAnimation = null)
    {
      OnConfigure.Add(
          blueprint =>
          {
            blueprint.ActionType = type;
            blueprint.HasFastAnimation = hasFastAnimation ?? blueprint.HasFastAnimation;
          });
      return this;
    }

    /** (Field) AvailableMetamagic */
    public AbilityConfigurator AddMetamagics(params Metamagic[] metamagics)
    {
      foreach (Metamagic metamagic in metamagics)
      {
        EnableMetamagics |= metamagic;
      }
      return this;
    }

    /** (Field) AvailableMetamagic */
    public AbilityConfigurator RemoveMetamagics(params Metamagic[] metamagics)
    {
      foreach (Metamagic metamagic in metamagics)
      {
        DisableMetamagics |= metamagic;
      }
      return this;
    }

    /** (Field) m_IsFullRoundAction */
    public AbilityConfigurator MakeFullRound(bool fullRound = true)
    {
      OnConfigure.Add(blueprint => blueprint.m_IsFullRoundAction = fullRound);
      return this;
    }

    /** (Field) LocalizedDuration */
    public AbilityConfigurator SetDurationText(LocalizedString duration)
    {
      OnConfigure.Add(blueprint => blueprint.LocalizedDuration = duration);
      return this;
    }

    /** (Field) LocalizedSavingThrow */
    public AbilityConfigurator SetSavingThrowText(LocalizedString savingThrow)
    {
      OnConfigure.Add(blueprint => blueprint.LocalizedSavingThrow = savingThrow);
      return this;
    }

    /** (Field) MaterialComponent */
    public AbilityConfigurator SetMaterialComponent(
        BlueprintAbility.MaterialComponentData component)
    {
      OnConfigure.Add(blueprint => blueprint.MaterialComponent = component);
      return this;
    }

    /** (Field) DisableLog */
    public AbilityConfigurator HideFromLog(bool hide = true)
    {
      OnConfigure.Add(blueprint => blueprint.DisableLog = hide);
      return this;
    }

    /** AbilityCasterAlignment */
    public AbilityConfigurator RequireCasterAlignment(
        AlignmentMaskType alignment, string ignoreFact = null)
    {
      var hasAlignment = new AbilityCasterAlignment { Alignment = alignment };
      if (ignoreFact != null)
      {
        hasAlignment.m_IgnoreFact =
            BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(ignoreFact);
      }
      return AddComponent(hasAlignment);
    }

    /**
     * AbilityCasterHasFacts
     *
     * @param facts BlueprintUnitFact
     */
    public AbilityConfigurator RequireCasterFacts(params string[] facts)
    {
      var hasFacts = new AbilityCasterHasFacts
      {
        m_Facts =
            facts
                .Select(
                    fact =>
                        BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact))
                .ToArray()
      };
      return AddComponent(hasFacts);
    }

    /**
     * AbilityCasterHasNoFacts
     *
     * @param facts BlueprintUnitFact
     */
    public AbilityConfigurator RequireCasterHasNoFacts(params string[] facts)
    {
      var hasNoFacts = new AbilityCasterHasNoFacts
      {
        m_Facts =
            facts
                .Select(
                    fact =>
                        BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact))
                .ToArray()
      };
      return AddComponent(hasNoFacts);
    }

    /**
     * AbilityCasterHasChosenWeapon
     *
     * Requires the caster to wield their chosen weapon, i.e. the weapon in which they have weapon
     * focus or Weapon Specialization.
     *
     * @param parameterizedWeaponFeature BlueprintParameterizedFeature
     * @param ignoreFact BlueprintUnitFact
     */
    public AbilityConfigurator RequireCasterHasChosenWeapon(
        string parameterizedWeaponFeature, string ignoreFact = null)
    {
      var hasChosenWeapon = new AbilityCasterHasChosenWeapon
      {
        m_ChosenWeaponFeature =
            BlueprintTool
                .GetRef<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>(
                    parameterizedWeaponFeature)
      };
      if (ignoreFact != null)
      {
        hasChosenWeapon.m_IgnoreWeaponFact =
            BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(ignoreFact);
      }
      return AddComponent(hasChosenWeapon);
    }

    /** AbilityCasterHasWeaponWithRangeType */
    public AbilityConfigurator RequireCasterWeaponRange(WeaponRangeType range)
    {
      var hasWeaponRange = new AbilityCasterHasWeaponWithRangeType { RangeType = range };
      return AddComponent(hasWeaponRange);
    }

    /** AbilityCasterInCombat */
    public AbilityConfigurator RequireCasterInCombat(bool requireInCombat = true)
    {
      var isInCombat = new AbilityCasterInCombat { Not = !requireInCombat };
      return AddComponent(isInCombat);
    }

    /**
     * AbilityCasterIsOnFavoredTerrain
     *
     * @param ignoreFeature BlueprintFeature
     */
    public AbilityConfigurator RequireCasterOnFavoredTerrain(string ignoreFeature = null)
    {
      var onFavoredTerrain = new AbilityCasterIsOnFavoredTerrain();
      if (ignoreFeature != null)
      {
        onFavoredTerrain.m_IgnoreFeature =
            BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(ignoreFeature);
      }
      return AddComponent(onFavoredTerrain);
    }

    /**
     * TargetHasBuffsFromCaster
     *
     * @param buffs BlueprintBuff
     */
    public AbilityConfigurator RequireTargetHasBuffsFromCaster(params string[] buffs)
    {
      var hasBuffs = new TargetHasBuffsFromCaster
      {
        m_CheckedBuffs =
            buffs
                .Select(buff => BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff))
                .ToArray()
      };
      return AddComponent(hasBuffs);
    }

    /** AbilityCanTargetDead */
    public AbilityConfigurator CanTargetDead()
    {
      return AddUniqueComponent(new AbilityCanTargetDead(), ComponentMerge.Skip);
    }


    [DeliverEffectAttr]
    /** AbilityDeliveredByWeapon */
    public AbilityConfigurator DeliveredByWeapon()
    {
      return AddUniqueComponent(new AbilityDeliveredByWeapon(), ComponentMerge.Skip);
    }

    [ApplyEffectAttr]
    /**
     * AbilityEffectRunAction
     *
     * Merge: Concatenates actions.
     */
    public AbilityConfigurator RunActions(
        ActionListBuilder actions,
        SavingThrowType savingThrow = SavingThrowType.Unknown,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var run = new AbilityEffectRunAction
      {
        Actions = actions.Build(),
        SavingThrowType = savingThrow
      };
      return AddUniqueComponent(run, mergeBehavior, merge ?? MergeRunActions);
    }

    private static void MergeRunActions(
        BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AbilityEffectRunAction;
      var target = other as AbilityEffectRunAction;
      source.Actions.Actions = source.Actions.Actions.AppendToArray(target.Actions.Actions);
    }

    /**
     * AbilityEffectMiss
     *
     * Merge: Concatenates actions.
     */
    public AbilityConfigurator OnMiss(
        ActionListBuilder actions,
        bool useTargetSelector = true,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var onMiss = new AbilityEffectMiss
      {
        MissAction = actions.Build(),
        UseTargetSelector = useTargetSelector
      };
      return AddUniqueComponent(onMiss, mergeBehavior, merge ?? MergeMissActions);
    }

    private static void MergeMissActions(
        BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AbilityEffectMiss;
      var target = other as AbilityEffectMiss;
      source.MissAction.Actions =
          source.MissAction.Actions.AppendToArray(target.MissAction.Actions);
    }

    // TODO: Replace w/ child classes
    [SelectTargetAttr]
    public AbilityConfigurator SelectTarget(AbilitySelectTarget target)
    {
      return AddComponent(target);
    }

    /** AbilityExecuteActionOnCast */
    public AbilityConfigurator OnCast(
        ActionListBuilder actions, ConditionsCheckerBuilder checker = null)
    {
      var onCast = new AbilityExecuteActionOnCast
      {
        Conditions = checker?.Build() ?? Constants.Empty.Conditions,
        Actions = actions.Build()
      };
      return AddComponent(onCast);
    }

    /**
     * SpellComponent
     *
     * Merge: Replaces existing component.
     */
    public AbilityConfigurator SetSpellSchool(
        SpellSchool school,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var schoolComponent = new SpellComponent { School = school };
      return AddUniqueComponent(schoolComponent, mergeBehavior, merge);
    }

    /** CantripComponent */
    public AbilityConfigurator MakeCantrip()
    {
      return AddUniqueComponent(new CantripComponent(), ComponentMerge.Skip);
    }

    /** CantripComponent */
    public AbilityConfigurator MakeNotCantrip()
    {
      OnConfigure.Add(blueprint => RemoveComponents(c => c is CantripComponent));
      return this;
    }

    /**
     * AbilityVariants
     *
     * @param names BlueprintAbility
     */
    public AbilityConfigurator AddVariants(params string[] names)
    {
      EnableVariants.AddRange(names.Select(name => BlueprintTool.Get<BlueprintAbility>(name)));
      return this;
    }

    /**
     * AbilityVariants
     *
     * @param names BlueprintAbility
     */
    public AbilityConfigurator RemoveVariants(params string[] names)
    {
      DisableVariants.AddRange(names.Select(name => BlueprintTool.Get<BlueprintAbility>(name)));
      return this;
    }

    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableMetamagics > 0) { Blueprint.AvailableMetamagic |= EnableMetamagics; }
      if (DisableMetamagics > 0) { Blueprint.AvailableMetamagic &= ~DisableMetamagics; }

      if (EnableVariants.Count > 0 || DisableVariants.Count > 0) { ConfigureVariants(); }
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.CustomRange > new Feet(0) && Blueprint.Range != AbilityRange.Custom)
      {
        AddValidationWarning(
            "A custom range value is present without AbilityRange.Custom. It will be ignored.");
      }

      var spellComponent = Blueprint.GetComponent<SpellComponent>();
      if (spellComponent != null && spellComponent.School == SpellSchool.None)
      {
        AddValidationWarning("A spell component is present without a SpellSchool.");
      }

      if (Blueprint.GetComponents<AbilityVariants>().Count() > 1)
      {
        AddValidationWarning("Multiple AbilityVariants components present. Only the first is used.");
      }

      if (Blueprint.GetComponents<CantripComponent>().Count() > 1)
      {
        AddValidationWarning(
            "Multiple AbilityVariants components present. Only the first is used.");
      }

      List<AbilityDeliverEffect> deliverEffects =
          Blueprint.GetComponents<AbilityDeliverEffect>().ToList();
      if (deliverEffects.Count > 1)
      {
        AddValidationWarning("Multiple AbilityDeliverEffects present. Only the first is used.");
      }

      if (Blueprint.GetComponent<AbilityApplyEffect>() is AbilityEffectMiss)
      {
        AddValidationWarning(
            "AbilityEffectMiss is the first AbilityApplyEffect. It will always trigger.");
      }

      List<AbilityApplyEffect> applyEffects =
          Blueprint.GetComponents<AbilityApplyEffect>().ToList();
      if (applyEffects.Count == 1 && applyEffects[0] is AbilityEffectMiss)
      {
        AddValidationWarning(
            "AbilityEffectMiss is the only AbilityApplyEffect. It will trigger on hit or miss.");
      }
      else if (applyEffects.Count == 2 && applyEffects[1] is AbilityEffectMiss)
      {
        var deliverEffect = Blueprint.GetComponent<AbilityDeliverEffect>();
        if (deliverEffect == null)
        {
          AddValidationWarning(
              $"AbilityEffectMiss requires an AbilityDeliverEffect.");
        }
        else if (!SupportsEffectMiss(deliverEffect))
        {
          AddValidationWarning(
              $"AbilityEffectMiss is not compatible with {deliverEffect.GetType()}");
        }
      }
      else if (applyEffects.Count > 1)
      {
        AddValidationWarning("Too many AbilityApplyEffects present. Only the first is used.");
      }

      if (Blueprint.GetComponents<AbilitySelectTarget>().Count() > 1)
      {
        AddValidationWarning(
            "Multiple AbilitySelectTarget components present. Only the first is used.");
      }
    }

    private bool SupportsEffectMiss(AbilityDeliverEffect effect)
    {
      return
          effect is AbilityDeliveredByWeapon
          || effect is AbilityDeliverClashingRocks
          || effect is AbilityDeliverProjectile
          || effect is AbilityDeliverTouch;
    }

    /** Parent must have this ability as an AbilityVariant. */
    private void SetParent(BlueprintAbility parent)
    {
      Blueprint.Parent = parent;

      var parentVariants = parent.GetComponent<AbilityVariants>();
      var abilityRef = Blueprint.ToReference<BlueprintAbilityReference>();
      if (parentVariants != null)
      {
        parentVariants.m_Variants = parentVariants.m_Variants.AppendToArray(abilityRef);
        return;
      }

      parentVariants = new();
      parentVariants.m_Variants = new BlueprintAbilityReference[] { abilityRef };
      parent.AddComponents(parentVariants);
    }

    /** Parent should not have this ability as an AbilityVariant. */
    private void RemoveParent()
    {
      var parentVariants = Blueprint.Parent?.GetComponent<AbilityVariants>();
      Blueprint.Parent = null;
      if (parentVariants == null)
      {
        AddValidationWarning($"Tried to remove an invalid parent.");
        return;
      }
      parentVariants.m_Variants =
          parentVariants.m_Variants
              .ToList()
              .FindAll(ability => ability != Blueprint.ToReference<BlueprintAbilityReference>())
              .ToArray();
    }

    private void ConfigureVariants()
    {
      var component = Blueprint.GetComponent<AbilityVariants>();
      if (component == null)
      {
        // Don't create a component to remove variants
        if (EnableVariants.Count == 0) { return; }

        component = new AbilityVariants();
        AddComponent(component);
      }
      EnableVariants.AddRange(
          component.m_Variants?.Select(reference => reference.Get())
              ?? Array.Empty<BlueprintAbility>());
      var variants = EnableVariants.Except(DisableVariants);

      // Each variant must have this as its parent
      variants.ForEach(
          ability => ability.m_Parent = Blueprint.ToReference<BlueprintAbilityReference>());
      component.m_Variants =
          variants.Select(ability => ability.ToReference<BlueprintAbilityReference>()).ToArray();
    }

    // Attribute for methods which add AbilityApplyEffect components.
    private class ApplyEffectAttr : Attribute { }
    // Attribute for methods which add AbilityDeliverEffect components.
    private class DeliverEffectAttr : Attribute { }
    // Attribute for methods which add AbilitySelectTarget components.
    private class SelectTargetAttr : Attribute { }
  }
}