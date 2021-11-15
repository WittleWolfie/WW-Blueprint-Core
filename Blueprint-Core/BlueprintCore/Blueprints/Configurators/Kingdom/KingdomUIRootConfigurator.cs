using BlueprintCore.Utils;
using Kingmaker.Kingdom;
using Kingmaker.UI.Kingdom;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="KingdomUIRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(KingdomUIRoot))]
  public class KingdomUIRootConfigurator : BaseBlueprintConfigurator<KingdomUIRoot, KingdomUIRootConfigurator>
  {
     private KingdomUIRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomUIRootConfigurator For(string name)
    {
      return new KingdomUIRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomUIRootConfigurator New(string name)
    {
      BlueprintTool.Create<KingdomUIRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomUIRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<KingdomUIRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.DefaultOpportunityMapMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetDefaultOpportunityMapMarker(KingdomUIEventMapMarker value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultOpportunityMapMarker = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.DefaultProblemMapMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetDefaultProblemMapMarker(KingdomUIEventMapMarker value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultProblemMapMarker = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToStats(params KingdomUIRoot.KingdomStatElement[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Stats.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromStats(params KingdomUIRoot.KingdomStatElement[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Stats = bp.Stats.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Resources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToResources(params KingdomUIRoot.KingdomResourceElement[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Resources.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Resources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromResources(params KingdomUIRoot.KingdomResourceElement[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Resources = bp.Resources.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.RavenTexts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetRavenTexts(KingdomUIRoot.KingdomRavenText value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RavenTexts = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.LeaderDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderDescriptions.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.LeaderDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderDescriptions = bp.LeaderDescriptions.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Texts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetTexts(KingdomUIRoot.KingdomUITexts value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Texts = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.EventResultMarginDescriptions.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.EventResultMarginDescriptions = bp.EventResultMarginDescriptions.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Settlement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetSettlement(KingdomUIRoot.SettlementRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Settlement = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetTooltip(KingdomUIRoot.KingdomUITooltip value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Tooltip = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Motto"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetMotto(KingdomUIRoot.KingdomMotto value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Motto = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.KingdomStatusChangeReasons.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.KingdomStatusChangeReasons = bp.KingdomStatusChangeReasons.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.KingdomHistoryEntitisCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetKingdomHistoryEntitisCount(int value)
    {
      return OnConfigureInternal(bp => bp.KingdomHistoryEntitisCount = value);
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.ExResourceStateTypeStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetExResourceStateTypeStrings(KingdomUIRoot.ResourceStateTypeStrings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ExResourceStateTypeStrings = value);
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.KingdomStautsDesriptions.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.KingdomStautsDesriptions = bp.KingdomStautsDesriptions.Where(item => !values.Contains(item)).ToList());
    }
  }
}
