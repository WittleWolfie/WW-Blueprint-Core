using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;

namespace BlueprintCoreGen.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFact"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFact))]
  public abstract class BaseFactConfigurator<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintFact
      where TBuilder : BaseFactConfigurator<T, TBuilder>
  {
    protected BaseFactConfigurator(string name) : base(name) { }

    // [GenerateComponents]
  }
}
