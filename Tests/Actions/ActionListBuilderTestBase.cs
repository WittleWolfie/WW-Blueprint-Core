using System;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Xunit;

namespace BlueprintCore.Tests.Actions
{
  [Collection("Harmony")]
  public abstract class ActionListBuilderTestBase : IDisposable
  {
    //----- AchievementData -----//
    protected static readonly string AchievementGuid = "f2c71962-3b0d-42f4-af9f-be567ebc5047";
    protected readonly AchievementData Achievement =
        CreateBlueprint<AchievementData>(AchievementGuid);

    //----- BlueprintAbility -----//
    protected static readonly string AbilityGuid = "fb43a111-d0bc-4e10-9933-3650ce806bb9";
    protected readonly BlueprintAbility Ability =
        CreateBlueprint<BlueprintAbility>(AbilityGuid);

    //----- BlueprintAbilityAreaEffect -----//
    protected static readonly string AbilityAOEGuid = "989a4bc7-89d0-451d-a0ea-5c6c3336dad0";
    protected readonly BlueprintAbilityAreaEffect AbilityAOE =
        CreateBlueprint<BlueprintAbilityAreaEffect>(AbilityAOEGuid);

    //----- BlueprintAbilityResource -----//
    protected static readonly string AbilityResourceGuid = "1a7a5f9e-03ff-4e98-a3e0-7d90cd341597";
    protected readonly BlueprintAbilityResource AbilityResource =
        CreateBlueprint<BlueprintAbilityResource>(AbilityResourceGuid);

    //----- BlueprintActionList -----//
    protected static readonly string ActionListGuid = "650c5d8c-56cb-4685-9d38-7c6c8e8c68af";
    protected readonly BlueprintActionList ActionList =
        CreateBlueprint<BlueprintActionList>(ActionListGuid);

    //----- BlueprintArchetype -----//
    protected static readonly string ArchetypeGuid = "b8b6eced-4edd-40a6-acb1-1827b6599cfc";
    protected readonly BlueprintArchetype Archetype =
        CreateBlueprint<BlueprintArchetype>(ArchetypeGuid);

    //----- BlueprintAreaEnterPoint -----//
    protected static readonly string AreaEnterPointGuid = "47f9c4ca-1d8c-4d46-86ac-29246e1c4ab0";
    protected readonly BlueprintAreaEnterPoint AreaEnterPoint =
        CreateBlueprint<BlueprintAreaEnterPoint>(AreaEnterPointGuid);

    //----- BlueprintArmyPreset -----//
    protected static readonly string ArmyGuid = "b8309f5f-7ac5-468b-a9e7-98cb805da802";
    protected readonly BlueprintArmyPreset Army = CreateBlueprint<BlueprintArmyPreset>(ArmyGuid);

    //----- BlueprintArmyLeader -----//
    protected static readonly string ArmyLeaderGuid = "fea29696-9fb3-4d51-a3ec-7727c0024a2a";
    protected readonly BlueprintArmyLeader ArmyLeader =
        CreateBlueprint<BlueprintArmyLeader>(ArmyLeaderGuid);

    //----- BlueprintBuff -----//
    protected static readonly string BuffGuid = "f3b38c34-2526-4ba6-a682-a751e5c05305";
    protected readonly BlueprintBuff Buff = CreateBlueprint<BlueprintBuff>(BuffGuid);

    protected static readonly string ExtraBuffGuid = "802285a2-491a-477f-b386-3fd07b5d4920";
    protected readonly BlueprintBuff ExtraBuff = CreateBlueprint<BlueprintBuff>(ExtraBuffGuid);

    //----- BlueprintCampingEncounter -----//
    protected static readonly string CampingEncounterGuid = "41c7a543-175b-41f9-8294-76c429d3b113";
    protected readonly BlueprintCampingEncounter CampingEncounter =
        CreateBlueprint<BlueprintCampingEncounter>(CampingEncounterGuid);

    //----- BlueprintControllableProjectile -----//
    protected static readonly string ControllableProjectileGuid =
            "cecbb683-02a2-42e7-baa4-ac0a8bca03e4";
    protected readonly BlueprintControllableProjectile ControllableProjectile =
        CreateBlueprint<BlueprintControllableProjectile>(ControllableProjectileGuid);

    //----- BlueprintEquipmentEnchantment -----//
    protected static readonly string EquipmentEnchantmentGuid =
        "1dd19073-1781-472a-b462-fa5dab8db2fe";
    protected readonly BlueprintEquipmentEnchantment EquipmentEnchantment =
        CreateBlueprint<BlueprintEquipmentEnchantment>(EquipmentEnchantmentGuid);

    //----- BlueprintEtude -----//
    protected static readonly string EtudeGuid = "ce7830c1-7a0a-4c78-9be5-6c36754d5682";
    protected readonly BlueprintEtude Etude = CreateBlueprint<BlueprintEtude>(EtudeGuid);

