//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMythicInfo"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMythicInfoConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintMythicInfo
    where TBuilder : BaseMythicInfoConfigurator<T, TBuilder>
  {
    protected BaseMythicInfoConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicInfo._mythic"/>
    /// </summary>
    public TBuilder Set_mythic(Mythic _mythic)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp._mythic = _mythic;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicInfo._mythic"/> by invoking the provided action.
    /// </summary>
    public TBuilder Modify_mythic(Action<Mythic> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp._mythic);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicInfo._etudeReference"/>
    /// </summary>
    ///
    /// <param name="_etudeReference">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder Set_etudeReference(Blueprint<BlueprintEtude, BlueprintEtudeReference> _etudeReference)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp._etudeReference = _etudeReference?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicInfo._etudeReference"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="_etudeReference">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder Modify_etudeReference(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp._etudeReference is null) { return; }
          action.Invoke(bp._etudeReference);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicInfo._mythicName"/>
    /// </summary>
    public TBuilder Set_mythicName(LocalizedString _mythicName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp._mythicName = _mythicName;
          if (bp._mythicName is null)
          {
            bp._mythicName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicInfo._mythicName"/> by invoking the provided action.
    /// </summary>
    public TBuilder Modify_mythicName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp._mythicName is null) { return; }
          action.Invoke(bp._mythicName);
        });
    }
  }
}
