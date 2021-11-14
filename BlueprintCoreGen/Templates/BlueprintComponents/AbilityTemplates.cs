using BlueprintCore.Abilities.Restrictions.New;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;
using static BlueprintCoreGen.Blueprints.Configurators.Abilities.AbilityConfigurator;

namespace BlueprintCoreGen.Templates.BlueprintComponents
{
  abstract class AbilityTemplates<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAbility
      where TBuilder : AbilityTemplates<T, TBuilder>
  {
    private AbilityTemplates(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="AbilityCasterAlignment"/>
    /// </summary>
    /// 
    /// <param name="ignoreFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterAlignment))]
    public TBuilder RequireCasterAlignment(AlignmentMaskType alignment, string ignoreFact = null)
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
    public TBuilder RequireCasterFacts(params string[] facts)
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
    public TBuilder RequireCasterHasNoFacts(params string[] facts)
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
    public TBuilder RequireCasterHasChosenWeapon(
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
    public TBuilder RequireCasterWeaponRange(WeaponRangeType range)
    {
      var hasWeaponRange = new AbilityCasterHasWeaponWithRangeType { RangeType = range };
      return AddComponent(hasWeaponRange);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterInCombat"/>
    /// </summary>
    [Implements(typeof(AbilityCasterInCombat))]
    public TBuilder RequireCasterInCombat(bool requireInCombat = true)
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
    public TBuilder RequireCasterOnFavoredTerrain(string ignoreFeature = null)
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
    public TBuilder RequireTargetHasBuffsFromCaster(string[] buffs, bool requireAllBuffs = false)
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
    public TBuilder CanTargetDead()
    {
      return AddUniqueComponent(new AbilityCanTargetDead(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliveredByWeapon"/>
    /// </summary>
    [DeliverEffectAttr]
    [Implements(typeof(AbilityDeliveredByWeapon))]
    public TBuilder DeliveredByWeapon()
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
    public TBuilder RunActions(
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
    public TBuilder OnMiss(
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
    public TBuilder OnCast(ActionsBuilder actions, ConditionsBuilder checker = null)
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
    public TBuilder SetSpellSchool(
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
    public TBuilder MakeCantrip()
    {
      return AddUniqueComponent(new CantripComponent(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Removes <see cref="CantripComponent"/>
    /// </summary>
    [Implements(typeof(CantripComponent))]
    public TBuilder MakeNotCantrip()
    {
      return RemoveComponents(c => c is CantripComponent);
    }

    /// <summary>
    /// Adds or modifies <see cref="AbilityVariants"/>
    /// </summary>
    /// 
    /// <param name="abilities"><see cref="BlueprintAbility"/> Updates the parent of each ability to this blueprint</param>
    [Implements(typeof(AbilityVariants))]
    public TBuilder AddVariants(params string[] abilities)
    {
      OnConfigureInternal(
          blueprint =>
              AddVariants(
                  blueprint, abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList()));
      return Self;
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
    public TBuilder RemoveVariants(params string[] abilities)
    {
      OnConfigureInternal(
          blueprint =>
              RemoveVariants(
                  blueprint, abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList()));
      return Self;
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
  }
}
