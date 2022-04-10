using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators.Facts;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.Blueprints.Configurators.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAbility"/>.</summary>
  /// <inheritdoc/>
  
  public class AbilityConfigurator : BaseUnitFactConfigurator<BlueprintAbility, AbilityConfigurator>
  {
    private AbilityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AbilityConfigurator For(string name) { return new AbilityConfigurator(name); }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AbilityConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbility>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_DefaultAiAction"/>
    /// </summary>
    /// 
    /// <param name="aiAction">
    /// <see cref="BlueprintAiCastSpell"/> Has its <see cref="BlueprintAiCastSpell.m_Ability"/> updated to this blueprint.
    /// </param>
    public AbilityConfigurator SetAiAction(string aiAction)
    {
      OnConfigureInternal(
          blueprint =>
          {
            var aiBlueprint = BlueprintTool.Get<BlueprintAiCastSpell>(aiAction);
            aiBlueprint.m_Ability = Blueprint.ToReference<BlueprintAbilityReference>();
            blueprint.m_DefaultAiAction = aiBlueprint.ToReference<BlueprintAiCastSpell.Reference>();
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Type"/>
    /// </summary>
    public AbilityConfigurator SetType(AbilityType type)
    {
      OnConfigureInternal(blueprint => blueprint.Type = type);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Range"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetCustomRange(int)"/> for <see cref="AbilityRange.Custom"/>.</remarks>
    public AbilityConfigurator SetRange(AbilityRange range)
    {
      if (range == AbilityRange.Custom)
      {
        throw new InvalidOperationException("Use SetCustomRange() for AbilityRange.Custom.");
      }
      OnConfigureInternal(blueprint => blueprint.Range = range);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Range"/> and <see cref="BlueprintAbility.CustomRange"/>
    /// </summary>
    public AbilityConfigurator SetCustomRange(int rangeInFeet)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.Range = AbilityRange.Custom;
            blueprint.CustomRange = new Feet(rangeInFeet);
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ShowNameForVariant"/> and <see cref="BlueprintAbility.OnlyForAllyCaster"/>
    /// </summary>
    public AbilityConfigurator ShowNameForVariant(bool showName = true, bool onlyForAlly = false)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.ShowNameForVariant = showName;
            blueprint.OnlyForAllyCaster = onlyForAlly;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.CanTargetPoint"/>, <see cref="BlueprintAbility.CanTargetEnemies"/>,
    /// <see cref="BlueprintAbility.CanTargetFriends"/>, and <see cref="BlueprintAbility.CanTargetSelf"/>
    /// </summary>
    public AbilityConfigurator AllowTargeting(
        bool? point = null, bool? enemies = null, bool? friends = null, bool? self = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.CanTargetPoint = point ?? blueprint.CanTargetPoint;
            blueprint.CanTargetEnemies = enemies ?? blueprint.CanTargetEnemies;
            blueprint.CanTargetFriends = friends ?? blueprint.CanTargetFriends;
            blueprint.CanTargetSelf = self ?? blueprint.CanTargetSelf;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.SpellResistance"/>
    /// </summary>
    public AbilityConfigurator ApplySpellResistance(bool applySR = true)
    {
      OnConfigureInternal(blueprint => blueprint.SpellResistance = applySR);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ActionBarAutoFillIgnored"/>
    /// </summary>
    public AbilityConfigurator AutoFillActionBar(bool autoFill = true)
    {
      OnConfigureInternal(blueprint => blueprint.ActionBarAutoFillIgnored = !autoFill);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Hidden"/>
    /// </summary>
    public AbilityConfigurator HideInUi(bool hide = true)
    {
      OnConfigureInternal(blueprint => blueprint.Hidden = hide);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.NeedEquipWeapons"/>
    /// </summary>
    public AbilityConfigurator RequireWeapon(bool requireWeapon = true)
    {
      OnConfigureInternal(blueprint => blueprint.NeedEquipWeapons = requireWeapon);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.NotOffensive"/>
    /// </summary>
    public AbilityConfigurator IsOffensive(bool offensive = true)
    {
      OnConfigureInternal(blueprint => blueprint.NotOffensive = !offensive);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.EffectOnAlly"/> and <see cref="BlueprintAbility.EffectOnEnemy"/>
    /// </summary>
    public AbilityConfigurator SetEffectOn(
        AbilityEffectOnUnit? onAlly = null, AbilityEffectOnUnit? onEnemy = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.EffectOnAlly = onAlly ?? blueprint.EffectOnAlly;
            blueprint.EffectOnEnemy = onEnemy ?? blueprint.EffectOnEnemy;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// 
    /// <param name="name"><see cref="BlueprintAbility"/> Has this blueprint added as a variant.</param>
    public AbilityConfigurator SetParent(string name)
    {
      OnConfigureInternal(blueprint => SetParent(BlueprintTool.Get<BlueprintAbility>(name)));
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// 
    /// <remarks>The parent will be updated to remove this blueprint as a variant.</remarks>
    public AbilityConfigurator ClearParent()
    {
      OnConfigureInternal(blueprint => RemoveParent());
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Animation"/>
    /// </summary>
    public AbilityConfigurator SetAnimationStyle(UnitAnimationActionCastSpell.CastAnimationStyle style)
    {
      OnConfigureInternal(blueprint => blueprint.Animation = style);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ActionType"/> and <see cref="BlueprintAbility.HasFastAnimation"/>
    /// </summary>
    public AbilityConfigurator SetActionType(UnitCommand.CommandType type, bool? hasFastAnimation = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.ActionType = type;
            blueprint.HasFastAnimation = hasFastAnimation ?? blueprint.HasFastAnimation;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator SetMetamagics(params Metamagic[] metamagics)
    {
      Metamagic availableMetamagic = 0;
      metamagics.ForEach(m => availableMetamagic |= m);
      return OnConfigureInternal(bp => bp.AvailableMetamagic = availableMetamagic);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator AddToMetamagics(params Metamagic[] metamagics)
    {
      return OnConfigureInternal(bp => metamagics.ForEach(m => bp.AvailableMetamagic |= m));
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator RemoveFromMetamagics(params Metamagic[] metamagics)
    {
      return OnConfigureInternal(bp => metamagics.ForEach(m => bp.AvailableMetamagic &= ~m));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_IsFullRoundAction"/>
    /// </summary>
    public AbilityConfigurator MakeFullRound(bool fullRound = true)
    {
      OnConfigureInternal(blueprint => blueprint.m_IsFullRoundAction = fullRound);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.LocalizedDuration"/>
    /// </summary>
    public AbilityConfigurator SetDurationText(LocalizedString duration)
    {
      OnConfigureInternal(blueprint => blueprint.LocalizedDuration = duration);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.LocalizedSavingThrow"/>
    /// </summary>
    public AbilityConfigurator SetSavingThrowText(LocalizedString savingThrow)
    {
      OnConfigureInternal(blueprint => blueprint.LocalizedSavingThrow = savingThrow);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.MaterialComponent"/>
    /// </summary>
    public AbilityConfigurator SetMaterialComponent(BlueprintAbility.MaterialComponentData component)
    {
      OnConfigureInternal(blueprint => blueprint.MaterialComponent = component);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.DisableLog"/>
    /// </summary>
    public AbilityConfigurator HideFromLog(bool hide = true)
    {
      OnConfigureInternal(blueprint => blueprint.DisableLog = hide);
      return this;
    }

    // [GenerateComponents]

    private void SetParent(BlueprintAbility parent)
    {
      Blueprint.Parent = parent;

      var parentVariants = parent.GetComponent<AbilityVariants>();
      var abilityRef = Blueprint.ToReference<BlueprintAbilityReference>();
      if (parentVariants != null)
      {
        parentVariants.m_Variants = CommonTool.Append(parentVariants.m_Variants, abilityRef);
        return;
      }

      parentVariants = new();
      parentVariants.m_Variants = new BlueprintAbilityReference[] { abilityRef };
      parent.AddComponents(parentVariants);
    }

    private void RemoveParent()
    {
      var parentVariants = Blueprint.Parent?.GetComponent<AbilityVariants>();
      Blueprint.Parent = null;
      if (parentVariants == null)
      {
        AddValidationWarning($"Tried to remove an invalid parent.");
        return;
      }
      parentVariants.m_Variants =
          parentVariants.m_Variants
              .ToList()
              .FindAll(ability => ability != Blueprint.ToReference<BlueprintAbilityReference>())
              .ToArray();
    }
  }
}