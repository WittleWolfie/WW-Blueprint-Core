//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root.Fx;
using System;

namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CastsGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCastsGroupConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : CastsGroup
    where TBuilder : BaseCastsGroupConfigurator<T, TBuilder>
  {
    protected BaseCastsGroupConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CastsGroup>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ArcaneCasts = copyFrom.m_ArcaneCasts;
          bp.m_DivineCasts = copyFrom.m_DivineCasts;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CastsGroup.m_ArcaneCasts"/>
    /// </summary>
    public TBuilder SetArcaneCasts(CastGroupForSpellSource arcaneCasts)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(arcaneCasts);
          bp.m_ArcaneCasts = arcaneCasts;
        });
    }

    /// <summary>
    /// Modifies <see cref="CastsGroup.m_ArcaneCasts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArcaneCasts(Action<CastGroupForSpellSource> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArcaneCasts is null) { return; }
          action.Invoke(bp.m_ArcaneCasts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CastsGroup.m_DivineCasts"/>
    /// </summary>
    public TBuilder SetDivineCasts(CastGroupForSpellSource divineCasts)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(divineCasts);
          bp.m_DivineCasts = divineCasts;
        });
    }

    /// <summary>
    /// Modifies <see cref="CastsGroup.m_DivineCasts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDivineCasts(Action<CastGroupForSpellSource> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DivineCasts is null) { return; }
          action.Invoke(bp.m_DivineCasts);
        });
    }
  }
}
