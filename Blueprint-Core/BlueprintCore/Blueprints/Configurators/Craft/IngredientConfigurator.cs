using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Utils;
using Kingmaker.Craft;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>
  /// Configurator for <see cref="BlueprintIngredient"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintIngredient))]
  public class IngredientConfigurator : BaseItemConfigurator<BlueprintIngredient, IngredientConfigurator>
  {
    private IngredientConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static IngredientConfigurator For(string name)
    {
      return new IngredientConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static IngredientConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintIngredient>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static IngredientConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintIngredient>(name, assetId);
      return For(name);
    }
  }
}
