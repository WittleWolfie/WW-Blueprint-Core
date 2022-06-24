//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Cooking
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCookingRecipe"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCookingRecipeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCookingRecipe
    where TBuilder : BaseCookingRecipeConfigurator<T, TBuilder>
  {
    protected BaseCookingRecipeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCookingRecipe.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCookingRecipe.Ingredients"/>
    /// </summary>
    public TBuilder SetIngredients(params BlueprintCookingRecipe.ItemEntry[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(ingredients);
          bp.Ingredients = ingredients;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCookingRecipe.Ingredients"/>
    /// </summary>
    public TBuilder AddToIngredients(params BlueprintCookingRecipe.ItemEntry[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Ingredients = bp.Ingredients ?? new BlueprintCookingRecipe.ItemEntry[0];
          bp.Ingredients = CommonTool.Append(bp.Ingredients, ingredients);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCookingRecipe.Ingredients"/>
    /// </summary>
    public TBuilder RemoveFromIngredients(params BlueprintCookingRecipe.ItemEntry[] ingredients)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Ingredients is null) { return; }
          bp.Ingredients = bp.Ingredients.Where(val => !ingredients.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCookingRecipe.Ingredients"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIngredients(Func<BlueprintCookingRecipe.ItemEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Ingredients is null) { return; }
          bp.Ingredients = bp.Ingredients.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCookingRecipe.Ingredients"/>
    /// </summary>
    public TBuilder ClearIngredients()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Ingredients = new BlueprintCookingRecipe.ItemEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.Ingredients"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIngredients(Action<BlueprintCookingRecipe.ItemEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Ingredients is null) { return; }
          bp.Ingredients.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCookingRecipe.CookingDC"/>
    /// </summary>
    public TBuilder SetCookingDC(int cookingDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CookingDC = cookingDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.CookingDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCookingDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CookingDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCookingRecipe.BuffDurationHours"/>
    /// </summary>
    public TBuilder SetBuffDurationHours(int buffDurationHours)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BuffDurationHours = buffDurationHours;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.BuffDurationHours"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBuffDurationHours(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BuffDurationHours);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCookingRecipe.m_PartyBuffs"/>
    /// </summary>
    ///
    /// <param name="partyBuffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPartyBuffs(params Blueprint<BlueprintBuffReference>[] partyBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PartyBuffs = partyBuffs.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCookingRecipe.m_PartyBuffs"/>
    /// </summary>
    ///
    /// <param name="partyBuffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPartyBuffs(params Blueprint<BlueprintBuffReference>[] partyBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PartyBuffs = bp.m_PartyBuffs ?? new BlueprintBuffReference[0];
          bp.m_PartyBuffs = CommonTool.Append(bp.m_PartyBuffs, partyBuffs.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCookingRecipe.m_PartyBuffs"/>
    /// </summary>
    ///
    /// <param name="partyBuffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPartyBuffs(params Blueprint<BlueprintBuffReference>[] partyBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PartyBuffs is null) { return; }
          bp.m_PartyBuffs = bp.m_PartyBuffs.Where(val => !partyBuffs.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPartyBuffs(Func<BlueprintBuffReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PartyBuffs is null) { return; }
          bp.m_PartyBuffs = bp.m_PartyBuffs.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCookingRecipe.m_PartyBuffs"/>
    /// </summary>
    public TBuilder ClearPartyBuffs()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PartyBuffs = new BlueprintBuffReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPartyBuffs(Action<BlueprintBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PartyBuffs is null) { return; }
          bp.m_PartyBuffs.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCookingRecipe.UnitBuffs"/>
    /// </summary>
    public TBuilder SetUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] unitBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(unitBuffs);
          bp.UnitBuffs = unitBuffs;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCookingRecipe.UnitBuffs"/>
    /// </summary>
    public TBuilder AddToUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] unitBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitBuffs = bp.UnitBuffs ?? new BlueprintCookingRecipe.UnitBuffEntry[0];
          bp.UnitBuffs = CommonTool.Append(bp.UnitBuffs, unitBuffs);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCookingRecipe.UnitBuffs"/>
    /// </summary>
    public TBuilder RemoveFromUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] unitBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitBuffs is null) { return; }
          bp.UnitBuffs = bp.UnitBuffs.Where(val => !unitBuffs.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCookingRecipe.UnitBuffs"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitBuffs(Func<BlueprintCookingRecipe.UnitBuffEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitBuffs is null) { return; }
          bp.UnitBuffs = bp.UnitBuffs.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCookingRecipe.UnitBuffs"/>
    /// </summary>
    public TBuilder ClearUnitBuffs()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitBuffs = new BlueprintCookingRecipe.UnitBuffEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCookingRecipe.UnitBuffs"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitBuffs(Action<BlueprintCookingRecipe.UnitBuffEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitBuffs is null) { return; }
          bp.UnitBuffs.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.Ingredients is null)
      {
        Blueprint.Ingredients = new BlueprintCookingRecipe.ItemEntry[0];
      }
      if (Blueprint.m_PartyBuffs is null)
      {
        Blueprint.m_PartyBuffs = new BlueprintBuffReference[0];
      }
      if (Blueprint.UnitBuffs is null)
      {
        Blueprint.UnitBuffs = new BlueprintCookingRecipe.UnitBuffEntry[0];
      }
    }
  }
}
