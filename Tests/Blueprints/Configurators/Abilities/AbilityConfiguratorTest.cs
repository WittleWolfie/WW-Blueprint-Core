using BlueprintCore.Abilities.Restrictions.New;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Conditions.New;
using BlueprintCore.Test.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Abilities
{
  public class AbilityConfiguratorTest
      : BaseUnitFactConfiguratorTest<BlueprintAbility, AbilityConfigurator>
  {
    public AbilityConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintAbility>(Guid);
    }

    protected override AbilityConfigurator GetConfigurator(string guid)
    {
      return AbilityConfigurator.For(guid)
          .SetType(AbilityType.Extraordinary)
          .RunActions(ActionsBuilder.New());
    }

    [Fact]
    public void SetAiAction()
    {
      GetConfigurator(Guid)
          .SetAiAction(AiCastSpellGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(
          AiCastSpell.ToReference<BlueprintAiCastSpell.Reference>(), ability.m_DefaultAiAction);
    }

    [Fact]
    public void SetType()
    {
      GetConfigurator(Guid)
          .SetType(AbilityType.Supernatural)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(AbilityType.Supernatural, ability.Type);
    }

    [Fact]
    public void SetRange_WithCustom()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            GetConfigurator(Guid)
               .SetRange(AbilityRange.Custom)
               .Configure());
    }

    [Fact]
    public void SetCustomRange()
    {
      GetConfigurator(Guid)
          .SetCustomRange(2)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(2, ability.CustomRange.Value);
      Assert.Equal(AbilityRange.Custom, ability.Range);
    }

    [Fact]
    public void ShowNameForVariant()
    {
      GetConfigurator(Guid)
          .ShowNameForVariant()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.ShowNameForVariant);
      Assert.False(ability.OnlyForAllyCaster);
    }

    [Fact]
    public void ShowNameForVariant_WithOptionalValues()
    {
      GetConfigurator(Guid)
          .ShowNameForVariant(showName: false, onlyForAlly: true)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.ShowNameForVariant);
      Assert.True(ability.OnlyForAllyCaster);
    }

    [Fact]
    public void AllowTargeting_WithValues()
    {
      GetConfigurator(Guid)
          .SetRange(AbilityRange.Close)
          .AllowTargeting(point: true, enemies: true, friends: true, self: false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.CanTargetPoint);
      Assert.True(ability.CanTargetEnemies);
      Assert.True(ability.CanTargetFriends);
      Assert.False(ability.CanTargetSelf);
    }

    [Fact]
    public void AllowTargeting_WithExistingValues()
    {
      // First pass
      GetConfigurator(Guid)
          .SetRange(AbilityRange.Close)
          .AllowTargeting(point: true, enemies: true, friends: true, self: false)
          .Configure();

      AbilityConfigurator.For(Guid)
          .AllowTargeting()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.CanTargetPoint);
      Assert.True(ability.CanTargetEnemies);
      Assert.True(ability.CanTargetFriends);
      Assert.False(ability.CanTargetSelf);
    }

    [Fact]
    public void ApplySpellResistance()
    {
      GetConfigurator(Guid)
          .SetType(AbilityType.SpellLike)
          .SetSpellSchool(SpellSchool.Abjuration)
          .ApplySpellResistance()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.SpellResistance);
    }

    [Fact]
    public void ApplySpellResistance_Disable()
    {
      GetConfigurator(Guid)
          .ApplySpellResistance(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.SpellResistance);
    }

    [Fact]
    public void AutoFillActionBar()
    {
      GetConfigurator(Guid)
          .AutoFillActionBar()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.ActionBarAutoFillIgnored);
    }

    [Fact]
    public void AutoFillActionBar_Disable()
    {
      GetConfigurator(Guid)
          .AutoFillActionBar(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.ActionBarAutoFillIgnored);
    }

    [Fact]
    public void HideInUi()
    {
      GetConfigurator(Guid)
          .HideInUi()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.Hidden);
    }

    [Fact]
    public void HideInUi_Disable()
    {
      GetConfigurator(Guid)
          .HideInUi(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.Hidden);
    }

    [Fact]
    public void RequireWeapon()
    {
      GetConfigurator(Guid)
          .RequireWeapon()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.NeedEquipWeapons);
    }

    [Fact]
    public void RequireWeapon_Disable()
    {
      GetConfigurator(Guid)
          .RequireWeapon(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.NeedEquipWeapons);
    }

    [Fact]
    public void IsOffensive()
    {
      GetConfigurator(Guid)
          .IsOffensive()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.NotOffensive);
    }

    [Fact]
    public void IsOffensive_Disable()
    {
      GetConfigurator(Guid)
          .IsOffensive(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.NotOffensive);
    }

    [Fact]
    public void SetEffectOn_WithValues()
    {
      GetConfigurator(Guid)
          .SetEffectOn(onAlly: AbilityEffectOnUnit.Harmful, onEnemy: AbilityEffectOnUnit.Helpful)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(AbilityEffectOnUnit.Harmful, ability.EffectOnAlly);
      Assert.Equal(AbilityEffectOnUnit.Helpful, ability.EffectOnEnemy);
    }

    [Fact]
    public void SetEffectOn_WithExistingValues()
    {
      // First pass
      GetConfigurator(Guid)
          .SetEffectOn(onAlly: AbilityEffectOnUnit.Harmful, onEnemy: AbilityEffectOnUnit.Helpful)
          .Configure();

      AbilityConfigurator.For(Guid)
          .SetEffectOn()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(AbilityEffectOnUnit.Harmful, ability.EffectOnAlly);
      Assert.Equal(AbilityEffectOnUnit.Helpful, ability.EffectOnEnemy);
    }

    [Fact]
    public void SetParent()
    {
      GetConfigurator(Guid)
          .SetParent(AbilityGuid)
          .Configure();

      var childAbility = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(
          TestAbility.ToReference<BlueprintAbilityReference>(),
          childAbility.Parent.ToReference<BlueprintAbilityReference>());

      var parentVariants = childAbility.Parent.GetComponent<AbilityVariants>();
      Assert.Contains(
          childAbility.ToReference<BlueprintAbilityReference>(), parentVariants.m_Variants);
    }

    [Fact]
    public void SetAnimationStyle()
    {
      GetConfigurator(Guid)
          .SetAnimationStyle(UnitAnimationActionCastSpell.CastAnimationStyle.BreathWeapon)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(
          UnitAnimationActionCastSpell.CastAnimationStyle.BreathWeapon, ability.Animation);
    }

    [Fact]
    public void SetActionType_Swift()
    {
      GetConfigurator(Guid)
          .SetActionType(UnitCommand.CommandType.Swift, hasFastAnimation: true)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(UnitCommand.CommandType.Swift, ability.ActionType);
      Assert.True(ability.HasFastAnimation);
    }

    [Fact]
    public void SetActionType_WithExistingValues()
    {
      // First pass
      GetConfigurator(Guid)
          .SetActionType(UnitCommand.CommandType.Swift, hasFastAnimation: true)
          .Configure();

      AbilityConfigurator.For(Guid)
          .SetActionType(UnitCommand.CommandType.Standard)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(UnitCommand.CommandType.Standard, ability.ActionType);
      Assert.True(ability.HasFastAnimation);
    }

    [Fact]
    public void SetMetamagics()
    {
      // First pass
      GetConfigurator(Guid).SetMetamagics(Metamagic.Empower);

      GetConfigurator(Guid)
          .SetMetamagics(Metamagic.Extend, Metamagic.Heighten)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Extend));
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Heighten));
      Assert.False(ability.AvailableMetamagic.HasFlag(Metamagic.Empower));
    }

    [Fact]
    public void AddMetamagics()
    {
      GetConfigurator(Guid)
          .AddToMetamagics(Metamagic.Empower, Metamagic.Heighten)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Empower));
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Heighten));
    }

    [Fact]
    public void AddMetamagics_ToExistingMetamagics()
    {
      // First pass
      GetConfigurator(Guid)
          .SetMetamagics(Metamagic.Empower, Metamagic.Heighten)
          .Configure();

      AbilityConfigurator.For(Guid)
          .AddToMetamagics(Metamagic.Quicken)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Empower));
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Heighten));
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Quicken));
    }

    [Fact]
    public void RemoveMetamagics()
    {
      // First pass
      GetConfigurator(Guid)
          .SetMetamagics(Metamagic.Empower, Metamagic.Heighten)
          .Configure();

      AbilityConfigurator.For(Guid)
          .RemoveFromMetamagics(Metamagic.Empower)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.AvailableMetamagic.HasFlag(Metamagic.Empower));
      Assert.True(ability.AvailableMetamagic.HasFlag(Metamagic.Heighten));
    }

    [Fact]
    public void MakeFullRound()
    {
      GetConfigurator(Guid)
          .MakeFullRound()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.m_IsFullRoundAction);
    }

    [Fact]
    public void MakeFullRound_Disable()
    {
      // First pass
      GetConfigurator(Guid)
          .MakeFullRound()
          .Configure();

      AbilityConfigurator.For(Guid)
          .MakeFullRound(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.m_IsFullRoundAction);
    }

    [Fact]
    public void SetDurationText()
    {
      GetConfigurator(Guid)
          .SetDurationText(new LocalizedString { m_Key = "duration" })
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal("duration", ability.LocalizedDuration.Key);
    }

    [Fact]
    public void SetSavingThrowText()
    {
      GetConfigurator(Guid)
          .SetSavingThrowText(new LocalizedString { m_Key = "savingThrow" })
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal("savingThrow", ability.LocalizedSavingThrow.Key);
    }

    [Fact]
    public void SetMaterialComponent()
    {
      GetConfigurator(Guid)
          .SetMaterialComponent(new BlueprintAbility.MaterialComponentData { Count = 3 })
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Equal(3, ability.MaterialComponent.Count);
    }

    [Fact]
    public void HideFromLog()
    {
      GetConfigurator(Guid)
          .HideFromLog()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.True(ability.DisableLog);
    }

    [Fact]
    public void HideFromLog_Disable()
    {
      // First pass
      GetConfigurator(Guid)
          .HideFromLog()
          .Configure();

      AbilityConfigurator.For(Guid)
          .HideFromLog(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.False(ability.DisableLog);
    }

    [Fact]
    public void RequireCasterAlignment()
    {
      GetConfigurator(Guid)
          .RequireCasterAlignment(AlignmentMaskType.LawfulGood)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var alignment = ability.GetComponent<AbilityCasterAlignment>();
      Assert.NotNull(alignment);

      Assert.Equal(AlignmentMaskType.LawfulGood, alignment.Alignment);
      Assert.Null(alignment.m_IgnoreFact);
    }

    [Fact]
    public void RequireCasterAlignment_WithIgnoreFact()
    {
      GetConfigurator(Guid)
          .RequireCasterAlignment(AlignmentMaskType.Evil, FactGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var alignment = ability.GetComponent<AbilityCasterAlignment>();
      Assert.NotNull(alignment);

      Assert.Equal(AlignmentMaskType.Evil, alignment.Alignment);
      Assert.Equal(TestFact.ToReference<BlueprintUnitFactReference>(), alignment.m_IgnoreFact);
    }

    [Fact]
    public void RequireCasterFacts()
    {
      GetConfigurator(Guid)
          .RequireCasterFacts(FactGuid, ExtraFactGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasFacts = ability.GetComponent<AbilityCasterHasFacts>();
      Assert.NotNull(hasFacts);

      Assert.Contains(TestFact.ToReference<BlueprintUnitFactReference>(), hasFacts.m_Facts);
      Assert.Contains(ExtraFact.ToReference<BlueprintUnitFactReference>(), hasFacts.m_Facts);
      Assert.Equal(2, hasFacts.m_Facts.Length);
    }

    [Fact]
    public void RequireCasterHasNoFacts()
    {
      GetConfigurator(Guid)
          .RequireCasterHasNoFacts(FactGuid, ExtraFactGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasNoFacts = ability.GetComponent<AbilityCasterHasNoFacts>();
      Assert.NotNull(hasNoFacts);

      Assert.Contains(TestFact.ToReference<BlueprintUnitFactReference>(), hasNoFacts.m_Facts);
      Assert.Contains(ExtraFact.ToReference<BlueprintUnitFactReference>(), hasNoFacts.m_Facts);
      Assert.Equal(2, hasNoFacts.m_Facts.Length);
    }

    [Fact]
    public void RequireCasterHasChosenWeapon()
    {
      GetConfigurator(Guid)
          .RequireCasterHasChosenWeapon(ParameterizedFeatureGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasChosenWeapon =
          ability.GetComponent<AbilityCasterHasChosenWeapon>();
      Assert.NotNull(hasChosenWeapon);

      Assert.Equal(
          ParameterizedFeature.ToReference<BlueprintParametrizedFeatureReference>(),
          hasChosenWeapon.m_ChosenWeaponFeature);
      Assert.Null(hasChosenWeapon.m_IgnoreWeaponFact);
    }

    [Fact]
    public void RequireCasterHasChosenWeapon_WithIgnoreFact()
    {
      GetConfigurator(Guid)
          .RequireCasterHasChosenWeapon(ParameterizedFeatureGuid, FactGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasChosenWeapon =
          ability.GetComponent<AbilityCasterHasChosenWeapon>();
      Assert.NotNull(hasChosenWeapon);

      Assert.Equal(
          ParameterizedFeature.ToReference<BlueprintParametrizedFeatureReference>(),
          hasChosenWeapon.m_ChosenWeaponFeature);
      Assert.Equal(
          TestFact.ToReference<BlueprintUnitFactReference>(), hasChosenWeapon.m_IgnoreWeaponFact);
    }

    [Fact]
    public void RequireCasterWeaponRange()
    {
      GetConfigurator(Guid)
          .RequireCasterWeaponRange(WeaponRangeType.MeleeNormal)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasWeaponRange =
          ability.GetComponent<AbilityCasterHasWeaponWithRangeType>();
      Assert.NotNull(hasWeaponRange);

      Assert.Equal(WeaponRangeType.MeleeNormal, hasWeaponRange.RangeType);
    }

    [Fact]
    public void RequireCasterInCombat()
    {
      GetConfigurator(Guid)
          .RequireCasterInCombat()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var isInCombat = ability.GetComponent<AbilityCasterInCombat>();
      Assert.NotNull(isInCombat);

      Assert.False(isInCombat.Not);
    }

    [Fact]
    public void RequireCasterInCombat_False()
    {
      GetConfigurator(Guid)
          .RequireCasterInCombat(false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var isInCombat = ability.GetComponent<AbilityCasterInCombat>();
      Assert.NotNull(isInCombat);

      Assert.True(isInCombat.Not);
    }

    [Fact]
    public void RequireCasterOnFavoredTerrain()
    {
      GetConfigurator(Guid)
          .RequireCasterOnFavoredTerrain()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var isOnFavoredTerrain =
          ability.GetComponent<AbilityCasterIsOnFavoredTerrain>();
      Assert.NotNull(isOnFavoredTerrain);

      Assert.Null(isOnFavoredTerrain.m_IgnoreFeature);
    }

    [Fact]
    public void RequireCasterOnFavoredTerrain_WithIgnoreFeature()
    {
      GetConfigurator(Guid)
          .RequireCasterOnFavoredTerrain(FeatureGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var isOnFavoredTerrain =
          ability.GetComponent<AbilityCasterIsOnFavoredTerrain>();
      Assert.NotNull(isOnFavoredTerrain);

      Assert.Equal(
          TestFeature.ToReference<BlueprintFeatureReference>(), isOnFavoredTerrain.m_IgnoreFeature);
    }

    [Fact]
    public void RequireTargetHasBuffsFromCaster()
    {
      GetConfigurator(Guid)
          .RequireTargetHasBuffsFromCaster(new string[] { BuffGuid, ExtraBuffGuid })
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasBuffs = ability.GetComponent<TargetHasBuffsFromCaster>();
      Assert.NotNull(hasBuffs);

      Assert.Equal(2, hasBuffs.Buffs.Length);
      Assert.Contains(Buff.ToReference<BlueprintBuffReference>(), hasBuffs.Buffs);
      Assert.Contains(ExtraBuff.ToReference<BlueprintBuffReference>(), hasBuffs.Buffs);

      Assert.False(hasBuffs.RequireAllBuffs);
    }

    [Fact]
    public void RequireTargetHasBuffsFromCaster_WithAllBuffs()
    {
      GetConfigurator(Guid)
          .RequireTargetHasBuffsFromCaster(
              new string[] { BuffGuid, ExtraBuffGuid }, requireAllBuffs: true)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var hasBuffs = ability.GetComponent<TargetHasBuffsFromCaster>();
      Assert.NotNull(hasBuffs);

      Assert.Equal(2, hasBuffs.Buffs.Length);
      Assert.Contains(Buff.ToReference<BlueprintBuffReference>(), hasBuffs.Buffs);
      Assert.Contains(ExtraBuff.ToReference<BlueprintBuffReference>(), hasBuffs.Buffs);

      Assert.True(hasBuffs.RequireAllBuffs);
    }

    [Fact]
    public void CanTargetDead()
    {
      GetConfigurator(Guid)
          .CanTargetDead()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var canTargetDead = ability.GetComponent<AbilityCanTargetDead>();
      Assert.NotNull(canTargetDead);
    }

    [Fact]
    public void DeliveredByWeapon()
    {
      GetConfigurator(Guid)
          .DeliveredByWeapon()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var deliveredByWeapon = ability.GetComponent<AbilityDeliveredByWeapon>();
      Assert.NotNull(deliveredByWeapon);
    }

    [Fact]
    public void DeliveredByWeapon_SkipMerge()
    {
      // First pass
      GetConfigurator(Guid)
          .DeliveredByWeapon()
          .Configure();

      var initialComponent =
          BlueprintTool.Get<BlueprintAbility>(Guid).GetComponent<AbilityDeliveredByWeapon>();
      Assert.NotNull(initialComponent);

      // Merge pass
      AbilityConfigurator.For(Guid)
          .DeliveredByWeapon()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var deliveredByWeapon = ability.GetComponent<AbilityDeliveredByWeapon>();
      Assert.Equal(initialComponent, deliveredByWeapon);
      Assert.Single(ability.GetComponents<AbilityDeliveredByWeapon>());
    }

    [Fact]
    public void DeliveredByWeapon_MultipleDeliverEffects_ThrowsException()
    {
      Assert.Throws<InvalidOperationException>(
          () => GetConfigurator(Guid)
              .DeliveredByWeapon()
              .DeliveredByWeapon()
              .Configure());
    }

    [Fact]
    public void RunActions()
    {
      AbilityConfigurator.For(Guid)
          .SetType(AbilityType.Extraordinary)
          .RunActions(ActionsBuilder.New().BreakFree().MeleeAttack())
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var runAction = ability.GetComponent<AbilityEffectRunAction>();
      Assert.NotNull(runAction);

      Assert.Equal(2, runAction.Actions.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(runAction.Actions.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(runAction.Actions.Actions[1]);

      Assert.False(runAction.HasSavingThrow);
    }

    [Fact]
    public void RunActions_WithSavingThrow()
    {
      AbilityConfigurator.For(Guid)
          .SetType(AbilityType.Extraordinary)
          .RunActions(
              ActionsBuilder.New().BreakFree().MeleeAttack(),
              SavingThrowType.Reflex)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var runAction = ability.GetComponent<AbilityEffectRunAction>();
      Assert.NotNull(runAction);

      Assert.Equal(2, runAction.Actions.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(runAction.Actions.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(runAction.Actions.Actions[1]);

      Assert.Equal(SavingThrowType.Reflex, runAction.SavingThrowType);
    }

    [Fact]
    public void RunActions_Merge()
    {
      // First pass
      AbilityConfigurator.For(Guid)
          .SetType(AbilityType.Extraordinary)
          .RunActions(
              ActionsBuilder.New().BreakFree().MeleeAttack(),
              SavingThrowType.Fortitude)
          .Configure();

      var initialComponent =
          BlueprintTool.Get<BlueprintAbility>(Guid).GetComponent<AbilityEffectRunAction>();
      Assert.NotNull(initialComponent);

      AbilityConfigurator.For(Guid)
          .RunActions(ActionsBuilder.New().MeleeAttack(), SavingThrowType.Will)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var runAction = ability.GetComponent<AbilityEffectRunAction>();
      Assert.NotNull(runAction);

      Assert.Equal(3, runAction.Actions.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(runAction.Actions.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(runAction.Actions.Actions[1]);
      Assert.IsType<ContextActionMeleeAttack>(runAction.Actions.Actions[2]);

      // Default merge ignores the new saving throw
      Assert.Equal(SavingThrowType.Fortitude, runAction.SavingThrowType);
    }

    [Fact]
    public void OnMiss()
    {
      GetConfigurator(Guid)
          .DeliveredByWeapon()
          .OnMiss(ActionsBuilder.New().BreakFree().MeleeAttack())
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var onMiss = ability.GetComponent<AbilityEffectMiss>();
      Assert.NotNull(onMiss);

      Assert.Equal(2, onMiss.MissAction.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(onMiss.MissAction.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(onMiss.MissAction.Actions[1]);

      Assert.True(onMiss.UseTargetSelector);
    }

    [Fact]
    public void OnMiss_WithoutTargetSelector()
    {
      GetConfigurator(Guid)
          .DeliveredByWeapon()
          .OnMiss(
              ActionsBuilder.New().BreakFree().MeleeAttack(),
              useTargetSelector: false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var onMiss = ability.GetComponent<AbilityEffectMiss>();
      Assert.NotNull(onMiss);

      Assert.Equal(2, onMiss.MissAction.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(onMiss.MissAction.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(onMiss.MissAction.Actions[1]);

      Assert.False(onMiss.UseTargetSelector);
    }

    [Fact]
    public void OnMiss_Merge()
    {
      // First pass
      GetConfigurator(Guid)
          .DeliveredByWeapon()
          .OnMiss(ActionsBuilder.New().BreakFree().MeleeAttack())
          .Configure();

      AbilityConfigurator.For(Guid)
          .OnMiss(
              ActionsBuilder.New().MeleeAttack(),
              useTargetSelector: false)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var onMiss = ability.GetComponent<AbilityEffectMiss>();
      Assert.NotNull(onMiss);

      Assert.Equal(3, onMiss.MissAction.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(onMiss.MissAction.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(onMiss.MissAction.Actions[1]);
      Assert.IsType<ContextActionMeleeAttack>(onMiss.MissAction.Actions[2]);

      Assert.True(onMiss.UseTargetSelector);
    }

    [Fact]
    public void OnMiss_WithoutApplyEffect_ThrowsException()
    {
      Assert.Throws<InvalidOperationException>(
          () => AbilityConfigurator.For(Guid)
              .OnMiss(ActionsBuilder.New().BreakFree().MeleeAttack())
              .Configure());
    }

    [Fact]
    public void OnCast()
    {
      GetConfigurator(Guid)
          .OnCast(ActionsBuilder.New().BreakFree().MeleeAttack())
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var onCast = ability.GetComponent<AbilityExecuteActionOnCast>();
      Assert.NotNull(onCast);

      Assert.Equal(2, onCast.Actions.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(onCast.Actions.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(onCast.Actions.Actions[1]);

      Assert.Empty(onCast.Conditions.Conditions);
    }

    [Fact]
    public void OnCast_WithConditions()
    {
      GetConfigurator(Guid)
          .OnCast(
              ActionsBuilder.New().BreakFree().MeleeAttack(),
              ConditionsBuilder.New().TargetIsYourself().TargetInMeleeRange())
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var onCast = ability.GetComponent<AbilityExecuteActionOnCast>();
      Assert.NotNull(onCast);

      Assert.Equal(2, onCast.Actions.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(onCast.Actions.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(onCast.Actions.Actions[1]);

      Assert.Equal(2, onCast.Conditions.Conditions.Length);
      Assert.IsType<ContextConditionTargetIsYourself>(onCast.Conditions.Conditions[0]);
      Assert.IsType<TargetInMeleeRange>(onCast.Conditions.Conditions[1]);
    }

    [Fact]
    public void MakeCantrip()
    {
      GetConfigurator(Guid)
          .MakeCantrip()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.NotNull(ability.GetComponent<CantripComponent>());
    }

    [Fact]
    public void MakeCantrip_Merge()
    {
      // First pass
      GetConfigurator(Guid)
          .MakeCantrip()
          .Configure();

      AbilityConfigurator.For(Guid)
          .MakeCantrip()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.NotNull(ability.GetComponent<CantripComponent>());
      Assert.Single(ability.GetComponents<CantripComponent>());
    }

    [Fact]
    public void MakeNotCantrip()
    {
      // First pass
      GetConfigurator(Guid)
          .MakeCantrip()
          .Configure();

      AbilityConfigurator.For(Guid)
          .MakeNotCantrip()
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      Assert.Null(ability.GetComponent<CantripComponent>());
    }

    [Fact]
    public void SetSpellSchool()
    {
      GetConfigurator(Guid)
          .SetType(AbilityType.SpellLike)
          .SetSpellSchool(SpellSchool.Divination)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var component = ability.GetComponent<SpellComponent>();
      Assert.NotNull(component);
      Assert.Equal(SpellSchool.Divination, component.School);
    }

    [Fact]
    public void AddVariants()
    {
      GetConfigurator(Guid)
          .AddVariants(AbilityGuid, ExtraAbilityGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var variants = ability.GetComponent<AbilityVariants>();
      Assert.NotNull(variants);

      Assert.Equal(2, variants.m_Variants.Length);
      Assert.Contains(TestAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);
      Assert.Contains(ExtraAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);
    }

    [Fact]
    public void AddVariants_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .AddVariants(AbilityGuid, ExtraAbilityGuid)
          .Configure();

      AbilityConfigurator.For(Guid)
          .AddVariants(AnotherAbilityGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var variants = ability.GetComponent<AbilityVariants>();
      Assert.NotNull(variants);

      Assert.Equal(3, variants.m_Variants.Length);
      Assert.Contains(TestAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);
      Assert.Contains(ExtraAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);
      Assert.Contains(AnotherAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);
    }

    [Fact]
    public void RemoveVariants()
    {
      // First pass
      GetConfigurator(Guid)
          .AddVariants(AbilityGuid, ExtraAbilityGuid, AnotherAbilityGuid)
          .Configure();

      AbilityConfigurator.For(Guid)
          .RemoveVariants(AbilityGuid)
          .Configure();

      var ability = BlueprintTool.Get<BlueprintAbility>(Guid);
      var variants = ability.GetComponent<AbilityVariants>();
      Assert.NotNull(variants);

      Assert.Equal(2, variants.m_Variants.Length);
      Assert.Contains(ExtraAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);
      Assert.Contains(AnotherAbility.ToReference<BlueprintAbilityReference>(), variants.m_Variants);

      Assert.Equal(BlueprintGuid.Empty, TestAbility.m_Parent.deserializedGuid);
    }

    private class TestAbilityDeliverEffect : AbilityDeliverEffect
    {
      public override IEnumerator<AbilityDeliveryTarget> Deliver(
          AbilityExecutionContext context, TargetWrapper target)
      { return null; }
    }
  }
}
