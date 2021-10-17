using BlueprintCore.Utils;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.AI.Blueprints;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
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
using Kingmaker.UnitLogic.Mechanics.Properties;
using System.Runtime.Serialization;
using UnityEngine;

namespace BlueprintCore.Test
{
  public static class TestData
  {
    public static void Init()
    {
      //----- AchievementData -----//
      Achievement = BlueprintPatch.Create<AchievementData>(AchievementGuid);

      //----- BlueprintAbility -----//
      TestAbility = BlueprintPatch.Create<BlueprintAbility>(AbilityGuid);
      ExtraAbility = BlueprintPatch.Create<BlueprintAbility>(ExtraAbilityGuid);
      AnotherAbility = BlueprintPatch.Create<BlueprintAbility>(AnotherAbilityGuid);

      //----- BlueprintAbilityAreaEffect -----//
      AbilityAOE = BlueprintPatch.Create<BlueprintAbilityAreaEffect>(AbilityAOEGuid);

      //----- BlueprintAbilityResource -----//
      AbilityResource = BlueprintPatch.Create<BlueprintAbilityResource>(AbilityResourceGuid);

      //----- BlueprintActionList -----//
      ActionList = BlueprintPatch.Create<BlueprintActionList>(ActionListGuid);

      //----- BlueprintAiCastSpell -----//
      AiCastSpell = BlueprintPatch.Create<BlueprintAiCastSpell>(AiCastSpellGuid);

      //----- BlueprintArchetype -----//
      Archetype = BlueprintPatch.Create<BlueprintArchetype>(ArchetypeGuid);
      ExtraArchetype = BlueprintPatch.Create<BlueprintArchetype>(ExtraArchetypeGuid);

      //----- BlueprintAreaEnterPoint -----//
      AreaEnterPoint = BlueprintPatch.Create<BlueprintAreaEnterPoint>(AreaEnterPointGuid);

      //----- BlueprintArmyPreset -----//
      Army = BlueprintPatch.Create<BlueprintArmyPreset>(ArmyGuid);

      //----- BlueprintArmyLeader -----//
      TestArmyLeader = BlueprintPatch.Create<BlueprintArmyLeader>(ArmyLeaderGuid);

      //----- BlueprintBuff -----//
      Buff = BlueprintPatch.Create<BlueprintBuff>(BuffGuid);
      ExtraBuff = BlueprintPatch.Create<BlueprintBuff>(ExtraBuffGuid);

      //----- BlueprintCampingEncounter -----//
      CampingEncounter = BlueprintPatch.Create<BlueprintCampingEncounter>(CampingEncounterGuid);

      //----- BlueprintCharacterClass -----//
      Clazz = BlueprintPatch.Create<BlueprintCharacterClass>(ClassGuid);
      ExtraClass = BlueprintPatch.Create<BlueprintCharacterClass>(ExtraClassGuid);

      //----- BlueprintControllableProjectile -----//
      TestControllableProjectile = BlueprintPatch.Create<BlueprintControllableProjectile>(ControllableProjectileGuid);

      //----- BlueprintEquipmentEnchantment -----//
      EquipmentEnchantment = BlueprintPatch.Create<BlueprintEquipmentEnchantment>(EquipmentEnchantmentGuid);

      //----- BlueprintEtude -----//
      TestEtude = BlueprintPatch.Create<BlueprintEtude>(EtudeGuid);
      ExtraEtude = BlueprintPatch.Create<BlueprintEtude>(ExtraEtudeGuid);

      //----- BlueprintFaction -----//
      Faction = BlueprintPatch.Create<BlueprintFaction>(FactionGuid);

      //----- BlueprintFeature -----//
      TestFeature = BlueprintPatch.Create<BlueprintFeature>(FeatureGuid);
      ExtraFeature = BlueprintPatch.Create<BlueprintFeature>(ExtraFeatureGuid);

      //----- BlueprintFeatureSelection -----//
      FeatureSelection = BlueprintPatch.Create<BlueprintFeatureSelection>(FeatureSelectionGuid);

      //----- BlueprintGlobalMapPoint -----//
      GlobalMapPoint = BlueprintPatch.Create<BlueprintGlobalMapPoint>(GlobalMapPointGuid);

      //----- BlueprintGlobalMagicSpell -----//
      GlobalSpell = BlueprintPatch.Create<BlueprintGlobalMagicSpell>(GlobalSpellGuid);

      //----- BlueprintItem -----//
      Item = BlueprintPatch.Create<BlueprintItem>(ItemGuid);

      //----- BlueprintItemArmor -----//
      Armor = BlueprintPatch.Create<BlueprintItemArmor>(ArmorGuid);

      //----- BlueprintItemEquipmentHandSimple -----//
      SimpleHandItem = BlueprintPatch.Create<BlueprintItemEquipmentHandSimple>(SimpleHandItemGuid);

      //----- BlueprintItemWeapon -----//
      Weapon = BlueprintPatch.Create<BlueprintItemWeapon>(WeaponGuid);

      //----- BlueprintKingdomArtisan -----//
      Artisan = BlueprintPatch.Create<BlueprintKingdomArtisan>(ArtisanGuid);

      //----- BlueprintKingdomBuff -----//
      KingdomBuff = BlueprintPatch.Create<BlueprintKingdomBuff>(KingdomBuffGuid);

      //----- BlueprintKingdomDeck -----//
      Deck = BlueprintPatch.Create<BlueprintKingdomDeck>(DeckGuid);

      // //----- BlueprintKingdomProject -----//
      Project = BlueprintPatch.Create<BlueprintKingdomProject>(ProjectGuid);

      //----- BlueprintParametrizedFeature -----//
      ParameterizedFeature = BlueprintPatch.Create<BlueprintParametrizedFeature>(ParameterizedFeatureGuid);
      ExtraParameterizedFeature = BlueprintPatch.Create<BlueprintParametrizedFeature>(ExtraParameterizedFeatureGuid);

      //----- BlueprintProgression -----//
      Progression =
          BlueprintPatch.Create<BlueprintProgression>(ProgressionGuid);

      //----- BlueprintProjectile -----//
      Projectile = BlueprintPatch.Create<BlueprintProjectile>(ProjectileGuid);

      //----- BlueprintQuestObjective -----//
      QuestObjective = BlueprintPatch.Create<BlueprintQuestObjective>(QuestObjectiveGuid);

      //----- BlueprintRegion -----//
      Region = BlueprintPatch.Create<BlueprintRegion>(RegionGuid);

      //----- BlueprintRomanceCounter -----//
      Romance = BlueprintPatch.Create<BlueprintRomanceCounter>(RomanceGuid);

      //----- BlueprintSettlement -----//
      Settlement = BlueprintPatch.Create<BlueprintSettlement>(SettlementGuid);

      //----- BlueprintSettlementBuilding -----//
      SettlementBuilding = BlueprintPatch.Create<BlueprintSettlementBuilding>(SettlementBuildingGuid);

      //----- SettlementBuildList -----//
      BuildList = BlueprintPatch.Create<SettlementBuildList>(BuildListGuid);

      //----- BlueprintSharedVendorTable -----//
      VendorTable = BlueprintPatch.Create<BlueprintSharedVendorTable>(VendorTableGuid);

      //----- BlueprintSpellbook -----//
      TestSpellbook = BlueprintPatch.Create<BlueprintSpellbook>(SpellbookGuid);
      ExtraSpellbook = BlueprintPatch.Create<BlueprintSpellbook>(ExtraSpellbookGuid);

      //----- BlueprintSummonPool -----//
      SummonPool = BlueprintPatch.Create<BlueprintSummonPool>(SummonPoolGuid);

      //----- BlueprintUnit -----//
      Unit = BlueprintPatch.Create<BlueprintUnit>(UnitGuid);

      //----- BlueprintUnitFact -----//
      TestFact = BlueprintPatch.Create<BlueprintUnitFact>(FactGuid);
      ExtraFact = BlueprintPatch.Create<BlueprintUnitFact>(ExtraFactGuid);

      //----- BlueprintUnitLoot -----//
      Loot = BlueprintPatch.Create<BlueprintUnitLoot>(LootGuid);

      //----- BlueprintUnitProperty -----//
      Property = BlueprintPatch.Create<BlueprintUnitProperty>(PropertyGuid);
      ExtraProperty = BlueprintPatch.Create<BlueprintUnitProperty>(ExtraPropertyGuid);
    }

