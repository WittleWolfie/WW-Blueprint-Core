//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmorType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmorTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmorType
    where TBuilder : BaseArmorTypeConfigurator<T, TBuilder>
  {
    protected BaseArmorTypeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
