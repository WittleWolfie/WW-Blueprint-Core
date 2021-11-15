using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintUnitTemplate"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitTemplate))]
  public class UnitTemplateConfigurator : BaseBlueprintConfigurator<BlueprintUnitTemplate, UnitTemplateConfigurator>
  {
     private UnitTemplateConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitTemplateConfigurator For(string name)
    {
      return new UnitTemplateConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitTemplateConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitTemplate>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitTemplateConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitTemplate>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator AddToRemoveFacts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_RemoveFacts = CommonTool.Append(bp.m_RemoveFacts, values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator RemoveFromRemoveFacts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_RemoveFacts =
                bp.m_RemoveFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator AddToAddFacts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_AddFacts = CommonTool.Append(bp.m_AddFacts, values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator RemoveFromAddFacts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_AddFacts =
                bp.m_AddFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.StatAdjustments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTemplateConfigurator AddToStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.StatAdjustments = CommonTool.Append(bp.StatAdjustments, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.StatAdjustments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTemplateConfigurator RemoveFromStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.StatAdjustments = bp.StatAdjustments.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
