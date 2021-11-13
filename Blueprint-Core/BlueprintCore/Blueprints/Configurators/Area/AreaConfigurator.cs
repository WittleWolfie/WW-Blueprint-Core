using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public abstract class BaseAreaConfigurator<T, TBuilder>
      : BaseAreaPartConfigurator<T, TBuilder>
      where T : BlueprintArea
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="BlueprintArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public class AreaConfigurator : BaseAreaPartConfigurator<BlueprintArea, AreaConfigurator>
  {
     private AreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaConfigurator For(string name)
    {
      return new AreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArea>(name, assetId);
      return For(name);
    }

  }
}
