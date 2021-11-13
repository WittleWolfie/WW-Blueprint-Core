using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.ActivatableAbilities;
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities
{
  /// <summary>Configurator for <see cref="BlueprintActivatableAbility"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintActivatableAbility))]
  public class ActivatableAbilityConfigurator : BaseUnitFactConfigurator<BlueprintActivatableAbility, ActivatableAbilityConfigurator>
  {
     private ActivatableAbilityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActivatableAbilityConfigurator For(string name)
    {
      return new ActivatableAbilityConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ActivatableAbilityConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintActivatableAbility>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActivatableAbilityConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintActivatableAbility>(name, assetId);
      return For(name);
    }

  }
}
