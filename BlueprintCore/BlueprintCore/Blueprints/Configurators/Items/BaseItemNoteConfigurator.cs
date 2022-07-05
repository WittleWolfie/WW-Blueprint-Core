//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemNote"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemNoteConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintItemNote
    where TBuilder : BaseItemNoteConfigurator<T, TBuilder>
  {
    protected BaseItemNoteConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
