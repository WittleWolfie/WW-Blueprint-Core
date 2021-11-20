using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="CanUseSpellCombatConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CanUseSpellCombatConsideration))]
  public class CanUseSpellCombatConsiderationConfigurator : BaseConsiderationConfigurator<CanUseSpellCombatConsideration, CanUseSpellCombatConsiderationConfigurator>
  {
    private CanUseSpellCombatConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CanUseSpellCombatConsiderationConfigurator For(string name)
    {
      return new CanUseSpellCombatConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CanUseSpellCombatConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<CanUseSpellCombatConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CanUseSpellCombatConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<CanUseSpellCombatConsideration>(name, assetId);
      return For(name);
    }
  }
}
