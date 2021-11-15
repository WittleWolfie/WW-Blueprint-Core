using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
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
    /// Sets <see cref="BlueprintGlobalMapPointVariation.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.Conditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.NameFromSettlement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSettlement"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetNameFromSettlement(string value)
    {
      return OnConfigureInternal(bp => bp.NameFromSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.FakeName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetFakeName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FakeName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.FakeDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetFakeDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FakeDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.m_AreaEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetAreaEntrance(string value)
    {
      return OnConfigureInternal(bp => bp.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.m_Entrances"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintMultiEntrance"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetEntrances(string value)
    {
      return OnConfigureInternal(bp => bp.m_Entrances = BlueprintTool.GetRef<BlueprintMultiEntranceReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.m_BookEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDialog"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetBookEvent(string value)
    {
      return OnConfigureInternal(bp => bp.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(value));
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
