# Blueprint-Core assembly

## BlueprintCore namespace

| public type | description |
| --- | --- |
| static class [Main](./BlueprintCore/Main.md) |  |

## BlueprintCore.Abilities.Restrictions.New namespace

| public type | description |
| --- | --- |
| class [TargetHasBuffsFromCaster](./BlueprintCore.Abilities.Restrictions.New/TargetHasBuffsFromCaster.md) | Requires the target to have specific buffs applied by the caster. |

## BlueprintCore.Actions.Builder namespace

| public type | description |
| --- | --- |
| class [ActionListBuilder](./BlueprintCore.Actions.Builder/ActionListBuilder.md) | Fluent builder for ActionList. |

## BlueprintCore.Actions.Builder.AreaEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderAreaEx](./BlueprintCore.Actions.Builder.AreaEx/ActionListBuilderAreaEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for actions involving the game map, dungeons, or locations. See also [`KingdomEx`](./BlueprintCore.Actions.Builder.KingdomEx/ActionListBuilderKingdomEx.md). |

## BlueprintCore.Actions.Builder.AVEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderAVEx](./BlueprintCore.Actions.Builder.AVEx/ActionListBuilderAVEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for actions involving audiovisual effects such as dialogs, camera, cutscenes, and sounds. |

## BlueprintCore.Actions.Builder.BasicEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderBasicEx](./BlueprintCore.Actions.Builder.BasicEx/ActionListBuilderBasicEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for most game mechanics related actions not included in [`ContextEx`](./BlueprintCore.Actions.Builder.ContextEx/ActionListBuilderContextEx.md). |

## BlueprintCore.Actions.Builder.ContextEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderContextEx](./BlueprintCore.Actions.Builder.ContextEx/ActionListBuilderContextEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for most ContextAction types. Some ContextAction types are in more specific extensions such as [`AVEx`](./BlueprintCore.Actions.Builder.AVEx/ActionListBuilderAVEx.md) or [`KingdomEx`](./BlueprintCore.Actions.Builder.KingdomEx/ActionListBuilderKingdomEx.md). |

## BlueprintCore.Actions.Builder.KingdomEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderKingdomEx](./BlueprintCore.Actions.Builder.KingdomEx/ActionListBuilderKingdomEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for actions involving the Kingdom and Crusade system. |

## BlueprintCore.Actions.Builder.MiscEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderMiscEx](./BlueprintCore.Actions.Builder.MiscEx/ActionListBuilderMiscEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for actions without a better extension container such as achievements and CustomEvent. |

## BlueprintCore.Actions.Builder.NewEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderNewEx](./BlueprintCore.Actions.Builder.NewEx/ActionListBuilderNewEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for actions defined in BlueprintCore and not available in the base game. |

## BlueprintCore.Actions.Builder.StoryEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderStoryEx](./BlueprintCore.Actions.Builder.StoryEx/ActionListBuilderStoryEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for actions related to the story such as companion stories, quests, name changes, and etudes. |

## BlueprintCore.Actions.Builder.UpgraderEx namespace

| public type | description |
| --- | --- |
| static class [ActionListBuilderUpgraderEx](./BlueprintCore.Actions.Builder.UpgraderEx/ActionListBuilderUpgraderEx.md) | Extension to [`ActionListBuilder`](./BlueprintCore.Actions.Builder/ActionListBuilder.md) for all UpgraderOnlyActions. |

## BlueprintCore.Actions.New namespace

| public type | description |
| --- | --- |
| class [SwitchToDemoralizeTarget](./BlueprintCore.Actions.New/SwitchToDemoralizeTarget.md) | Updates the current context target to match the target of the last Demoralize action. |

## BlueprintCore.Actions.Patches namespace

| public type | description |
| --- | --- |
| static class [DemoralizePatch](./BlueprintCore.Actions.Patches/DemoralizePatch.md) | Patch for Demoralize used by [`IsDemoralizeAction`](./BlueprintCore.Conditions.New/IsDemoralizeAction.md) and [`SwitchToDemoralizeTarget`](./BlueprintCore.Actions.New/SwitchToDemoralizeTarget.md). |

## BlueprintCore.Blueprints namespace

| public type | description |
| --- | --- |
| abstract class [BlueprintConfigurator&lt;T,TBuilder&gt;](./BlueprintCore.Blueprints/BlueprintConfigurator-2.md) | Fluent API for creating and modifying blueprints. |
| static class [BlueprintExtensions](./BlueprintCore.Blueprints/BlueprintExtensions.md) | Extension methods for types inheriting from BlueprintScriptableObject |
| static class [BlueprintTool](./BlueprintCore.Blueprints/BlueprintTool.md) | Tool for operations on blueprints. |

## BlueprintCore.Blueprints.Abilities namespace

| public type | description |
| --- | --- |
| class [AbilityConfigurator](./BlueprintCore.Blueprints.Abilities/AbilityConfigurator.md) | Configurator for BlueprintAbility. |

## BlueprintCore.Blueprints.Buffs namespace

