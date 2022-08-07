using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreTutorial.Feats
{
  public class FuriousFocus
  {
    private const string FeatName = "FuriousFocus";
    private const string FeatGuid = "f71ea407-f8ae-46dc-8315-b9c6a7819969";

    private const string FeatDisplayName = "FuriousFocus.Name";
    private const string FeatDescription = "FuriousFocus.Description";

    private const string IconPrefix = "assets/icons/";
    private const string IconName = IconPrefix + "furiousfocus.png";

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
        .SetIcon(IconName)
        // Adds UI recommendation for 3/4 or Full BAB characters
        .AddRecommendationBaseAttackPart(minPart: 0.7f)
        // Adds UI recommendation for Weapon Focus 2H
        .AddRecommendationWeaponSubcategoryFocus(subcategory: WeaponSubCategory.TwoHanded, hasFocus: true)
        // Adds UI tags
        .AddFeatureTagsComponent(featureTags: FeatureTag.Melee | FeatureTag.Damage)
        .AddPrerequisiteStatValue(StatType.Strength, 13)
        .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 1)
        .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
        .AddComponent<FuriousFocusBonus>()
        .Configure();
    }

    [TypeId("5767d0d5-d84c-4949-94aa-e654febc3b0f")]
    private class FuriousFocusBonus :
      UnitFactComponentDelegate,
      IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>
    {
      private readonly BlueprintBuff PowerAttackBuff = BuffRefs.PowerAttackBuff.Reference.Get();

      public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) { }

      public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt)
      {
        if (evt.Weapon is null || !evt.Weapon.Blueprint.IsTwoHanded)
        {
          Logger.Verbose("Skipped: not a 2H weapon attack.");
          return;
        }

        var rule = evt.Reason.Rule;
        if (rule is null || rule is not RuleAttackWithWeapon)
        {
          Logger.Verbose("Skipped: not RuleAttackWithWeapon");
          return;
        }

        var attackRule = rule as RuleAttackWithWeapon;
        if (!attackRule.IsFirstAttack)
        {
          Logger.Verbose("Skipped: not first attack");
          return;
        }

        if (evt.m_ModifiableBonus?.Modifiers is null)
        {
          Logger.Verbose("Skipped: no modifiers on attack.");
          return;
        }

        var powerAttackModifier =
          evt.m_ModifiableBonus.Modifiers
            .Where(m => m.Fact?.Blueprint == PowerAttackBuff)
            .Select(m => (Modifier?)m) // Cast to avoid getting a default struct
            .FirstOrDefault();
        if (powerAttackModifier is null)
        {
          Logger.Verbose("Skipped: power attack not applied");
          return;
        }

        Logger.Info($"Adding attack bonus to {Owner.CharacterName}'s attack");
        evt.AddModifier(new Modifier(-powerAttackModifier.Value.Value, Fact, ModifierDescriptor.UntypedStackable));
      }
    }
  }
}
