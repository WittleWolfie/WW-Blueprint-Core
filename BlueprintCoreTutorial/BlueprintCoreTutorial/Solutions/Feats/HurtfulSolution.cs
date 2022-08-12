using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;

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
        .AddComponent(
          new HurtfulComponent(ConditionsBuilder.New().TargetInMeleeRange().HasActionsAvailable(requireSwift: true)))
        .Configure();
    }

    private class HurtfulComponent : UnitFactComponentDelegate, IDemoralizeHandler
    {
      private readonly ConditionsChecker Conditions;

      public HurtfulComponent(ConditionsBuilder conditions)
      {
        Conditions = conditions.Build();
      }

      public void OnDemoralizeResolved(Demoralize demoralize, RuleSkillCheck intimidateCheck)
      {
        if (intimidateCheck.Success)
        {
          if (!Conditions.Check())
          {
            Logger.Verbose($"Conditions not met");
            return;
          }

          var target = intimidateCheck.GetRuleTarget();
          if (target is null)
          {
            Logger.Warn($"No target for demoralize.");
            return;
          }

          // Make sure target is not immune to demoralize, indicated by the presence of either Buff or GreaterBuff
          if (!target.HasFact(demoralize.Buff) || !target.HasFact(demoralize.GreaterBuff))
          {
            Logger.Verbose($"Target immune to demoralize");
            return;
          }

          Logger.Verbose($"{target.CharacterName} demoralized");

          var caster = Context.MaybeCaster;
          if (caster is null)
          {
            Logger.Warn($"Caster is missing");
            return;
          }

          var threatHandMelee = caster.GetThreatHandMelee();
          if (threatHandMelee is null)
          {
            Logger.Warn($"Unable to make melee attack");
            return;
          }

          var attack =
            Context.TriggerRule<RuleAttackWithWeapon>(
              new(caster, target, threatHandMelee.Weapon, attackBonusPenalty: 0));

          if (!attack.AttackRoll.IsHit)
          {
            Logger.Verbose($"Attack missed, removing demoralize effects");
            target.RemoveFact(demoralize.Buff);
            target.RemoveFact(demoralize.GreaterBuff);
          }
        }
        else
        {
          Logger.Verbose($"Intimidate check failed");
        }
      }
    }
  }
}
