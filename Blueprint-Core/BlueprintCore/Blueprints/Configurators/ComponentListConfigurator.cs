using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintComponentList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintComponentList))]
  public class ComponentListConfigurator : BaseBlueprintConfigurator<BlueprintComponentList, ComponentListConfigurator>
  {
     private ComponentListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ComponentListConfigurator For(string name)
    {
      return new ComponentListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ComponentListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintComponentList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ComponentListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintComponentList>(name, assetId);
      return For(name);
    }

  }
}
