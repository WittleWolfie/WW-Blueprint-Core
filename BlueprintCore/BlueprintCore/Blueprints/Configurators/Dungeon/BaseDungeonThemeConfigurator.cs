//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonTheme"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonThemeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonTheme
    where TBuilder : BaseDungeonThemeConfigurator<T, TBuilder>
  {
    protected BaseDungeonThemeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTheme.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTheme.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTheme.SceneAudio"/>
    /// </summary>
    public TBuilder SetSceneAudio(SceneReference sceneAudio)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(sceneAudio);
          bp.SceneAudio = sceneAudio;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTheme.SceneAudio"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySceneAudio(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SceneAudio is null) { return; }
          action.Invoke(bp.SceneAudio);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTheme.Bank"/>
    /// </summary>
    public TBuilder SetBank(string bank)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Bank = bank;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTheme.Bank"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBank(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Bank is null) { return; }
          action.Invoke(bp.Bank);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
    }
  }
}