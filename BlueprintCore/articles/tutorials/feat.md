# Adding a Feat

The first feat is [Magical Aptitude](https://aonprd.com/FeatDisplay.aspx?ItemName=Magical%20Aptitude).

Create a new folder in your project called `Feats`. Here is where you can add classes that create or modify feats.

Inside the feats folder create a new class called `MagicalAptitude`.

Mechanics in Wrath are usually represented by Blueprints. The wiki page on [Blueprints](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) goes into more detail, but for now just know that a feat is a `BlueprintFeature`. To create a feat we'll we'll use [FeatureConfigurator](xref:BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator).

### Creating the Feat

Define a method, `Configure`, which will create the feat when called:

```C#
public class MagicalAptitude
{
  public static void Configure()
  {
    // TODO: Create the feat!
  }
}
```

Creating a blueprint requires a Guid and name. The Guid is a unique identifier and the name is a human readable identifier. For ease of use and readability define them in `static readonly` fields:

```C#
public class MagicalAptitude
{
  private static readonly string FeatName = "MagicalAptitudeFeat";
  private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";
}
```
> [!TIP]
> There are many tools to generate a Guid, use whichever you prefer. In Visual Studio you can generate one using **Tools > Create GUID**. In C# you can generate them by calling [Guid.NewGuid()](https://docs.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=net-6.0#System_Guid_NewGuid), but you'll need to save and store it for a stable identifier.

Now create the feat:

```C#
FeatureConfigurator.New(FeatName, FeatGuid).Configure();
```

When `New()` is called it creates a new `BlueprintFeature` with the specified name and Guid, adds it to the game library, then returns the FeatureConfigurator. Once `Configure()` is called changes made to the blueprint are committed, the blueprint is validated, and the blueprint is returned.

### Selecting the Feat

At this point the feat exists but has no effect and can't be selected. To fix this we need to add it to a `BlueprintFeatureSelection`. BlueprintFeatureSelection defines a list of features you can select during character creation or advancement, e.g. feats, deities, and backgrounds.

There are many feat lists in game including `BasicFeatSelection` as well as feats tied to specific character options such as `WizardFeatSelection` which contains feats a wizard can choose as a bonus feat.

If you know exactly which lists you want to add your feat to you can use [FeatureSelectionConfigurator](xref:BlueprintCore.Blueprints.Configurators.Classes.Selection.FeatureSelectionConfigurator):

```C#
FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection).AddToAllFeatures(MyFeat).Configure();
```

> [!TIP]
> BPCore includes static references to many game blueprints in [References](xref:BlueprintCore.Blueprints.References).

When `For()` is called the `BlueprintFeatureSelection` for BasicFeatSelection is fetched and its FeatureSelectionConfigurator is returned.

When you call a configurator function such as `AddToAllFeatures()` two things happen:

1. The requested change is staged, but not committed until `Configure()` is called
2. The configurator is returned

This allows you to create a single statement to configure a blueprint, calling `Configure()` when you're done:

```C#
// SetX and SetY are just placeholders
FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection)
  .AddToAllFeatures(FeatName)
  .SetX(x)
  .SetY(y)
  .Configure();
```

> [!TIP]
> The first step to adding new content is understanding how existing content is implemented. There are several tools at your disposal discussed on the [wiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources). I recommend [BubblePrints](https://github.com/factubsio/BubblePrints) for exploring game content and [DataViewer](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/9) for validating your changes in-game.

Using the tools above you'll see hundreds of BlueprintFeatureSelection lists.

Luckily you don't need to know every list your feat should be on. Instead you can specify the corresponding `FeatureGroups`:

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat).Configure();
```

The configurator adds the feature to any BlueprintFeatureSelection with a matching `Group` or `Group2` field.

> [!NOTE]
> You will need to read the game code to figure things out. Pick your choice of [decompiler](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources#decompilers) and open up `%WrathPath%/Wrath_Data/Managed/Assembly-CSharp.dll`.

You need one more change before you can start testing: call `MagicalAptitude.Configure()` from the `BlueprintsCache` init patch.

> [!IMPORTANT]
> Always wrap blueprint creation and modification in a try/catch block which logs errors. This prevents the game from hanging and ensures errors are reported to the log.

```C#
[HarmonyPatch(typeof(BlueprintsCache))]
static class BlueprintsCaches_Patch
{
  // Uses BlueprintCore's LogWrapper which uses Owlcat's internal logging.
  // Logs to `%APPDATA%\..\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\GameLogFull.txt` and the Mods
  // channel in RemoteConsole.
  private static readonly LogWrapper Logger = LogWrapper.Get("MagicalAptitude");
  private static bool Initialized = false;

  [HarmonyPriority(Priority.First)]
  [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
  static void Postfix()
  {
    try
    {
      if (Initialized)
      {
        Logger.Info("Already initialized blueprints cache.");
        return;
      }
      Initialized = true;
      
      Logger.Info("Patching blueprints.");
      MagicalAptitude.Configure();
    }
    catch (Exception e)
    {
      Logger.Error("Failed to initialize.", e);
    }
  }
}
```

> [!NOTE]
> You can also use UMM's log: `ModSettings.ModEntry.Logger`. This logs to the `Player.log` file in the same directory as Owlcat's logging.

### Testing Your Changes

Now build the mod, install it, and start the game. When you level or create a character you should see the feat in the selection UI.

> [!WARNING]
> Don't test mods on a real save file or you run the risk of breaking it.

> [!TIP]
> Tools such as [ToyBox](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/8) are useful when testing mods. The cheats provided can spawn enemies, level characters, and generally set the game state to whatever you need for testing.

![Magical Aptitude showing in feat selection](~/images/magical_aptitude/feat_displaying.png)

> [!TIP]
> If the feat doesn't appear check the logs for any errors.

#### Automatic Mod Deployment

Modding requires you to frequently build, deploy, and test changes. To simplify this, configure the project to automatically deploy the mod after it builds. See [Getting Started#Optional: Automatic Mod Deployment](~/articles/intro.md#optional-automatic-mod-deployment) for instructions.

### Fixing the UI

If you click on it nothing works and you probably wante a name other than <c>null</c>. Open up your `LocalizedStrings.json` file and add new entries for the name and description:

```json
[
  {
    "Key": "MagicalAptitude.Name",
    // Don't process this since it is just a name. Without this it might create strange artifacts by trying to create
    // links to encycolpedia pages.
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

Now populate the `m_DisplayName` and `m_Description` fields of the blueprint:

```C#
public static void Configure()
{
  FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
      .SetDisplayName("MagicalAptitude.Name")
      .SetDescription("MagicalAptitude.Description")
      .Configure();
}
```

Test again and the feat should have a name and description! If you change the language to German you should see the name of the feat update, though the description will stay the same.

You may have noticed the feat icon was the stylized letters "MAF". If you don't provide an icon the game generates one using the name, in this case **M**agical**A**ptitude**F**eat. Since abilities often require multiple blueprints it is recommended to append the mechanical type, i.e. Feat, to blueprint names.

Magical Aptitude only requires one blueprint so you can drop "Feat" to get the letters "MA": **M**agical**A**ptitude.

```C#
private static readonly string FeatName = "MagicalAptitude";
```

### Adding Mechnical Effects

Everything looks good but there is no mechanical effect. There are several ways a feature can provide a bonus to skill checks. First try using auto-complete to search for a "Skill" component:

![Feature autocomplete for Skill](~/images/magical_aptitude/skill_feature_autocomplete.png)

[AddBuffSkillBonus](xref:BlueprintCore.Blueprints.Configurators.Facts.BaseUnitFactConfigurator`2.AddBuffSkillBonus(Kingmaker.EntitySystem.Stats.StatType,System.Int32,System.Nullable{Kingmaker.Enums.ModifierDescriptor})) looks like a good fit so let's try it:

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName("MagicalAptitude.Name")
    .SetDescription("MagicalAptitude.Description")
    .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2, descriptor: ModifierDescriptor.UntypedStackable)
    .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2, descriptor: ModifierDescriptor.UntypedStackable)
    .Configure();
```

Notice the skill is defined in using the `StatType` enum. This is used in game to represent most numerical characteristics. Instead of searching for "Skill" we could have searched for "Stat" to find different ways to add the effect.

> [!NOTE]
> For more information on how stats are used look at the CharacterStats class constructor. The different stat classes, e.g. ModifiableValueAttributeStat, impact whether a StatType is valid for a specific usage.

The `ModifierDescriptor` enum is used to resolve stacking for multiple bonuses. If you don't specify anything it stacks with all bonuses, otherwise it follows the rules for the specific enum type.

> [!TIP]
> Look at ModifiableBonus.Add() to see how stacking behavior is implemented for a descriptor.

#### Component Methods

`AddBuffSkillBonus()` is a component method which creates a `BlueprintComponent` of the specified type and adds it to the blueprint's `Component` field array. This is how most mechanical effects are accomplished.

Component methods have parameters which set field values. By default all parameters are optional but this may not be accurate; some parameters may be necessary for the component to function.

If you identify problems with the API such as optional parameters that should be required, file an [issue on GitHub](https://github.com/WittleWolfie/WW-Blueprint-Core/issues/new) or consider [contributing to BlueprintCore](~/articles/contributing.md).

### It works!

Now start the game, level a character, and select the Magical Aptitude feat. Afterwards you should see this on your character screen:

![Magical Aptitude feat bonus on character screen](~/images/magical_aptitude/feat_bonus.png)

### Adding Finishing Touches

Congratulations, you've added a feat! It's not done though, there are two problems:

1. No `FeatureTag` is specified
2. The bonus is always +2, but it should increase to +4 for once that skill has 10 ranks

The impact of `FeatureTag` is easy to see in game: if you hover over a feat in the selection UI, the tags are listed below the description box. You can use the search box to filter feats by tag.

For Magical Aptitude use `FeatureTag.Skills`.

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
    .SetDisplayName("MagicalAptitude.Name")
    .SetDescription("MagicalAptitude.Description")
    .AddFeatureTagsComponent(FeatureTag.Skills)
    .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2)
    .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2)
    .Configure();
```

### Completing the Feat

With the UI completed the only thing to fix is adding the +4 bonus. How can you do it?

If you look at the decompiled code for `BuffSkillBonus` it doesn't look good. The bonus is an `int` value that never changes, so you need another way to grant the +4 bonus.

This step is left as an exercise. There are several ways to accomplish this and the "Solutions" folder in the tutorial project contains one solution. Once your feat is finished, or if you're stuck, take a look.

Some tips:

* Look at existing game blueprints and see how they implement scaling bonuses
* The [Wrath Game Structure](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki) section of the wiki has information that is helpful

### Next Steps

Try the [Skald's Vigor](advanced/skalds_vigor.md) advanced feat tutorial which covers more topics including:

* Troubleshooting and debugging
* Wrath's `EventBus`
* Modifying existing blueprints
* Adding icons
* Actions and conditions
* Feature pre-requisites