//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Crusade.GlobalMagic;

namespace BlueprintCore.Blueprints.Configurators.Crusade
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintGlobalMagicSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGlobalMagicSpellConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintGlobalMagicSpell
    where TBuilder : BaseGlobalMagicSpellConfigurator<T, TBuilder>
  {
    protected BaseGlobalMagicSpellConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
