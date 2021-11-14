using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>Configurator for <see cref="TrashLootSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TrashLootSettings))]
  public class TrashLootSettingsConfigurator : BaseBlueprintConfigurator<TrashLootSettings, TrashLootSettingsConfigurator>
  {
     private TrashLootSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrashLootSettingsConfigurator For(string name)
    {
      return new TrashLootSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrashLootSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<TrashLootSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrashLootSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TrashLootSettings>(name, assetId);
      return For(name);
    }
  }
}
