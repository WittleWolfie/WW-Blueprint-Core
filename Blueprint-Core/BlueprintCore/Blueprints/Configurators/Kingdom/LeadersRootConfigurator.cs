using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="LeadersRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(LeadersRoot))]
  public class LeadersRootConfigurator : BaseBlueprintConfigurator<LeadersRoot, LeadersRootConfigurator>
  {
     private LeadersRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeadersRootConfigurator For(string name)
    {
      return new LeadersRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeadersRootConfigurator New(string name)
    {
      BlueprintTool.Create<LeadersRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeadersRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<LeadersRoot>(name, assetId);
      return For(name);
    }
  }
}
