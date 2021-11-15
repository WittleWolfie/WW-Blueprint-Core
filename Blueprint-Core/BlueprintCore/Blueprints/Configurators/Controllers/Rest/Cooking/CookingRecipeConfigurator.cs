using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Controllers.Rest.Cooking
{
  /// <summary>Configurator for <see cref="BlueprintCookingRecipe"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCookingRecipe))]
  public class CookingRecipeConfigurator : BaseBlueprintConfigurator<BlueprintCookingRecipe, CookingRecipeConfigurator>
  {
     private CookingRecipeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CookingRecipeConfigurator For(string name)
    {
      return new CookingRecipeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CookingRecipeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCookingRecipe>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CookingRecipeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCookingRecipe>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator AddToIngredients(params BlueprintCookingRecipe.ItemEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Ingredients = CommonTool.Append(bp.Ingredients, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator RemoveFromIngredients(params BlueprintCookingRecipe.ItemEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Ingredients = bp.Ingredients.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.CookingDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetCookingDC(int value)
    {
      return OnConfigureInternal(bp => bp.CookingDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.BuffDurationHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetBuffDurationHours(int value)
    {
      return OnConfigureInternal(bp => bp.BuffDurationHours = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintBuff"/></param>
    [Generated]
    public CookingRecipeConfigurator AddToPartyBuffs(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_PartyBuffs = CommonTool.Append(bp.m_PartyBuffs, values.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintBuff"/></param>
    [Generated]
    public CookingRecipeConfigurator RemoveFromPartyBuffs(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name));
            bp.m_PartyBuffs =
                bp.m_PartyBuffs
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.UnitBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator AddToUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitBuffs = CommonTool.Append(bp.UnitBuffs, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.UnitBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator RemoveFromUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitBuffs = bp.UnitBuffs.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
