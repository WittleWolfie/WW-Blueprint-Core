using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>Configurator for <see cref="BlueprintSpellsTable"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellsTable))]
  public class SpellsTableConfigurator : BaseBlueprintConfigurator<BlueprintSpellsTable, SpellsTableConfigurator>
  {
     private SpellsTableConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellsTableConfigurator For(string name)
    {
      return new SpellsTableConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpellsTableConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSpellsTable>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellsTableConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpellsTable>(name, assetId);
      return For(name);
    }

  }
}