| public type | description |
| --- | --- |
| class [BuffConfigurator](./BlueprintCore.Blueprints.Buffs/BuffConfigurator.md) | Configurator for BlueprintBuff. |

## BlueprintCore.Blueprints.Classes namespace

| public type | description |
| --- | --- |
| abstract class [CommonFeatureConfigurator&lt;T,TBuilder&gt;](./BlueprintCore.Blueprints.Classes/CommonFeatureConfigurator-2.md) | Implements common fields and component support for blueprints inheriting from BlueprintFeature. |
| class [FeatureConfigurator](./BlueprintCore.Blueprints.Classes/FeatureConfigurator.md) | Configurator for BlueprintFeature. |

## BlueprintCore.Blueprints.Classes.Selection namespace

| public type | description |
| --- | --- |
| class [FeatureSelectionConfigurator](./BlueprintCore.Blueprints.Classes.Selection/FeatureSelectionConfigurator.md) | Configurator for BlueprintFeatureSelection. |

## BlueprintCore.Blueprints.Components namespace

| public type | description |
| --- | --- |
| static class [CommonExtensions](./BlueprintCore.Blueprints.Components/CommonExtensions.md) | Common parameter extensions for ContextRankConfig. |
| static class [ContextRankConfigs](./BlueprintCore.Blueprints.Components/ContextRankConfigs.md) | Helper class for creating ContextRankConfig objects. |
| class [ProgressionEntry](./BlueprintCore.Blueprints.Components/ProgressionEntry.md) | Wrapper providing a constructor for CustomProgressionItem |
| static class [ProgressionExtensions](./BlueprintCore.Blueprints.Components/ProgressionExtensions.md) | Progression extensions for ContextRankConfig. |

## BlueprintCore.Blueprints.Facts namespace

| public type | description |
| --- | --- |
| abstract class [BlueprintUnitFactConfigurator&lt;T,TBuilder&gt;](./BlueprintCore.Blueprints.Facts/BlueprintUnitFactConfigurator-2.md) | Implements common fields and component support for blueprints inheriting from BlueprintUnitFact. |

## BlueprintCore.Conditions.Builder namespace

| public type | description |
| --- | --- |
| class [ConditionsCheckerBuilder](./BlueprintCore.Conditions.Builder/ConditionsCheckerBuilder.md) | Fluent builder for ConditionsChecker |

## BlueprintCore.Conditions.Builder.ContextEx namespace

| public type | description |
| --- | --- |
| static class [ConditionsCheckerBuilderContextEx](./BlueprintCore.Conditions.Builder.ContextEx/ConditionsCheckerBuilderContextEx.md) | Extension to [`ConditionsCheckerBuilder`](./BlueprintCore.Conditions.Builder/ConditionsCheckerBuilder.md) for most ContextCondition types. Some ContextCondition types are in more specific extensions such as KingdomEx. |

## BlueprintCore.Conditions.Builder.NewEx namespace

| public type | description |
| --- | --- |
| static class [ConditionsCheckerBuilderNewEx](./BlueprintCore.Conditions.Builder.NewEx/ConditionsCheckerBuilderNewEx.md) | Extension to [`ConditionsCheckerBuilder`](./BlueprintCore.Conditions.Builder/ConditionsCheckerBuilder.md) for conditions defined in BlueprintCore and not available in the base game. |

## BlueprintCore.Conditions.New namespace

| public type | description |
| --- | --- |
| class [IsDemoralizeAction](./BlueprintCore.Conditions.New/IsDemoralizeAction.md) | Checks to determine if a Demoralize is being executed. |
| class [TargetInMeleeRange](./BlueprintCore.Conditions.New/TargetInMeleeRange.md) | Checks if the target is in melee range. |

## BlueprintCore.Fixes namespace

| public type | description |
| --- | --- |
| static class [RuleTempModifierTooltips](./BlueprintCore.Fixes/RuleTempModifierTooltips.md) | Fix to ensure temporary modifiers are displayed on tooltips. |

## BlueprintCore.Utils namespace

| public type | description |
| --- | --- |
| class [CommonTool](./BlueprintCore.Utils/CommonTool.md) | Utility for common operations. |
| static class [Constants](./BlueprintCore.Utils/Constants.md) |  |
| static class [ContextDuration](./BlueprintCore.Utils/ContextDuration.md) | Helper class for creating ContextDurationValue objects. |
| static class [ContextValues](./BlueprintCore.Utils/ContextValues.md) | Helper class for creating ContextValue objects. |
| static class [ElementTool](./BlueprintCore.Utils/ElementTool.md) | Tool for operations on Element objects. |
| class [LogWrapper](./BlueprintCore.Utils/LogWrapper.md) | Wrapper around LogChannel which supports dynamically enabling or disabling verbose logging. |
| static class [PrereqTools](./BlueprintCore.Utils/PrereqTools.md) | Tool for operations on Prerequisite objects. |
| static class [Validator](./BlueprintCore.Utils/Validator.md) | Validates the configuration of objects. |

<!-- DO NOT EDIT: generated by xmldocmd for Blueprint-Core.dll -->
