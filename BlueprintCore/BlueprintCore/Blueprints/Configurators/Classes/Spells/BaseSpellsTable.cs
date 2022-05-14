//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpellsTable"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellsTableConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpellsTable
    where TBuilder : BaseSpellsTableConfigurator<T, TBuilder>
  {
    protected BaseSpellsTableConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
