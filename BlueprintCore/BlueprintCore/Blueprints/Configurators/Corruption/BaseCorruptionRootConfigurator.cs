//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;
using System;

namespace BlueprintCore.Blueprints.Configurators.Corruption
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCorruptionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCorruptionRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCorruptionRoot
    where TBuilder : BaseCorruptionRootConfigurator<T, TBuilder>
  {
    protected BaseCorruptionRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCorruptionRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Progression = copyFrom.m_Progression;
          bp.m_DefaultCorruptionGrowth = copyFrom.m_DefaultCorruptionGrowth;
          bp.m_DSSuccessCoefficient = copyFrom.m_DSSuccessCoefficient;
          bp.m_DSCriticalFailCoefficient = copyFrom.m_DSCriticalFailCoefficient;
          bp.m_GlobalMapBuff = copyFrom.m_GlobalMapBuff;
          bp.m_GlobalMapBuffDurationMinutes = copyFrom.m_GlobalMapBuffDurationMinutes;
          bp.m_SpeedModifierDC = copyFrom.m_SpeedModifierDC;
          bp.m_SpeedModifierDCIncrement = copyFrom.m_SpeedModifierDCIncrement;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCorruptionRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Progression = copyFrom.m_Progression;
          bp.m_DefaultCorruptionGrowth = copyFrom.m_DefaultCorruptionGrowth;
          bp.m_DSSuccessCoefficient = copyFrom.m_DSSuccessCoefficient;
          bp.m_DSCriticalFailCoefficient = copyFrom.m_DSCriticalFailCoefficient;
          bp.m_GlobalMapBuff = copyFrom.m_GlobalMapBuff;
          bp.m_GlobalMapBuffDurationMinutes = copyFrom.m_GlobalMapBuffDurationMinutes;
          bp.m_SpeedModifierDC = copyFrom.m_SpeedModifierDC;
          bp.m_SpeedModifierDCIncrement = copyFrom.m_SpeedModifierDCIncrement;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_Progression"/>
    /// </summary>
    public TBuilder SetProgression(CorruptionProgression progression)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(progression);
          bp.m_Progression = progression;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCorruptionRoot.m_Progression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProgression(Action<CorruptionProgression> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Progression is null) { return; }
          action.Invoke(bp.m_Progression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_DefaultCorruptionGrowth"/>
    /// </summary>
    ///
    /// <param name="defaultCorruptionGrowth">
    /// <para>
    /// InfoBox: Amount of corruption player gets after Rest
    /// </para>
    /// </param>
    public TBuilder SetDefaultCorruptionGrowth(int defaultCorruptionGrowth)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultCorruptionGrowth = defaultCorruptionGrowth;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_DSSuccessCoefficient"/>
    /// </summary>
    ///
    /// <param name="dSSuccessCoefficient">
    /// <para>
    /// InfoBox: Reduce corruption added on rest with success divine service check
    /// </para>
    /// </param>
    public TBuilder SetDSSuccessCoefficient(float dSSuccessCoefficient)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DSSuccessCoefficient = dSSuccessCoefficient;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_DSCriticalFailCoefficient"/>
    /// </summary>
    ///
    /// <param name="dSCriticalFailCoefficient">
    /// <para>
    /// InfoBox: Enlarge corruption added on rest with critical fail divine service check
    /// </para>
    /// </param>
    public TBuilder SetDSCriticalFailCoefficient(float dSCriticalFailCoefficient)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DSCriticalFailCoefficient = dSCriticalFailCoefficient;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_GlobalMapBuff"/>
    /// </summary>
    ///
    /// <param name="globalMapBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalMapBuff(Blueprint<BlueprintBuffReference> globalMapBuff)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalMapBuff = globalMapBuff?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCorruptionRoot.m_GlobalMapBuff"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGlobalMapBuff(Action<BlueprintBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalMapBuff is null) { return; }
          action.Invoke(bp.m_GlobalMapBuff);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_GlobalMapBuffDurationMinutes"/>
    /// </summary>
    public TBuilder SetGlobalMapBuffDurationMinutes(int globalMapBuffDurationMinutes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalMapBuffDurationMinutes = globalMapBuffDurationMinutes;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_SpeedModifierDC"/>
    /// </summary>
    ///
    /// <param name="speedModifierDC">
    /// <para>
    /// InfoBox: Divine Servant should roll (Zone.NormalMinCR + SpeedModifierDC + Increment * `checks count`) or more to prolong buff
    /// </para>
    /// </param>
    public TBuilder SetSpeedModifierDC(int speedModifierDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpeedModifierDC = speedModifierDC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCorruptionRoot.m_SpeedModifierDCIncrement"/>
    /// </summary>
    public TBuilder SetSpeedModifierDCIncrement(int speedModifierDCIncrement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpeedModifierDCIncrement = speedModifierDCIncrement;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_GlobalMapBuff is null)
      {
        Blueprint.m_GlobalMapBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
    }
  }
}
