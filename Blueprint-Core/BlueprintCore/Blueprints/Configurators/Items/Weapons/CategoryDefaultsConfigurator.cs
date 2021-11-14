using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Weapons;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>Configurator for <see cref="BlueprintCategoryDefaults"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCategoryDefaults))]
  public class CategoryDefaultsConfigurator : BaseBlueprintConfigurator<BlueprintCategoryDefaults, CategoryDefaultsConfigurator>
  {
     private CategoryDefaultsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CategoryDefaultsConfigurator For(string name)
    {
      return new CategoryDefaultsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CategoryDefaultsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCategoryDefaults>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CategoryDefaultsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCategoryDefaults>(name, assetId);
      return For(name);
    }
  }
}
