using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintSpellsTable.Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellsTableConfigurator AddToLevels(params SpellsLevelEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Levels = CommonTool.Append(bp.Levels, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellsTable.Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellsTableConfigurator RemoveFromLevels(params SpellsLevelEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Levels = bp.Levels.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