    //----- BlueprintFaction -----//
    protected static readonly string FactionGuid = "8ae8efe6-322f-4bf9-bb8d-badb4c103589";
    protected readonly BlueprintFaction Faction = CreateBlueprint<BlueprintFaction>(FactionGuid);

    //----- BlueprintFeature -----//
    protected static readonly string FeatureGuid = "e2e5be23-e9a6-46cf-b110-428f369a1daf";
    protected readonly BlueprintFeature Feature = CreateBlueprint<BlueprintFeature>(FeatureGuid);
    protected static readonly string ExtraFeatureGuid = "b5638518-8b5c-469d-a474-8cc789c69b76";
    protected readonly BlueprintFeature ExtraFeature =
            CreateBlueprint<BlueprintFeature>(ExtraFeatureGuid);

    //----- BlueprintFeatureSelection -----//
    protected static readonly string FeatureSelectionGuid = "94962093-e46d-49e1-9e0e-6e315e325e9d";
    protected readonly BlueprintFeatureSelection FeatureSelection =
            CreateBlueprint<BlueprintFeatureSelection>(FeatureSelectionGuid);

    //----- BlueprintGlobalMapPoint -----//
    protected static readonly string GlobalMapPointGuid = "5658d141-7bd0-4208-b179-2b8ede7711a8";
    protected readonly BlueprintGlobalMapPoint GlobalMapPoint =
        CreateBlueprint<BlueprintGlobalMapPoint>(GlobalMapPointGuid);

    //----- BlueprintGlobalMagicSpell -----//
    protected static readonly string GlobalSpellGuid = "a12b1b9d-59d3-4fa3-b0b7-a8077fcc3869";
    protected readonly BlueprintGlobalMagicSpell GlobalSpell =
        CreateBlueprint<BlueprintGlobalMagicSpell>(GlobalSpellGuid);

    //----- BlueprintItem -----//
    protected static readonly string ItemGuid = "e538ae39-cdd1-494b-b03b-b934b9da8dee";
    protected readonly BlueprintItem Item = CreateBlueprint<BlueprintItem>(ItemGuid);

    //----- BlueprintItemArmor -----//
    protected static readonly string ArmorGuid = "e4cafa6f-5ca0-4b7a-9eec-1172eaf63bbf";
    protected readonly BlueprintItemArmor Armor = CreateBlueprint<BlueprintItemArmor>(ArmorGuid);

    //----- BlueprintItemEquipmentHandSimple -----//
    protected static readonly string SimpleHandItemGuid = "0f729bb6-ebb7-44fd-a806-5dec705967dd";
    protected readonly BlueprintItemEquipmentHandSimple SimpleHandItem =
        CreateBlueprint<BlueprintItemEquipmentHandSimple>(SimpleHandItemGuid);

    //----- BlueprintItemWeapon -----//
    protected static readonly string WeaponGuid = "9cf61faf-4ae9-47a0-b325-2fabb13bc9e2";
    protected readonly BlueprintItemWeapon Weapon = CreateBlueprint<BlueprintItemWeapon>(WeaponGuid);

    //----- BlueprintKingdomArtisan -----//
    protected static readonly string ArtisanGuid = "3ed9a1e1-c5da-4370-b673-24a8d9d9898c";
    protected readonly BlueprintKingdomArtisan Artisan =
        CreateBlueprint<BlueprintKingdomArtisan>(ArtisanGuid);

    //----- BlueprintKingdomBuff -----//
    protected static readonly string KingdomBuffGuid = "e70c1dcd-b4ef-4022-8eea-3b17d15af334";
    protected readonly BlueprintKingdomBuff KingdomBuff =
        CreateBlueprint<BlueprintKingdomBuff>(KingdomBuffGuid);

    // //----- BlueprintKingdomDeck -----//
    protected static readonly string DeckGuid = "948ab7c7-5b44-415b-8fb2-8ac136d10401";
    protected readonly BlueprintKingdomDeck Deck = CreateBlueprint<BlueprintKingdomDeck>(DeckGuid);

    // //----- BlueprintKingdomProject -----//
    protected static readonly string ProjectGuid = "e489fed0-ed07-4aef-ae4e-ff99e6557edd";
    protected readonly BlueprintKingdomProject Project =
        CreateBlueprint<BlueprintKingdomProject>(ProjectGuid);

    //----- BlueprintProgression -----//
    protected static readonly string ProgressionGuid = "10305b16-4321-45ef-9937-1e4b66279220";
    protected readonly BlueprintProgression Progression =
        CreateBlueprint<BlueprintProgression>(ProgressionGuid);

