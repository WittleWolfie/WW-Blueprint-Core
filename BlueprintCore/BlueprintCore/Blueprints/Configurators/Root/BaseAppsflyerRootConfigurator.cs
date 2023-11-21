//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Stores;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AppsflyerRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAppsflyerRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : AppsflyerRoot
    where TBuilder : BaseAppsflyerRootConfigurator<T, TBuilder>
  {
    protected BaseAppsflyerRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<AppsflyerRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DevKey = copyFrom.DevKey;
          bp.XboxAppId = copyFrom.XboxAppId;
          bp.SteamAppId = copyFrom.SteamAppId;
          bp.PlayStationAppId = copyFrom.PlayStationAppId;
          bp.AvailableStores = copyFrom.AvailableStores;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<AppsflyerRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DevKey = copyFrom.DevKey;
          bp.XboxAppId = copyFrom.XboxAppId;
          bp.SteamAppId = copyFrom.SteamAppId;
          bp.PlayStationAppId = copyFrom.PlayStationAppId;
          bp.AvailableStores = copyFrom.AvailableStores;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AppsflyerRoot.DevKey"/>
    /// </summary>
    public TBuilder SetDevKey(string devKey)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DevKey = devKey;
        });
    }

    /// <summary>
    /// Modifies <see cref="AppsflyerRoot.DevKey"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDevKey(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DevKey is null) { return; }
          action.Invoke(bp.DevKey);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AppsflyerRoot.XboxAppId"/>
    /// </summary>
    public TBuilder SetXboxAppId(string xboxAppId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.XboxAppId = xboxAppId;
        });
    }

    /// <summary>
    /// Modifies <see cref="AppsflyerRoot.XboxAppId"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyXboxAppId(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.XboxAppId is null) { return; }
          action.Invoke(bp.XboxAppId);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AppsflyerRoot.SteamAppId"/>
    /// </summary>
    public TBuilder SetSteamAppId(string steamAppId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SteamAppId = steamAppId;
        });
    }

    /// <summary>
    /// Modifies <see cref="AppsflyerRoot.SteamAppId"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySteamAppId(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SteamAppId is null) { return; }
          action.Invoke(bp.SteamAppId);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AppsflyerRoot.PlayStationAppId"/>
    /// </summary>
    public TBuilder SetPlayStationAppId(string playStationAppId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PlayStationAppId = playStationAppId;
        });
    }

    /// <summary>
    /// Modifies <see cref="AppsflyerRoot.PlayStationAppId"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPlayStationAppId(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PlayStationAppId is null) { return; }
          action.Invoke(bp.PlayStationAppId);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AppsflyerRoot.AvailableStores"/>
    /// </summary>
    public TBuilder SetAvailableStores(params StoreTypeFlags[] availableStores)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AvailableStores = availableStores.Aggregate((StoreTypeFlags) 0, (f1, f2) => f1 | f2);
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="AppsflyerRoot.AvailableStores"/>
    /// </summary>
    public TBuilder AddToAvailableStores(params StoreTypeFlags[] availableStores)
    {
      return OnConfigureInternal(
        bp =>
        {
          availableStores.ForEach(f => bp.AvailableStores |= f);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="AppsflyerRoot.AvailableStores"/>
    /// </summary>
    public TBuilder RemoveFromAvailableStores(params StoreTypeFlags[] availableStores)
    {
      return OnConfigureInternal(
        bp =>
        {
          availableStores.ForEach(f => bp.AvailableStores &= ~f);
        });
    }
  }
}
