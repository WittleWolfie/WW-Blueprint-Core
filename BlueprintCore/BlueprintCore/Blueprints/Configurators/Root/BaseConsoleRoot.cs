//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ConsoleRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseConsoleRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : ConsoleRoot
    where TBuilder : BaseConsoleRootConfigurator<T, TBuilder>
  {
    protected BaseConsoleRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
