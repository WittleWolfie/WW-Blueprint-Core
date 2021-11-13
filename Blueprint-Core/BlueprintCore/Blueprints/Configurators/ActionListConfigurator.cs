using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintActionList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintActionList))]
  public class ActionListConfigurator : BaseBlueprintConfigurator<BlueprintActionList, ActionListConfigurator>
  {
     private ActionListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActionListConfigurator For(string name)
    {
      return new ActionListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ActionListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintActionList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActionListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintActionList>(name, assetId);
      return For(name);
    }

  }
}
