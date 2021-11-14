using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintCheck"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCheck))]
  public class CheckConfigurator : BaseCueBaseConfigurator<BlueprintCheck, CheckConfigurator>
  {
     private CheckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CheckConfigurator For(string name)
    {
      return new CheckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CheckConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCheck>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CheckConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCheck>(name, assetId);
      return For(name);
    }
  }
}
