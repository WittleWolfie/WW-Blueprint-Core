//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatAiCastSpell>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Ability = copyFrom.m_Ability;
          bp.m_ForceTargetSelf = copyFrom.m_ForceTargetSelf;
          bp.m_ForceTargetEnemy = copyFrom.m_ForceTargetEnemy;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTacticalCombatAiCastSpell>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Ability = copyFrom.m_Ability;
          bp.m_ForceTargetSelf = copyFrom.m_ForceTargetSelf;
          bp.m_ForceTargetEnemy = copyFrom.m_ForceTargetEnemy;
        });
    }

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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Ability is null)
      {
        Blueprint.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
    }
  }
}
