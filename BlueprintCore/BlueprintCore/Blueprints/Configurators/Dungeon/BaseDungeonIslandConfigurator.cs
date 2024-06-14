//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonIsland"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonIslandConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonIsland
    where TBuilder : BaseDungeonIslandConfigurator<T, TBuilder>
  {
    protected BaseDungeonIslandConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonIsland>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ImageLink = copyFrom.m_ImageLink;
          bp.m_ImageSkippedLink = copyFrom.m_ImageSkippedLink;
          bp.m_ImageVisitedLink = copyFrom.m_ImageVisitedLink;
          bp.m_ImageHoverLink = copyFrom.m_ImageHoverLink;
          bp.m_Settings = copyFrom.m_Settings;
          bp.m_ModificatorsInclude = copyFrom.m_ModificatorsInclude;
          bp.m_ModificatorsExclude = copyFrom.m_ModificatorsExclude;
          bp.m_Themes = copyFrom.m_Themes;
          bp.m_Tiers = copyFrom.m_Tiers;
          bp.LimitMinStage = copyFrom.LimitMinStage;
          bp.MinStage = copyFrom.MinStage;
          bp.LimitMaxStage = copyFrom.LimitMaxStage;
          bp.MaxStage = copyFrom.MaxStage;
          bp.Stages = copyFrom.Stages;
          bp.m_ArmiesExclude = copyFrom.m_ArmiesExclude;
          bp.m_ArmiesInclude = copyFrom.m_ArmiesInclude;
          bp.m_UnitTagsExclude = copyFrom.m_UnitTagsExclude;
          bp.m_UnitTagsInclude = copyFrom.m_UnitTagsInclude;
          bp.IncludeOtherArmies = copyFrom.IncludeOtherArmies;
          bp.m_Area = copyFrom.m_Area;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonIsland>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ImageLink = copyFrom.m_ImageLink;
          bp.m_ImageSkippedLink = copyFrom.m_ImageSkippedLink;
          bp.m_ImageVisitedLink = copyFrom.m_ImageVisitedLink;
          bp.m_ImageHoverLink = copyFrom.m_ImageHoverLink;
          bp.m_Settings = copyFrom.m_Settings;
          bp.m_ModificatorsInclude = copyFrom.m_ModificatorsInclude;
          bp.m_ModificatorsExclude = copyFrom.m_ModificatorsExclude;
          bp.m_Themes = copyFrom.m_Themes;
          bp.m_Tiers = copyFrom.m_Tiers;
          bp.LimitMinStage = copyFrom.LimitMinStage;
          bp.MinStage = copyFrom.MinStage;
          bp.LimitMaxStage = copyFrom.LimitMaxStage;
          bp.MaxStage = copyFrom.MaxStage;
          bp.Stages = copyFrom.Stages;
          bp.m_ArmiesExclude = copyFrom.m_ArmiesExclude;
          bp.m_ArmiesInclude = copyFrom.m_ArmiesInclude;
          bp.m_UnitTagsExclude = copyFrom.m_UnitTagsExclude;
          bp.m_UnitTagsInclude = copyFrom.m_UnitTagsInclude;
          bp.IncludeOtherArmies = copyFrom.IncludeOtherArmies;
          bp.m_Area = copyFrom.m_Area;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ImageLink"/>
    /// </summary>
    ///
    /// <param name="imageLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetImageLink(AssetLink<SpriteLink> imageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageLink = imageLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ImageLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageLink is null) { return; }
          action.Invoke(bp.m_ImageLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ImageSkippedLink"/>
    /// </summary>
    ///
    /// <param name="imageSkippedLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetImageSkippedLink(AssetLink<SpriteLink> imageSkippedLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageSkippedLink = imageSkippedLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ImageSkippedLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageSkippedLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageSkippedLink is null) { return; }
          action.Invoke(bp.m_ImageSkippedLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ImageVisitedLink"/>
    /// </summary>
    ///
    /// <param name="imageVisitedLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetImageVisitedLink(AssetLink<SpriteLink> imageVisitedLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageVisitedLink = imageVisitedLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ImageVisitedLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageVisitedLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageVisitedLink is null) { return; }
          action.Invoke(bp.m_ImageVisitedLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ImageHoverLink"/>
    /// </summary>
    ///
    /// <param name="imageHoverLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetImageHoverLink(AssetLink<SpriteLink> imageHoverLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageHoverLink = imageHoverLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ImageHoverLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageHoverLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageHoverLink is null) { return; }
          action.Invoke(bp.m_ImageHoverLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettings(params Blueprint<BlueprintDungeonSettingReference>[] settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = settings.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSettings(params Blueprint<BlueprintDungeonSettingReference>[] settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = bp.m_Settings ?? new BlueprintDungeonSettingReference[0];
          bp.m_Settings = CommonTool.Append(bp.m_Settings, settings.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSettings(params Blueprint<BlueprintDungeonSettingReference>[] settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings = bp.m_Settings.Where(val => !settings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_Settings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSettings(Func<BlueprintDungeonSettingReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings = bp.m_Settings.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_Settings"/>
    /// </summary>
    public TBuilder ClearSettings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = new BlueprintDungeonSettingReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_Settings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySettings(Action<BlueprintDungeonSettingReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ModificatorsInclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsInclude">
    /// <para>
    /// Tooltip: Restrict this island to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetModificatorsInclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsInclude = modificatorsInclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_ModificatorsInclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsInclude">
    /// <para>
    /// Tooltip: Restrict this island to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToModificatorsInclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsInclude = bp.m_ModificatorsInclude ?? new BlueprintDungeonModificatorReference[0];
          bp.m_ModificatorsInclude = CommonTool.Append(bp.m_ModificatorsInclude, modificatorsInclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ModificatorsInclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsInclude">
    /// <para>
    /// Tooltip: Restrict this island to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromModificatorsInclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsInclude is null) { return; }
          bp.m_ModificatorsInclude = bp.m_ModificatorsInclude.Where(val => !modificatorsInclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ModificatorsInclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromModificatorsInclude(Func<BlueprintDungeonModificatorReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsInclude is null) { return; }
          bp.m_ModificatorsInclude = bp.m_ModificatorsInclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_ModificatorsInclude"/>
    /// </summary>
    public TBuilder ClearModificatorsInclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsInclude = new BlueprintDungeonModificatorReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ModificatorsInclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyModificatorsInclude(Action<BlueprintDungeonModificatorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsInclude is null) { return; }
          bp.m_ModificatorsInclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ModificatorsExclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsExclude">
    /// <para>
    /// Tooltip: Restrict this island to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetModificatorsExclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsExclude = modificatorsExclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_ModificatorsExclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsExclude">
    /// <para>
    /// Tooltip: Restrict this island to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToModificatorsExclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsExclude = bp.m_ModificatorsExclude ?? new BlueprintDungeonModificatorReference[0];
          bp.m_ModificatorsExclude = CommonTool.Append(bp.m_ModificatorsExclude, modificatorsExclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ModificatorsExclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsExclude">
    /// <para>
    /// Tooltip: Restrict this island to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromModificatorsExclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsExclude is null) { return; }
          bp.m_ModificatorsExclude = bp.m_ModificatorsExclude.Where(val => !modificatorsExclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ModificatorsExclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromModificatorsExclude(Func<BlueprintDungeonModificatorReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsExclude is null) { return; }
          bp.m_ModificatorsExclude = bp.m_ModificatorsExclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_ModificatorsExclude"/>
    /// </summary>
    public TBuilder ClearModificatorsExclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsExclude = new BlueprintDungeonModificatorReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ModificatorsExclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyModificatorsExclude(Action<BlueprintDungeonModificatorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsExclude is null) { return; }
          bp.m_ModificatorsExclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_Themes"/>
    /// </summary>
    ///
    /// <param name="themes">
    /// <para>
    /// Blueprint of type BlueprintDungeonTheme. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetThemes(params Blueprint<BlueprintDungeonThemeReference>[] themes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Themes = themes.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_Themes"/>
    /// </summary>
    ///
    /// <param name="themes">
    /// <para>
    /// Blueprint of type BlueprintDungeonTheme. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToThemes(params Blueprint<BlueprintDungeonThemeReference>[] themes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Themes = bp.m_Themes ?? new BlueprintDungeonThemeReference[0];
          bp.m_Themes = CommonTool.Append(bp.m_Themes, themes.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_Themes"/>
    /// </summary>
    ///
    /// <param name="themes">
    /// <para>
    /// Blueprint of type BlueprintDungeonTheme. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromThemes(params Blueprint<BlueprintDungeonThemeReference>[] themes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Themes is null) { return; }
          bp.m_Themes = bp.m_Themes.Where(val => !themes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_Themes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromThemes(Func<BlueprintDungeonThemeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Themes is null) { return; }
          bp.m_Themes = bp.m_Themes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_Themes"/>
    /// </summary>
    public TBuilder ClearThemes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Themes = new BlueprintDungeonThemeReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_Themes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyThemes(Action<BlueprintDungeonThemeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Themes is null) { return; }
          bp.m_Themes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = tiers.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = bp.m_Tiers ?? new BlueprintDungeonTierReference[0];
          bp.m_Tiers = CommonTool.Append(bp.m_Tiers, tiers.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(val => !tiers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_Tiers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTiers(Func<BlueprintDungeonTierReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_Tiers"/>
    /// </summary>
    public TBuilder ClearTiers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = new BlueprintDungeonTierReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_Tiers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTiers(Action<BlueprintDungeonTierReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.LimitMinStage"/>
    /// </summary>
    public TBuilder SetLimitMinStage(bool limitMinStage = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LimitMinStage = limitMinStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.MinStage"/>
    /// </summary>
    ///
    /// <param name="minStage">
    /// <para>
    /// Tooltip: This army should appear not before this stage.
    /// </para>
    /// </param>
    public TBuilder SetMinStage(int minStage)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinStage = minStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.LimitMaxStage"/>
    /// </summary>
    public TBuilder SetLimitMaxStage(bool limitMaxStage = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LimitMaxStage = limitMaxStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.MaxStage"/>
    /// </summary>
    ///
    /// <param name="maxStage">
    /// <para>
    /// Tooltip: This army should appear not after this stage.
    /// </para>
    /// </param>
    public TBuilder SetMaxStage(int maxStage)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxStage = maxStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.Stages"/>
    /// </summary>
    public TBuilder SetStages(params int[] stages)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stages = stages;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.Stages"/>
    /// </summary>
    public TBuilder AddToStages(params int[] stages)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stages = bp.Stages ?? new int[0];
          bp.Stages = CommonTool.Append(bp.Stages, stages);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.Stages"/>
    /// </summary>
    public TBuilder RemoveFromStages(params int[] stages)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stages is null) { return; }
          bp.Stages = bp.Stages.Where(val => !stages.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.Stages"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStages(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stages is null) { return; }
          bp.Stages = bp.Stages.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.Stages"/>
    /// </summary>
    public TBuilder ClearStages()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stages = new int[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.Stages"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStages(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stages is null) { return; }
          bp.Stages.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ArmiesExclude"/>
    /// </summary>
    ///
    /// <param name="armiesExclude">
    /// <para>
    /// Tooltip: Armies that are excluded no matter what.
    /// </para>
    /// <para>
    /// InfoBox: Rules are checked in the following order: Armies exclude and include, Tags exclude and include.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmiesExclude(params Blueprint<BlueprintDungeonArmyReference>[] armiesExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmiesExclude = armiesExclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_ArmiesExclude"/>
    /// </summary>
    ///
    /// <param name="armiesExclude">
    /// <para>
    /// Tooltip: Armies that are excluded no matter what.
    /// </para>
    /// <para>
    /// InfoBox: Rules are checked in the following order: Armies exclude and include, Tags exclude and include.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToArmiesExclude(params Blueprint<BlueprintDungeonArmyReference>[] armiesExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmiesExclude = bp.m_ArmiesExclude ?? new BlueprintDungeonArmyReference[0];
          bp.m_ArmiesExclude = CommonTool.Append(bp.m_ArmiesExclude, armiesExclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ArmiesExclude"/>
    /// </summary>
    ///
    /// <param name="armiesExclude">
    /// <para>
    /// Tooltip: Armies that are excluded no matter what.
    /// </para>
    /// <para>
    /// InfoBox: Rules are checked in the following order: Armies exclude and include, Tags exclude and include.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromArmiesExclude(params Blueprint<BlueprintDungeonArmyReference>[] armiesExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmiesExclude is null) { return; }
          bp.m_ArmiesExclude = bp.m_ArmiesExclude.Where(val => !armiesExclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ArmiesExclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArmiesExclude(Func<BlueprintDungeonArmyReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmiesExclude is null) { return; }
          bp.m_ArmiesExclude = bp.m_ArmiesExclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_ArmiesExclude"/>
    /// </summary>
    public TBuilder ClearArmiesExclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmiesExclude = new BlueprintDungeonArmyReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ArmiesExclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArmiesExclude(Action<BlueprintDungeonArmyReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmiesExclude is null) { return; }
          bp.m_ArmiesExclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_ArmiesInclude"/>
    /// </summary>
    ///
    /// <param name="armiesInclude">
    /// <para>
    /// Tooltip: Armies that are included no matter what.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmiesInclude(params Blueprint<BlueprintDungeonArmyReference>[] armiesInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmiesInclude = armiesInclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_ArmiesInclude"/>
    /// </summary>
    ///
    /// <param name="armiesInclude">
    /// <para>
    /// Tooltip: Armies that are included no matter what.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToArmiesInclude(params Blueprint<BlueprintDungeonArmyReference>[] armiesInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmiesInclude = bp.m_ArmiesInclude ?? new BlueprintDungeonArmyReference[0];
          bp.m_ArmiesInclude = CommonTool.Append(bp.m_ArmiesInclude, armiesInclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ArmiesInclude"/>
    /// </summary>
    ///
    /// <param name="armiesInclude">
    /// <para>
    /// Tooltip: Armies that are included no matter what.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromArmiesInclude(params Blueprint<BlueprintDungeonArmyReference>[] armiesInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmiesInclude is null) { return; }
          bp.m_ArmiesInclude = bp.m_ArmiesInclude.Where(val => !armiesInclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_ArmiesInclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArmiesInclude(Func<BlueprintDungeonArmyReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmiesInclude is null) { return; }
          bp.m_ArmiesInclude = bp.m_ArmiesInclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_ArmiesInclude"/>
    /// </summary>
    public TBuilder ClearArmiesInclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmiesInclude = new BlueprintDungeonArmyReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_ArmiesInclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArmiesInclude(Action<BlueprintDungeonArmyReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmiesInclude is null) { return; }
          bp.m_ArmiesInclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_UnitTagsExclude"/>
    /// </summary>
    ///
    /// <param name="unitTagsExclude">
    /// <para>
    /// Tooltip: Exclude armies that have any one of these tags.
    /// </para>
    /// </param>
    public TBuilder SetUnitTagsExclude(params UnitTag[] unitTagsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTagsExclude = unitTagsExclude;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_UnitTagsExclude"/>
    /// </summary>
    ///
    /// <param name="unitTagsExclude">
    /// <para>
    /// Tooltip: Exclude armies that have any one of these tags.
    /// </para>
    /// </param>
    public TBuilder AddToUnitTagsExclude(params UnitTag[] unitTagsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTagsExclude = bp.m_UnitTagsExclude ?? new UnitTag[0];
          bp.m_UnitTagsExclude = CommonTool.Append(bp.m_UnitTagsExclude, unitTagsExclude);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_UnitTagsExclude"/>
    /// </summary>
    ///
    /// <param name="unitTagsExclude">
    /// <para>
    /// Tooltip: Exclude armies that have any one of these tags.
    /// </para>
    /// </param>
    public TBuilder RemoveFromUnitTagsExclude(params UnitTag[] unitTagsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTagsExclude is null) { return; }
          bp.m_UnitTagsExclude = bp.m_UnitTagsExclude.Where(val => !unitTagsExclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_UnitTagsExclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitTagsExclude(Func<UnitTag, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTagsExclude is null) { return; }
          bp.m_UnitTagsExclude = bp.m_UnitTagsExclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_UnitTagsExclude"/>
    /// </summary>
    public TBuilder ClearUnitTagsExclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTagsExclude = new UnitTag[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_UnitTagsExclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitTagsExclude(Action<UnitTag> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTagsExclude is null) { return; }
          bp.m_UnitTagsExclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_UnitTagsInclude"/>
    /// </summary>
    ///
    /// <param name="unitTagsInclude">
    /// <para>
    /// Tooltip: Include armies that have any one of these tags.
    /// </para>
    /// </param>
    public TBuilder SetUnitTagsInclude(params UnitTag[] unitTagsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTagsInclude = unitTagsInclude;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIsland.m_UnitTagsInclude"/>
    /// </summary>
    ///
    /// <param name="unitTagsInclude">
    /// <para>
    /// Tooltip: Include armies that have any one of these tags.
    /// </para>
    /// </param>
    public TBuilder AddToUnitTagsInclude(params UnitTag[] unitTagsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTagsInclude = bp.m_UnitTagsInclude ?? new UnitTag[0];
          bp.m_UnitTagsInclude = CommonTool.Append(bp.m_UnitTagsInclude, unitTagsInclude);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_UnitTagsInclude"/>
    /// </summary>
    ///
    /// <param name="unitTagsInclude">
    /// <para>
    /// Tooltip: Include armies that have any one of these tags.
    /// </para>
    /// </param>
    public TBuilder RemoveFromUnitTagsInclude(params UnitTag[] unitTagsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTagsInclude is null) { return; }
          bp.m_UnitTagsInclude = bp.m_UnitTagsInclude.Where(val => !unitTagsInclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIsland.m_UnitTagsInclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitTagsInclude(Func<UnitTag, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTagsInclude is null) { return; }
          bp.m_UnitTagsInclude = bp.m_UnitTagsInclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIsland.m_UnitTagsInclude"/>
    /// </summary>
    public TBuilder ClearUnitTagsInclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTagsInclude = new UnitTag[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_UnitTagsInclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitTagsInclude(Action<UnitTag> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTagsInclude is null) { return; }
          bp.m_UnitTagsInclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.IncludeOtherArmies"/>
    /// </summary>
    ///
    /// <param name="includeOtherArmies">
    /// <para>
    /// Tooltip: Include armies that were not chosen by the include rules and were not filtered out be the exclude rules.
    /// </para>
    /// </param>
    public TBuilder SetIncludeOtherArmies(bool includeOtherArmies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IncludeOtherArmies = includeOtherArmies;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIsland.m_Area"/>
    /// </summary>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArea(Blueprint<BlueprintAreaReference> area)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Area = area?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIsland.m_Area"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArea(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Area is null) { return; }
          action.Invoke(bp.m_Area);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Settings is null)
      {
        Blueprint.m_Settings = new BlueprintDungeonSettingReference[0];
      }
      if (Blueprint.m_ModificatorsInclude is null)
      {
        Blueprint.m_ModificatorsInclude = new BlueprintDungeonModificatorReference[0];
      }
      if (Blueprint.m_ModificatorsExclude is null)
      {
        Blueprint.m_ModificatorsExclude = new BlueprintDungeonModificatorReference[0];
      }
      if (Blueprint.m_Themes is null)
      {
        Blueprint.m_Themes = new BlueprintDungeonThemeReference[0];
      }
      if (Blueprint.m_Tiers is null)
      {
        Blueprint.m_Tiers = new BlueprintDungeonTierReference[0];
      }
      if (Blueprint.Stages is null)
      {
        Blueprint.Stages = new int[0];
      }
      if (Blueprint.m_ArmiesExclude is null)
      {
        Blueprint.m_ArmiesExclude = new BlueprintDungeonArmyReference[0];
      }
      if (Blueprint.m_ArmiesInclude is null)
      {
        Blueprint.m_ArmiesInclude = new BlueprintDungeonArmyReference[0];
      }
      if (Blueprint.m_UnitTagsExclude is null)
      {
        Blueprint.m_UnitTagsExclude = new UnitTag[0];
      }
      if (Blueprint.m_UnitTagsInclude is null)
      {
        Blueprint.m_UnitTagsInclude = new UnitTag[0];
      }
      if (Blueprint.m_Area is null)
      {
        Blueprint.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
    }
  }
}
