using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.AI;
using Kingmaker.UI.Settlement;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.AI
{
  /// <summary>Configurator for <see cref="SettlementBuildList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(SettlementBuildList))]
  public class SettlementBuildListConfigurator : BaseBlueprintConfigurator<SettlementBuildList, SettlementBuildListConfigurator>
  {
     private SettlementBuildListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementBuildListConfigurator For(string name)
    {
      return new SettlementBuildListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SettlementBuildListConfigurator New(string name)
    {
      BlueprintTool.Create<SettlementBuildList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementBuildListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<SettlementBuildList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SettlementBuildList.m_BuildArea"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementBuildListConfigurator SetBuildArea(string value)
    {
      return OnConfigureInternal(bp => bp.m_BuildArea = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="SettlementBuildList.SlotSetupPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator SetSlotSetupPrefab(SettlementsBuildSlots value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SlotSetupPrefab = value);
    }

    /// <summary>
    /// Modifies <see cref="SettlementBuildList.List"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator AddToList(params SettlementBuildList.Entry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.List.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="SettlementBuildList.List"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator RemoveFromList(params SettlementBuildList.Entry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.List = bp.List.Where(item => !values.Contains(item)).ToList());
    }
  }
}
