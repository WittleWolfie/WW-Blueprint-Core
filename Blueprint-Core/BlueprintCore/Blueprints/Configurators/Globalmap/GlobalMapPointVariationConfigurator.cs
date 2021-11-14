using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMapPointVariation"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPointVariation))]
  public class GlobalMapPointVariationConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPointVariation, GlobalMapPointVariationConfigurator>
  {
     private GlobalMapPointVariationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointVariationConfigurator For(string name)
    {
      return new GlobalMapPointVariationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapPointVariationConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMapPointVariation>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointVariationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMapPointVariation>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="LocationRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="RequiredCompanions"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(LocationRestriction))]
    public GlobalMapPointVariationConfigurator AddLocationRestriction(
        ConditionsBuilder IgnoreCondition,
        ConditionsBuilder AllowedCondition,
        string[] RequiredCompanions,
        LocalizedString Description)
    {
      ValidateParam(Description);
      
      var component =  new LocationRestriction();
      component.IgnoreCondition = IgnoreCondition.Build();
      component.AllowedCondition = AllowedCondition.Build();
      component.RequiredCompanions = RequiredCompanions.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToList();
      component.Description = Description;
      return AddComponent(component);
    }
  }
}
