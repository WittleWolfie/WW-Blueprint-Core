using BlueprintCore.Blueprints.Components;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Utils;

namespace Tutorials.Feats
{
  public class MagicalAptitudeSolution
  {
    private static readonly string FeatName = "MagicalAptitude";
    private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";
    private static readonly string BasicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";

    private static readonly string DisplayName = "Magical Aptitude";
    private static readonly string DisplayNameKey = "MagicalAptitudeName";
    private static readonly string Description =
        "You get a +2 bonus on all Spellcraft and Use Magic Device skill checks. If you have 10 or more ranks in one of"
        + " these skills, the bonus increases to +4 for that skill.";
    private static readonly string DescriptionKey = "MagicalAptitudeDescription";

    /// <summary>
    /// Adds the Magical Aptitude feat.
    /// </summary>
    /// 
    /// <remarks>
    /// This is not the only possible way to implement Magical Aptitude, it's just the way I chose to do it.
    /// </remarks>
    public static void Configure()
    {
      FeatureConfigurator.New(FeatName, FeatGuid)
          // Most of the time you want to set this to true. It is used during respec to determine whether a feature
          // should be removed.
          .SetIsClassFeature()
          // If you don't set this the context rank configs may not update properly and the bonus may not change.
          .SetReapplyOnLevelUp()
          .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
          .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
          .SetFeatureTags(FeatureTag.Skills)
          .SetFeatureGroups(FeatureGroup.Feat)
          // Custom progression returns +2 when Knowledge: Arcana is 9 or less, and +4 when it is 10 or more.
          .AddContextRankConfig(
              ContextRankConfigs.BaseStat(StatType.SkillKnowledgeArcana)
                  .WithCustomProgression((9, 2), (10, 4)))
          // ContextValues.Rank() associates the bonus with the ContextRankConfig created. Since neither specify an
          // AbilityRankType, they both use "Default". This is what associates a ContextValue with a specific
          // ContextRankConfig.
          .AddContextStatBonus(StatType.SkillKnowledgeArcana, ContextValues.Rank(), descriptor: ModifierDescriptor.Feat)
          // A second config is needed because you only get +4 to one of the skills if you have 10 ranks in that skill.
          .AddContextRankConfig(
              ContextRankConfigs.BaseStat(StatType.SkillUseMagicDevice, type: AbilityRankType.StatBonus)
                  .WithCustomProgression((9, 2), (10, 4)))
          // This time we declare a type of AbilityRankType.StatBonus. The actual type is meaningless, all that matters
          // is that the config has the same type. It could just as easily have been AbilityRankType.DamageBonus. If we
          // left the type blank one config would overwrite the other.
          .AddContextStatBonus(
              StatType.SkillUseMagicDevice,
              ContextValues.Rank(type: AbilityRankType.StatBonus),
              descriptor: ModifierDescriptor.Feat)
          .Configure();

      FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToFeatures(FeatName).Configure();
    }
  }
}
