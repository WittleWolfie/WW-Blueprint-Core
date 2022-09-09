using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace BlueprintCoreTutorial.Feats
{
  public class MagicalAptitudeSolution
  {
    private const string FeatName = "MagicalAptitude";
    private const string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";

    /// <summary>
    /// Adds the Magical Aptitude feat.
    /// </summary>
    /// 
    /// <remarks>
    /// This is not the only possible way to implement Magical Aptitude, it's just the way I chose to do it.
    /// </remarks>
    public static void Configure()
    {
      FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
        // If you don't set this the context rank configs may not update properly and the bonus may not change.
        .SetReapplyOnLevelUp()
        .SetDisplayName("MagicalAptitude.Name")
        .SetDescription("MagicalAptitude.Description")
        .AddFeatureTagsComponent(FeatureTag.Skills)
        // Custom progression returns +2 when Knowledge: Arcana is 9 or less, and +4 when it is 10 or more.
        .AddContextRankConfig(
          ContextRankConfigs.BaseStat(StatType.SkillKnowledgeArcana).WithCustomProgression((9, 2), (10, 4)))
        // ContextValues.Rank() associates the bonus with the ContextRankConfig created. Since neither specify an
        // AbilityRankType, they both use "Default". This is what associates a ContextValue with a specific
        // ContextRankConfig.
        .AddContextStatBonus(
          StatType.SkillKnowledgeArcana, ContextValues.Rank(), descriptor: ModifierDescriptor.UntypedStackable)
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
          descriptor: ModifierDescriptor.UntypedStackable)
        .Configure();
    }
  }
}
