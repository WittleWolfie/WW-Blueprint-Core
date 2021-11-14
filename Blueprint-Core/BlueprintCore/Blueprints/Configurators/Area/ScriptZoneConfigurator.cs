using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintScriptZone"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintScriptZone))]
  public class ScriptZoneConfigurator : BaseMapObjectConfigurator<BlueprintScriptZone, ScriptZoneConfigurator>
  {
     private ScriptZoneConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ScriptZoneConfigurator For(string name)
    {
      return new ScriptZoneConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ScriptZoneConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintScriptZone>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ScriptZoneConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintScriptZone>(name, assetId);
      return For(name);
    }
  }
}
