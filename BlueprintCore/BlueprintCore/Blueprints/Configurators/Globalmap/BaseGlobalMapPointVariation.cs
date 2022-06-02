//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using System;
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
    protected BaseGlobalMapPointVariationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
          if (bp.Conditions is null)
          {
            bp.Conditions = Utils.Constants.Empty.Conditions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          action.Invoke(bp.Conditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.Name"/>
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
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.Name"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.NameFromSettlement"/>
    /// </summary>
    ///
    /// <param name="nameFromSettlement">
    /// <para>
    /// Blueprint of type BlueprintSettlement. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNameFromSettlement(Blueprint<BlueprintSettlement.Reference> nameFromSettlement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NameFromSettlement = nameFromSettlement?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.NameFromSettlement"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNameFromSettlement(Action<BlueprintSettlement.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NameFromSettlement is null) { return; }
          action.Invoke(bp.NameFromSettlement);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.Description"/>
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
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.FakeName"/>
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
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.FakeName"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.FakeDescription"/>
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
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.FakeDescription"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.m_AreaEntrance"/>
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
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.m_AreaEntrance"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.m_Entrances"/>
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
    public TBuilder SetEntrances(Blueprint<BlueprintMultiEntranceReference> entrances)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Entrances = entrances?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.m_Entrances"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEntrances(Action<BlueprintMultiEntranceReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Entrances is null) { return; }
          action.Invoke(bp.m_Entrances);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapPointVariation.m_BookEvent"/>
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
    /// Modifies <see cref="BlueprintGlobalMapPointVariation.m_BookEvent"/> by invoking the provided action.
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
        LocalizedString? description = null,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
