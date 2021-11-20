using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSpellsTable"/>.
  /// </summary>
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
    public static SpellsTableConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpellsTable>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellsTable.Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellsTableConfigurator SetLevels(SpellsLevelEntry[] levels)
    {
      ValidateParam(levels);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Levels = levels;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintSpellsTable.Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellsTableConfigurator AddToLevels(params SpellsLevelEntry[] levels)
    {
      ValidateParam(levels);
      return OnConfigureInternal(
          bp =>
          {
            bp.Levels = CommonTool.Append(bp.Levels, levels ?? new SpellsLevelEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintSpellsTable.Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellsTableConfigurator RemoveFromLevels(params SpellsLevelEntry[] levels)
    {
      ValidateParam(levels);
      return OnConfigureInternal(
          bp =>
          {
            bp.Levels = bp.Levels.Where(item => !levels.Contains(item)).ToArray();
          });
    }
  }
}
