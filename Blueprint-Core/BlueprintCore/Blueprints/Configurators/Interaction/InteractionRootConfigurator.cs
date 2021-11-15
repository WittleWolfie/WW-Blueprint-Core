using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Interaction;
using Kingmaker.ResourceLinks;

namespace BlueprintCore.Blueprints.Configurators.Interaction
{
  /// <summary>Configurator for <see cref="BlueprintInteractionRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintInteractionRoot))]
  public class InteractionRootConfigurator : BaseBlueprintConfigurator<BlueprintInteractionRoot, InteractionRootConfigurator>
  {
     private InteractionRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static InteractionRootConfigurator For(string name)
    {
      return new InteractionRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static InteractionRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintInteractionRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static InteractionRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintInteractionRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_InteractionDCVariation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetInteractionDCVariation(int value)
    {
      return OnConfigureInternal(bp => bp.m_InteractionDCVariation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_MagicPowerCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetMagicPowerCost(int value)
    {
      return OnConfigureInternal(bp => bp.m_MagicPowerCost = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_MagicPowerItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public InteractionRootConfigurator SetMagicPowerItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_MagicPowerItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_DestructionFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetDestructionFx(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DestructionFx = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_FxDenominator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetFxDenominator(float value)
    {
      return OnConfigureInternal(bp => bp.m_FxDenominator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_DefaultDestructionSuccessSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetDefaultDestructionSuccessSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DefaultDestructionSuccessSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickStartSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickStartSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LockpickStartSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickEndSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickEndSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LockpickEndSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickSuccessSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickSuccessSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LockpickSuccessSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickFailSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickFailSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LockpickFailSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickCriticalFailSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickCriticalFailSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LockpickCriticalFailSound = value);
    }
  }
}
