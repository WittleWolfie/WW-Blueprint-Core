//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonIslandRewardUnit"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonIslandRewardUnitConfigurator<T, TBuilder>
    : BaseDungeonIslandRewardConfigurator<T, TBuilder>
    where T : BlueprintDungeonIslandRewardUnit
    where TBuilder : BaseDungeonIslandRewardUnitConfigurator<T, TBuilder>
  {
    protected BaseDungeonIslandRewardUnitConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardUnit.m_Blueprint"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBlueprint(Blueprint<BlueprintUnitReference> blueprint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Blueprint = blueprint?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandRewardUnit.m_Blueprint"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBlueprint(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Blueprint is null) { return; }
          action.Invoke(bp.m_Blueprint);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Blueprint is null)
      {
        Blueprint.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
    }
  }
}
