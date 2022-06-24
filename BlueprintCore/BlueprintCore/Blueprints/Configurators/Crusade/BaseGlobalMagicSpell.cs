//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Crusade
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMagicSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMagicSpellConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMagicSpell
    where TBuilder : BaseGlobalMagicSpellConfigurator<T, TBuilder>
  {
    protected BaseGlobalMagicSpellConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_SpellName"/>
    /// </summary>
    ///
    /// <param name="spellName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetSpellName(LocalString spellName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellName = spellName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_SpellName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellName is null) { return; }
          action.Invoke(bp.m_SpellName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_Description"/>
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
          bp.m_Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Description is null) { return; }
          action.Invoke(bp.m_Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(icon);
          bp.m_Icon = icon;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Icon is null) { return; }
          action.Invoke(bp.m_Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_VFX"/>
    /// </summary>
    public TBuilder SetVFX(PrefabLink vFX)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_VFX = vFX;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_VFX"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVFX(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VFX is null) { return; }
          action.Invoke(bp.m_VFX);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_HoursCooldown"/>
    /// </summary>
    public TBuilder SetHoursCooldown(GlobalMagicValue hoursCooldown)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(hoursCooldown);
          bp.m_HoursCooldown = hoursCooldown;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_HoursCooldown"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHoursCooldown(Action<GlobalMagicValue> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HoursCooldown is null) { return; }
          action.Invoke(bp.m_HoursCooldown);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_Executor"/>
    /// </summary>
    public TBuilder SetExecutor(BlueprintGlobalMagicSpell.ExecutorGlobalMagicSpell executor)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(executor);
          bp.m_Executor = executor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_Executor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExecutor(Action<BlueprintGlobalMagicSpell.ExecutorGlobalMagicSpell> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Executor is null) { return; }
          action.Invoke(bp.m_Executor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_SpellActions"/>
    /// </summary>
    public TBuilder SetSpellActions(ActionsBuilder spellActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellActions = spellActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_SpellActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellActions is null) { return; }
          action.Invoke(bp.m_SpellActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMagicSpell.m_SetCooldownManually"/>
    /// </summary>
    ///
    /// <param name="setCooldownManually">
    /// <para>
    /// InfoBox: Turn on if you set cooldown for this spell manually. And default cooldown set logic shouldn&amp;apos;t be run
    /// </para>
    /// </param>
    public TBuilder SetSetCooldownManually(bool setCooldownManually = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SetCooldownManually = setCooldownManually;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMagicSpell.m_SetCooldownManually"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySetCooldownManually(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_SetCooldownManually);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_SpellName is null)
      {
        Blueprint.m_SpellName = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Description is null)
      {
        Blueprint.m_Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_VFX is null)
      {
        Blueprint.m_VFX = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_SpellActions is null)
      {
        Blueprint.m_SpellActions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
