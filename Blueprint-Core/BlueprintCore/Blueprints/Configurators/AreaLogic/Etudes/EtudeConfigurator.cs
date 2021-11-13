using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Etudes
{
  /// <summary>Configurator for <see cref="BlueprintEtude"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEtude))]
  public class EtudeConfigurator : BaseFactConfigurator<BlueprintEtude, EtudeConfigurator>
  {
     private EtudeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EtudeConfigurator For(string name)
    {
      return new EtudeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static EtudeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintEtude>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EtudeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintEtude>(name, assetId);
      return For(name);
    }

  }
}
