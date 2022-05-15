using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;

namespace BlueprintCoreTutorial.Feats
{
  public class MagicalAptitude
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
    public static void Configure()
    {
      FeatureConfigurator.New(FeatName, FeatGuid)
          .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
          .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
          .AddFeatureTagsComponent(FeatureTag.Skills)
          .AddToGroups(FeatureGroup.Feat)
          .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2)
          .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2)
          .Configure();

      FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToAllFeatures(FeatName).Configure();
    }
  }
}
