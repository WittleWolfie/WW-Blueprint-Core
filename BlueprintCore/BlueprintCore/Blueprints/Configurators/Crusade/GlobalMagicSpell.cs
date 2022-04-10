using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Crusade
{
  /// <summary>
  /// Configurator for <see cref="BlueprintGlobalMagicSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class GlobalMagicSpellConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMagicSpell, GlobalMagicSpellConfigurator>
  {
    private GlobalMagicSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMagicSpellConfigurator For(string name)
    {
      return new GlobalMagicSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMagicSpellConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintGlobalMagicSpell>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_SpellName"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetSpellName(LocalizedString? spellName)
    {
      ValidateParam(spellName);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellName = spellName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_Description"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_Icon"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_VFX"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetVFX(PrefabLink? vFX)
    {
      ValidateParam(vFX);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_VFX = vFX ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_HoursCooldown"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetHoursCooldown(GlobalMagicValue hoursCooldown)
    {
      ValidateParam(hoursCooldown);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_HoursCooldown = hoursCooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_Executor"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetExecutor(BlueprintGlobalMagicSpell.ExecutorGlobalMagicSpell executor)
    {
      ValidateParam(executor);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Executor = executor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_SpellActions"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetSpellActions(ActionsBuilder? spellActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellActions = spellActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_SetCooldownManually"/> (Auto Generated)
    /// </summary>
    
    public GlobalMagicSpellConfigurator SetCooldownManually(bool setCooldownManually)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SetCooldownManually = setCooldownManually;
          });
    }
  }
}
