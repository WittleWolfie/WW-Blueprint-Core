using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Ecnchantments;
namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEnchantment))]
  public abstract class BaseItemEnchantmentConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintItemEnchantment
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEnchantmentConfigurator(string name) : base(name) { }

  }
}
