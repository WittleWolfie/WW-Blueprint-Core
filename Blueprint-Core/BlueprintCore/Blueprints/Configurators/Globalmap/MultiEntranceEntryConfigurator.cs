using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintMultiEntranceEntry"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMultiEntranceEntry))]
  public class MultiEntranceEntryConfigurator : BaseBlueprintConfigurator<BlueprintMultiEntranceEntry, MultiEntranceEntryConfigurator>
  {
     private MultiEntranceEntryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MultiEntranceEntryConfigurator For(string name)
    {
      return new MultiEntranceEntryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MultiEntranceEntryConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintMultiEntranceEntry>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MultiEntranceEntryConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintMultiEntranceEntry>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntranceEntry.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceEntryConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntranceEntry.m_Condition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceEntryConfigurator SetCondition(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.m_Condition = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntranceEntry.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceEntryConfigurator SetActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.m_Actions = value.Build());
    }
  }
}
