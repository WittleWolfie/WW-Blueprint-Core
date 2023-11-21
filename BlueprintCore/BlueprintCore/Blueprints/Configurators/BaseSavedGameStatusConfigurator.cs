//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSavedGameStatus"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSavedGameStatusConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSavedGameStatus
    where TBuilder : BaseSavedGameStatusConfigurator<T, TBuilder>
  {
    protected BaseSavedGameStatusConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSavedGameStatus>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.GameStatusVariants = copyFrom.GameStatusVariants;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSavedGameStatus>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.GameStatusVariants = copyFrom.GameStatusVariants;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSavedGameStatus.GameStatusVariants"/>
    /// </summary>
    ///
    /// <param name="gameStatusVariants">
    /// <para>
    /// Tooltip: Первый подходящий по условию текст будет добавлен в окно информации о сейве.
    /// </para>
    /// </param>
    public TBuilder SetGameStatusVariants(params BlueprintSavedGameStatus.GameStatusTextInfo[] gameStatusVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GameStatusVariants = gameStatusVariants;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintSavedGameStatus.GameStatusVariants"/>
    /// </summary>
    ///
    /// <param name="gameStatusVariants">
    /// <para>
    /// Tooltip: Первый подходящий по условию текст будет добавлен в окно информации о сейве.
    /// </para>
    /// </param>
    public TBuilder AddToGameStatusVariants(params BlueprintSavedGameStatus.GameStatusTextInfo[] gameStatusVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GameStatusVariants = bp.GameStatusVariants ?? new BlueprintSavedGameStatus.GameStatusTextInfo[0];
          bp.GameStatusVariants = CommonTool.Append(bp.GameStatusVariants, gameStatusVariants);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSavedGameStatus.GameStatusVariants"/>
    /// </summary>
    ///
    /// <param name="gameStatusVariants">
    /// <para>
    /// Tooltip: Первый подходящий по условию текст будет добавлен в окно информации о сейве.
    /// </para>
    /// </param>
    public TBuilder RemoveFromGameStatusVariants(params BlueprintSavedGameStatus.GameStatusTextInfo[] gameStatusVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GameStatusVariants is null) { return; }
          bp.GameStatusVariants = bp.GameStatusVariants.Where(val => !gameStatusVariants.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSavedGameStatus.GameStatusVariants"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromGameStatusVariants(Func<BlueprintSavedGameStatus.GameStatusTextInfo, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GameStatusVariants is null) { return; }
          bp.GameStatusVariants = bp.GameStatusVariants.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintSavedGameStatus.GameStatusVariants"/>
    /// </summary>
    public TBuilder ClearGameStatusVariants()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GameStatusVariants = new BlueprintSavedGameStatus.GameStatusTextInfo[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSavedGameStatus.GameStatusVariants"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyGameStatusVariants(Action<BlueprintSavedGameStatus.GameStatusTextInfo> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GameStatusVariants is null) { return; }
          bp.GameStatusVariants.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.GameStatusVariants is null)
      {
        Blueprint.GameStatusVariants = new BlueprintSavedGameStatus.GameStatusTextInfo[0];
      }
    }
  }
}
