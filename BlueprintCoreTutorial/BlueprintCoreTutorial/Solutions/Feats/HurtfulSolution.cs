using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreTutorial.Solutions.Feats
{
  public class HurtfulSolution
  {
    private const string FeatName = "Hurtful";
    private const string FeatGuid = "67a81a4b-4796-45df-86fe-6d360dbd7c6f";

    private const string FeatDisplayName = "Hurtful.Name";
    private const string FeatDescription = "Hurtful.Description";

    private const string IconPrefix = "assets/icons/";
    private const string IconName = IconPrefix + "hurtful.png";

    private static readonly LogWrapper Logger = LogWrapper.Get(FeatName);

    /// <summary>
    /// Adds the Furious Focus feat.
    /// </summary>
    public static void Configure()
    {
      Logger.Info($"Configuring {FeatName}");

      FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
        .SetDisplayName(FeatDisplayName)
        .SetDescription(FeatDescription)
        //.SetIcon(IconName)
        // Adds UI tags
        .AddFeatureTagsComponent(featureTags: FeatureTag.Melee | FeatureTag.Attack | FeatureTag.Skills)
        .AddPrerequisiteStatValue(StatType.Strength, 13)
        .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
        .Configure();
    }
  }
}
