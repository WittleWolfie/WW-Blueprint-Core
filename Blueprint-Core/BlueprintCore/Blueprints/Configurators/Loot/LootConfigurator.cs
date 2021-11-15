using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Enums;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>Configurator for <see cref="BlueprintLoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLoot))]
  public class LootConfigurator : BaseBlueprintConfigurator<BlueprintLoot, LootConfigurator>
  {
     private LootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LootConfigurator For(string name)
    {
      return new LootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetType(LootType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.IsSuperTrash"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetIsSuperTrash(bool value)
    {
      return OnConfigureInternal(bp => bp.IsSuperTrash = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Identify"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetIdentify(bool value)
    {
      return OnConfigureInternal(bp => bp.Identify = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Setting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetSetting(LootSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Setting = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArea"/></param>
    [Generated]
    public LootConfigurator SetArea(string value)
    {
      return OnConfigureInternal(bp => bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.ContainerName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetContainerName(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ContainerName = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator AddToItems(params LootEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Items = CommonTool.Append(bp.Items, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator RemoveFromItems(params LootEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Items = bp.Items.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
