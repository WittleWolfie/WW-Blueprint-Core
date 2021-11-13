using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Armors;
namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmorType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorType))]
  public abstract class BaseArmorTypeConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintArmorType
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseArmorTypeConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="BlueprintArmorType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorType))]
  public class ArmorTypeConfigurator : BaseBlueprintConfigurator<BlueprintArmorType, ArmorTypeConfigurator>
  {
     private ArmorTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorTypeConfigurator For(string name)
    {
      return new ArmorTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmorTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmorType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmorType>(name, assetId);
      return For(name);
    }

  }
}
