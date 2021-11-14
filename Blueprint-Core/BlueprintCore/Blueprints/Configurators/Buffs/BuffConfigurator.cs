using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Controllers.Units;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Buffs
{
  /// <summary>Configurator for <see cref="BlueprintBuff"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBuff))]
  public class BuffConfigurator : BaseUnitFactConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BlueprintBuff.Flags EnableFlags;
    private BlueprintBuff.Flags DisableFlags;

    private BuffConfigurator(string name) : base(name) { }

    /// <summary>Returns a configurator for the given blueprint.</summary>
    /// 
    /// <remarks>
    /// Use this function if the blueprint exists in the game library. If you're using
    /// <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModifiationTemplate</see> your
    /// JSON blueprints should already exist.
    /// </remarks>
    public static BuffConfigurator For(string name)
    {
      return new BuffConfigurator(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    /// 
    /// <remarks>
    /// Use this function to create a new blueprint if you provided a mapping with
    /// <see cref="BlueprintTool.AddGuidsByName"/>. Otherwise use <see cref="New(string, string)"/>.
    /// </remarks>
    public static BuffConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBuff>(name);
      return For(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    public static BuffConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBuff>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.IsClassFeature"/>
    /// </summary>
    public BuffConfigurator SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IsClassFeature = isClassFeature);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator AddFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        EnableFlags |= flag;
      }
      return this;
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator RemoveFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        DisableFlags |= flag;
      }
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Stacking"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetRanks(int)"/> for <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetStackingType(StackingType type)
    {
      if (type == StackingType.Rank)
      {
        throw new InvalidOperationException("Use SetRanks() for StackingType.Rank.");
      }

      return OnConfigureInternal(blueprint => blueprint.Stacking = type);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Ranks"/>
    /// </summary>
    ///
    /// <remarks>Also sets <see cref="BlueprintBuff.Stacking"/> to <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetRanks(int ranks)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.Stacking = StackingType.Rank;
            blueprint.Ranks = ranks;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.TickEachSecond"/>
    /// </summary>
    public BuffConfigurator SetTickEachSecond(bool tickEachSecond = true)
    {
      return OnConfigureInternal(blueprint => blueprint.TickEachSecond = tickEachSecond);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Frequency"/>
    /// </summary>
    public BuffConfigurator SetFrequency(DurationRate rate)
    {
      return OnConfigureInternal(blueprint => blueprint.Frequency = rate);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnStart"/>
    /// </summary>
    public BuffConfigurator SetFxOnStart(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnStart = prefab);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnRemove"/>
    /// </summary>
    public BuffConfigurator SetFxOnRemove(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnRemove = prefab);
    }

    /// <summary>
    /// Adds <see cref="AddEffectFastHealing"/>
    /// </summary>
    public BuffConfigurator FastHealing(int baseValue, ContextValue bonusValue = null)
    {
      var fastHealing = new AddEffectFastHealing
      {
        Heal = baseValue,
        Bonus = bonusValue ?? 0
      };
      return AddComponent(fastHealing);
    }

    /// <summary>
    /// Adds <see cref="RemoveWhenCombatEnded"/>
    /// </summary>
    public BuffConfigurator RemoveWhenCombatEnds()
    {
      AddUniqueComponent(new RemoveWhenCombatEnded(), ComponentMerge.Skip);
      return this;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.Mechanics.Buffs.BuffSleeping">BuffSleeping</see>
    /// </summary>
    public BuffConfigurator BuffSleeping(
        int? wakeupPerceptionDC = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var sleeping = new BuffSleeping();
      if (wakeupPerceptionDC is not null) { sleeping.WakeupPerceptionDC = wakeupPerceptionDC.Value; }
      return AddUniqueComponent(sleeping, mergeBehavior, merge);
    }


    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public BuffConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
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
    public BuffConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
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
    public BuffConfigurator ContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }


    /// <summary>
    /// Adds <see cref="AddDispelMagicFailedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDispelMagicFailedTrigger))]
    public BuffConfigurator AddAddDispelMagicFailedTrigger(
        ActionsBuilder ActionOnOwner,
        ActionsBuilder ActionOnCaster)
    {
      
      var component =  new AddDispelMagicFailedTrigger();
      component.ActionOnOwner = ActionOnOwner.Build();
      component.ActionOnCaster = ActionOnCaster.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellSchool))]
    public BuffConfigurator AddAddSpellSchool(
        SpellSchool School)
    {
      ValidateParam(School);
      
      var component =  new AddSpellSchool();
      component.School = School;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IsPositiveEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPositiveEffect))]
    public BuffConfigurator AddIsPositiveEffect()
    {
      return AddComponent(new IsPositiveEffect());
    }

    /// <summary>
    /// Adds <see cref="RemoveWhenCombatEnded"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveWhenCombatEnded))]
    public BuffConfigurator AddRemoveWhenCombatEnded()
    {
      return AddComponent(new RemoveWhenCombatEnded());
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public BuffConfigurator AddContextCalculateAbilityParams(
        bool UseKineticistMainStat,
        StatType StatType,
        bool StatTypeFromCustomProperty,
        string m_CustomProperty,
        bool ReplaceCasterLevel,
        ContextValue CasterLevel,
        bool ReplaceSpellLevel,
        ContextValue SpellLevel)
    {
      ValidateParam(UseKineticistMainStat);
      ValidateParam(StatType);
      ValidateParam(StatTypeFromCustomProperty);
      ValidateParam(ReplaceCasterLevel);
      ValidateParam(CasterLevel);
      ValidateParam(ReplaceSpellLevel);
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
    public BuffConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool UseKineticistMainStat,
        StatType StatType,
        string m_CharacterClass)
    {
      ValidateParam(UseKineticistMainStat);
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
    public BuffConfigurator AddContextCalculateSharedValue(
        AbilitySharedValue ValueType,
        ContextDiceValue Value,
        double Modifier)
    {
      ValidateParam(ValueType);
      ValidateParam(Value);
      ValidateParam(Modifier);
      
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
    public BuffConfigurator AddContextSetAbilityParams(
        bool Add10ToDC,
        ContextValue DC,
        ContextValue CasterLevel,
        ContextValue Concentration,
        ContextValue SpellLevel)
    {
      ValidateParam(Add10ToDC);
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
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public BuffConfigurator AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="ControlledProjectileHolder"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ControlledProjectileHolder))]
    public BuffConfigurator AddControlledProjectileHolder()
    {
      return AddComponent(new ControlledProjectileHolder());
    }
    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableFlags > 0) { Blueprint.m_Flags |= EnableFlags; }
      if (DisableFlags > 0) { Blueprint.m_Flags &= ~DisableFlags; }
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponent<ITickEachRound>() == null)
      {
        AddValidationWarning($"ITickEachRound component is missing. Frequency and TickEachSecond will be ignored.");
      }
    }
  }
}
