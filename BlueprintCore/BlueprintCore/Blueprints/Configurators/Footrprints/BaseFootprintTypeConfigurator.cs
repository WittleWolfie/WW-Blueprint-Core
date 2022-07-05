//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Footrprints;
using Kingmaker.Enums;
using Kingmaker.Utility.EnumArrays;
using System;

namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFootprintType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFootprintTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFootprintType
    where TBuilder : BaseFootprintTypeConfigurator<T, TBuilder>
  {
    protected BaseFootprintTypeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFootprintType.FootprintType"/>
    /// </summary>
    public TBuilder SetFootprintType(FootprintType footprintType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintType = footprintType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFootprintType.Footprints"/>
    /// </summary>
    public TBuilder SetFootprints(FootprintsEnumArray footprints)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(footprints);
          bp.Footprints = footprints;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFootprintType.Footprints"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFootprints(Action<FootprintsEnumArray> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Footprints is null) { return; }
          action.Invoke(bp.Footprints);
        });
    }
  }
}