    public static void Clear()
    {
      //----- AchievementData -----//
      Achievement = null;

      //----- BlueprintAbility -----//
      TestAbility = null;
      ExtraAbility = null;
      AnotherAbility = null;

      //----- BlueprintAbilityAreaEffect -----//
      AbilityAOE = null;

      //----- BlueprintAbilityResource -----//
      AbilityResource = null;

      //----- BlueprintActionList -----//
      ActionList = null;

      //----- BlueprintAiCastSpell -----//
      AiCastSpell = null;

      //----- BlueprintArchetype -----//
      Archetype = null;
      ExtraArchetype = null;

      //----- BlueprintAreaEnterPoint -----//
      AreaEnterPoint = null;

      //----- BlueprintArmyPreset -----//
      Army = null;

      //----- BlueprintArmyLeader -----//
      TestArmyLeader = null;

      //----- BlueprintBuff -----//
      Buff = null;
      ExtraBuff = null;

      //----- BlueprintCampingEncounter -----//
      CampingEncounter = null;

      //----- BlueprintCharacterClass -----//
      Clazz = null;
      ExtraClass = null;

      //----- BlueprintControllableProjectile -----//
      TestControllableProjectile = null;

      //----- BlueprintEquipmentEnchantment -----//
      EquipmentEnchantment = null;

      //----- BlueprintEtude -----//
      TestEtude = null;
      ExtraEtude = null;

      //----- BlueprintFaction -----//
      Faction = null;

      //----- BlueprintFeature -----//
      TestFeature = null;
      ExtraFeature = null;

      //----- BlueprintFeatureSelection -----//
      FeatureSelection = null;

      //----- BlueprintGlobalMapPoint -----//
      GlobalMapPoint = null;

      //----- BlueprintGlobalMagicSpell -----//
      GlobalSpell = null;

      //----- BlueprintItem -----//
      Item = null;

      //----- BlueprintItemArmor -----//
      Armor = null;

      //----- BlueprintItemEquipmentHandSimple -----//
      SimpleHandItem = null;

      //----- BlueprintItemWeapon -----//
      Weapon = null;

      //----- BlueprintKingdomArtisan -----//
      Artisan = null;

      //----- BlueprintKingdomBuff -----//
      KingdomBuff = null;

      //----- BlueprintKingdomDeck -----//
      Deck = null;

      // //----- BlueprintKingdomProject -----//
      Project = null;

      //----- BlueprintParametrizedFeature -----//
      ParameterizedFeature = null;
      ExtraParameterizedFeature = null;

      //----- BlueprintProgression -----//
      Progression = null;

      //----- BlueprintProjectile -----//
      Projectile = null;

      //----- BlueprintQuestObjective -----//
      QuestObjective = null;

      //----- BlueprintRegion -----//
      Region = null;

      //----- BlueprintRomanceCounter -----//
      Romance = null;

      //----- BlueprintSettlement -----//
      Settlement = null;

      //----- BlueprintSettlementBuilding -----//
      SettlementBuilding = null;

      //----- SettlementBuildList -----//
      BuildList = null;

      //----- BlueprintSharedVendorTable -----//
      VendorTable = null;

      //----- BlueprintSpellbook -----//
      TestSpellbook = null;
      ExtraSpellbook = null;

      //----- BlueprintSummonPool -----//
      SummonPool = null;

      //----- BlueprintUnit -----//
      Unit = null;

      //----- BlueprintUnitFact -----//
      TestFact = null;
      ExtraFact = null;

      //----- BlueprintUnitLoot -----//
      Loot = null;

      //----- BlueprintUnitProperty -----//
      Property = null;
      ExtraProperty = null;

      BlueprintPatch.Clear();
    }

