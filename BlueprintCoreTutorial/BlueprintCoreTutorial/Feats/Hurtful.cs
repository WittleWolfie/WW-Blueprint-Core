using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace BlueprintCoreTutorial.Feats
{
  public class Hurtful
  {
    private const string FeatName = "Hurtful";
    private const string FeatGuid = "67a81a4b-4796-45df-86fe-6d360dbd7c6f";

    private const string FeatDisplayName = "Hurtful.Name";
    private const string FeatDescription = "Hurtful.Description";

    private const string AbilityName = "Hurtful.Ability";
    private const string AbilityGuid = "4f75bc81-a4d0-4179-a301-79e1becbf310";

    private const string BuffName = "Hurtful.Buff";
    private const string BuffGuid = "4c224088-61da-45a9-bb5e-0dce4d9750c0";

    private const string IconPrefix = "assets/icons/";
    private const string IconName = IconPrefix + "hurtful.png";

    private static readonly LogWrapper Logger = LogWrapper.Get(FeatName);

    /// <summary>
    /// Adds the Furious Focus feat.
    /// </summary>
    public static void Configure()
    {
      Logger.Info($"Configuring {FeatName}");

      var buff =
        BuffConfigurator.New(BuffName, BuffGuid)
          // No need to clutter the UI, the ability itself is sufficient to indicate it is active.
          .SetFlags(BlueprintBuff.Flags.HiddenInUi)
          .AddComponent(
            new HurtfulComponent(ConditionsBuilder.New().TargetInMeleeRange().HasActionsAvailable(requireSwift: true)))
          .Configure();

      // Toggle ability to enable / disable hurtful trigger
      var ability =
        ActivatableAbilityConfigurator.New(AbilityName, AbilityGuid)
          .SetDisplayName(FeatDisplayName)
          .SetDescription(FeatDescription)
          .SetIcon(IconName)
          .SetBuff(buff)
          .Configure();

      FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
        .SetDisplayName(FeatDisplayName)
        .SetDescription(FeatDescription)
        .SetIcon(IconName)
        .AddFeatureTagsComponent(featureTags: FeatureTag.Melee | FeatureTag.Attack | FeatureTag.Skills)
        .AddPrerequisiteStatValue(StatType.Strength, 13)
        .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
        .AddFacts(new() { ability })
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

          var target = ContextData<MechanicsContext.Data>.Current?.CurrentTarget?.Unit;
          if (target is null)
          {
            Logger.Warn($"No target for demoralize.");
            return;
          }

          // Make sure target is not immune to demoralize, indicated by the presence of either Buff or GreaterBuff
          if (!(target.HasFact(demoralize.Buff) || target.HasFact(demoralize.GreaterBuff)))
          {
            Logger.Verbose($"{target.CharacterName} immune to demoralize");
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
