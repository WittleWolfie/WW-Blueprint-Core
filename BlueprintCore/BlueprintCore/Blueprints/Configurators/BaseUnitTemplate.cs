//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitTemplate"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitTemplateConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitTemplate
    where TBuilder : BaseUnitTemplateConfigurator<T, TBuilder>
  {
    protected BaseUnitTemplateConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