    //----- AchievementData -----//
    public static readonly string AchievementGuid = "f2c71962-3b0d-42f4-af9f-be567ebc5047";
    public static AchievementData Achievement;

    //----- BlueprintAbility -----//
    public static readonly string AbilityGuid = "0897de3e-4097-4cfa-bcfc-755119e36bf7";
    public static BlueprintAbility TestAbility;

    public static readonly string ExtraAbilityGuid = "9292a096-a5ad-446e-a199-d62014a73391";
    public static BlueprintAbility ExtraAbility;

    public static readonly string AnotherAbilityGuid = "f3fba7a2-a64e-44a4-a6de-9333c3409807";
    public static BlueprintAbility AnotherAbility;

    //----- BlueprintAbilityAreaEffect -----//
    public static readonly string AbilityAOEGuid = "989a4bc7-89d0-451d-a0ea-5c6c3336dad0";
    public static BlueprintAbilityAreaEffect AbilityAOE;

    //----- BlueprintAbilityResource -----//
    public static readonly string AbilityResourceGuid = "1a7a5f9e-03ff-4e98-a3e0-7d90cd341597";
    public static BlueprintAbilityResource AbilityResource;

    //----- BlueprintActionList -----//
    public static readonly string ActionListGuid = "650c5d8c-56cb-4685-9d38-7c6c8e8c68af";
    public static BlueprintActionList ActionList;

