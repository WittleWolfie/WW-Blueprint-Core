using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintFeatureSelectMythicSpellbook"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureSelectMythicSpellbook))]
  public class FeatureSelectMythicSpellbookConfigurator : BaseFeatureConfigurator<BlueprintFeatureSelectMythicSpellbook, FeatureSelectMythicSpellbookConfigurator>
  {
     private FeatureSelectMythicSpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureSelectMythicSpellbookConfigurator For(string name)
    {
      return new FeatureSelectMythicSpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FeatureSelectMythicSpellbookConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeatureSelectMythicSpellbook>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureSelectMythicSpellbookConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeatureSelectMythicSpellbook>(name, assetId);
      return For(name);
    }
  }
}
