# BlueprintConfigurator&lt;T,TBuilder&gt; class

Fluent API for creating and modifying blueprints.

```csharp
public abstract class BlueprintConfigurator<T, TBuilder>
    where T : BlueprintScriptableObject
    where TBuilder : BlueprintConfigurator
```

## Public Members

| name | description |
| --- | --- |
| [AddComponent](BlueprintConfigurator-2/AddComponent.md)(…) | Adds the specified BlueprintComponent to the blueprint. |
| [AddPrerequisiteAlignment](BlueprintConfigurator-2/AddPrerequisiteAlignment.md)(…) | Adds or modifies PrerequisiteAlignment |
| [AddSpellDescriptors](BlueprintConfigurator-2/AddSpellDescriptors.md)(…) | Adds or modifies SpellDescriptorComponent |
| [AddUniqueComponent](BlueprintConfigurator-2/AddUniqueComponent.md)(…) |  |
| [Configure](BlueprintConfigurator-2/Configure.md)() | Commits the configuration changes to the blueprint. |
| [ContextRankConfig](BlueprintConfigurator-2/ContextRankConfig.md)(…) | Adds ContextRankConfig |
| [FactContextActions](BlueprintConfigurator-2/FactContextActions.md)(…) |  |
| [OnConfigure](BlueprintConfigurator-2/OnConfigure.md)(…) | Executes the specified actions when [`Configure`](./BlueprintConfigurator-2/Configure.md) is called. |
| [PrerequisiteArchetype](BlueprintConfigurator-2/PrerequisiteArchetype.md)(…) | Adds PrerequisiteArchetypeLevel |
| [PrerequisiteCasterType](BlueprintConfigurator-2/PrerequisiteCasterType.md)(…) |  |
| [PrerequisiteCasterTypeSpellLevel](BlueprintConfigurator-2/PrerequisiteCasterTypeSpellLevel.md)(…) | Adds PrerequisiteCasterTypeSpellLevel |
| [PrerequisiteCharacterLevel](BlueprintConfigurator-2/PrerequisiteCharacterLevel.md)(…) |  |
| [PrerequisiteClassLevel](BlueprintConfigurator-2/PrerequisiteClassLevel.md)(…) | Adds PrerequisiteClassLevel |
| [PrerequisiteClassSpellLevel](BlueprintConfigurator-2/PrerequisiteClassSpellLevel.md)(…) |  |
| [PrerequisiteCompanion](BlueprintConfigurator-2/PrerequisiteCompanion.md)(…) |  |
| [PrerequisiteEtude](BlueprintConfigurator-2/PrerequisiteEtude.md)(…) | Adds PrerequisiteEtude |
| [PrerequisiteFeature](BlueprintConfigurator-2/PrerequisiteFeature.md)(…) | Adds PrerequisiteFeature |
| [PrerequisiteFeaturesFromList](BlueprintConfigurator-2/PrerequisiteFeaturesFromList.md)(…) | Adds PrerequisiteFeaturesFromList |
| [PrerequisiteIsPet](BlueprintConfigurator-2/PrerequisiteIsPet.md)(…) | Adds PrerequisiteIsPet |
| [PrerequisiteMainCharacter](BlueprintConfigurator-2/PrerequisiteMainCharacter.md)(…) |  |
| [PrerequisiteMythicLevel](BlueprintConfigurator-2/PrerequisiteMythicLevel.md)(…) |  |
| [PrerequisiteNoArchetype](BlueprintConfigurator-2/PrerequisiteNoArchetype.md)(…) | Adds PrerequisiteNoArchetype |
| [PrerequisiteNoClass](BlueprintConfigurator-2/PrerequisiteNoClass.md)(…) | Adds PrerequisiteNoClassLevel |
| [PrerequisiteNoFeature](BlueprintConfigurator-2/PrerequisiteNoFeature.md)(…) | Adds PrerequisiteNoFeature |
| [PrerequisiteNotProficient](BlueprintConfigurator-2/PrerequisiteNotProficient.md)(…) |  |
| [PrerequisiteParameterizedSpellFeature](BlueprintConfigurator-2/PrerequisiteParameterizedSpellFeature.md)(…) | Adds PrerequisiteParametrizedFeature |
| [PrerequisiteParameterizedSpellSchoolFeature](BlueprintConfigurator-2/PrerequisiteParameterizedSpellSchoolFeature.md)(…) | Adds PrerequisiteParametrizedFeature |
| [PrerequisiteParameterizedWeaponFeature](BlueprintConfigurator-2/PrerequisiteParameterizedWeaponFeature.md)(…) | Adds PrerequisiteParametrizedFeature |
| [PrerequisiteParameterizedWeaponSubcategory](BlueprintConfigurator-2/PrerequisiteParameterizedWeaponSubcategory.md)(…) | Adds PrerequisiteParametrizedFeature |
| [PrerequisitePet](BlueprintConfigurator-2/PrerequisitePet.md)(…) | Adds PrerequisitePet |
| [PrerequisitePlayerHasFeature](BlueprintConfigurator-2/PrerequisitePlayerHasFeature.md)(…) | Adds PrerequisitePlayerHasFeature |
| [PrerequisiteProficient](BlueprintConfigurator-2/PrerequisiteProficient.md)(…) |  |
| [PrerequisiteStat](BlueprintConfigurator-2/PrerequisiteStat.md)(…) | Adds PrerequisiteStatValue |
| [RemoveComponents](BlueprintConfigurator-2/RemoveComponents.md)(…) | Removed components from the blueprint matching the specified predicate. |
| [RemovePrerequisiteAlignment](BlueprintConfigurator-2/RemovePrerequisiteAlignment.md)(…) | Modifies PrerequisiteAlignment |
| [RemoveSpellDescriptors](BlueprintConfigurator-2/RemoveSpellDescriptors.md)(…) | Modifies SpellDescriptorComponent |
| enum [ComponentMerge&lt;T,TBuilder&gt;](BlueprintConfigurator-2.ComponentMerge-2.md) | Describes how to resolve conflicts when multiple unique components are added to a blueprint. |

