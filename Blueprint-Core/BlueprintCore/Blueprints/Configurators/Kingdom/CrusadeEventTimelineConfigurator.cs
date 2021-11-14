using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintCrusadeEventTimeline"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCrusadeEventTimeline))]
  public class CrusadeEventTimelineConfigurator : BaseBlueprintConfigurator<BlueprintCrusadeEventTimeline, CrusadeEventTimelineConfigurator>
  {
     private CrusadeEventTimelineConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CrusadeEventTimelineConfigurator For(string name)
    {
      return new CrusadeEventTimelineConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CrusadeEventTimelineConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCrusadeEventTimeline>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CrusadeEventTimelineConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCrusadeEventTimeline>(name, assetId);
      return For(name);
    }
  }
}
