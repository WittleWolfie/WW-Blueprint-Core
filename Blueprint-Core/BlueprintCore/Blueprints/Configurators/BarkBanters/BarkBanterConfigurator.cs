using BlueprintCore.Utils;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.BarkBanters
{
  /// <summary>Configurator for <see cref="BlueprintBarkBanter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBarkBanter))]
  public class BarkBanterConfigurator : BaseBlueprintConfigurator<BlueprintBarkBanter, BarkBanterConfigurator>
  {
     private BarkBanterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BarkBanterConfigurator For(string name)
    {
      return new BarkBanterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BarkBanterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBarkBanter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BarkBanterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBarkBanter>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.m_SpeakerType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetSpeakerType(SpeakerType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_SpeakerType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.m_Unit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public BarkBanterConfigurator SetUnit(string value)
    {
      return OnConfigureInternal(bp => bp.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetConditions(BanterConditions value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Conditions = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetWeight(float value)
    {
      return OnConfigureInternal(bp => bp.m_Weight = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.FirstPhrase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator AddToFirstPhrase(params LocalizedString[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FirstPhrase = CommonTool.Append(bp.FirstPhrase, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.FirstPhrase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator RemoveFromFirstPhrase(params LocalizedString[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FirstPhrase = bp.FirstPhrase.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.Responses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator AddToResponses(params BlueprintBarkBanter.BanterResponseEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Responses = CommonTool.Append(bp.Responses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.Responses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator RemoveFromResponses(params BlueprintBarkBanter.BanterResponseEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Responses = bp.Responses.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
