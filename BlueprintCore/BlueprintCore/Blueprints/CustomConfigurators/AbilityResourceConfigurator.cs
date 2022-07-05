using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;
using System;
using Kingmaker.EntitySystem.Stats;

namespace BlueprintCore.Blueprints.CustomConfigurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAbilityResource"/>.
  /// </summary>
  /// <inheritdoc/>
  public class AbilityResourceConfigurator
    : BaseAbilityResourceConfigurator<BlueprintAbilityResource, AbilityResourceConfigurator>
  {
    private AbilityResourceConfigurator(Blueprint<BlueprintReference<BlueprintAbilityResource>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static AbilityResourceConfigurator For(Blueprint<BlueprintReference<BlueprintAbilityResource>> blueprint)
    {
      return new AbilityResourceConfigurator(blueprint);
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static AbilityResourceConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbilityResource>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.m_MaxAmount"/> using <see cref="ResourceAmountBuilder"/>.
    /// </summary>
    public AbilityResourceConfigurator SetMaxAmount(ResourceAmountBuilder builder)
    {
      return OnConfigureInternal(bp => bp.m_MaxAmount = builder.Build());
    }

    /// <inheritdoc cref="BaseAbilityResourceConfigurator{T, TBuilder}.SetMax(int)"/>
    /// 
    /// <remarks>
    /// Sets <see cref="BlueprintAbilityResource.m_UseMax"/> to true.
    /// </remarks>
    public new AbilityResourceConfigurator SetMax(int max)
    {
      base.SetMax(max);
      return OnConfigureInternal(bp => bp.m_UseMax = true);
    }
  }

  /// <summary>
  /// Builder utility for <see cref="BlueprintAbilityResource.Amount"/>
  /// </summary>
  /// 
  /// <remarks>
  /// Note that you can use <see cref="IncreaseByLevel(string[], int)"/>, <see cref="IncreaseByStat(StatType)"/>, and
  /// <see cref="IncreaseByLevelStartPlusDivStep(string[], float, int, int, int, int, int)"/> simultaneously. Each will
  /// be applied, in that order.
  /// </remarks>
  public class ResourceAmountBuilder
  {
    private BlueprintAbilityResource.Amount Amount = new();
    public static ResourceAmountBuilder New(int baseValue)
    {
      var builder = new ResourceAmountBuilder();
      builder.Amount.BaseValue = baseValue;
      return builder;
    }

    /// <returns>A configured <see cref="BlueprintAbilityResource.Amount"/></returns>
    public BlueprintAbilityResource.Amount Build()
    {
      return Amount;
    }

    /// <summary>
    /// Increases the amount by <c>BonusPerLevel * ClassLevels</c>.
    /// </summary>
    /// 
    /// <remarks>Technically there is logic to support archetypes as well but it is unused and broken.</remarks>
    /// 
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    public ResourceAmountBuilder IncreaseByLevel(string[] classes, int bonusPerLevel = 1)
    {
      Amount.IncreasedByLevel = true;
      Amount.m_Class = classes.Select(clazz => BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz)).ToArray();
      Amount.LevelIncrease = bonusPerLevel;
      return this;
    }

    /// <summary>
    /// Increases the amount by <c>StatBonus</c>.
    /// </summary>
    public ResourceAmountBuilder IncreaseByStat(StatType stat)
    {
      Amount.IncreasedByStat = true;
      Amount.ResourceBonusStat = stat;
      return this;
    }

    /// <summary>
    /// Beginning at <c>StartingLevel</c>, increases the amount by
    /// <c>StartingBonus + BonusPerStep * (Levels - StartingLevel)/LevelsPerStep</c> or <c>MinBonus</c>, whichever is
    /// larger.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// Note that <c>Levels</c> is calculated as
    /// <c>ClassLevels + (CharacterLevel - ClassLevels) * OtherClassLevelsMultiplier</c>
    /// </para>
    /// 
    /// <para>
    /// As with <see cref="IncreaseByLevel(string[], int)"/>, archetype support is technically implemented but it is
    /// unused and broken.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    public ResourceAmountBuilder IncreaseByLevelStartPlusDivStep(
        string[]? classes = null,
        float otherClassLevelsMultiplier = 0f,
        int startingLevel = 0,
        int startingBonus = 0,
        int levelsPerStep = 1,
        int bonusPerStep = 0,
        int minBonus = 0)
    {
      Amount.IncreasedByLevelStartPlusDivStep = true;
      Amount.m_ClassDiv =
          classes is not null
              ? classes.Select(clazz => BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz))?.ToArray()
              : Array.Empty<BlueprintCharacterClassReference>();
      Amount.OtherClassesModifier = otherClassLevelsMultiplier;
      Amount.StartingLevel = startingLevel;
      Amount.StartingIncrease = startingBonus;
      Amount.LevelStep = levelsPerStep;
      Amount.PerStepIncrease = bonusPerStep;
      Amount.MinClassLevelIncrease = minBonus;
      return this;
    }
  }
}
