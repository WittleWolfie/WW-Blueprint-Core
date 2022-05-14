//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
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
    protected BaseGlobalMapPointConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalMap(Blueprint<BlueprintGlobalMap, BlueprintGlobalMap.Reference> globalMap)
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
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.Type"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyType(Action<GlobalMapPointType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Type);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.IsHidden"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsHidden(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsHidden);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.RevealedOnStart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRevealedOnStart(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RevealedOnStart);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.ExploreOnEnter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExploreOnEnter(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ExploreOnEnter);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.ClosedOnStart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyClosedOnStart(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ClosedOnStart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Name"/>
    /// </summary>
    public TBuilder SetName(LocalizedString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name;
          if (bp.Name is null)
          {
            bp.Name = Utils.Constants.Empty.String;
          }
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
    public TBuilder SetDescription(LocalizedString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description;
          if (bp.Description is null)
          {
            bp.Description = Utils.Constants.Empty.String;
          }
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
    public TBuilder SetFakeName(LocalizedString fakeName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FakeName = fakeName;
          if (bp.FakeName is null)
          {
            bp.FakeName = Utils.Constants.Empty.String;
          }
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
    public TBuilder SetFakeDescription(LocalizedString fakeDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FakeDescription = fakeDescription;
          if (bp.FakeDescription is null)
          {
            bp.FakeDescription = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.DcPerception"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDcPerception(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DcPerception);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.DCModifiers"/>
    /// </summary>
    public TBuilder SetDCModifiers(DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in dCModifiers) { Validate(item); }
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
          bp.DCModifiers = bp.DCModifiers.Where(predicate).ToArray();
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.OverrideRandomEncounterZoneSize"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverrideRandomEncounterZoneSize(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OverrideRandomEncounterZoneSize);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.NoRandomEncounterZoneSize"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoRandomEncounterZoneSize(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoRandomEncounterZoneSize);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAreaEntrance(Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> areaEntrance)
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
    ///
    /// <param name="areaEntrance">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEntrances(Blueprint<BlueprintMultiEntrance, BlueprintMultiEntrance.Reference> entrances)
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
    ///
    /// <param name="entrances">
    /// <para>
    /// Blueprint of type BlueprintMultiEntrance. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBookEvent(Blueprint<BlueprintDialog, BlueprintDialogReference> bookEvent)
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
    ///
    /// <param name="bookEvent">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
          if (bp.PossibleToRevealCondition is null)
          {
            bp.PossibleToRevealCondition = Utils.Constants.Empty.Conditions;
          }
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLocationVariations(List<Blueprint<BlueprintGlobalMapPointVariation, BlueprintGlobalMapPointVariation.Reference>> locationVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocationVariations = locationVariations?.Select(bp => bp.Reference)?.ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLocationVariations(params Blueprint<BlueprintGlobalMapPointVariation, BlueprintGlobalMapPointVariation.Reference>[] locationVariations)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocationVariations(params Blueprint<BlueprintGlobalMapPointVariation, BlueprintGlobalMapPointVariation.Reference>[] locationVariations)
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
    ///
    /// <param name="locationVariations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPointVariation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLocationVariations(Func<BlueprintGlobalMapPointVariation.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocationVariations is null) { return; }
          bp.LocationVariations = bp.LocationVariations.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintGlobalMapPoint.LocationVariations"/>
    /// </summary>
    ///
    /// <param name="locationVariations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPointVariation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///
    /// <param name="locationVariations">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPointVariation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.HasKingdomResource"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasKingdomResource(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasKingdomResource);
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
    public TBuilder SetResourceName(LocalizedString resourceName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceName = resourceName;
          if (bp.ResourceName is null)
          {
            bp.ResourceName = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.HasIngredients"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasIngredients(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasIngredients);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Ingredients"/>
    /// </summary>
    public TBuilder SetIngredients(IngredientPair[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in ingredients) { Validate(item); }
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
          bp.Ingredients = bp.Ingredients.Where(predicate).ToArray();
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.HasLoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasLoot(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasLoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.Loot"/>
    /// </summary>
    public TBuilder SetLoot(LootEntry[] loot)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in loot) { Validate(item); }
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
          bp.Loot = bp.Loot.Where(predicate).ToArray();
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.AdditionalArmyExperience"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAdditionalArmyExperience(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AdditionalArmyExperience);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.ResourceFoundDescription"/>
    /// </summary>
    public TBuilder SetResourceFoundDescription(LocalizedString resourceFoundDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceFoundDescription = resourceFoundDescription;
          if (bp.ResourceFoundDescription is null)
          {
            bp.ResourceFoundDescription = Utils.Constants.Empty.String;
          }
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmyObjective(Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference> armyObjective)
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
    ///
    /// <param name="armyObjective">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.Region"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRegion(Action<RegionId> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Region);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.ForceShowNameInUI"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForceShowNameInUI(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ForceShowNameInUI);
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.OverrideEnterConfirmationText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverrideEnterConfirmationText(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OverrideEnterConfirmationText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.CustomEnterConfirmationText"/>
    /// </summary>
    public TBuilder SetCustomEnterConfirmationText(LocalizedString customEnterConfirmationText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomEnterConfirmationText = customEnterConfirmationText;
          if (bp.CustomEnterConfirmationText is null)
          {
            bp.CustomEnterConfirmationText = Utils.Constants.Empty.String;
          }
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
          if (bp.OnEnterActions is null)
          {
            bp.OnEnterActions = Utils.Constants.Empty.Actions;
          }
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDemonGarrison(Blueprint<BlueprintArmyPreset, BlueprintArmyPreset.Reference> demonGarrison)
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
    ///
    /// <param name="demonGarrison">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGarrisonLeader(Blueprint<BlueprintArmyLeader, BlueprintArmyLeaderReference> garrisonLeader)
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
    ///
    /// <param name="garrisonLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.UseCustomClosedText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseCustomClosedText(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UseCustomClosedText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPoint.CustomClosedText"/>
    /// </summary>
    public TBuilder SetCustomClosedText(LocalizedString customClosedText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomClosedText = customClosedText;
          if (bp.CustomClosedText is null)
          {
            bp.CustomClosedText = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintGlobalMapPoint.GlobalMapZone"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGlobalMapZone(Action<GlobalMapZone> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.GlobalMapZone);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddLocationRadiusBuff(
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        float? radius = null)
    {
      var component = new LocationRadiusBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.Radius = radius ?? component.Radius;
      return AddComponent(component);
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
