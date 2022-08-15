using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils.Types;
using BlueprintCore.Utils;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs;
using System;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic;

namespace BlueprintCoreTutorial.Feats
{
  public class SkaldsVigor
  {
    internal const string FeatureName = "SkaldsVigor";
    internal const string FeatureDisplayName = "SkaldsVigor.Name";
    internal const string FeatureDescription = "SkaldsVigor.Description";

    internal const string FeatName = "SkaldsVigor.Feat";
    internal const string FeatGuid = "b1080f89-4d60-44a7-8cd4-dab82ab306b9";

    internal const string GreaterFeatName = "GreaterSkaldsVigor.Feat";
    internal const string GreaterFeatGuid = "c6e8af9a-f5c8-4dfa-84b7-9e0fbcb414d3";
    internal const string GreaterFeatDisplayName = "GreaterSkaldsVigor.Name";
    internal const string GreaterFeatDescription = "GreaterSkaldsVigor.Description";

    internal const string BuffName = "SkaldsVigor.Buff";
    internal const string BuffGuid = "222e1f64-3d93-489f-8a34-332fbc319c55";

    internal const string IconPrefix = "assets/icons/";
    internal const string IconName = IconPrefix + "skaldvigor.png";
    internal const string GreaterIconName = IconPrefix + "greaterskaldvigor.png";

    private static readonly LogWrapper Logger = LogWrapper.Get(FeatureName);

    /// <summary>
    /// Adds the Skald's Vigor and Greater Skald's Vigor feats.
    /// </summary>
    internal static void Configure()
    {
      Logger.Info($"Configuring {FeatureName}");
      var skaldClass = CharacterClassRefs.SkaldClass.ToString();

      // Buff to apply fast healing
      BuffConfigurator.New(BuffName, BuffGuid)
        .SetDisplayName(FeatureDisplayName)
        .SetDescription(FeatureDescription)
        .SetIcon(IconName)
        .AddEffectContextFastHealing(bonus: ContextValues.Rank())
        .AddContextRankConfig(
          // Wrath uses the unchained version of Inspired Rage, this re-creates the progression of strength bonus:
          // +2 until level 8, then +4 until level 16, then +6.
          ContextRankConfigs.ClassLevel(new string[] { skaldClass }).WithCustomProgression((7, 2), (15, 4), (16, 6)))
        .AddComponent<InspiredRageDeactivationHandler>()
        .Configure();

      // Skald's Vigor feat
      FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
        .SetDisplayName(FeatureDisplayName)
        .SetDescription(FeatureDescription)
        .SetIcon(IconName)
        .AddPrerequisiteFeature(FeatureRefs.RagingSong.ToString())
        .Configure();

      // Greater Skald's Vigor
      FeatureConfigurator.New(GreaterFeatName, GreaterFeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
         .SetDisplayName(GreaterFeatDisplayName)
         .SetDescription(GreaterFeatDescription)
         .SetIcon(GreaterIconName)
         .AddPrerequisiteFeature(FeatName)
         .Configure();

      var applyBuff = ActionsBuilder.New().ApplyBuffPermanent(BuffName, isNotDispelable: true);
      BuffConfigurator.For(BuffRefs.InspiredRageEffectBuff)
        .AddFactContextActions(
          activated:
            // Since it is actually part of the Inspired Rage buff it's not a valid dispel target.
            ActionsBuilder.New()
              .Conditional(
                ConditionsBuilder.New().TargetIsYourself().HasFact(FeatName),
                ifTrue: applyBuff)
              .Conditional(
                ConditionsBuilder.New().CasterHasFact(GreaterFeatName),
                ifTrue: applyBuff))
        // Prevents Inspired Rage from being removed and reapplied each round.
        .SetStacking(StackingType.Ignore)
        .Configure();
    }

    private class InspiredRageDeactivationHandler : UnitFactComponentDelegate, IActivatableAbilityWillStopHandler
    {
      private static readonly BlueprintActivatableAbility InspiredRage =
        ActivatableAbilityRefs.InspiredRageAbility.Reference.Get();

      private static readonly BlueprintBuff SkaldsVigor = BlueprintTool.Get<BlueprintBuff>(BuffName);

      public void HandleActivatableAbilityWillStop(ActivatableAbility ability)
      {
        try
        {
          if (ability?.Blueprint != InspiredRage)
          {
            return;
          }
          Logger.Info("Inspired Rage deactivated.");

          Buff skaldsVigor = ability.Owner.Buffs.GetBuff(SkaldsVigor);
          skaldsVigor?.Remove();
        }
        catch (Exception e)
        {
          Logger.Error("Error processing Raging Song deactivation.", e);
        }
      }
    }
  }
}
