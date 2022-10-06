//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMapEdge"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMapEdgeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMapEdge
    where TBuilder : BaseGlobalMapEdgeConfigurator<T, TBuilder>
  {
    protected BaseGlobalMapEdgeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintGlobalMapEdge>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Type = copyFrom.Type;
          bp.Priority = copyFrom.Priority;
          bp.m_Point1 = copyFrom.m_Point1;
          bp.m_Point2 = copyFrom.m_Point2;
          bp.LockCondition = copyFrom.LockCondition;
          bp.Length = copyFrom.Length;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintGlobalMapEdge>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Type = copyFrom.Type;
          bp.Priority = copyFrom.Priority;
          bp.m_Point1 = copyFrom.m_Point1;
          bp.m_Point2 = copyFrom.m_Point2;
          bp.LockCondition = copyFrom.LockCondition;
          bp.Length = copyFrom.Length;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapEdge.Type"/>
    /// </summary>
    public TBuilder SetType(GlobalMapEdgeType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapEdge.Priority"/>
    /// </summary>
    public TBuilder SetPriority(GlobalMapEdgePriority priority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Priority = priority;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapEdge.m_Point1"/>
    /// </summary>
    ///
    /// <param name="point1">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPoint1(Blueprint<BlueprintGlobalMapPoint.Reference> point1)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Point1 = point1?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapEdge.m_Point1"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPoint1(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Point1 is null) { return; }
          action.Invoke(bp.m_Point1);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapEdge.m_Point2"/>
    /// </summary>
    ///
    /// <param name="point2">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPoint2(Blueprint<BlueprintGlobalMapPoint.Reference> point2)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Point2 = point2?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapEdge.m_Point2"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPoint2(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Point2 is null) { return; }
          action.Invoke(bp.m_Point2);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapEdge.LockCondition"/>
    /// </summary>
    public TBuilder SetLockCondition(ConditionsBuilder lockCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LockCondition = lockCondition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGlobalMapEdge.LockCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LockCondition is null) { return; }
          action.Invoke(bp.LockCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintGlobalMapEdge.Length"/>
    /// </summary>
    public TBuilder SetLength(float length)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Length = length;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Point1 is null)
      {
        Blueprint.m_Point1 = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (Blueprint.m_Point2 is null)
      {
        Blueprint.m_Point2 = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      if (Blueprint.LockCondition is null)
      {
        Blueprint.LockCondition = Utils.Constants.Empty.Conditions;
      }
    }
  }
}
