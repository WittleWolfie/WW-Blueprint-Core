using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Consideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(Consideration))]
  public abstract class BaseConsiderationConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : Consideration
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseConsiderationConfigurator(string name) : base(name) { }
  }
}
