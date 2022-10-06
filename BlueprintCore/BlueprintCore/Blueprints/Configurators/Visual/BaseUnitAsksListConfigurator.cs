//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using Kingmaker.Visual.Sound;
using System;

namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitAsksList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitAsksListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitAsksList
    where TBuilder : BaseUnitAsksListConfigurator<T, TBuilder>
  {
    protected BaseUnitAsksListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitAsksList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DisplayName = copyFrom.DisplayName;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitAsksList>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DisplayName = copyFrom.DisplayName;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitAsksList.DisplayName"/>
    /// </summary>
    ///
    /// <param name="displayName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDisplayName(LocalString displayName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisplayName = displayName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitAsksList.DisplayName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisplayName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DisplayName is null) { return; }
          action.Invoke(bp.DisplayName);
        });
    }

    /// <summary>
    /// Adds <see cref="UnitAsksComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abrikandilu_Barks</term><description>97c7b7df236d38d4083756c6e71e038b</description></item>
    /// <item><term>Lilithu_Barks</term><description>08184ae01ef7a414da9edbd05a58144c</description></item>
    /// <item><term>Zombie_Barks</term><description>5b77c4c031391294b920f5a1e119b959</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddUnitAsksComponent(
        UnitAsksComponent.Bark? aggro = null,
        UnitAsksComponent.AnimationBark[]? animationBarks = null,
        UnitAsksComponent.Bark? checkFail = null,
        UnitAsksComponent.Bark? checkSuccess = null,
        UnitAsksComponent.Bark? criticalHit = null,
        UnitAsksComponent.Bark? currentlyActiveBark = null,
        UnitAsksComponent.Bark? death = null,
        UnitAsksComponent.Bark? discovery = null,
        UnitAsksComponent.Bark? fatigue = null,
        UnitAsksComponent.Bark? lowHealth = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        UnitAsksComponent.Bark? order = null,
        UnitAsksComponent.Bark? orderMove = null,
        UnitAsksComponent.Bark? pain = null,
        string? previewSound = null,
        UnitAsksComponent.Bark? refuseCast = null,
        UnitAsksComponent.Bark? refuseEquip = null,
        UnitAsksComponent.Bark? refuseUnequip = null,
        UnitAsksComponent.Bark? selected = null,
        string[]? soundBanks = null,
        UnitAsksComponent.Bark? stealth = null,
        UnitAsksComponent.Bark? stormRain = null,
        UnitAsksComponent.Bark? stormSnow = null,
        UnitAsksComponent.Bark? unconscious = null,
        UnitEntityData? unit = null)
    {
      var component = new UnitAsksComponent();
      Validate(aggro);
      component.Aggro = aggro ?? component.Aggro;
      Validate(animationBarks);
      component.AnimationBarks = animationBarks ?? component.AnimationBarks;
      if (component.AnimationBarks is null)
      {
        component.AnimationBarks = new UnitAsksComponent.AnimationBark[0];
      }
      Validate(checkFail);
      component.CheckFail = checkFail ?? component.CheckFail;
      Validate(checkSuccess);
      component.CheckSuccess = checkSuccess ?? component.CheckSuccess;
      Validate(criticalHit);
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      Validate(currentlyActiveBark);
      component.m_CurrentlyActiveBark = currentlyActiveBark ?? component.m_CurrentlyActiveBark;
      Validate(death);
      component.Death = death ?? component.Death;
      Validate(discovery);
      component.Discovery = discovery ?? component.Discovery;
      Validate(fatigue);
      component.Fatigue = fatigue ?? component.Fatigue;
      Validate(lowHealth);
      component.LowHealth = lowHealth ?? component.LowHealth;
      Validate(order);
      component.Order = order ?? component.Order;
      Validate(orderMove);
      component.OrderMove = orderMove ?? component.OrderMove;
      Validate(pain);
      component.Pain = pain ?? component.Pain;
      component.PreviewSound = previewSound ?? component.PreviewSound;
      Validate(refuseCast);
      component.RefuseCast = refuseCast ?? component.RefuseCast;
      Validate(refuseEquip);
      component.RefuseEquip = refuseEquip ?? component.RefuseEquip;
      Validate(refuseUnequip);
      component.RefuseUnequip = refuseUnequip ?? component.RefuseUnequip;
      Validate(selected);
      component.Selected = selected ?? component.Selected;
      component.SoundBanks = soundBanks ?? component.SoundBanks;
      if (component.SoundBanks is null)
      {
        component.SoundBanks = new string[0];
      }
      Validate(stealth);
      component.Stealth = stealth ?? component.Stealth;
      Validate(stormRain);
      component.StormRain = stormRain ?? component.StormRain;
      Validate(stormSnow);
      component.StormSnow = stormSnow ?? component.StormSnow;
      Validate(unconscious);
      component.Unconscious = unconscious ?? component.Unconscious;
      Validate(unit);
      component.m_Unit = unit ?? component.m_Unit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.DisplayName is null)
      {
        Blueprint.DisplayName = Utils.Constants.Empty.String;
      }
    }
  }
}
