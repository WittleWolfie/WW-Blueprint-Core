using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="FormationsRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FormationsRoot))]
  public class FormationsRootConfigurator : BaseBlueprintConfigurator<FormationsRoot, FormationsRootConfigurator>
  {
     private FormationsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FormationsRootConfigurator For(string name)
    {
      return new FormationsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FormationsRootConfigurator New(string name)
    {
      BlueprintTool.Create<FormationsRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FormationsRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FormationsRoot>(name, assetId);
      return For(name);
    }
  }
}
