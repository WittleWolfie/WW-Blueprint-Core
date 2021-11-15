using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>Configurator for <see cref="CustomAiConsiderationsRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CustomAiConsiderationsRoot))]
  public class CustomAiConsiderationsRootConfigurator : BaseBlueprintConfigurator<CustomAiConsiderationsRoot, CustomAiConsiderationsRootConfigurator>
  {
     private CustomAiConsiderationsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CustomAiConsiderationsRootConfigurator For(string name)
    {
      return new CustomAiConsiderationsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CustomAiConsiderationsRootConfigurator New(string name)
    {
      BlueprintTool.Create<CustomAiConsiderationsRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CustomAiConsiderationsRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CustomAiConsiderationsRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator AddToTargetConsiderations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_TargetConsiderations = CommonTool.Append(bp.m_TargetConsiderations, values.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator RemoveFromTargetConsiderations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name));
            bp.m_TargetConsiderations =
                bp.m_TargetConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator AddToActorConsiderations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_ActorConsiderations = CommonTool.Append(bp.m_ActorConsiderations, values.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator RemoveFromActorConsiderations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name));
            bp.m_ActorConsiderations =
                bp.m_ActorConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
