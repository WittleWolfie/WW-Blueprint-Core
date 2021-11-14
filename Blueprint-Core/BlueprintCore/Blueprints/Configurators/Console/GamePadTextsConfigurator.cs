using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Console;

namespace BlueprintCore.Blueprints.Configurators.Console
{
  /// <summary>Configurator for <see cref="GamePadTexts"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(GamePadTexts))]
  public class GamePadTextsConfigurator : BaseBlueprintConfigurator<GamePadTexts, GamePadTextsConfigurator>
  {
     private GamePadTextsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GamePadTextsConfigurator For(string name)
    {
      return new GamePadTextsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GamePadTextsConfigurator New(string name)
    {
      BlueprintTool.Create<GamePadTexts>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GamePadTextsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<GamePadTexts>(name, assetId);
      return For(name);
    }
  }
}
