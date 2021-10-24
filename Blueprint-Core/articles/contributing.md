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
    * `WRATH_DIR` environment variable must be the root installation directory for the game
        * Usually this is `C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure`
3. Clean the project
    * This copies the dependent assemblies to the project directory and publicizes Assembly-CSharp
    * If you don't have Unity Mod Manager installed you also need to put 
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
    * Always use braces, even for one line statements
    * Stay consistent with existing code and prefer common C# styling otherwise
4. Documentation
    * Use XML style comments
    * Builder and configurator methods that modify or create game types or fields must declare the type or field in their comment summary
    * String arguments that are used to reference blueprints must declare the type of blueprint they represent
5. No Patches
    * Harmony patches are not allowed. Since multiple mods may include this library it would result in multiple copies of the patch being installed, potentially causing incompatibility issues.
6. Before Committing
    * Rebuild the solution to ensure documentation is updated
    * Run all unit tests

## What to Contribute

### Documentation

This is likely the most helpful thing you can contribute. One of the biggest challenges to modding the game is understanding the behavior of game classes such as actions, conditions, and blueprint components.

If you use and understand one of these classes, update the corresponding configurator or builder methods to explain the in-game effect and proper usage.

### New Blueprint Configurators

Once 1.0 is released all blueprint types will have configurators. It will take some time and new configurators will 
 speed up the full release.

* Provide the appropriate `Create()` and `For()` methods
* Configurator inheritance should follow the blueprint class inheritance structure
* A new configurator should support all fields before submitting
* Component methods in configurators should only be exposed to blueprint types that support them

### New Configurator and Builder Methods

Once 1.0 is released all blueprint, action, and conditions types will have methods. It will take some time and any contributions speed up the full release.

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