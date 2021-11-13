using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;
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

  }
}