    //----- BlueprintAiCastSpell -----//
    public static readonly string AiCastSpellGuid = "ffbe7e22-1b9d-4ced-80d4-22d96887a62d";
    public static BlueprintAiCastSpell AiCastSpell;

    //----- BlueprintArchetype -----//
    public static readonly string ArchetypeGuid = "e6a3b7d6-1a5f-4852-8dca-e50e14f57ea7";
    public static BlueprintArchetype Archetype;

    public static readonly string ExtraArchetypeGuid = "e449b280-532f-45c9-9f63-ceec44fa909c";
    public static BlueprintArchetype ExtraArchetype;

    //----- BlueprintAreaEnterPoint -----//
    public static readonly string AreaEnterPointGuid = "47f9c4ca-1d8c-4d46-86ac-29246e1c4ab0";
    public static BlueprintAreaEnterPoint AreaEnterPoint;

    //----- BlueprintArmyPreset -----//
    public static readonly string ArmyGuid = "b8309f5f-7ac5-468b-a9e7-98cb805da802";
    public static BlueprintArmyPreset Army;

    //----- BlueprintArmyLeader -----//
    public static readonly string ArmyLeaderGuid = "fea29696-9fb3-4d51-a3ec-7727c0024a2a";
    public static BlueprintArmyLeader TestArmyLeader;

    //----- BlueprintBuff -----//
    public static readonly string BuffGuid = "efcfcdbe-2988-4ab4-941f-2d81f02e1e0b";
    public static BlueprintBuff Buff;

    public static readonly string ExtraBuffGuid = "4d6ceec1-c5c5-4043-a766-347fed4ed2e3";
    public static BlueprintBuff ExtraBuff;

    //----- BlueprintCampingEncounter -----//
    public static readonly string CampingEncounterGuid = "41c7a543-175b-41f9-8294-76c429d3b113";
    public static BlueprintCampingEncounter CampingEncounter;

    //----- BlueprintCharacterClass -----//
    public static readonly string ClassGuid = "7c05a373-6efe-4730-a0f3-c997ac1e1759";
    public static BlueprintCharacterClass Clazz;

    public static readonly string ExtraClassGuid = "47a46eba-c4c6-44cc-9809-20b4d6ad8d41";
    public static BlueprintCharacterClass ExtraClass;

    //----- BlueprintControllableProjectile -----//
    public static readonly string ControllableProjectileGuid = "cecbb683-02a2-42e7-baa4-ac0a8bca03e4";
    public static BlueprintControllableProjectile TestControllableProjectile;

    //----- BlueprintEquipmentEnchantment -----//
    public static readonly string EquipmentEnchantmentGuid = "1dd19073-1781-472a-b462-fa5dab8db2fe";
    public static BlueprintEquipmentEnchantment EquipmentEnchantment;

