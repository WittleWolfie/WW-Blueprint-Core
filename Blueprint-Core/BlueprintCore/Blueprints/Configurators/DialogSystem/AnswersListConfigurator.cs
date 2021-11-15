using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintAnswersList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAnswersList))]
  public class AnswersListConfigurator : BaseAnswerBaseConfigurator<BlueprintAnswersList, AnswersListConfigurator>
  {
     private AnswersListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AnswersListConfigurator For(string name)
    {
      return new AnswersListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AnswersListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAnswersList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AnswersListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAnswersList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswersList.ShowOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswersListConfigurator SetShowOnce(bool value)
    {
      return OnConfigureInternal(bp => bp.ShowOnce = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswersList.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswersListConfigurator SetConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.Conditions = value.Build());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswersList.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public AnswersListConfigurator AddToAnswers(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Answers.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswersList.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public AnswersListConfigurator RemoveFromAnswers(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name));
            bp.Answers =
                bp.Answers
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }
  }
}
