using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonArea))]
  public class DungeonAreaConfigurator : BaseAreaConfigurator<BlueprintDungeonArea, DungeonAreaConfigurator>
  {
     private DungeonAreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonAreaConfigurator For(string name)
    {
      return new DungeonAreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonAreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonAreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonArea>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonArea.DungeonSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator SetDungeonSetting(DungeonStageSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DungeonSetting = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.Rooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToRooms(params DungeonRoomSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Rooms = CommonTool.Append(bp.Rooms, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.Rooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromRooms(params DungeonRoomSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Rooms = bp.Rooms.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.SecretRooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToSecretRooms(params DungeonRoomSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SecretRooms = CommonTool.Append(bp.SecretRooms, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.SecretRooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromSecretRooms(params DungeonRoomSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SecretRooms = bp.SecretRooms.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToTraps(params DungeonTrapLocator[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Traps = CommonTool.Append(bp.Traps, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromTraps(params DungeonTrapLocator[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Traps = bp.Traps.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.ThemeLightScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToThemeLightScenes(params BlueprintDungeonArea.ThemeScene[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ThemeLightScenes = CommonTool.Append(bp.ThemeLightScenes, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArea.ThemeLightScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromThemeLightScenes(params BlueprintDungeonArea.ThemeScene[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ThemeLightScenes = bp.ThemeLightScenes.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