    //----- BlueprintEtude -----//
    public static readonly string EtudeGuid = "8c1589b0-f30c-488c-bd88-4fd90ea40113";
    public static BlueprintEtude TestEtude;

    public static readonly string ExtraEtudeGuid = "284819da-8952-4ded-a2b5-cfc4aee7ba01";
    public static BlueprintEtude ExtraEtude;

    //----- BlueprintFaction -----//
    public static readonly string FactionGuid = "8ae8efe6-322f-4bf9-bb8d-badb4c103589";
    public static BlueprintFaction Faction;

    //----- BlueprintFeature -----//
    public static readonly string FeatureGuid = "43a37f22-fc6a-44e9-b66e-d3dd41ef6ebc";
    public static BlueprintFeature TestFeature;

    public static readonly string ExtraFeatureGuid = "d43e5551-054a-488b-a8fa-97826b5df653";
    public static BlueprintFeature ExtraFeature;

    //----- BlueprintFeatureSelection -----//
    public static readonly string FeatureSelectionGuid = "94962093-e46d-49e1-9e0e-6e315e325e9d";
    public static BlueprintFeatureSelection FeatureSelection;

    //----- BlueprintGlobalMapPoint -----//
    public static readonly string GlobalMapPointGuid = "5658d141-7bd0-4208-b179-2b8ede7711a8";
    public static BlueprintGlobalMapPoint GlobalMapPoint;

    //----- BlueprintGlobalMagicSpell -----//
    public static readonly string GlobalSpellGuid = "a12b1b9d-59d3-4fa3-b0b7-a8077fcc3869";
    public static BlueprintGlobalMagicSpell GlobalSpell;

    //----- BlueprintItem -----//
    public static readonly string ItemGuid = "e538ae39-cdd1-494b-b03b-b934b9da8dee";
    public static BlueprintItem Item;

    //----- BlueprintItemArmor -----//
    public static readonly string ArmorGuid = "e4cafa6f-5ca0-4b7a-9eec-1172eaf63bbf";
    public static BlueprintItemArmor Armor;

    //----- BlueprintItemEquipmentHandSimple -----//
    public static readonly string SimpleHandItemGuid = "0f729bb6-ebb7-44fd-a806-5dec705967dd";
    public static BlueprintItemEquipmentHandSimple SimpleHandItem;

    //----- BlueprintItemWeapon -----//
    public static readonly string WeaponGuid = "9cf61faf-4ae9-47a0-b325-2fabb13bc9e2";
    public static BlueprintItemWeapon Weapon;
    //----- BlueprintKingdomArtisan -----//
    public static readonly string ArtisanGuid = "3ed9a1e1-c5da-4370-b673-24a8d9d9898c";
    public static BlueprintKingdomArtisan Artisan;

    //----- BlueprintKingdomBuff -----//
    public static readonly string KingdomBuffGuid = "e70c1dcd-b4ef-4022-8eea-3b17d15af334";
    public static BlueprintKingdomBuff KingdomBuff;

    // //----- BlueprintKingdomDeck -----//
    public static readonly string DeckGuid = "948ab7c7-5b44-415b-8fb2-8ac136d10401";
    public static BlueprintKingdomDeck Deck;

    // //----- BlueprintKingdomProject -----//
    public static readonly string ProjectGuid = "e489fed0-ed07-4aef-ae4e-ff99e6557edd";
    public static BlueprintKingdomProject Project;

    //----- BlueprintParametrizedFeature -----//
    public static readonly string ParameterizedFeatureGuid = "80b7137f-2404-450b-a361-6e125297f4c3";
    public static BlueprintParametrizedFeature ParameterizedFeature;

    public static readonly string ExtraParameterizedFeatureGuid = "0e195595-459a-405d-8c61-1e8365b12418";
    public static BlueprintParametrizedFeature ExtraParameterizedFeature;

    //----- BlueprintProgression -----//
    public static readonly string ProgressionGuid = "10305b16-4321-45ef-9937-1e4b66279220";
    public static BlueprintProgression Progression;

    //----- BlueprintProjectile -----//
    public static readonly string ProjectileGuid = "93dff70b-6e6c-4718-acfa-bc4ced9d7e51";
    public static BlueprintProjectile Projectile;

