using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Armors;
namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>Configurator for <see cref="BlueprintShieldType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintShieldType))]
  public class ShieldTypeConfigurator : BaseArmorTypeConfigurator<BlueprintShieldType, ShieldTypeConfigurator>
  {
     private ShieldTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ShieldTypeConfigurator For(string name)
    {
      return new ShieldTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ShieldTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintShieldType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ShieldTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintShieldType>(name, assetId);
      return For(name);
    }

  }
}
