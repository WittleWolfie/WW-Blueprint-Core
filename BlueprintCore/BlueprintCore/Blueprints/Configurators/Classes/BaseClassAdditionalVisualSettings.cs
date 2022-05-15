//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
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
    protected BaseClassAdditionalVisualSettingsConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.m_Prerequisite"/>
    /// </summary>
    ///
    /// <param name="prerequisite">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPrerequisite(Blueprint<BlueprintEtude, BlueprintEtudeReference> prerequisite)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Prerequisite = prerequisite?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.m_Prerequisite"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="prerequisite">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPrerequisite(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Prerequisite is null) { return; }
          action.Invoke(bp.m_Prerequisite);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/>
    /// </summary>
    public TBuilder SetColorRamps(BlueprintClassAdditionalVisualSettings.ColorRamp[] colorRamps)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in colorRamps) { Validate(item); }
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
          bp.ColorRamps = bp.ColorRamps.Where(predicate).ToArray();
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
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.OverrideFootprintType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverrideFootprintType(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OverrideFootprintType);
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
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettings.FootprintType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFootprintType(Action<FootprintType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FootprintType);
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
    ///
    /// <param name="commonSettings">
    /// <para>
    /// InfoBox: Applied in game and in doll room
    /// </para>
    /// </param>
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
    ///
    /// <param name="inGameSettings">
    /// <para>
    /// InfoBox: Applied in game only (after CommonSettings)
    /// </para>
    /// </param>
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
    ///
    /// <param name="dollRoomSettings">
    /// <para>
    /// InfoBox: Applied in doll room only (after CommonSettings)
    /// </para>
    /// </param>
    public TBuilder ModifyDollRoomSettings(Action<BlueprintClassAdditionalVisualSettings.SettingsData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DollRoomSettings is null) { return; }
          action.Invoke(bp.DollRoomSettings);
        });
    }
  }
}
