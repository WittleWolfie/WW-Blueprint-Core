# How to Contribute

Contributions are welcome!

1. [Fork](https://docs.github.com/en/get-started/quickstart/fork-a-repo) the [Project Repo](https://github.com/WittleWolfie/WW-Blueprint-Core)
2. Make your changes in the forked repo
3. Submit a [Pull Request](https://docs.github.com/en/get-started/quickstart/contributing-to-projects#making-a-pull-request)

## Local Project Setup

1. Install NuGet Packages
    * [Aze.Publicise.MSBuild.Task](https://www.nuget.org/packages/Aze.Publicise.MSBuild.Task/1.0.0)
    * [docfx.console](https://www.nuget.org/packages/docfx.console/)
2. Configure Environment Variables
    * `WrathPath` environment variable must be the root installation directory for the game
        * Usually this is `C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure`
3. Clean the project
    * This copies the dependent assemblies to the project directory and publicizes Assembly-CSharp
    * If you don't have Unity Mod Manager installed you need to add a reference to a Harmony assembly
4. Configure Hard Links
    * Delete the `docs` folder in the root directory and `index.md` in the root of the Blueprint-Core project
    * Open an admin command promt, navigate to the solution's directory, and run the following commands:
        * `mklink /h Blueprint-Core\index.md README.md`
        * `mklink /j docs Blueprint-Core\_site`
    * This is needed to update documentation when building changes

## Pull Request Requirements

1. Change Description
    * What was modified, removed, or added?
    * Why is the change needed?
2. Add/Update Unit Tests
3. Code Style
    * Limit lines to 120 characters
        * Relaxed for comments, especially comments with long links
    * 2 Space Indent, 4 Space Indent for wrapped lines
    * Always use braces, even for one line statements
    * Stay consistent with existing code and prefer common C# styling otherwise
    * Remove unused and sort usings
4. Documentation
    * Use XML style comments
    * Builder and configurator methods that modify or create game types or fields must declare the type or field in their comment summary
    * String arguments that are used to reference blueprints must declare the type of blueprint they represent
5. No Patches
    * Harmony patches are not allowed. Since multiple mods may include this library it would result in multiple copies of the patch being installed, potentially causing incompatibility issues.
6. Before Committing
    * Rebuild the solution using the Release configuration to ensure documentation is updated
    * Run all unit tests
        * Note: If tests throw exceptions when adding blueprints from TestData just re-run them. There is an issue with static data sticking around that I have not been able to resolve.

## Using BlueprintCoreGen

TODO: Update w/ more info

BlueprintCoreGen is configured to be run directly from Visual Studio and output files in `bin/<Release|Debug>/net5.0/`:

* `Templates` folder is a copy of the project files
* `missing_types.txt` lists game types detected but not implemented
* `ActionsBuilder` folder contains the generated ActionsBuilder classes

## What to Contribute

**Note:** Do not submit a pull request which includes Harmony patches. Since BlueprintCore is distributed as source, patches would be run in every mod built using it. It is possible to create safe patches but I am not going to evaluate pull requests in that detail.

### Documentation

This is likely the most helpful thing you can contribute. One of the biggest challenges to modding the game is understanding the behavior of game classes such as actions, conditions, and blueprint components.

If you use and understand the in game classes, update the corresponding configurator or builder method to explain the in-game effect and proper usage.

### Template Blueprint Configurators

Most configurators are generated automatically. There may be cases where the automated code is not ideal and hand-coded templates are preferable. When defining a new configurator:

// TODO: Code gen attr / flag
* Provide the appropriate `New()` and `For()` methods
* Implement configurators following the blueprint's type inheritance
    * You *must* provide templates for all configurators in the inheritance tree up to [BlueprintConfigurator](xref:BlueprintCore.Blueprints.Configurators.BlueprintConfigurator`1). This is a limitation of code generation.
* Implement support for all of the blueprint's fields (excluding inherited fields)
* Do not include component methods directly; add them to one of BlueprintCoreGen's configurator template classes

### Configurator and Builder Methods

TODO: Update

* Methods should enforce proper usage
    * Validate all required inputs are specified
    * Provide sensible defaults for optional inputs
    * Use multiple methods for a type whenever there are distinct valid configurations
        * Example: [DealDamage](xref:BlueprintCore.Actions.Builder.ContextEx.ActionsBuilderContextEx.DealDamage(BlueprintCore.Actions.Builder.ActionsBuilder,Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription,Kingmaker.UnitLogic.Mechanics.ContextDiceValue,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Nullable{System.Int32},System.Nullable{Kingmaker.UnitLogic.Abilities.AbilitySharedValue},System.Nullable{Kingmaker.UnitLogic.Abilities.AbilitySharedValue})) and related methods
* Indicate the game type or field created or modified in the method comment summary
* Document the blueprint type of any string arguments used to reference blueprints

### New Actions, Conditions, and Components

If you create new actions, conditions, or blueprint components that can be re-used, feel free to add them to the library.

* Implement the necessary configurator and builder methods to support them

### New Utilities

If you have utilities that would help other modders, feel free to add them to the library.