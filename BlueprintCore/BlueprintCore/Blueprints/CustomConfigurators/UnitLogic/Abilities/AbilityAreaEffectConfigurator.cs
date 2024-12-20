﻿using BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAbilityAreaEffect"/>.
  /// </summary>
  /// <inheritdoc/>
  public class AbilityAreaEffectConfigurator
    : BaseAbilityAreaEffectConfigurator<BlueprintAbilityAreaEffect, AbilityAreaEffectConfigurator>
  {
    private AbilityAreaEffectConfigurator(Blueprint<BlueprintReference<BlueprintAbilityAreaEffect>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static AbilityAreaEffectConfigurator For(Blueprint<BlueprintReference<BlueprintAbilityAreaEffect>> blueprint)
    {
      return new AbilityAreaEffectConfigurator(blueprint);
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static AbilityAreaEffectConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbilityAreaEffect>(name, guid);
      return For(name);
    }

    /// <inheritdoc cref="BaseAbilityAreaEffectConfigurator{T, TBuilder}.SetSizeInCells(int)"/>
    /// 
    /// <remarks>
    /// Sets <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/> to true.
    /// </remarks>
    public new AbilityAreaEffectConfigurator SetSizeInCells(int sizeInCells)
    {
      base.SetSizeInCells(sizeInCells);
      return OnConfigureInternal(bp => bp.CanBeUsedInTacticalCombat = true);
    }
  }
}
