//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

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
    protected BaseArmorTypeConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

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
  }
}
