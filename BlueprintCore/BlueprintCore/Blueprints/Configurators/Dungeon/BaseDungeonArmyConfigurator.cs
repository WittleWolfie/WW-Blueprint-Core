//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Enums;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonArmy"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonArmyConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonArmy
    where TBuilder : BaseDungeonArmyConfigurator<T, TBuilder>
  {
    protected BaseDungeonArmyConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonArmy>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ProbabilityWeight = copyFrom.m_ProbabilityWeight;
          bp.LimitMaxRooms = copyFrom.LimitMaxRooms;
          bp.MaxRooms = copyFrom.MaxRooms;
          bp.OverrideUnitsCount = copyFrom.OverrideUnitsCount;
          bp.UnitsCount = copyFrom.UnitsCount;
          bp.LimitMinStage = copyFrom.LimitMinStage;
          bp.MinStage = copyFrom.MinStage;
          bp.LimitMaxStage = copyFrom.LimitMaxStage;
          bp.MaxStage = copyFrom.MaxStage;
          bp.m_Tiers = copyFrom.m_Tiers;
          bp.m_MinDifficulty = copyFrom.m_MinDifficulty;
          bp.m_MaxDifficulty = copyFrom.m_MaxDifficulty;
          bp.m_Themes = copyFrom.m_Themes;
          bp.m_ModificatorsInclude = copyFrom.m_ModificatorsInclude;
          bp.m_ModificatorsExclude = copyFrom.m_ModificatorsExclude;
          bp.m_SettingsInclude = copyFrom.m_SettingsInclude;
          bp.m_SettingsExclude = copyFrom.m_SettingsExclude;
          bp.m_IncludeTags = copyFrom.m_IncludeTags;
          bp.m_ExcludeTags = copyFrom.m_ExcludeTags;
          bp.m_ExcludeUnits = copyFrom.m_ExcludeUnits;
          bp.m_IncludeUnits = copyFrom.m_IncludeUnits;
          bp.Units = copyFrom.Units;
          bp.PseudoCRUnits = copyFrom.PseudoCRUnits;
          bp.PseudoCRMultiplier = copyFrom.PseudoCRMultiplier;
          bp.m_CrUnitsFromPseudoCR = copyFrom.m_CrUnitsFromPseudoCR;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_ProbabilityWeight"/>
    /// </summary>
    ///
    /// <param name="probabilityWeight">
    /// <para>
    /// Tooltip: The weightened probability to use this army.
    /// </para>
    /// </param>
    public TBuilder SetProbabilityWeight(float probabilityWeight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ProbabilityWeight = probabilityWeight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.LimitMaxRooms"/>
    /// </summary>
    public TBuilder SetLimitMaxRooms(bool limitMaxRooms = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LimitMaxRooms = limitMaxRooms;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.MaxRooms"/>
    /// </summary>
    ///
    /// <param name="maxRooms">
    /// <para>
    /// Tooltip: Limit the rooms count where the army may simultaneously be used.
    /// </para>
    /// </param>
    public TBuilder SetMaxRooms(int maxRooms)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxRooms = maxRooms;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.OverrideUnitsCount"/>
    /// </summary>
    public TBuilder SetOverrideUnitsCount(bool overrideUnitsCount = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideUnitsCount = overrideUnitsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.UnitsCount"/>
    /// </summary>
    public TBuilder SetUnitsCount(params IntegerWeighted[] unitsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(unitsCount);
          bp.UnitsCount = unitsCount;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.UnitsCount"/>
    /// </summary>
    public TBuilder AddToUnitsCount(params IntegerWeighted[] unitsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitsCount = bp.UnitsCount ?? new IntegerWeighted[0];
          bp.UnitsCount = CommonTool.Append(bp.UnitsCount, unitsCount);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.UnitsCount"/>
    /// </summary>
    public TBuilder RemoveFromUnitsCount(params IntegerWeighted[] unitsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitsCount is null) { return; }
          bp.UnitsCount = bp.UnitsCount.Where(val => !unitsCount.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.UnitsCount"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitsCount(Func<IntegerWeighted, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitsCount is null) { return; }
          bp.UnitsCount = bp.UnitsCount.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.UnitsCount"/>
    /// </summary>
    public TBuilder ClearUnitsCount()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitsCount = new IntegerWeighted[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.UnitsCount"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitsCount(Action<IntegerWeighted> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitsCount is null) { return; }
          bp.UnitsCount.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.LimitMinStage"/>
    /// </summary>
    public TBuilder SetLimitMinStage(bool limitMinStage = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LimitMinStage = limitMinStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.MinStage"/>
    /// </summary>
    ///
    /// <param name="minStage">
    /// <para>
    /// Tooltip: This army should appear not before this stage.
    /// </para>
    /// </param>
    public TBuilder SetMinStage(int minStage)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinStage = minStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.LimitMaxStage"/>
    /// </summary>
    public TBuilder SetLimitMaxStage(bool limitMaxStage = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LimitMaxStage = limitMaxStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.MaxStage"/>
    /// </summary>
    ///
    /// <param name="maxStage">
    /// <para>
    /// Tooltip: This army should appear not after this stage.
    /// </para>
    /// </param>
    public TBuilder SetMaxStage(int maxStage)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxStage = maxStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Tooltip: This army should appear only in these tiers.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = tiers.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Tooltip: This army should appear only in these tiers.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = bp.m_Tiers ?? new BlueprintDungeonTierReference[0];
          bp.m_Tiers = CommonTool.Append(bp.m_Tiers, tiers.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Tooltip: This army should appear only in these tiers.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(val => !tiers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_Tiers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTiers(Func<BlueprintDungeonTierReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_Tiers"/>
    /// </summary>
    public TBuilder ClearTiers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = new BlueprintDungeonTierReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_Tiers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTiers(Action<BlueprintDungeonTierReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_MinDifficulty"/>
    /// </summary>
    public TBuilder SetMinDifficulty(DungeonDifficulty minDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MinDifficulty = minDifficulty;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_MaxDifficulty"/>
    /// </summary>
    public TBuilder SetMaxDifficulty(DungeonDifficulty maxDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxDifficulty = maxDifficulty;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_Themes"/>
    /// </summary>
    ///
    /// <param name="themes">
    /// <para>
    /// Blueprint of type BlueprintDungeonTheme. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetThemes(params Blueprint<BlueprintDungeonThemeReference>[] themes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Themes = themes.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_Themes"/>
    /// </summary>
    ///
    /// <param name="themes">
    /// <para>
    /// Blueprint of type BlueprintDungeonTheme. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToThemes(params Blueprint<BlueprintDungeonThemeReference>[] themes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Themes = bp.m_Themes ?? new BlueprintDungeonThemeReference[0];
          bp.m_Themes = CommonTool.Append(bp.m_Themes, themes.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_Themes"/>
    /// </summary>
    ///
    /// <param name="themes">
    /// <para>
    /// Blueprint of type BlueprintDungeonTheme. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromThemes(params Blueprint<BlueprintDungeonThemeReference>[] themes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Themes is null) { return; }
          bp.m_Themes = bp.m_Themes.Where(val => !themes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_Themes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromThemes(Func<BlueprintDungeonThemeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Themes is null) { return; }
          bp.m_Themes = bp.m_Themes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_Themes"/>
    /// </summary>
    public TBuilder ClearThemes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Themes = new BlueprintDungeonThemeReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_Themes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyThemes(Action<BlueprintDungeonThemeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Themes is null) { return; }
          bp.m_Themes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_ModificatorsInclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsInclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetModificatorsInclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsInclude = modificatorsInclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_ModificatorsInclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsInclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToModificatorsInclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsInclude = bp.m_ModificatorsInclude ?? new BlueprintDungeonModificatorReference[0];
          bp.m_ModificatorsInclude = CommonTool.Append(bp.m_ModificatorsInclude, modificatorsInclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ModificatorsInclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsInclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromModificatorsInclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsInclude is null) { return; }
          bp.m_ModificatorsInclude = bp.m_ModificatorsInclude.Where(val => !modificatorsInclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ModificatorsInclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromModificatorsInclude(Func<BlueprintDungeonModificatorReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsInclude is null) { return; }
          bp.m_ModificatorsInclude = bp.m_ModificatorsInclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_ModificatorsInclude"/>
    /// </summary>
    public TBuilder ClearModificatorsInclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsInclude = new BlueprintDungeonModificatorReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_ModificatorsInclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyModificatorsInclude(Action<BlueprintDungeonModificatorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsInclude is null) { return; }
          bp.m_ModificatorsInclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_ModificatorsExclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsExclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetModificatorsExclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsExclude = modificatorsExclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_ModificatorsExclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsExclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToModificatorsExclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsExclude = bp.m_ModificatorsExclude ?? new BlueprintDungeonModificatorReference[0];
          bp.m_ModificatorsExclude = CommonTool.Append(bp.m_ModificatorsExclude, modificatorsExclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ModificatorsExclude"/>
    /// </summary>
    ///
    /// <param name="modificatorsExclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island modificators.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromModificatorsExclude(params Blueprint<BlueprintDungeonModificatorReference>[] modificatorsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsExclude is null) { return; }
          bp.m_ModificatorsExclude = bp.m_ModificatorsExclude.Where(val => !modificatorsExclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ModificatorsExclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromModificatorsExclude(Func<BlueprintDungeonModificatorReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsExclude is null) { return; }
          bp.m_ModificatorsExclude = bp.m_ModificatorsExclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_ModificatorsExclude"/>
    /// </summary>
    public TBuilder ClearModificatorsExclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorsExclude = new BlueprintDungeonModificatorReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_ModificatorsExclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyModificatorsExclude(Action<BlueprintDungeonModificatorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ModificatorsExclude is null) { return; }
          bp.m_ModificatorsExclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_SettingsInclude"/>
    /// </summary>
    ///
    /// <param name="settingsInclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island settings.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettingsInclude(params Blueprint<BlueprintDungeonSettingReference>[] settingsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingsInclude = settingsInclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_SettingsInclude"/>
    /// </summary>
    ///
    /// <param name="settingsInclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island settings.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSettingsInclude(params Blueprint<BlueprintDungeonSettingReference>[] settingsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingsInclude = bp.m_SettingsInclude ?? new BlueprintDungeonSettingReference[0];
          bp.m_SettingsInclude = CommonTool.Append(bp.m_SettingsInclude, settingsInclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_SettingsInclude"/>
    /// </summary>
    ///
    /// <param name="settingsInclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island settings.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSettingsInclude(params Blueprint<BlueprintDungeonSettingReference>[] settingsInclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingsInclude is null) { return; }
          bp.m_SettingsInclude = bp.m_SettingsInclude.Where(val => !settingsInclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_SettingsInclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSettingsInclude(Func<BlueprintDungeonSettingReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingsInclude is null) { return; }
          bp.m_SettingsInclude = bp.m_SettingsInclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_SettingsInclude"/>
    /// </summary>
    public TBuilder ClearSettingsInclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingsInclude = new BlueprintDungeonSettingReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_SettingsInclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySettingsInclude(Action<BlueprintDungeonSettingReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingsInclude is null) { return; }
          bp.m_SettingsInclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_SettingsExclude"/>
    /// </summary>
    ///
    /// <param name="settingsExclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island settings.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSettingsExclude(params Blueprint<BlueprintDungeonSettingReference>[] settingsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingsExclude = settingsExclude.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_SettingsExclude"/>
    /// </summary>
    ///
    /// <param name="settingsExclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island settings.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSettingsExclude(params Blueprint<BlueprintDungeonSettingReference>[] settingsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingsExclude = bp.m_SettingsExclude ?? new BlueprintDungeonSettingReference[0];
          bp.m_SettingsExclude = CommonTool.Append(bp.m_SettingsExclude, settingsExclude.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_SettingsExclude"/>
    /// </summary>
    ///
    /// <param name="settingsExclude">
    /// <para>
    /// Tooltip: Restrict this army to specific island settings.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonSetting. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSettingsExclude(params Blueprint<BlueprintDungeonSettingReference>[] settingsExclude)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingsExclude is null) { return; }
          bp.m_SettingsExclude = bp.m_SettingsExclude.Where(val => !settingsExclude.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_SettingsExclude"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSettingsExclude(Func<BlueprintDungeonSettingReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingsExclude is null) { return; }
          bp.m_SettingsExclude = bp.m_SettingsExclude.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_SettingsExclude"/>
    /// </summary>
    public TBuilder ClearSettingsExclude()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SettingsExclude = new BlueprintDungeonSettingReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_SettingsExclude"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySettingsExclude(Action<BlueprintDungeonSettingReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SettingsExclude is null) { return; }
          bp.m_SettingsExclude.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_IncludeTags"/>
    /// </summary>
    public TBuilder SetIncludeTags(params UnitTag[] includeTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeTags = includeTags;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_IncludeTags"/>
    /// </summary>
    public TBuilder AddToIncludeTags(params UnitTag[] includeTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeTags = bp.m_IncludeTags ?? new UnitTag[0];
          bp.m_IncludeTags = CommonTool.Append(bp.m_IncludeTags, includeTags);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_IncludeTags"/>
    /// </summary>
    public TBuilder RemoveFromIncludeTags(params UnitTag[] includeTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeTags is null) { return; }
          bp.m_IncludeTags = bp.m_IncludeTags.Where(val => !includeTags.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_IncludeTags"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIncludeTags(Func<UnitTag, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeTags is null) { return; }
          bp.m_IncludeTags = bp.m_IncludeTags.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_IncludeTags"/>
    /// </summary>
    public TBuilder ClearIncludeTags()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeTags = new UnitTag[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_IncludeTags"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIncludeTags(Action<UnitTag> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeTags is null) { return; }
          bp.m_IncludeTags.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_ExcludeTags"/>
    /// </summary>
    public TBuilder SetExcludeTags(params UnitTag[] excludeTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcludeTags = excludeTags;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_ExcludeTags"/>
    /// </summary>
    public TBuilder AddToExcludeTags(params UnitTag[] excludeTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcludeTags = bp.m_ExcludeTags ?? new UnitTag[0];
          bp.m_ExcludeTags = CommonTool.Append(bp.m_ExcludeTags, excludeTags);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ExcludeTags"/>
    /// </summary>
    public TBuilder RemoveFromExcludeTags(params UnitTag[] excludeTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcludeTags is null) { return; }
          bp.m_ExcludeTags = bp.m_ExcludeTags.Where(val => !excludeTags.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ExcludeTags"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromExcludeTags(Func<UnitTag, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcludeTags is null) { return; }
          bp.m_ExcludeTags = bp.m_ExcludeTags.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_ExcludeTags"/>
    /// </summary>
    public TBuilder ClearExcludeTags()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcludeTags = new UnitTag[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_ExcludeTags"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyExcludeTags(Action<UnitTag> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcludeTags is null) { return; }
          bp.m_ExcludeTags.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_ExcludeUnits"/>
    /// </summary>
    ///
    /// <param name="excludeUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExcludeUnits(params Blueprint<BlueprintUnitReference>[] excludeUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcludeUnits = excludeUnits.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_ExcludeUnits"/>
    /// </summary>
    ///
    /// <param name="excludeUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToExcludeUnits(params Blueprint<BlueprintUnitReference>[] excludeUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcludeUnits = bp.m_ExcludeUnits ?? new BlueprintUnitReference[0];
          bp.m_ExcludeUnits = CommonTool.Append(bp.m_ExcludeUnits, excludeUnits.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ExcludeUnits"/>
    /// </summary>
    ///
    /// <param name="excludeUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromExcludeUnits(params Blueprint<BlueprintUnitReference>[] excludeUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcludeUnits is null) { return; }
          bp.m_ExcludeUnits = bp.m_ExcludeUnits.Where(val => !excludeUnits.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_ExcludeUnits"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromExcludeUnits(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcludeUnits is null) { return; }
          bp.m_ExcludeUnits = bp.m_ExcludeUnits.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_ExcludeUnits"/>
    /// </summary>
    public TBuilder ClearExcludeUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcludeUnits = new BlueprintUnitReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_ExcludeUnits"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyExcludeUnits(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcludeUnits is null) { return; }
          bp.m_ExcludeUnits.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_IncludeUnits"/>
    /// </summary>
    ///
    /// <param name="includeUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetIncludeUnits(params Blueprint<BlueprintUnitReference>[] includeUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeUnits = includeUnits.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.m_IncludeUnits"/>
    /// </summary>
    ///
    /// <param name="includeUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToIncludeUnits(params Blueprint<BlueprintUnitReference>[] includeUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeUnits = bp.m_IncludeUnits ?? new BlueprintUnitReference[0];
          bp.m_IncludeUnits = CommonTool.Append(bp.m_IncludeUnits, includeUnits.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_IncludeUnits"/>
    /// </summary>
    ///
    /// <param name="includeUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromIncludeUnits(params Blueprint<BlueprintUnitReference>[] includeUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeUnits is null) { return; }
          bp.m_IncludeUnits = bp.m_IncludeUnits.Where(val => !includeUnits.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.m_IncludeUnits"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIncludeUnits(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeUnits is null) { return; }
          bp.m_IncludeUnits = bp.m_IncludeUnits.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.m_IncludeUnits"/>
    /// </summary>
    public TBuilder ClearIncludeUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeUnits = new BlueprintUnitReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_IncludeUnits"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIncludeUnits(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeUnits is null) { return; }
          bp.m_IncludeUnits.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.Units"/>
    /// </summary>
    public TBuilder SetUnits(params BlueprintDungeonArmy.CrUnits[] units)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(units);
          bp.Units = units;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.Units"/>
    /// </summary>
    public TBuilder AddToUnits(params BlueprintDungeonArmy.CrUnits[] units)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Units = bp.Units ?? new BlueprintDungeonArmy.CrUnits[0];
          bp.Units = CommonTool.Append(bp.Units, units);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.Units"/>
    /// </summary>
    public TBuilder RemoveFromUnits(params BlueprintDungeonArmy.CrUnits[] units)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Units is null) { return; }
          bp.Units = bp.Units.Where(val => !units.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.Units"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnits(Func<BlueprintDungeonArmy.CrUnits, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Units is null) { return; }
          bp.Units = bp.Units.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.Units"/>
    /// </summary>
    public TBuilder ClearUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Units = new BlueprintDungeonArmy.CrUnits[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.Units"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnits(Action<BlueprintDungeonArmy.CrUnits> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Units is null) { return; }
          bp.Units.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.PseudoCRUnits"/>
    /// </summary>
    public TBuilder SetPseudoCRUnits(params BlueprintDungeonArmy.CrUnits[] pseudoCRUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(pseudoCRUnits);
          bp.PseudoCRUnits = pseudoCRUnits;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonArmy.PseudoCRUnits"/>
    /// </summary>
    public TBuilder AddToPseudoCRUnits(params BlueprintDungeonArmy.CrUnits[] pseudoCRUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PseudoCRUnits = bp.PseudoCRUnits ?? new BlueprintDungeonArmy.CrUnits[0];
          bp.PseudoCRUnits = CommonTool.Append(bp.PseudoCRUnits, pseudoCRUnits);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.PseudoCRUnits"/>
    /// </summary>
    public TBuilder RemoveFromPseudoCRUnits(params BlueprintDungeonArmy.CrUnits[] pseudoCRUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PseudoCRUnits is null) { return; }
          bp.PseudoCRUnits = bp.PseudoCRUnits.Where(val => !pseudoCRUnits.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonArmy.PseudoCRUnits"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPseudoCRUnits(Func<BlueprintDungeonArmy.CrUnits, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PseudoCRUnits is null) { return; }
          bp.PseudoCRUnits = bp.PseudoCRUnits.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonArmy.PseudoCRUnits"/>
    /// </summary>
    public TBuilder ClearPseudoCRUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PseudoCRUnits = new BlueprintDungeonArmy.CrUnits[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.PseudoCRUnits"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPseudoCRUnits(Action<BlueprintDungeonArmy.CrUnits> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PseudoCRUnits is null) { return; }
          bp.PseudoCRUnits.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.PseudoCRMultiplier"/>
    /// </summary>
    public TBuilder SetPseudoCRMultiplier(int pseudoCRMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PseudoCRMultiplier = pseudoCRMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonArmy.m_CrUnitsFromPseudoCR"/>
    /// </summary>
    public TBuilder SetCrUnitsFromPseudoCR(Dictionary<int,BlueprintDungeonArmy.CrUnits> crUnitsFromPseudoCR)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(crUnitsFromPseudoCR);
          bp.m_CrUnitsFromPseudoCR = crUnitsFromPseudoCR;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonArmy.m_CrUnitsFromPseudoCR"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCrUnitsFromPseudoCR(Action<Dictionary<int,BlueprintDungeonArmy.CrUnits>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CrUnitsFromPseudoCR is null) { return; }
          action.Invoke(bp.m_CrUnitsFromPseudoCR);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.UnitsCount is null)
      {
        Blueprint.UnitsCount = new IntegerWeighted[0];
      }
      if (Blueprint.m_Tiers is null)
      {
        Blueprint.m_Tiers = new BlueprintDungeonTierReference[0];
      }
      if (Blueprint.m_Themes is null)
      {
        Blueprint.m_Themes = new BlueprintDungeonThemeReference[0];
      }
      if (Blueprint.m_ModificatorsInclude is null)
      {
        Blueprint.m_ModificatorsInclude = new BlueprintDungeonModificatorReference[0];
      }
      if (Blueprint.m_ModificatorsExclude is null)
      {
        Blueprint.m_ModificatorsExclude = new BlueprintDungeonModificatorReference[0];
      }
      if (Blueprint.m_SettingsInclude is null)
      {
        Blueprint.m_SettingsInclude = new BlueprintDungeonSettingReference[0];
      }
      if (Blueprint.m_SettingsExclude is null)
      {
        Blueprint.m_SettingsExclude = new BlueprintDungeonSettingReference[0];
      }
      if (Blueprint.m_IncludeTags is null)
      {
        Blueprint.m_IncludeTags = new UnitTag[0];
      }
      if (Blueprint.m_ExcludeTags is null)
      {
        Blueprint.m_ExcludeTags = new UnitTag[0];
      }
      if (Blueprint.m_ExcludeUnits is null)
      {
        Blueprint.m_ExcludeUnits = new BlueprintUnitReference[0];
      }
      if (Blueprint.m_IncludeUnits is null)
      {
        Blueprint.m_IncludeUnits = new BlueprintUnitReference[0];
      }
      if (Blueprint.Units is null)
      {
        Blueprint.Units = new BlueprintDungeonArmy.CrUnits[0];
      }
      if (Blueprint.PseudoCRUnits is null)
      {
        Blueprint.PseudoCRUnits = new BlueprintDungeonArmy.CrUnits[0];
      }
    }
  }
}
