using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Shields;
namespace BlueprintCore.Blueprints.Configurators.Items.Shields
{
  /// <summary>Configurator for <see cref="BlueprintItemShield"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemShield))]
  public class ItemShieldConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemShield, ItemShieldConfigurator>
  {
     private ItemShieldConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemShieldConfigurator For(string name)
    {
      return new ItemShieldConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemShieldConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemShield>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemShieldConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemShield>(name, assetId);
      return For(name);
    }

  }
}
