//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Achievements
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AchievementData"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAchievementDataConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : AchievementData
    where TBuilder : BaseAchievementDataConfigurator<T, TBuilder>
  {
    protected BaseAchievementDataConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
