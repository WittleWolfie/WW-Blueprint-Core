//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
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
    protected BaseMythicInfoConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintMythicInfo>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp._mythic = copyFrom._mythic;
          bp._etudeReference = copyFrom._etudeReference;
          bp._mythicName = copyFrom._mythicName;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintMythicInfo>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp._mythic = copyFrom._mythic;
          bp._etudeReference = copyFrom._etudeReference;
          bp._mythicName = copyFrom._mythicName;
        });
    }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder Set_etudeReference(Blueprint<BlueprintEtudeReference> _etudeReference)
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
    ///
    /// <param name="_mythicName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder Set_mythicName(LocalString _mythicName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp._mythicName = _mythicName?.LocalizedString;
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint._etudeReference is null)
      {
        Blueprint._etudeReference = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      if (Blueprint._mythicName is null)
      {
        Blueprint._mythicName = Utils.Constants.Empty.String;
      }
    }
  }
}
