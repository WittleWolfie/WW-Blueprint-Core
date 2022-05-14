//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UI;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseUISoundConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUISound.Sounds"/>
    /// </summary>
    public TBuilder SetSounds(List<BlueprintUISound.UISound> sounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in sounds) { Validate(item); }
          bp.Sounds = sounds;
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
          bp.Sounds = bp.Sounds.Where(predicate).ToList();
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
    public TBuilder SetArmyManagement(List<BlueprintUISound.UISound> armyManagement)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in armyManagement) { Validate(item); }
          bp.ArmyManagement = armyManagement;
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
          bp.ArmyManagement = bp.ArmyManagement.Where(predicate).ToList();
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
    public TBuilder SetTooltip(List<BlueprintUISound.UISound> tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in tooltip) { Validate(item); }
          bp.Tooltip = tooltip;
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
          bp.Tooltip = bp.Tooltip.Where(predicate).ToList();
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
  }
}
