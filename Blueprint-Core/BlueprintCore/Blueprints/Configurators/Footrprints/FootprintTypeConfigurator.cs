using BlueprintCore.Utils;
using Kingmaker.Blueprints.Footrprints;
using Kingmaker.Enums;
using Kingmaker.Utility.EnumArrays;

namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>Configurator for <see cref="BlueprintFootprintType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFootprintType))]
  public class FootprintTypeConfigurator : BaseBlueprintConfigurator<BlueprintFootprintType, FootprintTypeConfigurator>
  {
     private FootprintTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FootprintTypeConfigurator For(string name)
    {
      return new FootprintTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FootprintTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFootprintType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FootprintTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFootprintType>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFootprintType.FootprintType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FootprintTypeConfigurator SetFootprintType(FootprintType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FootprintType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFootprintType.Footprints"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FootprintTypeConfigurator SetFootprints(FootprintsEnumArray value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Footprints = value);
    }
  }
}