## Protected Members

| name | description |
| --- | --- |
| [BlueprintConfigurator](BlueprintConfigurator-2/BlueprintConfigurator.md)(…) |  |
| readonly [Blueprint](BlueprintConfigurator-2/Blueprint.md) |  |
| readonly [Name](BlueprintConfigurator-2/Name.md) |  |
| readonly [Self](BlueprintConfigurator-2/Self.md) |  |
| [AddValidationWarning](BlueprintConfigurator-2/AddValidationWarning.md)(…) |  |
| abstract [ConfigureInternal](BlueprintConfigurator-2/ConfigureInternal.md)() | Type specific configuration implemented in child classes. |
| [OnConfigureInternal](BlueprintConfigurator-2/OnConfigureInternal.md)(…) | Internal function comparable to [`OnConfigure`](./BlueprintConfigurator-2/OnConfigure.md). |
| abstract [ValidateInternal](BlueprintConfigurator-2/ValidateInternal.md)() | Type specific validation implemented in child classes. |
| static readonly [Logger](BlueprintConfigurator-2/Logger.md) |  |

## Remarks

Implementation is done using the [Curiously Recurring Template Pattern](https://en.wikipedia.org/wiki/Curiously_recurring_template_pattern).

**Key Features**

**Blueprint Creation**

Each configurator provides a function to create a new blueprint and register it in the game library.

**Component Type Safety**

Blueprints are very permissive; any BlueprintComponent can be added to any blueprint type. In reality many component types are only functional on certain types of blueprints, defined using attributes.

The configurator API mimics the inheritance structure of blueprint types in the game to restrict the available types of components. The API does not perfectly implement these restrictions because inheritance cannot represent the restrictions completely. In those cases type safety is provided through validation.

See [Wrath Blueprints](https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) for more information on component and blueprint type safety.

**Validation**

When [`Configure`](./BlueprintConfigurator-2/Configure.md) is called a combination of Owlcat provided and custom validation logic checks the blueprint for errors. All errors are then logged. This validates the blueprint only contains supported component types as well as checking for some implicit usage errors, such as [AbilityEffects](https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/[Wrath]-Abilities) usage.

See [`Validator`](../BlueprintCore.Utils/Validator.md) for more details on how validation works.

**Fluent API**

The API is designed to minimize boilerplate required to modify blueprints and create components. Configurators work with the [`ActionListBuilder`](../BlueprintCore.Actions.Builder/ActionListBuilder.md) and [`ConditionsCheckerBuilder`](../BlueprintCore.Conditions.Builder/ConditionsCheckerBuilder.md) APIs as well.

Complicated components such as ContextRankConfig which do not work well with the configurator API have their own helper classes. e.g. [`ContextRankConfigs`](../BlueprintCore.Blueprints.Components/ContextRankConfigs.md)

Add the Skald's Vigor and Greater Skald's Vigor feats (minus UI icons):

```csharp
var skaldClass = "WW-SkaldClass";
var inspiredRageFeature = "WW-InspiredRageFeature";
var inspiredRageBuff = "WW-InspiredRageBuff";
var skaldsVigorBuff = "WW-SkaldsVigorBuff";
var skaldsVigorFeat = "WW-SkaldsVigorFeat";
var greaterSkaldsVigorFeat = "WW-GreaterSkaldsVigorFeat";

// Register the names
BlueprintTool.AddGuidsByName(
    (skaldClass, "6afa347d804838b48bda16acb0573dc0"),
    (inspiredRageFeature, "1a639eadc2c3ed546bc4bb236864cd0c"),
    (inspiredRageBuff, "75b3978757908d24aaaecaf2dc209b89"),
    // New blueprints and guids
    (skaldsVigorBuff, "35fa838eb545491fbe73d593a3c456ed"),
    (skaldsVigorFeat, "59f825ec85744ac29e7d49201561638d"),
    (greaterSkaldsVigorFeat, "b97fa348973a4c5a916d78e9ed029e1f"));

// Load the icons and strings (not provided by library)
var skaldsVigorIcon = LoadSkaldsVigorIcon();
var greaterSkaldsVigorIcon = LoadGreaterSkaldsVigorIcon();
var skaldsVigorName = LoadSkaldsVigorName();
var greaterSkaldsVigorName = LoadGreaterSkaldsVigorName();
var skaldsVigorDescription = LoadSkaldsVigorDescription();
var greaterSkaldsVigorDescription = LoadGreaterSkaldsVigorDescription();

// Create the buff
BuffConfigurator.New(skaldsVigorBuff)
    .ContextRankConfig(
        // Sets a context rank value to 1 + 2 * (SkaldLevels / 8).
        ContextRankConfigs.ClassLevel(new string[] { skaldClass }).DivideByThenDoubleThenAdd1(8))
    // Adds fast healing to the buff. The base value is 1 and the context rank value is added. Before level 8
    // it provides 2; at level 8 it increases to 4; at level 16 it increases to 6.
    .FastHealing(1, bonusValue: ContextValues.Rank())
    .Configure();

// Creates an action to apply the buff. Permanent duration is used because it stays active as long as Inspired
// Rage is active.
var applyBuff = ActionListBuilder.New().ApplyBuff(skaldsVigorBuff, permanent: true, dispellable: false);
BuffConfigurator.For(inspiredRageBuff)
    .FactContextActions(
        onActivated:
            ActionListBuilder.New()
                // When the Inspired Rage buff is applied to the caster, Skald's Vigor is applied if they have
                // the feat.
                .Conditional(
                    ConditionsCheckerBuilder.New().TargetIsYourself().HasFact(skaldsVigorFeat),
                    ifTrue: applyBuff)
                // For characters other than the caster, Skald's Vigor is only applied if the caster has the
                // greater feat. Note: Technically this will apply the buff to the caster twice, but by default
                // buffs do not stack so it has no effect.
                .Conditional(
                    ConditionsCheckerBuilder.New().CasterHasFact(greaterSkaldsVigorFeat), ifTrue: applyBuff),
        onDeactivated:
            // Removes Skald's Vigor when Inspired Rage ends.
            // There is actually a bug with this implementation; Lingering Song will extend the duration of
            // Skald's Vigor when it should not. The fix for this is beyond the scope of this example.
            ActionListBuilder.New().RemoveBuff(skaldsVigorBuff))
    .Configure();
```

## See Also

* namespace [BlueprintCore.Blueprints](../Blueprint-Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for Blueprint-Core.dll -->
