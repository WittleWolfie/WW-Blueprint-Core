//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseTrapSettingsRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Modifies <see cref="BlueprintTrapSettingsRoot.m_DefaultPerceptionRadius"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultPerceptionRadius(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_DefaultPerceptionRadius);
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
    /// Modifies <see cref="BlueprintTrapSettingsRoot.m_DisableDCMargin"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableDCMargin(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_DisableDCMargin);
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettings(List<Blueprint<BlueprintTrapSettings, BlueprintTrapSettingsReference>> settings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Settings = settings?.Select(bp => bp.Reference)?.ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSettings(params Blueprint<BlueprintTrapSettings, BlueprintTrapSettingsReference>[] settings)
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSettings(params Blueprint<BlueprintTrapSettings, BlueprintTrapSettingsReference>[] settings)
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
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintTrapSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSettings(Func<BlueprintTrapSettingsReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Settings is null) { return; }
          bp.m_Settings = bp.m_Settings.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTrapSettingsRoot.m_Settings"/>
    /// </summary>
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintTrapSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///
    /// <param name="settings">
    /// <para>
    /// Blueprint of type BlueprintTrapSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintTrapSettingsRoot.EasyDisableDCDelta"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEasyDisableDCDelta(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.EasyDisableDCDelta);
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

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettingsRoot.HardDisableDCDelta"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHardDisableDCDelta(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HardDisableDCDelta);
        });
    }
  }
}
