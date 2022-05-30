# How to Contribute

Contributions are welcome!

1. [Fork](https://docs.github.com/en/get-started/quickstart/fork-a-repo) the [Project Repo](https://github.com/WittleWolfie/WW-Blueprint-Core)
2. [Setup the project](#local-project-setup)
3. Make your changes in the forked repo
4. Submit a [Pull Request](https://docs.github.com/en/get-started/quickstart/contributing-to-projects#making-a-pull-request)
    * Keep in mind the [Pull Request Requirements](#pull-request-requirements)
    
If you're confused by the configuration overrides don't want to contribute directly, feel free to file a [GitHub Issue](https://github.com/WittleWolfie/WW-Blueprint-Core/issues). Share what game type you're working with and whatever information you have on its usage, as well as any difficulties you had working with it.

# What to Contribute

## Knowledge of Game Types

Possibly the most helpful contribution you could provide! If you are familiar with the usage of game types, specifically any `Condition`, `GameAction`, `BlueprintComponent`, or `BlueprintScriptableObject`, you can improve the Builder and Configurator APIs and documentation.

Examples contributions:

* Remarks on behavior of game types or the relationship between field values
    * `AbilityEffectMiss` needs to be added after another `AbilityApplyEffect` or it will always trigger.
* Indicating which fields for a game type are required or can be ignored
    * The `AddFacts` component must set `m_Facts`.
* Customizing the API to reflect more complex interactions such as constant fields or related fields
    * The `AddContextStatBonus` field `HasMinimal` should be true when `Minimal` is set and false otherwise.
* Adding validation of blueprint or component configuration
    * `BlueprintAbility` can only have one `AbilityDeliverEffect` component

Most of these are accomplished through configuration overrides or hardcoded overrides. Validation is handled by classes within the `BlueprintCore.Utils.Validation` namespace. Some configurator API changes require implementing a custom configurator class.

The sections below explain how to make these changes and provide examples already in use.

### Using Configuration Overrides

The Blueprint configurator, ActionsBuilder, and ConditionsBuilder APIs are automatically by iterating over types in the game assembly generating methods and classes to construct those types. This is handled by the BlueprintCoreGen and customized through JSON config files and static rules in the [Overrides](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides) package:

* [Actions](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/Actions)
    * Each file supports an ActionsBuilder extension class, e.g. `AreaActions.json`
    * The config determine which actions belong in that extension class as well as custom handling for those actions
    * Each is a `ConstructorMethod`, defined in [MethodOverrides](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Methods/MethodOverrides.cs)
* [Blueprints](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/Blueprints)
    * `Blueprints.json` supports overrides for handling blueprint fields in configurator classes
        * Each entry is a `BlueprintOverride`, defined in [Configurators](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Class/Configurators.cs)
    * `Components.json` supports overrides for handling BlueprintComponent methods
        * Each entry is a `ConstructorMethod`, defined in [MethodOverrides](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Methods/MethodOverrides.cs)
    * `ComponentsAllowedOn.json` overrides which Blueprint types a given component can be used on
        * Each entry is a `ComponentsAllowedOnOverride`, defined in [Configurators](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Class/Configurators.cs)
* [Conditions](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/Conditions)
    * Each file supports a ConditionsBuilder extension class, e.g. `AreaConditions.json`
    * The config determine which conditions belong in that extension class as well as custom handling for those conditions
    * Each entry is a `ConstructorMethod`, defined in [MethodOverrides](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Methods/MethodOverrides.cs)
* [Examples](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/Examples)
    * Each file is a generated list of usage examples for game types
    * `Examples.cs` is not automatically generated; it contains hand selected examples
* [Ignored](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/Ignored)
    * Each file is a generated list of types to ignore
    * `Ignored.cs` is not automatically generated; it contains hand selected fields and game types to ignore
* [Fields.json](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/Fields.json)
    * Overrides for specific fields which apply to all inherited types
    * Each entry is a `FieldOverride`, defined in [ParameterOverrides](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Params/ParameterOverrides.cs)
* [FieldTypes.json](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/BlueprintCoreGen/CodeGen/Overrides/FieldTypes.json)
    * Overrides for handling specific game types
    * Each entry is a `FieldTypeOverride`, defined in [ParameterOverrides](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Params/ParameterOverrides.cs)

The sections below demonstrate how to use the configuration overrides for specific changes. Once you have your configuration override ready to test see [Using BlueprintCoreGen](#using-blueprintcoregen).

#### Adding Remarks

*Works On*: Actions, Blueprint Components, Conditions, Blueprint Fields

For actions and conditions find the corresponding entry in one of the config files, e.g. [ContextActions.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Actions/ContextActions.json):

```json
{
  "TypeName": "ContextActionArmorEnchantPool",
  "Remarks": [
    "The caster's armor is enchanted based on its available enhancement bonus. e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied."
  ],
  ...
},
```

`Remarks` is defined as a list of strings, each of which is wrapped in paragraph tags. The result:

![ContextActionArmorEnchantPool Remarks](~/images/contributing/action_remarks.png)

For a component either find an existing entry in [Components.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Blueprints/Components.json)
or add a new one:

```json
{
  "TypeName": "AbilityVariants",
  "Remarks": [
    "This ability should be the parent as defined in <see cref=\"BlueprintAbility.m_Parent\"/> for each variant.",
    "If you remove a variant be sure to clear <see cref=\"BlueprintAbility.m_Parent\"/> for that ability. You can set it to <c>BlueprintTool.GetRef&lt;BlueprintAbilityReference&gt;(null)</c>."
  ]
}
```

For a blueprint field find an existing entry in [Blueprints.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Blueprints/Blueprints.json)
or add a new one:

```json
{
  "TypeName": "BlueprintBuff",
  "Fields": [
    {
      "FieldName": "Stacking",
      "Remarks": [
        "Use <see cref=\"SetRanks(int)\"/> for StackingType.Rank."
      ]
    }
  ]
}
```

#### Marking Fields Required or Ignored

*Works On*: Actions, Blueprint Components, Conditions

For actions and conditions find the corresponding entry in one of the config files, e.g. [ContextConditions.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Conditions/ContextConditions.json):

```json
{
  "TypeName": "ContextConditionHasFact",
  "RequiredFields": [ "m_Fact" ]
},
```

`RequiredFields` is a list of field names which will be required parameters in the generated method. The result:

![ContextConditionHasFact Required Field](~/images/contributing/condition_required_field.png)

Example of ignoring a field in [ContextActions.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Actions/ContextActions.json):

```json
{
  "TypeName": "ContextActionOnRandomAreaTarget",
  "Remarks": [ "Only works inside of AbilityAreaEffectRunAction and only effects enemies." ],
  "RequiredFields": [ "Actions" ],
  "IgnoredFields": [ "OnEnemies" ]
},
```

`IgnoredFields` is a list of field names which will not be exposed as parameters in the generated method. The result:

![ContextConditionHasFact Required Field](~/images/contributing/action_ignored_field.png)

For components find an existing entry in [Components.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Blueprints/Components.json)
or add a new one:

```json
{
  "TypeName": "AbilityCasterAlignment",
  "RequiredFields": [ "alignment" ]
},
```

#### Handling Related Fields

*Works On*: Actions, Blueprint Components, Conditions

A common pattern in game types is a boolean field which indicates whether to use another field. This can be handled by using ignored fields and custom fields, e.g. in [Components.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Blueprints/Components.json):

```json
{
  "TypeName": "AddContextStatBonus",
  "RequiredFields": [ "Stat", "Value" ],
  "IgnoredFields": [ "HasMinimal" ],
  "CustomFields": [
    {
      "FieldName": "Minimal",
      "ExtraAssignmentFmtLines": [ "{0}.HasMinimal = {1} is null;" ]
    }
  ]
},
```

The resulting method accepts a parameter for `Minimal` but not `HasMinimal`. Internally `HasMinimal` will be set based on whether `Minimal` is specified. Here is the resulting method:

```C#
public TBuilder AddContextStatBonus(
  StatType stat,
  ContextValue value,
  ModifierDescriptor? descriptor = null,
  Action<BlueprintComponent, BlueprintComponent>? merge = null,
  ComponentMerge mergeBehavior = ComponentMerge.Fail,
  int? minimal = null,
  int? multiplier = null)
{
  var component = new AddContextStatBonus();
  component.Stat = stat;
  component.Value = value;
  component.Descriptor = descriptor ?? component.Descriptor;
  component.Minimal = minimal ?? component.Minimal;
  component.HasMinimal = minimal is null;
  component.Multiplier = multiplier ?? component.Multiplier;
  return AddUniqueComponent(component, mergeBehavior, merge);
}
```

The `CustomFields` config is a list of fields by name customized using the `CustomField` class in [ParameterOverrides](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Params/ParameterOverrides.cs).

`ExtraAssignmentFmtLines` is a list of format strings inserted after the field operation in the generated method. See `CustomField` for full documentation.

#### Splitting Methods

*Works On*: Actions, Blueprint Components, Conditions

Some game types implement several distinct uses, each requiring different configurations. For example, `ContextActionApplyBuff` can be used to apply a value with different durations. The resulting override generates three distinct methods:

```json
{
  "TypeName": "ContextActionApplyBuff",
  "RequiredFields": [ "m_Buff" ],
  "Methods": [
    {
      "MethodName": "ApplyBuffPermanent",
      "IgnoredFields": [ "DurationSeconds", "DurationValue" ],
      "ConstantFields": [
        {
          "FieldName": "UseDurationSeconds",
          "Value": "false"
        },
        {
          "FieldName": "Permanent",
          "Value": "true"
        }
      ]
    },
    {
      "MethodName": "ApplyBuffWithDurationSeconds",
      "RequiredFields": [ "DurationSeconds" ],
      "IgnoredFields": [ "DurationValue" ],
      "ConstantFields": [
        {
          "FieldName": "UseDurationSeconds",
          "Value": "true"
        },
        {
          "FieldName": "Permanent",
          "Value": "false"
        }
      ]
    },
    {
      "MethodName": "ApplyBuff",
      "RequiredFields": [ "DurationValue" ],
      "IgnoredFields": [ "DurationSeconds" ],
      "ConstantFields": [
        {
          "FieldName": "UseDurationSeconds",
          "Value": "false"
        },
        {
          "FieldName": "Permanent",
          "Value": "false"
        }
      ]
    }
  ]
},
```

`Methods` is a list of method overrides, each of which generates a single method. Notice that `RequiredFields` is defined in the root override; anything defined in the root applies to all methods. In this case, `m_Buff` is a required parameter for all generated methods.

The resulting code:

```C#
public static ActionsBuilder ApplyBuffPermanent(
    this ActionsBuilder builder,
    Blueprint<BlueprintBuffReference> buff,
    bool? asChild = null,
    bool? isFromSpell = null,
    bool? isNotDispelable = null,
    bool? sameDuration = null,
    bool? toCaster = null)
{
  var element = ElementTool.Create<ContextActionApplyBuff>();
  element.m_Buff = buff?.Reference;
  element.AsChild = asChild ?? element.AsChild;
  element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
  element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
  element.SameDuration = sameDuration ?? element.SameDuration;
  element.ToCaster = toCaster ?? element.ToCaster;
  element.Permanent = true;
  element.UseDurationSeconds = false;
  return builder.Add(element);
}

public static ActionsBuilder ApplyBuffWithDurationSeconds(
    this ActionsBuilder builder,
    Blueprint<BlueprintBuffReference> buff,
    float durationSeconds,
    bool? asChild = null,
    bool? isFromSpell = null,
    bool? isNotDispelable = null,
    bool? sameDuration = null,
    bool? toCaster = null)
{
  var element = ElementTool.Create<ContextActionApplyBuff>();
  element.m_Buff = buff?.Reference;
  element.DurationSeconds = durationSeconds;
  element.AsChild = asChild ?? element.AsChild;
  element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
  element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
  element.SameDuration = sameDuration ?? element.SameDuration;
  element.ToCaster = toCaster ?? element.ToCaster;
  element.Permanent = false;
  element.UseDurationSeconds = true;
  return builder.Add(element);
}

public static ActionsBuilder ApplyBuff(
    this ActionsBuilder builder,
    Blueprint<BlueprintBuffReference> buff,
    ContextDurationValue durationValue,
    bool? asChild = null,
    bool? isFromSpell = null,
    bool? isNotDispelable = null,
    bool? sameDuration = null,
    bool? toCaster = null)
{
  var element = ElementTool.Create<ContextActionApplyBuff>();
  element.m_Buff = buff?.Reference;
  builder.Validate(durationValue);
  element.DurationValue = durationValue;
  element.AsChild = asChild ?? element.AsChild;
  element.IsFromSpell = isFromSpell ?? element.IsFromSpell;
  element.IsNotDispelable = isNotDispelable ?? element.IsNotDispelable;
  element.SameDuration = sameDuration ?? element.SameDuration;
  element.ToCaster = toCaster ?? element.ToCaster;
  element.Permanent = false;
  element.UseDurationSeconds = false;
  return builder.Add(element);
}
```

These methods ensure `ContextActionApplyBuff` is properly configured for the duration desired.

Note the usage of `ConstantFields` to mark fields such as `Permanent` to a constant value based on the method.

#### Further Customizing Methods

The extent of configuration is defined in the various override classes. Supported customization includes:

* Adding required imports
* Adding extra method parameters
* Specifying defualt values
* Specifying field nullability
* Specifying parameter comments
* Customizing the assignment statement
* Adding additional lines of code
* Overriding blueprint field methods
* Renaming parameters or methods (use sparingly)

Here's a complex example from [ContextActions.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/Actions/ContextActions.json):

```json
{
  "TypeName": "ContextActionArmorEnchantPool",
  "Remarks": [
    "The caster's armor is enchanted based on its available enhancement bonus. e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied."
  ],
  "Imports": [
    "BlueprintTool",
    "BlueprintItemEnchantment",
    "BlueprintItemEnchantmentReference",
    "ItemEnchantments"
  ],
  "RequiredFields": [ "EnchantPool", "DurationValue" ],
  "IgnoredFields": [ "m_DefaultEnchantments" ],
  "ExtraParams": [
    {
      "ParamName": "enchantmentPlus1",
      "TypeName": "Blueprint<BlueprintItemEnchantmentReference>?",
      "CommentFmt": "Defaults to TemporaryArmorEnhancementBonus1",
      "DefaultValue": "null",
      "OperationFmt": [
        "{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;"
      ]
    },
    {
      "ParamName": "enchantmentPlus2",
      "TypeName": "Blueprint<BlueprintItemEnchantmentReference>?",
      "CommentFmt": "Defaults to TemporaryArmorEnhancementBonus2",
      "DefaultValue": "null",
      "OperationFmt": [
        "{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;"
      ]
    },
    {
      "ParamName": "enchantmentPlus3",
      "TypeName": "Blueprint<BlueprintItemEnchantmentReference>?",
      "CommentFmt": "Defaults to TemporaryArmorEnhancementBonus3",
      "DefaultValue": "null",
      "OperationFmt": [
        "{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;"
      ]
    },
    {
      "ParamName": "enchantmentPlus4",
      "TypeName": "Blueprint<BlueprintItemEnchantmentReference>?",
      "CommentFmt": "Defaults to TemporaryArmorEnhancementBonus4",
      "DefaultValue": "null",
      "OperationFmt": [
        "{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;"
      ]
    },
    {
      "ParamName": "enchantmentPlus5",
      "TypeName": "Blueprint<BlueprintItemEnchantmentReference>?",
      "CommentFmt": "Defaults to TemporaryArmorEnhancementBonus5",
      "DefaultValue": "null",
      "OperationFmt": [
        "{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;"
      ]
    }
  ]
},
```

Internally `ContextActionArmorEnchantPool` has an array for enchantments but in practice only 5 entries are usable. To represent this five extra parameters are included with defaults chosen based on existing game blueprints.

#### Field Type Behavior

Some field types need global handling overrides. In that case you can edit [FieldTypes.json](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreGen/CodeGen/Overrides/FieldTypes.json).

You can apply a variety of changes:

* Replace with an alternate type
    * Useful if you have a utility or wrapper class such as `ActionsBuilder` in place of `ActionList`
* Control whether the field is validated
* Change the assignment syntax
* Change the null handling behavior
* Add imports

Here is the override for `ActionList`:

```json
{
  "TypeName": "ActionList",
  "TypeNameOverride": "ActionsBuilder",
  "Imports": [ "ActionsBuilder" ],
  "AssignmentFmtRhs": "{0}?.Build()",
  "AssignmentIfNullRhs": "Utils.Constants.Empty.Actions"
},
```

This results in every method requiring an `ActionList` requesting an `ActionsBuilder`. If nothing is provided `Utils.Constants.Empty.Actions` is assigned to prevent NPEs.

Most commonly these overrides are useful for types which should never be null such as `PrefabLink`:

```json
{
  "TypeName": "PrefabLink",
  "AssignmentIfNullRhs": "Utils.Constants.Empty.PrefabLink"
}
```

This ensure even if the type's default field value is null it will be set to `Utils.Constants.Empty.PrefabLink`.

### Hardcoded Overrides

### Validation

### Custom Configurators

## Actions, Conditions, and Components

## Utilities

# What Not to Contribute

BlueprintCore is not the appropriate library for:

* Game content or behavior changes
* Bugfixes
* Anything requiring a harmony patch

If you have a very good reason for including a harmony patch let me know and we can discuss. The problem with patching is that multiple copies of the patch will be installed if multiple mods use BlueprintCore. As a result patches must be carefully implemented to function properly.

# Local Project Setup

1. Install NuGet Packages
    * [Aze.Publicise.MSBuild.Task](https://www.nuget.org/packages/Aze.Publicise.MSBuild.Task/1.0.0)
    * [docfx.console](https://www.nuget.org/packages/docfx.console/)
2. Configure Environment Variables
    * `WrathPath` environment variable must be the root installation directory for the game
        * Usually this is `C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure`
3. Clean the project
    * This copies the dependent assemblies to the project directory and publicizes Assembly-CSharp
    * Note that you should already have Unity Mod Manager installed
4. Configure Hard Links
    * Delete the `docs` folder in the root directory
    * Open an admin command promt, navigate to the solution's directory, and run the following commands:
        * `mklink /j docs BlueprintCore\_site`
    * This is needed to update documentation when building changes

**Note**: It is recommended to build using the Debug configuration. The Release configuration generates documentation which takes several minutes.

## Testing Changes

# Pull Request Requirements

1. Change Description
    * What was modified, removed, or added?
    * Why is the change needed?
2. Add/Update Unit Tests **Ignore this currently, Unit Test project needs to be fixed.**
    * Generated code does not need unit tests
3. Code Style
    * Limit lines to 120 characters
        * Relaxed for comments, especially comments with long links
    * 2 Space Indents
    * Always use braces, even for one line statements
    * Stay consistent with existing code and prefer common C# styling otherwise
    * Remove unused and sort usings
4. Documentation
    * Use XML style comments to document classes and public methods
        * Explain what it's for, how to use it, and any constraints on inputs
        * Consider including examples using the `<example>` tag
5. No Patches
    * Harmony patches are not allowed since the library may be included in multiple mods.
    * If you really want to add a patch, contact me to explain why. Note that it will have to be idempotent, i.e. function correctly if applied multiple times
6. Before Committing
    * Rebuild the solution using the **Release** configuration to update documentation
    * Run all unit tests
        * Note: If tests throw exceptions when adding blueprints from TestData just re-run them. There is an issue with static data sticking around that I have not been able to resolve.

# Using BlueprintCoreGen 

BlueprintCoreGen is the tool responsible for generating the ActionsBuilder, ConditionsBuilder, and Blueprint configurator classes. It can execute in one of two modes: Analysis and Code Generation. In both modes be sure to run it in Debug configuration.

## Analysis

Analysis is usually only needed to be run after the game patches so you probably don't need to use it. If you want to anyways:

1. Set `RunTypeUsageAnalysis` to `true` in Program.cs
2. Run the program

Once it is completed check the output directory (`bin/debug/net5.0`). There should be a folder titled `Analysis` which contains eight files:

* ExampleBlueprintComponents.cs
* ExampleBlueprintScriptableObjects.cs
* ExampleConditions.cs
* ExampleGameActions.cs
* IgnoredBlueprintComponents.cs
* IgnoredBlueprintScriptableObjects.cs
* IgnoredConditions.cs
* IgnoredGameActions.cs

1. Copy the four `Example*.cs` files into the project folder `CodeGen/Overrides/Example`
2. Copy the four `Ignored*.cs` files into the project folder `CodeGen/Overrides/Ignored`

Known Issue: You may have to replace a few type references with fully qualified type names due to naming conflicts.

## Code Generation

If you make changes to how code is generated or modify one of the `*.json` config files in the `Overrides` directory, you'll need to run Code Generation.

1. Set `RunTypeUsageAnalysis` to `false` in Program.cs
2. Run the program
3. Once it completes, navigate to the output directory (`bin/debug/net5.0`) and execute `UpdateCodeGen.ps1`
    * This must be executed from the output directory

Make sure that BlueprintCore builds, then remove unused using statements. [Here is a quick guide to doing this in Visual Studio](https://www.redbitdev.com/post/quick-tip-remove-unused-using-references-in-visual-studio).

After making updates you can run the code generation directly in visual studio. Once it completes the output is in `bin/<Release|Debug>/net5.0/`: