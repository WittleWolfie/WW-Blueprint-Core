//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiRoam"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAiRoamConfigurator<T, TBuilder>
    : BaseAiActionConfigurator<T, TBuilder>
    where T : BlueprintAiRoam
    where TBuilder : BaseAiRoamConfigurator<T, TBuilder>
  {
    protected BaseAiRoamConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiRoam.TargetType"/>
    /// </summary>
    public TBuilder SetTargetType(Kingmaker.AI.Blueprints.TargetType targetType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TargetType = targetType;
        });
    }
  }
}
