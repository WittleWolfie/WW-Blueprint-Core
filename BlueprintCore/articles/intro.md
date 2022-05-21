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

#### Basic Operations

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

##### Adding Components

Every supported component has at least one AddX method where X is the component type, e.g. `AddBuffSkillBonus` in `FeatureConfigurator`. Through community contributions Some components have multiple methods based on usage. For example, `PrerequisiteParametrizedFeature` is implemented in three methods: AddPrerequisiteParametrizedSpellFeature, AddPrerequisiteParametrizedWeaponFeature, and AddPrerequisiteParametrizedWeaponFeature.

Some component types are unique: only one component should exist in a given blueprint. By default adding a second unique component will result in a failure but you can override this to skip or provide a merging function to combine the two components. For more details see [ComponentMerge](xref:BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge).

```C#
FeatureConfigurator.For(FeatGuid)
  // Ignores the change if the feat already has this prerequisite.
  // This could happen if another mod or a game patch released after your mod adds it already.
  .AddPrerequisiteIsPet(mergeBehavior: ComponentMerge.Skip)
  .Configure();
```

##### Modifing Fields

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

#### Referencing Blueprints

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
* [AddUniqueComponent](xref:BlueprintCore.Blueprints.CustomConfigurators.RootConfigurator`2.AddComponent(Kingmaker.Blueprints.BlueprintComponent,BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge,System.Action{Kingmaker.Blueprints.BlueprintComponent,Kingmaker.Blueprints.BlueprintComponent}))
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

To support this the library implements almost all configurator functionality within abstract classes and only exposes `New()` and `For()` in concrete classes. For example, [UISoundConfigurator](xref:BlueprintCore.Blueprints.Configurators.UI.UISoundConfigurator) can be customized by extending [BaseUISoundConfigurator](xref:BlueprintCore.Blueprints.Configurators.UI.BaseUISoundConfigurator-2).

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

In the event that you need a configurator for a blueprint no in the base game you can use [BlueprintConfigurator](xref:BlueprintCore.Blueprints.CustomConfigurators.BlueprintConfigurator`1).

This will not expose all component types or fields, but it provides the method chain API, advanced component methods, and runs validation when configured.

```C#
BlueprintConfigurator<MyBlueprintType>.New()
  .AddComponent(someComponent)
  .OnConfigure(bp => bp.myBlueprintField = someValue)
  .Configure();
```

Notice the usage of `OnConfigure()` to set fields not exposed by the API.

If the blueprint is more complex it may be better to create your own configurator as described above in Customizing Configurators.

## ActionsBuilder and ConditionsBuilder

Actions and conditions in the game are always used in the form of `ActionList` and `ConditionsChecker`. [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder) provide builder APIs for constructing them.

Basic usage both builders is the same:

1. Instantiate a builder using `New()`
2. Add actions/conditions using builder methods
    * `ConditionsBuilder` has a special method, [UseOr()](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder.UseOr) which results in a `ConditionsChecker` that will pass if any one condition passes. By default all conditions must pass.
3. Build the list with `Build()`
    * When an `ActionList` or `ConditionsChecker` is needed in a library method you do not need to call `Build()`. Instead the builder is passed into the method directly and `Build()` is called by the library.
    * Calling build logs validation errors as a warning.

Builder methods declare the game type they implement in their comment summary.

### Extensions

To limit the number of actions and conditions available when using [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder), specific types are implemented in extension methods.

Extension methods are logically grouped so most of the time you can include a single extension namespace. The extension groups are the same for both builders:

* AreaEx
    * Extensions involving the game map, dungeons, or locations
    * Types specifically related to the Kingdom and Crusade system are in KingdomEx
* AVEx
    * Extensions involving audiovisual effects such as dialogs, camera, cutscenes, and sounds
    * `ActionsBuilder` only
* BasicEx
    * Extensions for most game mechanics not included in ContextEx
* ContextEx
    * Extensions for `ContextAction` and `ContextCondition` types
    * Some types are implemented in more specific extensions such as KingdomEx
* KingdomEx
    * Extensions for the Kingom and Crusade systems
* MiscEx
    * Extensions that are not game mechanics related and don't fit into other categories
    * Examples include things like achievement related actions
* NewEx
    * Extensions for types provided by BlueprintCore
* StoryEx
    * Extensions related to the story such as companion stories, quests, and etudes
* UpgraderEx
    * Extensions for all `UpgraderOnlyActions` types
    * `ActionsBuilder` only

### Quick Example: Melee Attack

The following snippet creates a new `ActionList` that initiates a melee attack if the target is in melee range.

```
// Extension for MeleeAttack() which is a ContextAction
using BlueprintCore.Actions.Builder.ContextEx;
// Extension for TargetInMeleeRange() which is a new condition in the library
using BlueprintCore.Conditions.Builder.NewEx;

ActionsBuilder.New()
    .Conditional(
        ConditionsBuilder.New().TargetInMeleeRange(),
        ifTrue: ActionsBuilder.New().MeleeAttack())
    .Build();
```

## Referencing Blueprints

When a blueprint reference is required the API accepts a `string` argument. The argument can be the guid for the blueprint or it can be the name of the blueprint if you have registered a name to guid mapping using [BlueprintTool#AddGuidsByName()](xref:BlueprintCore.Utils.BlueprintTool.AddGuidsByName(System.Collections.Generic.Dictionary{System.String,System.String})). Blueprints created using [BlueprintTool#Create(string, string)](xref:BlueprintCore.Utils.BlueprintTool.Create``1(System.String,System.String)) automatically register the name to guid mapping.

The parameter comment declares the type of blueprint reference expected.

## Generated Methods

The majority of the API is implemented using generated code. These methods are identified by the [GeneratedAttribute](xref:BlueprintCore.Utils.GeneratedAttribute).

Generated methods have a parameter for every field in the object, essentially acting as a constructor. To minimize boilerplate generated methods declare most parameters as optional.

This is not an indication of how the object should be used. Optional parameters in a generated method may be required for the object to function. In contrast, non-generated methods expose strict APIs that only declare parameters optional when they are not needed.

If you identify methods in need of manual implementations please report them. This should be reserved for complex objects with a large number of fields or complex requirements for its fields.

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

* [ContextDuration](xref:BlueprintCore.Utils.ContextDuration)
    * Creates `ContextDurationValue`
* [ContextValues](xref:BlueprintCore.Utils.ContextValues)
    * Creates `ContextValue`
* [ContextRankConfigs](xref:BlueprintCore.Blueprints.Components.ContextRankConfigs)
    * Creates `ContextRankConfig`
* [ResourceAmountBuilder](xref:BlueprintCore.Blueprints.Configurators.Abilities.ResourceAmountBuilder)
    * Creates `BlueprintAbilityResource.Amount`
    
### Logging

[LogWrapper](xref:BlueprintCore.Utils.LogWrapper) wraps the game's `LogChannel` class to provide control over verbose log output. It is used internally for logging within BlueprintCore and is available for use within your modification, but not required.

### Validator

[Validator](xref:BlueprintCore.Utils.Validator) is used by the library to validate method inputs, actions, conditions, blueprint components, and blueprints. Any game objects you create outside of the library can be validated using [Validator#Check()](xref:BlueprintCore.Utils.Validator.Check(System.Object)).
