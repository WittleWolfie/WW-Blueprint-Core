using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace BlueprintCoreTutorial.Feats
{
  public class MagicalAptitude
  {
    private static readonly string FeatName = "MagicalAptitude";
    private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";

    /// <summary>
    /// Adds the Magical Aptitude feat.
    /// </summary>
    public static void Configure()
    {
      FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
          .SetDisplayName("MagicalAptitude.Name")
          .SetDescription("MagicalAptitude.Description")
          .AddFeatureTagsComponent(FeatureTag.Skills)
          .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2, descriptor: ModifierDescriptor.Feat)
          .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2, descriptor: ModifierDescriptor.Feat)
          .Configure();
    }
  }
}
