using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintUnitTemplate"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitTemplate))]
  public class UnitTemplateConfigurator : BaseBlueprintConfigurator<BlueprintUnitTemplate, UnitTemplateConfigurator>
  {
     private UnitTemplateConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitTemplateConfigurator For(string name)
    {
      return new UnitTemplateConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitTemplateConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitTemplate>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitTemplateConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitTemplate>(name, assetId);
      return For(name);
    }
  }
}
