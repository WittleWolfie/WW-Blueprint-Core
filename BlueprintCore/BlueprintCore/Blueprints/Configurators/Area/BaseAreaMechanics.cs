//***** AUTO-GENERATED - DO NOT EDIT *****//

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
    protected BaseAreaMechanicsConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArea(Blueprint<BlueprintArea, BlueprintAreaReference> area)
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
  }
}
