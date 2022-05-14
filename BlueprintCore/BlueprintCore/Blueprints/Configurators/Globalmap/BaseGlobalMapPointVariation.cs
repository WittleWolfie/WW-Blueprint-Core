//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMapPointVariation"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMapPointVariationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMapPointVariation
    where TBuilder : BaseGlobalMapPointVariationConfigurator<T, TBuilder>
  {
    protected BaseGlobalMapPointVariationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="LocationRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Location_Daeran_Q2_HeavenDoorstep</term><description>ff7eb82a42780bd46817d9963bb40734</description></item>
    /// <item><term>Location_Lann_Q3_SavamelekhLair_Wenduag</term><description>2af1ff61a77c88646b5745b44b02ecec</description></item>
    /// <item><term>Point_SeelahCamp</term><description>7af4eb6fb78a56e40a18a038199fd555</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="requiredCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddLocationRestriction(
        ConditionsBuilder? allowedCondition = null,
        LocalizedString? description = null,
        ConditionsBuilder? ignoreCondition = null,
        List<Blueprint<BlueprintUnit, BlueprintUnitReference>>? requiredCompanions = null)
    {
      var component = new LocationRestriction();
      component.AllowedCondition = allowedCondition?.Build() ?? component.AllowedCondition;
      if (component.AllowedCondition is null)
      {
        component.AllowedCondition = Utils.Constants.Empty.Conditions;
      }
      component.Description = description ?? component.Description;
      if (component.Description is null)
      {
        component.Description = Utils.Constants.Empty.String;
      }
      component.IgnoreCondition = ignoreCondition?.Build() ?? component.IgnoreCondition;
      if (component.IgnoreCondition is null)
      {
        component.IgnoreCondition = Utils.Constants.Empty.Conditions;
      }
      component.RequiredCompanions = requiredCompanions?.Select(bp => bp.Reference)?.ToList() ?? component.RequiredCompanions;
      if (component.RequiredCompanions is null)
      {
        component.RequiredCompanions = new();
      }
      return AddComponent(component);
    }
  }
}
