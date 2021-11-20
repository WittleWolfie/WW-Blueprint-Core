using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDynamicMapObject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDynamicMapObject))]
  public class DynamicMapObjectConfigurator : BaseMapObjectConfigurator<BlueprintDynamicMapObject, DynamicMapObjectConfigurator>
  {
    private DynamicMapObjectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DynamicMapObjectConfigurator For(string name)
    {
      return new DynamicMapObjectConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DynamicMapObjectConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDynamicMapObject>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DynamicMapObjectConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDynamicMapObject>(name, assetId);
      return For(name);
    }
  }
}
