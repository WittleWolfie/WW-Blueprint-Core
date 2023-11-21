//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LocatorsConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLocatorsConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : LocatorsConsideration
    where TBuilder : BaseLocatorsConsiderationConfigurator<T, TBuilder>
  {
    protected BaseLocatorsConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<LocatorsConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Locators = copyFrom.Locators;
          bp.CheckCasterDistance = copyFrom.CheckCasterDistance;
          bp.MinCasterDistanceToLocator = copyFrom.MinCasterDistanceToLocator;
          bp.CheckPartyDistance = copyFrom.CheckPartyDistance;
          bp.MinPartyDistanceToLocator = copyFrom.MinPartyDistanceToLocator;
          bp.MaxPartyDistanceToLocator = copyFrom.MaxPartyDistanceToLocator;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<LocatorsConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Locators = copyFrom.Locators;
          bp.CheckCasterDistance = copyFrom.CheckCasterDistance;
          bp.MinCasterDistanceToLocator = copyFrom.MinCasterDistanceToLocator;
          bp.CheckPartyDistance = copyFrom.CheckPartyDistance;
          bp.MinPartyDistanceToLocator = copyFrom.MinPartyDistanceToLocator;
          bp.MaxPartyDistanceToLocator = copyFrom.MaxPartyDistanceToLocator;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LocatorsConsideration.Locators"/>
    /// </summary>
    public TBuilder SetLocators(params EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(locators);
          bp.Locators = locators;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="LocatorsConsideration.Locators"/>
    /// </summary>
    public TBuilder AddToLocators(params EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locators = bp.Locators ?? new EntityReference[0];
          bp.Locators = CommonTool.Append(bp.Locators, locators);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="LocatorsConsideration.Locators"/>
    /// </summary>
    public TBuilder RemoveFromLocators(params EntityReference[] locators)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators = bp.Locators.Where(val => !locators.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="LocatorsConsideration.Locators"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLocators(Func<EntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators = bp.Locators.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="LocatorsConsideration.Locators"/>
    /// </summary>
    public TBuilder ClearLocators()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Locators = new EntityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="LocatorsConsideration.Locators"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLocators(Action<EntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Locators is null) { return; }
          bp.Locators.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LocatorsConsideration.CheckCasterDistance"/>
    /// </summary>
    public TBuilder SetCheckCasterDistance(bool checkCasterDistance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckCasterDistance = checkCasterDistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LocatorsConsideration.MinCasterDistanceToLocator"/>
    /// </summary>
    ///
    /// <param name="minCasterDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from caster by at least MinCasterDistanceToLocator meters (0 means no limit)
    /// </para>
    /// </param>
    public TBuilder SetMinCasterDistanceToLocator(float minCasterDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinCasterDistanceToLocator = minCasterDistanceToLocator;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LocatorsConsideration.CheckPartyDistance"/>
    /// </summary>
    public TBuilder SetCheckPartyDistance(bool checkPartyDistance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckPartyDistance = checkPartyDistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LocatorsConsideration.MinPartyDistanceToLocator"/>
    /// </summary>
    ///
    /// <param name="minPartyDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from all party members by at least MinPartyDistanceToLocator meters (0 or less means no limit)
    /// </para>
    /// </param>
    public TBuilder SetMinPartyDistanceToLocator(float minPartyDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinPartyDistanceToLocator = minPartyDistanceToLocator;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LocatorsConsideration.MaxPartyDistanceToLocator"/>
    /// </summary>
    ///
    /// <param name="maxPartyDistanceToLocator">
    /// <para>
    /// InfoBox: Selects target point from locators which is distant from at least one party member less than MaxPartyDistanceToLocator meters (0 or less means no limit)
    /// </para>
    /// </param>
    public TBuilder SetMaxPartyDistanceToLocator(float maxPartyDistanceToLocator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxPartyDistanceToLocator = maxPartyDistanceToLocator;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Locators is null)
      {
        Blueprint.Locators = new EntityReference[0];
      }
    }
  }
}
