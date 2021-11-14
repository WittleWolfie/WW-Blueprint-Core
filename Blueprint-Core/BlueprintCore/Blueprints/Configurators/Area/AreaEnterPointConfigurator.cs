using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintAreaEnterPoint"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaEnterPoint))]
  public class AreaEnterPointConfigurator : BaseBlueprintConfigurator<BlueprintAreaEnterPoint, AreaEnterPointConfigurator>
  {
     private AreaEnterPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaEnterPointConfigurator For(string name)
    {
      return new AreaEnterPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaEnterPointConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaEnterPoint>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaEnterPointConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaEnterPoint>(name, assetId);
      return For(name);
    }
  }
}
