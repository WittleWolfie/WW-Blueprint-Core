using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Crusade.GlobalMagic
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMagicSpell"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMagicSpell))]
  public class GlobalMagicSpellConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMagicSpell, GlobalMagicSpellConfigurator>
  {
     private GlobalMagicSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMagicSpellConfigurator For(string name)
    {
      return new GlobalMagicSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMagicSpellConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMagicSpell>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMagicSpellConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMagicSpell>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_SpellName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetSpellName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_SpellName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Icon = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_VFX"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetVFX(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_VFX = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_HoursCooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetHoursCooldown(GlobalMagicValue value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_HoursCooldown = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_Executor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetExecutor(BlueprintGlobalMagicSpell.ExecutorGlobalMagicSpell value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Executor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_SpellActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetSpellActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.m_SpellActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMagicSpell.m_SetCooldownManually"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMagicSpellConfigurator SetSetCooldownManually(bool value)
    {
      return OnConfigureInternal(bp => bp.m_SetCooldownManually = value);
    }
  }
}
