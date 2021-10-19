# ActionListBuilderContextEx class

Extension to [`ActionListBuilder`](../BlueprintCore.Actions.Builder/ActionListBuilder.md) for most ContextAction types. Some ContextAction types are in more specific extensions such as [`AVEx`](../BlueprintCore.Actions.Builder.AVEx/ActionListBuilderAVEx.md) or [`KingdomEx`](../BlueprintCore.Actions.Builder.KingdomEx/ActionListBuilderKingdomEx.md).

```csharp
public static class ActionListBuilderContextEx
```

## Public Members

| name | description |
| --- | --- |
| static [AddFeature](ActionListBuilderContextEx/AddFeature.md)(…) | Adds ContextActionAddFeature |
| static [AddLocustClone](ActionListBuilderContextEx/AddLocustClone.md)(…) | Adds ContextActionAddLocustClone |
| static [AddToSharedValue](ActionListBuilderContextEx/AddToSharedValue.md)(…) |  |
| static [AddToSwarmTargets](ActionListBuilderContextEx/AddToSwarmTargets.md)(…) | Adds ContextActionSwarmTarget |
| static [AeonRollbackState](ActionListBuilderContextEx/AeonRollbackState.md)(…) | Adds ContextActionAeonRollbackToSavedState |
| static [AfterSavingThrow](ActionListBuilderContextEx/AfterSavingThrow.md)(…) | Adds ContextActionConditionalSaved |
| static [ApplyBuff](ActionListBuilderContextEx/ApplyBuff.md)(…) | Adds ContextActionApplyBuff |
| static [ArmorEnchantPool](ActionListBuilderContextEx/ArmorEnchantPool.md)(…) | Adds ContextActionArmorEnchantPool |
| static [AttackWithWeapon](ActionListBuilderContextEx/AttackWithWeapon.md)(…) | Adds ContextActionAttackWithWeapon |
| static [BatteringBlast](ActionListBuilderContextEx/BatteringBlast.md)(…) | Adds ContextActionBatteringBlast |
| static [BreakFree](ActionListBuilderContextEx/BreakFree.md)(…) | Adds ContextActionBreakFree |
| static [BreathOfLife](ActionListBuilderContextEx/BreathOfLife.md)(…) | Adds ContextActionBreathOfLife |
| static [BreathOfMoney](ActionListBuilderContextEx/BreathOfMoney.md)(…) | Adds ContextActionBreathOfMoney |
| static [CastSpell](ActionListBuilderContextEx/CastSpell.md)(…) | Adds ContextActionCastSpell |
| static [ChangeBuffDuration](ActionListBuilderContextEx/ChangeBuffDuration.md)(…) | Adds ContextActionReduceBuffDuration |
| static [ClearSummonPool](ActionListBuilderContextEx/ClearSummonPool.md)(…) | Adds ContextActionClearSummonPool |
| static [CombatManeuver](ActionListBuilderContextEx/CombatManeuver.md)(…) | Adds ContextActionCombatManeuver |
| static [CustomCombatManeuver](ActionListBuilderContextEx/CustomCombatManeuver.md)(…) | Adds ContextActionCombatManeuverCustom |
| static [DealAbilityDamage](ActionListBuilderContextEx/DealAbilityDamage.md)(…) |  |
| static [DealDamage](ActionListBuilderContextEx/DealDamage.md)(…) | Adds ContextActionDealDamage |
| static [DealDamagePreRolled](ActionListBuilderContextEx/DealDamagePreRolled.md)(…) |  |
| static [DealPermanentNegativeLevels](ActionListBuilderContextEx/DealPermanentNegativeLevels.md)(…) |  |
| static [DealTempNegativeLevels](ActionListBuilderContextEx/DealTempNegativeLevels.md)(…) |  |
| static [DealWeaponDamage](ActionListBuilderContextEx/DealWeaponDamage.md)(…) | Adds ContextActionDealWeaponDamage |
| static [Demoralize](ActionListBuilderContextEx/Demoralize.md)(…) | Adds [`Demoralize`](./ActionListBuilderContextEx/Demoralize.md) |
| static [DetectSecretDoors](ActionListBuilderContextEx/DetectSecretDoors.md)(…) | Adds ContextActionDetectSecretDoors |
| static [DevourWithSwarm](ActionListBuilderContextEx/DevourWithSwarm.md)(…) | Adds ContextActionDevourBySwarm |
| static [Disarm](ActionListBuilderContextEx/Disarm.md)(…) | Adds ContextActionDisarm |
| static [DismissAOE](ActionListBuilderContextEx/DismissAOE.md)(…) | Adds ContextActionDismissAreaEffect |
| static [Dismount](ActionListBuilderContextEx/Dismount.md)(…) | Adds ContextActionDismount |
| static [Dispel](ActionListBuilderContextEx/Dispel.md)(…) | Adds ContextActionDispelMagic |
| static [DivideSharedValueBy2](ActionListBuilderContextEx/DivideSharedValueBy2.md)(…) |  |
| static [DivideSharedValueBy4](ActionListBuilderContextEx/DivideSharedValueBy4.md)(…) |  |
| static [DropItems](ActionListBuilderContextEx/DropItems.md)(…) | Adds ContextActionDropItems |
| static [EnchantWornItem](ActionListBuilderContextEx/EnchantWornItem.md)(…) | Adds ContextActionEnchantWornItem |
| static [FinishObjective](ActionListBuilderContextEx/FinishObjective.md)(…) | Adds ContextActionFinishObjective |
| static [GiveExperience](ActionListBuilderContextEx/GiveExperience.md)(…) | Adds ContextActionGiveExperience |
| static [GiveRandomTrashToPlayer](ActionListBuilderContextEx/GiveRandomTrashToPlayer.md)(…) | Adds ContextActionAddRandomTrashItem |
| static [Grapple](ActionListBuilderContextEx/Grapple.md)(…) | Adds ContextActionGrapple |
| static [HealNegativeLevels](ActionListBuilderContextEx/HealNegativeLevels.md)(…) | Adds ContextActionHealEnergyDrain |
| static [HealStatDamage](ActionListBuilderContextEx/HealStatDamage.md)(…) | Adds ContextActionHealStatDamage |
| static [HealTarget](ActionListBuilderContextEx/HealTarget.md)(…) | Adds ContextActionHealTarget |
| static [HideInPlainSight](ActionListBuilderContextEx/HideInPlainSight.md)(…) | Adds ContextActionHideInPlainSight |
| static [Kill](ActionListBuilderContextEx/Kill.md)(…) | Adds ContextActionKill |
| static [Knockdown](ActionListBuilderContextEx/Knockdown.md)(…) | Adds ContextActionKnockdownTarget |
| static [KnowledgeCheck](ActionListBuilderContextEx/KnowledgeCheck.md)(…) | Adds ContextActionMakeKnowledgeCheck |
| static [MagicFang](ActionListBuilderContextEx/MagicFang.md)(…) |  |
| static [MagicWeapon](ActionListBuilderContextEx/MagicWeapon.md)(…) | Adds EnhanceWeapon |
| static [MarkOwnerForDismemberment](ActionListBuilderContextEx/MarkOwnerForDismemberment.md)(…) | Adds ContextActionMarkForceDismemberOwner |
| static [MeleeAttack](ActionListBuilderContextEx/MeleeAttack.md)(…) | Adds ContextActionMeleeAttack |
| static [Mount](ActionListBuilderContextEx/Mount.md)(…) | Adds ContextActionMount |
| static [MultiplySharedValue](ActionListBuilderContextEx/MultiplySharedValue.md)(…) |  |
| static [OnCaster](ActionListBuilderContextEx/OnCaster.md)(…) | Adds ContextActionOnContextCaster |
| static [OnEachSwallowedUnit](ActionListBuilderContextEx/OnEachSwallowedUnit.md)(…) | Adds ContextActionForEachSwallowedUnit |
| static [OnOwner](ActionListBuilderContextEx/OnOwner.md)(…) | Adds ContextActionOnOwner |
| static [OnPartyMembers](ActionListBuilderContextEx/OnPartyMembers.md)(…) | Adds ContextActionPartyMembers |
| static [OnPets](ActionListBuilderContextEx/OnPets.md)(…) | Adds ContextActionsOnPet |
| static [OnRandomEnemyInAOE](ActionListBuilderContextEx/OnRandomEnemyInAOE.md)(…) | Adds ContextActionOnRandomAreaTarget |
| static [OnRandomUnitNearTarget](ActionListBuilderContextEx/OnRandomUnitNearTarget.md)(…) | Adds ContextActionOnRandomTargetsAround |
| static [OnSwarmTargets](ActionListBuilderContextEx/OnSwarmTargets.md)(…) | Adds ContextActionOnSwarmTargets |
| static [ProjectileFx](ActionListBuilderContextEx/ProjectileFx.md)(…) | Adds ContextActionProjectileFx |
| static [ProvokeOpportunityAttack](ActionListBuilderContextEx/ProvokeOpportunityAttack.md)(…) | Adds ContextActionProvokeAttackOfOpportunity |
| static [ProvokeOpportunityAttackFromCaster](ActionListBuilderContextEx/ProvokeOpportunityAttackFromCaster.md)(…) | Adds ContextActionProvokeAttackFromCaster |
| static [Push](ActionListBuilderContextEx/Push.md)(…) | Adds ContextActionPush |
| static [RandomActions](ActionListBuilderContextEx/RandomActions.md)(…) | Adds ContextActionRandomize |
| static [RangedAttack](ActionListBuilderContextEx/RangedAttack.md)(…) | Adds ContextActionRangedAttack |
| static [RecoverItemCharges](ActionListBuilderContextEx/RecoverItemCharges.md)(…) | Adds ContextActionRecoverItemCharges |
| static [RemoveBuff](ActionListBuilderContextEx/RemoveBuff.md)(…) | Adds ContextActionRemoveBuff |
| static [RemoveBuffStack](ActionListBuilderContextEx/RemoveBuffStack.md)(…) | Adds ContextActionRemoveBuffSingleStack |
| static [RemoveBuffsWithDescriptor](ActionListBuilderContextEx/RemoveBuffsWithDescriptor.md)(…) | Adds ContextActionRemoveBuffsByDescriptor |
| static [RemoveDeathDoor](ActionListBuilderContextEx/RemoveDeathDoor.md)(…) | Adds ContextActionRemoveDeathDoor |
| static [RemoveFromSwarmTargets](ActionListBuilderContextEx/RemoveFromSwarmTargets.md)(…) |  |
| static [RemoveSelf](ActionListBuilderContextEx/RemoveSelf.md)(…) | Adds ContextActionRemoveSelf |
| static [RepeatActions](ActionListBuilderContextEx/RepeatActions.md)(…) | Adds ContextActionRepeatedActions |
| static [ResetAlignment](ActionListBuilderContextEx/ResetAlignment.md)(…) | Adds ContextActionResetAlignment |
| static [RestoreAllResourcesToFull](ActionListBuilderContextEx/RestoreAllResourcesToFull.md)(…) | Adds ContextRestoreResource |
| static [RestoreResource](ActionListBuilderContextEx/RestoreResource.md)(…) | Adds ContextRestoreResource |
| static [RestoreSpells](ActionListBuilderContextEx/RestoreSpells.md)(…) | Adds ContextActionRestoreSpells |
| static [Resurrect](ActionListBuilderContextEx/Resurrect.md)(…) | Adds ContextActionResurrect |
| static [ResurrectAndFullRestore](ActionListBuilderContextEx/ResurrectAndFullRestore.md)(…) |  |
| static [RunActionWithGreatestValue](ActionListBuilderContextEx/RunActionWithGreatestValue.md)(…) | Adds ContextActionSelectByValue |
| static [SavingThrow](ActionListBuilderContextEx/SavingThrow.md)(…) | Adds ContextActionSavingThrow |
| static [SetSharedValue](ActionListBuilderContextEx/SetSharedValue.md)(…) | Adds ContextActionChangeSharedValue |
| static [SetSharedValueToHD](ActionListBuilderContextEx/SetSharedValueToHD.md)(…) |  |
| static [ShieldArmorEnchantPool](ActionListBuilderContextEx/ShieldArmorEnchantPool.md)(…) | Adds ContextActionShieldArmorEnchantPool |
| static [ShieldWeaponEnchantPool](ActionListBuilderContextEx/ShieldWeaponEnchantPool.md)(…) | Adds ContextActionShieldWeaponEnchantPool |
| static [SkillCheck](ActionListBuilderContextEx/SkillCheck.md)(…) | Adds ContextActionSkillCheck |
| static [SkillCheckWithFailureDegrees](ActionListBuilderContextEx/SkillCheckWithFailureDegrees.md)(…) |  |
| static [SpawnAOE](ActionListBuilderContextEx/SpawnAOE.md)(…) | Adds ContextActionSpawnAreaEffect |
| static [SpawnControllableProjectile](ActionListBuilderContextEx/SpawnControllableProjectile.md)(…) | Adds ContextActionSpawnControllableProjectile |
| static [SpawnMonster](ActionListBuilderContextEx/SpawnMonster.md)(…) | Adds ContextActionSpawnMonster |
| static [SpawnMonsterUnlinked](ActionListBuilderContextEx/SpawnMonsterUnlinked.md)(…) | Adds ContextActionSpawnUnlinkedMonster |
| static [SpawnMonsterUsingSummonPool](ActionListBuilderContextEx/SpawnMonsterUsingSummonPool.md)(…) |  |
| static [SpendOpportunityAttack](ActionListBuilderContextEx/SpendOpportunityAttack.md)(…) | Adds ContextActionSpendAttackOfOpportunity |
| static [SpendResource](ActionListBuilderContextEx/SpendResource.md)(…) | Adds ContextSpendResource |
| static [StealBuffs](ActionListBuilderContextEx/StealBuffs.md)(…) | Adds ContextActionStealBuffs |
| static [SwallowWhole](ActionListBuilderContextEx/SwallowWhole.md)(…) | Adds ContextActionSwallowWhole |
| static [SwarmAttack](ActionListBuilderContextEx/SwarmAttack.md)(…) | Adds ContextActionSwarmAttack |
| static [SwitchDualCompanion](ActionListBuilderContextEx/SwitchDualCompanion.md)(…) | Adds ContextActionSwitchDualCompanion |
| static [SwordlordAdaptiveTacticsAdd](ActionListBuilderContextEx/SwordlordAdaptiveTacticsAdd.md)(…) | Adds SwordlordAdaptiveTacticsAdd |
| static [SwordlordAdaptiveTacticsClear](ActionListBuilderContextEx/SwordlordAdaptiveTacticsClear.md)(…) | Adds SwordlordAdaptiveTacticsClear |
| static [Teleport](ActionListBuilderContextEx/Teleport.md)(…) | Adds ContextActionTranslocate |
| static [Unsummon](ActionListBuilderContextEx/Unsummon.md)(…) | Adds ContextActionUnsummon |
| static [WeaponEnchantPool](ActionListBuilderContextEx/WeaponEnchantPool.md)(…) | Adds ContextActionWeaponEnchantPool |

## See Also

* namespace [BlueprintCore.Actions.Builder.ContextEx](../Blueprint-Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for Blueprint-Core.dll -->
