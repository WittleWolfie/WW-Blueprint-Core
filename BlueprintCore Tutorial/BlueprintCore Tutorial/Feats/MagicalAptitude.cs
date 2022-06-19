using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Utils;
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
    private static readonly string BasicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";

    /// <summary>
    /// Adds the Magical Aptitude feat.
    /// </summary>
    public static void Configure()
    {
      FeatureConfigurator.New(FeatName, FeatGuid)
          .SetDisplayName("MagicalAptitude.Name")
          .SetDescription("MagicalAptitude.Description")
          .AddFeatureTagsComponent(FeatureTag.Skills)
          .AddToGroups(FeatureGroup.Feat)
          .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2, descriptor: ModifierDescriptor.Feat)
          .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2, descriptor: ModifierDescriptor.Feat)
          .Configure();

      FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToAllFeatures(FeatName).Configure();
    }
  }
}
