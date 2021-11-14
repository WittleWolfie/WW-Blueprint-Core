using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintAreaMechanics"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaMechanics))]
  public class AreaMechanicsConfigurator : BaseBlueprintConfigurator<BlueprintAreaMechanics, AreaMechanicsConfigurator>
  {
     private AreaMechanicsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaMechanicsConfigurator For(string name)
    {
      return new AreaMechanicsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaMechanicsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaMechanics>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaMechanicsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaMechanics>(name, assetId);
      return For(name);
    }
  }
}
