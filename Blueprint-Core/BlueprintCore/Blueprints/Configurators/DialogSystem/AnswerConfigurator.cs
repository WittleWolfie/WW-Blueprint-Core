using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintAnswer"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAnswer))]
  public class AnswerConfigurator : BaseAnswerBaseConfigurator<BlueprintAnswer, AnswerConfigurator>
  {
     private AnswerConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AnswerConfigurator For(string name)
    {
      return new AnswerConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AnswerConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAnswer>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AnswerConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAnswer>(name, assetId);
      return For(name);
    }

  }
}
