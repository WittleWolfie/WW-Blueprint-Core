# Understanding the API

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

## Limitations

BlueprintCoreGen analyzes the game library and combines that data with community provided configuration overrides to generate methods and classes which wrap common game types. The goal is to provide an API with minimal boilerplate which enforces proper usage of game types as much as possible, but there are some limitations to this approach:

* Hand tuning code can be more complicated than simply writing a function
    * Specific configuration paths are required for any code output and it's not always easy to logically define this
* When the game API changes, so does the BlueprintCore API
    * This leads to breaking changes at times, though generally this means the code you wrote would break anyways
    * So far only Patch 1.2 has truly introduced breaking changes
* When the community adds configuration overrides, the BlueprintCore API changes
    * This leads to breaking changes for anyone using those functions

Generally API breaking changes are limited to basic things like renaming methods or method parameters. These should be trivial to update between versions, but it is something to keep in mind when using BlueprintCore.