using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsAroundConsideration))]
  public abstract class BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
      : BaseConsiderationConfigurator<T, TBuilder>
      where T : UnitsAroundConsideration
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseUnitsAroundConsiderationConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="UnitsAroundConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsAroundConsideration))]
  public class UnitsAroundConsiderationConfigurator : BaseConsiderationConfigurator<UnitsAroundConsideration, UnitsAroundConsiderationConfigurator>
  {
     private UnitsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitsAroundConsiderationConfigurator For(string name)
    {
      return new UnitsAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitsAroundConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<UnitsAroundConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitsAroundConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<UnitsAroundConsideration>(name, assetId);
      return For(name);
    }

  }
}
