using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.EntitySystem.Persistence.Versioning;

namespace BlueprintCore.Blueprints.Configurators.EntitySystem.Persistence.Versioning
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnitUpgrader"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitUpgrader))]
  public class UnitUpgraderConfigurator : BaseBlueprintConfigurator<BlueprintUnitUpgrader, UnitUpgraderConfigurator>
  {
    private UnitUpgraderConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitUpgraderConfigurator For(string name)
    {
      return new UnitUpgraderConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitUpgraderConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitUpgrader>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitUpgraderConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitUpgrader>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitUpgrader.Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitUpgraderConfigurator SetActions(ActionsBuilder actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Actions = actions?.Build() ?? Constants.Empty.Actions;
          });
    }
  }
}
