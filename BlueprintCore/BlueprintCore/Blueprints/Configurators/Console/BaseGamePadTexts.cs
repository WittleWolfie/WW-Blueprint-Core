//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Console;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Console
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="GamePadTexts"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGamePadTextsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : GamePadTexts
    where TBuilder : BaseGamePadTextsConfigurator<T, TBuilder>
  {
    protected BaseGamePadTextsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="GamePadTexts.m_Layers"/>
    /// </summary>
    public TBuilder SetLayers(params GamePadTexts.GamePadTextsLayer[] layers)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(layers);
          bp.m_Layers = layers.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="GamePadTexts.m_Layers"/>
    /// </summary>
    public TBuilder AddToLayers(params GamePadTexts.GamePadTextsLayer[] layers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Layers = bp.m_Layers ?? new();
          bp.m_Layers.AddRange(layers);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="GamePadTexts.m_Layers"/>
    /// </summary>
    public TBuilder RemoveFromLayers(params GamePadTexts.GamePadTextsLayer[] layers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Layers is null) { return; }
          bp.m_Layers = bp.m_Layers.Where(val => !layers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="GamePadTexts.m_Layers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLayers(Func<GamePadTexts.GamePadTextsLayer, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Layers is null) { return; }
          bp.m_Layers = bp.m_Layers.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="GamePadTexts.m_Layers"/>
    /// </summary>
    public TBuilder ClearLayers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Layers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="GamePadTexts.m_Layers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLayers(Action<GamePadTexts.GamePadTextsLayer> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Layers is null) { return; }
          bp.m_Layers.ForEach(action);
        });
    }
  }
}
