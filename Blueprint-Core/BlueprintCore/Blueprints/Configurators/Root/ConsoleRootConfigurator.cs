using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;
namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="ConsoleRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ConsoleRoot))]
  public class ConsoleRootConfigurator : BaseBlueprintConfigurator<ConsoleRoot, ConsoleRootConfigurator>
  {
     private ConsoleRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConsoleRootConfigurator For(string name)
    {
      return new ConsoleRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ConsoleRootConfigurator New(string name)
    {
      BlueprintTool.Create<ConsoleRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConsoleRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ConsoleRoot>(name, assetId);
      return For(name);
    }

  }
}