    //----- BlueprintProjectile -----//
    protected static readonly string ProjectileGuid = "93dff70b-6e6c-4718-acfa-bc4ced9d7e51";
    protected readonly BlueprintProjectile Projectile =
        CreateBlueprint<BlueprintProjectile>(ProjectileGuid);

    //----- BlueprintQuestObjective -----//
    protected static readonly string QuestObjectiveGuid = "ed92eaad-b12f-463e-8cff-b00f5c0063a2";
    protected readonly BlueprintQuestObjective QuestObjective =
        CreateBlueprint<BlueprintQuestObjective>(QuestObjectiveGuid);

    //----- BlueprintRegion -----//
    protected static readonly string RegionGuid = "373f4c50-c351-4f1d-b95f-8129a352b943";
    protected readonly BlueprintRegion Region = CreateBlueprint<BlueprintRegion>(RegionGuid);

    //----- BlueprintRomanceCounter -----//
    protected static readonly string RomanceGuid = "8cf1c517-f456-47d3-bce2-43d9d7f7e8b7";
    protected readonly BlueprintRomanceCounter Romance =
        CreateBlueprint<BlueprintRomanceCounter>(RomanceGuid);

    //----- BlueprintSettlement -----//
    protected static readonly string SettlementGuid = "574bda63-7682-44ba-8acd-4edaaf26ca21";
    protected readonly BlueprintSettlement Settlement =
            CreateBlueprint<BlueprintSettlement>(SettlementGuid);

    //----- BlueprintSettlementBuilding -----//
    protected static readonly string SettlementBuildingGuid =
        "d2702e5c-9719-460c-919b-32fa8700ddb2";
    protected readonly BlueprintSettlementBuilding SettlementBuilding =
        CreateBlueprint<BlueprintSettlementBuilding>(SettlementBuildingGuid);

    //----- SettlementBuildList -----//
    protected static readonly string BuildListGuid = "ffa499d1-db21-4c5f-9102-ab1a913633a7";
    protected readonly SettlementBuildList BuildList =
            CreateBlueprint<SettlementBuildList>(BuildListGuid);

    //----- BlueprintSharedVendorTable -----//
    protected static readonly string VendorTableGuid = "afca4171-3d2f-47b5-ac61-9886a0c735c1";
    protected readonly BlueprintSharedVendorTable VendorTable =
        CreateBlueprint<BlueprintSharedVendorTable>(VendorTableGuid);

    //----- BlueprintSpellbook -----//
    protected static readonly string SpellbookGuid = "0f9324b6-8eec-4cb1-92bc-fe6d5a322275";
    protected readonly BlueprintSpellbook Spellbook =
        CreateBlueprint<BlueprintSpellbook>(SpellbookGuid);

    protected static readonly string ExtraSpellbookGuid = "6a8e8923-e459-4642-82e6-fd4fed02001d";
    protected readonly BlueprintSpellbook ExtraSpellbook =
        CreateBlueprint<BlueprintSpellbook>(ExtraSpellbookGuid);

    //----- BlueprintSummonPool -----//
    protected static readonly string SummonPoolGuid = "5d6d75fb-a1ce-4536-99b1-6eab90f88251";
    protected readonly BlueprintSummonPool SummonPool =
        CreateBlueprint<BlueprintSummonPool>(SummonPoolGuid);

    //----- BlueprintUnit -----//
    protected static readonly string UnitGuid = "83dd1ece-33da-4702-a3b1-5b623b0864c4";
    protected readonly BlueprintUnit Unit = CreateBlueprint<BlueprintUnit>(UnitGuid);

    //----- BlueprintUnitLoot -----//
    protected static readonly string LootGuid = "da81b8a8-ebd7-4c20-8b44-8ee1183b4df3";
    protected readonly BlueprintUnitLoot Loot = CreateBlueprint<BlueprintUnitLoot>(LootGuid);

    //----- Common Objects -----//
    protected static readonly ClickedUnit ClickedUnit = ElementTool.Create<ClickedUnit>();
    protected static readonly Distance Distance = ElementTool.Create<Distance>();
    protected static readonly IntConstant IntConstant = ElementTool.Create<IntConstant>();
    protected static readonly NearestPosition NearestPosition = ElementTool.Create<NearestPosition>();
    protected static readonly Trap Trap = ElementTool.Create<Trap>();
    protected static readonly DamageDescription Damage = new();
    protected static readonly DamageTypeDescription DamageTypeDescription =
        new() { Type = DamageType.Energy };

    public ActionListBuilderTestBase() { }

    public void Dispose()
    {
      BlueprintPatch.Clear();
    }

    protected static T CreateBlueprint<T>(string guid) where T : SimpleBlueprint, new()
    {
      var blueprint = Util.Create<T>(guid);
      BlueprintPatch.Add(blueprint);
      return blueprint;
    }
  }
}
