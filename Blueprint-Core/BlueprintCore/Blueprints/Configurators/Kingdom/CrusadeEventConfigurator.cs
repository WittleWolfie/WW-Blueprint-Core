using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintCrusadeEvent"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCrusadeEvent))]
  public class CrusadeEventConfigurator : BaseKingdomEventBaseConfigurator<BlueprintCrusadeEvent, CrusadeEventConfigurator>
  {
     private CrusadeEventConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CrusadeEventConfigurator For(string name)
    {
      return new CrusadeEventConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CrusadeEventConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCrusadeEvent>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CrusadeEventConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCrusadeEvent>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventConfigurator AddToEventSolutions(params EventSolution[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_EventSolutions = CommonTool.Append(bp.m_EventSolutions, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventConfigurator RemoveFromEventSolutions(params EventSolution[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_EventSolutions = bp.m_EventSolutions.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
