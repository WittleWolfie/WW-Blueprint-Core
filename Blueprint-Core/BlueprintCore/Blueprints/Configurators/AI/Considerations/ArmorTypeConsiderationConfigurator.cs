using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="ArmorTypeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmorTypeConsideration))]
  public class ArmorTypeConsiderationConfigurator : BaseConsiderationConfigurator<ArmorTypeConsideration, ArmorTypeConsiderationConfigurator>
  {
    private ArmorTypeConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorTypeConsiderationConfigurator For(string name)
    {
      return new ArmorTypeConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmorTypeConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ArmorTypeConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorTypeConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<ArmorTypeConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ArmorTypeConsideration.LightArmorScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConsiderationConfigurator SetLightArmorScore(float lightArmorScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LightArmorScore = lightArmorScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmorTypeConsideration.HeavyArmorScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConsiderationConfigurator SetHeavyArmorScore(float heavyArmorScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HeavyArmorScore = heavyArmorScore;
          });
    }
  }
}
