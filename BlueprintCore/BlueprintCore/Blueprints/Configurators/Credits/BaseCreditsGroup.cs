//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Credits;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCreditsGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCreditsGroupConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCreditsGroup
    where TBuilder : BaseCreditsGroupConfigurator<T, TBuilder>
  {
    protected BaseCreditsGroupConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.TabIcon"/>
    /// </summary>
    public TBuilder SetTabIcon(Sprite tabIcon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(tabIcon);
          bp.TabIcon = tabIcon;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.TabIcon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTabIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TabIcon is null) { return; }
          action.Invoke(bp.TabIcon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.HeaderText"/>
    /// </summary>
    public TBuilder SetHeaderText(LocalizedString headerText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HeaderText = headerText;
          if (bp.HeaderText is null)
          {
            bp.HeaderText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.HeaderText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHeaderText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HeaderText is null) { return; }
          action.Invoke(bp.HeaderText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.LeftPageImage"/>
    /// </summary>
    public TBuilder SetLeftPageImage(Sprite leftPageImage)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(leftPageImage);
          bp.LeftPageImage = leftPageImage;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.LeftPageImage"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeftPageImage(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeftPageImage is null) { return; }
          action.Invoke(bp.LeftPageImage);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.LeftPageText"/>
    /// </summary>
    public TBuilder SetLeftPageText(LocalizedString leftPageText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeftPageText = leftPageText;
          if (bp.LeftPageText is null)
          {
            bp.LeftPageText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.LeftPageText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeftPageText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeftPageText is null) { return; }
          action.Invoke(bp.LeftPageText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.m_RolesData"/>
    /// </summary>
    ///
    /// <param name="rolesData">
    /// <para>
    /// Blueprint of type BlueprintCreditsRoles. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRolesData(Blueprint<BlueprintCreditsRolesReference> rolesData)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RolesData = rolesData?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.m_RolesData"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRolesData(Action<BlueprintCreditsRolesReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RolesData is null) { return; }
          action.Invoke(bp.m_RolesData);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.m_TeamsData"/>
    /// </summary>
    ///
    /// <param name="teamsData">
    /// <para>
    /// Blueprint of type BlueprintCreditsTeams. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTeamsData(Blueprint<BlueprintCreditsTeamsReference> teamsData)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TeamsData = teamsData?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.m_TeamsData"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTeamsData(Action<BlueprintCreditsTeamsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TeamsData is null) { return; }
          action.Invoke(bp.m_TeamsData);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.OrderTeams"/>
    /// </summary>
    public TBuilder SetOrderTeams(params string[] orderTeams)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OrderTeams = orderTeams.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCreditsGroup.OrderTeams"/>
    /// </summary>
    public TBuilder AddToOrderTeams(params string[] orderTeams)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OrderTeams = bp.OrderTeams ?? new();
          bp.OrderTeams.AddRange(orderTeams);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsGroup.OrderTeams"/>
    /// </summary>
    public TBuilder RemoveFromOrderTeams(params string[] orderTeams)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OrderTeams is null) { return; }
          bp.OrderTeams = bp.OrderTeams.Where(val => !orderTeams.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsGroup.OrderTeams"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOrderTeams(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OrderTeams is null) { return; }
          bp.OrderTeams = bp.OrderTeams.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCreditsGroup.OrderTeams"/>
    /// </summary>
    public TBuilder ClearOrderTeams()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OrderTeams = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.OrderTeams"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOrderTeams(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OrderTeams is null) { return; }
          bp.OrderTeams.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsGroup.Persones"/>
    /// </summary>
    public TBuilder SetPersones(params CreditPerson[] persones)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in persones) { Validate(item); }
          bp.Persones = persones.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCreditsGroup.Persones"/>
    /// </summary>
    public TBuilder AddToPersones(params CreditPerson[] persones)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Persones = bp.Persones ?? new();
          bp.Persones.AddRange(persones);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsGroup.Persones"/>
    /// </summary>
    public TBuilder RemoveFromPersones(params CreditPerson[] persones)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Persones is null) { return; }
          bp.Persones = bp.Persones.Where(val => !persones.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsGroup.Persones"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPersones(Func<CreditPerson, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Persones is null) { return; }
          bp.Persones = bp.Persones.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCreditsGroup.Persones"/>
    /// </summary>
    public TBuilder ClearPersones()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Persones = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.Persones"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPersones(Action<CreditPerson> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Persones is null) { return; }
          bp.Persones.ForEach(action);
        });
    }
  }
}
