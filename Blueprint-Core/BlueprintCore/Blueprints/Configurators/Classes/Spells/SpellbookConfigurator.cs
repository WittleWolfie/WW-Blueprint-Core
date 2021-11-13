using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>Configurator for <see cref="BlueprintSpellbook"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellbook))]
  public class SpellbookConfigurator : BaseBlueprintConfigurator<BlueprintSpellbook, SpellbookConfigurator>
  {
     private SpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellbookConfigurator For(string name)
    {
      return new SpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpellbookConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSpellbook>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellbookConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpellbook>(name, assetId);
      return For(name);
    }

  }
}
