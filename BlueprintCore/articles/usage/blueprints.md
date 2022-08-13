# Blueprints

Blueprints form the basis of most game mechanics. Feats, abilities, spells, classes, dialogs, quests, and more are defined using blueprints.

Modifying existing or creating new blueprints is accomplished in BPCore using Blueprint Configurators.

## Blueprint Configurators

For every blueprint type inheriting from `BlueprintScriptableObject` there is a corresponding configurator. e.g. [BuffConfigurator](xref:BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs.BuffConfigurator) is the configurator for `BlueprintBuff`.

Blueprint types not used in the base game do not have configurators and should not be used.

### Basic Usage

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

### Adding Components

Every supported component has at least one AddX method where X is the component type, e.g. `AddBuffSkillBonus` in `FeatureConfigurator`. Through community contributions Some components have multiple methods based on usage. For example, `PrerequisiteParametrizedFeature` is implemented in three methods: AddPrerequisiteParametrizedSpellFeature, AddPrerequisiteParametrizedWeaponFeature, and AddPrerequisiteParametrizedWeaponFeature.

Some component types are unique: only one component should exist in a given blueprint. By default adding a second unique component will result in a failure but you can override this to skip or provide a merging function to combine the two components. For more details see [ComponentMerge](xref:BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge).

```C#
FeatureConfigurator.For(FeatGuid)
  // Ignores the change if the feat already has this prerequisite.
  // This could happen if another mod or a game patch released after your mod adds it already.
  .AddPrerequisiteIsPet(mergeBehavior: ComponentMerge.Skip)
  .Configure();
```

### Modifying Fields

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

### Advanced Usage

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

### Customizing Configurators

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
  private TypeConfigurator(Blueprint<BlueprintReference<BlueprintType>> blueprint) : base(blueprint) { }

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
  public static TypeConfigurator For(Blueprint<BlueprintReference<BlueprintType>> blueprint)
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
  /// An implicit cast converts the string to <see cref="Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
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

### New Blueprint Types

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

## Referencing Blueprints

> [!TIP]
> For many blueprint types there is a "Refs" class with static fields for referencing existing blueprints, e.g. [FeatureRefs.AcidImmunity](xref:BlueprintCore.Blueprints.References.FeatureRefs.AcidImmunity). You can also iterate through all blueprints using the `All` field, e.g. [FeatureRefs.All](xref:BlueprintCore.Blueprints.References.FeatureRefs.All).

Many API calls require references to a blueprint. To simplify blueprint references BlueprintCore defines [Blueprint<TRef>](xref:BlueprintCore.Utils.Blueprint`1). This provides implicit constructors which allow referencing blueprints by:

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
var featReference = BlueprintTool.GetRef<BlueprintFeatureReference>(FeatGuid);
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
var newFeats = new Blueprint<BlueprintFeatureReference>[] { feat, myOtherFeatGuid };
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(newFeats)
  .Configure();
```

Note that you can also cast stored collections:
```C#
List<BlueprintFeatureReference> features = new() { myNewFeature.ToReference(), myOtherNewFeature.ToReference() };
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid)
  .AddToAllFeatures(features.Cast<Blueprint<BlueprintFeatureReference>>().ToArray())
  .Configure();
```

These examples use configurators but the same approach works for all BlueprintCore APIs.