    //----- BlueprintQuestObjective -----//
    public static readonly string QuestObjectiveGuid = "ed92eaad-b12f-463e-8cff-b00f5c0063a2";
    public static BlueprintQuestObjective QuestObjective;

    //----- BlueprintRegion -----//
    public static readonly string RegionGuid = "373f4c50-c351-4f1d-b95f-8129a352b943";
    public static BlueprintRegion Region;

    //----- BlueprintRomanceCounter -----//
    public static readonly string RomanceGuid = "8cf1c517-f456-47d3-bce2-43d9d7f7e8b7";
    public static BlueprintRomanceCounter Romance;

    //----- BlueprintSettlement -----//
    public static readonly string SettlementGuid = "574bda63-7682-44ba-8acd-4edaaf26ca21";
    public static BlueprintSettlement Settlement;

    //----- BlueprintSettlementBuilding -----//
    public static readonly string SettlementBuildingGuid = "d2702e5c-9719-460c-919b-32fa8700ddb2";
    public static BlueprintSettlementBuilding SettlementBuilding;

    //----- SettlementBuildList -----//
    public static readonly string BuildListGuid = "ffa499d1-db21-4c5f-9102-ab1a913633a7";
    public static SettlementBuildList BuildList;

    //----- BlueprintSharedVendorTable -----//
    public static readonly string VendorTableGuid = "afca4171-3d2f-47b5-ac61-9886a0c735c1";
    public static BlueprintSharedVendorTable VendorTable;

    //----- BlueprintSpellbook -----//
    public static readonly string SpellbookGuid = "0f9324b6-8eec-4cb1-92bc-fe6d5a322275";
    public static BlueprintSpellbook TestSpellbook;

    public static readonly string ExtraSpellbookGuid = "6a8e8923-e459-4642-82e6-fd4fed02001d";
    public static BlueprintSpellbook ExtraSpellbook;

    //----- BlueprintSummonPool -----//
    public static readonly string SummonPoolGuid = "5d6d75fb-a1ce-4536-99b1-6eab90f88251";
    public static BlueprintSummonPool SummonPool;

    //----- BlueprintUnit -----//
    public static readonly string UnitGuid = "83dd1ece-33da-4702-a3b1-5b623b0864c4";
    public static BlueprintUnit Unit;

    //----- BlueprintUnitFact -----//
    public static readonly string FactGuid = "f7dba63d-9b33-436d-9841-ca2821b89a1b";
    public static BlueprintUnitFact TestFact;

    public static readonly string ExtraFactGuid = "06d8783f-3b21-4b79-b2d0-061d13f30768";
    public static BlueprintUnitFact ExtraFact;

    //----- BlueprintUnitLoot -----//
    public static readonly string LootGuid = "da81b8a8-ebd7-4c20-8b44-8ee1183b4df3";
    public static BlueprintUnitLoot Loot;

    //----- BlueprintUnitProperty -----//
    public static readonly string PropertyGuid = "dfb7bafc-44bc-4d7a-9212-249e926d558d";
    public static BlueprintUnitProperty Property;

    public static readonly string ExtraPropertyGuid = "aa2c1770-1ea2-4b4d-9e8f-3f05c21155a8";
    public static BlueprintUnitProperty ExtraProperty;

    //----- Common Objects -----// 
    public static readonly ClickedUnit TestUnit = ElementTool.Create<ClickedUnit>();
    public static readonly Distance TestDistance = ElementTool.Create<Distance>();
    public static readonly IntConstant TestInt = ElementTool.Create<IntConstant>();
    public static readonly NearestPosition TestPosition = ElementTool.Create<NearestPosition>();
    public static readonly Trap TestTrap = ElementTool.Create<Trap>();
    public static readonly DamageDescription TestDamage = new();
    public static readonly DamageTypeDescription TestDamageTypeDescription =
        new() { Type = DamageType.Energy };
    public static readonly Sprite TestSprite = (Sprite)FormatterServices.GetUninitializedObject(typeof(Sprite));
  }
}
