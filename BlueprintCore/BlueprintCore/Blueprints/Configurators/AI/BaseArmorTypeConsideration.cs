//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ArmorTypeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmorTypeConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ArmorTypeConsideration
    where TBuilder : BaseArmorTypeConsiderationConfigurator<T, TBuilder>
  {
    protected BaseArmorTypeConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ArmorTypeConsideration.LightArmorScore"/>
    /// </summary>
    ///
    /// <param name="lightArmorScore">
    /// <para>
    /// Tooltip: Light or no armor
    /// </para>
    /// </param>
    public TBuilder SetLightArmorScore(float lightArmorScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LightArmorScore = lightArmorScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmorTypeConsideration.LightArmorScore"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="lightArmorScore">
    /// <para>
    /// Tooltip: Light or no armor
    /// </para>
    /// </param>
    public TBuilder ModifyLightArmorScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LightArmorScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmorTypeConsideration.HeavyArmorScore"/>
    /// </summary>
    ///
    /// <param name="heavyArmorScore">
    /// <para>
    /// Tooltip: Heavy or medium armor
    /// </para>
    /// </param>
    public TBuilder SetHeavyArmorScore(float heavyArmorScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HeavyArmorScore = heavyArmorScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmorTypeConsideration.HeavyArmorScore"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="heavyArmorScore">
    /// <para>
    /// Tooltip: Heavy or medium armor
    /// </para>
    /// </param>
    public TBuilder ModifyHeavyArmorScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HeavyArmorScore);
        });
    }
  }
}
