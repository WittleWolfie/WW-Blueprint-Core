//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.QA.Arbiter;
using System;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArbiterInstruction"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArbiterInstructionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArbiterInstruction
    where TBuilder : BaseArbiterInstructionConfigurator<T, TBuilder>
  {
    protected BaseArbiterInstructionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AreaCheckerComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Arbiter/Area Checker
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="overrideAreaPreset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAreaCheckerComponent(
        Blueprint<BlueprintArea, BlueprintAreaReference>? area = null,
        ArbiterElementList? areaParts = null,
        bool? makeMapScreenshot = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintAreaPreset, BlueprintAreaPresetReference>? overrideAreaPreset = null,
        bool? overrideTimeOfDay = null,
        TimeOfDay? timeOfDay = null)
    {
      var component = new AreaCheckerComponent();
      component.Area = area?.Reference ?? component.Area;
      if (component.Area is null)
      {
        component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      Validate(areaParts);
      component.AreaParts = areaParts ?? component.AreaParts;
      component.MakeMapScreenshot = makeMapScreenshot ?? component.MakeMapScreenshot;
      component.OverrideAreaPreset = overrideAreaPreset?.Reference ?? component.OverrideAreaPreset;
      if (component.OverrideAreaPreset is null)
      {
        component.OverrideAreaPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(null);
      }
      component.OverrideTimeOfDay = overrideTimeOfDay ?? component.OverrideTimeOfDay;
      component.TimeOfDay = timeOfDay ?? component.TimeOfDay;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponCheckerComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Arbiter/Weapon Checker
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="weapon">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponCheckerComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintItemWeapon, BlueprintItemWeaponReference>? weapon = null)
    {
      var component = new WeaponCheckerComponent();
      component.Weapon = weapon?.Reference ?? component.Weapon;
      if (component.Weapon is null)
      {
        component.Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
