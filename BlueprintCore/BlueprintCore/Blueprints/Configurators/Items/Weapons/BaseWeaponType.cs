//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintWeaponType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseWeaponTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintWeaponType
    where TBuilder : BaseWeaponTypeConfigurator<T, TBuilder>
  {
    protected BaseWeaponTypeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
