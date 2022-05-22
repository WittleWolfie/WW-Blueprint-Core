# Getting Started

## Project Setup

1. Create a C# Class Library. If you haven't written mods for any Pathfinder game consider going through the [Beginner Guide](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Beginner-Guide).
2. Create a [public assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicize-Assemblies).
3. Install [WW-Blueprint-Core](https://www.nuget.org/packages/WW-Blueprint-Core/) using [NuGet](https://docs.microsoft.com/en-us/nuget/what-is-nuget).
4. Make sure your project is configured for .NET 4.7.2 and the latest C# language version
    * In your .csproj file you should have the following properties:
    ```xml
    <PropertyGroup>
      <LangVersion>latest</LangVersion>
      <TargetFramework>net472</TargetFramework>
    </PropertyGroup>
    ```
5. Add the required assembly references:
    * Publicized copy of `%WrathPath%\Wrath_Data\Managed\Assembly-CSharp.dll`
    * `%WrathPath%\Wrath_Data\Managed\Assembly-CSharp-firstpass.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Core.dll`
    * `$WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.UI.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Validation.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Visual.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.CoreModule.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityModManager\0Harmony.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityModManager\UnityModManager.dll`
6. Configure DLL Merging:
    * Install [ILRepack.MSBuild.Task](https://www.nuget.org/packages/ILRepack.MSBuild.Task/) using NuGet
    * Add the following to your .csproj file, using your mod's assembly name in place of `MyAssemblyName`:
    ```xml
    <!-- DLL Merging -->
    <Target Name="ILRepack" AfterTargets="Build">
      <ItemGroup>
        <InputAssemblies Include="BlueprintCore.dll" />
        <InputAssemblies Include="MyAssemblyName.dll" />
        <OutputAssembly Include="MyAssemblyName.dll" />
      </ItemGroup>
    
      <Message Text="Merging: @(InputAssemblies) into @(OutputAssembly)" Importance="High" />

      <ILRepack
        OutputType="Dll"
        MainAssembly="MyAssemblyName.dll"
        OutputAssembly="@(OutputAssembly)"
        InputAssemblies="@(InputAssemblies)"
        WorkingDirectory="$(OutputPath)" />
    </Target>
    ```
    * ILRepack requires your game assembly to have the file name `Assembly-CSharp.dll`. By default the publicizer creates `Assembly-CSharp_public.dll`. To resolve this update your assembly reference and publicize target in your project file:
    ```xml
    <ItemGroup>
      <Reference Include="Assembly-CSharp">
        <HintPath>$(SolutionDir)lib\Assembly-CSharp.dll</HintPath>
      </Reference>
    </ItemGroup>

    <!-- Publicize Target -->
    <Target Name="Publicize" AfterTargets="Clean">
      <ItemGroup>
        <Assemblies Include="$(WrathPath)\Wrath_Data\Managed\Assembly-CSharp.dll" />
        <PublicAssembly Include="$(SolutionDir)\lib\Assembly-CSharp_public.dll" />
        <RenamedAssembly Include="$(SolutionDir)\lib\Assembly-CSharp.dll" />
      </ItemGroup>

      <PublicizeTask InputAssemblies="@(Assemblies)" OutputDir="$(SolutionDir)lib/" />
      <Move SourceFiles="@(PublicAssembly)" DestinationFiles="@(RenamedAssembly)" />
    </Target>
    ```
7. You're ready to go!

If you already have a project or are having trouble, take a look at [BlueprintCore Tutorial.csproj](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCore%20Tutorial/BlueprintCore%20Tutorial/BlueprintCore%20Tutorial.csproj).

Your project file should look almost identical to the tutorial project file, with the exception that you may have additional package and assembly references. In particular make sure:

* Your publicized assembly is called `Assembly-CSharp.dll`
* Your assembly references do not set `<Private>false</Private>`
* All referenced assemblies are included

Without these `ILRepack` will fail.

## Using BlueprintCore

For a step-by-step walkthrough see [Tutorials](tutorials/overview.md).

If you're having problems check [Known Issues](issues.md).

If you're interested in contributing see [How to Contribute](contributing.md).

Below is an overview of the basic features of BlueprintCore and how to use them.

### Blueprint Configurators

For every blueprint type inheriting from `BlueprintScriptableObject` there is a corresponding configurator. e.g. [BuffConfigurator](xref:BlueprintCore.Blueprints.Configurators.Buffs.BuffConfigurator) is the configurator for `BlueprintBuff`.

Blueprint types not used in the base game do not have configurators and should not be used.

#### Basic Usage

1. Creating a new Blueprint
```C#
// Creates a feature with the provided name and guid. Once this is called the blueprint is registered in the game
// library and is accessible, but has nothing configured.
FeatureConfigurator.New(FeatName, FeatGuid)
  // Sets the m_DisplayName field inherited from BlueprintUnitFact to the created localized string.
  .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
  // Sets the Groups field.
  .SetGroups(FeatureGroup.Feat)
  // Adds a BuffSkillBonus component which increases the Knowledge Arcana skill by 2.
  .AddBuffSkillBonus(StatType.SkillKnowledgeArcana, 2)
  // Commits changes to the blueprint and returns the configured blueprint. If any validation errors are detected it
  // logs a warning.
  .Configure();
```
2. Modify an existing Blueprint
```C#
// Fetches the BlueprintFeatureSelection from the game library with the provided guid. In this case it is the selection
// for all general feats available in the game.
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  // Adds the feat referenced by FeatName to the blueprint field m_AllFeatures.
  .AddToAllFeatures(FeatName)
  // Commits changes to the blueprint and returns the configured blueprint. If any validation errors are detected it
  // logs a warning.
  .Configure();
```

#### Adding Components

Every supported component has at least one AddX method where X is the component type, e.g. `AddBuffSkillBonus` in `FeatureConfigurator`. Through community contributions Some components have multiple methods based on usage. For example, `PrerequisiteParametrizedFeature` is implemented in three methods: AddPrerequisiteParametrizedSpellFeature, AddPrerequisiteParametrizedWeaponFeature, and AddPrerequisiteParametrizedWeaponFeature.

Some component types are unique: only one component should exist in a given blueprint. By default adding a second unique component will result in a failure but you can override this to skip or provide a merging function to combine the two components. For more details see [ComponentMerge](xref:BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge).

```C#
FeatureConfigurator.For(FeatGuid)
  // Ignores the change if the feat already has this prerequisite.
  // This could happen if another mod or a game patch released after your mod adds it already.
  .AddPrerequisiteIsPet(mergeBehavior: ComponentMerge.Skip)
  .Configure();
```

#### Modifing Fields

Fields are implemented through several methods. Note that for the purpose of naming, internal prefixes are removed so m_Spell is treated as Spell.

* SetX - Sets the value of X
    * All exposed fields have this method
```C#
FeatureConfigurator.New(FeatName, FeatGuid)
  .SetGroups(FeatureGroup.Feat)
  .Configure();
```
* ModifyX - Modifies X by invoking a provided `Action`
    * All non-primitive, non-enum fields have this method
    * For lists and arrays the action is invoked on each element
```C#
AbilityConfigurator.For(AbilityGuid)
  .ModifyDefaultAiAction(aiAction => UpdateDefaultAiAction(aiAction))
  .Configure();
```
* AddToX - Adds elements to X
    * All list and array fields have this method
    * Bitflag fields have this method
```C#
FeatureConfigurator.New(FeatName, FeatGuid)
  .AddToGroups(FeatureGroup.Feat)
  .Configure();
```
* RemoveFromX - Removes elements from X
    * All list and array fields have this method
    * Bitflag fields have this method
```C#
FeatureConfigurator.For(FeatGuid)
  .RemoveFromGroups(FeatureGroup.Feat)
  .Configure();
```
* RemoveFromX (Predicate) - Removes elements from X matching the provided predicate
    * All list and array fields have this method
```C#
FeatureConfigurator.New(FeatName, FeatGuid)
  .RemoveFromGroups(group => group == FeatureGroup.Feat)
  .Configure();
```
* Clear - Clears the value of X
    * All list and array fields have this method
```C#
FeatureConfigurator.For(FeatName)
  .ClearGroups()
  .Configure();
```

#### Advanced Usage

If you wrote your own component or want to use a component from another mod or mod library, you can add components directly through methods in [RootConfigurator](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2):

* [AddComponent](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2.AddComponent(Kingmaker.Blueprints.BlueprintComponent))
    * A typed version of this method exists which accepts an init `Action`
```C#
FeatureConfigurator.New(FeatName, FeatGuid)
  // Both calls are equivalent
  .AddComponent(new MyCustomComponent(someValue))
  .AddComponent<MyCustomComponent>(c => c.Value = someValue)
  .Configure();
```
* [AddUniqueComponent](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2.AddUniqueComponent(Kingmaker.Blueprints.BlueprintComponent,BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge,System.Action{Kingmaker.Blueprints.BlueprintComponent,Kingmaker.Blueprints.BlueprintComponent}))
    * Similar to `AddComponent` but includes support for merging unique components
* [EditComponent](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2.EditComponent``1(System.Action{``0}))
    * Invokes the provided action on the first component matching the specified type
```C#
FeatureConfigurator.For(FeatGuid)
  .EditComponent<ContextRankConfig>(c => UpdateContextRankConfig(c))
  .Configure();
```
* [RemoveComponent](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2.RemoveComponents(System.Func{Kingmaker.Blueprints.BlueprintComponent,System.Boolean}))
    * Removes any components matching the supplied predicate
* [OnConfigure](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2.OnConfigure(System.Action{`0}[]))
    * Invokes the provided `Action` on the blueprint as the last step in configuration

As with all changes to the blueprint, these functions are only applied once `Configure()` is called, and the action provided in `OnConfigure()` is invoked after everything else is done.

#### Customizing Configurators

If you want to extend a configurator to include your own logic you can do so with one limitation: you cannot extend concrete implementations.

To support this the library implements almost all configurator functionality within abstract classes and only exposes `New()` and `For()` in concrete classes. For example, [UISoundConfigurator](xref:BlueprintCore.Blueprints.Configurators.UI.UISoundConfigurator) can be customized by extending [BaseUISoundConfigurator](xref:BlueprintCore.Blueprints.Configurators.UI.BaseUISoundConfigurator`2).

As the library is improved concrete implementations are hand written to include additional logic, e.g. [BuffConfigurator](xref:BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs.BuffConfigurator). Any logic included here would be lost if you choose to create your own BuffConfigurator class.

To implement a custom configurator use this as a template for your class:

```C#
/// <summary>
/// Configurator for <see cref="BlueprintType"/>.
/// </summary>
/// <inheritdoc/>
public class TypeConfigurator : BaseTypeConfigurator<BlueprintType, TypeConfigurator>
{
  private TypeConfigurator(Blueprint<BlueprintType, BlueprintReference<BlueprintType>> blueprint) : base(blueprint) { }

  /// <summary>
  /// Returns a configurator to modify the specified blueprint.
  /// </summary>
  /// <remarks>
  /// <para>
  /// Use this to modify existing blueprints, such as blueprints from the base game.
  /// </para>
  /// <para>
  /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
  /// </para>
  /// </remarks>
  public static TypeConfigurator For(Blueprint<BlueprintType, BlueprintReference<BlueprintType>> blueprint)
  {
    return new TypeConfigurator(blueprint);
  }

  /// <summary>
  /// Creates a new blueprint and returns a new configurator to modify it.
  /// </summary> 
  /// <remarks>
  /// <para>
  /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
  /// </para>
  /// <para>
  /// An implicit cast converts the string to <see cref="Blueprint{T, TRef}"/>, exposing the blueprint instance and its reference.
  /// </para>
  /// </remarks>
  public static TypeConfigurator New(string name, string guid)
  {
    BlueprintTool.Create<BlueprintType>(name, guid);
    return For(name);
  }
}
```

At this point you can create new methods:

```C#
public TypeConfigurator DoSomething()
{
  // Do something
  return this;
}
```

or you can override existing methods:

```C#
public new TypeConfigurator SetField(int fieldValue)
{
  // Do something
  return this;
}
```

In the last example, the use of `new` ensures that the inherited method is hidden and calls will direct to your method instead.

#### New Blueprint Types

In the event that you need a configurator for a blueprint not in the base game you can use [BlueprintConfigurator](xref:BlueprintCore.Blueprints.CustomConfigurators.BlueprintConfigurator`1).

This will not expose all component types or fields, but it provides the method chain API, advanced component methods, and runs validation when configured.

```C#
BlueprintConfigurator<MyBlueprintType>.New()
  .AddComponent(someComponent)
  .OnConfigure(bp => bp.myBlueprintField = someValue)
  .Configure();
```

Notice the usage of `OnConfigure()` to set fields not exposed by the API.

If the blueprint is more complex it may be better to create your own configurator as described above in Customizing Configurators.

### ActionsBuilder and ConditionsBuilder

Actions and conditions in the game are (almost) always used in the form of `ActionList` and `ConditionsChecker`. [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder) provide builder APIs for constructing them. Both APIs behave the same.

#### Basic Usage

```C#
using BlueprintCore.Actions.Builder.ContextEx;

// Creates an ActionsBuilder which grants a buff and triggers a melee attack
var meleeAttack =
  ActionsBuilder.New()
    .ApplyBuff(MyAttackBuff, duration: ContextDuration.Fixed(1))
    .MeleeAttack();
```

You can call `Build()` directly but usually this is not necessary. Actions and conditions are used in the context of blueprints, blueprint components, or other actions and conditions. BlueprintCore APIs all accept builders in place of `ActionList` and `ConditionsChecker`:
```C#
using BlueprintCore.Actions.Builder.ContextEx;

AbilityConfigurator.New(AbilityName, AbilityGuid)
  // Adds an AbilityEffectRunAction component which grants a buff and triggers a melee attack when the ability is used.
  // Build() is called internally by the library.
  .AddAbilityEffectRunAction(
    ActionsBuilder.New()
      .ApplyBuff(MyAttackBuff, duration: ContextDuration.Fixed(1))
      .MeleeAttack())
  .Configure();
```

Notice that both examples included the namespace `BlueprintCore.Actions.Builder.ContextEx`. This is because actions and conditions are implemented using extension classes. Each extension namespace includes a different set of actions and conditions, grouped loosely by usage.

The full breakdown of extension classes is provided in [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder). At a glance:

* AreaEx - Involves the game map, dungeons, or locations
* AVEx - Involves audiovisual effects such as dialogs, camera, cutscenes, and sounds 
* BasicEx - Most non-context actions and conditions related to game mechanics
* ContextEx - Most context actions and conditions related to game mechanics
* KingdomEx - Involves the Kingdom and Crusade system
* MiscEx - Catch-all for uncategorized
* NewEx - New actions and conditions implemented in BlueprintCore
* UpgraderEx - UpgraderOnlyActions (does not exist for conditions)

Only actions or conditions in the extension classes imported will be available in auto-complete or compilation. Usually you only need a single extension class for a given blueprint.

#### Customizing Builders

Builders are implemented almost entirely through extension classes and methods. To add your own methods just create a class and use the extension method syntax:

```C#
public static ActionsBuilder AddMyCustomAction(this ActionsBuilder builder, int someValue)
{
  return builder.Add(ElementTool.Create<MyCustomAction>() { Value = someValue });
}
```

Note the usage of [ElementTool.Create<>()](xref:BlueprintCore.Utils.ElementTool.Create``1). Use this when instantiating types inheriting from `Element` to ensure they are configured properly or it can cause your mod to fail.

#### Advanced Usage

Builders have an `Add()` method which can be used to add any relevant type:

```C#
var actions = ActionsBuilder.New().Add(ElementTool.Create<MyCustomAction>());
```

There is also a version of `Add()` which takes a type argument and init action:

```C#
var actions = ActionsBuilder.New().Add<MyCustomAction>(a => a.Value = someValue);
```

ConditionsBuilder has a special method, [UseOr()](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder.UseOr), which results in the conditions being evaluated using or instead of and logic. i.e. By default all conditions in the builder must pass but calling `UseOr()` means only a single condition needs to pass.

1. Instantiate a builder using `New()`
2. Add actions/conditions using builder methods
    * `ConditionsBuilder` has a special method, [UseOr()](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder.UseOr) which results in a `ConditionsChecker` that will pass if any one condition passes. By default all conditions must pass.
3. Build the list with `Build()`
    * When an `ActionList` or `ConditionsChecker` is needed in a library method you do not need to call `Build()`. Instead the builder is passed into the method directly and `Build()` is called by the library.
    * Calling build logs validation errors as a warning.

## Referencing Blueprints

Many API calls require references to a blueprint. To simplify blueprint references BlueprintCore defines [Blueprint<T, TRef>](xref:BlueprintCore.Utils.Blueprint`2). This provides implicit constructors which allow referencing blueprints by:

* GUID / Asset ID string
```C#
var basicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";
FeatureSelectionConfigurator.For(basicFeatSelectionGuid);
```
* Name string - only applies to blueprint created using BlueprintCore
```C#
FeatureConfigurator.New(FeatName, FeatGuid);
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(FeatName)
  .Configure();
```
* Blueprint instance
```C#
var feat = FeatureConfigurator.New(FeatName, FeatGuid).Configure();
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(feat)
  .Configure();
```
* Blueprint reference
```C#
FeatureConfigurator.New(FeatName, FeatGuid);
var featReference = BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(FeatGuid);
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(featReference)
  .Configure();
```
* Guid
```C#
var basicFeatSelectionGuid = Guid.Parse("247a4068-296e-8be4-2890-143f451b4b45");
FeatureSelectionConfigurator.For(basicFeatSelectionGuid);
```
* BlueprintGuid
```C#
var basicFeatSelectionGuid = BlueprintGuid.Parse("247a4068-296e-8be4-2890-143f451b4b45");
FeatureSelectionConfigurator.For(basicFeatSelectionGuid);
```

When passing in a list or array you can mix and match:
```C#
var feat = FeatureConfigurator.New(FeatName, FeatGuid).Configure();
var myOtherFeatGuid = "247a4068-296e-8be4-2890-143f451b4b46";
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(feat, myOtherFeatGuid)
  .Configure();
```

If you're declaring or storing a list or array you need to declare the correct type for the collection:
```C#
var feat = FeatureConfigurator.New(FeatName, FeatGuid).Configure();
var myOtherFeatGuid = "247a4068-296e-8be4-2890-143f451b4b46";
var newFeats = new Blueprint<BlueprintFeature, BlueprintFeatureReference>[] { feat, myOtherFeatGuid };
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(newFeats)
  .Configure();
```

These examples use configurators but the same approach works for all BlueprintCore APIs.

## Understanding the API

The configurator and builder APIs, with the exception of the builder base classes and configurators in the `BlueprintCore.Blueprints.CustomConfigurators` namespace, are generated code.

Here are some examples to help understand the resulting API:

![Prerequisite Character Class Method](~/images/prerequisite_character_class_method.png)

* This method adds a `PrerequisiteClassLevel` component to the blueprint
* Adding this component requires `characterClass` and `level`
    * By default APIs have no required parameters. This is because it is difficult if not impossible to judge whether a type needs a value for a field specified using static analysis.
    * Since these are required, it indicates this method has been overriden by a manual config indicating that you should always specify these values for a `PrerequisiteClassLevel` component.
* Every other parameter is null, excluding `mergeBehavior`
    * By default all parameters have a default value of null (primitives are handled using nullable types)
    * If you do not provide these parameters the default value of the corresponding field in `PrerequisiteClassLevel` is used
        * Essentially, the API will not set the value of fields that are not specified, barring some exceptions covered in the next example
* BlueprintCore specific parameters are present: `mergeBehavior` and `merge`
    * This indicates the component is unique: there should only be a single copy in any given blueprint
    * These parameters grant control over interactions if there are multiple copies present
  
![Rest Trigger Method](~/images/add_rest_trigger_method.png)

* This method adds an `AddRestTrigger` component to the blueprint
    * The XML doc has a bug here, since the component and method name are the same it resolves incorrectly.
* Adding this component doesn't require anything
    * After using this example, it now requires an `ActionsBuilder`; I updated the config because this component obviously doesn't make sense without one
* Something special happens in the library if no argument is passed in
    * `ActionsBuilder` is used to set an `ActionList` field value, but the game will throw an exception if an `ActionList` field is null
    * To ensure that the `ActionList` is not null, BlueprintCore checks the field value and if it detects a null field it sets it to [Constants.Empty.Actions](xref:BlueprintCore.Utils.Constants.Empty.Actions)

The null handling case is an important one: there are several types in the game library that generally cause problems when null. As a result BlueprintCore APIs will automatically set fields with these types to "empty" defaults. As of writing these types include:

* ActionList
* ConditionsChecker
* ContextDiceValue
* ContextValue
* LocalizedString
* PrefabLink

If you find other types that should never be null please file a [GitHub Issue](https://github.com/WittleWolfie/WW-Blueprint-Core/issues).

Similarly you can file an issue if you think a given method should be implemented differently, usually requiring certain inputs. More details on providing this feedback are in [How to Contribute](contributing.md).

### Limitations

BlueprintCoreGen analyzes the game library and combines that data with community provided configuration overrides to generate methods and classes which wrap common game types. The goal is to provide an API with minimal boilerplate which enforces proper usage of game types as much as possible, but there are some limitations to this approach:

* Hand tuning code can be more complicated than simply writing a function
    * Specific configuration paths are required for any code output and it's not always easy to logically define this
* When the game API changes, so does the BlueprintCore API
    * This leads to breaking changes at times, though generally this means the code you wrote would break anyways
    * So far only Patch 1.2 has truly introduced breaking changes
* When the community adds configuration overrides, the BlueprintCore API changes
    * This leads to break changes for anyone using those functions

Generally API breaking changes are limited to basic things like renaming methods or method parameters. These should be trivial to update between versions, but it is something to keep in mind when using BlueprintCore.

## Logging and Utils

### Tools

Tool classes provide simple utility functions, usually related to a specific type. See each class for more details, but some notable uses:

* [BlueprintTool](xref:BlueprintCore.Utils.BlueprintTool)
    * Use this to create, fetch, and provide a name to guid mapping for blueprints
* [ElementTool](xref:BlueprintCore.Utils.ElementTool)
    * Use this to create or initialize types inheriting from `Element`
* [PrereqTool](xref:BlueprintCore.Utils.PrereqTool)
    * Use this to create types inheriting from `Prerequisite`

### Type Constructors

Utility classes are provided to simplify creating game objects.

* [ContextDuration](xref:BlueprintCore.Utils.Types.ContextDuration)
```C#
var contextDuration = ContextDuration.Fixed(2);
```
* [ContextValues](xref:BlueprintCore.Utils.Types.ContextValues)
```C#
var contextValue = ContextValues.Rank();
```
* [ContextRankConfigs](xref:BlueprintCore.Utils.Types.ContextRankConfigs)
```C#
var contextRankConfig = ContextRankConfigs.BaseAttack().WithDivStepProgression(2);
```
* [UnitConditionException](xref:BlueprintCore.Utils.Types.UnitConditionException)
```C#
var unitConditionException = UnitConditionException.TargetHasFeatures(FeatureGuid1, FeatureGuid2);
```
    
### Logging

[LogWrapper](xref:BlueprintCore.Utils.LogWrapper) wraps the game's `LogChannel` class to provide control over verbose log output.

It is used internally for logging within BlueprintCore and is available for use within your modification, but not required.

```C#
private static readonly LogWrapper ModLogger = LogWrapper.Get("MyMod");
private static readonly LogWrapper FeatLogger = LogWrapper.Get("Feats");

ModLogger.Info("Mod initialized.");
FeatLogger.Info.("Feat initialized.");
```

The output to the log from the above example is:

```
BlueprintCore.MyMod: Mod initialized.
BlueprintCore.Feats: Mod initialized.
```

Log output is available locally in `%APPDATA%\..\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\GameLogFull.txt` or in [Remote Console](https://github.com/OwlcatOpenSource/RemoteConsole/releases).

Log output uses the `Mods` channel currently.

### Validator

[Validator](xref:BlueprintCore.Utils.Validator) is used by the library to validate method inputs, actions, conditions, blueprint components, and blueprints.

You can also use it separately for any game objects created outside of the library:

```C#
private static readonly LogWrapper ModLogger = LogWrapper.Get("MyMod");

var validator = new Validator("MyValidator", "BlueprintBuff");
validator.Check(myBuff);
validator.Check(myBuffActions);
if (validator.HasErrors())
{
  ModLogger.Warning(validator.GetErrorString());
}
```

Once you create a `Validator`, you can call `Check()` for any objects related to it and they will all be bundled into the same error validation string.
