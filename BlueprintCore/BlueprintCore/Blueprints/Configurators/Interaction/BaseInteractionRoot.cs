//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Interaction;
using Kingmaker.ResourceLinks;
using System;

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
    protected BaseInteractionRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Modifies <see cref="BlueprintInteractionRoot.m_InteractionDCVariation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInteractionDCVariation(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_InteractionDCVariation);
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
    /// Modifies <see cref="BlueprintInteractionRoot.m_MagicPowerCost"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="magicPowerCost">
    /// <para>
    /// InfoBox: Used to calculate result count after item destruction: Item.Cost / MagicPowerCost = `count of MagicPowerItem`
    /// </para>
    /// </param>
    public TBuilder ModifyMagicPowerCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MagicPowerCost);
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMagicPowerItem(Blueprint<BlueprintItem, BlueprintItemReference> magicPowerItem)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    public TBuilder SetDestructionFx(PrefabLink destructionFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DestructionFx = destructionFx;
          if (bp.m_DestructionFx is null)
          {
            bp.m_DestructionFx = Utils.Constants.Empty.PrefabLink;
          }
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
    /// Modifies <see cref="BlueprintInteractionRoot.m_FxDenominator"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="fxDenominator">
    /// <para>
    /// InfoBox: For final Fx scale we use formula: 1 + (ObjectScale - 1) / FxDenominator
    /// </para>
    /// </param>
    public TBuilder ModifyFxDenominator(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_FxDenominator);
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
  }
}
