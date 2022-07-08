//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Corruption;
using Kingmaker.Craft;
using Kingmaker.ElementsSystem;
using Kingmaker.Interaction;
using Kingmaker.RazerChroma;
using Kingmaker.ResourceLinks;
using Kingmaker.Settings;
using Kingmaker.Settings.Difficulty;
using Kingmaker.Tutorial;
using Kingmaker.UI.SettingsUI;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation;
using Kingmaker.Visual.Sound;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRoot
    where TBuilder : BaseRootConfigurator<T, TBuilder>
  {
    protected BaseRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_DefaultPlayerCharacter"/>
    /// </summary>
    ///
    /// <param name="defaultPlayerCharacter">
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
    public TBuilder SetDefaultPlayerCharacter(Blueprint<BlueprintUnitReference> defaultPlayerCharacter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultPlayerCharacter = defaultPlayerCharacter?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_DefaultPlayerCharacter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultPlayerCharacter(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultPlayerCharacter is null) { return; }
          action.Invoke(bp.m_DefaultPlayerCharacter);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/>
    /// </summary>
    ///
    /// <param name="selectablePlayerCharacters">
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
    public TBuilder SetSelectablePlayerCharacters(params Blueprint<BlueprintUnitReference>[] selectablePlayerCharacters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SelectablePlayerCharacters = selectablePlayerCharacters.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/>
    /// </summary>
    ///
    /// <param name="selectablePlayerCharacters">
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
    public TBuilder AddToSelectablePlayerCharacters(params Blueprint<BlueprintUnitReference>[] selectablePlayerCharacters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SelectablePlayerCharacters = bp.m_SelectablePlayerCharacters ?? new BlueprintUnitReference[0];
          bp.m_SelectablePlayerCharacters = CommonTool.Append(bp.m_SelectablePlayerCharacters, selectablePlayerCharacters.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/>
    /// </summary>
    ///
    /// <param name="selectablePlayerCharacters">
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
    public TBuilder RemoveFromSelectablePlayerCharacters(params Blueprint<BlueprintUnitReference>[] selectablePlayerCharacters)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SelectablePlayerCharacters is null) { return; }
          bp.m_SelectablePlayerCharacters = bp.m_SelectablePlayerCharacters.Where(val => !selectablePlayerCharacters.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSelectablePlayerCharacters(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SelectablePlayerCharacters is null) { return; }
          bp.m_SelectablePlayerCharacters = bp.m_SelectablePlayerCharacters.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/>
    /// </summary>
    public TBuilder ClearSelectablePlayerCharacters()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SelectablePlayerCharacters = new BlueprintUnitReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySelectablePlayerCharacters(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SelectablePlayerCharacters is null) { return; }
          bp.m_SelectablePlayerCharacters.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_PlayerFaction"/>
    /// </summary>
    ///
    /// <param name="playerFaction">
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
    public TBuilder SetPlayerFaction(Blueprint<BlueprintFactionReference> playerFaction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerFaction = playerFaction?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_PlayerFaction"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPlayerFaction(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PlayerFaction is null) { return; }
          action.Invoke(bp.m_PlayerFaction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.CompanionsAI"/>
    /// </summary>
    public TBuilder SetCompanionsAI(bool companionsAI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompanionsAI = companionsAI;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_KingFlag"/>
    /// </summary>
    ///
    /// <param name="kingFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetKingFlag(Blueprint<BlueprintUnlockableFlagReference> kingFlag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingFlag = kingFlag?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_KingFlag"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingFlag(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_KingFlag is null) { return; }
          action.Invoke(bp.m_KingFlag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.MinProjectileMissDeviation"/>
    /// </summary>
    public TBuilder SetMinProjectileMissDeviation(float minProjectileMissDeviation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinProjectileMissDeviation = minProjectileMissDeviation;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.MaxProjectileMissDeviation"/>
    /// </summary>
    public TBuilder SetMaxProjectileMissDeviation(float maxProjectileMissDeviation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxProjectileMissDeviation = maxProjectileMissDeviation;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.HumanAnimationSet"/>
    /// </summary>
    public TBuilder SetHumanAnimationSet(AnimationSet humanAnimationSet)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(humanAnimationSet);
          bp.HumanAnimationSet = humanAnimationSet;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.HumanAnimationSet"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHumanAnimationSet(Action<AnimationSet> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HumanAnimationSet is null) { return; }
          action.Invoke(bp.HumanAnimationSet);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_NewGamePreset"/>
    /// </summary>
    ///
    /// <param name="newGamePreset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNewGamePreset(Blueprint<BlueprintAreaPresetReference> newGamePreset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NewGamePreset = newGamePreset?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_NewGamePreset"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNewGamePreset(Action<BlueprintAreaPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NewGamePreset is null) { return; }
          action.Invoke(bp.m_NewGamePreset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.StartGameActions"/>
    /// </summary>
    public TBuilder SetStartGameActions(ActionsBuilder startGameActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartGameActions = startGameActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.StartGameActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartGameActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartGameActions is null) { return; }
          action.Invoke(bp.StartGameActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Dialog"/>
    /// </summary>
    public TBuilder SetDialog(DialogRoot dialog)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dialog);
          bp.Dialog = dialog;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Dialog"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDialog(Action<DialogRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Dialog is null) { return; }
          action.Invoke(bp.Dialog);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Cheats"/>
    /// </summary>
    public TBuilder SetCheats(CheatRoot cheats)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cheats);
          bp.Cheats = cheats;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Cheats"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheats(Action<CheatRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cheats is null) { return; }
          action.Invoke(bp.Cheats);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_RE"/>
    /// </summary>
    ///
    /// <param name="rE">
    /// <para>
    /// Blueprint of type RandomEncountersRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRE(Blueprint<RandomEncountersRootReference> rE)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RE = rE?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_RE"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRE(Action<RandomEncountersRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RE is null) { return; }
          action.Invoke(bp.m_RE);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_GlobalMap"/>
    /// </summary>
    public TBuilder SetGlobalMap(GlobalMapRoot globalMap)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(globalMap);
          bp.m_GlobalMap = globalMap;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_GlobalMap"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGlobalMap(Action<GlobalMapRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalMap is null) { return; }
          action.Invoke(bp.m_GlobalMap);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Progression"/>
    /// </summary>
    public TBuilder SetProgression(ProgressionRoot progression)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(progression);
          bp.Progression = progression;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Progression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProgression(Action<ProgressionRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Progression is null) { return; }
          action.Invoke(bp.Progression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.CharGen"/>
    /// </summary>
    public TBuilder SetCharGen(CharGenRoot charGen)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(charGen);
          bp.CharGen = charGen;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.CharGen"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCharGen(Action<CharGenRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CharGen is null) { return; }
          action.Invoke(bp.CharGen);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Prefabs"/>
    /// </summary>
    public TBuilder SetPrefabs(Prefabs prefabs)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(prefabs);
          bp.Prefabs = prefabs;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Prefabs"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPrefabs(Action<Prefabs> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Prefabs is null) { return; }
          action.Invoke(bp.Prefabs);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.OccludedCharacterColors"/>
    /// </summary>
    public TBuilder SetOccludedCharacterColors(OccludedCharacterColors occludedCharacterColors)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(occludedCharacterColors);
          bp.OccludedCharacterColors = occludedCharacterColors;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.OccludedCharacterColors"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOccludedCharacterColors(Action<OccludedCharacterColors> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OccludedCharacterColors is null) { return; }
          action.Invoke(bp.OccludedCharacterColors);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.UIRoot"/>
    /// </summary>
    public TBuilder SetUIRoot(UIRoot uIRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(uIRoot);
          bp.UIRoot = uIRoot;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.UIRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUIRoot(Action<UIRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UIRoot is null) { return; }
          action.Invoke(bp.UIRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Quests"/>
    /// </summary>
    public TBuilder SetQuests(QuestsRoot quests)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(quests);
          bp.Quests = quests;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Quests"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyQuests(Action<QuestsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Quests is null) { return; }
          action.Invoke(bp.Quests);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Vendors"/>
    /// </summary>
    public TBuilder SetVendors(VendorsRoot vendors)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(vendors);
          bp.Vendors = vendors;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Vendors"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVendors(Action<VendorsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Vendors is null) { return; }
          action.Invoke(bp.Vendors);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.SystemMechanics"/>
    /// </summary>
    public TBuilder SetSystemMechanics(SystemMechanicsRoot systemMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(systemMechanics);
          bp.SystemMechanics = systemMechanics;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.SystemMechanics"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySystemMechanics(Action<SystemMechanicsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SystemMechanics is null) { return; }
          action.Invoke(bp.SystemMechanics);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.StatusBuffs"/>
    /// </summary>
    public TBuilder SetStatusBuffs(StatusBuffsRoot statusBuffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(statusBuffs);
          bp.StatusBuffs = statusBuffs;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.StatusBuffs"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStatusBuffs(Action<StatusBuffsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatusBuffs is null) { return; }
          action.Invoke(bp.StatusBuffs);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Cursors"/>
    /// </summary>
    public TBuilder SetCursors(CursorRoot cursors)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cursors);
          bp.Cursors = cursors;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Cursors"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCursors(Action<CursorRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cursors is null) { return; }
          action.Invoke(bp.Cursors);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.WeatherSettings"/>
    /// </summary>
    public TBuilder SetWeatherSettings(WeatherRoot weatherSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(weatherSettings);
          bp.WeatherSettings = weatherSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.WeatherSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeatherSettings(Action<WeatherRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.WeatherSettings is null) { return; }
          action.Invoke(bp.WeatherSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.DlcSettings"/>
    /// </summary>
    public TBuilder SetDlcSettings(DlcRoot dlcSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dlcSettings);
          bp.DlcSettings = dlcSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.DlcSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDlcSettings(Action<DlcRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DlcSettings is null) { return; }
          action.Invoke(bp.DlcSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.NewGameSettings"/>
    /// </summary>
    public TBuilder SetNewGameSettings(NewGameRoot newGameSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(newGameSettings);
          bp.NewGameSettings = newGameSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.NewGameSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNewGameSettings(Action<NewGameRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NewGameSettings is null) { return; }
          action.Invoke(bp.NewGameSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.SurfaceTypeData"/>
    /// </summary>
    public TBuilder SetSurfaceTypeData(SurfaceTypeData surfaceTypeData)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(surfaceTypeData);
          bp.SurfaceTypeData = surfaceTypeData;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.SurfaceTypeData"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySurfaceTypeData(Action<SurfaceTypeData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SurfaceTypeData is null) { return; }
          action.Invoke(bp.SurfaceTypeData);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_InvisibleKittenUnit"/>
    /// </summary>
    ///
    /// <param name="invisibleKittenUnit">
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
    public TBuilder SetInvisibleKittenUnit(Blueprint<BlueprintUnitReference> invisibleKittenUnit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_InvisibleKittenUnit = invisibleKittenUnit?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_InvisibleKittenUnit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInvisibleKittenUnit(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_InvisibleKittenUnit is null) { return; }
          action.Invoke(bp.m_InvisibleKittenUnit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.OptimizationDummyUnit"/>
    /// </summary>
    public TBuilder SetOptimizationDummyUnit(PrefabLink optimizationDummyUnit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OptimizationDummyUnit = optimizationDummyUnit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.OptimizationDummyUnit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOptimizationDummyUnit(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OptimizationDummyUnit is null) { return; }
          action.Invoke(bp.OptimizationDummyUnit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_CoinItem"/>
    /// </summary>
    ///
    /// <param name="coinItem">
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
    public TBuilder SetCoinItem(Blueprint<BlueprintItemReference> coinItem)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CoinItem = coinItem?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_CoinItem"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCoinItem(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CoinItem is null) { return; }
          action.Invoke(bp.m_CoinItem);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.LocalizedTexts"/>
    /// </summary>
    public TBuilder SetLocalizedTexts(LocalizedTexts localizedTexts)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(localizedTexts);
          bp.LocalizedTexts = localizedTexts;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.LocalizedTexts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedTexts(Action<LocalizedTexts> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedTexts is null) { return; }
          action.Invoke(bp.LocalizedTexts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.SettingsRoot"/>
    /// </summary>
    public TBuilder SetSettingsRoot(UISettingsRoot settingsRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(settingsRoot);
          bp.SettingsRoot = settingsRoot;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.SettingsRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySettingsRoot(Action<UISettingsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SettingsRoot is null) { return; }
          action.Invoke(bp.SettingsRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_DifficultyList"/>
    /// </summary>
    public TBuilder SetDifficultyList(DifficultyPresetsList difficultyList)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(difficultyList);
          bp.m_DifficultyList = difficultyList;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_DifficultyList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDifficultyList(Action<DifficultyPresetsList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DifficultyList is null) { return; }
          action.Invoke(bp.m_DifficultyList);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.SettingsValues"/>
    /// </summary>
    public TBuilder SetSettingsValues(SettingsValues settingsValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(settingsValues);
          bp.SettingsValues = settingsValues;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.SettingsValues"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySettingsValues(Action<SettingsValues> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SettingsValues is null) { return; }
          action.Invoke(bp.SettingsValues);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.StealthEffectPrefab"/>
    /// </summary>
    public TBuilder SetStealthEffectPrefab(GameObject stealthEffectPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(stealthEffectPrefab);
          bp.StealthEffectPrefab = stealthEffectPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.StealthEffectPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStealthEffectPrefab(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StealthEffectPrefab is null) { return; }
          action.Invoke(bp.StealthEffectPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.ExitStealthEffectPrefab"/>
    /// </summary>
    public TBuilder SetExitStealthEffectPrefab(GameObject exitStealthEffectPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(exitStealthEffectPrefab);
          bp.ExitStealthEffectPrefab = exitStealthEffectPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.ExitStealthEffectPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExitStealthEffectPrefab(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExitStealthEffectPrefab is null) { return; }
          action.Invoke(bp.ExitStealthEffectPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.WeaponModelSizing"/>
    /// </summary>
    public TBuilder SetWeaponModelSizing(WeaponModelSizeSettings weaponModelSizing)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(weaponModelSizing);
          bp.WeaponModelSizing = weaponModelSizing;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.WeaponModelSizing"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeaponModelSizing(Action<WeaponModelSizeSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.WeaponModelSizing is null) { return; }
          action.Invoke(bp.WeaponModelSizing);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.BeltItemModelSizing"/>
    /// </summary>
    public TBuilder SetBeltItemModelSizing(BeltItemModelSizeSettings beltItemModelSizing)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(beltItemModelSizing);
          bp.BeltItemModelSizing = beltItemModelSizing;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.BeltItemModelSizing"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBeltItemModelSizing(Action<BeltItemModelSizeSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BeltItemModelSizing is null) { return; }
          action.Invoke(bp.BeltItemModelSizing);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.MountModelSizing"/>
    /// </summary>
    public TBuilder SetMountModelSizing(MountModelSizeSetting mountModelSizing)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(mountModelSizing);
          bp.MountModelSizing = mountModelSizing;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.MountModelSizing"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMountModelSizing(Action<MountModelSizeSetting> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MountModelSizing is null) { return; }
          action.Invoke(bp.MountModelSizing);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Sound"/>
    /// </summary>
    public TBuilder SetSound(SoundRoot sound)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(sound);
          bp.Sound = sound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Sound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySound(Action<SoundRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Sound is null) { return; }
          action.Invoke(bp.Sound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_CutscenesRoot"/>
    /// </summary>
    ///
    /// <param name="cutscenesRoot">
    /// <para>
    /// Blueprint of type CutscenesRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCutscenesRoot(Blueprint<CutscenesRoot.Reference> cutscenesRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CutscenesRoot = cutscenesRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_CutscenesRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCutscenesRoot(Action<CutscenesRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CutscenesRoot is null) { return; }
          action.Invoke(bp.m_CutscenesRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_Kingdom"/>
    /// </summary>
    ///
    /// <param name="kingdom">
    /// <para>
    /// Blueprint of type KingdomRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetKingdom(Blueprint<KingdomRootReference> kingdom)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Kingdom = kingdom?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_Kingdom"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingdom(Action<KingdomRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Kingdom is null) { return; }
          action.Invoke(bp.m_Kingdom);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_CorruptionRoot"/>
    /// </summary>
    ///
    /// <param name="corruptionRoot">
    /// <para>
    /// Blueprint of type BlueprintCorruptionRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCorruptionRoot(Blueprint<BlueprintCorruptionRoot.Reference> corruptionRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CorruptionRoot = corruptionRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_CorruptionRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCorruptionRoot(Action<BlueprintCorruptionRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CorruptionRoot is null) { return; }
          action.Invoke(bp.m_CorruptionRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_ArmyRoot"/>
    /// </summary>
    ///
    /// <param name="armyRoot">
    /// <para>
    /// Blueprint of type ArmyRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmyRoot(Blueprint<ArmyRootReference> armyRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyRoot = armyRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_ArmyRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmyRoot(Action<ArmyRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmyRoot is null) { return; }
          action.Invoke(bp.m_ArmyRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_CraftRoot"/>
    /// </summary>
    ///
    /// <param name="craftRoot">
    /// <para>
    /// Blueprint of type CraftRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCraftRoot(Blueprint<CraftRoot.Reference> craftRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CraftRoot = craftRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_CraftRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCraftRoot(Action<CraftRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CraftRoot is null) { return; }
          action.Invoke(bp.m_CraftRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_LeadersRoot"/>
    /// </summary>
    ///
    /// <param name="leadersRoot">
    /// <para>
    /// Blueprint of type LeadersRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLeadersRoot(Blueprint<LeadersRootReference> leadersRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LeadersRoot = leadersRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_LeadersRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeadersRoot(Action<LeadersRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LeadersRoot is null) { return; }
          action.Invoke(bp.m_LeadersRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_MoraleRoot"/>
    /// </summary>
    ///
    /// <param name="moraleRoot">
    /// <para>
    /// Blueprint of type MoraleRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMoraleRoot(Blueprint<MoraleRoot.Reference> moraleRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MoraleRoot = moraleRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_MoraleRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMoraleRoot(Action<MoraleRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MoraleRoot is null) { return; }
          action.Invoke(bp.m_MoraleRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_TacticalCombat"/>
    /// </summary>
    ///
    /// <param name="tacticalCombat">
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTacticalCombat(Blueprint<BlueprintTacticalCombatRoot.Reference> tacticalCombat)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TacticalCombat = tacticalCombat?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_TacticalCombat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTacticalCombat(Action<BlueprintTacticalCombatRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TacticalCombat is null) { return; }
          action.Invoke(bp.m_TacticalCombat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Calendar"/>
    /// </summary>
    public TBuilder SetCalendar(CalendarRoot calendar)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(calendar);
          bp.Calendar = calendar;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Calendar"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCalendar(Action<CalendarRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Calendar is null) { return; }
          action.Invoke(bp.Calendar);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_Formations"/>
    /// </summary>
    ///
    /// <param name="formations">
    /// <para>
    /// Blueprint of type FormationsRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFormations(Blueprint<FormationsRootReference> formations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Formations = formations?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_Formations"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFormations(Action<FormationsRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Formations is null) { return; }
          action.Invoke(bp.m_Formations);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.RazerColorData"/>
    /// </summary>
    public TBuilder SetRazerColorData(RazerColorData razerColorData)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(razerColorData);
          bp.RazerColorData = razerColorData;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.RazerColorData"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRazerColorData(Action<RazerColorData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RazerColorData is null) { return; }
          action.Invoke(bp.RazerColorData);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Animation"/>
    /// </summary>
    public TBuilder SetAnimation(AnimationRoot animation)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(animation);
          bp.Animation = animation;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Animation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAnimation(Action<AnimationRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Animation is null) { return; }
          action.Invoke(bp.Animation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Camping"/>
    /// </summary>
    public TBuilder SetCamping(CampingRoot camping)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(camping);
          bp.Camping = camping;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Camping"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCamping(Action<CampingRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Camping is null) { return; }
          action.Invoke(bp.Camping);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_FxRoot"/>
    /// </summary>
    ///
    /// <param name="fxRoot">
    /// <para>
    /// Blueprint of type FxRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFxRoot(Blueprint<FxRootReference> fxRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FxRoot = fxRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_FxRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFxRoot(Action<FxRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FxRoot is null) { return; }
          action.Invoke(bp.m_FxRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_HitSystemRoot"/>
    /// </summary>
    ///
    /// <param name="hitSystemRoot">
    /// <para>
    /// Blueprint of type HitSystemRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetHitSystemRoot(Blueprint<HitSystemRootReference> hitSystemRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HitSystemRoot = hitSystemRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_HitSystemRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHitSystemRoot(Action<HitSystemRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HitSystemRoot is null) { return; }
          action.Invoke(bp.m_HitSystemRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_PlayerUpgradeActions"/>
    /// </summary>
    ///
    /// <param name="playerUpgradeActions">
    /// <para>
    /// Blueprint of type PlayerUpgradeActionsRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPlayerUpgradeActions(Blueprint<PlayerUpgradeActionsRoot.Reference> playerUpgradeActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerUpgradeActions = playerUpgradeActions?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_PlayerUpgradeActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPlayerUpgradeActions(Action<PlayerUpgradeActionsRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PlayerUpgradeActions is null) { return; }
          action.Invoke(bp.m_PlayerUpgradeActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_CustomCompanion"/>
    /// </summary>
    ///
    /// <param name="customCompanion">
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
    public TBuilder SetCustomCompanion(Blueprint<BlueprintUnitReference> customCompanion)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CustomCompanion = customCompanion?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_CustomCompanion"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomCompanion(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CustomCompanion is null) { return; }
          action.Invoke(bp.m_CustomCompanion);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.CustomCompanionBaseCost"/>
    /// </summary>
    public TBuilder SetCustomCompanionBaseCost(int customCompanionBaseCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomCompanionBaseCost = customCompanionBaseCost;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.StandartPerceptionRadius"/>
    /// </summary>
    public TBuilder SetStandartPerceptionRadius(int standartPerceptionRadius)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StandartPerceptionRadius = standartPerceptionRadius;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.AreaEffectAutoDestroySeconds"/>
    /// </summary>
    public TBuilder SetAreaEffectAutoDestroySeconds(int areaEffectAutoDestroySeconds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AreaEffectAutoDestroySeconds = areaEffectAutoDestroySeconds;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.AnnoyingConditionsAutoDestroySeconds"/>
    /// </summary>
    public TBuilder SetAnnoyingConditionsAutoDestroySeconds(int annoyingConditionsAutoDestroySeconds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AnnoyingConditionsAutoDestroySeconds = annoyingConditionsAutoDestroySeconds;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.DefaultDissolveTexture"/>
    /// </summary>
    public TBuilder SetDefaultDissolveTexture(Texture2D defaultDissolveTexture)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(defaultDissolveTexture);
          bp.DefaultDissolveTexture = defaultDissolveTexture;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.DefaultDissolveTexture"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultDissolveTexture(Action<Texture2D> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultDissolveTexture is null) { return; }
          action.Invoke(bp.DefaultDissolveTexture);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.Achievements"/>
    /// </summary>
    public TBuilder SetAchievements(AchievementsRoot achievements)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(achievements);
          bp.Achievements = achievements;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.Achievements"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAchievements(Action<AchievementsRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Achievements is null) { return; }
          action.Invoke(bp.Achievements);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_UnitTypes"/>
    /// </summary>
    ///
    /// <param name="unitTypes">
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
    public TBuilder SetUnitTypes(params Blueprint<BlueprintUnitTypeReference>[] unitTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTypes = unitTypes.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRoot.m_UnitTypes"/>
    /// </summary>
    ///
    /// <param name="unitTypes">
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
    public TBuilder AddToUnitTypes(params Blueprint<BlueprintUnitTypeReference>[] unitTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTypes = bp.m_UnitTypes ?? new BlueprintUnitTypeReference[0];
          bp.m_UnitTypes = CommonTool.Append(bp.m_UnitTypes, unitTypes.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRoot.m_UnitTypes"/>
    /// </summary>
    ///
    /// <param name="unitTypes">
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
    public TBuilder RemoveFromUnitTypes(params Blueprint<BlueprintUnitTypeReference>[] unitTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTypes is null) { return; }
          bp.m_UnitTypes = bp.m_UnitTypes.Where(val => !unitTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRoot.m_UnitTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitTypes(Func<BlueprintUnitTypeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTypes is null) { return; }
          bp.m_UnitTypes = bp.m_UnitTypes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRoot.m_UnitTypes"/>
    /// </summary>
    public TBuilder ClearUnitTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UnitTypes = new BlueprintUnitTypeReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_UnitTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitTypes(Action<BlueprintUnitTypeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitTypes is null) { return; }
          bp.m_UnitTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.TestUIStyles"/>
    /// </summary>
    public TBuilder SetTestUIStyles(TestUIStylesRoot testUIStyles)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(testUIStyles);
          bp.TestUIStyles = testUIStyles;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.TestUIStyles"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTestUIStyles(Action<TestUIStylesRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TestUIStyles is null) { return; }
          action.Invoke(bp.TestUIStyles);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_Dungeon"/>
    /// </summary>
    ///
    /// <param name="dungeon">
    /// <para>
    /// Blueprint of type BlueprintDungeonRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDungeon(Blueprint<BlueprintDungeonRootReference> dungeon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Dungeon = dungeon?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_Dungeon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDungeon(Action<BlueprintDungeonRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Dungeon is null) { return; }
          action.Invoke(bp.m_Dungeon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_ConsoleRoot"/>
    /// </summary>
    ///
    /// <param name="consoleRoot">
    /// <para>
    /// Blueprint of type ConsoleRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetConsoleRoot(Blueprint<ConsoleRootReference> consoleRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConsoleRoot = consoleRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_ConsoleRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConsoleRoot(Action<ConsoleRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConsoleRoot is null) { return; }
          action.Invoke(bp.m_ConsoleRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_BlueprintTrapSettingsRoot"/>
    /// </summary>
    ///
    /// <param name="blueprintTrapSettingsRoot">
    /// <para>
    /// Blueprint of type BlueprintTrapSettingsRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBlueprintTrapSettingsRoot(Blueprint<BlueprintTrapSettingsRootReference> blueprintTrapSettingsRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BlueprintTrapSettingsRoot = blueprintTrapSettingsRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_BlueprintTrapSettingsRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBlueprintTrapSettingsRoot(Action<BlueprintTrapSettingsRootReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BlueprintTrapSettingsRoot is null) { return; }
          action.Invoke(bp.m_BlueprintTrapSettingsRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_InteractionRoot"/>
    /// </summary>
    ///
    /// <param name="interactionRoot">
    /// <para>
    /// Blueprint of type BlueprintInteractionRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetInteractionRoot(Blueprint<BlueprintInteractionRoot.Referense> interactionRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_InteractionRoot = interactionRoot?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_InteractionRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInteractionRoot(Action<BlueprintInteractionRoot.Referense> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_InteractionRoot is null) { return; }
          action.Invoke(bp.m_InteractionRoot);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_BlueprintMythicsSettingsReference"/>
    /// </summary>
    ///
    /// <param name="blueprintMythicsSettingsReference">
    /// <para>
    /// Blueprint of type BlueprintMythicsSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBlueprintMythicsSettingsReference(Blueprint<BlueprintMythicsSettingsReference> blueprintMythicsSettingsReference)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BlueprintMythicsSettingsReference = blueprintMythicsSettingsReference?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_BlueprintMythicsSettingsReference"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBlueprintMythicsSettingsReference(Action<BlueprintMythicsSettingsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BlueprintMythicsSettingsReference is null) { return; }
          action.Invoke(bp.m_BlueprintMythicsSettingsReference);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_CustomAiConsiderations"/>
    /// </summary>
    ///
    /// <param name="customAiConsiderations">
    /// <para>
    /// Blueprint of type CustomAiConsiderationsRoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCustomAiConsiderations(Blueprint<CustomAiConsiderationsRoot.Reference> customAiConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CustomAiConsiderations = customAiConsiderations?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_CustomAiConsiderations"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomAiConsiderations(Action<CustomAiConsiderationsRoot.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CustomAiConsiderations is null) { return; }
          action.Invoke(bp.m_CustomAiConsiderations);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRoot.m_BlueprintBugReportTutorialReference"/>
    /// </summary>
    ///
    /// <param name="blueprintBugReportTutorialReference">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBlueprintBugReportTutorialReference(Blueprint<BlueprintTutorial.Reference> blueprintBugReportTutorialReference)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BlueprintBugReportTutorialReference = blueprintBugReportTutorialReference?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_BlueprintBugReportTutorialReference"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBlueprintBugReportTutorialReference(Action<BlueprintTutorial.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BlueprintBugReportTutorialReference is null) { return; }
          action.Invoke(bp.m_BlueprintBugReportTutorialReference);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DefaultPlayerCharacter is null)
      {
        Blueprint.m_DefaultPlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.m_SelectablePlayerCharacters is null)
      {
        Blueprint.m_SelectablePlayerCharacters = new BlueprintUnitReference[0];
      }
      if (Blueprint.m_PlayerFaction is null)
      {
        Blueprint.m_PlayerFaction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      if (Blueprint.m_KingFlag is null)
      {
        Blueprint.m_KingFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      if (Blueprint.m_NewGamePreset is null)
      {
        Blueprint.m_NewGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(null);
      }
      if (Blueprint.StartGameActions is null)
      {
        Blueprint.StartGameActions = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.m_RE is null)
      {
        Blueprint.m_RE = BlueprintTool.GetRef<RandomEncountersRootReference>(null);
      }
      if (Blueprint.m_InvisibleKittenUnit is null)
      {
        Blueprint.m_InvisibleKittenUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.OptimizationDummyUnit is null)
      {
        Blueprint.OptimizationDummyUnit = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_CoinItem is null)
      {
        Blueprint.m_CoinItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      if (Blueprint.m_CutscenesRoot is null)
      {
        Blueprint.m_CutscenesRoot = BlueprintTool.GetRef<CutscenesRoot.Reference>(null);
      }
      if (Blueprint.m_Kingdom is null)
      {
        Blueprint.m_Kingdom = BlueprintTool.GetRef<KingdomRootReference>(null);
      }
      if (Blueprint.m_CorruptionRoot is null)
      {
        Blueprint.m_CorruptionRoot = BlueprintTool.GetRef<BlueprintCorruptionRoot.Reference>(null);
      }
      if (Blueprint.m_ArmyRoot is null)
      {
        Blueprint.m_ArmyRoot = BlueprintTool.GetRef<ArmyRootReference>(null);
      }
      if (Blueprint.m_CraftRoot is null)
      {
        Blueprint.m_CraftRoot = BlueprintTool.GetRef<CraftRoot.Reference>(null);
      }
      if (Blueprint.m_LeadersRoot is null)
      {
        Blueprint.m_LeadersRoot = BlueprintTool.GetRef<LeadersRootReference>(null);
      }
      if (Blueprint.m_MoraleRoot is null)
      {
        Blueprint.m_MoraleRoot = BlueprintTool.GetRef<MoraleRoot.Reference>(null);
      }
      if (Blueprint.m_TacticalCombat is null)
      {
        Blueprint.m_TacticalCombat = BlueprintTool.GetRef<BlueprintTacticalCombatRoot.Reference>(null);
      }
      if (Blueprint.m_Formations is null)
      {
        Blueprint.m_Formations = BlueprintTool.GetRef<FormationsRootReference>(null);
      }
      if (Blueprint.m_FxRoot is null)
      {
        Blueprint.m_FxRoot = BlueprintTool.GetRef<FxRootReference>(null);
      }
      if (Blueprint.m_HitSystemRoot is null)
      {
        Blueprint.m_HitSystemRoot = BlueprintTool.GetRef<HitSystemRootReference>(null);
      }
      if (Blueprint.m_PlayerUpgradeActions is null)
      {
        Blueprint.m_PlayerUpgradeActions = BlueprintTool.GetRef<PlayerUpgradeActionsRoot.Reference>(null);
      }
      if (Blueprint.m_CustomCompanion is null)
      {
        Blueprint.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.m_UnitTypes is null)
      {
        Blueprint.m_UnitTypes = new BlueprintUnitTypeReference[0];
      }
      if (Blueprint.m_Dungeon is null)
      {
        Blueprint.m_Dungeon = BlueprintTool.GetRef<BlueprintDungeonRootReference>(null);
      }
      if (Blueprint.m_ConsoleRoot is null)
      {
        Blueprint.m_ConsoleRoot = BlueprintTool.GetRef<ConsoleRootReference>(null);
      }
      if (Blueprint.m_BlueprintTrapSettingsRoot is null)
      {
        Blueprint.m_BlueprintTrapSettingsRoot = BlueprintTool.GetRef<BlueprintTrapSettingsRootReference>(null);
      }
      if (Blueprint.m_InteractionRoot is null)
      {
        Blueprint.m_InteractionRoot = BlueprintTool.GetRef<BlueprintInteractionRoot.Referense>(null);
      }
      if (Blueprint.m_BlueprintMythicsSettingsReference is null)
      {
        Blueprint.m_BlueprintMythicsSettingsReference = BlueprintTool.GetRef<BlueprintMythicsSettingsReference>(null);
      }
      if (Blueprint.m_CustomAiConsiderations is null)
      {
        Blueprint.m_CustomAiConsiderations = BlueprintTool.GetRef<CustomAiConsiderationsRoot.Reference>(null);
      }
      if (Blueprint.m_BlueprintBugReportTutorialReference is null)
      {
        Blueprint.m_BlueprintBugReportTutorialReference = BlueprintTool.GetRef<BlueprintTutorial.Reference>(null);
      }
    }
  }
}
