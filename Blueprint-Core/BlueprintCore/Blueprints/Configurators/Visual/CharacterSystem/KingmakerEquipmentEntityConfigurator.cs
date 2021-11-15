using BlueprintCore.Utils;
using Kingmaker.ResourceLinks;
using Kingmaker.Visual.CharacterSystem;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Visual.CharacterSystem
{
  /// <summary>Configurator for <see cref="KingmakerEquipmentEntity"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(KingmakerEquipmentEntity))]
  public class KingmakerEquipmentEntityConfigurator : BaseBlueprintConfigurator<KingmakerEquipmentEntity, KingmakerEquipmentEntityConfigurator>
  {
     private KingmakerEquipmentEntityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingmakerEquipmentEntityConfigurator For(string name)
    {
      return new KingmakerEquipmentEntityConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingmakerEquipmentEntityConfigurator New(string name)
    {
      BlueprintTool.Create<KingmakerEquipmentEntity>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingmakerEquipmentEntityConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<KingmakerEquipmentEntity>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_MaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator AddToMaleArray(params EquipmentEntityLink[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_MaleArray = CommonTool.Append(bp.m_MaleArray, values));
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_MaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator RemoveFromMaleArray(params EquipmentEntityLink[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_MaleArray = bp.m_MaleArray.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator AddToFemaleArray(params EquipmentEntityLink[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_FemaleArray = CommonTool.Append(bp.m_FemaleArray, values));
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator RemoveFromFemaleArray(params EquipmentEntityLink[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_FemaleArray = bp.m_FemaleArray.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="KingmakerEquipmentEntity.m_RaceDependent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator SetRaceDependent(bool value)
    {
      return OnConfigureInternal(bp => bp.m_RaceDependent = value);
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator AddToRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_RaceDependentArrays = CommonTool.Append(bp.m_RaceDependentArrays, values));
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator RemoveFromRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_RaceDependentArrays = bp.m_RaceDependentArrays.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
