# Adding a Feat

The first feat is [Magical Aptitude](https://aonprd.com/FeatDisplay.aspx?ItemName=Magical%20Aptitude).

Create a new folder in your project called `Feats`. Here is where you can add classes that create or modify feats.

Inside the feats folder create a new class called `MagicalAptitude`.

Mechanics in Wrath are usually represented by Blueprints. The wiki page on [Blueprints](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) goes into more detail, but for now just know that a feat is a `BlueprintFeature`. To create a feat we'll we'll use [FeatureConfigurator](xref:BlueprintCore.Blueprints.Configurators.Classes.FeatureConfigurator).

### Create a Feat

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

### Add to Feat Selection

At this point the feat exists but has no effect and can't be selected. To fix this we need to add it to a `BlueprintFeatureSelection`. `BlueprintFeatureSelection` defines a list of features you can select during character creation or advancement, e.g. feats, deities, and backgrounds.

There are several feat lists in game including `BasicFeatSelection` as well as feats tied to specific character options such as `WizardFeatSelection` which contains feats a wizard can choose as a bonus feat. For now just use BasicFeatSelection which includes all generally available feats.

> [!TIP]
> The first step to adding new content is understanding how existing content is implemented. There are several tools at your disposal discussed on the [wiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources). I recommend [BubblePrints](https://github.com/factubsio/BubblePrints) for exploring game content and [DataViewer](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/9) for validating your changes in-game.

To add the feat you need the Guid for BasicFeatSelection: `247a4068-296e-8be4-2890-143f451b4b45`. You can find this using the tools in the tip above.

Create a [FeatureSelectionConfigurator](xref:BlueprintCore.Blueprints.Configurators.Classes.Selection.FeatureSelectionConfigurator) to modify *BasicFeatSelection*:

```C#
private static readonly string BasicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";

public static void Configure()
{
  FeatureConfigurator.New(FeatName, FeatGuid).Configure();

  FeatureSelectionConfigurator.For(BasicFeatSelectionGuid);
}
```

When `For()` is called the `BlueprintFeatureSelection` for BasicFeatSelection is fetched from the game library and the FeatureSelectionConfigurator is returned.

To add the feat look at the contents of *BasicFeatSelection*:

![Basic feat selection contents](~/images/magical_aptitude/basic_feat_selection.png)

Feats are stored in a field called `m_AllFeatures`. Since the field is an array the configurator should have a method called `AddToAllFeatures`:

> [!NOTE]
> You will need to read the game code to figure things out. Pick your choice of [decompiler](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources#decompilers) and open up `%WrathPath%/Wrath_Data/Managed/Assembly-CSharp.dll`.

```C#
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToAllFeatures(FeatName).Configure();
```

When you call a function on a configurator such as `AddToAllFeatures()` two things happen:

1. The requested change is staged, but not committed until `Configure()` is called
2. The configurator is returned

This allows you to create a single statement to configure a blueprint, calling `Configure()` when you're done:

```C#
// SetX and SetY are just placeholders
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToAllFeatures(FeatName).SetX(x).SetY(y).Configure();
```

Notice you passed `FeatName` to `AddToFeatures` rather than `FeatGuid`. When the feat was created using `FeatureConfigurator.New()` the name was registered to the Guid for lookup.

When a blueprint is needed BlueprintCore APIs accept a [Blueprint<TRef>](xref:BlueprintCore.Utils.Blueprint`1) parameter. This enables passing blueprints in as a name, Guid, blueprint, or blueprint reference. See [Referencing Blueprints](~/articles/intro.md#referencing-blueprints) for more information.

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

### First Test!

Now build the mod, install it, and start the game. When you level or create a character you should see the feat in the selection UI.

> [!WARNING]
> Don't test mods on a real save file or you run the risk of breaking it.

> [!TIP]
> Tools such as [ToyBox](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/8) are useful when testing mods. The cheats provided can spawn enemies, level characters, and generally set the game state to whatever you need for testing.

![Magical Aptitude showing in feat selection](~/images/magical_aptitude/feat_displaying.png)

> [!TIP]
> If the feat doesn't appear check the logs for any errors.

### Fix the UI

If you click on it nothing works and you probably wante a name other than <c>null</c>. To do that populate the `m_DisplayName` and `m_Description` fields of the blueprint:

```C#
private static readonly string DisplayName = "Magical Aptitude";
private static readonly string DisplayNameKey = "MagicalAptitudeName";
private static readonly string Description =
  "You get a +2 bonus on all Spellcraft and Use Magic Device skill checks. If you have 10 or more ranks in one of"
  + " these skills, the bonus increases to +4 for that skill.";
private static readonly string DescriptionKey = "MagicalAptitudeDescription";

public static void Configure()
{
  FeatureConfigurator.New(FeatName, FeatGuid)
      .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
      .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
      .Configure();

  FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToFeatures(FeatName).Configure();
}
```

Game strings are represented using the class `LocalizedString`. A LocalizedString has a key used to lookup the value by language. [LocalizationTool](xref:BlueprintCore.Utils.LocalizationTool) creates the string, but only for the current language. Support for better localization is on the roadmap.

Test again and the feat should have a name and description!

You may have noticed the feat icon was the stylized letters "MAF". If you don't provide an icon the game generates one using the name, in this case **M**agical**A**ptitude**F**eat. Since abilities often require multiple blueprints it is recommended to append the mechanical type, i.e. Feat, to blueprint names. Magical Aptitude only requires one blueprint so you can drop "Feat" to get the letters "MA": **M**agical**A**ptitude.

```C#
private static readonly string FeatName = "MagicalAptitude";
```

#### Use Automatic Deployment

Modding requires you to frequently build, deploy, and test changes. To simplify this, configure the project to automatically update the mod after it builds. This is accomplished by adding a [Copy task](https://docs.microsoft.com/en-us/visualstudio/msbuild/copy-task?view=vs-2022) to the project file.

Open up your project file (<Name>.csproj) and add the following block, using your mod's name in place of `BlueprintCoreTutorial`:

```xml
<!-- Automatic Deployment Setup -->
<Target Name="DeployMod" AfterTargets="ILRepack">
  <ItemGroup>
    <Assembly Include="$(OutputPath)\BlueprintCoreTutorial.dll" />
    <ModConfig Include="$(OutputPath)\Info.json" />
  </ItemGroup>

  <Copy SourceFiles="@(Assembly)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
  <Copy SourceFiles="@(ModConfig)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
</Target>
```

Now whenever you want to test changes just build and start the game.

### Add Mechnical Effects

Everything looks good but there is no mechanical effect. There are several ways a feature can provide a bonus to skill checks. First try using auto-complete to search for a "Skill" component:

![Feature autocomplete for Skill](~/images/magical_aptitude/skill_feature_autocomplete.png)

[AddBuffSkillBonus](xref:BlueprintCore.Blueprints.Configurators.Facts.BaseUnitFactConfigurator`2.AddBuffSkillBonus(Kingmaker.EntitySystem.Stats.StatType,System.Int32,System.Nullable{Kingmaker.Enums.ModifierDescriptor})) looks like a good fit so let's try it:

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
    .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
    .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2, descriptor: ModifierDescriptor.Feat)
    .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2, descriptor: ModifierDescriptor.Feat)
    .Configure();
```

#### Component Methods

`AddBuffSkillBonus()` is a component method which creates a `BlueprintComponent` of the specified type and add it to the blueprint's `Component` field array. Most mechanical effects are defined using components and applied this way.

Component methods have parameters which set field values. By default all parameters are optional but this may not be accurate.

If you identify problems with the API such as optional parameters that should be required, file an [issue on GitHub](https://github.com/WittleWolfie/WW-Blueprint-Core/issues/new) or consider [contributing to BlueprintCore](~/articles/contributing.md).

Note that the skill is defined in the `StatType` enum which is used by the game for most numeric characteristics. Instead of searching for "Skill" we could have searched for "Stat" to find different options. A word caution: not every use of `StatType` works with every type of stat.

> [!NOTE]
> For more information on how stats are used look at the CharacterStats class constructor. The different stat classes, e.g. ModifiableValueAttributeStat, impact whether a StatType is valid for a specific usage.

The `ModifierDescriptor` enum is used to resolve stacking for multiple bonuses. If you don't specify anything it stacks with all bonuses, otherwise it follows the rules for the specific enum type.

> [!TIP]
> Look at ModifiableBonus.Add() to see how stacking behavior is implemented for a descriptor.

### It works!

Now start the game, level a character, and select the Magical Aptitude feat. Afterwards you should see this on your character screen:

![Magical Aptitude feat bonus on character screen](~/images/magical_aptitude/feat_bonus.png)

### Add Finishing Touches

Congratulations, you've added a feat! It's not done though, there are three problems:

1. The bonus is always +2, but it should increase to +4 for once that skill has 10 ranks
2. No `FeatureGroup` is specified
3. No `FeatureTag` is specified

Numbers 2 and 3 are simple so fix those first. You're probably wondering what `FeatureGroup` and `FeatureTag` do and why they're needed. The impact of `FeatureTag` is easy to see in game: if you hover over a feat in the selection UI, the tags are listed below the description box. You can use the search box to filter feats by tag.

`FeatureGroup` is less clear; it has values like `CombatFeat` and `WizardFeat` which makes it seem as if this populates class specific feat selection lists. Unfortunately it does not. It is used for UI treatments such as additional description text on teamwork feats and changing the order of displayed feats in the selection UI.

> [!TIP]
> BlueprintFeatureSelection has a field for a FeatureGroup. [TabletopTweaks](https://github.com/Vek17/WrathMods-TabletopTweaks/) uses this field to automatically add feats to the appropriate lists. See the FeatTool utility.
> Consider using that utility or creating a config file to map your feats to feat lists. This simplifies adding feats and enables compatibility with other mods that feats or feat lists. Eventually BlueprintCore will include this functionality.

For Magical Aptitude use `FeatureGroup.Feat` and `FeatureTag.Skills`.

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
    .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
    .AddFeatureTagsComponent(FeatureTag.Skills)
    .AddToGroups(FeatureGroup.Feat)
    .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2)
    .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2)
    .Configure();
```

### Final Challenge

With the UI completed the only thing to fix is adding the +4 bonus. How can you do it?

If you look at the decompiled code for `BuffSkillBonus` it doesn't look good. The bonus is an `int` value that never changes, so you need another way to grant the +4 bonus.

This step is left as an exercise. There are several ways to accomplish this and the "Solutions" folder in the tutorial project contains one solution. Once your feat is finished, or if you're stuck, take a look.

Some tips:

* Look at existing game blueprints and see how they implement scaling bonuses
* The [Wrath Game Structure](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki) section of the wiki has information that is helpful