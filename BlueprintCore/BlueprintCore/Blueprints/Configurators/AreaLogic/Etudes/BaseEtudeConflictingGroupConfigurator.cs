//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Etudes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEtudeConflictingGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEtudeConflictingGroupConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintEtudeConflictingGroup
    where TBuilder : BaseEtudeConflictingGroupConfigurator<T, TBuilder>
  {
    protected BaseEtudeConflictingGroupConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEtudeConflictingGroup>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
