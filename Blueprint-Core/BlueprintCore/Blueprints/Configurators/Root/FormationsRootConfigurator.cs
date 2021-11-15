using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="FormationsRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FormationsRoot))]
  public class FormationsRootConfigurator : BaseBlueprintConfigurator<FormationsRoot, FormationsRootConfigurator>
  {
     private FormationsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FormationsRootConfigurator For(string name)
    {
      return new FormationsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FormationsRootConfigurator New(string name)
    {
      BlueprintTool.Create<FormationsRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FormationsRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FormationsRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.m_PredefinedFormations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintPartyFormation"/></param>
    [Generated]
    public FormationsRootConfigurator AddToPredefinedFormations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_PredefinedFormations = CommonTool.Append(bp.m_PredefinedFormations, values.Select(name => BlueprintTool.GetRef<BlueprintPartyFormationReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.m_PredefinedFormations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintPartyFormation"/></param>
    [Generated]
    public FormationsRootConfigurator RemoveFromPredefinedFormations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintPartyFormationReference>(name));
            bp.m_PredefinedFormations =
                bp.m_PredefinedFormations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.m_FollowersFormation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="FollowersFormation"/></param>
    [Generated]
    public FormationsRootConfigurator SetFollowersFormation(string value)
    {
      return OnConfigureInternal(bp => bp.m_FollowersFormation = BlueprintTool.GetRef<BlueprintFollowersFormationReference>(value));
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.FormationsScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FormationsRootConfigurator SetFormationsScale(float value)
    {
      return OnConfigureInternal(bp => bp.FormationsScale = value);
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.MinSpaceFactor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FormationsRootConfigurator SetMinSpaceFactor(float value)
    {
      return OnConfigureInternal(bp => bp.MinSpaceFactor = value);
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.AutoFormation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FormationsRootConfigurator SetAutoFormation(FormationsRoot.AutoFormationSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AutoFormation = value);
    }
  }
}
