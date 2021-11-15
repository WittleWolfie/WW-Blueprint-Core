using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>Configurator for <see cref="BlueprintAiCastSpell"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiCastSpell))]
  public class AiCastSpellConfigurator : BaseAiActionConfigurator<BlueprintAiCastSpell, AiCastSpellConfigurator>
  {
     private AiCastSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiCastSpellConfigurator For(string name)
    {
      return new AiCastSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AiCastSpellConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAiCastSpell>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiCastSpellConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAiCastSpell>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_MinCasterSqrDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinCasterSqrDistanceToLocator(float value)
    {
      return OnConfigureInternal(bp => bp.m_MinCasterSqrDistanceToLocator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_MinPartySqrDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinPartySqrDistanceToLocator(float value)
    {
      return OnConfigureInternal(bp => bp.m_MinPartySqrDistanceToLocator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_MaxPartySqrDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMaxPartySqrDistanceToLocator(float value)
    {
      return OnConfigureInternal(bp => bp.m_MaxPartySqrDistanceToLocator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_AffectedByImpatience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetAffectedByImpatience(bool value)
    {
      return OnConfigureInternal(bp => bp.m_AffectedByImpatience = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_Ability"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator SetAbility(string value)
    {
      return OnConfigureInternal(bp => bp.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_ForceTargetSelf"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetForceTargetSelf(bool value)
    {
      return OnConfigureInternal(bp => bp.m_ForceTargetSelf = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_ForceTargetEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetForceTargetEnemy(bool value)
    {
      return OnConfigureInternal(bp => bp.m_ForceTargetEnemy = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_RandomVariant"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetRandomVariant(bool value)
    {
      return OnConfigureInternal(bp => bp.m_RandomVariant = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_Variant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator SetVariant(string value)
    {
      return OnConfigureInternal(bp => bp.m_Variant = BlueprintTool.GetRef<BlueprintAbilityReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_VariantsSet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator AddToVariantsSet(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_VariantsSet = CommonTool.Append(bp.m_VariantsSet, values.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.m_VariantsSet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator RemoveFromVariantsSet(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name));
            bp.m_VariantsSet =
                bp.m_VariantsSet
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.Locators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator AddToLocators(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Locators = CommonTool.Append(bp.Locators, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiCastSpell.Locators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator RemoveFromLocators(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Locators = bp.Locators.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.CheckCasterDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetCheckCasterDistance(bool value)
    {
      return OnConfigureInternal(bp => bp.CheckCasterDistance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.MinCasterDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinCasterDistanceToLocator(float value)
    {
      return OnConfigureInternal(bp => bp.MinCasterDistanceToLocator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.CheckPartyDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetCheckPartyDistance(bool value)
    {
      return OnConfigureInternal(bp => bp.CheckPartyDistance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.MinPartyDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinPartyDistanceToLocator(float value)
    {
      return OnConfigureInternal(bp => bp.MinPartyDistanceToLocator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.MaxPartyDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMaxPartyDistanceToLocator(float value)
    {
      return OnConfigureInternal(bp => bp.MaxPartyDistanceToLocator = value);
    }
  }
}
