# Text, Logging, Unity Assets, and Utils

While the bulk of the functionality of BPCore is implemented in [Blueprint Configurators](blueprints.md) and [Builders](builders.md), there are many utility classes that provide additional functionality.

## Text

To display text in game you need to create a `LocalizedString` with a key used to look up the text for the appropriate locale / language.

Using BPCore you can define text in JSON file containing a [MultiLocaleString](xref:BlueprintCore.Utils.Localization.MultiLocaleString) array, such as this example from the [Feat Tutorial](~/articles/tutorials/feat.md):

```json
[
  {
    "Key": "MagicalAptitude.Name",
    "ProcessTemplates": false,
    "enGB": "Magical Aptitude",
    "deDE": "Magische Begabung"
  },

  {
    "Key": "MagicalAptitude.Description",
    "enGB": "You get a +2 bonus on all Spellcraft and Use Magic Device skill checks. If you have 10 or more ranks in one of these skills, the bonus increases to +4 for that skill."
  }
]
```

By default BPCore uses the file `LocalizedStrings.json` in the same folder as your mod assembly; the same location as the `Info.json` file for a UMM mod. You can override this by calling [LocalizationTool.LoadLocalizationPack()](xref:BlueprintCore.Utils.LocalizationTool.LoadLocalizationPack(System.String)) and providing your own file.

### Localized Values

In your JSON file you can provide a value for each locale supported in-game: `enGB`, `ruRU`, `deDE`, `frFR`, `zhCN`, and `esES`. You must specify `enGB` as it is used for any locale without a value.

Referencing `MagicalAptitude.Name` when the locale is `enGB` results in "Magical Aptitude" and "Magische Begabung" when the locale is set to `deDE`.

### Template Processing

By default `ProcessTemplates` is true. When set to true:

* [EncyclopediaTool.TagEncyclopediaEntries()](xref:BlueprintCore.Utils.EncyclopediaTool.TagEncyclopediaEntries(System.String)) is called (English only)
    * Generates links to the in-game encyclopedia for relevant entries such as `Strength` or `DC`
* The game's `TextTemplateEngine` is used to process the string
    * Converts placeholder strings into output, e.g. `{name}` is replaced by the character's name

> [!TIP]
> Set `ProcessTemplates` to false for most feature names to ensure there are no UI bugs. Features like encyclopedia links don't work propertly for feature names.

Below is a list of template placeholders as of writing this doc, but the source of truth is the game's code in `TextTemplateEngine`.

* `{mf}`, MaleFemaleTemplate()
* `{race}`, RaceTemplate()
* `{name}`, NameTemplate()
* `{kingdomname}`, KingdomNameTemplate()
* `{date}`, DateTemplate()
* `{time}`, TimeTempate()
* `{custom_companion_cost}`, CustomCompanionCostTemplate()
* `{respec_cost}`, RespecCostTemplate()
* `{leader_cost}`, LeaderCostTemplate()
* `{flag}`, FlagTemplate()
* `{n}`, NarratorStartTemplate()
* `{/n}`, NarratorEndTemplate()
* `{g}`, TooltipStartTemplate(TooltipType.Glosary)
* `{/g}`, TooltipEndTemplate(TooltipType.Glosary)
* `{d}`, TooltipStartTemplate(TooltipType.Decisions)
* `{/d}`, TooltipEndTemplate(TooltipType.Decisions)
* `{m}`, TooltipStartTemplate(TooltipType.Mechanics)
* `{/m}`, TooltipEndTemplate(TooltipType.Mechanics)
* `{mf_Regent}`, LeaderMaleFemaleTemplate(LeaderType.Counselor)
* `{mf_Counsilor}`, LeaderMaleFemaleTemplate(LeaderType.Strategist)
* `{mf_GrandDiplomat}`, LeaderMaleFemaleTemplate(LeaderType.Diplomat)
* `{mf_Magister}`, LeaderMaleFemaleTemplate(LeaderType.General)
* `{mf_General}`, LeaderMaleFemaleTemplate(LeaderType.General)
* `{target}`, LogTemplateTarget()
* `{formula}`, LogTemplateFormula()
* `{source}`, LogTemplateSource()
* `{text}`, LogTemplateText()
* `{text_with_tags}`, LogTemplateTextWithTags()
* `{description}`, LogTemplateDescription()
* `{count}`, LogTemplateCount()
* `{count_form}`, LogTemplateCountForm()
* `{roll}`, LogTemplateRoll()
* `{d20}`, LogTemplateD20()
* `{d100}`, LogTemplateD100()
* `{mod}`, LogTemplateModifier()
* `{dc}`, LogTemplateDC()
* `{chance_dc}`, LogTemplateChanceDC()
* `{roll_chance}`, LogTemplateRollChance()
* `{slotname}`, UITemplateEquipedItem()
* `{wielder}`, UITemplateItemWielder()
* `{rations}`, UITemplateRations()
* `{recipe}`, UITemplateSimpleText()
* `{attack_number}`, LogTemplateAttackNumber()
* `{attacks_count}`, LogTemplateAttacksCount()
* `{round}`, LogTemplateRound()
* `{claimed_villages_count}`, SettlementsCountTemplate(SettlementState.LevelType.Village)
* `{claimed_towns_count}`, SettlementsCountTemplate(SettlementState.LevelType.Town)
* `{claimed_cities_count}`, SettlementsCountTemplate(SettlementState.LevelType.City)
* `{portraits_path}`, UITemplatePartraitsPath()
* `{area_name}`, UITemplateAreaName()
* `{bind}`, KeyBindingTemplate()
* `{console_bind}`, ConsoleBindingTemplate()
* `{empty}`, EmptyTemplate()
* `{br}`, LineBreakTemplate()
* `{pc_console}`, PcConsoleTemplate()
* `{t}`, TutorialDataTemplate()
* `{ui}`, UITemplate()

