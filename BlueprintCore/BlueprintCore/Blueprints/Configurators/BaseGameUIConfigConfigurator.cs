//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="GameUIConfig"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGameUIConfigConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : GameUIConfig
    where TBuilder : BaseGameUIConfigConfigurator<T, TBuilder>
  {
    protected BaseGameUIConfigConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<GameUIConfig>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DLC3GameOverWindow = copyFrom.DLC3GameOverWindow;
          bp.DLC3BoonWindow = copyFrom.DLC3BoonWindow;
          bp.DLC3MapWindow = copyFrom.DLC3MapWindow;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<GameUIConfig>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DLC3GameOverWindow = copyFrom.DLC3GameOverWindow;
          bp.DLC3BoonWindow = copyFrom.DLC3BoonWindow;
          bp.DLC3MapWindow = copyFrom.DLC3MapWindow;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="GameUIConfig.DLC3GameOverWindow"/>
    /// </summary>
    public TBuilder SetDLC3GameOverWindow(GameUIConfig.PrefabLinkPair dLC3GameOverWindow)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dLC3GameOverWindow);
          bp.DLC3GameOverWindow = dLC3GameOverWindow;
        });
    }

    /// <summary>
    /// Modifies <see cref="GameUIConfig.DLC3GameOverWindow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDLC3GameOverWindow(Action<GameUIConfig.PrefabLinkPair> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DLC3GameOverWindow is null) { return; }
          action.Invoke(bp.DLC3GameOverWindow);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="GameUIConfig.DLC3BoonWindow"/>
    /// </summary>
    public TBuilder SetDLC3BoonWindow(GameUIConfig.PrefabLinkPair dLC3BoonWindow)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dLC3BoonWindow);
          bp.DLC3BoonWindow = dLC3BoonWindow;
        });
    }

    /// <summary>
    /// Modifies <see cref="GameUIConfig.DLC3BoonWindow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDLC3BoonWindow(Action<GameUIConfig.PrefabLinkPair> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DLC3BoonWindow is null) { return; }
          action.Invoke(bp.DLC3BoonWindow);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="GameUIConfig.DLC3MapWindow"/>
    /// </summary>
    public TBuilder SetDLC3MapWindow(GameUIConfig.PrefabLinkPair dLC3MapWindow)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dLC3MapWindow);
          bp.DLC3MapWindow = dLC3MapWindow;
        });
    }

    /// <summary>
    /// Modifies <see cref="GameUIConfig.DLC3MapWindow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDLC3MapWindow(Action<GameUIConfig.PrefabLinkPair> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DLC3MapWindow is null) { return; }
          action.Invoke(bp.DLC3MapWindow);
        });
    }
  }
}
