//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatAiCastSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatAiCastSpellConfigurator<T, TBuilder>
    : BaseTacticalCombatAiActionConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatAiCastSpell
    where TBuilder : BaseTacticalCombatAiCastSpellConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatAiCastSpellConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatAiCastSpell.m_Ability"/>
    /// </summary>
    ///
    /// <param name="ability">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAbility(Blueprint<BlueprintAbilityReference> ability)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Ability = ability?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatAiCastSpell.m_Ability"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAbility(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Ability is null) { return; }
          action.Invoke(bp.m_Ability);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetSelf"/>
    /// </summary>
    public TBuilder SetForceTargetSelf(bool forceTargetSelf = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForceTargetSelf = forceTargetSelf;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetSelf"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForceTargetSelf(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ForceTargetSelf);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetEnemy"/>
    /// </summary>
    public TBuilder SetForceTargetEnemy(bool forceTargetEnemy = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForceTargetEnemy = forceTargetEnemy;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetEnemy"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForceTargetEnemy(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ForceTargetEnemy);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_Ability is null)
      {
        Blueprint.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
    }
  }
}
