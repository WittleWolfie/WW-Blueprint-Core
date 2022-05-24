# How to Contribute

**Disclaimer**: These docs haven't been updated since 2.0 release. For now, disregard them. I will update them soon.

Contributions are welcome!

1. [Fork](https://docs.github.com/en/get-started/quickstart/fork-a-repo) the [Project Repo](https://github.com/WittleWolfie/WW-Blueprint-Core)
2. Make your changes in the forked repo
3. Submit a [Pull Request](https://docs.github.com/en/get-started/quickstart/contributing-to-projects#making-a-pull-request)

# What to Contribute

## Knowledge of Game Types

Possibly the most helpful contribution you could provide! If you are familiar with the usage of game types, specifically any `Condition`, `GameAction`, `BlueprintComponent`, or `BlueprintScriptableObject`, you can improve the Builder and Configurator APIs.

Examples of useful contributions:

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

#### Adding Remarks

#### Marking Fields Required or Ignored

#### Splitting Methods

#### Marking Fields Constant

#### Marking Related Fields

#### Further Customizing Methods

#### Field Type Behavior

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

BlueprintCoreGen is the tool responsible for generating the ActionsBuilder, ConditionsBuilder, and Blueprint Configurator classes. It can execute in one of two modes: Analysis and Code Generation. In both modes be sure to run it in Debug configuration.

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