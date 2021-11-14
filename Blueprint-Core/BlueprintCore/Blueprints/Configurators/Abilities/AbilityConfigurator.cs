using BlueprintCore.Abilities.Restrictions.New;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Craft;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Visual.HitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAbility"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAbility))]
  public class AbilityConfigurator : BaseUnitFactConfigurator<BlueprintAbility, AbilityConfigurator>
  {
    private Metamagic EnableMetamagics;
    private Metamagic DisableMetamagics;

    private AbilityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AbilityConfigurator For(string name) { return new AbilityConfigurator(name); }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AbilityConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAbility>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AbilityConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAbility>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_DefaultAiAction"/>
    /// </summary>
    /// 
    /// <param name="aiAction">
    /// <see cref="BlueprintAiCastSpell"/> Has its <see cref="BlueprintAiCastSpell.m_Ability"/> updated to this blueprint.
    /// </param>
    public AbilityConfigurator SetAiAction(string aiAction)
    {
      OnConfigureInternal(
          blueprint =>
          {
            var aiBlueprint = BlueprintTool.Get<BlueprintAiCastSpell>(aiAction);
            aiBlueprint.m_Ability = Blueprint.ToReference<BlueprintAbilityReference>();
            blueprint.m_DefaultAiAction = aiBlueprint.ToReference<BlueprintAiCastSpell.Reference>();
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Type"/>
    /// </summary>
    public AbilityConfigurator SetType(AbilityType type)
    {
      OnConfigureInternal(blueprint => blueprint.Type = type);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Range"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetCustomRange(int)"/> for <see cref="AbilityRange.Custom"/>.</remarks>
    public AbilityConfigurator SetRange(AbilityRange range)
    {
      if (range == AbilityRange.Custom)
      {
        throw new InvalidOperationException("Use SetCustomRange() for AbilityRange.Custom.");
      }
      OnConfigureInternal(blueprint => blueprint.Range = range);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Range"/> and <see cref="BlueprintAbility.CustomRange"/>
    /// </summary>
    public AbilityConfigurator SetCustomRange(int rangeInFeet)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.Range = AbilityRange.Custom;
            blueprint.CustomRange = new Feet(rangeInFeet);
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ShowNameForVariant"/> and <see cref="BlueprintAbility.OnlyForAllyCaster"/>
    /// </summary>
    public AbilityConfigurator ShowNameForVariant(bool showName = true, bool onlyForAlly = false)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.ShowNameForVariant = showName;
            blueprint.OnlyForAllyCaster = onlyForAlly;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.CanTargetPoint"/>, <see cref="BlueprintAbility.CanTargetEnemies"/>,
    /// <see cref="BlueprintAbility.CanTargetFriends"/>, and <see cref="BlueprintAbility.CanTargetSelf"/>
    /// </summary>
    public AbilityConfigurator AllowTargeting(
        bool? point = null, bool? enemies = null, bool? friends = null, bool? self = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.CanTargetPoint = point ?? blueprint.CanTargetPoint;
            blueprint.CanTargetEnemies = enemies ?? blueprint.CanTargetEnemies;
            blueprint.CanTargetFriends = friends ?? blueprint.CanTargetFriends;
            blueprint.CanTargetSelf = self ?? blueprint.CanTargetSelf;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.SpellResistance"/>
    /// </summary>
    public AbilityConfigurator ApplySpellResistance(bool applySR = true)
    {
      OnConfigureInternal(blueprint => blueprint.SpellResistance = applySR);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ActionBarAutoFillIgnored"/>
    /// </summary>
    public AbilityConfigurator AutoFillActionBar(bool autoFill = true)
    {
      OnConfigureInternal(blueprint => blueprint.ActionBarAutoFillIgnored = !autoFill);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Hidden"/>
    /// </summary>
    public AbilityConfigurator HideInUi(bool hide = true)
    {
      OnConfigureInternal(blueprint => blueprint.Hidden = hide);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.NeedEquipWeapons"/>
    /// </summary>
    public AbilityConfigurator RequireWeapon(bool requireWeapon = true)
    {
      OnConfigureInternal(blueprint => blueprint.NeedEquipWeapons = requireWeapon);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.NotOffensive"/>
    /// </summary>
    public AbilityConfigurator IsOffensive(bool offensive = true)
    {
      OnConfigureInternal(blueprint => blueprint.NotOffensive = !offensive);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.EffectOnAlly"/> and <see cref="BlueprintAbility.EffectOnEnemy"/>
    /// </summary>
    public AbilityConfigurator SetEffectOn(
        AbilityEffectOnUnit? onAlly = null, AbilityEffectOnUnit? onEnemy = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.EffectOnAlly = onAlly ?? blueprint.EffectOnAlly;
            blueprint.EffectOnEnemy = onEnemy ?? blueprint.EffectOnEnemy;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// 
    /// <param name="name"><see cref="BlueprintAbility"/> Has this blueprint added as a variant.</param>
    public AbilityConfigurator SetParent(string name)
    {
      OnConfigureInternal(blueprint => SetParent(BlueprintTool.Get<BlueprintAbility>(name)));
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// 
    /// <remarks>The parent will be updated to remove this blueprint as a variant.</remarks>
    public AbilityConfigurator ClearParent()
    {
      OnConfigureInternal(blueprint => RemoveParent());
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Animation"/>
    /// </summary>
    public AbilityConfigurator SetAnimationStyle(UnitAnimationActionCastSpell.CastAnimationStyle style)
    {
      OnConfigureInternal(blueprint => blueprint.Animation = style);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ActionType"/> and <see cref="BlueprintAbility.HasFastAnimation"/>
    /// </summary>
    public AbilityConfigurator SetActionType(UnitCommand.CommandType type, bool? hasFastAnimation = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.ActionType = type;
            blueprint.HasFastAnimation = hasFastAnimation ?? blueprint.HasFastAnimation;
          });
      return this;
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator AddMetamagics(params Metamagic[] metamagics)
    {
      foreach (Metamagic metamagic in metamagics) { EnableMetamagics |= metamagic; }
      return this;
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator RemoveMetamagics(params Metamagic[] metamagics)
    {
      foreach (Metamagic metamagic in metamagics) { DisableMetamagics |= metamagic; }
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_IsFullRoundAction"/>
    /// </summary>
    public AbilityConfigurator MakeFullRound(bool fullRound = true)
    {
      OnConfigureInternal(blueprint => blueprint.m_IsFullRoundAction = fullRound);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.LocalizedDuration"/>
    /// </summary>
    public AbilityConfigurator SetDurationText(LocalizedString duration)
    {
      OnConfigureInternal(blueprint => blueprint.LocalizedDuration = duration);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.LocalizedSavingThrow"/>
    /// </summary>
    public AbilityConfigurator SetSavingThrowText(LocalizedString savingThrow)
    {
      OnConfigureInternal(blueprint => blueprint.LocalizedSavingThrow = savingThrow);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.MaterialComponent"/>
    /// </summary>
    public AbilityConfigurator SetMaterialComponent(BlueprintAbility.MaterialComponentData component)
    {
      OnConfigureInternal(blueprint => blueprint.MaterialComponent = component);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.DisableLog"/>
    /// </summary>
    public AbilityConfigurator HideFromLog(bool hide = true)
    {
      OnConfigureInternal(blueprint => blueprint.DisableLog = hide);
      return this;
    }


    /// <summary>
    /// Adds <see cref="AbilityCasterAlignment"/>
    /// </summary>
    /// 
    /// <param name="ignoreFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterAlignment))]
    public AbilityConfigurator RequireCasterAlignment(AlignmentMaskType alignment, string ignoreFact = null)
    {
      var hasAlignment = new AbilityCasterAlignment { Alignment = alignment };
      if (ignoreFact != null)
      {
        hasAlignment.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      }
      return AddComponent(hasAlignment);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasFacts"/>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterHasFacts))]
    public AbilityConfigurator RequireCasterFacts(params string[] facts)
    {
      var hasFacts = new AbilityCasterHasFacts
      {
        m_Facts = facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray()
      };
      return AddComponent(hasFacts);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasNoFacts"/>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterHasNoFacts))]
    public AbilityConfigurator RequireCasterHasNoFacts(params string[] facts)
    {
      var hasNoFacts = new AbilityCasterHasNoFacts
      {
        m_Facts = facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray()
      };
      return AddComponent(hasNoFacts);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasChosenWeapon"/>
    /// </summary>
    /// 
    /// <remarks>
    /// Requires the caster to wield their chosen weapon, i.e. the weapon in which they have Weapon Focus or Weapon
    /// Specialization.
    /// </remarks>
    /// 
    /// <param name="parameterizedWeaponFeature"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature">BlueprintParametrizedFeature</see></param>
    /// <param name="ignoreFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterHasChosenWeapon))]
    public AbilityConfigurator RequireCasterHasChosenWeapon(
        string parameterizedWeaponFeature, string ignoreFact = null)
    {
      var hasChosenWeapon = new AbilityCasterHasChosenWeapon
      {
        m_ChosenWeaponFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(parameterizedWeaponFeature)
      };
      if (ignoreFact != null)
      {
        hasChosenWeapon.m_IgnoreWeaponFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      }
      return AddComponent(hasChosenWeapon);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasWeaponWithRangeType"/>
    /// </summary>
    [Implements(typeof(AbilityCasterHasWeaponWithRangeType))]
    public AbilityConfigurator RequireCasterWeaponRange(WeaponRangeType range)
    {
      var hasWeaponRange = new AbilityCasterHasWeaponWithRangeType { RangeType = range };
      return AddComponent(hasWeaponRange);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterInCombat"/>
    /// </summary>
    [Implements(typeof(AbilityCasterInCombat))]
    public AbilityConfigurator RequireCasterInCombat(bool requireInCombat = true)
    {
      var isInCombat = new AbilityCasterInCombat { Not = !requireInCombat };
      return AddComponent(isInCombat);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterIsOnFavoredTerrain"/>
    /// </summary>
    /// 
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(AbilityCasterIsOnFavoredTerrain))]
    public AbilityConfigurator RequireCasterOnFavoredTerrain(string ignoreFeature = null)
    {
      var onFavoredTerrain = new AbilityCasterIsOnFavoredTerrain();
      if (ignoreFeature != null)
      {
        onFavoredTerrain.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      }
      return AddComponent(onFavoredTerrain);
    }

    /// <summary>
    /// Adds <see cref="TargetHasBuffsFromCaster"/>
    /// </summary>
    /// 
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    [Implements(typeof(TargetHasBuffsFromCaster))]
    public AbilityConfigurator RequireTargetHasBuffsFromCaster(string[] buffs, bool requireAllBuffs = false)
    {
      var hasBuffs = new TargetHasBuffsFromCaster
      {
        Buffs = buffs.Select(buff => BlueprintTool.GetRef<BlueprintBuffReference>(buff)).ToArray(),
        RequireAllBuffs = requireAllBuffs
      };
      return AddComponent(hasBuffs);
    }

    /// <summary>
    /// Adds <see cref="AbilityCanTargetDead"/>
    /// </summary>
    [Implements(typeof(AbilityCanTargetDead))]
    public AbilityConfigurator CanTargetDead()
    {
      return AddUniqueComponent(new AbilityCanTargetDead(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliveredByWeapon"/>
    /// </summary>
    [DeliverEffectAttr]
    [Implements(typeof(AbilityDeliveredByWeapon))]
    public AbilityConfigurator DeliveredByWeapon()
    {
      return AddUniqueComponent(new AbilityDeliveredByWeapon(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunAction"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionList</see></remarks>
    [ApplyEffectAttr]
    [Implements(typeof(AbilityEffectRunAction))]
    public AbilityConfigurator RunActions(
        ActionsBuilder actions,
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

    [Implements(typeof(AbilityEffectRunAction))]
    private static void MergeRunActions(BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AbilityEffectRunAction;
      var target = other as AbilityEffectRunAction;
      source.Actions.Actions = CommonTool.Append(source.Actions.Actions, target.Actions.Actions);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectMiss"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionList</see></remarks>
    [Implements(typeof(AbilityEffectMiss))]
    public AbilityConfigurator OnMiss(
        ActionsBuilder actions,
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

    [Implements(typeof(AbilityEffectMiss))]
    private static void MergeMissActions(BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AbilityEffectMiss;
      var target = other as AbilityEffectMiss;
      source.MissAction.Actions = CommonTool.Append(source.MissAction.Actions, target.MissAction.Actions);
    }

    /// <summary>
    /// Adds <see cref="AbilityExecuteActionOnCast"/>
    /// </summary>
    [Implements(typeof(AbilityExecuteActionOnCast))]
    public AbilityConfigurator OnCast(ActionsBuilder actions, ConditionsBuilder checker = null)
    {
      var onCast = new AbilityExecuteActionOnCast
      {
        Conditions = checker?.Build() ?? Constants.Empty.Conditions,
        Actions = actions.Build()
      };
      return AddComponent(onCast);
    }

    /// <summary>
    /// Adds <see cref="SpellComponent"/>
    /// </summary>
    [Implements(typeof(SpellComponent))]
    public AbilityConfigurator SetSpellSchool(
        SpellSchool school,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var schoolComponent = new SpellComponent { School = school };
      return AddUniqueComponent(schoolComponent, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CantripComponent"/>
    /// </summary>
    [Implements(typeof(CantripComponent))]
    public AbilityConfigurator MakeCantrip()
    {
      return AddUniqueComponent(new CantripComponent(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Removes <see cref="CantripComponent"/>
    /// </summary>
    [Implements(typeof(CantripComponent))]
    public AbilityConfigurator MakeNotCantrip()
    {
      return RemoveComponents(c => c is CantripComponent);
    }

    /// <summary>
    /// Adds or modifies <see cref="AbilityVariants"/>
    /// </summary>
    /// 
    /// <param name="abilities"><see cref="BlueprintAbility"/> Updates the parent of each ability to this blueprint</param>
    [Implements(typeof(AbilityVariants))]
    public AbilityConfigurator AddVariants(params string[] abilities)
    {
      return OnConfigureInternal(
          blueprint =>
              AddVariants(
                  blueprint, abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList()));
    }

    [Implements(typeof(AbilityVariants))]
    private void AddVariants(BlueprintAbility bp, List<BlueprintAbilityReference> variants)
    {
      var component = bp.GetComponent<AbilityVariants>();
      if (component is null)
      {
        component = new AbilityVariants();
        AddComponent(component);
      }
      var bpRef = bp.ToReference<BlueprintAbilityReference>();
      variants.ForEach(reference => reference.Get().m_Parent = bpRef);
      component.m_Variants = CommonTool.Append(component.m_Variants, variants.ToArray());
    }

    /// <summary>
    /// Modifies <see cref="AbilityVariants"/>
    /// </summary>
    /// 
    /// <param name="abilities"><see cref="BlueprintAbility"/> Removes this blueprint as the parent of each ability</param>
    [Implements(typeof(AbilityVariants))]
    public AbilityConfigurator RemoveVariants(params string[] abilities)
    {
      return OnConfigureInternal(
          blueprint =>
              RemoveVariants(
                  blueprint, abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList()));
    }

    [Implements(typeof(AbilityVariants))]
    private static void RemoveVariants(BlueprintAbility bp, List<BlueprintAbilityReference> variants)
    {
      var component = bp.GetComponent<AbilityVariants>();
      if (component is null) { return; }

      var nullRef = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      variants.ForEach(
          reference =>
          {
            var ability = reference.Get();
            if (ability.m_Parent?.deserializedGuid == bp.AssetGuid) { ability.m_Parent = nullRef; }
          });
      component.m_Variants =
          component.m_Variants
              .Where(
                  reference => !variants.Exists(removeRef => reference.deserializedGuid == removeRef.deserializedGuid))
              .ToArray();
    }

    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        EnableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        DisableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public AbilityConfigurator ContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }

    /// <summary>
    /// Adds <see cref="InPowerDismemberComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InPowerDismemberComponent))]
    public AbilityConfigurator AddInPowerDismemberComponent()
    {
      return AddComponent(new InPowerDismemberComponent());
    }

    /// <summary>
    /// Adds <see cref="SplitDismemberComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SplitDismemberComponent))]
    public AbilityConfigurator AddSplitDismemberComponent()
    {
      return AddComponent(new SplitDismemberComponent());
    }

    /// <summary>
    /// Adds <see cref="ActionPanelLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActionPanelLogic))]
    public AbilityConfigurator AddActionPanelLogic(
        int Priority,
        ConditionsBuilder AutoFillConditions,
        ConditionsBuilder AutoCastConditions)
    {
      
      var component =  new ActionPanelLogic();
      component.Priority = Priority;
      component.AutoFillConditions = AutoFillConditions.Build();
      component.AutoCastConditions = AutoCastConditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CraftInfoComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CraftInfoComponent))]
    public AbilityConfigurator AddCraftInfoComponent(
        CraftSpellType SpellType,
        CraftSavingThrow SavingThrow,
        CraftAOE AOEType)
    {
      ValidateParam(SpellType);
      ValidateParam(SavingThrow);
      ValidateParam(AOEType);
      
      var component =  new CraftInfoComponent();
      component.SpellType = SpellType;
      component.SavingThrow = SavingThrow;
      component.AOEType = AOEType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityIsFullRoundInTurnBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityIsFullRoundInTurnBased))]
    public AbilityConfigurator AddAbilityIsFullRoundInTurnBased(
        bool FullRoundIfTurnBased)
    {
      
      var component =  new AbilityIsFullRoundInTurnBased();
      component.FullRoundIfTurnBased = FullRoundIfTurnBased;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LevelUpRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LevelUpRecommendation))]
    public AbilityConfigurator AddLevelUpRecommendation(
        ClassesPriority[] ClassPriorities)
    {
      foreach (var item in ClassPriorities)
      {
        ValidateParam(item);
      }
      
      var component =  new LevelUpRecommendation();
      component.ClassPriorities = ClassPriorities;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChirurgeonSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChirurgeonSpell))]
    public AbilityConfigurator AddChirurgeonSpell()
    {
      return AddComponent(new ChirurgeonSpell());
    }

    /// <summary>
    /// Adds <see cref="PretendSpellLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PretendSpellLevel))]
    public AbilityConfigurator AddPretendSpellLevel(
        int SpellLevel)
    {
      
      var component =  new PretendSpellLevel();
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellListComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(SpellListComponent))]
    public AbilityConfigurator AddSpellListComponent(
        string m_SpellList,
        int SpellLevel)
    {
      
      var component =  new SpellListComponent();
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellTypeOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellTypeOverride))]
    public AbilityConfigurator AddSpellTypeOverride(
        SpellSource Type)
    {
      ValidateParam(Type);
      
      var component =  new SpellTypeOverride();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UniqueSpellComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UniqueSpellComponent))]
    public AbilityConfigurator AddUniqueSpellComponent()
    {
      return AddComponent(new UniqueSpellComponent());
    }

    /// <summary>
    /// Adds <see cref="AbilityKineticist"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="CachedDamageSource"><see cref="BlueprintScriptableObject"/></param>
    /// <param name="m_RequiredResource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="ResourceCostIncreasingFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="ResourceCostDecreasingFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityKineticist))]
    public AbilityConfigurator AddAbilityKineticist(
        int BlastBurnCost,
        int InfusionBurnCost,
        int WildTalentBurnCost,
        List<AbilityKineticist.DamageInfo> CachedDamageInfo,
        string CachedDamageSource,
        string m_RequiredResource,
        bool m_IsSpendResource,
        bool CostIsCustom,
        int Amount,
        string[] ResourceCostIncreasingFacts,
        string[] ResourceCostDecreasingFacts)
    {
      foreach (var item in CachedDamageInfo)
      {
        ValidateParam(item);
      }
      
      var component =  new AbilityKineticist();
      component.BlastBurnCost = BlastBurnCost;
      component.InfusionBurnCost = InfusionBurnCost;
      component.WildTalentBurnCost = WildTalentBurnCost;
      component.CachedDamageInfo = CachedDamageInfo;
      component.CachedDamageSource = BlueprintTool.GetRef<AnyBlueprintReference>(CachedDamageSource);
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_RequiredResource);
      component.m_IsSpendResource = m_IsSpendResource;
      component.CostIsCustom = CostIsCustom;
      component.Amount = Amount;
      component.ResourceCostIncreasingFacts = ResourceCostIncreasingFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToList();
      component.ResourceCostDecreasingFacts = ResourceCostDecreasingFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public AbilityConfigurator AddContextCalculateAbilityParams(
        bool UseKineticistMainStat,
        StatType StatType,
        bool StatTypeFromCustomProperty,
        string m_CustomProperty,
        bool ReplaceCasterLevel,
        ContextValue CasterLevel,
        bool ReplaceSpellLevel,
        ContextValue SpellLevel)
    {
      ValidateParam(StatType);
      ValidateParam(CasterLevel);
      ValidateParam(SpellLevel);
      
      var component =  new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.StatTypeFromCustomProperty = StatTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_CustomProperty);
      component.ReplaceCasterLevel = ReplaceCasterLevel;
      component.CasterLevel = CasterLevel;
      component.ReplaceSpellLevel = ReplaceSpellLevel;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public AbilityConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool UseKineticistMainStat,
        StatType StatType,
        string m_CharacterClass)
    {
      ValidateParam(StatType);
      
      var component =  new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public AbilityConfigurator AddContextCalculateSharedValue(
        AbilitySharedValue ValueType,
        ContextDiceValue Value,
        double Modifier)
    {
      ValidateParam(ValueType);
      ValidateParam(Value);
      
      var component =  new ContextCalculateSharedValue();
      component.ValueType = ValueType;
      component.Value = Value;
      component.Modifier = Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public AbilityConfigurator AddContextSetAbilityParams(
        bool Add10ToDC,
        ContextValue DC,
        ContextValue CasterLevel,
        ContextValue Concentration,
        ContextValue SpellLevel)
    {
      ValidateParam(DC);
      ValidateParam(CasterLevel);
      ValidateParam(Concentration);
      ValidateParam(SpellLevel);
      
      var component =  new ContextSetAbilityParams();
      component.Add10ToDC = Add10ToDC;
      component.DC = DC;
      component.CasterLevel = CasterLevel;
      component.Concentration = Concentration;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityTeleportation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CasterDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_CasterAppearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideAppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(ArmyAbilityTeleportation))]
    public AbilityConfigurator AddArmyAbilityTeleportation(
        Feet Radius,
        GameObject PortalFromPrefab,
        GameObject PortalToPrefab,
        string PortalBone,
        GameObject CasterDisappearFx,
        GameObject CasterAppearFx,
        GameObject SideDisappearFx,
        GameObject SideAppearFx,
        string m_CasterDisappearProjectile,
        string m_CasterAppearProjectile,
        string m_SideDisappearProjectile,
        string m_SideAppearProjectile)
    {
      ValidateParam(Radius);
      ValidateParam(PortalFromPrefab);
      ValidateParam(PortalToPrefab);
      ValidateParam(CasterDisappearFx);
      ValidateParam(CasterAppearFx);
      ValidateParam(SideDisappearFx);
      ValidateParam(SideAppearFx);
      
      var component =  new ArmyAbilityTeleportation();
      component.Radius = Radius;
      component.PortalFromPrefab = PortalFromPrefab;
      component.PortalToPrefab = PortalToPrefab;
      component.PortalBone = PortalBone;
      component.CasterDisappearFx = CasterDisappearFx;
      component.CasterAppearFx = CasterAppearFx;
      component.SideDisappearFx = SideDisappearFx;
      component.SideAppearFx = SideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideAppearProjectile);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityOnInBattleUnits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityOnInBattleUnits))]
    public AbilityConfigurator AddAbilityOnInBattleUnits(
        AbilityOnInBattleUnits.AllyState m_FactionType)
    {
      ValidateParam(m_FactionType);
      
      var component =  new AbilityOnInBattleUnits();
      component.m_FactionType = m_FactionType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAffectLineOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAffectLineOnGrid))]
    public AbilityConfigurator AddAbilityAffectLineOnGrid(
        bool m_Vertical,
        Kingmaker.UnitLogic.Abilities.Components.TargetType m_TargetType,
        ConditionsBuilder m_Condition,
        Feet m_SpreadSpeed)
    {
      ValidateParam(m_TargetType);
      ValidateParam(m_SpreadSpeed);
      
      var component =  new AbilityAffectLineOnGrid();
      component.m_Vertical = m_Vertical;
      component.m_TargetType = m_TargetType;
      component.m_Condition = m_Condition.Build();
      component.m_SpreadSpeed = m_SpreadSpeed;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityApplyFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityApplyFact))]
    public AbilityConfigurator AddAbilityApplyFact(
        AbilityApplyFact.FactRestriction m_Restriction,
        string[] m_Facts,
        bool m_HasDuration,
        ContextDurationValue m_Duration)
    {
      ValidateParam(m_Restriction);
      ValidateParam(m_Duration);
      
      var component =  new AbilityApplyFact();
      component.m_Restriction = m_Restriction;
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_HasDuration = m_HasDuration;
      component.m_Duration = m_Duration;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityConvertSpellLevelToResource"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintScriptableObject"/></param>
    [Generated]
    [Implements(typeof(AbilityConvertSpellLevelToResource))]
    public AbilityConfigurator AddAbilityConvertSpellLevelToResource(
        string m_Resource)
    {
      
      var component =  new AbilityConvertSpellLevelToResource();
      component.m_Resource = BlueprintTool.GetRef<AnyBlueprintReference>(m_Resource);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomAnimationByBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomAnimationByBuff))]
    public AbilityConfigurator AddAbilityCustomAnimationByBuff(
        UnitAnimationActionClip DefaultAnimation,
        AbilityCustomAnimationByBuff.Entry[] Variants)
    {
      ValidateParam(DefaultAnimation);
      foreach (var item in Variants)
      {
        ValidateParam(item);
      }
      
      var component =  new AbilityCustomAnimationByBuff();
      component.DefaultAnimation = DefaultAnimation;
      component.Variants = Variants;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomAttack))]
    public AbilityConfigurator AddAbilityCustomAttack()
    {
      return AddComponent(new AbilityCustomAttack());
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomCharge))]
    public AbilityConfigurator AddAbilityCustomCharge()
    {
      return AddComponent(new AbilityCustomCharge());
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomCleave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_GreaterFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomCleave))]
    public AbilityConfigurator AddAbilityCustomCleave(
        string m_GreaterFeature)
    {
      
      var component =  new AbilityCustomCleave();
      component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_GreaterFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CasterDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_CasterAppearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideAppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDimensionDoor))]
    public AbilityConfigurator AddAbilityCustomDimensionDoor(
        Feet Radius,
        GameObject PortalFromPrefab,
        GameObject PortalToPrefab,
        string PortalBone,
        GameObject CasterDisappearFx,
        GameObject CasterAppearFx,
        GameObject SideDisappearFx,
        GameObject SideAppearFx,
        string m_CasterDisappearProjectile,
        string m_CasterAppearProjectile,
        string m_SideDisappearProjectile,
        string m_SideAppearProjectile)
    {
      ValidateParam(Radius);
      ValidateParam(PortalFromPrefab);
      ValidateParam(PortalToPrefab);
      ValidateParam(CasterDisappearFx);
      ValidateParam(CasterAppearFx);
      ValidateParam(SideDisappearFx);
      ValidateParam(SideAppearFx);
      
      var component =  new AbilityCustomDimensionDoor();
      component.Radius = Radius;
      component.PortalFromPrefab = PortalFromPrefab;
      component.PortalToPrefab = PortalToPrefab;
      component.PortalBone = PortalBone;
      component.CasterDisappearFx = CasterDisappearFx;
      component.CasterAppearFx = CasterAppearFx;
      component.SideDisappearFx = SideDisappearFx;
      component.SideAppearFx = SideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideAppearProjectile);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoorSwap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_AppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDimensionDoorSwap))]
    public AbilityConfigurator AddAbilityCustomDimensionDoorSwap(
        GameObject PortalFromPrefab,
        string PortalBone,
        GameObject DisappearFx,
        GameObject AppearFx,
        string m_DisappearProjectile,
        string m_AppearProjectile)
    {
      ValidateParam(PortalFromPrefab);
      ValidateParam(DisappearFx);
      ValidateParam(AppearFx);
      
      var component =  new AbilityCustomDimensionDoorSwap();
      component.PortalFromPrefab = PortalFromPrefab;
      component.PortalBone = PortalBone;
      component.DisappearFx = DisappearFx;
      component.AppearFx = AppearFx;
      component.m_DisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_DisappearProjectile);
      component.m_AppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_AppearProjectile);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoorTargets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CasterDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_CasterAppearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideAppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDimensionDoorTargets))]
    public AbilityConfigurator AddAbilityCustomDimensionDoorTargets(
        UnitEvaluator[] Targets,
        Feet Radius,
        GameObject PortalFromPrefab,
        GameObject PortalToPrefab,
        string PortalBone,
        GameObject CasterDisappearFx,
        GameObject CasterAppearFx,
        GameObject SideDisappearFx,
        GameObject SideAppearFx,
        string m_CasterDisappearProjectile,
        string m_CasterAppearProjectile,
        string m_SideDisappearProjectile,
        string m_SideAppearProjectile)
    {
      foreach (var item in Targets)
      {
        ValidateParam(item);
      }
      ValidateParam(Radius);
      ValidateParam(PortalFromPrefab);
      ValidateParam(PortalToPrefab);
      ValidateParam(CasterDisappearFx);
      ValidateParam(CasterAppearFx);
      ValidateParam(SideDisappearFx);
      ValidateParam(SideAppearFx);
      
      var component =  new AbilityCustomDimensionDoorTargets();
      component.Targets = Targets;
      component.Radius = Radius;
      component.PortalFromPrefab = PortalFromPrefab;
      component.PortalToPrefab = PortalToPrefab;
      component.PortalBone = PortalBone;
      component.CasterDisappearFx = CasterDisappearFx;
      component.CasterAppearFx = CasterAppearFx;
      component.SideDisappearFx = SideDisappearFx;
      component.SideAppearFx = SideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideAppearProjectile);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDweomerLeap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CasterDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_CasterAppearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideAppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDweomerLeap))]
    public AbilityConfigurator AddAbilityCustomDweomerLeap(
        Feet Radius,
        GameObject PortalFromPrefab,
        GameObject PortalToPrefab,
        string PortalBone,
        GameObject CasterDisappearFx,
        GameObject CasterAppearFx,
        GameObject SideDisappearFx,
        GameObject SideAppearFx,
        string m_CasterDisappearProjectile,
        string m_CasterAppearProjectile,
        string m_SideDisappearProjectile,
        string m_SideAppearProjectile)
    {
      ValidateParam(Radius);
      ValidateParam(PortalFromPrefab);
      ValidateParam(PortalToPrefab);
      ValidateParam(CasterDisappearFx);
      ValidateParam(CasterAppearFx);
      ValidateParam(SideDisappearFx);
      ValidateParam(SideAppearFx);
      
      var component =  new AbilityCustomDweomerLeap();
      component.Radius = Radius;
      component.PortalFromPrefab = PortalFromPrefab;
      component.PortalToPrefab = PortalToPrefab;
      component.PortalBone = PortalBone;
      component.CasterDisappearFx = CasterDisappearFx;
      component.CasterAppearFx = CasterAppearFx;
      component.SideDisappearFx = SideDisappearFx;
      component.SideAppearFx = SideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideAppearProjectile);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomFlashStep"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FlashShot"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_CasterDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_CasterAppearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideDisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_SideAppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomFlashStep))]
    public AbilityConfigurator AddAbilityCustomFlashStep(
        string m_FlashShot,
        Feet Radius,
        GameObject PortalFromPrefab,
        GameObject PortalToPrefab,
        string PortalBone,
        GameObject CasterDisappearFx,
        GameObject CasterAppearFx,
        GameObject SideDisappearFx,
        GameObject SideAppearFx,
        string m_CasterDisappearProjectile,
        string m_CasterAppearProjectile,
        string m_SideDisappearProjectile,
        string m_SideAppearProjectile)
    {
      ValidateParam(Radius);
      ValidateParam(PortalFromPrefab);
      ValidateParam(PortalToPrefab);
      ValidateParam(CasterDisappearFx);
      ValidateParam(CasterAppearFx);
      ValidateParam(SideDisappearFx);
      ValidateParam(SideAppearFx);
      
      var component =  new AbilityCustomFlashStep();
      component.m_FlashShot = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_FlashShot);
      component.Radius = Radius;
      component.PortalFromPrefab = PortalFromPrefab;
      component.PortalToPrefab = PortalToPrefab;
      component.PortalBone = PortalBone;
      component.CasterDisappearFx = CasterDisappearFx;
      component.CasterAppearFx = CasterAppearFx;
      component.SideDisappearFx = SideDisappearFx;
      component.SideAppearFx = SideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_CasterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_SideAppearProjectile);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomFly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomFly))]
    public AbilityConfigurator AddAbilityCustomFly(
        UnitAnimationActionBuffState Animation,
        float MaxHeight,
        float FlyUpTime,
        float TakeoffTime,
        float LandTime,
        AnimationCurve TakeOff,
        AnimationCurve Landing)
    {
      ValidateParam(Animation);
      ValidateParam(TakeOff);
      ValidateParam(Landing);
      
      var component =  new AbilityCustomFly();
      component.Animation = Animation;
      component.MaxHeight = MaxHeight;
      component.FlyUpTime = FlyUpTime;
      component.TakeoffTime = TakeoffTime;
      component.LandTime = LandTime;
      component.TakeOff = TakeOff;
      component.Landing = Landing;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomMeleeAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="m_RowdyFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomMeleeAttack))]
    public AbilityConfigurator AddAbilityCustomMeleeAttack(
        AbilityCustomMeleeAttack.AttackType m_Type,
        int VitalStrikeMod,
        string m_MythicBlueprint,
        string m_RowdyFeature)
    {
      ValidateParam(m_Type);
      
      var component =  new AbilityCustomMeleeAttack();
      component.m_Type = m_Type;
      component.VitalStrikeMod = VitalStrikeMod;
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(m_MythicBlueprint);
      component.m_RowdyFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_RowdyFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomMove))]
    public AbilityConfigurator AddAbilityCustomMove()
    {
      return AddComponent(new AbilityCustomMove());
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomOverrun"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AddBuffWhileRunning"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomOverrun))]
    public AbilityConfigurator AddAbilityCustomOverrun(
        string m_AddBuffWhileRunning,
        float DelayBeforeStart,
        float DelayAfterFinish,
        bool FirstTargetOnly,
        bool AutoSuccess,
        bool StopOnCorpulence,
        ActionsBuilder Actions)
    {
      
      var component =  new AbilityCustomOverrun();
      component.m_AddBuffWhileRunning = BlueprintTool.GetRef<BlueprintBuffReference>(m_AddBuffWhileRunning);
      component.DelayBeforeStart = DelayBeforeStart;
      component.DelayAfterFinish = DelayAfterFinish;
      component.FirstTargetOnly = FirstTargetOnly;
      component.AutoSuccess = AutoSuccess;
      component.StopOnCorpulence = StopOnCorpulence;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomTeleportation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomTeleportation))]
    public AbilityConfigurator AddAbilityCustomTeleportation(
        string m_Projectile,
        GameObject DisappearFx,
        float DisappearDuration,
        GameObject AppearFx,
        float AppearDuration)
    {
      ValidateParam(DisappearFx);
      ValidateParam(AppearFx);
      
      var component =  new AbilityCustomTeleportation();
      component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_Projectile);
      component.DisappearFx = DisappearFx;
      component.DisappearDuration = DisappearDuration;
      component.AppearFx = AppearFx;
      component.AppearDuration = AppearDuration;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomTongueGrab"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomTongueGrab))]
    public AbilityConfigurator AddAbilityCustomTongueGrab(
        UnitAnimationCustomTongueGrab AnimationAction,
        float TongueStickSpeed,
        float TongueReturnSpeed,
        AnimationCurve StickCurve,
        AnimationCurve ReturnCurve,
        Feet PullDistance,
        bool m_ReturnTargetAbility)
    {
      ValidateParam(AnimationAction);
      ValidateParam(StickCurve);
      ValidateParam(ReturnCurve);
      ValidateParam(PullDistance);
      
      var component =  new AbilityCustomTongueGrab();
      component.AnimationAction = AnimationAction;
      component.TongueStickSpeed = TongueStickSpeed;
      component.TongueReturnSpeed = TongueReturnSpeed;
      component.StickCurve = StickCurve;
      component.ReturnCurve = ReturnCurve;
      component.PullDistance = PullDistance;
      component.m_ReturnTargetAbility = m_ReturnTargetAbility;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomVitalStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="m_RowdyFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomVitalStrike))]
    public AbilityConfigurator AddAbilityCustomVitalStrike(
        int VitalStrikeMod,
        string m_MythicBlueprint,
        string m_RowdyFeature)
    {
      
      var component =  new AbilityCustomVitalStrike();
      component.VitalStrikeMod = VitalStrikeMod;
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(m_MythicBlueprint);
      component.m_RowdyFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_RowdyFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverAttackWithWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDeliverAttackWithWeapon))]
    public AbilityConfigurator AddAbilityDeliverAttackWithWeapon()
    {
      return AddComponent(new AbilityDeliverAttackWithWeapon());
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverChain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ProjectileFirst"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_Projectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverChain))]
    public AbilityConfigurator AddAbilityDeliverChain(
        string m_ProjectileFirst,
        string m_Projectile,
        ContextValue TargetsCount,
        Feet Radius,
        bool TargetDead,
        Kingmaker.UnitLogic.Abilities.Components.TargetType m_TargetType,
        ConditionsBuilder m_Condition)
    {
      ValidateParam(TargetsCount);
      ValidateParam(Radius);
      ValidateParam(m_TargetType);
      
      var component =  new AbilityDeliverChain();
      component.m_ProjectileFirst = BlueprintTool.GetRef<BlueprintProjectileReference>(m_ProjectileFirst);
      component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_Projectile);
      component.TargetsCount = TargetsCount;
      component.Radius = Radius;
      component.TargetDead = TargetDead;
      component.m_TargetType = m_TargetType;
      component.m_Condition = m_Condition.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverClashingRocks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverClashingRocks))]
    public AbilityConfigurator AddAbilityDeliverClashingRocks(
        string m_Projectile,
        Feet Width,
        Feet DistanceToTarget,
        bool IgnoreConcealment,
        bool NeedAttackRoll,
        string m_Weapon)
    {
      ValidateParam(Width);
      ValidateParam(DistanceToTarget);
      
      var component =  new AbilityDeliverClashingRocks();
      component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_Projectile);
      component.Width = Width;
      component.DistanceToTarget = DistanceToTarget;
      component.IgnoreConcealment = IgnoreConcealment;
      component.NeedAttackRoll = NeedAttackRoll;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDeliverDelay))]
    public AbilityConfigurator AddAbilityDeliverDelay(
        float DelaySeconds)
    {
      
      var component =  new AbilityDeliverDelay();
      component.DelaySeconds = DelaySeconds;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverProjectile"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projectiles"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_ControlledProjectileHolderBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverProjectile))]
    public AbilityConfigurator AddAbilityDeliverProjectile(
        string[] m_Projectiles,
        AbilityProjectileType Type,
        bool IsHandOfTheApprentice,
        Feet m_Length,
        Feet m_LineWidth,
        bool NeedAttackRoll,
        string m_Weapon,
        bool ReplaceAttackRollBonusStat,
        StatType AttackRollBonusStat,
        bool UseMaxProjectilesCount,
        AbilityRankType MaxProjectilesCountRank,
        float DelayBetweenProjectiles,
        string m_ControlledProjectileHolderBuff)
    {
      ValidateParam(Type);
      ValidateParam(m_Length);
      ValidateParam(m_LineWidth);
      ValidateParam(AttackRollBonusStat);
      ValidateParam(MaxProjectilesCountRank);
      
      var component =  new AbilityDeliverProjectile();
      component.m_Projectiles = m_Projectiles.Select(bp => BlueprintTool.GetRef<BlueprintProjectileReference>(bp)).ToArray();
      component.Type = Type;
      component.IsHandOfTheApprentice = IsHandOfTheApprentice;
      component.m_Length = m_Length;
      component.m_LineWidth = m_LineWidth;
      component.NeedAttackRoll = NeedAttackRoll;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      component.ReplaceAttackRollBonusStat = ReplaceAttackRollBonusStat;
      component.AttackRollBonusStat = AttackRollBonusStat;
      component.UseMaxProjectilesCount = UseMaxProjectilesCount;
      component.MaxProjectilesCountRank = MaxProjectilesCountRank;
      component.DelayBetweenProjectiles = DelayBetweenProjectiles;
      component.m_ControlledProjectileHolderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_ControlledProjectileHolderBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverProjectileOnGrid"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Projectiles"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_ControlledProjectileHolderBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverProjectileOnGrid))]
    public AbilityConfigurator AddAbilityDeliverProjectileOnGrid(
        bool LaunchProjectileOnGridLine,
        int LengthInCells,
        string[] m_Projectiles,
        AbilityProjectileType Type,
        bool IsHandOfTheApprentice,
        Feet m_Length,
        Feet m_LineWidth,
        bool NeedAttackRoll,
        string m_Weapon,
        bool ReplaceAttackRollBonusStat,
        StatType AttackRollBonusStat,
        bool UseMaxProjectilesCount,
        AbilityRankType MaxProjectilesCountRank,
        float DelayBetweenProjectiles,
        string m_ControlledProjectileHolderBuff)
    {
      ValidateParam(Type);
      ValidateParam(m_Length);
      ValidateParam(m_LineWidth);
      ValidateParam(AttackRollBonusStat);
      ValidateParam(MaxProjectilesCountRank);
      
      var component =  new AbilityDeliverProjectileOnGrid();
      component.LaunchProjectileOnGridLine = LaunchProjectileOnGridLine;
      component.LengthInCells = LengthInCells;
      component.m_Projectiles = m_Projectiles.Select(bp => BlueprintTool.GetRef<BlueprintProjectileReference>(bp)).ToArray();
      component.Type = Type;
      component.IsHandOfTheApprentice = IsHandOfTheApprentice;
      component.m_Length = m_Length;
      component.m_LineWidth = m_LineWidth;
      component.NeedAttackRoll = NeedAttackRoll;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      component.ReplaceAttackRollBonusStat = ReplaceAttackRollBonusStat;
      component.AttackRollBonusStat = AttackRollBonusStat;
      component.UseMaxProjectilesCount = UseMaxProjectilesCount;
      component.MaxProjectilesCountRank = MaxProjectilesCountRank;
      component.DelayBetweenProjectiles = DelayBetweenProjectiles;
      component.m_ControlledProjectileHolderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_ControlledProjectileHolderBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverTouch"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TouchWeapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverTouch))]
    public AbilityConfigurator AddAbilityDeliverTouch(
        string m_TouchWeapon)
    {
      
      var component =  new AbilityDeliverTouch();
      component.m_TouchWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_TouchWeapon);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDemonCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDemonCharge))]
    public AbilityConfigurator AddAbilityDemonCharge()
    {
      return AddComponent(new AbilityDemonCharge());
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public AbilityConfigurator AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedPoint"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityEffectRunActionOnClickedPoint))]
    public AbilityConfigurator AddAbilityEffectRunActionOnClickedPoint(
        ActionsBuilder Action)
    {
      
      var component =  new AbilityEffectRunActionOnClickedPoint();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityEffectRunActionOnClickedTarget))]
    public AbilityConfigurator AddAbilityEffectRunActionOnClickedTarget(
        ActionsBuilder Action)
    {
      
      var component =  new AbilityEffectRunActionOnClickedTarget();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityEffectRunActionOnClickedUnit))]
    public AbilityConfigurator AddAbilityEffectRunActionOnClickedUnit(
        ActionsBuilder Action)
    {
      
      var component =  new AbilityEffectRunActionOnClickedUnit();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectStickyTouch"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TouchDeliveryAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AbilityEffectStickyTouch))]
    public AbilityConfigurator AddAbilityEffectStickyTouch(
        string m_TouchDeliveryAbility)
    {
      
      var component =  new AbilityEffectStickyTouch();
      component.m_TouchDeliveryAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_TouchDeliveryAbility);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityIsBomb"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityIsBomb))]
    public AbilityConfigurator AddAbilityIsBomb()
    {
      return AddComponent(new AbilityIsBomb());
    }

    /// <summary>
    /// Adds <see cref="AbilityKineticBlade"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityKineticBlade))]
    public AbilityConfigurator AddAbilityKineticBlade()
    {
      return AddComponent(new AbilityKineticBlade());
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementCanMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRequirementCanMove))]
    public AbilityConfigurator AddAbilityRequirementCanMove()
    {
      return AddComponent(new AbilityRequirementCanMove());
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementHasCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRequirementHasCondition))]
    public AbilityConfigurator AddAbilityRequirementHasCondition(
        bool Not,
        UnitCondition[] Conditions,
        List<UnitCondition> m_ConditionsCache)
    {
      foreach (var item in Conditions)
      {
        ValidateParam(item);
      }
      foreach (var item in m_ConditionsCache)
      {
        ValidateParam(item);
      }
      
      var component =  new AbilityRequirementHasCondition();
      component.Not = Not;
      component.Conditions = Conditions;
      component.m_ConditionsCache = m_ConditionsCache;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementHasItemInHands"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRequirementHasItemInHands))]
    public AbilityConfigurator AddAbilityRequirementHasItemInHands(
        AbilityRequirementHasItemInHands.RequirementType m_Type)
    {
      ValidateParam(m_Type);
      
      var component =  new AbilityRequirementHasItemInHands();
      component.m_Type = m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredResource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="ResourceCostIncreasingFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="ResourceCostDecreasingFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityResourceLogic))]
    public AbilityConfigurator AddAbilityResourceLogic(
        string m_RequiredResource,
        bool m_IsSpendResource,
        bool CostIsCustom,
        int Amount,
        string[] ResourceCostIncreasingFacts,
        string[] ResourceCostDecreasingFacts)
    {
      
      var component =  new AbilityResourceLogic();
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_RequiredResource);
      component.m_IsSpendResource = m_IsSpendResource;
      component.CostIsCustom = CostIsCustom;
      component.Amount = Amount;
      component.ResourceCostIncreasingFacts = ResourceCostIncreasingFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToList();
      component.ResourceCostDecreasingFacts = ResourceCostDecreasingFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityRestoreSpellSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRestoreSpellSlot))]
    public AbilityConfigurator AddAbilityRestoreSpellSlot(
        bool AnySpellLevel,
        int SpellLevel)
    {
      
      var component =  new AbilityRestoreSpellSlot();
      component.AnySpellLevel = AnySpellLevel;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityRestoreSpontaneousSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRestoreSpontaneousSpell))]
    public AbilityConfigurator AddAbilityRestoreSpontaneousSpell(
        bool AnySpellLevel,
        int SpellLevel)
    {
      
      var component =  new AbilityRestoreSpontaneousSpell();
      component.AnySpellLevel = AnySpellLevel;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityShadowSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Factor"><see cref="BlueprintUnitProperty"/></param>
    /// <param name="SpellList"><see cref="BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(AbilityShadowSpell))]
    public AbilityConfigurator AddAbilityShadowSpell(
        SpellSchool School,
        string m_Factor,
        int MaxSpellLevel,
        string SpellList)
    {
      ValidateParam(School);
      
      var component =  new AbilityShadowSpell();
      component.School = School;
      component.m_Factor = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_Factor);
      component.MaxSpellLevel = MaxSpellLevel;
      component.SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(SpellList);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityShowIfCasterHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_UnitFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityShowIfCasterHasFact))]
    public AbilityConfigurator AddAbilityShowIfCasterHasFact(
        string m_UnitFact,
        bool Not)
    {
      
      var component =  new AbilityShowIfCasterHasFact();
      component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_UnitFact);
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilitySillyFeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilitySillyFeed))]
    public AbilityConfigurator AddAbilitySillyFeed(
        UnitAnimationActionClip m_Animation)
    {
      ValidateParam(m_Animation);
      
      var component =  new AbilitySillyFeed();
      component.m_Animation = m_Animation;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilitySwitchDualCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DisappearProjectile"><see cref="BlueprintProjectile"/></param>
    /// <param name="m_AppearProjectile"><see cref="BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilitySwitchDualCompanion))]
    public AbilityConfigurator AddAbilitySwitchDualCompanion(
        GameObject PortalPrefab,
        string PortalBone,
        GameObject DisappearFx,
        GameObject AppearFx,
        string m_DisappearProjectile,
        string m_AppearProjectile,
        float AppearDelay)
    {
      ValidateParam(PortalPrefab);
      ValidateParam(DisappearFx);
      ValidateParam(AppearFx);
      
      var component =  new AbilitySwitchDualCompanion();
      component.PortalPrefab = PortalPrefab;
      component.PortalBone = PortalBone;
      component.DisappearFx = DisappearFx;
      component.AppearFx = AppearFx;
      component.m_DisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_DisappearProjectile);
      component.m_AppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(m_AppearProjectile);
      component.AppearDelay = AppearDelay;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetsAround"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetsAround))]
    public AbilityConfigurator AddAbilityTargetsAround(
        Feet m_Radius,
        Kingmaker.UnitLogic.Abilities.Components.TargetType m_TargetType,
        bool m_IncludeDead,
        ConditionsBuilder m_Condition,
        Feet m_SpreadSpeed)
    {
      ValidateParam(m_Radius);
      ValidateParam(m_TargetType);
      ValidateParam(m_SpreadSpeed);
      
      var component =  new AbilityTargetsAround();
      component.m_Radius = m_Radius;
      component.m_TargetType = m_TargetType;
      component.m_IncludeDead = m_IncludeDead;
      component.m_Condition = m_Condition.Build();
      component.m_SpreadSpeed = m_SpreadSpeed;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetsAroundOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetsAroundOnGrid))]
    public AbilityConfigurator AddAbilityTargetsAroundOnGrid(
        int m_DiameterInCells,
        Kingmaker.UnitLogic.Abilities.Components.TargetType m_TargetType,
        bool m_IncludeDead,
        ConditionsBuilder m_Condition,
        Feet m_SpreadSpeed)
    {
      ValidateParam(m_TargetType);
      ValidateParam(m_SpreadSpeed);
      
      var component =  new AbilityTargetsAroundOnGrid();
      component.m_DiameterInCells = m_DiameterInCells;
      component.m_TargetType = m_TargetType;
      component.m_IncludeDead = m_IncludeDead;
      component.m_Condition = m_Condition.Build();
      component.m_SpreadSpeed = m_SpreadSpeed;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilitySwtichDualCompanionChecker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilitySwtichDualCompanionChecker))]
    public AbilityConfigurator AddAbilitySwtichDualCompanionChecker()
    {
      return AddComponent(new AbilitySwtichDualCompanionChecker());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetAlignment))]
    public AbilityConfigurator AddAbilityTargetAlignment(
        AlignmentMaskType Alignment)
    {
      ValidateParam(Alignment);
      
      var component =  new AbilityTargetAlignment();
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetBreathOfLife"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RecentlyDeadBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_UndeadFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetBreathOfLife))]
    public AbilityConfigurator AddAbilityTargetBreathOfLife(
        string m_RecentlyDeadBuff,
        string m_UndeadFact)
    {
      
      var component =  new AbilityTargetBreathOfLife();
      component.m_RecentlyDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_RecentlyDeadBuff);
      component.m_UndeadFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_UndeadFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCanSeeCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetCanSeeCaster))]
    public AbilityConfigurator AddAbilityTargetCanSeeCaster(
        bool Not)
    {
      
      var component =  new AbilityTargetCanSeeCaster();
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetDivineTroth"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetDivineTroth))]
    public AbilityConfigurator AddAbilityTargetDivineTroth(
        string m_CheckBuff)
    {
      
      var component =  new AbilityTargetDivineTroth();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHPCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FactToCheck"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHPCondition))]
    public AbilityConfigurator AddAbilityTargetHPCondition(
        int CurrentHPLessThan,
        bool Inverted,
        bool CheckFact,
        string m_FactToCheck,
        int OverrideCurrentHPLessThan)
    {
      
      var component =  new AbilityTargetHPCondition();
      component.CurrentHPLessThan = CurrentHPLessThan;
      component.Inverted = Inverted;
      component.CheckFact = CheckFact;
      component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_FactToCheck);
      component.OverrideCurrentHPLessThan = OverrideCurrentHPLessThan;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHasFact))]
    public AbilityConfigurator AddAbilityTargetHasFact(
        string[] m_CheckedFacts,
        bool Inverted)
    {
      
      var component =  new AbilityTargetHasFact();
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Inverted = Inverted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasMeleeWeaponInPrimaryHand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetHasMeleeWeaponInPrimaryHand))]
    public AbilityConfigurator AddAbilityTargetHasMeleeWeaponInPrimaryHand()
    {
      return AddComponent(new AbilityTargetHasMeleeWeaponInPrimaryHand());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasNoFactUnless"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_UnlessFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHasNoFactUnless))]
    public AbilityConfigurator AddAbilityTargetHasNoFactUnless(
        string[] m_CheckedFacts,
        string m_UnlessFact)
    {
      
      var component =  new AbilityTargetHasNoFactUnless();
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_UnlessFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_UnlessFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAlly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsAlly))]
    public AbilityConfigurator AddAbilityTargetIsAlly(
        bool Not)
    {
      
      var component =  new AbilityTargetIsAlly();
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAreaEffectFromCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsAreaEffectFromCaster))]
    public AbilityConfigurator AddAbilityTargetIsAreaEffectFromCaster()
    {
      return AddComponent(new AbilityTargetIsAreaEffectFromCaster());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsDeadAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsDeadAnimalCompanion))]
    public AbilityConfigurator AddAbilityTargetIsDeadAnimalCompanion()
    {
      return AddComponent(new AbilityTargetIsDeadAnimalCompanion());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsDeadCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsDeadCompanion))]
    public AbilityConfigurator AddAbilityTargetIsDeadCompanion()
    {
      return AddComponent(new AbilityTargetIsDeadCompanion());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsFavoredEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsFavoredEnemy))]
    public AbilityConfigurator AddAbilityTargetIsFavoredEnemy()
    {
      return AddComponent(new AbilityTargetIsFavoredEnemy());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsNotDevoured"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsNotDevoured))]
    public AbilityConfigurator AddAbilityTargetIsNotDevoured()
    {
      return AddComponent(new AbilityTargetIsNotDevoured());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsPartyMember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsPartyMember))]
    public AbilityConfigurator AddAbilityTargetIsPartyMember(
        bool Not)
    {
      
      var component =  new AbilityTargetIsPartyMember();
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetMaximumHitDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetMaximumHitDice))]
    public AbilityConfigurator AddAbilityTargetMaximumHitDice(
        int HitDice)
    {
      
      var component =  new AbilityTargetMaximumHitDice();
      component.HitDice = HitDice;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetNotSelf"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetNotSelf))]
    public AbilityConfigurator AddAbilityTargetNotSelf()
    {
      return AddComponent(new AbilityTargetNotSelf());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetStatCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetStatCondition))]
    public AbilityConfigurator AddAbilityTargetStatCondition(
        StatType Stat,
        int GreaterThan,
        bool Inverted)
    {
      ValidateParam(Stat);
      
      var component =  new AbilityTargetStatCondition();
      component.Stat = Stat;
      component.GreaterThan = GreaterThan;
      component.Inverted = Inverted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetStoneToFlesh"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetStoneToFlesh))]
    public AbilityConfigurator AddAbilityTargetStoneToFlesh(
        bool CanBeNotPetrified)
    {
      
      var component =  new AbilityTargetStoneToFlesh();
      component.CanBeNotPetrified = CanBeNotPetrified;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DimensionDoorRestrictionIgnorance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DimensionDoorRestrictionIgnorance))]
    public AbilityConfigurator AddDimensionDoorRestrictionIgnorance()
    {
      return AddComponent(new DimensionDoorRestrictionIgnorance());
    }

    /// <summary>
    /// Adds <see cref="LineOfSightIgnorance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LineOfSightIgnorance))]
    public AbilityConfigurator AddLineOfSightIgnorance()
    {
      return AddComponent(new LineOfSightIgnorance());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterMainWeaponCheck))]
    public AbilityConfigurator AddAbilityCasterMainWeaponCheck(
        WeaponCategory[] Category)
    {
      foreach (var item in Category)
      {
        ValidateParam(item);
      }
      
      var component =  new AbilityCasterMainWeaponCheck();
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponIsMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterMainWeaponIsMelee))]
    public AbilityConfigurator AddAbilityCasterMainWeaponIsMelee()
    {
      return AddComponent(new AbilityCasterMainWeaponIsMelee());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponIsTwoHanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterMainWeaponIsTwoHanded))]
    public AbilityConfigurator AddAbilityCasterMainWeaponIsTwoHanded()
    {
      return AddComponent(new AbilityCasterMainWeaponIsTwoHanded());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterNotPolymorphed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterNotPolymorphed))]
    public AbilityConfigurator AddAbilityCasterNotPolymorphed()
    {
      return AddComponent(new AbilityCasterNotPolymorphed());
    }

    /// <summary>
    /// Adds <see cref="AbilityMaxSquadsRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityMaxSquadsRestriction))]
    public AbilityConfigurator AddAbilityMaxSquadsRestriction()
    {
      return AddComponent(new AbilityMaxSquadsRestriction());
    }

    /// <summary>
    /// Adds <see cref="AbilitySpawnFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilitySpawnFx))]
    public AbilityConfigurator AddAbilitySpawnFx(
        PrefabLink PrefabLink,
        AbilitySpawnFxTime Time,
        AbilitySpawnFxAnchor Anchor,
        AbilitySpawnFxWeaponTarget WeaponTarget,
        bool DestroyOnCast,
        float Delay,
        AbilitySpawnFxAnchor PositionAnchor,
        AbilitySpawnFxAnchor OrientationAnchor,
        AbilitySpawnFxOrientation OrientationMode)
    {
      ValidateParam(PrefabLink);
      ValidateParam(Time);
      ValidateParam(Anchor);
      ValidateParam(WeaponTarget);
      ValidateParam(PositionAnchor);
      ValidateParam(OrientationAnchor);
      ValidateParam(OrientationMode);
      
      var component =  new AbilitySpawnFx();
      component.PrefabLink = PrefabLink;
      component.Time = Time;
      component.Anchor = Anchor;
      component.WeaponTarget = WeaponTarget;
      component.DestroyOnCast = DestroyOnCast;
      component.Delay = Delay;
      component.PositionAnchor = PositionAnchor;
      component.OrientationAnchor = OrientationAnchor;
      component.OrientationMode = OrientationMode;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityHook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyAbilityHook))]
    public AbilityConfigurator AddArmyAbilityHook(
        float PullSpeed,
        AnimationCurve PullCurve,
        int PullDistanceInCells)
    {
      ValidateParam(PullCurve);
      
      var component =  new ArmyAbilityHook();
      component.PullSpeed = PullSpeed;
      component.PullCurve = PullCurve;
      component.PullDistanceInCells = PullDistanceInCells;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomAreaOnGrid))]
    public AbilityConfigurator AddCustomAreaOnGrid(
        List<Vector2Int> AffectedCells,
        bool IgnoreObstaclesAndUnits,
        bool SpawnFxInEveryCell)
    {
      foreach (var item in AffectedCells)
      {
        ValidateParam(item);
      }
      
      var component =  new CustomAreaOnGrid();
      component.AffectedCells = AffectedCells;
      component.IgnoreObstaclesAndUnits = IgnoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = SpawnFxInEveryCell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatDefenseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatDefenseAbility))]
    public AbilityConfigurator AddTacticalCombatDefenseAbility()
    {
      return AddComponent(new TacticalCombatDefenseAbility());
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatResurrection))]
    public AbilityConfigurator AddTacticalCombatResurrection()
    {
      return AddComponent(new TacticalCombatResurrection());
    }

    /// <summary>
    /// Adds <see cref="PureRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PureRecommendation))]
    public AbilityConfigurator AddPureRecommendation(
        RecommendationPriority Priority)
    {
      ValidateParam(Priority);
      
      var component =  new PureRecommendation();
      component.Priority = Priority;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationAccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationAccomplishedSneakAttacker))]
    public AbilityConfigurator AddRecommendationAccomplishedSneakAttacker()
    {
      return AddComponent(new RecommendationAccomplishedSneakAttacker());
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationBaseAttackPart))]
    public AbilityConfigurator AddRecommendationBaseAttackPart(
        float MinPart,
        bool NotRecommendIfHigher)
    {
      
      var component =  new RecommendationBaseAttackPart();
      component.MinPart = MinPart;
      component.NotRecommendIfHigher = NotRecommendIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationCompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CompanionRank"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(RecommendationCompanionBoon))]
    public AbilityConfigurator AddRecommendationCompanionBoon(
        string m_CompanionRank)
    {
      
      var component =  new RecommendationCompanionBoon();
      component.m_CompanionRank = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CompanionRank);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationHasFeature))]
    public AbilityConfigurator AddRecommendationHasFeature(
        string m_Feature,
        bool Mandatory)
    {
      
      var component =  new RecommendationHasFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      component.Mandatory = Mandatory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationNoFeatFromGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationNoFeatFromGroup))]
    public AbilityConfigurator AddRecommendationNoFeatFromGroup(
        string[] m_Features,
        bool GoodIfNoFeature)
    {
      
      var component =  new RecommendationNoFeatFromGroup();
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.GoodIfNoFeature = GoodIfNoFeature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbook))]
    public AbilityConfigurator AddRecommendationRequiresSpellbook()
    {
      return AddComponent(new RecommendationRequiresSpellbook());
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbookSource))]
    public AbilityConfigurator AddRecommendationRequiresSpellbookSource(
        bool Arcane,
        bool Divine,
        bool Alchemist)
    {
      
      var component =  new RecommendationRequiresSpellbookSource();
      component.Arcane = Arcane;
      component.Divine = Divine;
      component.Alchemist = Alchemist;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatComparison"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatComparison))]
    public AbilityConfigurator AddRecommendationStatComparison(
        StatType HigherStat,
        StatType LowerStat,
        int Diff)
    {
      ValidateParam(HigherStat);
      ValidateParam(LowerStat);
      
      var component =  new RecommendationStatComparison();
      component.HigherStat = HigherStat;
      component.LowerStat = LowerStat;
      component.Diff = Diff;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatMiminum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatMiminum))]
    public AbilityConfigurator AddRecommendationStatMiminum(
        StatType Stat,
        int MinimalValue,
        bool GoodIfHigher)
    {
      ValidateParam(Stat);
      
      var component =  new RecommendationStatMiminum();
      component.Stat = Stat;
      component.MinimalValue = MinimalValue;
      component.GoodIfHigher = GoodIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponSubcategoryFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponSubcategoryFocus))]
    public AbilityConfigurator AddRecommendationWeaponSubcategoryFocus(
        WeaponSubCategory Subcategory,
        bool HasFocus,
        bool BadIfNoFocus)
    {
      ValidateParam(Subcategory);
      
      var component =  new RecommendationWeaponSubcategoryFocus();
      component.Subcategory = Subcategory;
      component.HasFocus = HasFocus;
      component.BadIfNoFocus = BadIfNoFocus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponTypeFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponTypeFocus))]
    public AbilityConfigurator AddRecommendationWeaponTypeFocus(
        WeaponRangeType WeaponRangeType,
        bool HasFocus)
    {
      ValidateParam(WeaponRangeType);
      
      var component =  new RecommendationWeaponTypeFocus();
      component.WeaponRangeType = WeaponRangeType;
      component.HasFocus = HasFocus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatRecommendationChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatRecommendationChange))]
    public AbilityConfigurator AddStatRecommendationChange(
        StatType Stat,
        bool Recommended)
    {
      ValidateParam(Stat);
      
      var component =  new StatRecommendationChange();
      component.Stat = Stat;
      component.Recommended = Recommended;
      return AddComponent(component);
    }

    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableMetamagics > 0) { Blueprint.AvailableMetamagic |= EnableMetamagics; }
      if (DisableMetamagics > 0) { Blueprint.AvailableMetamagic &= ~DisableMetamagics; }
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.CustomRange > new Feet(0) && Blueprint.Range != AbilityRange.Custom)
      {
        AddValidationWarning("A custom range value is present without AbilityRange.Custom. It will be ignored.");
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
        AddValidationWarning("Multiple AbilityVariants components present. Only the first is used.");
      }

      List<AbilityDeliverEffect> deliverEffects = Blueprint.GetComponents<AbilityDeliverEffect>().ToList();
      if (deliverEffects.Count > 1)
      {
        AddValidationWarning("Multiple AbilityDeliverEffects present. Only the first is used.");
      }

      if (Blueprint.GetComponent<AbilityApplyEffect>() is AbilityEffectMiss)
      {
        AddValidationWarning("AbilityEffectMiss is the first AbilityApplyEffect. It will always trigger.");
      }

      List<AbilityApplyEffect> applyEffects =
          Blueprint.GetComponents<AbilityApplyEffect>().ToList();
      if (applyEffects.Count == 1 && applyEffects[0] is AbilityEffectMiss)
      {
        AddValidationWarning("AbilityEffectMiss is the only AbilityApplyEffect. It will trigger on hit or miss.");
      }
      else if (applyEffects.Count == 2 && applyEffects[1] is AbilityEffectMiss)
      {
        var deliverEffect = Blueprint.GetComponent<AbilityDeliverEffect>();
        if (deliverEffect == null)
        {
          AddValidationWarning($"AbilityEffectMiss requires an AbilityDeliverEffect.");
        }
        else if (!SupportsEffectMiss(deliverEffect))
        {
          AddValidationWarning($"AbilityEffectMiss is not compatible with {deliverEffect.GetType()}");
        }
      }
      else if (applyEffects.Count > 1)
      {
        AddValidationWarning("Too many AbilityApplyEffects present. Only the first is used.");
      }

      if (Blueprint.GetComponents<AbilitySelectTarget>().Count() > 1)
      {
        AddValidationWarning("Multiple AbilitySelectTarget components present. Only the first is used.");
      }
    }

    private static bool SupportsEffectMiss(AbilityDeliverEffect effect)
    {
      return
          effect is AbilityDeliveredByWeapon
          || effect is AbilityDeliverClashingRocks
          || effect is AbilityDeliverProjectile
          || effect is AbilityDeliverTouch;
    }

    private void SetParent(BlueprintAbility parent)
    {
      Blueprint.Parent = parent;

      var parentVariants = parent.GetComponent<AbilityVariants>();
      var abilityRef = Blueprint.ToReference<BlueprintAbilityReference>();
      if (parentVariants != null)
      {
        parentVariants.m_Variants = CommonTool.Append(parentVariants.m_Variants, abilityRef);
        return;
      }

      parentVariants = new();
      parentVariants.m_Variants = new BlueprintAbilityReference[] { abilityRef };
      parent.AddComponents(parentVariants);
    }

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

    // Attribute for methods which add AbilityApplyEffect components.
    [AttributeUsage(AttributeTargets.Method)]
    public class ApplyEffectAttr : Attribute { }

    // Attribute for methods which add AbilityDeliverEffect components.
    [AttributeUsage(AttributeTargets.Method)]
    public class DeliverEffectAttr : Attribute { }

    // Attribute for methods which add AbilitySelectTarget components.
    [AttributeUsage(AttributeTargets.Method)]
    public class SelectTargetAttr : Attribute { }
  }
}
