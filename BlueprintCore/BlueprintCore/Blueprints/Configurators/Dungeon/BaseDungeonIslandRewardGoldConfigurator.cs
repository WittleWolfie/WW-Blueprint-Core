//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonIslandRewardGold"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonIslandRewardGoldConfigurator<T, TBuilder>
    : BaseDungeonIslandRewardConfigurator<T, TBuilder>
    where T : BlueprintDungeonIslandRewardGold
    where TBuilder : BaseDungeonIslandRewardGoldConfigurator<T, TBuilder>
  {
    protected BaseDungeonIslandRewardGoldConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardGold.m_Container"/>
    /// </summary>
    ///
    /// <param name="container">
    /// <para>
    /// Blueprint of type BlueprintDynamicMapObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetContainer(Blueprint<BlueprintDynamicMapObjectReference> container)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Container = container?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandRewardGold.m_Container"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyContainer(Action<BlueprintDynamicMapObjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Container is null) { return; }
          action.Invoke(bp.m_Container);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardGold.Fixed"/>
    /// </summary>
    public TBuilder SetFixedValue(bool fixedValue = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Fixed = fixedValue;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardGold.m_Count"/>
    /// </summary>
    public TBuilder SetCount(int count)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Count = count;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Container is null)
      {
        Blueprint.m_Container = BlueprintTool.GetRef<BlueprintDynamicMapObjectReference>(null);
      }
    }
  }
}