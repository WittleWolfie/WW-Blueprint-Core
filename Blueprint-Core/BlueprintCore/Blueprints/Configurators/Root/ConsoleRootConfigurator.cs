using BlueprintCore.Utils;
using Kingmaker.Blueprints.Console;
using Kingmaker.Blueprints.Root;
using Owlcat.Runtime.UI.ConsoleTools.GamepadInput;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="ConsoleRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ConsoleRoot))]
  public class ConsoleRootConfigurator : BaseBlueprintConfigurator<ConsoleRoot, ConsoleRootConfigurator>
  {
     private ConsoleRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConsoleRootConfigurator For(string name)
    {
      return new ConsoleRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ConsoleRootConfigurator New(string name)
    {
      BlueprintTool.Create<ConsoleRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConsoleRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ConsoleRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ConsoleRoot.Icons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsoleRootConfigurator SetIcons(GamePadIcons value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Icons = value);
    }

    /// <summary>
    /// Sets <see cref="ConsoleRoot.Texts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="GamePadTexts"/></param>
    [Generated]
    public ConsoleRootConfigurator SetTexts(string value)
    {
      return OnConfigureInternal(bp => bp.Texts = BlueprintTool.GetRef<GamePadTexts.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="ConsoleRoot.InGameMenuIcons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsoleRootConfigurator SetInGameMenuIcons(ConsoleRoot.UIInGameMenuIcons value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.InGameMenuIcons = value);
    }
  }
}
