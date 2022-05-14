//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Visual.CharacterSystem;

namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="KingmakerEquipmentEntity"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingmakerEquipmentEntityConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : KingmakerEquipmentEntity
    where TBuilder : BaseKingmakerEquipmentEntityConfigurator<T, TBuilder>
  {
    protected BaseKingmakerEquipmentEntityConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
