//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Enums;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswerBase"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAnswerBaseConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAnswerBase
    where TBuilder : BaseAnswerBaseConfigurator<T, TBuilder>
  {
    protected BaseAnswerBaseConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswerBase.MythicRequirement"/>
    /// </summary>
    public TBuilder SetMythicRequirement(Mythic mythicRequirement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MythicRequirement = mythicRequirement;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswerBase.AlignmentRequirement"/>
    /// </summary>
    public TBuilder SetAlignmentRequirement(AlignmentComponent alignmentRequirement)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlignmentRequirement = alignmentRequirement;
        });
    }
  }
}
