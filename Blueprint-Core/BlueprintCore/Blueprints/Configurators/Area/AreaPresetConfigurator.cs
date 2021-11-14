using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPreset))]
  public abstract class BaseAreaPresetConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAreaPreset
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaPresetConfigurator(string name) : base(name) { }
  }

  /// <summary>Configurator for <see cref="BlueprintAreaPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPreset))]
  public class AreaPresetConfigurator : BaseBlueprintConfigurator<BlueprintAreaPreset, AreaPresetConfigurator>
  {
     private AreaPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaPresetConfigurator For(string name)
    {
      return new AreaPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaPreset>(name, assetId);
      return For(name);
    }
  }
}
