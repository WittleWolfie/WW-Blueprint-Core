//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFootprint>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.LeftFootPrint = copyFrom.LeftFootPrint;
          bp.RightFootPrint = copyFrom.RightFootPrint;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFootprint>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.LeftFootPrint = copyFrom.LeftFootPrint;
          bp.RightFootPrint = copyFrom.RightFootPrint;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFootprint.LeftFootPrint"/>
    /// </summary>
    ///
    /// <param name="leftFootPrint">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetLeftFootPrint(AssetLink<PrefabLink> leftFootPrint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeftFootPrint = leftFootPrint?.Get();
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
    ///
    /// <param name="rightFootPrint">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetRightFootPrint(AssetLink<PrefabLink> rightFootPrint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RightFootPrint = rightFootPrint?.Get();
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
