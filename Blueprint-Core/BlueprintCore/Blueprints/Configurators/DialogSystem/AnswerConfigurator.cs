using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
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

    /// <summary>
    /// Adds <see cref="ActingCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Companion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ActingCompanion))]
    public AnswerConfigurator AddActingCompanion(
        string m_Companion)
    {
      
      var component =  new ActingCompanion();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(m_Companion);
      return AddComponent(component);
    }
  }
}
