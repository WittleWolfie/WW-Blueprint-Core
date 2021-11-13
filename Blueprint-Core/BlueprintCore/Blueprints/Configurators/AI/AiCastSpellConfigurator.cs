using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>Configurator for <see cref="BlueprintAiCastSpell"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiCastSpell))]
  public class AiCastSpellConfigurator : BaseAiActionConfigurator<BlueprintAiCastSpell, AiCastSpellConfigurator>
  {
     private AiCastSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiCastSpellConfigurator For(string name)
    {
      return new AiCastSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AiCastSpellConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAiCastSpell>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiCastSpellConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAiCastSpell>(name, assetId);
      return For(name);
    }

  }
}
