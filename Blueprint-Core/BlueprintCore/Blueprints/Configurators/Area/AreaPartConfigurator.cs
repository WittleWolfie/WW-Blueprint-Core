using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPart"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPart))]
  public abstract class BaseAreaPartConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintAreaPart
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaPartConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="BlueprintAreaPart"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPart))]
  public class AreaPartConfigurator : BaseFactConfigurator<BlueprintAreaPart, AreaPartConfigurator>
  {
     private AreaPartConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaPartConfigurator For(string name)
    {
      return new AreaPartConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaPartConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaPart>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaPartConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaPart>(name, assetId);
      return For(name);
    }

  }
}
