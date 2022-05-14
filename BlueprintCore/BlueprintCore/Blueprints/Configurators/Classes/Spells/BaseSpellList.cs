//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpellList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpellList
    where TBuilder : BaseSpellListConfigurator<T, TBuilder>
  {
    protected BaseSpellListConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
