using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintUnitType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitType))]
  public class UnitTypeConfigurator : BaseBlueprintConfigurator<BlueprintUnitType, UnitTypeConfigurator>
  {
     private UnitTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitTypeConfigurator For(string name)
    {
      return new UnitTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitType>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.KnowledgeStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetKnowledgeStat(StatType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.KnowledgeStat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.Image"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetImage(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Image = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitTypeConfigurator AddToSignatureAbilities(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_SignatureAbilities = CommonTool.Append(bp.m_SignatureAbilities, values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitTypeConfigurator RemoveFromSignatureAbilities(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_SignatureAbilities =
                bp.m_SignatureAbilities
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
