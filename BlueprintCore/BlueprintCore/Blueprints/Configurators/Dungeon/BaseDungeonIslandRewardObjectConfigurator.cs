//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonIslandRewardObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonIslandRewardObjectConfigurator<T, TBuilder>
    : BaseDungeonIslandRewardConfigurator<T, TBuilder>
    where T : BlueprintDungeonIslandRewardObject
    where TBuilder : BaseDungeonIslandRewardObjectConfigurator<T, TBuilder>
  {
    protected BaseDungeonIslandRewardObjectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonIslandRewardObject>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Object = copyFrom.m_Object;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardObject.m_Object"/>
    /// </summary>
    ///
    /// <param name="objectValue">
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
    public TBuilder SetObjectValue(Blueprint<BlueprintDynamicMapObjectReference> objectValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Object = objectValue?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandRewardObject.m_Object"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyObjectValue(Action<BlueprintDynamicMapObjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Object is null) { return; }
          action.Invoke(bp.m_Object);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Object is null)
      {
        Blueprint.m_Object = BlueprintTool.GetRef<BlueprintDynamicMapObjectReference>(null);
      }
    }
  }
}
