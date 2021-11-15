using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="MoraleRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(MoraleRoot))]
  public class MoraleRootConfigurator : BaseBlueprintConfigurator<MoraleRoot, MoraleRootConfigurator>
  {
     private MoraleRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MoraleRootConfigurator For(string name)
    {
      return new MoraleRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MoraleRootConfigurator New(string name)
    {
      BlueprintTool.Create<MoraleRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MoraleRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<MoraleRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_MoraleBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetMoraleBorder(Vector2Int value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MoraleBorder = value);
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_DevineForNegative"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetDevineForNegative(float value)
    {
      return OnConfigureInternal(bp => bp.m_DevineForNegative = value);
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_DevineForPositive"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetDevineForPositive(float value)
    {
      return OnConfigureInternal(bp => bp.m_DevineForPositive = value);
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_NegativeFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public MoraleRootConfigurator AddToNegativeFacts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_NegativeFacts = CommonTool.Append(bp.m_NegativeFacts, values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_NegativeFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public MoraleRootConfigurator RemoveFromNegativeFacts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_NegativeFacts =
                bp.m_NegativeFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_GlobalArmiesMoraleBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomBuff"/></param>
    [Generated]
    public MoraleRootConfigurator SetGlobalArmiesMoraleBuff(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalArmiesMoraleBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(value));
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.BaseMoraleValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetBaseMoraleValue(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.BaseMoraleValue = value);
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.ArmyEffectOnSquad"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetArmyEffectOnSquad(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ArmyEffectOnSquad = value);
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.UnitNotHaveMorale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetUnitNotHaveMorale(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UnitNotHaveMorale = value);
    }
  }
}
