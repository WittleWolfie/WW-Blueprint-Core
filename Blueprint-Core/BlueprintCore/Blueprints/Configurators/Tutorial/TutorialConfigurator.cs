using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Tutorial;
namespace BlueprintCore.Blueprints.Configurators.Tutorial
{
  /// <summary>Configurator for <see cref="BlueprintTutorial"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTutorial))]
  public class TutorialConfigurator : BaseFactConfigurator<BlueprintTutorial, TutorialConfigurator>
  {
     private TutorialConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TutorialConfigurator For(string name)
    {
      return new TutorialConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TutorialConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTutorial>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TutorialConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTutorial>(name, assetId);
      return For(name);
    }

  }
}
