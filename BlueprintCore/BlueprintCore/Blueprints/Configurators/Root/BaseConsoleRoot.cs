//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Console;
using Kingmaker.Blueprints.Root;
using Owlcat.Runtime.UI.ConsoleTools.GamepadInput;
using System;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ConsoleRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseConsoleRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : ConsoleRoot
    where TBuilder : BaseConsoleRootConfigurator<T, TBuilder>
  {
    protected BaseConsoleRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ConsoleRoot.Icons"/>
    /// </summary>
    public TBuilder SetIcons(GamePadIcons icons)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(icons);
          bp.Icons = icons;
        });
    }

    /// <summary>
    /// Modifies <see cref="ConsoleRoot.Icons"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcons(Action<GamePadIcons> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icons is null) { return; }
          action.Invoke(bp.Icons);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConsoleRoot.Texts"/>
    /// </summary>
    ///
    /// <param name="texts">
    /// <para>
    /// Blueprint of type GamePadTexts. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTexts(Blueprint<GamePadTexts, GamePadTexts.Reference> texts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Texts = texts?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ConsoleRoot.Texts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTexts(Action<GamePadTexts.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Texts is null) { return; }
          action.Invoke(bp.Texts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ConsoleRoot.InGameMenuIcons"/>
    /// </summary>
    public TBuilder SetInGameMenuIcons(ConsoleRoot.UIInGameMenuIcons inGameMenuIcons)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(inGameMenuIcons);
          bp.InGameMenuIcons = inGameMenuIcons;
        });
    }

    /// <summary>
    /// Modifies <see cref="ConsoleRoot.InGameMenuIcons"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInGameMenuIcons(Action<ConsoleRoot.UIInGameMenuIcons> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.InGameMenuIcons is null) { return; }
          action.Invoke(bp.InGameMenuIcons);
        });
    }
  }
}
