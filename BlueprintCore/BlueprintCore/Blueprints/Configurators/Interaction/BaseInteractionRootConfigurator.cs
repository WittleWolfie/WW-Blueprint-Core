//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Interaction;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Interaction
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintInteractionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseInteractionRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintInteractionRoot
    where TBuilder : BaseInteractionRootConfigurator<T, TBuilder>
  {
    protected BaseInteractionRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintInteractionRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_InteractionDCVariation = copyFrom.m_InteractionDCVariation;
          bp.m_MagicPowerCost = copyFrom.m_MagicPowerCost;
          bp.m_MagicPowerItem = copyFrom.m_MagicPowerItem;
          bp.m_DestructionFx = copyFrom.m_DestructionFx;
          bp.m_FxDenominator = copyFrom.m_FxDenominator;
          bp.m_DefaultDestructionSuccessSound = copyFrom.m_DefaultDestructionSuccessSound;
          bp.m_LockpickStartSound = copyFrom.m_LockpickStartSound;
          bp.m_LockpickEndSound = copyFrom.m_LockpickEndSound;
          bp.m_LockpickSuccessSound = copyFrom.m_LockpickSuccessSound;
          bp.m_LockpickFailSound = copyFrom.m_LockpickFailSound;
          bp.m_LockpickCriticalFailSound = copyFrom.m_LockpickCriticalFailSound;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintInteractionRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_InteractionDCVariation = copyFrom.m_InteractionDCVariation;
          bp.m_MagicPowerCost = copyFrom.m_MagicPowerCost;
          bp.m_MagicPowerItem = copyFrom.m_MagicPowerItem;
          bp.m_DestructionFx = copyFrom.m_DestructionFx;
          bp.m_FxDenominator = copyFrom.m_FxDenominator;
          bp.m_DefaultDestructionSuccessSound = copyFrom.m_DefaultDestructionSuccessSound;
          bp.m_LockpickStartSound = copyFrom.m_LockpickStartSound;
          bp.m_LockpickEndSound = copyFrom.m_LockpickEndSound;
          bp.m_LockpickSuccessSound = copyFrom.m_LockpickSuccessSound;
          bp.m_LockpickFailSound = copyFrom.m_LockpickFailSound;
          bp.m_LockpickCriticalFailSound = copyFrom.m_LockpickCriticalFailSound;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_InteractionDCVariation"/>
    /// </summary>
    public TBuilder SetInteractionDCVariation(int interactionDCVariation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_InteractionDCVariation = interactionDCVariation;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_MagicPowerCost"/>
    /// </summary>
    ///
    /// <param name="magicPowerCost">
    /// <para>
    /// InfoBox: Used to calculate result count after item destruction: Item.Cost / MagicPowerCost = `count of MagicPowerItem`
    /// </para>
    /// </param>
    public TBuilder SetMagicPowerCost(int magicPowerCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MagicPowerCost = magicPowerCost;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_MagicPowerItem"/>
    /// </summary>
    ///
    /// <param name="magicPowerItem">
    /// <para>
    /// InfoBox: Will drop from destroyed items to indicate their cost
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMagicPowerItem(Blueprint<BlueprintItemReference> magicPowerItem)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MagicPowerItem = magicPowerItem?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_MagicPowerItem"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMagicPowerItem(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MagicPowerItem is null) { return; }
          action.Invoke(bp.m_MagicPowerItem);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_DestructionFx"/>
    /// </summary>
    ///
    /// <param name="destructionFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetDestructionFx(AssetLink<PrefabLink> destructionFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DestructionFx = destructionFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_DestructionFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDestructionFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DestructionFx is null) { return; }
          action.Invoke(bp.m_DestructionFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_FxDenominator"/>
    /// </summary>
    ///
    /// <param name="fxDenominator">
    /// <para>
    /// InfoBox: For final Fx scale we use formula: 1 + (ObjectScale - 1) / FxDenominator
    /// </para>
    /// </param>
    public TBuilder SetFxDenominator(float fxDenominator)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FxDenominator = fxDenominator;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_DefaultDestructionSuccessSound"/>
    /// </summary>
    public TBuilder SetDefaultDestructionSuccessSound(string defaultDestructionSuccessSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultDestructionSuccessSound = defaultDestructionSuccessSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_DefaultDestructionSuccessSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultDestructionSuccessSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultDestructionSuccessSound is null) { return; }
          action.Invoke(bp.m_DefaultDestructionSuccessSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_LockpickStartSound"/>
    /// </summary>
    public TBuilder SetLockpickStartSound(string lockpickStartSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LockpickStartSound = lockpickStartSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_LockpickStartSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockpickStartSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LockpickStartSound is null) { return; }
          action.Invoke(bp.m_LockpickStartSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_LockpickEndSound"/>
    /// </summary>
    public TBuilder SetLockpickEndSound(string lockpickEndSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LockpickEndSound = lockpickEndSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_LockpickEndSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockpickEndSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LockpickEndSound is null) { return; }
          action.Invoke(bp.m_LockpickEndSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_LockpickSuccessSound"/>
    /// </summary>
    public TBuilder SetLockpickSuccessSound(string lockpickSuccessSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LockpickSuccessSound = lockpickSuccessSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_LockpickSuccessSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockpickSuccessSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LockpickSuccessSound is null) { return; }
          action.Invoke(bp.m_LockpickSuccessSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_LockpickFailSound"/>
    /// </summary>
    public TBuilder SetLockpickFailSound(string lockpickFailSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LockpickFailSound = lockpickFailSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_LockpickFailSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockpickFailSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LockpickFailSound is null) { return; }
          action.Invoke(bp.m_LockpickFailSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintInteractionRoot.m_LockpickCriticalFailSound"/>
    /// </summary>
    public TBuilder SetLockpickCriticalFailSound(string lockpickCriticalFailSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LockpickCriticalFailSound = lockpickCriticalFailSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintInteractionRoot.m_LockpickCriticalFailSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockpickCriticalFailSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LockpickCriticalFailSound is null) { return; }
          action.Invoke(bp.m_LockpickCriticalFailSound);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_MagicPowerItem is null)
      {
        Blueprint.m_MagicPowerItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      if (Blueprint.m_DestructionFx is null)
      {
        Blueprint.m_DestructionFx = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
