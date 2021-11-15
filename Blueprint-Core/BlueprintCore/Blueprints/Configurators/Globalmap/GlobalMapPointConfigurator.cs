using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMapPoint"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPoint))]
  public class GlobalMapPointConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPoint, GlobalMapPointConfigurator>
  {
     private GlobalMapPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointConfigurator For(string name)
    {
      return new GlobalMapPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMapPointConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_GlobalMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMap"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetGlobalMap(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetType(GlobalMapPointType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.IsHidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetIsHidden(bool value)
    {
      return OnConfigureInternal(bp => bp.IsHidden = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.RevealedOnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetRevealedOnStart(bool value)
    {
      return OnConfigureInternal(bp => bp.RevealedOnStart = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ExploreOnEnter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetExploreOnEnter(bool value)
    {
      return OnConfigureInternal(bp => bp.ExploreOnEnter = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ClosedOnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetClosedOnStart(bool value)
    {
      return OnConfigureInternal(bp => bp.ClosedOnStart = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.FakeName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetFakeName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FakeName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.FakeDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetFakeDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FakeDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.DcPerception"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetDcPerception(int value)
    {
      return OnConfigureInternal(bp => bp.DcPerception = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator AddToDCModifiers(params DCModifier[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DCModifiers = CommonTool.Append(bp.DCModifiers, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromDCModifiers(params DCModifier[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DCModifiers = bp.DCModifiers.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.OverrideRandomEncounterZoneSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetOverrideRandomEncounterZoneSize(bool value)
    {
      return OnConfigureInternal(bp => bp.OverrideRandomEncounterZoneSize = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.NoRandomEncounterZoneSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetNoRandomEncounterZoneSize(float value)
    {
      return OnConfigureInternal(bp => bp.NoRandomEncounterZoneSize = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_AreaEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetAreaEntrance(string value)
    {
      return OnConfigureInternal(bp => bp.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_Entrances"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintMultiEntrance"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetEntrances(string value)
    {
      return OnConfigureInternal(bp => bp.m_Entrances = BlueprintTool.GetRef<BlueprintMultiEntrance.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_BookEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDialog"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetBookEvent(string value)
    {
      return OnConfigureInternal(bp => bp.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.PossibleToRevealCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetPossibleToRevealCondition(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.PossibleToRevealCondition = value.Build());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.LocationVariations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPointVariation"/></param>
    [Generated]
    public GlobalMapPointConfigurator AddToLocationVariations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.LocationVariations = CommonTool.Append(bp.LocationVariations, values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPointVariation.Reference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.LocationVariations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintGlobalMapPointVariation"/></param>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromLocationVariations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPointVariation.Reference>(name));
            bp.LocationVariations =
                bp.LocationVariations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.HasKingdomResource"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetHasKingdomResource(bool value)
    {
      return OnConfigureInternal(bp => bp.HasKingdomResource = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ResourceStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetResourceStats(KingdomStats.Changes value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourceStats = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ResourceName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetResourceName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourceName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.HasIngredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetHasIngredients(bool value)
    {
      return OnConfigureInternal(bp => bp.HasIngredients = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator AddToIngredients(params IngredientPair[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Ingredients = CommonTool.Append(bp.Ingredients, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromIngredients(params IngredientPair[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Ingredients = bp.Ingredients.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.HasLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetHasLoot(bool value)
    {
      return OnConfigureInternal(bp => bp.HasLoot = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator AddToLoot(params LootEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Loot = CommonTool.Append(bp.Loot, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromLoot(params LootEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Loot = bp.Loot.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.AdditionalArmyExperience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetAdditionalArmyExperience(int value)
    {
      return OnConfigureInternal(bp => bp.AdditionalArmyExperience = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ResourceFoundDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetResourceFoundDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourceFoundDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_ArmyObjective"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintQuestObjective"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetArmyObjective(string value)
    {
      return OnConfigureInternal(bp => bp.m_ArmyObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Region"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetRegion(RegionId value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Region = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ForceShowNameInUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetForceShowNameInUI(bool value)
    {
      return OnConfigureInternal(bp => bp.ForceShowNameInUI = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.OverrideEnterConfirmationText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetOverrideEnterConfirmationText(bool value)
    {
      return OnConfigureInternal(bp => bp.OverrideEnterConfirmationText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.CustomEnterConfirmationText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetCustomEnterConfirmationText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CustomEnterConfirmationText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.OnEnterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetOnEnterActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnEnterActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.DemonGarrison"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArmyPreset"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetDemonGarrison(string value)
    {
      return OnConfigureInternal(bp => bp.DemonGarrison = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.GarrisonLeader"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArmyLeader"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetGarrisonLeader(string value)
    {
      return OnConfigureInternal(bp => bp.GarrisonLeader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.AutoDefeatData"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetAutoDefeatData(AutoDefeatData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AutoDefeatData = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.UseCustomClosedText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetUseCustomClosedText(bool value)
    {
      return OnConfigureInternal(bp => bp.UseCustomClosedText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.CustomClosedText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetCustomClosedText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CustomClosedText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.GlobalMapZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetGlobalMapZone(GlobalMapZone value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.GlobalMapZone = value);
    }

    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(LocationRadiusBuff))]
    public GlobalMapPointConfigurator AddLocationRadiusBuff(
        float Radius,
        string m_Buff)
    {
      
      var component =  new LocationRadiusBuff();
      component.Radius = Radius;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LocationRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="RequiredCompanions"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(LocationRestriction))]
    public GlobalMapPointConfigurator AddLocationRestriction(
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

    /// <summary>
    /// Adds <see cref="LocationRevealedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LocationRevealedTrigger))]
    public GlobalMapPointConfigurator AddLocationRevealedTrigger(
        bool OnlyOnce,
        ActionsBuilder OnReveal)
    {
      
      var component =  new LocationRevealedTrigger();
      component.OnlyOnce = OnlyOnce;
      component.OnReveal = OnReveal.Build();
      return AddComponent(component);
    }
  }
}
