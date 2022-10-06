//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Sound;
using System;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaMechanics"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaMechanicsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaMechanics
    where TBuilder : BaseAreaMechanicsConfigurator<T, TBuilder>
  {
    protected BaseAreaMechanicsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaMechanics>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Area = copyFrom.Area;
          bp.Scene = copyFrom.Scene;
          bp.AdditionalDataBank = copyFrom.AdditionalDataBank;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaMechanics>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Area = copyFrom.Area;
          bp.Scene = copyFrom.Scene;
          bp.AdditionalDataBank = copyFrom.AdditionalDataBank;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaMechanics.Area"/>
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
          bp.Area = area?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaMechanics.Area"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArea(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Area is null) { return; }
          action.Invoke(bp.Area);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaMechanics.Scene"/>
    /// </summary>
    public TBuilder SetScene(SceneReference scene)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(scene);
          bp.Scene = scene;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaMechanics.Scene"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyScene(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Scene is null) { return; }
          action.Invoke(bp.Scene);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaMechanics.AdditionalDataBank"/>
    /// </summary>
    public TBuilder SetAdditionalDataBank(AkBankReference additionalDataBank)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(additionalDataBank);
          bp.AdditionalDataBank = additionalDataBank;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaMechanics.AdditionalDataBank"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAdditionalDataBank(Action<AkBankReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AdditionalDataBank is null) { return; }
          action.Invoke(bp.AdditionalDataBank);
        });
    }

    /// <summary>
    /// Adds <see cref="AdditionalPreloadComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Prologue_Kenabres_CitizenIdle</term><description>bffcc04cd70a5db44b1d8c1477b10cc9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="resources">
    /// <para>
    /// Blueprint of type ResourceListForPreload. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AdditionalPreloadComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<ResourceListForPreload.Ref>? resources = null)
    {
      var component = new AdditionalPreloadComponent();
      component.Resources = resources?.Reference ?? component.Resources;
      if (component.Resources is null)
      {
        component.Resources = BlueprintTool.GetRef<ResourceListForPreload.Ref>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Area is null)
      {
        Blueprint.Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
    }
  }
}
