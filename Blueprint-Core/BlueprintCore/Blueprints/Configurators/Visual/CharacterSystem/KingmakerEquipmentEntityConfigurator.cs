using BlueprintCore.Utils;
using Kingmaker.Visual.CharacterSystem;

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
  }
}
