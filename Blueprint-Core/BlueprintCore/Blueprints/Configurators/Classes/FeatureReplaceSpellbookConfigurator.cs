using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintFeatureReplaceSpellbook"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureReplaceSpellbook))]
  public class FeatureReplaceSpellbookConfigurator : BaseFeatureConfigurator<BlueprintFeatureReplaceSpellbook, FeatureReplaceSpellbookConfigurator>
  {
     private FeatureReplaceSpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureReplaceSpellbookConfigurator For(string name)
    {
      return new FeatureReplaceSpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FeatureReplaceSpellbookConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeatureReplaceSpellbook>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureReplaceSpellbookConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeatureReplaceSpellbook>(name, assetId);
      return For(name);
    }

  }
}
