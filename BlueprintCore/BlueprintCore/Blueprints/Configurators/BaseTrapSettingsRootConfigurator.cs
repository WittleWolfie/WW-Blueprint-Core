//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTrapSettingsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTrapSettingsRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTrapSettingsRoot
    where TBuilder : BaseTrapSettingsRootConfigurator<T, TBuilder>
  {
    protected BaseTrapSettingsRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintTrapSettingsRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DefaultPerceptionRadius = copyFrom.m_DefaultPerceptionRadius;
          bp.m_DisableDCMargin = copyFrom.m_DisableDCMargin;
          bp.m_Settings = copyFrom.m_Settings;
          bp.EasyDisableDCDelta = copyFrom.EasyDisableDCDelta;
          bp.HardDisableDCDelta = copyFrom.HardDisableDCDelta;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettingsRoot.m_DefaultPerceptionRadius"/>
    /// </summary>
    public TBuilder SetDefaultPerceptionRadius(float defaultPerceptionRadius)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultPerceptionRadius = defaultPerceptionRadius;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettingsRoot.m_DisableDCMargin"/>
    /// </summary>
    public TBuilder SetDisableDCMargin(int disableDCMargin)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DisableDCMargin = disableDCMargin;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettingsRoot.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintTrapSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettings(params Blueprint<BlueprintTrapSettingsReference>[] settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = settings.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTrapSettingsRoot.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintTrapSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSettings(params Blueprint<BlueprintTrapSettingsReference>[] settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = bp.m_Settings ?? new BlueprintTrapSettingsReference[0];
          bp.m_Settings = CommonTool.Append(bp.m_Settings, settings.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTrapSettingsRoot.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintTrapSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSettings(params Blueprint<BlueprintTrapSettingsReference>[] settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings = bp.m_Settings.Where(val => !settings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTrapSettingsRoot.m_Settings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSettings(Func<BlueprintTrapSettingsReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings = bp.m_Settings.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTrapSettingsRoot.m_Settings"/>
    /// </summary>
    public TBuilder ClearSettings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = new BlueprintTrapSettingsReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettingsRoot.m_Settings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySettings(Action<BlueprintTrapSettingsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettingsRoot.EasyDisableDCDelta"/>
    /// </summary>
    public TBuilder SetEasyDisableDCDelta(int easyDisableDCDelta)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EasyDisableDCDelta = easyDisableDCDelta;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettingsRoot.HardDisableDCDelta"/>
    /// </summary>
    public TBuilder SetHardDisableDCDelta(int hardDisableDCDelta)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HardDisableDCDelta = hardDisableDCDelta;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Settings is null)
      {
        Blueprint.m_Settings = new BlueprintTrapSettingsReference[0];
      }
    }
  }
}
