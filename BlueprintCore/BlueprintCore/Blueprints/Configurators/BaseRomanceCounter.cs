//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRomanceCounter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRomanceCounterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRomanceCounter
    where TBuilder : BaseRomanceCounterConfigurator<T, TBuilder>
  {
    protected BaseRomanceCounterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRomanceCounter.m_CounterFlag"/>
    /// </summary>
    ///
    /// <param name="counterFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCounterFlag(Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference> counterFlag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CounterFlag = counterFlag?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRomanceCounter.m_CounterFlag"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="counterFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCounterFlag(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CounterFlag is null) { return; }
          action.Invoke(bp.m_CounterFlag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRomanceCounter.m_MinValueFlag"/>
    /// </summary>
    ///
    /// <param name="minValueFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMinValueFlag(Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference> minValueFlag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MinValueFlag = minValueFlag?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRomanceCounter.m_MinValueFlag"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="minValueFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyMinValueFlag(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MinValueFlag is null) { return; }
          action.Invoke(bp.m_MinValueFlag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRomanceCounter.m_MaxValueFlag"/>
    /// </summary>
    ///
    /// <param name="maxValueFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMaxValueFlag(Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference> maxValueFlag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxValueFlag = maxValueFlag?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRomanceCounter.m_MaxValueFlag"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="maxValueFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyMaxValueFlag(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MaxValueFlag is null) { return; }
          action.Invoke(bp.m_MaxValueFlag);
        });
    }
  }
}
