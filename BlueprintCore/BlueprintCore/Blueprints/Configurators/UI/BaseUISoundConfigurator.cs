//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UI;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUISound"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUISoundConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUISound
    where TBuilder : BaseUISoundConfigurator<T, TBuilder>
  {
    protected BaseUISoundConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUISound>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Sounds = copyFrom.Sounds;
          bp.ArmyManagement = copyFrom.ArmyManagement;
          bp.Tooltip = copyFrom.Tooltip;
          bp.CardInterface = copyFrom.CardInterface;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUISound>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Sounds = copyFrom.Sounds;
          bp.ArmyManagement = copyFrom.ArmyManagement;
          bp.Tooltip = copyFrom.Tooltip;
          bp.CardInterface = copyFrom.CardInterface;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUISound.Sounds"/>
    /// </summary>
    public TBuilder SetSounds(params BlueprintUISound.UISound[] sounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(sounds);
          bp.Sounds = sounds.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUISound.Sounds"/>
    /// </summary>
    public TBuilder AddToSounds(params BlueprintUISound.UISound[] sounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Sounds = bp.Sounds ?? new();
          bp.Sounds.AddRange(sounds);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.Sounds"/>
    /// </summary>
    public TBuilder RemoveFromSounds(params BlueprintUISound.UISound[] sounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Sounds is null) { return; }
          bp.Sounds = bp.Sounds.Where(val => !sounds.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.Sounds"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSounds(Func<BlueprintUISound.UISound, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Sounds is null) { return; }
          bp.Sounds = bp.Sounds.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUISound.Sounds"/>
    /// </summary>
    public TBuilder ClearSounds()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Sounds = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.Sounds"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySounds(Action<BlueprintUISound.UISound> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Sounds is null) { return; }
          bp.Sounds.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUISound.ArmyManagement"/>
    /// </summary>
    public TBuilder SetArmyManagement(params BlueprintUISound.UISound[] armyManagement)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(armyManagement);
          bp.ArmyManagement = armyManagement.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUISound.ArmyManagement"/>
    /// </summary>
    public TBuilder AddToArmyManagement(params BlueprintUISound.UISound[] armyManagement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArmyManagement = bp.ArmyManagement ?? new();
          bp.ArmyManagement.AddRange(armyManagement);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.ArmyManagement"/>
    /// </summary>
    public TBuilder RemoveFromArmyManagement(params BlueprintUISound.UISound[] armyManagement)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArmyManagement is null) { return; }
          bp.ArmyManagement = bp.ArmyManagement.Where(val => !armyManagement.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.ArmyManagement"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArmyManagement(Func<BlueprintUISound.UISound, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArmyManagement is null) { return; }
          bp.ArmyManagement = bp.ArmyManagement.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUISound.ArmyManagement"/>
    /// </summary>
    public TBuilder ClearArmyManagement()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArmyManagement = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.ArmyManagement"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArmyManagement(Action<BlueprintUISound.UISound> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArmyManagement is null) { return; }
          bp.ArmyManagement.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUISound.Tooltip"/>
    /// </summary>
    public TBuilder SetTooltip(params BlueprintUISound.UISound[] tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(tooltip);
          bp.Tooltip = tooltip.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUISound.Tooltip"/>
    /// </summary>
    public TBuilder AddToTooltip(params BlueprintUISound.UISound[] tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Tooltip = bp.Tooltip ?? new();
          bp.Tooltip.AddRange(tooltip);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.Tooltip"/>
    /// </summary>
    public TBuilder RemoveFromTooltip(params BlueprintUISound.UISound[] tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Tooltip is null) { return; }
          bp.Tooltip = bp.Tooltip.Where(val => !tooltip.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.Tooltip"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTooltip(Func<BlueprintUISound.UISound, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Tooltip is null) { return; }
          bp.Tooltip = bp.Tooltip.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUISound.Tooltip"/>
    /// </summary>
    public TBuilder ClearTooltip()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Tooltip = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.Tooltip"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTooltip(Action<BlueprintUISound.UISound> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Tooltip is null) { return; }
          bp.Tooltip.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUISound.CardInterface"/>
    /// </summary>
    public TBuilder SetCardInterface(params BlueprintUISound.UISound[] cardInterface)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cardInterface);
          bp.CardInterface = cardInterface.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUISound.CardInterface"/>
    /// </summary>
    public TBuilder AddToCardInterface(params BlueprintUISound.UISound[] cardInterface)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CardInterface = bp.CardInterface ?? new();
          bp.CardInterface.AddRange(cardInterface);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.CardInterface"/>
    /// </summary>
    public TBuilder RemoveFromCardInterface(params BlueprintUISound.UISound[] cardInterface)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CardInterface is null) { return; }
          bp.CardInterface = bp.CardInterface.Where(val => !cardInterface.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUISound.CardInterface"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCardInterface(Func<BlueprintUISound.UISound, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CardInterface is null) { return; }
          bp.CardInterface = bp.CardInterface.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUISound.CardInterface"/>
    /// </summary>
    public TBuilder ClearCardInterface()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CardInterface = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.CardInterface"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCardInterface(Action<BlueprintUISound.UISound> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CardInterface is null) { return; }
          bp.CardInterface.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Sounds is null)
      {
        Blueprint.Sounds = new();
      }
      if (Blueprint.ArmyManagement is null)
      {
        Blueprint.ArmyManagement = new();
      }
      if (Blueprint.Tooltip is null)
      {
        Blueprint.Tooltip = new();
      }
      if (Blueprint.CardInterface is null)
      {
        Blueprint.CardInterface = new();
      }
    }
  }
}
