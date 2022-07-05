//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;
using Kingmaker.ResourceLinks;
using System;

namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFootprint"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFootprintConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFootprint
    where TBuilder : BaseFootprintConfigurator<T, TBuilder>
  {
    protected BaseFootprintConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFootprint.LeftFootPrint"/>
    /// </summary>
    public TBuilder SetLeftFootPrint(PrefabLink leftFootPrint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeftFootPrint = leftFootPrint;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFootprint.LeftFootPrint"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeftFootPrint(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeftFootPrint is null) { return; }
          action.Invoke(bp.LeftFootPrint);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFootprint.RightFootPrint"/>
    /// </summary>
    public TBuilder SetRightFootPrint(PrefabLink rightFootPrint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RightFootPrint = rightFootPrint;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFootprint.RightFootPrint"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRightFootPrint(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RightFootPrint is null) { return; }
          action.Invoke(bp.RightFootPrint);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.LeftFootPrint is null)
      {
        Blueprint.LeftFootPrint = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.RightFootPrint is null)
      {
        Blueprint.RightFootPrint = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
