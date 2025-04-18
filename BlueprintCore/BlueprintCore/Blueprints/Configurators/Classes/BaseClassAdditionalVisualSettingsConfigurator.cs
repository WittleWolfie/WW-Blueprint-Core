//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintClassAdditionalVisualSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseClassAdditionalVisualSettingsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintClassAdditionalVisualSettings
    where TBuilder : BaseClassAdditionalVisualSettingsConfigurator<T, TBuilder>
  {
    protected BaseClassAdditionalVisualSettingsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintClassAdditionalVisualSettings>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Conditions = copyFrom.m_Conditions;
          bp.ColorRamps = copyFrom.ColorRamps;
          bp.OverrideFootprintType = copyFrom.OverrideFootprintType;
          bp.FootprintType = copyFrom.FootprintType;
          bp.CommonSettings = copyFrom.CommonSettings;
          bp.InGameSettings = copyFrom.InGameSettings;
          bp.DollRoomSettings = copyFrom.DollRoomSettings;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintClassAdditionalVisualSettings>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Conditions = copyFrom.m_Conditions;
          bp.ColorRamps = copyFrom.ColorRamps;
          bp.OverrideFootprintType = copyFrom.OverrideFootprintType;
          bp.FootprintType = copyFrom.FootprintType;
          bp.CommonSettings = copyFrom.CommonSettings;
          bp.InGameSettings = copyFrom.InGameSettings;
          bp.DollRoomSettings = copyFrom.DollRoomSettings;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.m_Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Conditions = conditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.m_Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Conditions is null) { return; }
          action.Invoke(bp.m_Conditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/>
    /// </summary>
    public TBuilder SetColorRamps(params BlueprintClassAdditionalVisualSettings.ColorRamp[] colorRamps)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(colorRamps);
          bp.ColorRamps = colorRamps;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/>
    /// </summary>
    public TBuilder AddToColorRamps(params BlueprintClassAdditionalVisualSettings.ColorRamp[] colorRamps)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ColorRamps = bp.ColorRamps ?? new BlueprintClassAdditionalVisualSettings.ColorRamp[0];
          bp.ColorRamps = CommonTool.Append(bp.ColorRamps, colorRamps);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/>
    /// </summary>
    public TBuilder RemoveFromColorRamps(params BlueprintClassAdditionalVisualSettings.ColorRamp[] colorRamps)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ColorRamps is null) { return; }
          bp.ColorRamps = bp.ColorRamps.Where(val => !colorRamps.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromColorRamps(Func<BlueprintClassAdditionalVisualSettings.ColorRamp, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ColorRamps is null) { return; }
          bp.ColorRamps = bp.ColorRamps.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/>
    /// </summary>
    public TBuilder ClearColorRamps()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ColorRamps = new BlueprintClassAdditionalVisualSettings.ColorRamp[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyColorRamps(Action<BlueprintClassAdditionalVisualSettings.ColorRamp> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ColorRamps is null) { return; }
          bp.ColorRamps.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.OverrideFootprintType"/>
    /// </summary>
    public TBuilder SetOverrideFootprintType(bool overrideFootprintType = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideFootprintType = overrideFootprintType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.FootprintType"/>
    /// </summary>
    public TBuilder SetFootprintType(FootprintType footprintType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintType = footprintType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.CommonSettings"/>
    /// </summary>
    ///
    /// <param name="commonSettings">
    /// <para>
    /// InfoBox: Applied in game and in doll room
    /// </para>
    /// </param>
    public TBuilder SetCommonSettings(BlueprintClassAdditionalVisualSettings.SettingsData commonSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(commonSettings);
          bp.CommonSettings = commonSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.CommonSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCommonSettings(Action<BlueprintClassAdditionalVisualSettings.SettingsData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CommonSettings is null) { return; }
          action.Invoke(bp.CommonSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.InGameSettings"/>
    /// </summary>
    ///
    /// <param name="inGameSettings">
    /// <para>
    /// InfoBox: Applied in game only (after CommonSettings)
    /// </para>
    /// </param>
    public TBuilder SetInGameSettings(BlueprintClassAdditionalVisualSettings.SettingsData inGameSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(inGameSettings);
          bp.InGameSettings = inGameSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.InGameSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInGameSettings(Action<BlueprintClassAdditionalVisualSettings.SettingsData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.InGameSettings is null) { return; }
          action.Invoke(bp.InGameSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.DollRoomSettings"/>
    /// </summary>
    ///
    /// <param name="dollRoomSettings">
    /// <para>
    /// InfoBox: Applied in doll room only (after CommonSettings)
    /// </para>
    /// </param>
    public TBuilder SetDollRoomSettings(BlueprintClassAdditionalVisualSettings.SettingsData dollRoomSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dollRoomSettings);
          bp.DollRoomSettings = dollRoomSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.DollRoomSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDollRoomSettings(Action<BlueprintClassAdditionalVisualSettings.SettingsData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DollRoomSettings is null) { return; }
          action.Invoke(bp.DollRoomSettings);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Conditions is null)
      {
        Blueprint.m_Conditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.ColorRamps is null)
      {
        Blueprint.ColorRamps = new BlueprintClassAdditionalVisualSettings.ColorRamp[0];
      }
    }
  }
}
