using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Conditions.New;
using BlueprintCore.Test.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.ContextEx
{
  public class ActionListBuilderContextExTest : TestBase
  {
    [Fact]
    public void ApplyBuff()
    {
      var actions =
          ActionListBuilder.New()
              .ApplyBuff(BuffGuid, useDurationSeconds: true, durationSeconds: 1f)
              .Build();

      Assert.Single(actions.Actions);
      var applyBuff = (ContextActionApplyBuff)actions.Actions[0];
      ElementAsserts.IsValid(applyBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), applyBuff.m_Buff);
      Assert.True(applyBuff.UseDurationSeconds);
      Assert.Equal(1f, applyBuff.DurationSeconds);
      Assert.Null(applyBuff.DurationValue);
      Assert.False(applyBuff.Permanent);
      Assert.False(applyBuff.IsFromSpell);
      Assert.False(applyBuff.IsNotDispelable);
      Assert.False(applyBuff.ToCaster);
      Assert.True(applyBuff.AsChild);
      Assert.False(applyBuff.SameDuration);
    }

    [Fact]
    public void ApplyBuff_WithDurationValue()
    {
      var duration = ContextDuration.Fixed(2);

      var actions =
          ActionListBuilder.New()
              .ApplyBuff(BuffGuid, duration: duration)
              .Build();

      Assert.Single(actions.Actions);
      var applyBuff = (ContextActionApplyBuff)actions.Actions[0];
      ElementAsserts.IsValid(applyBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), applyBuff.m_Buff);
      Assert.False(applyBuff.UseDurationSeconds);
      Assert.Equal(0f, applyBuff.DurationSeconds);
      Assert.Equal(duration, applyBuff.DurationValue);
      Assert.False(applyBuff.Permanent);
      Assert.False(applyBuff.IsFromSpell);
      Assert.False(applyBuff.IsNotDispelable);
      Assert.False(applyBuff.ToCaster);
      Assert.True(applyBuff.AsChild);
      Assert.False(applyBuff.SameDuration);
    }

    [Fact]
    public void ApplyBuff_WithPermanentDuration()
    {
      var actions =
          ActionListBuilder.New()
              .ApplyBuff(BuffGuid, permanent: true)
              .Build();

      Assert.Single(actions.Actions);
      var applyBuff = (ContextActionApplyBuff)actions.Actions[0];
      ElementAsserts.IsValid(applyBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), applyBuff.m_Buff);
      Assert.False(applyBuff.UseDurationSeconds);
      Assert.Equal(0f, applyBuff.DurationSeconds);
      Assert.Null(applyBuff.DurationValue);
      Assert.True(applyBuff.Permanent);
      Assert.False(applyBuff.IsFromSpell);
      Assert.False(applyBuff.IsNotDispelable);
      Assert.False(applyBuff.ToCaster);
      Assert.True(applyBuff.AsChild);
      Assert.False(applyBuff.SameDuration);
    }

    [Fact]
    public void ApplyBuff_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .ApplyBuff(
                  BuffGuid,
                  permanent: true,
                  isFromSpell: true,
                  dispellable: false,
                  toCaster: true,
                  asChild: false,
                  sameDuration: true)
              .Build();

      Assert.Single(actions.Actions);
      var applyBuff = (ContextActionApplyBuff)actions.Actions[0];
      ElementAsserts.IsValid(applyBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), applyBuff.m_Buff);
      Assert.False(applyBuff.UseDurationSeconds);
      Assert.Equal(0f, applyBuff.DurationSeconds);
      Assert.Null(applyBuff.DurationValue);
      Assert.True(applyBuff.Permanent);
      Assert.True(applyBuff.IsFromSpell);
      Assert.True(applyBuff.IsNotDispelable);
      Assert.True(applyBuff.ToCaster);
      Assert.False(applyBuff.AsChild);
      Assert.True(applyBuff.SameDuration);
    }

    [Fact]
    public void ApplyBuff_WithoutDuration()
    {
      Assert.Throws<InvalidOperationException>(
          () => ActionListBuilder.New().ApplyBuff(BuffGuid).Build());
    }

    [Fact]
    public void AddFeature()
    {
      var actions = ActionListBuilder.New().AddFeature(FeatureGuid).Build();

      Assert.Single(actions.Actions);
      var addFeature = (ContextActionAddFeature)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_PermanentFeature);
    }

    [Fact]
    public void AddLocustClone()
    {
      var actions = ActionListBuilder.New().AddLocustClone(FeatureGuid).Build();

      Assert.Single(actions.Actions);
      var addClone = (ContextActionAddLocustClone)actions.Actions[0];
      ElementAsserts.IsValid(addClone);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), addClone.m_CloneFeature);
    }

    [Fact]
    public void AeonRollbackState()
    {
      var actions = ActionListBuilder.New().AeonRollbackState().Build();

      Assert.Single(actions.Actions);
      var rollbackState = (ContextActionAeonRollbackToSavedState)actions.Actions[0];
      ElementAsserts.IsValid(rollbackState);
    }

    // Default GUIDs for ArmorEnchantPool
    private const string PlusOneArmor = "1d9b60d57afb45c4f9bb0a3c21bb3b98";
    private const string PlusTwoArmor = "d45bfd838c541bb40bde7b0bf0e1b684";
    private const string PlusThreeArmor = "51c51d841e9f16046a169729c13c4d4f";
    private const string PlusFourArmor = "a23bcee56c9fcf64d863dafedb369387";
    private const string PlusFiveArmor = "15d7d6cbbf56bd744b37bbf9225ea83b";

    private static void SetupArmorEnchantPool()
    {
      BlueprintPatch.Add(
          Util.Create<BlueprintEquipmentEnchantment>(PlusOneArmor),
          Util.Create<BlueprintEquipmentEnchantment>(PlusTwoArmor),
          Util.Create<BlueprintEquipmentEnchantment>(PlusThreeArmor),
          Util.Create<BlueprintEquipmentEnchantment>(PlusFourArmor),
          Util.Create<BlueprintEquipmentEnchantment>(PlusFiveArmor));
    }

    [Fact]
    public void ArmorEnchantPool()
    {
      SetupArmorEnchantPool();

      var actions =
          ActionListBuilder.New()
              .ArmorEnchantPool(EnchantPoolType.ArcanePool, ContextDuration.Fixed(3))
              .Build();

      Assert.Single(actions.Actions);
      var enchantArmor = (ContextActionArmorEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchantArmor);

      Assert.Equal(EnchantPoolType.ArcanePool, enchantArmor.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.None, enchantArmor.Group);
      Assert.Equal(3, enchantArmor.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusOneArmor, enchantArmor.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusTwoArmor, enchantArmor.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeArmor, enchantArmor.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourArmor, enchantArmor.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveArmor, enchantArmor.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void ArmorEnchantPool_WithOptionalValues()
    {
      SetupArmorEnchantPool();

      var actions =
          ActionListBuilder.New()
              .ArmorEnchantPool(
                EnchantPoolType.SacredArmorPool,
                ContextDuration.Fixed(6),
                group: ActivatableAbilityGroup.TrueMagus,
                plusOneEnchantment: PlusTwoArmor,
                plusTwoEnchantment: PlusThreeArmor,
                plusThreeEnchantment: PlusFourArmor,
                plusFourEnchantment: PlusFiveArmor,
                plusFiveEnchantment: PlusOneArmor)
              .Build();

      Assert.Single(actions.Actions);
      var enchantArmor = (ContextActionArmorEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchantArmor);

      Assert.Equal(EnchantPoolType.SacredArmorPool, enchantArmor.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.TrueMagus, enchantArmor.Group);
      Assert.Equal(6, enchantArmor.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusTwoArmor, enchantArmor.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeArmor, enchantArmor.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourArmor, enchantArmor.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveArmor, enchantArmor.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusOneArmor, enchantArmor.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void ShieldArmorEnchantPool()
    {
      SetupArmorEnchantPool();

      var actions =
          ActionListBuilder.New()
              .ShieldArmorEnchantPool(EnchantPoolType.ArcanePool, ContextDuration.Fixed(3))
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionShieldArmorEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(EnchantPoolType.ArcanePool, enchant.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.None, enchant.Group);
      Assert.Equal(3, enchant.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusOneArmor, enchant.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusTwoArmor, enchant.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeArmor, enchant.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourArmor, enchant.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveArmor, enchant.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void ShieldArmorEnchantPool_WithOptionalValues()
    {
      SetupArmorEnchantPool();

      var actions =
          ActionListBuilder.New()
              .ShieldArmorEnchantPool(
                EnchantPoolType.SacredArmorPool,
                ContextDuration.Fixed(6),
                group: ActivatableAbilityGroup.TrueMagus,
                plusOneEnchantment: PlusTwoArmor,
                plusTwoEnchantment: PlusThreeArmor,
                plusThreeEnchantment: PlusFourArmor,
                plusFourEnchantment: PlusFiveArmor,
                plusFiveEnchantment: PlusOneArmor)
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionShieldArmorEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(EnchantPoolType.SacredArmorPool, enchant.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.TrueMagus, enchant.Group);
      Assert.Equal(6, enchant.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusTwoArmor, enchant.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeArmor, enchant.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourArmor, enchant.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveArmor, enchant.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusOneArmor, enchant.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    // Default GUIDs for WeaponEnchantPool and ShieldWeaponEnchantPool
    private const string PlusOneWeapon = "d704f90f54f813043a525f304f6c0050";
    private const string PlusTwoWeapon = "9e9bab3020ec5f64499e007880b37e52";
    private const string PlusThreeWeapon = "d072b841ba0668846adeb007f623bd6c";
    private const string PlusFourWeapon = "6a6a0901d799ceb49b33d4851ff72132";
    private const string PlusFiveWeapon = "746ee366e50611146821d61e391edf16";

    private static void SetupWeaponEnchantPool()
    {
      BlueprintPatch.Add(
          Util.Create<BlueprintEquipmentEnchantment>(PlusOneWeapon),
          Util.Create<BlueprintEquipmentEnchantment>(PlusTwoWeapon),
          Util.Create<BlueprintEquipmentEnchantment>(PlusThreeWeapon),
          Util.Create<BlueprintEquipmentEnchantment>(PlusFourWeapon),
          Util.Create<BlueprintEquipmentEnchantment>(PlusFiveWeapon));
    }

    [Fact]
    public void WeaponEnchantPool()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .WeaponEnchantPool(EnchantPoolType.ArcanePool, ContextDuration.Fixed(3))
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionWeaponEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(EnchantPoolType.ArcanePool, enchant.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.None, enchant.Group);
      Assert.Equal(3, enchant.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusOneWeapon, enchant.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusTwoWeapon, enchant.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeWeapon, enchant.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourWeapon, enchant.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveWeapon, enchant.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void WeaponEnchantPool_WithOptionalValues()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .WeaponEnchantPool(
                EnchantPoolType.SacredWeaponPool,
                ContextDuration.Fixed(6),
                group: ActivatableAbilityGroup.TrueMagus,
                plusOneEnchantment: PlusTwoWeapon,
                plusTwoEnchantment: PlusThreeWeapon,
                plusThreeEnchantment: PlusFourWeapon,
                plusFourEnchantment: PlusFiveWeapon,
                plusFiveEnchantment: PlusOneWeapon)
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionWeaponEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(EnchantPoolType.SacredWeaponPool, enchant.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.TrueMagus, enchant.Group);
      Assert.Equal(6, enchant.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusTwoWeapon, enchant.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeWeapon, enchant.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourWeapon, enchant.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveWeapon, enchant.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusOneWeapon, enchant.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void ShieldWeaponEnchantPool()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .ShieldWeaponEnchantPool(EnchantPoolType.ArcanePool, ContextDuration.Fixed(3))
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionShieldWeaponEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(EnchantPoolType.ArcanePool, enchant.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.None, enchant.Group);
      Assert.Equal(3, enchant.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusOneWeapon, enchant.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusTwoWeapon, enchant.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeWeapon, enchant.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourWeapon, enchant.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveWeapon, enchant.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void ShieldWeaponEnchantPool_WithOptionalValues()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .ShieldWeaponEnchantPool(
                EnchantPoolType.SacredWeaponPool,
                ContextDuration.Fixed(6),
                group: ActivatableAbilityGroup.TrueMagus,
                plusOneEnchantment: PlusTwoWeapon,
                plusTwoEnchantment: PlusThreeWeapon,
                plusThreeEnchantment: PlusFourWeapon,
                plusFourEnchantment: PlusFiveWeapon,
                plusFiveEnchantment: PlusOneWeapon)
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionShieldWeaponEnchantPool)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(EnchantPoolType.SacredWeaponPool, enchant.EnchantPool);
      Assert.Equal(ActivatableAbilityGroup.TrueMagus, enchant.Group);
      Assert.Equal(6, enchant.DurationValue.BonusValue.Value);

      Assert.Equal(
          PlusTwoWeapon, enchant.m_DefaultEnchantments[0].deserializedGuid.ToString());
      Assert.Equal(
          PlusThreeWeapon, enchant.m_DefaultEnchantments[1].deserializedGuid.ToString());
      Assert.Equal(
          PlusFourWeapon, enchant.m_DefaultEnchantments[2].deserializedGuid.ToString());
      Assert.Equal(
          PlusFiveWeapon, enchant.m_DefaultEnchantments[3].deserializedGuid.ToString());
      Assert.Equal(
          PlusOneWeapon, enchant.m_DefaultEnchantments[4].deserializedGuid.ToString());
    }

    [Fact]
    public void AttackWithWeapon()
    {
      var actions =
          ActionListBuilder.New().AttackWithWeapon(StatType.Intelligence, WeaponGuid).Build();

      Assert.Single(actions.Actions);
      var attack = (ContextActionAttackWithWeapon)actions.Actions[0];
      ElementAsserts.IsValid(attack);

      Assert.Equal(StatType.Intelligence, attack.m_Stat);
      Assert.Equal(Weapon.ToReference<BlueprintItemWeaponReference>(), attack.m_WeaponRef);
    }

    [Fact]
    public void BatteringBlast()
    {
      var actions = ActionListBuilder.New().BatteringBlast().Build();

      Assert.Single(actions.Actions);
      var blast = (ContextActionBatteringBlast)actions.Actions[0];
      ElementAsserts.IsValid(blast);

      Assert.False(blast.Remove);
    }

    [Fact]
    public void BatteringBlast_Remove()
    {
      var actions = ActionListBuilder.New().BatteringBlast(true).Build();

      Assert.Single(actions.Actions);
      var blast = (ContextActionBatteringBlast)actions.Actions[0];
      ElementAsserts.IsValid(blast);

      Assert.True(blast.Remove);
    }

    [Fact]
    public void BreakFree()
    {
      var actions = ActionListBuilder.New().BreakFree().Build();

      Assert.Single(actions.Actions);
      var breakFree = (ContextActionBreakFree)actions.Actions[0];
      ElementAsserts.IsValid(breakFree);

      Assert.False(breakFree.UseCMB);
      Assert.False(breakFree.UseCMD);
      Assert.Empty(breakFree.Success.Actions);
      Assert.Empty(breakFree.Failure.Actions);
    }

    [Fact]
    public void BreakFree_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .BreakFree(
                  useCMB: true,
                  useCMD: true,
                  onSuccess: ActionListBuilder.New().MeleeAttack(),
                  onFail: ActionListBuilder.New().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var breakFree = (ContextActionBreakFree)actions.Actions[0];
      ElementAsserts.IsValid(breakFree);

      Assert.True(breakFree.UseCMB);
      Assert.True(breakFree.UseCMD);
      Assert.IsType<ContextActionMeleeAttack>(breakFree.Success.Actions[0]);
      Assert.IsType<SwitchToDemoralizeTarget>(breakFree.Failure.Actions[0]);
    }

    [Fact]
    public void BreathOfLife()
    {
      var actions =
          ActionListBuilder.New()
              .BreathOfLife(
                  new ContextDiceValue
                  {
                    DiceType = DiceType.D2,
                    DiceCountValue = 2,
                    BonusValue = 3
                  })
              .Build();

      Assert.Single(actions.Actions);
      var breathOfLife = (ContextActionBreathOfLife)actions.Actions[0];
      ElementAsserts.IsValid(breathOfLife);

      Assert.Equal(DiceType.D2, breathOfLife.Value.DiceType);
      Assert.Equal(2, breathOfLife.Value.DiceCountValue.Value);
      Assert.Equal(3, breathOfLife.Value.BonusValue.Value);
    }

    [Fact]
    public void BreathOfMoney()
    {
      var actions = ActionListBuilder.New().BreathOfMoney(1, 5).Build();

      Assert.Single(actions.Actions);
      var breathOfMoney = (ContextActionBreathOfMoney)actions.Actions[0];
      ElementAsserts.IsValid(breathOfMoney);

      Assert.Equal(1, breathOfMoney.MinCoins.Value);
      Assert.Equal(5, breathOfMoney.MaxCoins.Value);
    }

    [Fact]
    public void SetSharedValue()
    {
      var actions =
          ActionListBuilder.New().SetSharedValue(AbilitySharedValue.DamageBonus, 3).Build();

      Assert.Single(actions.Actions);
      var setValue = (ContextActionChangeSharedValue)actions.Actions[0];
      ElementAsserts.IsValid(setValue);

      Assert.Equal(AbilitySharedValue.DamageBonus, setValue.SharedValue);
      Assert.Equal(SharedValueChangeType.Set, setValue.Type);
      Assert.Equal(3, setValue.SetValue.Value);
    }

    [Fact]
    public void SetSharedValueToHD()
    {
      var actions =
          ActionListBuilder.New().SetSharedValueToHD(AbilitySharedValue.Damage).Build();

      Assert.Single(actions.Actions);
      var setValue = (ContextActionChangeSharedValue)actions.Actions[0];
      ElementAsserts.IsValid(setValue);

      Assert.Equal(AbilitySharedValue.Damage, setValue.SharedValue);
      Assert.Equal(SharedValueChangeType.SubHD, setValue.Type);
    }

    [Fact]
    public void AddToSharedValue()
    {
      var actions =
          ActionListBuilder.New().AddToSharedValue(AbilitySharedValue.DungeonBoonValue, 5).Build();

      Assert.Single(actions.Actions);
      var setValue = (ContextActionChangeSharedValue)actions.Actions[0];
      ElementAsserts.IsValid(setValue);

      Assert.Equal(AbilitySharedValue.DungeonBoonValue, setValue.SharedValue);
      Assert.Equal(SharedValueChangeType.Add, setValue.Type);
      Assert.Equal(5, setValue.AddValue.Value);
    }

    [Fact]
    public void MultiplySharedValue()
    {
      var actions = ActionListBuilder.New().MultiplySharedValue(AbilitySharedValue.Heal, 4).Build();

      Assert.Single(actions.Actions);
      var setValue = (ContextActionChangeSharedValue)actions.Actions[0];
      ElementAsserts.IsValid(setValue);

      Assert.Equal(AbilitySharedValue.Heal, setValue.SharedValue);
      Assert.Equal(SharedValueChangeType.Multiply, setValue.Type);
      Assert.Equal(4, setValue.MultiplyValue.Value);
    }

    [Fact]
    public void DivideSharedValueBy2()
    {
      var actions =
          ActionListBuilder.New().DivideSharedValueBy2(AbilitySharedValue.StatBonus).Build();

      Assert.Single(actions.Actions);
      var setValue = (ContextActionChangeSharedValue)actions.Actions[0];
      ElementAsserts.IsValid(setValue);

      Assert.Equal(AbilitySharedValue.StatBonus, setValue.SharedValue);
      Assert.Equal(SharedValueChangeType.Div2, setValue.Type);
    }

    [Fact]
    public void DivideSharedValueBy4()
    {
      var actions =
          ActionListBuilder.New().DivideSharedValueBy4(AbilitySharedValue.Duration).Build();

      Assert.Single(actions.Actions);
      var setValue = (ContextActionChangeSharedValue)actions.Actions[0];
      ElementAsserts.IsValid(setValue);

      Assert.Equal(AbilitySharedValue.Duration, setValue.SharedValue);
      Assert.Equal(SharedValueChangeType.Div4, setValue.Type);
    }

    [Fact]
    public void ClearSummonPool()
    {
      var actions = ActionListBuilder.New().ClearSummonPool(SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var clearSummons = (ContextActionClearSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(clearSummons);

      Assert.Equal(
          SummonPool.ToReference<BlueprintSummonPoolReference>(), clearSummons.m_SummonPool);
    }

    [Fact]
    public void CombatManeuver()
    {
      var actions =
          ActionListBuilder.New()
          .CombatManeuver(
              Kingmaker.RuleSystem.Rules.CombatManeuver.Disarm,
              ActionListBuilder.New().MeleeAttack())
          .Build();

      Assert.Single(actions.Actions);
      var maneuver = (ContextActionCombatManeuver)actions.Actions[0];
      ElementAsserts.IsValid(maneuver);

      Assert.Equal(Kingmaker.RuleSystem.Rules.CombatManeuver.Disarm, maneuver.Type);
      Assert.IsType<ContextActionMeleeAttack>(maneuver.OnSuccess.Actions[0]);
      Assert.False(maneuver.IgnoreConcealment);
      Assert.False(maneuver.BatteringBlast);
      Assert.False(maneuver.ReplaceStat);
    }

    [Fact]
    public void CombatManeuver_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
          .CombatManeuver(
              Kingmaker.RuleSystem.Rules.CombatManeuver.Grapple,
              ActionListBuilder.New().MeleeAttack(),
              ignoreConcealment: true,
              batteringBlast: true,
              useStat: StatType.Strength,
              useKineticistMainStat: true,
              useCastingStat: true,
              useCasterLevelForBAB: true,
              useBestMentalStat: true)
          .Build();

      Assert.Single(actions.Actions);
      var maneuver = (ContextActionCombatManeuver)actions.Actions[0];
      ElementAsserts.IsValid(maneuver);

      Assert.Equal(Kingmaker.RuleSystem.Rules.CombatManeuver.Grapple, maneuver.Type);
      Assert.IsType<ContextActionMeleeAttack>(maneuver.OnSuccess.Actions[0]);
      Assert.True(maneuver.IgnoreConcealment);
      Assert.True(maneuver.BatteringBlast);
      Assert.True(maneuver.ReplaceStat);
      Assert.Equal(StatType.Strength, maneuver.NewStat);
      Assert.True(maneuver.UseKineticistMainStat);
      Assert.True(maneuver.UseCastingStat);
      Assert.True(maneuver.UseCasterLevelAsBaseAttack);
      Assert.True(maneuver.UseBestMentalStat);
    }

    [Fact]
    public void CustomCombatManeuver()
    {
      var actions =
          ActionListBuilder.New()
              .CustomCombatManeuver(Kingmaker.RuleSystem.Rules.CombatManeuver.DirtyTrickBlind)
              .Build();

      Assert.Single(actions.Actions);
      var maneuver = (ContextActionCombatManeuverCustom)actions.Actions[0];
      ElementAsserts.IsValid(maneuver);

      Assert.Equal(Kingmaker.RuleSystem.Rules.CombatManeuver.DirtyTrickBlind, maneuver.Type);
      Assert.Empty(maneuver.Success.Actions);
      Assert.Empty(maneuver.Failure.Actions);
    }

    [Fact]
    public void CustomCombatManeuver_WithActions()
    {
      var actions =
          ActionListBuilder.New()
              .CustomCombatManeuver(
                  Kingmaker.RuleSystem.Rules.CombatManeuver.DirtyTrickBlind,
                  onSuccess: ActionListBuilder.New().MeleeAttack(),
                  onFail: ActionListBuilder.New().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var maneuver = (ContextActionCombatManeuverCustom)actions.Actions[0];
      ElementAsserts.IsValid(maneuver);

      Assert.Equal(Kingmaker.RuleSystem.Rules.CombatManeuver.DirtyTrickBlind, maneuver.Type);
      Assert.IsType<ContextActionMeleeAttack>(maneuver.Success.Actions[0]);
      Assert.IsType<SwitchToDemoralizeTarget>(maneuver.Failure.Actions[0]);
    }

    [Fact]
    public void AfterSavingThrow()
    {
      var actions = ActionListBuilder.New().AfterSavingThrow().Build();

      Assert.Single(actions.Actions);
      var onSave = (ContextActionConditionalSaved)actions.Actions[0];
      ElementAsserts.IsValid(onSave);

      Assert.Empty(onSave.Succeed.Actions);
      Assert.Empty(onSave.Failed.Actions);
    }

    [Fact]
    public void AfterSavingThrow_WithActions()
    {
      var actions =
          ActionListBuilder.New()
              .AfterSavingThrow(
                  ifPassed: ActionListBuilder.New().MeleeAttack(),
                  ifFailed: ActionListBuilder.New().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var onSave = (ContextActionConditionalSaved)actions.Actions[0];
      ElementAsserts.IsValid(onSave);

      Assert.IsType<ContextActionMeleeAttack>(onSave.Succeed.Actions[0]);
      Assert.IsType<SwitchToDemoralizeTarget>(onSave.Failed.Actions[0]);
    }

    [Fact]
    public void DealDamage()
    {
      var actions =
          ActionListBuilder.New()
              .DealDamage(
                  TestDamageTypeDescription,
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 2,
                    BonusValue = 3
                  })
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.Damage, dmg.m_Type);
      Assert.Equal(TestDamageTypeDescription, dmg.DamageType);

      Assert.False(dmg.Half);
      Assert.False(dmg.IsAoE);
      Assert.False(dmg.HalfIfSaved);
      Assert.False(dmg.IgnoreCritical);
      Assert.False(dmg.UseMinHPAfterDamage);

      Assert.False(dmg.WriteResultToSharedValue);
      Assert.False(dmg.WriteCriticalToSharedValue);

      Assert.False(dmg.ReadPreRolledFromSharedValue);
      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(2, dmg.Value.DiceCountValue.Value);
      Assert.Equal(3, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealDamage(
                  TestDamageTypeDescription,
                  new ContextDiceValue
                  {
                    DiceType = DiceType.D2,
                    DiceCountValue = 3,
                    BonusValue = 4
                  },
                  dealHalfIfSaved: true,
                  dealHalf: true,
                  ignoreCrit: true,
                  isAOE: true,
                  minHPAfterDmg: 5,
                  sharedResult: AbilitySharedValue.DamageBonus,
                  criticalSharedResult: AbilitySharedValue.Duration)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.Damage, dmg.m_Type);
      Assert.Equal(TestDamageTypeDescription, dmg.DamageType);

      Assert.True(dmg.Half);
      Assert.True(dmg.IsAoE);
      Assert.True(dmg.HalfIfSaved);
      Assert.True(dmg.IgnoreCritical);

      Assert.True(dmg.UseMinHPAfterDamage);
      Assert.Equal(5, dmg.MinHPAfterDamage);

      Assert.True(dmg.WriteResultToSharedValue);
      Assert.Equal(AbilitySharedValue.DamageBonus, dmg.ResultSharedValue);
      Assert.True(dmg.WriteCriticalToSharedValue);
      Assert.Equal(AbilitySharedValue.Duration, dmg.CriticalSharedValue);

      Assert.False(dmg.ReadPreRolledFromSharedValue);
      Assert.Equal(DiceType.D2, dmg.Value.DiceType);
      Assert.Equal(3, dmg.Value.DiceCountValue.Value);
      Assert.Equal(4, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealDamagePreRolled()
    {
      var actions =
          ActionListBuilder.New()
              .DealDamagePreRolled(TestDamageTypeDescription, AbilitySharedValue.Damage)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.Damage, dmg.m_Type);
      Assert.Equal(TestDamageTypeDescription, dmg.DamageType);

      Assert.False(dmg.Half);
      Assert.False(dmg.HalfIfSaved);
      Assert.False(dmg.AlreadyHalved);
      Assert.False(dmg.IgnoreCritical);
      Assert.False(dmg.UseMinHPAfterDamage);

      Assert.False(dmg.WriteResultToSharedValue);
      Assert.False(dmg.WriteCriticalToSharedValue);

      Assert.True(dmg.ReadPreRolledFromSharedValue);
      Assert.Equal(AbilitySharedValue.Damage, dmg.PreRolledSharedValue);
    }

    [Fact]
    public void DealDamagePreRolled_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealDamagePreRolled(
                  TestDamageTypeDescription,
                  AbilitySharedValue.Damage,
                  dealHalfIfSaved: true,
                  dealHalf: true,
                  alreadyHalved: true,
                  ignoreCrit: true,
                  minHPAfterDmg: 8,
                  sharedResult: AbilitySharedValue.DamageBonus,
                  criticalSharedResult: AbilitySharedValue.Duration)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.Damage, dmg.m_Type);
      Assert.Equal(TestDamageTypeDescription, dmg.DamageType);

      Assert.True(dmg.Half);
      Assert.True(dmg.HalfIfSaved);
      Assert.True(dmg.AlreadyHalved);
      Assert.True(dmg.IgnoreCritical);

      Assert.True(dmg.UseMinHPAfterDamage);
      Assert.Equal(8, dmg.MinHPAfterDamage);

      Assert.True(dmg.WriteResultToSharedValue);
      Assert.Equal(AbilitySharedValue.DamageBonus, dmg.ResultSharedValue);
      Assert.True(dmg.WriteCriticalToSharedValue);
      Assert.Equal(AbilitySharedValue.Duration, dmg.CriticalSharedValue);

      Assert.True(dmg.ReadPreRolledFromSharedValue);
      Assert.Equal(AbilitySharedValue.Damage, dmg.PreRolledSharedValue);
    }

    [Fact]
    public void DealAbilityDamage()
    {
      var actions =
          ActionListBuilder.New()
              .DealAbilityDamage(
                  StatType.Strength,
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 2,
                    BonusValue = 3
                  })
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.AbilityDamage, dmg.m_Type);
      Assert.Equal(StatType.Strength, dmg.AbilityType);

      Assert.False(dmg.Drain);
      Assert.False(dmg.HalfIfSaved);
      Assert.False(dmg.IgnoreCritical);
      Assert.False(dmg.UseMinHPAfterDamage);

      Assert.False(dmg.WriteResultToSharedValue);
      Assert.False(dmg.WriteCriticalToSharedValue);

      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(2, dmg.Value.DiceCountValue.Value);
      Assert.Equal(3, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealAbilityDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealAbilityDamage(
                  StatType.Strength,
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 4,
                    BonusValue = 5
                  },
                  isDrain: true,
                  dealHalfIfSaved: true,
                  ignoreCrit: true,
                  minStatAfterDmg: 1,
                  sharedResult: AbilitySharedValue.Duration,
                  criticalSharedResult: AbilitySharedValue.Heal)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.AbilityDamage, dmg.m_Type);
      Assert.Equal(StatType.Strength, dmg.AbilityType);

      Assert.True(dmg.Drain);
      Assert.True(dmg.HalfIfSaved);
      Assert.True(dmg.IgnoreCritical);

      Assert.True(dmg.UseMinHPAfterDamage);
      Assert.Equal(1, dmg.MinHPAfterDamage);

      Assert.True(dmg.WriteResultToSharedValue);
      Assert.Equal(AbilitySharedValue.Duration, dmg.ResultSharedValue);
      Assert.True(dmg.WriteCriticalToSharedValue);
      Assert.Equal(AbilitySharedValue.Heal, dmg.CriticalSharedValue);

      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(4, dmg.Value.DiceCountValue.Value);
      Assert.Equal(5, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealPermanentNegativeLevels()
    {
      var actions =
          ActionListBuilder.New()
              .DealPermanentNegativeLevels(
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 2,
                    BonusValue = 3
                  })
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.EnergyDrain, dmg.m_Type);
      Assert.Equal(EnergyDrainType.Permanent, dmg.EnergyDrainType);

      Assert.False(dmg.HalfIfSaved);
      Assert.False(dmg.IgnoreCritical);

      Assert.False(dmg.WriteResultToSharedValue);
      Assert.False(dmg.WriteCriticalToSharedValue);

      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(2, dmg.Value.DiceCountValue.Value);
      Assert.Equal(3, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealPermanentNegativeLevels_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealPermanentNegativeLevels(
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 1,
                    BonusValue = 2
                  },
                  dealHalfIfSaved: true,
                  ignoreCrit: true,
                  sharedResult: AbilitySharedValue.Damage,
                  criticalSharedResult: AbilitySharedValue.Duration)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.EnergyDrain, dmg.m_Type);
      Assert.Equal(EnergyDrainType.Permanent, dmg.EnergyDrainType);

      Assert.True(dmg.HalfIfSaved);
      Assert.True(dmg.IgnoreCritical);

      Assert.True(dmg.WriteResultToSharedValue);
      Assert.Equal(AbilitySharedValue.Damage, dmg.ResultSharedValue);
      Assert.True(dmg.WriteCriticalToSharedValue);
      Assert.Equal(AbilitySharedValue.Duration, dmg.CriticalSharedValue);

      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(1, dmg.Value.DiceCountValue.Value);
      Assert.Equal(2, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealTempNegativeLevels()
    {
      var actions =
          ActionListBuilder.New()
              .DealTempNegativeLevels(
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 2,
                    BonusValue = 3
                  },
                  ContextDuration.Fixed(2))
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.EnergyDrain, dmg.m_Type);
      Assert.Equal(EnergyDrainType.Temporary, dmg.EnergyDrainType);
      Assert.Equal(2, dmg.Duration.BonusValue.Value);

      Assert.False(dmg.HalfIfSaved);
      Assert.False(dmg.IgnoreCritical);

      Assert.False(dmg.WriteResultToSharedValue);
      Assert.False(dmg.WriteCriticalToSharedValue);

      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(2, dmg.Value.DiceCountValue.Value);
      Assert.Equal(3, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealTempNegativeLevels_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealTempNegativeLevels(
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 1,
                    BonusValue = 1
                  },
                  ContextDuration.Fixed(2),
                  permanentOnFailedSave: true,
                  dealHalfIfSaved: true,
                  ignoreCrit: true,
                  sharedResult: AbilitySharedValue.StatBonus,
                  criticalSharedResult: AbilitySharedValue.StatBonus)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ContextActionDealDamage.Type.EnergyDrain, dmg.m_Type);
      Assert.Equal(EnergyDrainType.SaveOrBecamePermanent, dmg.EnergyDrainType);
      Assert.Equal(2, dmg.Duration.BonusValue.Value);

      Assert.True(dmg.HalfIfSaved);
      Assert.True(dmg.IgnoreCritical);

      Assert.True(dmg.WriteResultToSharedValue);
      Assert.Equal(AbilitySharedValue.StatBonus, dmg.ResultSharedValue);
      Assert.True(dmg.WriteCriticalToSharedValue);
      Assert.Equal(AbilitySharedValue.StatBonus, dmg.CriticalSharedValue);

      Assert.Equal(DiceType.One, dmg.Value.DiceType);
      Assert.Equal(1, dmg.Value.DiceCountValue.Value);
      Assert.Equal(1, dmg.Value.BonusValue.Value);
    }

    [Fact]
    public void DealWeaponDamage()
    {
      var actions = ActionListBuilder.New().DealWeaponDamage().Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealWeaponDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.False(dmg.CanBeRanged);
    }

    [Fact]
    public void DealWeaponDamage_AllowRanged()
    {
      var actions = ActionListBuilder.New().DealWeaponDamage(true).Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionDealWeaponDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.True(dmg.CanBeRanged);
    }

    [Fact]
    public void DetectSecretDoors()
    {
      var actions = ActionListBuilder.New().DetectSecretDoors().Build();

      Assert.Single(actions.Actions);
      var detectDoors = (ContextActionDetectSecretDoors)actions.Actions[0];
      ElementAsserts.IsValid(detectDoors);
    }

    [Fact]
    public void DevourWithSwarm()
    {
      var actions = ActionListBuilder.New().DevourWithSwarm().Build();

      Assert.Single(actions.Actions);
      var devour = (ContextActionDevourBySwarm)actions.Actions[0];
      ElementAsserts.IsValid(devour);
    }

    [Fact]
    public void Disarm()
    {
      var actions = ActionListBuilder.New().Disarm().Build();

      Assert.Single(actions.Actions);
      var disarm = (ContextActionDisarm)actions.Actions[0];
      ElementAsserts.IsValid(disarm);
    }

    [Fact]
    public void DismissAOE()
    {
      var actions = ActionListBuilder.New().DismissAOE().Build();

      Assert.Single(actions.Actions);
      var dismissAOE = (ContextActionDismissAreaEffect)actions.Actions[0];
      ElementAsserts.IsValid(dismissAOE);
    }

    [Fact]
    public void Dismount()
    {
      var actions = ActionListBuilder.New().Dismount().Build();

      Assert.Single(actions.Actions);
      var dismount = (ContextActionDismount)actions.Actions[0];
      ElementAsserts.IsValid(dismount);
    }

    [Fact]
    public void Dispel()
    {
      var actions =
          ActionListBuilder.New()
              .Dispel(
                  ContextActionDispelMagic.BuffType.All,
                  RuleDispelMagic.CheckType.CasterLevel,
                  5)
              .Build();

      Assert.Single(actions.Actions);
      var dispel = (ContextActionDispelMagic)actions.Actions[0];
      ElementAsserts.IsValid(dispel);

      Assert.Equal(ContextActionDispelMagic.BuffType.All, dispel.m_BuffType);
      Assert.Equal(RuleDispelMagic.CheckType.CasterLevel, dispel.m_CheckType);
      Assert.Equal(StatType.Unknown, dispel.m_Skill);

      Assert.Equal(5, dispel.m_MaxSpellLevel.Value);
      Assert.False(dispel.m_UseMaxCasterLevel);

      Assert.False(dispel.OnlyTargetEnemyBuffs);
      Assert.False(dispel.m_StopAfterFirstRemoved);

      Assert.Equal(0, dispel.CheckBonus);
      Assert.Equal(0, dispel.ContextBonus.Value);

      Assert.Empty(dispel.OnSuccess.Actions);
      Assert.Empty(dispel.OnFail.Actions);

      Assert.Empty(dispel.Schools);
      Assert.Equal((long)SpellDescriptor.None, dispel.Descriptor.m_IntValue);
    }

    [Fact]
    public void Dispel_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .Dispel(
                  ContextActionDispelMagic.BuffType.FromSpells,
                  RuleDispelMagic.CheckType.SkillDC,
                  6,
                  onlyDispelEnemyBuffs: true,
                  removeOnlyOne: true,
                  bonus: 3,
                  contextBonus: 5,
                  onSuccess: ActionListBuilder.New().MeleeAttack(),
                  onFail: ActionListBuilder.New().SwitchToDemoralizeTarget(),
                  limitToSchools:
                      new SpellSchool[] { SpellSchool.Abjuration, SpellSchool.Conjuration },
                  limitToDescriptor: SpellDescriptor.Fire,
                  checkEitherSchoolOrDescriptor: true,
                  skill: StatType.CheckIntimidate,
                  maxCasterLevel: 20)
              .Build();

      Assert.Single(actions.Actions);
      var dispel = (ContextActionDispelMagic)actions.Actions[0];
      ElementAsserts.IsValid(dispel);

      Assert.Equal(ContextActionDispelMagic.BuffType.FromSpells, dispel.m_BuffType);
      Assert.Equal(RuleDispelMagic.CheckType.SkillDC, dispel.m_CheckType);
      Assert.Equal(StatType.CheckIntimidate, dispel.m_Skill);

      Assert.Equal(6, dispel.m_MaxSpellLevel.Value);
      Assert.True(dispel.m_UseMaxCasterLevel);
      Assert.Equal(20, dispel.m_MaxCasterLevel.Value);

      Assert.True(dispel.OnlyTargetEnemyBuffs);
      Assert.True(dispel.m_StopAfterFirstRemoved);

      Assert.Equal(3, dispel.CheckBonus);
      Assert.Equal(5, dispel.ContextBonus.Value);

      Assert.Single(dispel.OnSuccess.Actions);
      Assert.IsType<ContextActionMeleeAttack>(dispel.OnSuccess.Actions[0]);
      Assert.Single(dispel.OnFail.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(dispel.OnFail.Actions[0]);

      Assert.Equal(2, dispel.Schools.Length);
      Assert.Contains(SpellSchool.Abjuration, dispel.Schools);
      Assert.Contains(SpellSchool.Conjuration, dispel.Schools);
      Assert.Equal((long)SpellDescriptor.Fire, dispel.Descriptor.m_IntValue);
    }

    [Fact]
    public void DropItems()
    {
      var actions = ActionListBuilder.New().DropItems().Build();

      Assert.Single(actions.Actions);
      var dropItems = (ContextActionDropItems)actions.Actions[0];
      ElementAsserts.IsValid(dropItems);
    }

    [Fact]
    public void EnchantWornItem()
    {
      var actions =
          ActionListBuilder.New()
              .EnchantWornItem(
                  EquipmentEnchantmentGuid, EquipSlotBase.SlotType.Armor, ContextDuration.Fixed(2))
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionEnchantWornItem)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(
          EquipmentEnchantment.ToReference<BlueprintItemEnchantmentReference>(),
          enchant.m_Enchantment);
      Assert.Equal(EquipSlotBase.SlotType.Armor, enchant.Slot);
      Assert.Equal(2, enchant.DurationValue.BonusValue.Value);

      Assert.False(enchant.ToCaster);
      Assert.False(enchant.RemoveOnUnequip);
    }

    [Fact]
    public void EnchantWornItem_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .EnchantWornItem(
                  EquipmentEnchantmentGuid,
                  EquipSlotBase.SlotType.Belt,
                  ContextDuration.Fixed(3),
                  onCaster: true,
                  removeOnUnequip: true)
              .Build();

      Assert.Single(actions.Actions);
      var enchant = (ContextActionEnchantWornItem)actions.Actions[0];
      ElementAsserts.IsValid(enchant);

      Assert.Equal(
          EquipmentEnchantment.ToReference<BlueprintItemEnchantmentReference>(),
          enchant.m_Enchantment);
      Assert.Equal(EquipSlotBase.SlotType.Belt, enchant.Slot);
      Assert.Equal(3, enchant.DurationValue.BonusValue.Value);

      Assert.True(enchant.ToCaster);
      Assert.True(enchant.RemoveOnUnequip);
    }

    [Fact]
    public void FinishObjective()
    {
      var actions = ActionListBuilder.New().FinishObjective(QuestObjectiveGuid).Build();

      Assert.Single(actions.Actions);
      var finish = (ContextActionFinishObjective)actions.Actions[0];
      ElementAsserts.IsValid(finish);

      Assert.Equal(
          QuestObjective.ToReference<BlueprintQuestObjectiveReference>(), finish.m_Objective);
    }

    [Fact]
    public void OnEachSwallowedUnit()
    {
      var actions =
          ActionListBuilder.New()
              .OnEachSwallowedUnit(ActionListBuilder.New().MeleeAttack())
              .Build();

      Assert.Single(actions.Actions);
      var onUnit = (ContextActionForEachSwallowedUnit)actions.Actions[0];
      ElementAsserts.IsValid(onUnit);

      Assert.IsType<ContextActionMeleeAttack>(onUnit.Action.Actions[0]);
    }

    [Fact]
    public void GiveExperience()
    {
      var actions = ActionListBuilder.New().GiveExperience().Build();

      Assert.Single(actions.Actions);
      var giveXP = (ContextActionGiveExperience)actions.Actions[0];
      ElementAsserts.IsValid(giveXP);
    }

    [Fact]
    public void Grapple()
    {
      var actions = ActionListBuilder.New().Grapple().Build();

      Assert.Single(actions.Actions);
      var grapple = (ContextActionGrapple)actions.Actions[0];
      ElementAsserts.IsValid(grapple);

      Assert.Null(grapple.m_CasterBuff);
      Assert.Null(grapple.m_TargetBuff);
    }

    [Fact]
    public void Grapple_WithBuffs()
    {
      var actions =
          ActionListBuilder.New().Grapple(casterBuff: BuffGuid, targetBuff: ExtraBuffGuid).Build();

      Assert.Single(actions.Actions);
      var grapple = (ContextActionGrapple)actions.Actions[0];
      ElementAsserts.IsValid(grapple);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), grapple.m_CasterBuff);
      Assert.Equal(ExtraBuff.ToReference<BlueprintBuffReference>(), grapple.m_TargetBuff);
    }

    [Fact]
    public void HealNegativeLevels()
    {
      var actions = ActionListBuilder.New().HealNegativeLevels().Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionHealEnergyDrain)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(EnergyDrainHealType.None, heal.TemporaryNegativeLevelsHeal);
      Assert.Equal(EnergyDrainHealType.None, heal.PermanentNegativeLevelsHeal);
    }

    [Fact]
    public void HealNegativeLevels_WithLevels()
    {
      var actions =
          ActionListBuilder.New()
              .HealNegativeLevels(
                  tempLevels: EnergyDrainHealType.All, permanentLevels: EnergyDrainHealType.One)
              .Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionHealEnergyDrain)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(EnergyDrainHealType.All, heal.TemporaryNegativeLevelsHeal);
      Assert.Equal(EnergyDrainHealType.One, heal.PermanentNegativeLevelsHeal);
    }

    [Fact]
    public void HealStatDamage()
    {
      var actions =
          ActionListBuilder.New()
              .HealStatDamage(
                  ContextActionHealStatDamage.StatDamageHealType.HealAllDamage,
                  ContextActionHealStatDamage.StatClass.Mental)
              .Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionHealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(ContextActionHealStatDamage.StatDamageHealType.HealAllDamage, heal.m_HealType);
      Assert.Equal(ContextActionHealStatDamage.StatClass.Mental, heal.m_StatClass);
      Assert.False(heal.HealDrain);
      Assert.False(heal.WriteResultToSharedValue);
    }

    [Fact]
    public void HealStatDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .HealStatDamage(
                  ContextActionHealStatDamage.StatDamageHealType.Dice,
                  ContextActionHealStatDamage.StatClass.Physical,
                  value:
                      new ContextDiceValue
                      {
                        DiceType = DiceType.D8,
                        DiceCountValue = 1,
                        BonusValue = 2
                      },
                  healDrain: true,
                  sharedResult: AbilitySharedValue.Heal)
              .Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionHealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(ContextActionHealStatDamage.StatDamageHealType.Dice, heal.m_HealType);
      Assert.Equal(ContextActionHealStatDamage.StatClass.Physical, heal.m_StatClass);
      Assert.True(heal.HealDrain);
      Assert.True(heal.WriteResultToSharedValue);
      Assert.Equal(AbilitySharedValue.Heal, heal.ResultSharedValue);

      Assert.Equal(DiceType.D8, heal.Value.DiceType);
      Assert.Equal(1, heal.Value.DiceCountValue.Value);
      Assert.Equal(2, heal.Value.BonusValue.Value);
    }

    [Fact]
    public void HealTarget()
    {
      var actions =
          ActionListBuilder.New()
              .HealTarget(
                  new ContextDiceValue
                  {
                    DiceType = DiceType.D4,
                    DiceCountValue = 2,
                    BonusValue = 1
                  })
              .Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionHealTarget)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(DiceType.D4, heal.Value.DiceType);
      Assert.Equal(2, heal.Value.DiceCountValue.Value);
      Assert.Equal(1, heal.Value.BonusValue.Value);
    }

    [Fact]
    public void HideInPlainSight()
    {
      var actions = ActionListBuilder.New().HideInPlainSight().Build();

      Assert.Single(actions.Actions);
      var hide = (ContextActionHideInPlainSight)actions.Actions[0];
      ElementAsserts.IsValid(hide);
    }

    [Fact]
    public void Kill()
    {
      var actions = ActionListBuilder.New().Kill().Build();

      Assert.Single(actions.Actions);
      var kill = (ContextActionKill)actions.Actions[0];
      ElementAsserts.IsValid(kill);

      Assert.Equal(UnitState.DismemberType.None, kill.Dismember);
    }

    [Fact]
    public void Kill_WithDismember()
    {
      var actions = ActionListBuilder.New().Kill(UnitState.DismemberType.LimbsApart).Build();

      Assert.Single(actions.Actions);
      var kill = (ContextActionKill)actions.Actions[0];
      ElementAsserts.IsValid(kill);

      Assert.Equal(UnitState.DismemberType.LimbsApart, kill.Dismember);
    }

    [Fact]
    public void Knockdown()
    {
      var actions = ActionListBuilder.New().Knockdown().Build();

      Assert.Single(actions.Actions);
      var knockdown = (ContextActionKnockdownTarget)actions.Actions[0];
      ElementAsserts.IsValid(knockdown);
    }

    [Fact]
    public void KnowledgeCheck()
    {
      var actions = ActionListBuilder.New().KnowledgeCheck().Build();

      Assert.Single(actions.Actions);
      var knowledgeCheck = (ContextActionMakeKnowledgeCheck)actions.Actions[0];
      ElementAsserts.IsValid(knowledgeCheck);

      Assert.Empty(knowledgeCheck.SuccessActions.Actions);
      Assert.Empty(knowledgeCheck.FailActions.Actions);
    }

    [Fact]
    public void KnowledgeCheck_WithActions()
    {
      var actions =
          ActionListBuilder.New()
              .KnowledgeCheck(
                  onSuccess: ActionListBuilder.New().MeleeAttack(),
                  onFail: ActionListBuilder.New().SwitchToDemoralizeTarget())
              .Build();

      Assert.Single(actions.Actions);
      var knowledgeCheck = (ContextActionMakeKnowledgeCheck)actions.Actions[0];
      ElementAsserts.IsValid(knowledgeCheck);

      Assert.IsType<ContextActionMeleeAttack>(knowledgeCheck.SuccessActions.Actions[0]);
      Assert.IsType<SwitchToDemoralizeTarget>(knowledgeCheck.FailActions.Actions[0]);
    }

    [Fact]
    public void MarkOwnerForDismemberment()
    {
      var actions = ActionListBuilder.New().MarkOwnerForDismemberment().Build();

      Assert.Single(actions.Actions);
      var markForDismemberment = (ContextActionMarkForceDismemberOwner)actions.Actions[0];
      ElementAsserts.IsValid(markForDismemberment);

      Assert.Equal(UnitState.DismemberType.Normal, markForDismemberment.ForceDismemberType);
    }

    [Fact]
    public void MarkOwnerForDismemberment_WithType()
    {
      var actions =
          ActionListBuilder.New()
              .MarkOwnerForDismemberment(UnitState.DismemberType.InPower)
              .Build();

      Assert.Single(actions.Actions);
      var markForDismemberment = (ContextActionMarkForceDismemberOwner)actions.Actions[0];
      ElementAsserts.IsValid(markForDismemberment);

      Assert.Equal(UnitState.DismemberType.InPower, markForDismemberment.ForceDismemberType);
    }

    [Fact]
    public void MeleeAttack()
    {
      var actions = ActionListBuilder.New().MeleeAttack().Build();

      Assert.Single(actions.Actions);
      var meleeAttack = (ContextActionMeleeAttack)actions.Actions[0];
      ElementAsserts.IsValid(meleeAttack);

      Assert.False(meleeAttack.AutoCritThreat);
      Assert.False(meleeAttack.AutoCritConfirmation);
      Assert.False(meleeAttack.AutoHit);
      Assert.False(meleeAttack.IgnoreStatBonus);
      Assert.False(meleeAttack.SelectNewTarget);
    }

    [Fact]
    public void MeleeAttack_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .MeleeAttack(
                  autoCritThreat: true,
                  autoCritConfirm: true,
                  autoHit: true,
                  ignoreStatBonus: true,
                  selectNewTarget: true)
              .Build();

      Assert.Single(actions.Actions);
      var meleeAttack = (ContextActionMeleeAttack)actions.Actions[0];
      ElementAsserts.IsValid(meleeAttack);

      Assert.True(meleeAttack.AutoCritThreat);
      Assert.True(meleeAttack.AutoCritConfirmation);
      Assert.True(meleeAttack.AutoHit);
      Assert.True(meleeAttack.IgnoreStatBonus);
      Assert.True(meleeAttack.SelectNewTarget);
    }

    [Fact]
    public void Mount()
    {
      var actions = ActionListBuilder.New().Mount().Build();

      Assert.Single(actions.Actions);
      var mount = (ContextActionMount)actions.Actions[0];
      ElementAsserts.IsValid(mount);
    }

    [Fact]
    public void OnCaster()
    {
      var actions = ActionListBuilder.New().OnCaster(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var onCaster = (ContextActionOnContextCaster)actions.Actions[0];
      ElementAsserts.IsValid(onCaster);

      Assert.Single(onCaster.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onCaster.Actions.Actions[0]);
    }

    [Fact]
    public void OnOwner()
    {
      var actions = ActionListBuilder.New().OnOwner(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var onCaster = (ContextActionOnOwner)actions.Actions[0];
      ElementAsserts.IsValid(onCaster);

      Assert.Single(onCaster.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onCaster.Actions.Actions[0]);
    }

    [Fact]
    public void OnRandomEnemyInAOE()
    {
      var actions =
          ActionListBuilder.New().OnRandomEnemyInAOE(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var onEnemy = (ContextActionOnRandomAreaTarget)actions.Actions[0];
      ElementAsserts.IsValid(onEnemy);

      Assert.Single(onEnemy.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onEnemy.Actions.Actions[0]);
    }

    [Fact]
    public void OnRandomUnitNearTarget()
    {
      var actions =
          ActionListBuilder.New()
              .OnRandomUnitNearTarget(ActionListBuilder.New().MeleeAttack(), 3)
              .Build();

      Assert.Single(actions.Actions);
      var onUnit = (ContextActionOnRandomTargetsAround)actions.Actions[0];
      ElementAsserts.IsValid(onUnit);

      Assert.Single(onUnit.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onUnit.Actions.Actions[0]);
      Assert.Equal(3, onUnit.Radius.m_Value);

      Assert.Equal(1, onUnit.NumberOfTargets);
      Assert.True(onUnit.OnEnemies);
      Assert.Equal(BlueprintGuid.Empty, onUnit.m_FilterNoFact.deserializedGuid);
    }

    [Fact]
    public void OnRandomUnitNearTarget_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .OnRandomUnitNearTarget(
                  ActionListBuilder.New().MeleeAttack(),
                  5,
                  numTargets: 4,
                  targetEnemies: false,
                  ignoreFact: BuffGuid)
              .Build();

      Assert.Single(actions.Actions);
      var onUnit = (ContextActionOnRandomTargetsAround)actions.Actions[0];
      ElementAsserts.IsValid(onUnit);

      Assert.Single(onUnit.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onUnit.Actions.Actions[0]);
      Assert.Equal(5, onUnit.Radius.m_Value);

      Assert.Equal(4, onUnit.NumberOfTargets);
      Assert.False(onUnit.OnEnemies);
      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), onUnit.m_FilterNoFact);
    }

    [Fact]
    public void OnSwarmTargets()
    {
      var actions =
          ActionListBuilder.New().OnSwarmTargets(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var onTarget = (ContextActionOnSwarmTargets)actions.Actions[0];
      ElementAsserts.IsValid(onTarget);

      Assert.Single(onTarget.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onTarget.Actions.Actions[0]);
    }

    [Fact]
    public void OnPartyMembers()
    {
      var actions =
          ActionListBuilder.New().OnPartyMembers(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var onParty = (ContextActionPartyMembers)actions.Actions[0];
      ElementAsserts.IsValid(onParty);

      Assert.Single(onParty.Action.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onParty.Action.Actions[0]);
    }

    [Fact]
    public void ProjectileFx()
    {
      var actions = ActionListBuilder.New().ProjectileFx(ProjectileGuid).Build();

      Assert.Single(actions.Actions);
      var projectileFx = (ContextActionProjectileFx)actions.Actions[0];
      ElementAsserts.IsValid(projectileFx);

      Assert.Equal(
          Projectile.ToReference<BlueprintProjectileReference>(), projectileFx.m_Projectile);
    }

    [Fact]
    public void ProvokeOpportunityAttackFromCaster()
    {
      var actions = ActionListBuilder.New().ProvokeOpportunityAttackFromCaster().Build();

      Assert.Single(actions.Actions);
      var attack = (ContextActionProvokeAttackFromCaster)actions.Actions[0];
      ElementAsserts.IsValid(attack);
    }

    [Fact]
    public void ProvokeOpportunityAttack()
    {
      var actions = ActionListBuilder.New().ProvokeOpportunityAttack().Build();

      Assert.Single(actions.Actions);
      var attack = (ContextActionProvokeAttackOfOpportunity)actions.Actions[0];
      ElementAsserts.IsValid(attack);

      Assert.False(attack.ApplyToCaster);
    }

    [Fact]
    public void ProvokeOpportunityAttack_CasterProvokes()
    {
      var actions = ActionListBuilder.New().ProvokeOpportunityAttack(casterProvokes: true).Build();

      Assert.Single(actions.Actions);
      var attack = (ContextActionProvokeAttackOfOpportunity)actions.Actions[0];
      ElementAsserts.IsValid(attack);

      Assert.True(attack.ApplyToCaster);
    }

    [Fact]
    public void Push()
    {
      var actions = ActionListBuilder.New().Push(3).Build();

      Assert.Single(actions.Actions);
      var push = (ContextActionPush)actions.Actions[0];
      ElementAsserts.IsValid(push);

      Assert.Equal(3, push.Distance.Value);
      Assert.False(push.ProvokeAttackOfOpportunity);
    }

    [Fact]
    public void Push_Provokes()
    {
      var actions = ActionListBuilder.New().Push(12, provokeOpportunityAttack: true).Build();

      Assert.Single(actions.Actions);
      var push = (ContextActionPush)actions.Actions[0];
      ElementAsserts.IsValid(push);

      Assert.Equal(12, push.Distance.Value);
      Assert.True(push.ProvokeAttackOfOpportunity);
    }

    [Fact]
    public void RandomActions()
    {
      var actions =
          ActionListBuilder.New()
              .RandomActions(
                  (actions: ActionListBuilder.New().MeleeAttack(), weight: 2),
                  (actions: ActionListBuilder.New().SwitchToDemoralizeTarget(), weight: 3))
              .Build();

      Assert.Single(actions.Actions);
      var randomActions = (ContextActionRandomize)actions.Actions[0];
      ElementAsserts.IsValid(randomActions);

      Assert.Equal(2, randomActions.m_Actions.Length);
      Assert.Single(randomActions.m_Actions[0].Action.Actions);
      Assert.IsType<ContextActionMeleeAttack>(randomActions.m_Actions[0].Action.Actions[0]);
      Assert.Single(randomActions.m_Actions[1].Action.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(randomActions.m_Actions[1].Action.Actions[0]);
    }

    [Fact]
    public void RangedAttack()
    {
      var actions = ActionListBuilder.New().RangedAttack().Build();

      Assert.Single(actions.Actions);
      var meleeAttack = (ContextActionRangedAttack)actions.Actions[0];
      ElementAsserts.IsValid(meleeAttack);

      Assert.False(meleeAttack.AutoCritThreat);
      Assert.False(meleeAttack.AutoCritConfirmation);
      Assert.False(meleeAttack.AutoHit);
      Assert.False(meleeAttack.IgnoreStatBonus);
      Assert.False(meleeAttack.SelectNewTarget);
    }

    [Fact]
    public void RangedAttack_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .RangedAttack(
                  autoCritThreat: true,
                  autoCritConfirm: true,
                  autoHit: true,
                  ignoreStatBonus: true,
                  selectNewTarget: true)
              .Build();

      Assert.Single(actions.Actions);
      var meleeAttack = (ContextActionRangedAttack)actions.Actions[0];
      ElementAsserts.IsValid(meleeAttack);

      Assert.True(meleeAttack.AutoCritThreat);
      Assert.True(meleeAttack.AutoCritConfirmation);
      Assert.True(meleeAttack.AutoHit);
      Assert.True(meleeAttack.IgnoreStatBonus);
      Assert.True(meleeAttack.SelectNewTarget);
    }

    [Fact]
    public void RecoverItemCharges()
    {
      Armor.m_Ability = TestAbility.ToReference<BlueprintAbilityReference>();
      Armor.SpendCharges = true;
      Armor.Charges = 5;

      var actions = ActionListBuilder.New().RecoverItemCharges(ArmorGuid).Build();

      Assert.Single(actions.Actions);
      var recoverCharges = (ContextActionRecoverItemCharges)actions.Actions[0];
      ElementAsserts.IsValid(recoverCharges);

      Assert.Equal(Armor.ToReference<BlueprintItemEquipmentReference>(), recoverCharges.m_Item);
      Assert.Equal(1, recoverCharges.ChargesRecoverCount);
    }

    [Fact]
    public void ChangeBuffDuration()
    {
      var actions =
          ActionListBuilder.New()
              .ChangeBuffDuration(BuffGuid, ContextDuration.Fixed(7), true)
              .Build();

      Assert.Single(actions.Actions);
      var reduceDuration = (ContextActionReduceBuffDuration)actions.Actions[0];
      ElementAsserts.IsValid(reduceDuration);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), reduceDuration.m_TargetBuff);
      Assert.Equal(7, reduceDuration.DurationValue.BonusValue.Value);
      Assert.True(reduceDuration.Increase);
      Assert.False(reduceDuration.ToTarget);
    }

    [Fact]
    public void ChangeBuffDuration_OnTarget()
    {
      var actions =
          ActionListBuilder.New()
              .ChangeBuffDuration(BuffGuid, ContextDuration.Fixed(3), false, true)
              .Build();

      Assert.Single(actions.Actions);
      var reduceDuration = (ContextActionReduceBuffDuration)actions.Actions[0];
      ElementAsserts.IsValid(reduceDuration);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), reduceDuration.m_TargetBuff);
      Assert.Equal(3, reduceDuration.DurationValue.BonusValue.Value);
      Assert.False(reduceDuration.Increase);
      Assert.True(reduceDuration.ToTarget);
    }

    [Fact]
    public void RemoveBuff()
    {
      var actions = ActionListBuilder.New().RemoveBuff(BuffGuid).Build();

      Assert.Single(actions.Actions);
      var removeBuff = (ContextActionRemoveBuff)actions.Actions[0];
      ElementAsserts.IsValid(removeBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), removeBuff.m_Buff);
      Assert.False(removeBuff.RemoveRank);
      Assert.False(removeBuff.ToCaster);
    }

    [Fact]
    public void RemoveBuff_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .RemoveBuff(BuffGuid, removeRank: true, toCaster: true)
              .Build();

      Assert.Single(actions.Actions);
      var removeBuff = (ContextActionRemoveBuff)actions.Actions[0];
      ElementAsserts.IsValid(removeBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), removeBuff.m_Buff);
      Assert.True(removeBuff.RemoveRank);
      Assert.True(removeBuff.ToCaster);
    }

    [Fact]
    public void RemoveBuffsWithDescriptor()
    {
      SpellDescriptor descriptor = SpellDescriptor.Paralysis | SpellDescriptor.MindAffecting;

      var actions = ActionListBuilder.New().RemoveBuffsWithDescriptor(descriptor).Build();

      Assert.Single(actions.Actions);
      var removeBuffs = (ContextActionRemoveBuffsByDescriptor)actions.Actions[0];
      ElementAsserts.IsValid(removeBuffs);

      Assert.Equal(descriptor, removeBuffs.SpellDescriptor.Value);
      Assert.True(removeBuffs.NotSelf);
    }

    [Fact]
    public void RemoveBuffsWithDescriptor_IncludeThisBuff()
    {
      SpellDescriptor descriptor = SpellDescriptor.Paralysis;

      var actions =
          ActionListBuilder.New()
              .RemoveBuffsWithDescriptor(descriptor, includeThisBuff: true)
              .Build();

      Assert.Single(actions.Actions);
      var removeBuffs = (ContextActionRemoveBuffsByDescriptor)actions.Actions[0];
      ElementAsserts.IsValid(removeBuffs);

      Assert.Equal(descriptor, removeBuffs.SpellDescriptor.Value);
      Assert.False(removeBuffs.NotSelf);
    }

    [Fact]
    public void RemoveBuffStack()
    {
      var actions = ActionListBuilder.New().RemoveBuffStack(BuffGuid).Build();

      Assert.Single(actions.Actions);
      var removeStack = (ContextActionRemoveBuffSingleStack)actions.Actions[0];
      ElementAsserts.IsValid(removeStack);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), removeStack.m_TargetBuff);
    }

    [Fact]
    public void RemoveDeathDoor()
    {
      var actions = ActionListBuilder.New().RemoveDeathDoor().Build();

      Assert.Single(actions.Actions);
      var removeDeathDoor = (ContextActionRemoveDeathDoor)actions.Actions[0];
      ElementAsserts.IsValid(removeDeathDoor);
    }

    [Fact]
    public void RemoveSelf()
    {
      var actions = ActionListBuilder.New().RemoveSelf().Build();

      Assert.Single(actions.Actions);
      var remove = (ContextActionRemoveSelf)actions.Actions[0];
      ElementAsserts.IsValid(remove);
    }

    [Fact]
    public void RepeatActions()
    {
      var actions =
          ActionListBuilder.New()
              .RepeatActions(
                  ActionListBuilder.New().MeleeAttack(),
                  new ContextDiceValue
                  {
                    DiceType = DiceType.One,
                    DiceCountValue = 3,
                    BonusValue = 4
                  })
              .Build();

      Assert.Single(actions.Actions);
      var repeat = (ContextActionRepeatedActions)actions.Actions[0];
      ElementAsserts.IsValid(repeat);

      Assert.Single(repeat.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(repeat.Actions.Actions[0]);

      Assert.Equal(DiceType.One, repeat.Value.DiceType);
      Assert.Equal(3, repeat.Value.DiceCountValue.Value);
      Assert.Equal(4, repeat.Value.BonusValue.Value);
    }

    [Fact]
    public void RestoreSpells()
    {
      var actions =
          ActionListBuilder.New().RestoreSpells(SpellbookGuid, ExtraSpellbookGuid).Build();

      Assert.Single(actions.Actions);
      var restoreSpells = (ContextActionRestoreSpells)actions.Actions[0];
      ElementAsserts.IsValid(restoreSpells);

      Assert.Equal(2, restoreSpells.m_Spellbooks.Length);
      Assert.Equal(
          TestSpellbook.ToReference<BlueprintSpellbookReference>(), restoreSpells.m_Spellbooks[0]);
      Assert.Equal(
          ExtraSpellbook.ToReference<BlueprintSpellbookReference>(), restoreSpells.m_Spellbooks[1]);
    }

    [Fact]
    public void Resurrect()
    {
      var actions = ActionListBuilder.New().Resurrect(0.5f).Build();

      Assert.Single(actions.Actions);
      var resurrect = (ContextActionResurrect)actions.Actions[0];
      ElementAsserts.IsValid(resurrect);

      Assert.Equal(0.5f, resurrect.ResultHealth);
      Assert.False(resurrect.FullRestore);
      Assert.Equal(BlueprintGuid.Empty, resurrect.m_CustomResurrectionBuff.deserializedGuid);
    }

    [Fact]
    public void Resurrect_WithCustomBuff()
    {
      var actions = ActionListBuilder.New().Resurrect(0.5f, resurrectBuff: BuffGuid).Build();

      Assert.Single(actions.Actions);
      var resurrect = (ContextActionResurrect)actions.Actions[0];
      ElementAsserts.IsValid(resurrect);

      Assert.Equal(0.5f, resurrect.ResultHealth);
      Assert.False(resurrect.FullRestore);
      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), resurrect.m_CustomResurrectionBuff);
    }

    [Fact]
    public void ResurrectAndFullRestore()
    {
      var actions = ActionListBuilder.New().ResurrectAndFullRestore().Build();

      Assert.Single(actions.Actions);
      var resurrect = (ContextActionResurrect)actions.Actions[0];
      ElementAsserts.IsValid(resurrect);

      Assert.True(resurrect.FullRestore);
      Assert.Equal(BlueprintGuid.Empty, resurrect.m_CustomResurrectionBuff.deserializedGuid);
    }

    [Fact]
    public void ResurrectAndFullRestore_WithCustomBuff()
    {
      var actions = ActionListBuilder.New().ResurrectAndFullRestore().Build();

      Assert.Single(actions.Actions);
      var resurrect = (ContextActionResurrect)actions.Actions[0];
      ElementAsserts.IsValid(resurrect);

      Assert.True(resurrect.FullRestore);
      Assert.Equal(BlueprintGuid.Empty, resurrect.m_CustomResurrectionBuff.deserializedGuid);
    }

    [Fact]
    public void SavingThrow()
    {
      var actions =
          ActionListBuilder.New()
              .SavingThrow(SavingThrowType.Reflex, ActionListBuilder.New().MeleeAttack())
              .Build();

      Assert.Single(actions.Actions);
      var savingThrow = (ContextActionSavingThrow)actions.Actions[0];
      ElementAsserts.IsValid(savingThrow);

      Assert.Equal(SavingThrowType.Reflex, savingThrow.Type);
      Assert.Single(savingThrow.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(savingThrow.Actions.Actions[0]);

      Assert.False(savingThrow.FromBuff);
      Assert.False(savingThrow.HasCustomDC);
      Assert.Empty(savingThrow.m_ConditionalDCIncrease);
    }

    [Fact]
    public void SavingThrow_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .SavingThrow(
                  SavingThrowType.Will,
                  ActionListBuilder.New().MeleeAttack(),
                  customDC: 15,
                  fromBuff: true,
                  (conditions: ConditionsCheckerBuilder.New().IsDemoralizeAction(), 3),
                  (conditions: ConditionsCheckerBuilder.New().TargetInMeleeRange(), 4))
              .Build();

      Assert.Single(actions.Actions);
      var savingThrow = (ContextActionSavingThrow)actions.Actions[0];
      ElementAsserts.IsValid(savingThrow);

      Assert.Equal(SavingThrowType.Will, savingThrow.Type);
      Assert.Single(savingThrow.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(savingThrow.Actions.Actions[0]);

      Assert.True(savingThrow.FromBuff);

      Assert.True(savingThrow.HasCustomDC);
      Assert.Equal(15, savingThrow.CustomDC.Value);

      Assert.Equal(2, savingThrow.m_ConditionalDCIncrease.Length);
      Assert.Single(savingThrow.m_ConditionalDCIncrease[0].Condition.Conditions);
      Assert.IsType<IsDemoralizeAction>(
          savingThrow.m_ConditionalDCIncrease[0].Condition.Conditions[0]);
      Assert.Equal(3, savingThrow.m_ConditionalDCIncrease[0].Value.Value);

      Assert.Single(savingThrow.m_ConditionalDCIncrease[1].Condition.Conditions);
      Assert.IsType<TargetInMeleeRange>(
          savingThrow.m_ConditionalDCIncrease[1].Condition.Conditions[0]);
      Assert.Equal(4, savingThrow.m_ConditionalDCIncrease[1].Value.Value);
    }

    [Fact]
    public void RunActionWithGreatestValue()
    {
      var actions =
          ActionListBuilder.New()
              .RunActionWithGreatestValue(
                  (value: 5, ActionListBuilder.New().MeleeAttack()),
                  (value: 10, ActionListBuilder.New().SwitchToDemoralizeTarget()))
              .Build();

      Assert.Single(actions.Actions);
      var run = (ContextActionSelectByValue)actions.Actions[0];
      ElementAsserts.IsValid(run);

      Assert.Equal(ContextActionSelectByValue.SelectionType.Greatest, run.m_Type);
      Assert.Equal(2, run.m_Variants.Length);

      Assert.Equal(5, run.m_Variants[0].Value.Value);
      Assert.Single(run.m_Variants[0].Action.Actions);
      Assert.IsType<ContextActionMeleeAttack>(run.m_Variants[0].Action.Actions[0]);

      Assert.Equal(10, run.m_Variants[1].Value.Value);
      Assert.Single(run.m_Variants[1].Action.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(run.m_Variants[1].Action.Actions[0]);
    }

    [Fact]
    public void SkillCheck()
    {
      var actions = ActionListBuilder.New().SkillCheck(StatType.CheckBluff).Build();

      Assert.Single(actions.Actions);
      var skillCheck = (ContextActionSkillCheck)actions.Actions[0];
      ElementAsserts.IsValid(skillCheck);

      Assert.Equal(StatType.CheckBluff, skillCheck.Stat);
      Assert.False(skillCheck.UseCustomDC);

      Assert.Empty(skillCheck.Success.Actions);
      Assert.Empty(skillCheck.Failure.Actions);

      Assert.False(skillCheck.CalculateDCDifference);
      Assert.Empty(skillCheck.FailureDiffMoreOrEqual5Less10.Actions);
      Assert.Empty(skillCheck.FailureDiffMoreOrEqual10.Actions);

      Assert.Empty(skillCheck.m_ConditionalDCIncrease);
    }

    [Fact]
    public void SkillCheck_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .SkillCheck(
                  StatType.CheckDiplomacy,
                  customDC: 20,
                  onSuccess: ActionListBuilder.New().MeleeAttack(),
                  onFail: ActionListBuilder.New().SwitchToDemoralizeTarget(),
                  (condition: ConditionsCheckerBuilder.New().IsDemoralizeAction(), value: 5),
                  (condition: ConditionsCheckerBuilder.New().TargetInMeleeRange(), value: 3))
              .Build();

      Assert.Single(actions.Actions);
      var skillCheck = (ContextActionSkillCheck)actions.Actions[0];
      ElementAsserts.IsValid(skillCheck);

      Assert.Equal(StatType.CheckDiplomacy, skillCheck.Stat);

      Assert.True(skillCheck.UseCustomDC);
      Assert.Equal(20, skillCheck.CustomDC.Value);

      Assert.Single(skillCheck.Success.Actions);
      Assert.IsType<ContextActionMeleeAttack>(skillCheck.Success.Actions[0]);
      Assert.Single(skillCheck.Failure.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(skillCheck.Failure.Actions[0]);

      Assert.False(skillCheck.CalculateDCDifference);
      Assert.Empty(skillCheck.FailureDiffMoreOrEqual5Less10.Actions);
      Assert.Empty(skillCheck.FailureDiffMoreOrEqual10.Actions);

      Assert.Equal(2, skillCheck.m_ConditionalDCIncrease.Length);
      Assert.Single(skillCheck.m_ConditionalDCIncrease[0].Condition.Conditions);
      Assert.IsType<IsDemoralizeAction>(
          skillCheck.m_ConditionalDCIncrease[0].Condition.Conditions[0]);
      Assert.Equal(5, skillCheck.m_ConditionalDCIncrease[0].Value.Value);

      Assert.Single(skillCheck.m_ConditionalDCIncrease[1].Condition.Conditions);
      Assert.IsType<TargetInMeleeRange>(
          skillCheck.m_ConditionalDCIncrease[1].Condition.Conditions[0]);
      Assert.Equal(3, skillCheck.m_ConditionalDCIncrease[1].Value.Value);
    }

    [Fact]
    public void SkillCheckWithFailureDegrees()
    {
      var actions =
          ActionListBuilder.New().SkillCheckWithFailureDegrees(StatType.CheckBluff).Build();

      Assert.Single(actions.Actions);
      var skillCheck = (ContextActionSkillCheck)actions.Actions[0];
      ElementAsserts.IsValid(skillCheck);

      Assert.Equal(StatType.CheckBluff, skillCheck.Stat);
      Assert.False(skillCheck.UseCustomDC);

      Assert.Empty(skillCheck.Success.Actions);
      Assert.Empty(skillCheck.Failure.Actions);

      Assert.True(skillCheck.CalculateDCDifference);
      Assert.Empty(skillCheck.FailureDiffMoreOrEqual5Less10.Actions);
      Assert.Empty(skillCheck.FailureDiffMoreOrEqual10.Actions);

      Assert.Empty(skillCheck.m_ConditionalDCIncrease);
    }

    [Fact]
    public void SkillCheckWithFailureDegrees_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .SkillCheckWithFailureDegrees(
                  StatType.CheckDiplomacy,
                  customDC: 20,
                  onSuccess: ActionListBuilder.New().MeleeAttack(),
                  onFailBy5to10: ActionListBuilder.New().SwitchToDemoralizeTarget(),
                  onFailBy10orMore: ActionListBuilder.New().Mount(),
                  (condition: ConditionsCheckerBuilder.New().IsDemoralizeAction(), value: 5),
                  (condition: ConditionsCheckerBuilder.New().TargetInMeleeRange(), value: 3))
              .Build();

      Assert.Single(actions.Actions);
      var skillCheck = (ContextActionSkillCheck)actions.Actions[0];
      ElementAsserts.IsValid(skillCheck);

      Assert.Equal(StatType.CheckDiplomacy, skillCheck.Stat);

      Assert.True(skillCheck.UseCustomDC);
      Assert.Equal(20, skillCheck.CustomDC.Value);

      Assert.Single(skillCheck.Success.Actions);
      Assert.IsType<ContextActionMeleeAttack>(skillCheck.Success.Actions[0]);
      Assert.Empty(skillCheck.Failure.Actions);

      Assert.True(skillCheck.CalculateDCDifference);
      Assert.Single(skillCheck.FailureDiffMoreOrEqual5Less10.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(skillCheck.FailureDiffMoreOrEqual5Less10.Actions[0]);

      Assert.Single(skillCheck.FailureDiffMoreOrEqual5Less10.Actions);
      Assert.IsType<ContextActionMount>(skillCheck.FailureDiffMoreOrEqual10.Actions[0]);

      Assert.Equal(2, skillCheck.m_ConditionalDCIncrease.Length);
      Assert.Single(skillCheck.m_ConditionalDCIncrease[0].Condition.Conditions);
      Assert.IsType<IsDemoralizeAction>(
          skillCheck.m_ConditionalDCIncrease[0].Condition.Conditions[0]);
      Assert.Equal(5, skillCheck.m_ConditionalDCIncrease[0].Value.Value);

      Assert.Single(skillCheck.m_ConditionalDCIncrease[1].Condition.Conditions);
      Assert.IsType<TargetInMeleeRange>(
          skillCheck.m_ConditionalDCIncrease[1].Condition.Conditions[0]);
      Assert.Equal(3, skillCheck.m_ConditionalDCIncrease[1].Value.Value);
    }

    [Fact]
    public void OnPets()
    {
      var actions = ActionListBuilder.New().OnPets(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var onPets = (ContextActionsOnPet)actions.Actions[0];
      ElementAsserts.IsValid(onPets);

      Assert.Single(onPets.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onPets.Actions.Actions[0]);

      Assert.Equal(PetType.AnimalCompanion, onPets.PetType);
      Assert.False(onPets.AllPets);
    }

    [Fact]
    public void OnPets_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .OnPets(
                  ActionListBuilder.New().MeleeAttack(),
                  anyPetType: true,
                  type: PetType.MythicSkeletalChampion)
              .Build();

      Assert.Single(actions.Actions);
      var onPets = (ContextActionsOnPet)actions.Actions[0];
      ElementAsserts.IsValid(onPets);

      Assert.Single(onPets.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onPets.Actions.Actions[0]);

      Assert.Equal(PetType.MythicSkeletalChampion, onPets.PetType);
      Assert.True(onPets.AllPets);
    }

    [Fact]
    public void SpawnAOE()
    {
      var actions =
          ActionListBuilder.New().SpawnAOE(AbilityAOEGuid, ContextDuration.Fixed(2)).Build();

      Assert.Single(actions.Actions);
      var spawnAOE = (ContextActionSpawnAreaEffect)actions.Actions[0];
      ElementAsserts.IsValid(spawnAOE);

      Assert.Equal(
          AbilityAOE.ToReference<BlueprintAbilityAreaEffectReference>(), spawnAOE.m_AreaEffect);
      Assert.Equal(2, spawnAOE.DurationValue.BonusValue.Value);
    }

    [Fact]
    public void SpawnControllableProjectile()
    {
      var actions =
          ActionListBuilder.New()
              .SpawnControllableProjectile(ControllableProjectileGuid, BuffGuid)
              .Build();

      Assert.Single(actions.Actions);
      var spawnProjectile = (ContextActionSpawnControllableProjectile)actions.Actions[0];
      ElementAsserts.IsValid(spawnProjectile);

      Assert.Equal(
          TestControllableProjectile.ToReference<BlueprintControllableProjectileReference>(),
          spawnProjectile.ControllableProjectile);
      Assert.Equal(
          Buff.ToReference<BlueprintBuffReference>(), spawnProjectile.AssociatedCasterBuff);
    }

    [Fact]
    public void SpawnMonster()
    {
      Unit.m_Faction = Faction.ToReference<BlueprintFactionReference>();

      var actions =
          ActionListBuilder.New()
              .SpawnMonster(
                  UnitGuid,
                  new ContextDiceValue { DiceType = DiceType.One, DiceCountValue = 7 },
                  ContextDuration.Fixed(6))
              .Build();

      Assert.Single(actions.Actions);
      var spawn = (ContextActionSpawnMonster)actions.Actions[0];
      ElementAsserts.IsValid(spawn);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), spawn.m_Blueprint);
      Assert.Null(spawn.m_SummonPool);

      Assert.Equal(DiceType.One, spawn.CountValue.DiceType);
      Assert.Equal(7, spawn.CountValue.DiceCountValue.Value);
      Assert.Equal(6, spawn.DurationValue.BonusValue.Value);
      Assert.Equal(0, spawn.LevelValue.Value);

      Assert.Empty(spawn.AfterSpawn.Actions);

      Assert.False(spawn.DoNotLinkToCaster);
      Assert.False(spawn.IsDirectlyControllable);
    }

    [Fact]
    public void SpawnMonster_WithOptionalValues()
    {
      Unit.m_Faction = Faction.ToReference<BlueprintFactionReference>();

      var actions =
          ActionListBuilder.New()
              .SpawnMonster(
                  UnitGuid,
                  new ContextDiceValue { DiceType = DiceType.One, DiceCountValue = 7 },
                  ContextDuration.Fixed(6),
                  onSpawn: ActionListBuilder.New().MeleeAttack(),
                  level: 6,
                  controllable: true,
                  linkToCaster: false)
              .Build();

      Assert.Single(actions.Actions);
      var spawn = (ContextActionSpawnMonster)actions.Actions[0];
      ElementAsserts.IsValid(spawn);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), spawn.m_Blueprint);
      Assert.Null(spawn.m_SummonPool);

      Assert.Equal(DiceType.One, spawn.CountValue.DiceType);
      Assert.Equal(7, spawn.CountValue.DiceCountValue.Value);
      Assert.Equal(6, spawn.DurationValue.BonusValue.Value);
      Assert.Equal(6, spawn.LevelValue.Value);

      Assert.Single(spawn.AfterSpawn.Actions);
      Assert.IsType<ContextActionMeleeAttack>(spawn.AfterSpawn.Actions[0]);

      Assert.True(spawn.DoNotLinkToCaster);
      Assert.True(spawn.IsDirectlyControllable);
    }

    [Fact]
    public void SpawnMonsterUsingSummonPool()
    {
      Unit.m_Faction = Faction.ToReference<BlueprintFactionReference>();

      var actions =
          ActionListBuilder.New()
              .SpawnMonsterUsingSummonPool(
                  UnitGuid,
                  SummonPoolGuid,
                  new ContextDiceValue { DiceType = DiceType.One, DiceCountValue = 2 },
                  ContextDuration.Fixed(3))
              .Build();

      Assert.Single(actions.Actions);
      var spawn = (ContextActionSpawnMonster)actions.Actions[0];
      ElementAsserts.IsValid(spawn);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), spawn.m_Blueprint);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), spawn.m_SummonPool);

      Assert.Equal(DiceType.One, spawn.CountValue.DiceType);
      Assert.Equal(2, spawn.CountValue.DiceCountValue.Value);
      Assert.Equal(3, spawn.DurationValue.BonusValue.Value);
      Assert.Equal(0, spawn.LevelValue.Value);

      Assert.Empty(spawn.AfterSpawn.Actions);

      Assert.False(spawn.UseLimitFromSummonPool);
      Assert.False(spawn.DoNotLinkToCaster);
      Assert.False(spawn.IsDirectlyControllable);
    }

    [Fact]
    public void SpawnMonsterUsingSummonPool_WithOptionalValues()
    {
      Unit.m_Faction = Faction.ToReference<BlueprintFactionReference>();

      var actions =
          ActionListBuilder.New()
              .SpawnMonsterUsingSummonPool(
                  UnitGuid,
                  SummonPoolGuid,
                  new ContextDiceValue { DiceType = DiceType.One, DiceCountValue = 4 },
                  ContextDuration.Fixed(6),
                  useSummonPoolLimit: true,
                  onSpawn: ActionListBuilder.New().MeleeAttack(),
                  level: 1,
                  controllable: true,
                  linkToCaster: false)
              .Build();

      Assert.Single(actions.Actions);
      var spawn = (ContextActionSpawnMonster)actions.Actions[0];
      ElementAsserts.IsValid(spawn);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), spawn.m_Blueprint);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), spawn.m_SummonPool);

      Assert.Equal(DiceType.One, spawn.CountValue.DiceType);
      Assert.Equal(4, spawn.CountValue.DiceCountValue.Value);
      Assert.Equal(6, spawn.DurationValue.BonusValue.Value);
      Assert.Equal(1, spawn.LevelValue.Value);

      Assert.Single(spawn.AfterSpawn.Actions);
      Assert.IsType<ContextActionMeleeAttack>(spawn.AfterSpawn.Actions[0]);

      Assert.True(spawn.UseLimitFromSummonPool);
      Assert.True(spawn.DoNotLinkToCaster);
      Assert.True(spawn.IsDirectlyControllable);
    }

    [Fact]
    public void SpawnMonsterUnlinked()
    {
      var actions = ActionListBuilder.New().SpawnMonsterUnlinked(UnitGuid).Build();

      Assert.Single(actions.Actions);
      var spawn = (ContextActionSpawnUnlinkedMonster)actions.Actions[0];
      ElementAsserts.IsValid(spawn);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), spawn.m_Blueprint);
    }

    [Fact]
    public void SpendOpportunityAttack()
    {
      var actions = ActionListBuilder.New().SpendOpportunityAttack().Build();

      Assert.Single(actions.Actions);
      var spend = (ContextActionSpendAttackOfOpportunity)actions.Actions[0];
      ElementAsserts.IsValid(spend);
    }

    [Fact]
    public void StealBuffs()
    {
      var actions = ActionListBuilder.New().StealBuffs(SpellDescriptor.Chaos).Build();

      Assert.Single(actions.Actions);
      var steal = (ContextActionStealBuffs)actions.Actions[0];
      ElementAsserts.IsValid(steal);

      Assert.Equal((long)SpellDescriptor.Chaos, steal.m_Descriptor.m_IntValue);
    }

    [Fact]
    public void SwallowWhole()
    {
      var actions = ActionListBuilder.New().SwallowWhole().Build();

      Assert.Single(actions.Actions);
      var swallow = (ContextActionSwallowWhole)actions.Actions[0];
      ElementAsserts.IsValid(swallow);

      Assert.Null(swallow.m_TargetBuff);
    }

    [Fact]
    public void SwallowWhole_WithBuff()
    {
      var actions = ActionListBuilder.New().SwallowWhole(BuffGuid).Build();

      Assert.Single(actions.Actions);
      var swallow = (ContextActionSwallowWhole)actions.Actions[0];
      ElementAsserts.IsValid(swallow);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), swallow.m_TargetBuff);
    }

    [Fact]
    public void AddToSwarmTargets()
    {
      var actions = ActionListBuilder.New().AddToSwarmTargets().Build();

      Assert.Single(actions.Actions);
      var addTarget = (ContextActionSwarmTarget)actions.Actions[0];
      ElementAsserts.IsValid(addTarget);

      Assert.False(addTarget.Remove);
    }

    [Fact]
    public void RemoveFromSwarmTargets()
    {
      var actions = ActionListBuilder.New().RemoveFromSwarmTargets().Build();

      Assert.Single(actions.Actions);
      var removeTarget = (ContextActionSwarmTarget)actions.Actions[0];
      ElementAsserts.IsValid(removeTarget);

      Assert.True(removeTarget.Remove);
    }

    [Fact]
    public void Teleport()
    {
      var actions = ActionListBuilder.New().Teleport().Build();

      Assert.Single(actions.Actions);
      var teleport = (ContextActionTranslocate)actions.Actions[0];
      ElementAsserts.IsValid(teleport);
    }

    [Fact]
    public void Unsummon()
    {
      var actions = ActionListBuilder.New().Unsummon().Build();

      Assert.Single(actions.Actions);
      var unsummon = (ContextActionUnsummon)actions.Actions[0];
      ElementAsserts.IsValid(unsummon);
    }

    [Fact]
    public void RestoreResource()
    {
      var actions = ActionListBuilder.New().RestoreResource(AbilityResourceGuid).Build();

      Assert.Single(actions.Actions);
      var restore = (ContextRestoreResource)actions.Actions[0];
      ElementAsserts.IsValid(restore);

      Assert.False(restore.m_IsFullRestoreAllResources);
      Assert.Equal(
          AbilityResource.ToReference<BlueprintAbilityResourceReference>(), restore.m_Resource);

      Assert.False(restore.ContextValueRestoration);
    }

    [Fact]
    public void RestoreResource_WithAmount()
    {
      var actions = ActionListBuilder.New().RestoreResource(AbilityResourceGuid, 12).Build();

      Assert.Single(actions.Actions);
      var restore = (ContextRestoreResource)actions.Actions[0];
      ElementAsserts.IsValid(restore);

      Assert.False(restore.m_IsFullRestoreAllResources);
      Assert.Equal(
          AbilityResource.ToReference<BlueprintAbilityResourceReference>(), restore.m_Resource);

      Assert.True(restore.ContextValueRestoration);
      Assert.Equal(12, restore.Value.Value);
    }

    [Fact]
    public void RestoreAllResourcesToFull()
    {
      var actions = ActionListBuilder.New().RestoreAllResourcesToFull().Build();

      Assert.Single(actions.Actions);
      var restore = (ContextRestoreResource)actions.Actions[0];
      ElementAsserts.IsValid(restore);

      Assert.True(restore.m_IsFullRestoreAllResources);
    }

    [Fact]
    public void SpendResource()
    {
      var actions = ActionListBuilder.New().SpendResource(AbilityResourceGuid).Build();

      Assert.Single(actions.Actions);
      var spend = (ContextSpendResource)actions.Actions[0];
      ElementAsserts.IsValid(spend);

      Assert.Equal(
          AbilityResource.ToReference<BlueprintAbilityResourceReference>(), spend.m_Resource);

      Assert.False(spend.ContextValueSpendure);
    }

    [Fact]
    public void SpendResource_WithAmount()
    {
      var actions = ActionListBuilder.New().SpendResource(AbilityResourceGuid, 10).Build();

      Assert.Single(actions.Actions);
      var spend = (ContextSpendResource)actions.Actions[0];
      ElementAsserts.IsValid(spend);

      Assert.Equal(
          AbilityResource.ToReference<BlueprintAbilityResourceReference>(), spend.m_Resource);

      Assert.True(spend.ContextValueSpendure);
      Assert.Equal(10, spend.Value.Value);
    }

    // Default GUIDs for Demoralize buffs
    private const string Shaken = "25ec6cb6ab1845c48a95f9c20b034220";
    private const string Frightened = "f08a7239aa961f34c8301518e71d4cdf";
    private const string DisplayWeaponProwess = "ac8d4d2e375a8c841a19ed46696e5af2";
    private const string ShatterConfidenceFeature = "14225a2e4561bfd46874c9a4a97e7133";
    private const string ShatterConfidenceBuff = "51f5a63f1a0cb9047acdad77fc437312";

    private static void SetupDemoralize()
    {
      BlueprintPatch.Add(
          Util.Create<BlueprintBuff>(Shaken),
          Util.Create<BlueprintBuff>(Frightened),
          Util.Create<BlueprintFeature>(DisplayWeaponProwess),
          Util.Create<BlueprintFeature>(ShatterConfidenceFeature),
          Util.Create<BlueprintBuff>(ShatterConfidenceBuff));
    }

    [Fact]
    public void Demoralize()
    {
      SetupDemoralize();

      var actions = ActionListBuilder.New().Demoralize().Build();

      Assert.Single(actions.Actions);
      var demoralize = (Demoralize)actions.Actions[0];
      ElementAsserts.IsValid(demoralize);

      Assert.Equal(0, demoralize.Bonus);
      Assert.False(demoralize.DazzlingDisplay);

      Assert.Equal(Shaken, demoralize.m_Buff.deserializedGuid.ToString());
      Assert.Equal(Frightened, demoralize.m_GreaterBuff.deserializedGuid.ToString());
      Assert.Equal(
          DisplayWeaponProwess, demoralize.m_SwordlordProwessFeature.deserializedGuid.ToString());
      Assert.Equal(
          ShatterConfidenceFeature,
          demoralize.m_ShatterConfidenceFeature.deserializedGuid.ToString());
      Assert.Equal(
          ShatterConfidenceBuff, demoralize.m_ShatterConfidenceBuff.deserializedGuid.ToString());

      Assert.Empty(demoralize.TricksterRank3Actions.Actions);
    }

    [Fact]
    public void Demoralize_WithOptionalValues()
    {
      SetupDemoralize();

      var actions =
          ActionListBuilder.New()
              .Demoralize(
                  bonus: 3,
                  dazzlingDisplay: true,
                  effect: ShatterConfidenceBuff,
                  greaterEffect: Shaken,
                  swordlordProwess: ShatterConfidenceFeature,
                  shatterConfidenceFeature: DisplayWeaponProwess,
                  shatterConfidenceBuff: Frightened,
                  tricksterRank3Actions: ActionListBuilder.New().MeleeAttack())
              .Build();

      Assert.Single(actions.Actions);
      var demoralize = (Demoralize)actions.Actions[0];
      ElementAsserts.IsValid(demoralize);

      Assert.Equal(3, demoralize.Bonus);
      Assert.True(demoralize.DazzlingDisplay);

      Assert.Equal(ShatterConfidenceBuff, demoralize.m_Buff.deserializedGuid.ToString());
      Assert.Equal(Shaken, demoralize.m_GreaterBuff.deserializedGuid.ToString());
      Assert.Equal(
          ShatterConfidenceFeature,
          demoralize.m_SwordlordProwessFeature.deserializedGuid.ToString());
      Assert.Equal(
          DisplayWeaponProwess, demoralize.m_ShatterConfidenceFeature.deserializedGuid.ToString());
      Assert.Equal(
          Frightened, demoralize.m_ShatterConfidenceBuff.deserializedGuid.ToString());

      Assert.Single(demoralize.TricksterRank3Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(demoralize.TricksterRank3Actions.Actions[0]);
    }

    [Fact]
    public void MagicWeapon()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .MagicWeapon(
                  new string[] { PlusOneWeapon, PlusTwoWeapon },
                  ContextDuration.Fixed(3),
                  4)
              .Build();

      Assert.Single(actions.Actions);
      var enhance = (EnhanceWeapon)actions.Actions[0];
      ElementAsserts.IsValid(enhance);

      Assert.Equal(EnhanceWeapon.EnchantmentApplyType.MagicWeapon, enhance.EnchantmentType);

      Assert.Equal(2, enhance.m_Enchantment.Length);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusOneWeapon);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusTwoWeapon);

      Assert.Equal(3, enhance.DurationValue.BonusValue.Value);
      Assert.Equal(4, enhance.EnchantLevel.Value);

      Assert.False(enhance.Greater);
      Assert.False(enhance.UseSecondaryHand);
    }

    [Fact]
    public void MagicWeapon_WithOptionalValues()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .MagicWeapon(
                  new string[] { PlusOneWeapon, PlusTwoWeapon },
                  ContextDuration.Fixed(4),
                  3,
                  greater: true,
                  useSecondaryHand: true)
              .Build();

      Assert.Single(actions.Actions);
      var enhance = (EnhanceWeapon)actions.Actions[0];
      ElementAsserts.IsValid(enhance);

      Assert.Equal(EnhanceWeapon.EnchantmentApplyType.MagicWeapon, enhance.EnchantmentType);

      Assert.Equal(2, enhance.m_Enchantment.Length);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusOneWeapon);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusTwoWeapon);

      Assert.Equal(4, enhance.DurationValue.BonusValue.Value);
      Assert.Equal(3, enhance.EnchantLevel.Value);

      Assert.True(enhance.Greater);
      Assert.True(enhance.UseSecondaryHand);
    }

    [Fact]
    public void MagicFang()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .MagicFang(
                  new string[] { PlusOneWeapon, PlusTwoWeapon },
                  ContextDuration.Fixed(3),
                  4)
              .Build();

      Assert.Single(actions.Actions);
      var enhance = (EnhanceWeapon)actions.Actions[0];
      ElementAsserts.IsValid(enhance);

      Assert.Equal(EnhanceWeapon.EnchantmentApplyType.MagicFang, enhance.EnchantmentType);

      Assert.Equal(2, enhance.m_Enchantment.Length);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusOneWeapon);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusTwoWeapon);

      Assert.Equal(3, enhance.DurationValue.BonusValue.Value);
      Assert.Equal(4, enhance.EnchantLevel.Value);

      Assert.False(enhance.Greater);
    }

    [Fact]
    public void MagicFang_WithOptionalValues()
    {
      SetupWeaponEnchantPool();

      var actions =
          ActionListBuilder.New()
              .MagicFang(
                  new string[] { PlusOneWeapon, PlusTwoWeapon },
                  ContextDuration.Fixed(5),
                  2,
                  greater: true)
              .Build();

      Assert.Single(actions.Actions);
      var enhance = (EnhanceWeapon)actions.Actions[0];
      ElementAsserts.IsValid(enhance);

      Assert.Equal(EnhanceWeapon.EnchantmentApplyType.MagicFang, enhance.EnchantmentType);

      Assert.Equal(2, enhance.m_Enchantment.Length);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusOneWeapon);
      Assert.Contains(
          enhance.m_Enchantment,
          enhancement => enhancement.deserializedGuid == PlusTwoWeapon);

      Assert.Equal(5, enhance.DurationValue.BonusValue.Value);
      Assert.Equal(2, enhance.EnchantLevel.Value);

      Assert.True(enhance.Greater);
    }

    [Fact]
    public void SwordlordAdaptiveTacticsAdd()
    {
      var actions = ActionListBuilder.New().SwordlordAdaptiveTacticsAdd(BuffGuid).Build();

      Assert.Single(actions.Actions);
      var add = (SwordlordAdaptiveTacticsAdd)actions.Actions[0];
      ElementAsserts.IsValid(add);

      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), add.m_Source);
    }

    [Fact]
    public void SwordlordAdaptiveTacticsClear()
    {
      var actions = ActionListBuilder.New().SwordlordAdaptiveTacticsClear().Build();

      Assert.Single(actions.Actions);
      var clear = (SwordlordAdaptiveTacticsClear)actions.Actions[0];
      ElementAsserts.IsValid(clear);
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    [Fact]
    public void ResetAlignment()
    {
      var actions = ActionListBuilder.New().ResetAlignment().Build();

      Assert.Single(actions.Actions);
      var resetAlignment = (ContextActionResetAlignment)actions.Actions[0];
      ElementAsserts.IsValid(resetAlignment);

      Assert.False(resetAlignment.m_ResetAlignmentLock);
    }

    [Fact]
    public void ResetAlignment_RemoveMythicLock()
    {
      var actions = ActionListBuilder.New().ResetAlignment(true).Build();

      Assert.Single(actions.Actions);
      var resetAlignment = (ContextActionResetAlignment)actions.Actions[0];
      ElementAsserts.IsValid(resetAlignment);

      Assert.True(resetAlignment.m_ResetAlignmentLock);
    }

    [Fact]
    public void SwarmAttack()
    {
      var actions =
          ActionListBuilder.New().SwarmAttack(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var attack = (ContextActionSwarmAttack)actions.Actions[0];
      ElementAsserts.IsValid(attack);

      Assert.Single(attack.AttackActions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(attack.AttackActions.Actions[0]);
    }

    [Fact]
    public void SwitchDualCompanion()
    {
      var actions = ActionListBuilder.New().SwitchDualCompanion().Build();

      Assert.Single(actions.Actions);
      var switchCompanion = (ContextActionSwitchDualCompanion)actions.Actions[0];
      ElementAsserts.IsValid(switchCompanion);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void GiveRandomTrashToPlayer()
    {
      var actions =
          ActionListBuilder.New().GiveRandomTrashToPlayer(TrashLootType.Scrolls, 2).Build();

      Assert.Single(actions.Actions);
      var giveTrash = (ContextActionAddRandomTrashItem)actions.Actions[0];
      ElementAsserts.IsValid(giveTrash);

      Assert.Equal(TrashLootType.Scrolls, giveTrash.m_LootType);
      Assert.Equal(2, giveTrash.m_MaxCost);
      Assert.False(giveTrash.m_Identify);
      Assert.False(giveTrash.m_Silent);
    }

    [Fact]
    public void GiveRandomTrashToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveRandomTrashToPlayer(TrashLootType.Scrolls, 3, identify: true, silent: true)
              .Build();

      Assert.Single(actions.Actions);
      var giveTrash = (ContextActionAddRandomTrashItem)actions.Actions[0];
      ElementAsserts.IsValid(giveTrash);

      Assert.Equal(TrashLootType.Scrolls, giveTrash.m_LootType);
      Assert.Equal(3, giveTrash.m_MaxCost);
      Assert.True(giveTrash.m_Identify);
      Assert.True(giveTrash.m_Silent);
    }
  }
}
