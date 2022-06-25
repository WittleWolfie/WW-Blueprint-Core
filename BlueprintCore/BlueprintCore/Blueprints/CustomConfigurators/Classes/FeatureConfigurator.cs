using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  public class FeatureConfigurator
    : BaseFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
  {
    private FeatureConfigurator(Blueprint<BlueprintReference<BlueprintFeature>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static FeatureConfigurator For(Blueprint<BlueprintReference<BlueprintFeature>> blueprint)
    {
      return new FeatureConfigurator(blueprint);
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// 
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="groups">
    /// A list of FeatureGroups. Each group provided adds the feature to the appropriate BlueprintFeatureSelections.
    /// For a full list of selections see TODO.
    /// </param>
    public static FeatureConfigurator New(string name, string guid, params FeatureGroup[] groups)
    {
      BlueprintTool.Create<BlueprintFeature>(name, guid);
      return For(name).SetGroups(groups);
    }

    private static readonly IEnumerable<BlueprintFeatureSelection> FeatureSelections =
      FeatureSelectionRefs.All.Select(selectionRef => selectionRef.Reference.Get());
    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();

      foreach (var selection in FeatureSelections)
      {
        if (Blueprint.HasGroup(selection.Group) || Blueprint.HasGroup(selection.Group2))
        {
          AddToSelection(selection);
        }
      }

      foreach (var group in Blueprint.Groups)
      {
        switch (group)
        {
          case FeatureGroup.Feat:
            AddToSelection(FeatureSelectionRefs.BasicFeatSelection);
            AddToSelection(FeatureSelectionRefs.ExtraFeatMythicFeat);
            break;
          case FeatureGroup.CombatFeat:
            AddToSelection(FeatureSelectionRefs.CavalierBonusFeatSelection);
            AddToSelection(FeatureSelectionRefs.CombatTrick);
            AddToSelection(FeatureSelectionRefs.EldritchKnightFeatSelection);
            AddToSelection(FeatureSelectionRefs.FighterFeatSelection);
            AddToSelection(FeatureSelectionRefs.GendarmeFeatSelection);
            AddToSelection(FeatureSelectionRefs.LoremasterCombatFeatSelection);
            AddToSelection(FeatureSelectionRefs.MagusFeatSelection);
            AddToSelection(FeatureSelectionRefs.StudentOfWarCombatFeatSelection);
            AddToSelection(FeatureSelectionRefs.WarpriestFeatSelection);
            break;
          case FeatureGroup.WizardFeat:
            break;
          case FeatureGroup.Domain:
            break;
          case FeatureGroup.FinesseTraining:
            break;
          case FeatureGroup.RagePower:
            break;
          case FeatureGroup.RogueTalent:
            break;
          case FeatureGroup.FavoriteEnemy:
            break;
          case FeatureGroup.Discovery:
            break;
          case FeatureGroup.WeaponTraining:
            break;
          case FeatureGroup.Racial:
            break;
          case FeatureGroup.Trait:
            break;
          case FeatureGroup.SpecialistSchool:
            break;
          case FeatureGroup.OppositionSchool:
            break;
          case FeatureGroup.BloodLine:
            break;
          case FeatureGroup.FavoriteTerrain:
            break;
          case FeatureGroup.RangerStyle:
            break;
          case FeatureGroup.DefensivePower:
            break;
          case FeatureGroup.Mercy:
            break;
          case FeatureGroup.MagusArcana:
            break;
          case FeatureGroup.EldritchScionArcana:
            break;
          case FeatureGroup.StyleFeat:
            break;
          case FeatureGroup.TeamworkFeat:
            break;
          case FeatureGroup.Deities:
            break;
          case FeatureGroup.ChannelEnergy:
            break;
          case FeatureGroup.KiPowers:
            break;
          case FeatureGroup.ScaledFistKiPowers:
            break;
          case FeatureGroup.ExoticWeaponProficiency:
            break;
          case FeatureGroup.VivisectionistDiscovery:
            break;
          case FeatureGroup.ThassilonianSpellbook:
            break;
          case FeatureGroup.ArcaneTricksterSpellbook:
            break;
          case FeatureGroup.EldritchKnightSpellbook:
            break;
          case FeatureGroup.DragonDiscipleSpellbook:
            break;
          case FeatureGroup.DraconicBloodlineSelection:
            break;
          case FeatureGroup.MysticTheurgeArcaneSpellbook:
            break;
          case FeatureGroup.MysticTheurgeDivineSpellbook:
            break;
          case FeatureGroup.CreatureType:
            break;
          case FeatureGroup.AnimalCompanion:
            break;
          case FeatureGroup.DruidDomain:
            break;
          case FeatureGroup.BlightDruidDomain:
            break;
          case FeatureGroup.ClericSecondaryDomain:
            break;
          case FeatureGroup.AasimarHeritage:
            break;
          case FeatureGroup.RangerBond:
            break;
          case FeatureGroup.DruidBond:
            break;
          case FeatureGroup.TieflingHeritage:
            break;
          case FeatureGroup.KineticBlast:
            break;
          case FeatureGroup.KineticBlastInfusion:
            break;
          case FeatureGroup.KineticWildTalent:
            break;
          case FeatureGroup.KineticElementalFocus:
            break;
          case FeatureGroup.WitchHex:
            break;
          case FeatureGroup.WitchPatron:
            break;
          case FeatureGroup.Familiar:
            break;
          case FeatureGroup.OracleCurse:
            break;
          case FeatureGroup.ShamanHex:
            break;
          case FeatureGroup.ShamanSpirit:
            break;
          case FeatureGroup.MythicFeat:
            break;
          case FeatureGroup.MythicAbility:
            break;
          case FeatureGroup.OracleMystery:
            break;
          case FeatureGroup.OracleRevelation:
            break;
          case FeatureGroup.BloodragerBloodline:
            break;
          case FeatureGroup.MythicTrick1:
            break;
          case FeatureGroup.MythicTrick2:
            break;
          case FeatureGroup.MythicTrick3:
            break;
          case FeatureGroup.SkeletalChampion:
            break;
          case FeatureGroup.ImprovedSwordOfHeaven:
            break;
          case FeatureGroup.GreaterSwordOfHeaven:
            break;
          case FeatureGroup.ArcanistExploit:
            break;
          case FeatureGroup.DemonicAspect:
            break;
          case FeatureGroup.SelectMythicSpellbook:
            break;
          case FeatureGroup.AzataSuperpowerAbilities:
            break;
          case FeatureGroup.MountedCombatFeat:
            break;
          case FeatureGroup.WarpriestBlessing:
            break;
          case FeatureGroup.TerrainDominance:
            break;
          case FeatureGroup.SlayerTalent:
            break;
          case FeatureGroup.HellknightSigniferSpellbook:
            break;
          case FeatureGroup.EnlightenedPhilosopherMystery:
            break;
          case FeatureGroup.DivineHerbalistMystery:
            break;
          case FeatureGroup.UndergroundChemistDiscovery:
            break;
          case FeatureGroup.BackgroundSelection:
            break;
          case FeatureGroup.DhampirHeritage:
            break;
          case FeatureGroup.OreadHeritage:
            break;
          case FeatureGroup.KitsuneHeritage:
            break;
          case FeatureGroup.AngelMythcHalo:
            break;
          case FeatureGroup.DemonMajorAspect:
            break;
          case FeatureGroup.LichUniqueAbility:
            break;
          case FeatureGroup.LichSkeletalUpgrade:
            break;
          case FeatureGroup.MythicAdditionalProgressions:
            break;
          case FeatureGroup.DemonLordAspect:
            break;
          case FeatureGroup.TricksterFeat:
            break;
          case FeatureGroup.ReplaceSpellbook:
            break;
          case FeatureGroup.HalfOrcHeritage:
            break;
          default:
            break;
        }
      }
    }

    private void AddToSelection(Blueprint<BlueprintReference<BlueprintFeatureSelection>> selection)
    {
      FeatureSelectionConfigurator.For(selection).AddToAllFeatures(Blueprint).Configure();
    }
  }
}
