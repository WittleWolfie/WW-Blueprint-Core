# How to Contribute

**Disclaimer**: These docs haven't been updated since 2.0 release. For now, disregard them. I will update them soon.

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
    * Delete the `docs` folder in the root directory and `index.md` in the root of the BlueprintCore project
    * Open an admin command promt, navigate to the solution's directory, and run the following commands:
        * `mklink /h BlueprintCore\index.md README.md`
        * `mklink /j docs BlueprintCore\_site`
    * This is needed to update documentation when building changes

**Note**: It is recommended to build using the Debug configuration. The Release configuration generates documentation which takes several minutes.

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
    * Harmony patches are not allowed since the library may be included in multiple mods.
6. Before Committing
    * Rebuild the solution using the Release configuration to ensure documentation is updated
    * Run all unit tests
        * Note: If tests throw exceptions when adding blueprints from TestData just re-run them. There is an issue with static data sticking around that I have not been able to resolve.

## Using BlueprintCoreGen

After making updates you can run the code generation directly in visual studio. Once it completes the output is in `bin/<Release|Debug>/net5.0/`:

1. Run the powershell script `UpdateCodeGen.ps1` in the output to propagate changes to the `BlueprintCore` project
2. Remove unused usings from the updated code in `BlueprintCore`
    * In Visual Studio find an unused using, hit `Alt + Enter`, and select `Fix all occurrences in Solution`
    ![Remove unused usings](~/images/remove_usings.png)

## What to Contribute

### Documentation

This is likely the most helpful thing you can contribute. One of the biggest challenges to modding the game is understanding the behavior of game classes such as actions, conditions, and blueprint components.

If you use and understand the in game classes, update the corresponding configurator or builder method to explain the in-game effect and proper usage.

### Template Blueprint Configurators

For blueprints with complex fields or field relationships, hand-written templates are preferable. They can also be used for custom validation code. When defining a new configurator:

* Implement configurators following the blueprint's type inheritance
    * You *must* provide templates for all configurators in the inheritance tree up to [BlueprintConfigurator](xref:BlueprintCore.Blueprints.Configurators.BlueprintConfigurator`1). This is a limitation of code generation.
* Add a [Generated attribute](xref:BlueprintCore.Utils.GeneratedAttribute) indicating which blueprint type is implemented
* Provide the appropriate `New()` and `For()` methods
* Add methods for all fields defined in the blueprint, but not inherited fields
* Do not include component methods

### Configurator and Builder Methods

For components, actions, and conditions with complex parameters or parameter relationships, hand-written templates are preferable.

Configurator method templates are defined in the `BlueprintComponents` folder and grouped logically into classes. Only the method definition is used, the class declaration is used to group templates.

Builder method templates are defined in the `ActionsBuilder` and `ConditionsBuilder` folders. They are defined directly in the output class.

* Add a [Implements attribute](xref:BlueprintCore.Utils.ImplementsAttribute) to each method indicating which type is implemented
    * Multiple methods can have the same implements attribute; they will be copied together into the relevant output class
* Method declarations should enforce required and optional parameters while providing sensible defaults
    * Parameters with an object type defined in game library should be checked with the validator
    * Use multiple methods for a type if there are distinct valid configurations
        * Example: [DealDamage](xref:BlueprintCore.Actions.Builder.ContextEx.ActionsBuilderContextEx.DealDamage(BlueprintCore.Actions.Builder.ActionsBuilder,Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription,Kingmaker.UnitLogic.Mechanics.ContextDiceValue,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Nullable{System.Int32},System.Nullable{Kingmaker.UnitLogic.Abilities.AbilitySharedValue},System.Nullable{Kingmaker.UnitLogic.Abilities.AbilitySharedValue})) and related methods
* When adding a builder method, remove the auto-generated comment attribute for types already represented
* Document the implemented game type in the method comment, as well as any usage restrictions
* Document the blueprint type of any string arguments used to reference blueprints
* Document parameters with value or usage restrictions

### New Actions, Conditions, and Components

If you create new actions, conditions, or blueprint components that can be re-used, feel free to add them to the library.

* Implement the necessary configurator and builder methods to support them

### New Utilities

If you have utilities that would help other modders, feel free to add them to the library.