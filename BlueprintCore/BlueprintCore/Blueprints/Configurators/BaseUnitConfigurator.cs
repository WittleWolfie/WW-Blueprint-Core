//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Items;
using Kingmaker.Controllers.Rest.Special;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.TempMapCode.Ambush;
using Kingmaker.Dungeon.FactLogic;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning;
using Kingmaker.Enums;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components.Fixers;
using Kingmaker.Utility;
using Kingmaker.View.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnit"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitConfigurator<T, TBuilder>
    : BaseUnitFactConfigurator<T, TBuilder>
    where T : BlueprintUnit
    where TBuilder : BaseUnitConfigurator<T, TBuilder>
  {
    protected BaseUnitConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnit>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Type = copyFrom.m_Type;
          bp.LocalizedName = copyFrom.LocalizedName;
          bp.Gender = copyFrom.Gender;
          bp.Size = copyFrom.Size;
          bp.IsLeftHanded = copyFrom.IsLeftHanded;
          bp.Color = copyFrom.Color;
          bp.m_Race = copyFrom.m_Race;
          bp.Alignment = copyFrom.Alignment;
          bp.m_Portrait = copyFrom.m_Portrait;
          bp.Prefab = copyFrom.Prefab;
          bp.m_CustomizationPreset = copyFrom.m_CustomizationPreset;
          bp.Visual = copyFrom.Visual;
          bp.m_Faction = copyFrom.m_Faction;
          bp.FactionOverrides = copyFrom.FactionOverrides;
          bp.m_StartingInventory = copyFrom.m_StartingInventory;
          bp.m_Brain = copyFrom.m_Brain;
          bp.AlternativeBrains = copyFrom.AlternativeBrains;
          bp.Body = copyFrom.Body;
          bp.Strength = copyFrom.Strength;
          bp.Dexterity = copyFrom.Dexterity;
          bp.Constitution = copyFrom.Constitution;
          bp.Intelligence = copyFrom.Intelligence;
          bp.Wisdom = copyFrom.Wisdom;
          bp.Charisma = copyFrom.Charisma;
          bp.Speed = copyFrom.Speed;
          bp.BaseAttackBonus = copyFrom.BaseAttackBonus;
          bp.Skills = copyFrom.Skills;
          bp.MaxHP = copyFrom.MaxHP;
          bp.m_AdditionalTemplates = copyFrom.m_AdditionalTemplates;
          bp.m_AddFacts = copyFrom.m_AddFacts;
          bp.IsCheater = copyFrom.IsCheater;
          bp.IsFake = copyFrom.IsFake;
          bp.m_PS4ChunkId = copyFrom.m_PS4ChunkId;
          bp.m_HasAssignedChunkId = copyFrom.m_HasAssignedChunkId;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnit>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Type = copyFrom.m_Type;
          bp.LocalizedName = copyFrom.LocalizedName;
          bp.Gender = copyFrom.Gender;
          bp.Size = copyFrom.Size;
          bp.IsLeftHanded = copyFrom.IsLeftHanded;
          bp.Color = copyFrom.Color;
          bp.m_Race = copyFrom.m_Race;
          bp.Alignment = copyFrom.Alignment;
          bp.m_Portrait = copyFrom.m_Portrait;
          bp.Prefab = copyFrom.Prefab;
          bp.m_CustomizationPreset = copyFrom.m_CustomizationPreset;
          bp.Visual = copyFrom.Visual;
          bp.m_Faction = copyFrom.m_Faction;
          bp.FactionOverrides = copyFrom.FactionOverrides;
          bp.m_StartingInventory = copyFrom.m_StartingInventory;
          bp.m_Brain = copyFrom.m_Brain;
          bp.AlternativeBrains = copyFrom.AlternativeBrains;
          bp.Body = copyFrom.Body;
          bp.Strength = copyFrom.Strength;
          bp.Dexterity = copyFrom.Dexterity;
          bp.Constitution = copyFrom.Constitution;
          bp.Intelligence = copyFrom.Intelligence;
          bp.Wisdom = copyFrom.Wisdom;
          bp.Charisma = copyFrom.Charisma;
          bp.Speed = copyFrom.Speed;
          bp.BaseAttackBonus = copyFrom.BaseAttackBonus;
          bp.Skills = copyFrom.Skills;
          bp.MaxHP = copyFrom.MaxHP;
          bp.m_AdditionalTemplates = copyFrom.m_AdditionalTemplates;
          bp.m_AddFacts = copyFrom.m_AddFacts;
          bp.IsCheater = copyFrom.IsCheater;
          bp.IsFake = copyFrom.IsFake;
          bp.m_PS4ChunkId = copyFrom.m_PS4ChunkId;
          bp.m_HasAssignedChunkId = copyFrom.m_HasAssignedChunkId;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_Type"/>
    /// </summary>
    ///
    /// <param name="type">
    /// <para>
    /// Blueprint of type BlueprintUnitType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetType(Blueprint<BlueprintUnitTypeReference> type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Type = type?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_Type"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyType(Action<BlueprintUnitTypeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Type is null) { return; }
          action.Invoke(bp.m_Type);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.LocalizedName"/>
    /// </summary>
    public TBuilder SetLocalizedName(SharedStringAsset localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(localizedName);
          bp.LocalizedName = localizedName;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.LocalizedName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedName(Action<SharedStringAsset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedName is null) { return; }
          action.Invoke(bp.LocalizedName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Gender"/>
    /// </summary>
    public TBuilder SetGender(Gender gender)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Gender = gender;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Size"/>
    /// </summary>
    public TBuilder SetSize(Size size)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Size = size;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.IsLeftHanded"/>
    /// </summary>
    public TBuilder SetIsLeftHanded(bool isLeftHanded = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsLeftHanded = isLeftHanded;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Color"/>
    /// </summary>
    public TBuilder SetColor(Color color)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Color = color;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.Color"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyColor(Action<Color> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Color);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_Race"/>
    /// </summary>
    ///
    /// <param name="race">
    /// <para>
    /// Blueprint of type BlueprintRace. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRace(Blueprint<BlueprintRaceReference> race)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Race = race?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_Race"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRace(Action<BlueprintRaceReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Race is null) { return; }
          action.Invoke(bp.m_Race);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Alignment"/>
    /// </summary>
    public TBuilder SetAlignment(Alignment alignment)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Alignment = alignment;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_Portrait"/>
    /// </summary>
    ///
    /// <param name="portrait">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPortrait(Blueprint<BlueprintPortraitReference> portrait)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Portrait = portrait?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_Portrait"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPortrait(Action<BlueprintPortraitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Portrait is null) { return; }
          action.Invoke(bp.m_Portrait);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Prefab"/>
    /// </summary>
    ///
    /// <param name="prefab">
    /// You can pass in the animation using a UnitViewLink or it's AssetId.
    /// </param>
    public TBuilder SetPrefab(AssetLink<UnitViewLink> prefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Prefab = prefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.Prefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPrefab(Action<UnitViewLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Prefab is null) { return; }
          action.Invoke(bp.Prefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_CustomizationPreset"/>
    /// </summary>
    ///
    /// <param name="customizationPreset">
    /// <para>
    /// Blueprint of type UnitCustomizationPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCustomizationPreset(Blueprint<UnitCustomizationPresetReference> customizationPreset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CustomizationPreset = customizationPreset?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_CustomizationPreset"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomizationPreset(Action<UnitCustomizationPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CustomizationPreset is null) { return; }
          action.Invoke(bp.m_CustomizationPreset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Visual"/>
    /// </summary>
    public TBuilder SetVisual(UnitVisualParams visual)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(visual);
          bp.Visual = visual;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.Visual"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVisual(Action<UnitVisualParams> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Visual is null) { return; }
          action.Invoke(bp.Visual);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_Faction"/>
    /// </summary>
    ///
    /// <param name="faction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFaction(Blueprint<BlueprintFactionReference> faction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Faction = faction?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_Faction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFaction(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Faction is null) { return; }
          action.Invoke(bp.m_Faction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.FactionOverrides"/>
    /// </summary>
    public TBuilder SetFactionOverrides(FactionOverrides factionOverrides)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(factionOverrides);
          bp.FactionOverrides = factionOverrides;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.FactionOverrides"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFactionOverrides(Action<FactionOverrides> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FactionOverrides is null) { return; }
          action.Invoke(bp.FactionOverrides);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_StartingInventory"/>
    /// </summary>
    ///
    /// <param name="startingInventory">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartingInventory(params Blueprint<BlueprintItemReference>[] startingInventory)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingInventory = startingInventory.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnit.m_StartingInventory"/>
    /// </summary>
    ///
    /// <param name="startingInventory">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartingInventory(params Blueprint<BlueprintItemReference>[] startingInventory)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingInventory = bp.m_StartingInventory ?? new BlueprintItemReference[0];
          bp.m_StartingInventory = CommonTool.Append(bp.m_StartingInventory, startingInventory.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.m_StartingInventory"/>
    /// </summary>
    ///
    /// <param name="startingInventory">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartingInventory(params Blueprint<BlueprintItemReference>[] startingInventory)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingInventory is null) { return; }
          bp.m_StartingInventory = bp.m_StartingInventory.Where(val => !startingInventory.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.m_StartingInventory"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartingInventory(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingInventory is null) { return; }
          bp.m_StartingInventory = bp.m_StartingInventory.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnit.m_StartingInventory"/>
    /// </summary>
    public TBuilder ClearStartingInventory()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingInventory = new BlueprintItemReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_StartingInventory"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStartingInventory(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingInventory is null) { return; }
          bp.m_StartingInventory.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_Brain"/>
    /// </summary>
    ///
    /// <param name="brain">
    /// <para>
    /// Blueprint of type BlueprintBrain. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBrain(Blueprint<BlueprintBrainReference> brain)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Brain = brain?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_Brain"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBrain(Action<BlueprintBrainReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Brain is null) { return; }
          action.Invoke(bp.m_Brain);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.AlternativeBrains"/>
    /// </summary>
    ///
    /// <param name="alternativeBrains">
    /// <para>
    /// Blueprint of type BlueprintBrain. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAlternativeBrains(params Blueprint<BlueprintBrainReference>[] alternativeBrains)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlternativeBrains = alternativeBrains.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnit.AlternativeBrains"/>
    /// </summary>
    ///
    /// <param name="alternativeBrains">
    /// <para>
    /// Blueprint of type BlueprintBrain. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAlternativeBrains(params Blueprint<BlueprintBrainReference>[] alternativeBrains)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlternativeBrains = bp.AlternativeBrains ?? new BlueprintBrainReference[0];
          bp.AlternativeBrains = CommonTool.Append(bp.AlternativeBrains, alternativeBrains.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.AlternativeBrains"/>
    /// </summary>
    ///
    /// <param name="alternativeBrains">
    /// <para>
    /// Blueprint of type BlueprintBrain. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAlternativeBrains(params Blueprint<BlueprintBrainReference>[] alternativeBrains)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlternativeBrains is null) { return; }
          bp.AlternativeBrains = bp.AlternativeBrains.Where(val => !alternativeBrains.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.AlternativeBrains"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAlternativeBrains(Func<BlueprintBrainReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlternativeBrains is null) { return; }
          bp.AlternativeBrains = bp.AlternativeBrains.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnit.AlternativeBrains"/>
    /// </summary>
    public TBuilder ClearAlternativeBrains()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlternativeBrains = new BlueprintBrainReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.AlternativeBrains"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAlternativeBrains(Action<BlueprintBrainReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlternativeBrains is null) { return; }
          bp.AlternativeBrains.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Body"/>
    /// </summary>
    public TBuilder SetBody(BlueprintUnit.UnitBody body)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(body);
          bp.Body = body;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.Body"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBody(Action<BlueprintUnit.UnitBody> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Body is null) { return; }
          action.Invoke(bp.Body);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Strength"/>
    /// </summary>
    public TBuilder SetStrength(int strength)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Strength = strength;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Dexterity"/>
    /// </summary>
    public TBuilder SetDexterity(int dexterity)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Dexterity = dexterity;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Constitution"/>
    /// </summary>
    public TBuilder SetConstitution(int constitution)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Constitution = constitution;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Intelligence"/>
    /// </summary>
    public TBuilder SetIntelligence(int intelligence)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Intelligence = intelligence;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Wisdom"/>
    /// </summary>
    public TBuilder SetWisdom(int wisdom)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Wisdom = wisdom;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Charisma"/>
    /// </summary>
    public TBuilder SetCharisma(int charisma)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Charisma = charisma;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Speed"/>
    /// </summary>
    public TBuilder SetSpeed(Feet speed)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Speed = speed;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.Speed"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpeed(Action<Feet> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Speed);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.BaseAttackBonus"/>
    /// </summary>
    public TBuilder SetBaseAttackBonus(int baseAttackBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaseAttackBonus = baseAttackBonus;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.Skills"/>
    /// </summary>
    public TBuilder SetSkills(BlueprintUnit.UnitSkills skills)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(skills);
          bp.Skills = skills;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.Skills"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySkills(Action<BlueprintUnit.UnitSkills> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Skills is null) { return; }
          action.Invoke(bp.Skills);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.MaxHP"/>
    /// </summary>
    public TBuilder SetMaxHP(int maxHP)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxHP = maxHP;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_AdditionalTemplates"/>
    /// </summary>
    ///
    /// <param name="additionalTemplates">
    /// <para>
    /// Blueprint of type BlueprintUnitTemplate. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAdditionalTemplates(params Blueprint<BlueprintUnitTemplateReference>[] additionalTemplates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AdditionalTemplates = additionalTemplates.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnit.m_AdditionalTemplates"/>
    /// </summary>
    ///
    /// <param name="additionalTemplates">
    /// <para>
    /// Blueprint of type BlueprintUnitTemplate. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAdditionalTemplates(params Blueprint<BlueprintUnitTemplateReference>[] additionalTemplates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AdditionalTemplates = bp.m_AdditionalTemplates ?? new BlueprintUnitTemplateReference[0];
          bp.m_AdditionalTemplates = CommonTool.Append(bp.m_AdditionalTemplates, additionalTemplates.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.m_AdditionalTemplates"/>
    /// </summary>
    ///
    /// <param name="additionalTemplates">
    /// <para>
    /// Blueprint of type BlueprintUnitTemplate. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAdditionalTemplates(params Blueprint<BlueprintUnitTemplateReference>[] additionalTemplates)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AdditionalTemplates is null) { return; }
          bp.m_AdditionalTemplates = bp.m_AdditionalTemplates.Where(val => !additionalTemplates.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.m_AdditionalTemplates"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAdditionalTemplates(Func<BlueprintUnitTemplateReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AdditionalTemplates is null) { return; }
          bp.m_AdditionalTemplates = bp.m_AdditionalTemplates.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnit.m_AdditionalTemplates"/>
    /// </summary>
    public TBuilder ClearAdditionalTemplates()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AdditionalTemplates = new BlueprintUnitTemplateReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_AdditionalTemplates"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAdditionalTemplates(Action<BlueprintUnitTemplateReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AdditionalTemplates is null) { return; }
          bp.m_AdditionalTemplates.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_AddFacts"/>
    /// </summary>
    ///
    /// <param name="addFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAddFacts(params Blueprint<BlueprintUnitFactReference>[] addFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddFacts = addFacts.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnit.m_AddFacts"/>
    /// </summary>
    ///
    /// <param name="addFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAddFacts(params Blueprint<BlueprintUnitFactReference>[] addFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddFacts = bp.m_AddFacts ?? new BlueprintUnitFactReference[0];
          bp.m_AddFacts = CommonTool.Append(bp.m_AddFacts, addFacts.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.m_AddFacts"/>
    /// </summary>
    ///
    /// <param name="addFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAddFacts(params Blueprint<BlueprintUnitFactReference>[] addFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddFacts is null) { return; }
          bp.m_AddFacts = bp.m_AddFacts.Where(val => !addFacts.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnit.m_AddFacts"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAddFacts(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddFacts is null) { return; }
          bp.m_AddFacts = bp.m_AddFacts.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnit.m_AddFacts"/>
    /// </summary>
    public TBuilder ClearAddFacts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddFacts = new BlueprintUnitFactReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnit.m_AddFacts"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAddFacts(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddFacts is null) { return; }
          bp.m_AddFacts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.IsCheater"/>
    /// </summary>
    ///
    /// <param name="isCheater">
    /// <para>
    /// Tooltip: Trap actors, mapobject cast targets and other untis that are not actually subject ot game mechanics. Cheaters can use any ability, are never ingame but do show FX
    /// </para>
    /// </param>
    public TBuilder SetIsCheater(bool isCheater = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsCheater = isCheater;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.IsFake"/>
    /// </summary>
    public TBuilder SetIsFake(bool isFake = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsFake = isFake;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_PS4ChunkId"/>
    /// </summary>
    public TBuilder SetPS4ChunkId(PS4ChunkId pS4ChunkId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PS4ChunkId = pS4ChunkId;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnit.m_HasAssignedChunkId"/>
    /// </summary>
    public TBuilder SetHasAssignedChunkId(bool hasAssignedChunkId = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HasAssignedChunkId = hasAssignedChunkId;
        });
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageTriggerFixed"/>
    /// </summary>
    public TBuilder AddOutgoingDamageTriggerFixed(AddOutgoingDamageTriggerFixed component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonAddLootToVendor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Dungeon Add Loot To Vendor
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_Falconium_tier1_original1</term><description>2a2e73631326473bb43abda08475380b</description></item>
    /// <item><term>DLC4_Negociant</term><description>61b56a52383f433799f91c15dea57d31</description></item>
    /// <item><term>DLC5_Storasta_Trader</term><description>714c7d560d0c4900a3b661ef18d02ede</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDungeonAddLootToVendor(params DungeonAddLootToVendor.Item[] loots)
    {
      var component = new DungeonAddLootToVendor();
      Validate(loots);
      component.m_Loots = loots;
      if (component.m_Loots is null)
      {
        component.m_Loots = new DungeonAddLootToVendor.Item[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitUpgraderComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalCompanionUnitMammoth</term><description>e7aa96d15a45238438ae4cfb476f6bb9</description></item>
    /// <item><term>GiantSpiderSummoned</term><description>9e120b5e0ad3c794491c049aa24b9fde</description></item>
    /// <item><term>WyvernPeridot</term><description>6a8af899a123abf459e3e1fedf39e8be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="upgraders">
    /// <para>
    /// Blueprint of type BlueprintUnitUpgrader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddUnitUpgraderComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintUnitUpgrader.Reference>>? upgraders = null)
    {
      var component = new UnitUpgraderComponent();
      component.m_Upgraders = upgraders?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Upgraders;
      if (component.m_Upgraders is null)
      {
        component.m_Upgraders = new BlueprintUnitUpgrader.Reference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CampingSpecialAbility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>Octavia_Companion_BlackDragon</term><description>b8f5dee95746a744b9d27362e9d00d4e</description></item>
    /// <item><term>StartGameSorcererPregenUnitLevel8</term><description>f373e1221fc89d9419109e23cf1a7048</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="campCutscene">
    /// <para>
    /// Blueprint of type Cutscene. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="dlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="enemiesBuffOnRandomEncounter">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="partyBuff">
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
    /// <param name="partyBuffDuringCamp">
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
    /// <param name="partyBuffOnRandomEncounter">
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
    /// <param name="selfBuff">
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
    /// <param name="selfBuffOnRandomEncounter">
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
    public TBuilder AddCampingSpecialAbility(
        Blueprint<CutsceneReference>? campCutscene = null,
        CampPositionType? campPositionType = null,
        CampingSpecialCustomMechanics? customMechanics = null,
        LocalString? description = null,
        Blueprint<BlueprintDlcRewardReference>? dlcReward = null,
        Blueprint<BlueprintBuffReference>? enemiesBuffOnRandomEncounter = null,
        int? extraRations = null,
        int? maxEnemyRandomEncounterBuffs = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? minEnemyRandomEncounterBuffs = null,
        LocalString? name = null,
        Blueprint<BlueprintBuffReference>? partyBuff = null,
        Blueprint<BlueprintBuffReference>? partyBuffDuringCamp = null,
        Blueprint<BlueprintBuffReference>? partyBuffOnRandomEncounter = null,
        float? randomEncounterBuffsChance = null,
        Blueprint<BlueprintBuffReference>? selfBuff = null,
        Blueprint<BlueprintBuffReference>? selfBuffOnRandomEncounter = null)
    {
      var component = new CampingSpecialAbility();
      component.m_CampCutscene = campCutscene?.Reference ?? component.m_CampCutscene;
      if (component.m_CampCutscene is null)
      {
        component.m_CampCutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      component.CampPositionType = campPositionType ?? component.CampPositionType;
      component.CustomMechanics = customMechanics ?? component.CustomMechanics;
      component.Description = description?.LocalizedString ?? component.Description;
      if (component.Description is null)
      {
        component.Description = Utils.Constants.Empty.String;
      }
      component.m_DlcReward = dlcReward?.Reference ?? component.m_DlcReward;
      if (component.m_DlcReward is null)
      {
        component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      component.m_EnemiesBuffOnRandomEncounter = enemiesBuffOnRandomEncounter?.Reference ?? component.m_EnemiesBuffOnRandomEncounter;
      if (component.m_EnemiesBuffOnRandomEncounter is null)
      {
        component.m_EnemiesBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.ExtraRations = extraRations ?? component.ExtraRations;
      component.MaxEnemyRandomEncounterBuffs = maxEnemyRandomEncounterBuffs ?? component.MaxEnemyRandomEncounterBuffs;
      component.MinEnemyRandomEncounterBuffs = minEnemyRandomEncounterBuffs ?? component.MinEnemyRandomEncounterBuffs;
      component.Name = name?.LocalizedString ?? component.Name;
      if (component.Name is null)
      {
        component.Name = Utils.Constants.Empty.String;
      }
      component.m_PartyBuff = partyBuff?.Reference ?? component.m_PartyBuff;
      if (component.m_PartyBuff is null)
      {
        component.m_PartyBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_PartyBuffDuringCamp = partyBuffDuringCamp?.Reference ?? component.m_PartyBuffDuringCamp;
      if (component.m_PartyBuffDuringCamp is null)
      {
        component.m_PartyBuffDuringCamp = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_PartyBuffOnRandomEncounter = partyBuffOnRandomEncounter?.Reference ?? component.m_PartyBuffOnRandomEncounter;
      if (component.m_PartyBuffOnRandomEncounter is null)
      {
        component.m_PartyBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.RandomEncounterBuffsChance = randomEncounterBuffsChance ?? component.RandomEncounterBuffsChance;
      component.m_SelfBuff = selfBuff?.Reference ?? component.m_SelfBuff;
      if (component.m_SelfBuff is null)
      {
        component.m_SelfBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_SelfBuffOnRandomEncounter = selfBuffOnRandomEncounter?.Reference ?? component.m_SelfBuffOnRandomEncounter;
      if (component.m_SelfBuffOnRandomEncounter is null)
      {
        component.m_SelfBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="OverrideAnimationRaceComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1_Regill_Companion</term><description>a1c3429385ab481b9f0ee2fd5af63de8</description></item>
    /// <item><term>RegillPregenLevel15</term><description>22559c1e87288c04f9fc1c8ec70e8af7</description></item>
    /// <item><term>RegillPregenLevel9</term><description>88c8c0527d08019428ee43617fd439df</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprintRace">
    /// <para>
    /// Blueprint of type BlueprintRace. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddOverrideAnimationRaceComponent(
        Blueprint<BlueprintRaceReference>? blueprintRace = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new OverrideAnimationRaceComponent();
      component.BlueprintRace = blueprintRace?.Reference ?? component.BlueprintRace;
      if (component.BlueprintRace is null)
      {
        component.BlueprintRace = BlueprintTool.GetRef<BlueprintRaceReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UnitAggroFilter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DarknessMachine</term><description>5ccf98d8542442c1b81dc0973d5afe7a</description></item>
    /// <item><term>SmithKitten</term><description>5788b5e98469dd64f8afafe1fda8d53d</description></item>
    /// <item><term>WagonKitten</term><description>c07d0cff2312c4647a30706bd3bf84c6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="filterCondition">
    /// <para>
    /// InfoBox: No conditions means always should aggro. Otherwise aggroes only if FilterCondition is true
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddUnitAggroFilter(
        ActionsBuilder? actionsOnAggro = null,
        ConditionsBuilder? filterCondition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UnitAggroFilter();
      component.ActionsOnAggro = actionsOnAggro?.Build() ?? component.ActionsOnAggro;
      if (component.ActionsOnAggro is null)
      {
        component.ActionsOnAggro = Utils.Constants.Empty.Actions;
      }
      component.FilterCondition = filterCondition?.Build() ?? component.FilterCondition;
      if (component.FilterCondition is null)
      {
        component.FilterCondition = Utils.Constants.Empty.Conditions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityLimits"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_Nahyndri_FinalBoss</term><description>7beffb211ea84810876ab65014c1cee5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAttackOfOpportunityLimits(
        float? angleToTurnMax = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? shouldTurnToTarget = null)
    {
      var component = new AttackOfOpportunityLimits();
      component.AngleToTurnMax = angleToTurnMax ?? component.AngleToTurnMax;
      component.ShouldTurnToTarget = shouldTurnToTarget ?? component.ShouldTurnToTarget;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DisableAllFx"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CR20_AnimatedWeapon_Bardiche</term><description>1706dff4d4435d540b5260fe1feb98e4</description></item>
    /// <item><term>DLC3_CR23_SkeletalChampion_level14_MiniBoss_noItem</term><description>a4ff21675cfd432a9556f31efdb4925c</description></item>
    /// <item><term>DLC5_CR7_AnimatedWeapon_Longsword</term><description>101a8122040545bc9a3cd10249fb4f62</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDisableAllFx(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DisableAllFx();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitBlueprintForRespec"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1StartPregenCavalierUnit</term><description>cbc5b710d6c446da9964700a3717d3a0</description></item>
    /// <item><term>DLC3WarpriestFeralChampionPregen</term><description>7091aebc3da94121ac3f5341b6589d14</description></item>
    /// <item><term>StartGameSorcererPregenUnit</term><description>1f6d72fd52ce418fb677db2243ea4de5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprint">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddReplaceUnitBlueprintForRespec(
        Blueprint<BlueprintUnitReference>? blueprint = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ReplaceUnitBlueprintForRespec();
      component.m_Blueprint = blueprint?.Reference ?? component.m_Blueprint;
      if (component.m_Blueprint is null)
      {
        component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UnitIsStoryCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Anevia_Companion</term><description>88162735402ac094d8a08867814902dd</description></item>
    /// <item><term>Fighter_Level7</term><description>d7ba48103c9d4860a780af873954abc2</description></item>
    /// <item><term>Woljif_NPC</term><description>318127d85d5d41b4d9acea4e2ad1c4a4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddUnitIsStoryCompanion(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UnitIsStoryCompanion();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelLimit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Mage_Test</term><description>f9161aa0b3f519c47acbce01f53ee217</description></item>
    /// <item><term>MC_Human_M_Cavalier_DemonUnit</term><description>96ae0d6d804c47e583779f9751e418ec</description></item>
    /// <item><term>WoljifTestLeve9</term><description>b6a343d8b3f47784dab47911fb42a84a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddClassLevelLimit(
        int? levelLimit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ClassLevelLimit();
      component.LevelLimit = levelLimit ?? component.LevelLimit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelLimit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Mage_Test</term><description>f9161aa0b3f519c47acbce01f53ee217</description></item>
    /// <item><term>MC_Elf_F_Sorcerer_DefendersHeart</term><description>50868dfb0d5e406c9a993f5ba1befaaf</description></item>
    /// <item><term>WoljifTestLeve9</term><description>b6a343d8b3f47784dab47911fb42a84a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMythicLevelLimit(
        int? levelLimit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new MythicLevelLimit();
      component.LevelLimit = levelLimit ?? component.LevelLimit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Experience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>00_FindEchoLair</term><description>876fc5d40aa5d8b47ac0138cf0a680ae</description></item>
    /// <item><term>DLC3_CR14_DeepShadowDemonTough</term><description>580e014994544fefbe22e9f6164ad49b</description></item>
    /// <item><term>Ziforian_normal</term><description>7ef2998dbeb7fda43a47ce842f4d142d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="playerGainsNoExp">
    /// <para>
    /// InfoBox: When true, Exp will be used in encounter CR calculation, but player will not gained it
    /// </para>
    /// </param>
    public TBuilder AddExperience(
        IntEvaluator? count = null,
        int? cR = null,
        bool? dummy = null,
        EncounterType? encounter = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? modifier = null,
        bool? playerGainsNoExp = null)
    {
      var component = new Experience();
      Validate(count);
      component.Count = count ?? component.Count;
      component.CR = cR ?? component.CR;
      component.Dummy = dummy ?? component.Dummy;
      component.Encounter = encounter ?? component.Encounter;
      component.Modifier = modifier ?? component.Modifier;
      component.PlayerGainsNoExp = playerGainsNoExp ?? component.PlayerGainsNoExp;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="NoStartingItemsComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CustomCompanionDlc2</term><description>46e3688f1f2748589b4147ea3367434b</description></item>
    /// <item><term>StartGame_Player_Unit_DLC2</term><description>78d4f75f6e144224a948df629df00193</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddNoStartingItemsComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NoStartingItemsComponent();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PregenUnitComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: PregenInformation
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1StartPregenCavalierUnit</term><description>cbc5b710d6c446da9964700a3717d3a0</description></item>
    /// <item><term>MC_Human_M_Cavalier_IvorySanctum</term><description>66f2c9db01f74d3692fe85d52213bf52</description></item>
    /// <item><term>StartGameSorcererPregenUnitLevel8</term><description>f373e1221fc89d9419109e23cf1a7048</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="pregenClass">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="pregenDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="pregenName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="pregenRole">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPregenUnitComponent(
        LocalString? pregenClass = null,
        LocalString? pregenDescription = null,
        LocalString? pregenName = null,
        LocalString? pregenRole = null)
    {
      var component = new PregenUnitComponent();
      component.PregenClass = pregenClass?.LocalizedString ?? component.PregenClass;
      if (component.PregenClass is null)
      {
        component.PregenClass = Utils.Constants.Empty.String;
      }
      component.PregenDescription = pregenDescription?.LocalizedString ?? component.PregenDescription;
      if (component.PregenDescription is null)
      {
        component.PregenDescription = Utils.Constants.Empty.String;
      }
      component.PregenName = pregenName?.LocalizedString ?? component.PregenName;
      if (component.PregenName is null)
      {
        component.PregenName = Utils.Constants.Empty.String;
      }
      component.PregenRole = pregenRole?.LocalizedString ?? component.PregenRole;
      if (component.PregenRole is null)
      {
        component.PregenRole = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StartingStatPointsComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CustomCompanion</term><description>baaff53a675a84f4983f1e2113b24552</description></item>
    /// <item><term>CustomCompanionDlc3</term><description>4ee630120a7a4774a11eb09489b32bbb</description></item>
    /// <item><term>StartGame_Player_Unit_DLC2</term><description>78d4f75f6e144224a948df629df00193</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddStartingStatPointsComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? startingStatPoints = null)
    {
      var component = new StartingStatPointsComponent();
      component.StartingStatPoints = startingStatPoints ?? component.StartingStatPoints;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnClick"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>Octavia_Companion_Kalavakus</term><description>776047de5b2e10249b2db7cb1b5e47d3</description></item>
    /// <item><term>Octavia_Companion_Wyvern</term><description>8fc128d5685471649b99a440cfdc3bbf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddActionsOnClick(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        float? cooldown = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? overrideDistance = null,
        bool? triggerOnApproach = null,
        bool? triggerOnParty = null)
    {
      var component = new ActionsOnClick();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.Cooldown = cooldown ?? component.Cooldown;
      component.m_OverrideDistance = overrideDistance ?? component.m_OverrideDistance;
      component.TriggerOnApproach = triggerOnApproach ?? component.TriggerOnApproach;
      component.TriggerOnParty = triggerOnParty ?? component.TriggerOnParty;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DialogOnClick"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Dialog/Start On Click
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>Octavia_Companion_Athach</term><description>c613fb61c8d981f4b878af21264393b7</description></item>
    /// <item><term>TestTrader</term><description>38c90d65490c1c143a9f1f0fde6bbe20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialog">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDialogOnClick(
        ConditionsBuilder? conditions = null,
        float? cooldown = null,
        Blueprint<BlueprintDialogReference>? dialog = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? noDialogActions = null,
        float? overrideDistance = null,
        bool? triggerOnApproach = null,
        bool? triggerOnParty = null)
    {
      var component = new DialogOnClick();
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.Cooldown = cooldown ?? component.Cooldown;
      component.m_Dialog = dialog?.Reference ?? component.m_Dialog;
      if (component.m_Dialog is null)
      {
        component.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.NoDialogActions = noDialogActions?.Build() ?? component.NoDialogActions;
      if (component.NoDialogActions is null)
      {
        component.NoDialogActions = Utils.Constants.Empty.Actions;
      }
      component.m_OverrideDistance = overrideDistance ?? component.m_OverrideDistance;
      component.TriggerOnApproach = triggerOnApproach ?? component.TriggerOnApproach;
      component.TriggerOnParty = triggerOnParty ?? component.TriggerOnParty;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityToCharacterComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Ability/Castable ability
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Mage_Test</term><description>f9161aa0b3f519c47acbce01f53ee217</description></item>
    /// <item><term>DLC5_UmbralDragon</term><description>abb84b9edf12429cb33cb704474f102c</description></item>
    /// <item><term>WillOWispYellowSummon_cr8</term><description>25a09e126dba4fcb90b3f95bbe61cd0d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilities">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityToCharacterComponent(params Blueprint<BlueprintAbilityReference>[] abilities)
    {
      var component = new AddAbilityToCharacterComponent();
      component.m_Abilities = abilities.Select(bp => bp.Reference).ToArray();
      if (component.m_Abilities is null)
      {
        component.m_Abilities = new BlueprintAbilityReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAmbushBehaviour"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Passive/Add ambush behaviour
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CR11M_MythicCrazyIncubus</term><description>667f0ff46d87bca498cb8f410057be03</description></item>
    /// <item><term>CR8_WarWisp</term><description>5101be4b7f4e08047b84e0cb789b67e4</description></item>
    /// <item><term>DLC3_CR8_BabauPoisoner_MeleeRogue</term><description>107055a08d4f4798b88f37c56d0fb1f0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAmbushBehaviour(
        float? joinCombatDisatnce = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddAmbushBehaviour();
      component.JoinCombatDisatnce = joinCombatDisatnce ?? component.JoinCombatDisatnce;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddLoot"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add loot
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArenaWizard_Curse</term><description>c0fe3438b11d09841a8717ab55eebe15</description></item>
    /// <item><term>DLC3_CR1_KoboldRangedFighterLevel3</term><description>54191b1b6b17411fb79c1d2c9e67831c</description></item>
    /// <item><term>Zanedra_Sanctum</term><description>34c3e14d08f2ff4448b745761cbb846f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="loot">
    /// <para>
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddLoot(
        Blueprint<BlueprintUnitLootReference>? loot = null)
    {
      var component = new AddLoot();
      component.m_Loot = loot?.Reference ?? component.m_Loot;
      if (component.m_Loot is null)
      {
        component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLootToVendorTable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1_BlindCarver_Wintersun</term><description>c209cd1dfa02401eb66f190f0f5675ad</description></item>
    /// <item><term>DLC3_Steersman</term><description>b13fa6c6d2b54d86875eb1e853455e98</description></item>
    /// <item><term>WarCamp_ScrollVendorYoung</term><description>6b6eb149263959a4c9ea307057a20978</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="loot">
    /// <para>
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddLootToVendorTable(
        Blueprint<BlueprintUnitLootReference>? loot = null)
    {
      var component = new AddLootToVendorTable();
      component.m_Loot = loot?.Reference ?? component.m_Loot;
      if (component.m_Loot is null)
      {
        component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSharedVendor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add vendor table
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Arsinoe</term><description>a609ed9b2205d034bb3bb04d2a255681</description></item>
    /// <item><term>DLC5_Velhen_Armor</term><description>6aa9aa9cc1d04bc2aba2476223a42984</description></item>
    /// <item><term>Woljif_NPC</term><description>318127d85d5d41b4d9acea4e2ad1c4a4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="m_Table">
    /// <para>
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSharedVendor(
        Blueprint<BlueprintSharedVendorTableReference>? m_Table = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddSharedVendor();
      component.m_m_Table = m_Table?.Reference ?? component.m_m_Table;
      if (component.m_m_Table is null)
      {
        component.m_m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddTags"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArchpriestGolemCR23</term><description>fe60facdf4574f599fb5eea50bfffb69</description></item>
    /// <item><term>DLC3_CR11_FireElementalElder</term><description>c913003de3b64a239f7cb5b167876af2</description></item>
    /// <item><term>Velhm</term><description>f9c01a9515cd1f347800685ddbfbcc41</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTags(
        AddTags.DifficultyRequirement? difficultyRequirement = null,
        bool? isCaster = null,
        bool? isMelee = null,
        bool? isRanged = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        UnitTag[]? tags = null,
        bool? useInDungeon = null,
        bool? useInRandomEncounter = null)
    {
      var component = new AddTags();
      component.m_DifficultyRequirement = difficultyRequirement ?? component.m_DifficultyRequirement;
      component.IsCaster = isCaster ?? component.IsCaster;
      component.IsMelee = isMelee ?? component.IsMelee;
      component.IsRanged = isRanged ?? component.IsRanged;
      component.Tags = tags ?? component.Tags;
      if (component.Tags is null)
      {
        component.Tags = new UnitTag[0];
      }
      component.UseInDungeon = useInDungeon ?? component.UseInDungeon;
      component.UseInRandomEncounter = useInRandomEncounter ?? component.UseInRandomEncounter;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItems"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add vendor items
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Azata_MadAlchemist</term><description>76cfa7d2cc33eaf41ad242d27ac02f19</description></item>
    /// <item><term>Dyra_Trader_Neathholm</term><description>bd6d6b07f1682c14c9d0966ef7954648</description></item>
    /// <item><term>WintersunIncubusTrader</term><description>c36a4eb2bcf976e4892eaffb61493a94</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="loot">
    /// <para>
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddVendorItems(
        Blueprint<BlueprintUnitLootReference>? loot = null)
    {
      var component = new AddVendorItems();
      component.m_Loot = loot?.Reference ?? component.m_Loot;
      if (component.m_Loot is null)
      {
        component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeVendorPrices"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CR3_Crusader_Human_PaladinMelee_Vendor1</term><description>f7f12ae65b95491da0daf56a756dfcfb</description></item>
    /// <item><term>DLC3_VendorInPort_tier1_original_potions</term><description>bdb8de4454914a0396d3c620bb589c4c</description></item>
    /// <item><term>DLC4_NegociantSecondState</term><description>32a3b06249984fda9bc474c2feaec195</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddChangeVendorPrices(
        Dictionary<BlueprintItem,long>? itemsToBuyCosts = null,
        Dictionary<BlueprintItem,long>? itemsToSellCosts = null,
        ChangeVendorPrices.Entry[]? priceOverrides = null)
    {
      var component = new ChangeVendorPrices();
      Validate(itemsToBuyCosts);
      component.m_ItemsToBuyCosts = itemsToBuyCosts ?? component.m_ItemsToBuyCosts;
      Validate(itemsToSellCosts);
      component.m_ItemsToSellCosts = itemsToSellCosts ?? component.m_ItemsToSellCosts;
      Validate(priceOverrides);
      component.m_PriceOverrides = priceOverrides ?? component.m_PriceOverrides;
      if (component.m_PriceOverrides is null)
      {
        component.m_PriceOverrides = new ChangeVendorPrices.Entry[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PregenDollSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1StartPregenCavalierUnit</term><description>cbc5b710d6c446da9964700a3717d3a0</description></item>
    /// <item><term>DLC3StartPregenRangerUnit</term><description>0f1804ad82d341eaa706e8442711bca2</description></item>
    /// <item><term>StartGameSorcererPregenUnit</term><description>1f6d72fd52ce418fb677db2243ea4de5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPregenDollSettings(
        PregenDollSettings.Entry? defaultValue = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PregenDollSettings();
      Validate(defaultValue);
      component.Default = defaultValue ?? component.Default;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="NPCWithAura"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC5_CR9_ShadowPlane_SoulEater</term><description>4c816f24c61847e2b772a79e593922cf</description></item>
    /// <item><term>DLC5_CR9_ShadowPlaneShadowDemonAdvanced_Pit</term><description>ebcee08c46bc4f728dd110e407a68158</description></item>
    /// <item><term>StoneBall</term><description>5daa93994334de54f919c268fcb52f63</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddNPCWithAura(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NPCWithAura();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="FixUnitOnPostLoad_AddNewFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Ankou_ShadowDoubleSummon</term><description>704d11701a4a9ef4daee07e4593bf69c</description></item>
    /// <item><term>FiendishAnkou</term><description>8180204b0589cfb4f9796475ec60c5ce</description></item>
    /// <item><term>TotemSpiritFey</term><description>c54a51d331294d1886af81040ee29dcc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="newFact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddFixUnitOnPostLoad_AddNewFact(
        string? comment = null,
        Blueprint<BlueprintUnitFactReference>? newFact = null,
        string? taskId = null)
    {
      var component = new FixUnitOnPostLoad_AddNewFact();
      component.Comment = comment ?? component.Comment;
      component.m_NewFact = newFact?.Reference ?? component.m_NewFact;
      if (component.m_NewFact is null)
      {
        component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.TaskId = taskId ?? component.TaskId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReturnVendorTable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Woljif_Companion</term><description>766435873b1361c4287c351de194e5f9</description></item>
    /// <item><term>Woljif_DH_NotCompanion</term><description>f31cea279cd08c341913bc33577aea5a</description></item>
    /// <item><term>Woljif_NPC</term><description>318127d85d5d41b4d9acea4e2ad1c4a4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="table">
    /// <para>
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddReturnVendorTable(
        string? comment = null,
        Blueprint<BlueprintSharedVendorTableReference>? table = null,
        string? taskId = null)
    {
      var component = new ReturnVendorTable();
      component.Comment = comment ?? component.Comment;
      component.m_Table = table?.Reference ?? component.m_Table;
      if (component.m_Table is null)
      {
        component.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      component.TaskId = taskId ?? component.TaskId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyCriticalDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyCaydenBuffCritBuff</term><description>7c2b00088ac3476e949518d0b8a78526</description></item>
    /// <item><term>ArmySwordSaintCrit</term><description>9eb7e9b7296d4d12855625d04beb3976</description></item>
    /// <item><term>Trickster3PlaceOfPowerBuff</term><description>adcc8e0615fa4e37bd7e5854302203fe</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmyCriticalDamage(
        ContextValue? chanceBase = null,
        ContextValue? chanceMultiplier = null,
        float? critBonus = null,
        float? critMultiplier = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ArmyCriticalDamage();
      component.m_ChanceBase = chanceBase ?? component.m_ChanceBase;
      if (component.m_ChanceBase is null)
      {
        component.m_ChanceBase = ContextValues.Constant(0);
      }
      component.m_ChanceMultiplier = chanceMultiplier ?? component.m_ChanceMultiplier;
      if (component.m_ChanceMultiplier is null)
      {
        component.m_ChanceMultiplier = ContextValues.Constant(0);
      }
      component.m_CritBonus = critBonus ?? component.m_CritBonus;
      component.m_CritMultiplier = critMultiplier ?? component.m_CritMultiplier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmySwitchWeaponSlotInMelee"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyArcher</term><description>adee0dc84ed3f254fa5da3c90d1e8e3c</description></item>
    /// <item><term>ArmyInfernalArchers</term><description>8e412d72eddc43a8b360f38da7446a6b</description></item>
    /// <item><term>KTC_ArmyHeadhunter</term><description>167fd434a10540a2b1007c7f189ee55a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmySwitchWeaponSlotInMelee(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? slotIndexForMelee = null)
    {
      var component = new ArmySwitchWeaponSlotInMelee();
      component.m_SlotIndexForMelee = slotIndexForMelee ?? component.m_SlotIndexForMelee;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BuildingSpiritualGardenSkill</term><description>923f02023f5f49f6842aabf3d3cf0e44</description></item>
    /// <item><term>IntimidationRank1</term><description>c465debec287c4f448050cda26a27b77</description></item>
    /// <item><term>Leadership6IncreaseMorale</term><description>796c4868365243cface2d36f997135a9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTacticalMoraleModifier(
        TacticalMoraleModifier.FactionTarget? factionTarget = null,
        int? modValue = null,
        TargetFilter? targetFilter = null)
    {
      var component = new TacticalMoraleModifier();
      component.m_FactionTarget = factionTarget ?? component.m_FactionTarget;
      component.m_ModValue = modValue ?? component.m_ModValue;
      Validate(targetFilter);
      component.m_TargetFilter = targetFilter ?? component.m_TargetFilter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyAeonsBythos</term><description>a6d75776a29d4c0bb3bc8bcad259e990</description></item>
    /// <item><term>ArmyInquisitor</term><description>4cef3f3bb47343a45a1846204e2ef68d</description></item>
    /// <item><term>LeaderUnitVrockStandard</term><description>7fa16932774ed544fa7762b5ab6bb6cc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="icon">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    /// <param name="maxExtraActions">
    /// <para>
    /// InfoBox: Base turn and bonus morale turn have separate counters
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="tier">
    /// <para>
    /// InfoBox: Should be set automatically according to HP
    /// </para>
    /// </param>
    public TBuilder AddArmyUnitComponent(
        LocalString? description = null,
        Asset<Sprite>? icon = null,
        bool? isHaveMorale = null,
        int? maxExtraActions = null,
        int? mercenariesBaseGrowths = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ArmyProperties? properties = null,
        KingdomResourcesAmount? recruitmentPrice = null,
        int? startMorale = null,
        KingdomResourcesAmount? supportPrice = null,
        int? tier = null)
    {
      var component = new ArmyUnitComponent();
      component.Description = description?.LocalizedString ?? component.Description;
      if (component.Description is null)
      {
        component.Description = Utils.Constants.Empty.String;
      }
      component.Icon = icon?.Get() ?? component.Icon;
      component.IsHaveMorale = isHaveMorale ?? component.IsHaveMorale;
      component.MaxExtraActions = maxExtraActions ?? component.MaxExtraActions;
      component.MercenariesBaseGrowths = mercenariesBaseGrowths ?? component.MercenariesBaseGrowths;
      component.Properties = properties ?? component.Properties;
      component.RecruitmentPrice = recruitmentPrice ?? component.RecruitmentPrice;
      component.StartMorale = startMorale ?? component.StartMorale;
      component.SupportPrice = supportPrice ?? component.SupportPrice;
      component.Tier = tier ?? component.Tier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitSpellPower"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyAeonsBythos</term><description>a6d75776a29d4c0bb3bc8bcad259e990</description></item>
    /// <item><term>ArmyKalavakus</term><description>fe83c9d601c845e288f172ed259342ba</description></item>
    /// <item><term>KTC_ArmyVampire</term><description>4f37d4c10f4844d9abbebb8b7e0f5c7c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmyUnitSpellPower(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? spellPower = null)
    {
      var component = new ArmyUnitSpellPower();
      component.m_SpellPower = spellPower ?? component.m_SpellPower;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BuffOnEntityCreated"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Passive/BuffOnEntityCreated
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>GolemWoodSummon</term><description>38db08516a706cf448327c5b81c22c79</description></item>
    /// <item><term>Ygefeles_WeakCopy</term><description>7aab7792681750a42bacd71f9f7c6d5f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
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
    public TBuilder AddBuffOnEntityCreated(
        Blueprint<BlueprintBuffReference>? buff = null)
    {
      var component = new BuffOnEntityCreated();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MobCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add ability resources
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aasimar_Victim</term><description>dfa634221ff82bf42a3b0a511b6d2e5a</description></item>
    /// <item><term>Dimalchio</term><description>0c4b24a1f9dd73c4f925ed79166ff481</description></item>
    /// <item><term>Zerieks</term><description>79674c8c4286cd7498c7bb33fd8dca31</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddMobCaster()
    {
      return AddComponent(new MobCaster());
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Type is null)
      {
        Blueprint.m_Type = BlueprintTool.GetRef<BlueprintUnitTypeReference>(null);
      }
      if (Blueprint.m_Race is null)
      {
        Blueprint.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(null);
      }
      if (Blueprint.m_Portrait is null)
      {
        Blueprint.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(null);
      }
      if (Blueprint.m_CustomizationPreset is null)
      {
        Blueprint.m_CustomizationPreset = BlueprintTool.GetRef<UnitCustomizationPresetReference>(null);
      }
      if (Blueprint.m_Faction is null)
      {
        Blueprint.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (Blueprint.m_StartingInventory is null)
      {
        Blueprint.m_StartingInventory = new BlueprintItemReference[0];
      }
      if (Blueprint.m_Brain is null)
      {
        Blueprint.m_Brain = BlueprintTool.GetRef<BlueprintBrainReference>(null);
      }
      if (Blueprint.AlternativeBrains is null)
      {
        Blueprint.AlternativeBrains = new BlueprintBrainReference[0];
      }
      if (Blueprint.m_AdditionalTemplates is null)
      {
        Blueprint.m_AdditionalTemplates = new BlueprintUnitTemplateReference[0];
      }
      if (Blueprint.m_AddFacts is null)
      {
        Blueprint.m_AddFacts = new BlueprintUnitFactReference[0];
      }
    }
  }
}
