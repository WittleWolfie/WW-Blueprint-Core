using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Corruption;
using Kingmaker.Craft;
using Kingmaker.Interaction;
using Kingmaker.RazerChroma;
using Kingmaker.ResourceLinks;
using Kingmaker.Settings;
using Kingmaker.Settings.Difficulty;
using Kingmaker.UI.SettingsUI;
using Kingmaker.Visual.Animation;
using Kingmaker.Visual.Sound;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="BlueprintRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRoot))]
  public class RootConfigurator : BaseBlueprintConfigurator<BlueprintRoot, RootConfigurator>
  {
     private RootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RootConfigurator For(string name)
    {
      return new RootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_DefaultPlayerCharacter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetDefaultPlayerCharacter(string value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultPlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator AddToSelectablePlayerCharacters(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_SelectablePlayerCharacters = CommonTool.Append(bp.m_SelectablePlayerCharacters, values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator RemoveFromSelectablePlayerCharacters(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_SelectablePlayerCharacters =
                bp.m_SelectablePlayerCharacters
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_PlayerFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintFaction"/></param>
    [Generated]
    public RootConfigurator SetPlayerFaction(string value)
    {
      return OnConfigureInternal(bp => bp.m_PlayerFaction = BlueprintTool.GetRef<BlueprintFactionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.CompanionsAI"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCompanionsAI(bool value)
    {
      return OnConfigureInternal(bp => bp.CompanionsAI = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_KingFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    public RootConfigurator SetKingFlag(string value)
    {
      return OnConfigureInternal(bp => bp.m_KingFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.MinProjectileMissDeviation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetMinProjectileMissDeviation(float value)
    {
      return OnConfigureInternal(bp => bp.MinProjectileMissDeviation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.MaxProjectileMissDeviation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetMaxProjectileMissDeviation(float value)
    {
      return OnConfigureInternal(bp => bp.MaxProjectileMissDeviation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.HumanAnimationSet"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetHumanAnimationSet(AnimationSet value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.HumanAnimationSet = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_NewGamePreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    public RootConfigurator SetNewGamePreset(string value)
    {
      return OnConfigureInternal(bp => bp.m_NewGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StartGameActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStartGameActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.StartGameActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Dialog"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDialog(DialogRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Dialog = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Cheats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCheats(CheatRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Cheats = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_RE"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="RandomEncountersRoot"/></param>
    [Generated]
    public RootConfigurator SetRE(string value)
    {
      return OnConfigureInternal(bp => bp.m_RE = BlueprintTool.GetRef<RandomEncountersRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_GlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetGlobalMap(GlobalMapRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_GlobalMap = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Progression"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetProgression(ProgressionRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Progression = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.CharGen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCharGen(CharGenRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CharGen = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Prefabs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetPrefabs(Prefabs value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Prefabs = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.OccludedCharacterColors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetOccludedCharacterColors(OccludedCharacterColors value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.OccludedCharacterColors = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.UIRoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetUIRoot(UIRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UIRoot = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Quests"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetQuests(QuestsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Quests = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Vendors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetVendors(VendorsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Vendors = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SystemMechanics"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSystemMechanics(SystemMechanicsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SystemMechanics = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StatusBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStatusBuffs(StatusBuffsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StatusBuffs = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Cursors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCursors(CursorRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Cursors = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.WeatherSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetWeatherSettings(WeatherRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.WeatherSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.DlcSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDlcSettings(DlcRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DlcSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.NewGameSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetNewGameSettings(NewGameRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.NewGameSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SurfaceTypeData"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSurfaceTypeData(SurfaceTypeData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SurfaceTypeData = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_InvisibleKittenUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetInvisibleKittenUnit(string value)
    {
      return OnConfigureInternal(bp => bp.m_InvisibleKittenUnit = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.OptimizationDummyUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetOptimizationDummyUnit(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.OptimizationDummyUnit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CoinItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public RootConfigurator SetCoinItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_CoinItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.LocalizedTexts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetLocalizedTexts(LocalizedTexts value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LocalizedTexts = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SettingsRoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSettingsRoot(UISettingsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SettingsRoot = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_DifficultyList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDifficultyList(DifficultyPresetsList value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DifficultyList = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SettingsValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSettingsValues(SettingsValues value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SettingsValues = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StealthEffectPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStealthEffectPrefab(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StealthEffectPrefab = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.ExitStealthEffectPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetExitStealthEffectPrefab(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ExitStealthEffectPrefab = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.WeaponModelSizing"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetWeaponModelSizing(WeaponModelSizeSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.WeaponModelSizing = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.MountModelSizing"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetMountModelSizing(MountModelSizeSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MountModelSizing = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Sound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSound(SoundRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Sound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CutscenesRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CutscenesRoot"/></param>
    [Generated]
    public RootConfigurator SetCutscenesRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_CutscenesRoot = BlueprintTool.GetRef<CutscenesRoot.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_Kingdom"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="KingdomRoot"/></param>
    [Generated]
    public RootConfigurator SetKingdom(string value)
    {
      return OnConfigureInternal(bp => bp.m_Kingdom = BlueprintTool.GetRef<KingdomRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CorruptionRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCorruptionRoot"/></param>
    [Generated]
    public RootConfigurator SetCorruptionRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_CorruptionRoot = BlueprintTool.GetRef<BlueprintCorruptionRoot.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_ArmyRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="ArmyRoot"/></param>
    [Generated]
    public RootConfigurator SetArmyRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_ArmyRoot = BlueprintTool.GetRef<ArmyRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CraftRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CraftRoot"/></param>
    [Generated]
    public RootConfigurator SetCraftRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_CraftRoot = BlueprintTool.GetRef<CraftRoot.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_LeadersRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="LeadersRoot"/></param>
    [Generated]
    public RootConfigurator SetLeadersRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_LeadersRoot = BlueprintTool.GetRef<LeadersRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_MoraleRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="MoraleRoot"/></param>
    [Generated]
    public RootConfigurator SetMoraleRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_MoraleRoot = BlueprintTool.GetRef<MoraleRoot.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_TacticalCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintTacticalCombatRoot"/></param>
    [Generated]
    public RootConfigurator SetTacticalCombat(string value)
    {
      return OnConfigureInternal(bp => bp.m_TacticalCombat = BlueprintTool.GetRef<BlueprintTacticalCombatRoot.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Calendar"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCalendar(CalendarRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Calendar = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_Formations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="FormationsRoot"/></param>
    [Generated]
    public RootConfigurator SetFormations(string value)
    {
      return OnConfigureInternal(bp => bp.m_Formations = BlueprintTool.GetRef<FormationsRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.RazerColorData"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetRazerColorData(RazerColorData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RazerColorData = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Animation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAnimation(AnimationRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Animation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Camping"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCamping(CampingRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Camping = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_FxRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="FxRoot"/></param>
    [Generated]
    public RootConfigurator SetFxRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_FxRoot = BlueprintTool.GetRef<FxRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_HitSystemRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="HitSystemRoot"/></param>
    [Generated]
    public RootConfigurator SetHitSystemRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_HitSystemRoot = BlueprintTool.GetRef<HitSystemRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_PlayerUpgradeActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="PlayerUpgradeActionsRoot"/></param>
    [Generated]
    public RootConfigurator SetPlayerUpgradeActions(string value)
    {
      return OnConfigureInternal(bp => bp.m_PlayerUpgradeActions = BlueprintTool.GetRef<PlayerUpgradeActionsRoot.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CustomCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetCustomCompanion(string value)
    {
      return OnConfigureInternal(bp => bp.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.CustomCompanionBaseCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCustomCompanionBaseCost(int value)
    {
      return OnConfigureInternal(bp => bp.CustomCompanionBaseCost = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StandartPerceptionRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStandartPerceptionRadius(int value)
    {
      return OnConfigureInternal(bp => bp.StandartPerceptionRadius = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.AreaEffectAutoDestroySeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAreaEffectAutoDestroySeconds(int value)
    {
      return OnConfigureInternal(bp => bp.AreaEffectAutoDestroySeconds = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.AnnoyingConditionsAutoDestroySeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAnnoyingConditionsAutoDestroySeconds(int value)
    {
      return OnConfigureInternal(bp => bp.AnnoyingConditionsAutoDestroySeconds = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.DefaultDissolveTexture"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDefaultDissolveTexture(Texture2D value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultDissolveTexture = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Achievements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAchievements(AchievementsRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Achievements = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_UnitTypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitType"/></param>
    [Generated]
    public RootConfigurator AddToUnitTypes(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_UnitTypes = CommonTool.Append(bp.m_UnitTypes, values.Select(name => BlueprintTool.GetRef<BlueprintUnitTypeReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRoot.m_UnitTypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitType"/></param>
    [Generated]
    public RootConfigurator RemoveFromUnitTypes(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitTypeReference>(name));
            bp.m_UnitTypes =
                bp.m_UnitTypes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.TestUIStyles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetTestUIStyles(TestUIStylesRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TestUIStyles = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_Dungeon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDungeonRoot"/></param>
    [Generated]
    public RootConfigurator SetDungeon(string value)
    {
      return OnConfigureInternal(bp => bp.m_Dungeon = BlueprintTool.GetRef<BlueprintDungeonRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_ConsoleRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="ConsoleRoot"/></param>
    [Generated]
    public RootConfigurator SetConsoleRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_ConsoleRoot = BlueprintTool.GetRef<ConsoleRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_BlueprintTrapSettingsRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintTrapSettingsRoot"/></param>
    [Generated]
    public RootConfigurator SetBlueprintTrapSettingsRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_BlueprintTrapSettingsRoot = BlueprintTool.GetRef<BlueprintTrapSettingsRootReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_InteractionRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintInteractionRoot"/></param>
    [Generated]
    public RootConfigurator SetInteractionRoot(string value)
    {
      return OnConfigureInternal(bp => bp.m_InteractionRoot = BlueprintTool.GetRef<BlueprintInteractionRoot.Referense>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_BlueprintMythicsSettingsReference"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintMythicsSettings"/></param>
    [Generated]
    public RootConfigurator SetBlueprintMythicsSettingsReference(string value)
    {
      return OnConfigureInternal(bp => bp.m_BlueprintMythicsSettingsReference = BlueprintTool.GetRef<BlueprintMythicsSettingsReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CustomAiConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CustomAiConsiderationsRoot"/></param>
    [Generated]
    public RootConfigurator SetCustomAiConsiderations(string value)
    {
      return OnConfigureInternal(bp => bp.m_CustomAiConsiderations = BlueprintTool.GetRef<CustomAiConsiderationsRoot.Reference>(value));
    }
  }
}