### Referencing Text

In BPCore APIs that set text values accept a [LocalString](xref:BlueprintCore.Utils.LocalString) parameter. To specify a text value from this file use the key:

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName("MagicalAptitude.Name")
    .SetDescription("MagicalAptitude.Description")
    .Configure();
```

You can also reference text already in the game by the key.

If you have a `LocalizedString` you can use it directly:

```C#
LocalizedString magicalAptitudeName = LocalizationTool.CreateString(FeatNameKey, FeatName, tagEncyclopediaEntries: false);
LocalizedString magicalAptitudeDescription = LocalizationTool.CreateString(FeatDescriptionKey, FeatDescription);

FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName(magicalAptitudeName)
    .SetDescription(magicalAptitudeDescription")
    .Configure();
```

Using [LocalizationTool.CreateString()](xref:BlueprintCore.Utils.LocalizationTool.CreateString(System.String,System.String,System.Boolean)) is not recommended; it only works for a single locale and fails if the user changes locale mid-game.

Passing in a `LocalizedString` directly is useful if you are using [TabletopTweaks-Core](https://github.com/Vek17/TabletopTweaks-Core) localization or referencing text copied from an existing blueprint.

## Logging

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

## Unity Assets

BPCore supports importing assets from a Unity AssetBundle included in your mod. Using [Unity](https://unity3d.com/get-unity/download/archive) (version `2019.4.26f1`), create an AssetBundle called `assets` and place it in the same diretory as your assembly. For a walkthrough of generating an AssetBundle see the [Skald's Vigor Tutorial](~/tutorials/advanced/skalds_vigor.md#create-an-assetbundle).

When a BPCore API needs an asset it requests an [Asset<T>](xref:BlueprintCore.Utils.Assets.Asset`1) or [AssetLink<TLink>](xref:BlueprintCore.Utils.Assets.AssetLink`1. You can provide these directly or by Asset ID. Unity usually defines the Asset ID using the file path relative to the Unity project directory, e.g. `MyUnityProject/assets/icons/myicon.png` is referenced using `assets/icons/myicon.png`. If you're ever unsure, look in the `assets.manifest` file in the same directory as the `assets` bundle or the bottom of the inspector tab in Unity.

```C#
BuffConfigurator.New(BuffName, BuffGuid)
  .SetDisplayName(BuffDisplayName)
  .SetDescription(BuffDescription)
  .SetIcon("assets/icons/myicon.png")
  .Configure();
```

This works regardless of whether an asset or an asset link, e.g. `SpriteLink`, is required.

If you want to directly load the resource call `ResourcesLibrary.TryGetResource<Sprite>()`:

```C#
var myIconSprite = ResourcesLibraryTryGetResource<Sprite>("assets/icons/myicon.png");
```

## Tools

Tool classes provide simple utility functions, usually related to a specific type. See each class for more details, but some notable uses:

* [BlueprintTool](xref:BlueprintCore.Utils.BlueprintTool)
    * Use this to create, fetch, and provide a name to guid mapping for blueprints
* [ElementTool](xref:BlueprintCore.Utils.ElementTool)
    * Use this to create or initialize types inheriting from `Element`
* [PrereqTool](xref:BlueprintCore.Utils.PrereqTool)
    * Use this to create types inheriting from `Prerequisite`

## Type Constructors

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

## Validator

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
