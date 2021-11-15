using BlueprintCore.Utils;
using Kingmaker.Blueprints.Console;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="GamePadTexts.m_Layers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GamePadTextsConfigurator AddToLayers(params GamePadTexts.GamePadTextsLayer[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Layers.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="GamePadTexts.m_Layers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GamePadTextsConfigurator RemoveFromLayers(params GamePadTexts.GamePadTextsLayer[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Layers = bp.m_Layers.Where(item => !values.Contains(item)).ToList());
    }
  }
}
