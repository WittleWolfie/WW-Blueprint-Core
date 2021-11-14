using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>Configurator for <see cref="BlueprintSpellList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellList))]
  public class SpellListConfigurator : BaseBlueprintConfigurator<BlueprintSpellList, SpellListConfigurator>
  {
     private SpellListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellListConfigurator For(string name)
    {
      return new SpellListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpellListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSpellList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpellList>(name, assetId);
      return For(name);
    }
  }
}
