using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Crusade.GlobalMagic;

namespace BlueprintCore.Blueprints.Configurators.Crusade.GlobalMagic
{
  /// <summary>Configurator for <see cref="BlueprintGlobalMagicSpell"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMagicSpell))]
  public class GlobalMagicSpellConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMagicSpell, GlobalMagicSpellConfigurator>
  {
     private GlobalMagicSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMagicSpellConfigurator For(string name)
    {
      return new GlobalMagicSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GlobalMagicSpellConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGlobalMagicSpell>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMagicSpellConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGlobalMagicSpell>(name, assetId);
      return For(name);
    }
  }
}
