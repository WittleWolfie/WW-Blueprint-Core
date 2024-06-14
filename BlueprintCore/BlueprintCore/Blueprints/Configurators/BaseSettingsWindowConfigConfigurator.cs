//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SettingsWindowConfig"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettingsWindowConfigConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : SettingsWindowConfig
    where TBuilder : BaseSettingsWindowConfigConfigurator<T, TBuilder>
  {
    protected BaseSettingsWindowConfigConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SettingsWindowConfig>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.PSConsolePrefab = copyFrom.PSConsolePrefab;
          bp.DualSenseConsolePrefab = copyFrom.DualSenseConsolePrefab;
          bp.XBoxConsolePrefab = copyFrom.XBoxConsolePrefab;
          bp.SwitchConsolePrefab = copyFrom.SwitchConsolePrefab;
          bp.SteamConsolePrefab = copyFrom.SteamConsolePrefab;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SettingsWindowConfig>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.PSConsolePrefab = copyFrom.PSConsolePrefab;
          bp.DualSenseConsolePrefab = copyFrom.DualSenseConsolePrefab;
          bp.XBoxConsolePrefab = copyFrom.XBoxConsolePrefab;
          bp.SwitchConsolePrefab = copyFrom.SwitchConsolePrefab;
          bp.SteamConsolePrefab = copyFrom.SteamConsolePrefab;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettingsWindowConfig.PSConsolePrefab"/>
    /// </summary>
    ///
    /// <param name="pSConsolePrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetPSConsolePrefab(AssetLink<PrefabLink> pSConsolePrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PSConsolePrefab = pSConsolePrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="SettingsWindowConfig.PSConsolePrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPSConsolePrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PSConsolePrefab is null) { return; }
          action.Invoke(bp.PSConsolePrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettingsWindowConfig.DualSenseConsolePrefab"/>
    /// </summary>
    ///
    /// <param name="dualSenseConsolePrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetDualSenseConsolePrefab(AssetLink<PrefabLink> dualSenseConsolePrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DualSenseConsolePrefab = dualSenseConsolePrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="SettingsWindowConfig.DualSenseConsolePrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDualSenseConsolePrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DualSenseConsolePrefab is null) { return; }
          action.Invoke(bp.DualSenseConsolePrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettingsWindowConfig.XBoxConsolePrefab"/>
    /// </summary>
    ///
    /// <param name="xBoxConsolePrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetXBoxConsolePrefab(AssetLink<PrefabLink> xBoxConsolePrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.XBoxConsolePrefab = xBoxConsolePrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="SettingsWindowConfig.XBoxConsolePrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyXBoxConsolePrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.XBoxConsolePrefab is null) { return; }
          action.Invoke(bp.XBoxConsolePrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettingsWindowConfig.SwitchConsolePrefab"/>
    /// </summary>
    ///
    /// <param name="switchConsolePrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetSwitchConsolePrefab(AssetLink<PrefabLink> switchConsolePrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SwitchConsolePrefab = switchConsolePrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="SettingsWindowConfig.SwitchConsolePrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySwitchConsolePrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SwitchConsolePrefab is null) { return; }
          action.Invoke(bp.SwitchConsolePrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettingsWindowConfig.SteamConsolePrefab"/>
    /// </summary>
    ///
    /// <param name="steamConsolePrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetSteamConsolePrefab(AssetLink<PrefabLink> steamConsolePrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SteamConsolePrefab = steamConsolePrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="SettingsWindowConfig.SteamConsolePrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySteamConsolePrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SteamConsolePrefab is null) { return; }
          action.Invoke(bp.SteamConsolePrefab);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.PSConsolePrefab is null)
      {
        Blueprint.PSConsolePrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.DualSenseConsolePrefab is null)
      {
        Blueprint.DualSenseConsolePrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.XBoxConsolePrefab is null)
      {
        Blueprint.XBoxConsolePrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.SwitchConsolePrefab is null)
      {
        Blueprint.SwitchConsolePrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.SteamConsolePrefab is null)
      {
        Blueprint.SteamConsolePrefab = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
