//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Blueprints.Quests;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMapPoint"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMapPointConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMapPoint
    where TBuilder : BaseGlobalMapPointConfigurator<T, TBuilder>
  {
    protected BaseGlobalMapPointConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintGlobalMapPoint>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_GlobalMap = copyFrom.m_GlobalMap;
          bp.Type = copyFrom.Type;
          bp.IsHidden = copyFrom.IsHidden;
          bp.RevealedOnStart = copyFrom.RevealedOnStart;
          bp.ExploreOnEnter = copyFrom.ExploreOnEnter;
          bp.ClosedOnStart = copyFrom.ClosedOnStart;
          bp.Name = copyFrom.Name;
          bp.Description = copyFrom.Description;
          bp.FakeName = copyFrom.FakeName;
          bp.FakeDescription = copyFrom.FakeDescription;
          bp.DcPerception = copyFrom.DcPerception;
          bp.DCModifiers = copyFrom.DCModifiers;
          bp.OverrideRandomEncounterZoneSize = copyFrom.OverrideRandomEncounterZoneSize;
          bp.NoRandomEncounterZoneSize = copyFrom.NoRandomEncounterZoneSize;
          bp.m_AreaEntrance = copyFrom.m_AreaEntrance;
          bp.m_Entrances = copyFrom.m_Entrances;
          bp.m_BookEvent = copyFrom.m_BookEvent;
          bp.PossibleToRevealCondition = copyFrom.PossibleToRevealCondition;
          bp.LocationVariations = copyFrom.LocationVariations;
          bp.HasKingdomResource = copyFrom.HasKingdomResource;
          bp.ResourceStats = copyFrom.ResourceStats;
          bp.ResourceName = copyFrom.ResourceName;
          bp.HasIngredients = copyFrom.HasIngredients;
          bp.Ingredients = copyFrom.Ingredients;
          bp.HasLoot = copyFrom.HasLoot;
          bp.Loot = copyFrom.Loot;
          bp.AdditionalArmyExperience = copyFrom.AdditionalArmyExperience;
          bp.ResourceFoundDescription = copyFrom.ResourceFoundDescription;
          bp.m_ArmyObjective = copyFrom.m_ArmyObjective;
          bp.Region = copyFrom.Region;
          bp.ForceShowNameInUI = copyFrom.ForceShowNameInUI;
          bp.OverrideEnterConfirmationText = copyFrom.OverrideEnterConfirmationText;
          bp.CustomEnterConfirmationText = copyFrom.CustomEnterConfirmationText;
          bp.OnEnterActions = copyFrom.OnEnterActions;
          bp.DemonGarrison = copyFrom.DemonGarrison;
          bp.GarrisonLeader = copyFrom.GarrisonLeader;
          bp.AutoDefeatData = copyFrom.AutoDefeatData;
          bp.UseCustomClosedText = copyFrom.UseCustomClosedText;
          bp.CustomClosedText = copyFrom.CustomClosedText;
          bp.GlobalMapZone = copyFrom.GlobalMapZone;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintGlobalMapPoint>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_GlobalMap = copyFrom.m_GlobalMap;
          bp.Type = copyFrom.Type;
          bp.IsHidden = copyFrom.IsHidden;
          bp.RevealedOnStart = copyFrom.RevealedOnStart;
          bp.ExploreOnEnter = copyFrom.ExploreOnEnter;
          bp.ClosedOnStart = copyFrom.ClosedOnStart;
          bp.Name = copyFrom.Name;
          bp.Description = copyFrom.Description;
          bp.FakeName = copyFrom.FakeName;
          bp.FakeDescription = copyFrom.FakeDescription;
          bp.DcPerception = copyFrom.DcPerception;
          bp.DCModifiers = copyFrom.DCModifiers;
          bp.OverrideRandomEncounterZoneSize = copyFrom.OverrideRandomEncounterZoneSize;
          bp.NoRandomEncounterZoneSize = copyFrom.NoRandomEncounterZoneSize;
          bp.m_AreaEntrance = copyFrom.m_AreaEntrance;
          bp.m_Entrances = copyFrom.m_Entrances;
          bp.m_BookEvent = copyFrom.m_BookEvent;
          bp.PossibleToRevealCondition = copyFrom.PossibleToRevealCondition;
          bp.LocationVariations = copyFrom.LocationVariations;
          bp.HasKingdomResource = copyFrom.HasKingdomResource;
          bp.ResourceStats = copyFrom.ResourceStats;
          bp.ResourceName = copyFrom.ResourceName;
          bp.HasIngredients = copyFrom.HasIngredients;
          bp.Ingredients = copyFrom.Ingredients;
          bp.HasLoot = copyFrom.HasLoot;
          bp.Loot = copyFrom.Loot;
          bp.AdditionalArmyExperience = copyFrom.AdditionalArmyExperience;
          bp.ResourceFoundDescription = copyFrom.ResourceFoundDescription;
          bp.m_ArmyObjective = copyFrom.m_ArmyObjective;
          bp.Region = copyFrom.Region;
          bp.ForceShowNameInUI = copyFrom.ForceShowNameInUI;
          bp.OverrideEnterConfirmationText = copyFrom.OverrideEnterConfirmationText;
          bp.CustomEnterConfirmationText = copyFrom.CustomEnterConfirmationText;
          bp.OnEnterActions = copyFrom.OnEnterActions;
          bp.DemonGarrison = copyFrom.DemonGarrison;
          bp.GarrisonLeader = copyFrom.GarrisonLeader;
          bp.AutoDefeatData = copyFrom.AutoDefeatData;
          bp.UseCustomClosedText = copyFrom.UseCustomClosedText;
          bp.CustomClosedText = copyFrom.CustomClosedText;
          bp.GlobalMapZone = copyFrom.GlobalMapZone;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.m_GlobalMap"/>
    /// </summary>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalMap(Blueprint<BlueprintGlobalMap.Reference> globalMap)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalMap = globalMap?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.m_GlobalMap"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGlobalMap(Action<BlueprintGlobalMap.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalMap is null) { return; }
          action.Invoke(bp.m_GlobalMap);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Type"/>
    /// </summary>
    public TBuilder SetType(GlobalMapPointType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.IsHidden"/>
    /// </summary>
    public TBuilder SetIsHidden(bool isHidden = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsHidden = isHidden;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.RevealedOnStart"/>
    /// </summary>
    public TBuilder SetRevealedOnStart(bool revealedOnStart = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RevealedOnStart = revealedOnStart;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ExploreOnEnter"/>
    /// </summary>
    public TBuilder SetExploreOnEnter(bool exploreOnEnter = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExploreOnEnter = exploreOnEnter;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ClosedOnStart"/>
    /// </summary>
    public TBuilder SetClosedOnStart(bool closedOnStart = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClosedOnStart = closedOnStart;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Description"/>
    /// </summary>
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.FakeName"/>
    /// </summary>
    ///
    /// <param name="fakeName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetFakeName(LocalString fakeName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FakeName = fakeName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.FakeName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFakeName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FakeName is null) { return; }
          action.Invoke(bp.FakeName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.FakeDescription"/>
    /// </summary>
    ///
    /// <param name="fakeDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetFakeDescription(LocalString fakeDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FakeDescription = fakeDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.FakeDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFakeDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FakeDescription is null) { return; }
          action.Invoke(bp.FakeDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.DcPerception"/>
    /// </summary>
    public TBuilder SetDcPerception(int dcPerception)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DcPerception = dcPerception;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.DCModifiers"/>
    /// </summary>
    public TBuilder SetDCModifiers(params DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dCModifiers);
          bp.DCModifiers = dCModifiers;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintGlobalMapPoint.DCModifiers"/>
    /// </summary>
    public TBuilder AddToDCModifiers(params DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DCModifiers = bp.DCModifiers ?? new DCModifier[0];
          bp.DCModifiers = CommonTool.Append(bp.DCModifiers, dCModifiers);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.DCModifiers"/>
    /// </summary>
    public TBuilder RemoveFromDCModifiers(params DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DCModifiers is null) { return; }
          bp.DCModifiers = bp.DCModifiers.Where(val => !dCModifiers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.DCModifiers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDCModifiers(Func<DCModifier, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DCModifiers is null) { return; }
          bp.DCModifiers = bp.DCModifiers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMapPoint.DCModifiers"/>
    /// </summary>
    public TBuilder ClearDCModifiers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DCModifiers = new DCModifier[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.DCModifiers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDCModifiers(Action<DCModifier> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DCModifiers is null) { return; }
          bp.DCModifiers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.OverrideRandomEncounterZoneSize"/>
    /// </summary>
    public TBuilder SetOverrideRandomEncounterZoneSize(bool overrideRandomEncounterZoneSize = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideRandomEncounterZoneSize = overrideRandomEncounterZoneSize;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.NoRandomEncounterZoneSize"/>
    /// </summary>
    public TBuilder SetNoRandomEncounterZoneSize(float noRandomEncounterZoneSize)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoRandomEncounterZoneSize = noRandomEncounterZoneSize;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.m_AreaEntrance"/>
    /// </summary>
    ///
    /// <param name="areaEntrance">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAreaEntrance(Blueprint<BlueprintAreaEnterPointReference> areaEntrance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AreaEntrance = areaEntrance?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.m_AreaEntrance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaEntrance(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AreaEntrance is null) { return; }
          action.Invoke(bp.m_AreaEntrance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.m_Entrances"/>
    /// </summary>
    ///
    /// <param name="entrances">
    /// <para>
    /// Blueprint of type BlueprintMultiEntrance. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEntrances(Blueprint<BlueprintMultiEntrance.Reference> entrances)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Entrances = entrances?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.m_Entrances"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEntrances(Action<BlueprintMultiEntrance.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entrances is null) { return; }
          action.Invoke(bp.m_Entrances);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.m_BookEvent"/>
    /// </summary>
    ///
    /// <param name="bookEvent">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBookEvent(Blueprint<BlueprintDialogReference> bookEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BookEvent = bookEvent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.m_BookEvent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBookEvent(Action<BlueprintDialogReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BookEvent is null) { return; }
          action.Invoke(bp.m_BookEvent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.PossibleToRevealCondition"/>
    /// </summary>
    public TBuilder SetPossibleToRevealCondition(ConditionsBuilder possibleToRevealCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PossibleToRevealCondition = possibleToRevealCondition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.PossibleToRevealCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPossibleToRevealCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PossibleToRevealCondition is null) { return; }
          action.Invoke(bp.PossibleToRevealCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.LocationVariations"/>
    /// </summary>
    ///
    /// <param name="locationVariations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPointVariation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLocationVariations(params Blueprint<BlueprintGlobalMapPointVariation.Reference>[] locationVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocationVariations = locationVariations.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintGlobalMapPoint.LocationVariations"/>
    /// </summary>
    ///
    /// <param name="locationVariations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPointVariation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLocationVariations(params Blueprint<BlueprintGlobalMapPointVariation.Reference>[] locationVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocationVariations = bp.LocationVariations ?? new BlueprintGlobalMapPointVariation.Reference[0];
          bp.LocationVariations = CommonTool.Append(bp.LocationVariations, locationVariations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.LocationVariations"/>
    /// </summary>
    ///
    /// <param name="locationVariations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPointVariation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocationVariations(params Blueprint<BlueprintGlobalMapPointVariation.Reference>[] locationVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocationVariations is null) { return; }
          bp.LocationVariations = bp.LocationVariations.Where(val => !locationVariations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.LocationVariations"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLocationVariations(Func<BlueprintGlobalMapPointVariation.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocationVariations is null) { return; }
          bp.LocationVariations = bp.LocationVariations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMapPoint.LocationVariations"/>
    /// </summary>
    public TBuilder ClearLocationVariations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocationVariations = new BlueprintGlobalMapPointVariation.Reference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.LocationVariations"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLocationVariations(Action<BlueprintGlobalMapPointVariation.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocationVariations is null) { return; }
          bp.LocationVariations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.HasKingdomResource"/>
    /// </summary>
    public TBuilder SetHasKingdomResource(bool hasKingdomResource = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasKingdomResource = hasKingdomResource;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ResourceStats"/>
    /// </summary>
    public TBuilder SetResourceStats(KingdomStats.Changes resourceStats)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(resourceStats);
          bp.ResourceStats = resourceStats;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.ResourceStats"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourceStats(Action<KingdomStats.Changes> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceStats is null) { return; }
          action.Invoke(bp.ResourceStats);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ResourceName"/>
    /// </summary>
    ///
    /// <param name="resourceName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetResourceName(LocalString resourceName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceName = resourceName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.ResourceName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourceName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceName is null) { return; }
          action.Invoke(bp.ResourceName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.HasIngredients"/>
    /// </summary>
    public TBuilder SetHasIngredients(bool hasIngredients = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasIngredients = hasIngredients;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Ingredients"/>
    /// </summary>
    public TBuilder SetIngredients(params IngredientPair[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(ingredients);
          bp.Ingredients = ingredients;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintGlobalMapPoint.Ingredients"/>
    /// </summary>
    public TBuilder AddToIngredients(params IngredientPair[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Ingredients = bp.Ingredients ?? new IngredientPair[0];
          bp.Ingredients = CommonTool.Append(bp.Ingredients, ingredients);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.Ingredients"/>
    /// </summary>
    public TBuilder RemoveFromIngredients(params IngredientPair[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Ingredients is null) { return; }
          bp.Ingredients = bp.Ingredients.Where(val => !ingredients.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.Ingredients"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIngredients(Func<IngredientPair, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Ingredients is null) { return; }
          bp.Ingredients = bp.Ingredients.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMapPoint.Ingredients"/>
    /// </summary>
    public TBuilder ClearIngredients()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Ingredients = new IngredientPair[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Ingredients"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIngredients(Action<IngredientPair> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Ingredients is null) { return; }
          bp.Ingredients.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.HasLoot"/>
    /// </summary>
    public TBuilder SetHasLoot(bool hasLoot = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasLoot = hasLoot;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Loot"/>
    /// </summary>
    public TBuilder SetLoot(params LootEntry[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(loot);
          bp.Loot = loot;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintGlobalMapPoint.Loot"/>
    /// </summary>
    public TBuilder AddToLoot(params LootEntry[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Loot = bp.Loot ?? new LootEntry[0];
          bp.Loot = CommonTool.Append(bp.Loot, loot);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.Loot"/>
    /// </summary>
    public TBuilder RemoveFromLoot(params LootEntry[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Loot is null) { return; }
          bp.Loot = bp.Loot.Where(val => !loot.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintGlobalMapPoint.Loot"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLoot(Func<LootEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Loot is null) { return; }
          bp.Loot = bp.Loot.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMapPoint.Loot"/>
    /// </summary>
    public TBuilder ClearLoot()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Loot = new LootEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.Loot"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLoot(Action<LootEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Loot is null) { return; }
          bp.Loot.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.AdditionalArmyExperience"/>
    /// </summary>
    public TBuilder SetAdditionalArmyExperience(int additionalArmyExperience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AdditionalArmyExperience = additionalArmyExperience;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ResourceFoundDescription"/>
    /// </summary>
    ///
    /// <param name="resourceFoundDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetResourceFoundDescription(LocalString resourceFoundDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceFoundDescription = resourceFoundDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.ResourceFoundDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourceFoundDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceFoundDescription is null) { return; }
          action.Invoke(bp.ResourceFoundDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.m_ArmyObjective"/>
    /// </summary>
    ///
    /// <param name="armyObjective">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmyObjective(Blueprint<BlueprintQuestObjectiveReference> armyObjective)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyObjective = armyObjective?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.m_ArmyObjective"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmyObjective(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmyObjective is null) { return; }
          action.Invoke(bp.m_ArmyObjective);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Region"/>
    /// </summary>
    public TBuilder SetRegion(RegionId region)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Region = region;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ForceShowNameInUI"/>
    /// </summary>
    public TBuilder SetForceShowNameInUI(bool forceShowNameInUI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForceShowNameInUI = forceShowNameInUI;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.OverrideEnterConfirmationText"/>
    /// </summary>
    public TBuilder SetOverrideEnterConfirmationText(bool overrideEnterConfirmationText = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideEnterConfirmationText = overrideEnterConfirmationText;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.CustomEnterConfirmationText"/>
    /// </summary>
    ///
    /// <param name="customEnterConfirmationText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetCustomEnterConfirmationText(LocalString customEnterConfirmationText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomEnterConfirmationText = customEnterConfirmationText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.CustomEnterConfirmationText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomEnterConfirmationText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CustomEnterConfirmationText is null) { return; }
          action.Invoke(bp.CustomEnterConfirmationText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.OnEnterActions"/>
    /// </summary>
    public TBuilder SetOnEnterActions(ActionsBuilder onEnterActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnEnterActions = onEnterActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.OnEnterActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnEnterActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnEnterActions is null) { return; }
          action.Invoke(bp.OnEnterActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.DemonGarrison"/>
    /// </summary>
    ///
    /// <param name="demonGarrison">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDemonGarrison(Blueprint<BlueprintArmyPreset.Reference> demonGarrison)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DemonGarrison = demonGarrison?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.DemonGarrison"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDemonGarrison(Action<BlueprintArmyPreset.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DemonGarrison is null) { return; }
          action.Invoke(bp.DemonGarrison);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.GarrisonLeader"/>
    /// </summary>
    ///
    /// <param name="garrisonLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGarrisonLeader(Blueprint<BlueprintArmyLeaderReference> garrisonLeader)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GarrisonLeader = garrisonLeader?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.GarrisonLeader"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGarrisonLeader(Action<BlueprintArmyLeaderReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GarrisonLeader is null) { return; }
          action.Invoke(bp.GarrisonLeader);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.AutoDefeatData"/>
    /// </summary>
    public TBuilder SetAutoDefeatData(AutoDefeatData autoDefeatData)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(autoDefeatData);
          bp.AutoDefeatData = autoDefeatData;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.AutoDefeatData"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoDefeatData(Action<AutoDefeatData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AutoDefeatData is null) { return; }
          action.Invoke(bp.AutoDefeatData);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.UseCustomClosedText"/>
    /// </summary>
    public TBuilder SetUseCustomClosedText(bool useCustomClosedText = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UseCustomClosedText = useCustomClosedText;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.CustomClosedText"/>
    /// </summary>
    ///
    /// <param name="customClosedText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetCustomClosedText(LocalString customClosedText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomClosedText = customClosedText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPoint.CustomClosedText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomClosedText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CustomClosedText is null) { return; }
          action.Invoke(bp.CustomClosedText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.GlobalMapZone"/>
    /// </summary>
    public TBuilder SetGlobalMapZone(GlobalMapZone globalMapZone)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GlobalMapZone = globalMapZone;
        });
    }

    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Asylum</term><description>0fd24a67f41f4f63adb6e19bb526fb1f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddLocationRadiusBuff(
        Blueprint<BlueprintBuffReference>? buff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? radius = null)
    {
      var component = new LocationRadiusBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.Radius = radius ?? component.Radius;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

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
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="requiredCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddLocationRestriction(
        ConditionsBuilder? allowedCondition = null,
        LocalString? description = null,
        ConditionsBuilder? ignoreCondition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintUnitReference>>? requiredCompanions = null)
    {
      var component = new LocationRestriction();
      component.AllowedCondition = allowedCondition?.Build() ?? component.AllowedCondition;
      if (component.AllowedCondition is null)
      {
        component.AllowedCondition = Utils.Constants.Empty.Conditions;
      }
      component.Description = description?.LocalizedString ?? component.Description;
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_GlobalMap is null)
      {
        Blueprint.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.FakeName is null)
      {
        Blueprint.FakeName = Utils.Constants.Empty.String;
      }
      if (Blueprint.FakeDescription is null)
      {
        Blueprint.FakeDescription = Utils.Constants.Empty.String;
      }
      if (Blueprint.DCModifiers is null)
      {
        Blueprint.DCModifiers = new DCModifier[0];
      }
      if (Blueprint.m_AreaEntrance is null)
      {
        Blueprint.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_Entrances is null)
      {
        Blueprint.m_Entrances = BlueprintTool.GetRef<BlueprintMultiEntrance.Reference>(null);
      }
      if (Blueprint.m_BookEvent is null)
      {
        Blueprint.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      if (Blueprint.PossibleToRevealCondition is null)
      {
        Blueprint.PossibleToRevealCondition = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.LocationVariations is null)
      {
        Blueprint.LocationVariations = new BlueprintGlobalMapPointVariation.Reference[0];
      }
      if (Blueprint.ResourceName is null)
      {
        Blueprint.ResourceName = Utils.Constants.Empty.String;
      }
      if (Blueprint.Ingredients is null)
      {
        Blueprint.Ingredients = new IngredientPair[0];
      }
      if (Blueprint.Loot is null)
      {
        Blueprint.Loot = new LootEntry[0];
      }
      if (Blueprint.ResourceFoundDescription is null)
      {
        Blueprint.ResourceFoundDescription = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_ArmyObjective is null)
      {
        Blueprint.m_ArmyObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      if (Blueprint.CustomEnterConfirmationText is null)
      {
        Blueprint.CustomEnterConfirmationText = Utils.Constants.Empty.String;
      }
      if (Blueprint.OnEnterActions is null)
      {
        Blueprint.OnEnterActions = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.DemonGarrison is null)
      {
        Blueprint.DemonGarrison = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(null);
      }
      if (Blueprint.GarrisonLeader is null)
      {
        Blueprint.GarrisonLeader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(null);
      }
      if (Blueprint.CustomClosedText is null)
      {
        Blueprint.CustomClosedText = Utils.Constants.Empty.String;
      }
    }
  }
}
