# Adding a Feat

Our first feat is [Magical Aptitude](https://aonprd.com/FeatDisplay.aspx?ItemName=Magical%20Aptitude). Due to changes from the tabletop game our feat will grant bonuses to Knowledge Arcana in place of Spellcraft.

To keep our code organized, create a new folder called `Feats`. Inside the folder create a new class called `MagicalAptitude`. This is where we'll create the feat.

Mechanics in Wrath are often represented by Blueprints. The wiki page on [Blueprints](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) goes into a little more detail but for now we just need to know that feats are represented in game by `BlueprintFeature`.

Since we are creating a `BlueprintFeature`, we can use [FeatureConfigurator](xref:BlueprintCore.Blueprints.Configurators.Classes.FeatureConfigurator). However, before we can use that we should define a method which creates the feat:

```C#
public class MagicalAptitude
{
  public static void Create()
  {
    // TODO: Create the feat!
  }
}
```

Now we can create the feat!

```C#
public static void Create()
{
  FeatureConfigurator.New().Configure;
}
```

Unfortunately, this doesn't compile. Every blueprint in the game needs a Guid as a unique identifier. Additionally, blueprints have a `name` field with  a human readable identifier. Since we may need to reference these later, and because they are essentially constants, we'll define them as `static readonly` fields.

```C#
public class MagicalAptitude
{
  private static readonly string FeatName = "MagicalAptitudeFeat";
  private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";
}
```

Use your tool of choice to generate a Guid. Visual Studio can generate one using **Tools > Create GUID**. You can generate one programmatically using [Guid.NewGuid()](https://docs.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=net-6.0#System_Guid_NewGuid), but be sure to save it and reuse it or else you'll have a new Guid every time you load the game.

Now we can create our feat:

```C#
FeatureConfigurator.New(FeatName, FeatGuid).Configure();
```

We have successfully added the to the game! It has no effect and it wouldn't even show up as an option. If you can't select it there's really no point in adding a feat, so let's fix it.

Selectable options like feats, deities, and backgrounds are grouped into lists stored in `BlueprintFeatureSelection`. If we want our feat to show up we'll need to add it to one of these. Luckily we already know there is a list called *BasicFeatSelection* which has all generally available feats. If you browse the game's blueprints you'll find feat lists that represent bonus feats granted by classes such as *FighterFeatSelect*. We might want to add our feat to some of those lists later, but right now *BasicFeatSelection* is good enough.

[!TIP]
One of the best ways to figure out how to make new content is to see how existing content is implemented. There are several tools at your disposal discussed on the [wiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources). I highly recommend [BubblePrints](https://github.com/factubsio/BubblePrints) for exploring game content and [DataViewer](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/9) for validating your changes in-game.

In order to modify *BasicFeatSelect* we need to find its Guid. In the game data we can see it is `247a4068-296e-8be4-2890-143f451b4b45`. This allows us to create a [FeatureSelectionConfigurator](xref:BlueprintCore.Blueprints.Configurators.Classes.Selection.FeatureSelectionConfigurator) for it. For readability we'll store in a `static readonly` variable.

```C#
private static readonly string BasicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";

public static void Create()
{
  FeatureConfigurator.New(FeatName, FeatGuid).Configure();

  FeatureSelectionConfigurator.For(BasicFeatSelectionGuid);
}
```

To actually add our feat we can look at the contents of *BasicFeatSelection*:

![Basic feat selection contents](~/images/magical_aptitude/basic_feat_selection.png)

Looks like the feats are stored in a field called `m_AllFeatures`. Since the field is an array, our configurator should have a method called `AddToAllFeatures`, but if you try that it will fail to compile. As it turns out, `BlueprintFeatureSelection` has an unused field inside called `m_Features`. The configurator is written to remove the ambiguity between `AllFeatures` and `Features`. Instead you can use [AddToFeatures](xref:BlueprintCore.Blueprints.Configurators.Classes.Selection.FeatureSelectionConfigurator.AddToFeatures(System.String[])).

[!NOTE]
Sooner or later you are going to have to read the game code to figure things out. Pick your choice of [decompiler](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources#decompilers) and open up `%WrathPath%/Wrath_Data/Managed/Assembly-CSharp.dll`. It's not as scary as it may sound.

```C#
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToFeatures(FeatName).Configure();
```

Notice that the code snippet passes in `FeatName` rather than `FeatGuid`. Either would work here.

When the library needs to reference a blueprint it accepts a string with a parameter comment indicating the type of blueprint expected. That string can be the blueprint's Guid or, if you provide a mapping from name to Guid, it can be the name. Usually you must specify the mapping using [BlueprintTool.AddGuidsByName](xref:BlueprintCore.Utils.BlueprintTool.AddGuidsByName(System.ValueTuple{System.String,System.String}[])), but when we created our feat using the `New(string name, string guid)` syntax the mapping was automatically registered.

We only need one more change before we're ready to start testing. We need to actually call our method from our blueprints init patch. In case something goes wrong, we'll wrap the call with a try/catch block and log any exceptions:

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
      
      MagicalAptitude.Create();
    }
    catch (Exception e)
    {
      Logger.Error("Failed to initialize.", e);
    }
  }
}
```

[!NOTE]
As an alternative to LogWrapper or Owlcat's LogChannel, you can use UMM's log: `ModSettings.ModEntry.Logger`. This logs
to the `Player.log` file in the same directory as Owlcat's logging.

Build and install the mod, then start a game and create a new character or level up an existing one. You should see the feat during feat selection.

[!WARNING]
Don't test mods on a real save file or you run the risk of breaking it.

[!TIP]
Tools such as [ToyBox](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/8) are useful when testing mods. The cheats provided can spawn enemies, level characters, and generally set the game state to whatever you need for testing.

![Magical Aptitude showing in feat selection](~/images/magical_aptitude/feat_displaying.png)

[!TIP]
Feat not showing? Check the logs for an error creating the feat.

Now we have it showing but if you click on it nothing works and we should probably use a name other than <c>null</c>.

```C#
private static readonly string DisplayName = "Magical Aptitude";
private static readonly string DisplayNameKey = "MagicalAptitudeName";
private static readonly string Description =
    "You get a +2 bonus on all Escape Artist and Stealth skill checks. If you have 10 or more ranks in one of these"
    + " skills, the bonus increases to +4 for that skill.";
private static readonly string DescriptionKey = "MagicalAptitudeDescription";

public static void Create()
{
  FeatureConfigurator.New(FeatName, FeatGuid)
      .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
      .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
      .Configure();

  FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToFeatures(FeatName).Configure();
}
```

In game strings are represented using the class `LocalizedString`. Its key maps to different strings in different locale packs. [LocalizationTool](xref:BlueprintCore.Utils.LocalizationTool) creates the string but only for the current locale. Support for better localization is on the roadmap.

Now if you update the mod and try again you should see the feat complete with a name and description!

From here on out expect to make tweaks, update your mod, then load the game and test. Let's make it a little bit easier by automating the mod install process. To do this we'll add a [Copy task](https://docs.microsoft.com/en-us/visualstudio/msbuild/copy-task?view=vs-2022) to our project file.

Open up your project file (<Name>.csproj) for text editing, and add the following using your mod's name in place of `BlueprintCoreTutorial`:

```xml
<ItemGroup>
  <Assembly Include="$(BaseOutputPath)\BlueprintCoreTutorial.dll" />
  <ModConfig Include="$(BaseOutputPath)\Info.json" />
</ItemGroup>
<Target Name="DeployMod">
  <Copy SourceFiles="@(Assembly)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
  <Copy SourceFiles="@(ModConfig)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
</Target>
```

Now whenever you build your mod is automatically updated. All you need to do to test is launch the game.

Notice that we never specified an icon so the game generated an icon automatically with the stylized letters "MAF". Providing an icon will not be covered in this tutorial, but we can tweak the automatically generated icon to be a little more clear. The letters come from the `FeatName` we provided: **M**agical**A**ptitude**F**eat. Usually I append the mechanical type of blueprint, i.e. Feat, to names because many feats or buffs require multiple blueprints. Since we only need one for Magical Aptitude, we can just drop "Feat" and call it "MagicalAptitude" so the letters are "MA".

```C#
private static readonly string FeatName = "MagicalAptitude";
```

All that's left is to add a mechanical effect. There are many different ways to provide a bonus to skill checks. As a starting point you can just use auto-complete and start searching:

![Feature autocomplete for Skill](~/images/magical_aptitude/skill_feature_autocomplete.png)

It looks like [AddBuffSkillBonus](xref:BlueprintCore.Blueprints.Configurators.Facts.BaseUnitFactConfigurator`2.AddBuffSkillBonus(Kingmaker.EntitySystem.Stats.StatType,Kingmaker.Enums.ModifierDescriptor,System.Int32)) does what we want, so let's try it.

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
    .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
    .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, descriptor: ModifierDescriptor.Feat, value: 2)
    .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, descriptor: ModifierDescriptor.Feat, value: 2)
    .Configure();
```

Notice that the skill bonus is part of the `StatType` enum. When we were looking for a way to add our skill bonus we searched for methods with "Skill" in the name. Internally the game uses the same enum for basically every characteristic. You could also have searched for "Stat" and come up with different options but keep in mind that not every reference to `StatType` actually works with all values.

The `ModifierDescriptor` we provide is used by the game to apply stacking behavior. To ensure our proper stacking we need to specify the descriptor.

At this point you can start the game, level a character, and select the feat. Afterwards you should see this on your character screen:

![Magical Aptitude feat bonus on character screen](~/images/magical_aptitude/feat_bonus.png)

Congratulations! You've just added a feat. However, we're not quite done. We still have three problems:

1. The bonus is always +2, no matter how many ranks we have in either skill.
2. No `FeatureGroup` is specified
3. No `FeatureTag` is specified

Numbers 2 and 3 are simple so let's fix those first. You might be wondering what `FeatureGroup` and `FeatureTag` actually mean. The impact of `FeatureTag` is immediately obvious: when you are in the feat selection UI you'll notice that at the bottom of a feat's description there are tags listed. You can search feats by tag to filter the selection UI.

`FeatureGroup` is a little less obvious. If you look through the values you'll see things like `CombatFeat` and `WizardFeat`. You might assume this is what populates all those class specific feat selection lists. In reality, it is used for UI treatments such as additional description for teamwork feats and choosing the order to display feats in the selection UI.

[!TIP]
BlueprintFeatureSelection actually has a field storing a FeatureGroup. [TabletopTweaks](https://github.com/Vek17/WrathMods-TabletopTweaks/) uses this in its FeatTool utility to automatically add feats to the appropriate lists. Consider using that utility or defining a config which defines which lists contain your new feats. This makes it easy to manage new feats and enables compatibility with mods that add new feat lists.

For our feat we'll use `FeatureGroup.Feat` and `FeatureTag.Skills`.

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
    .SetDisplayName(LocalizationTool.CreateString(DisplayNameKey, DisplayName))
    .SetDescription(LocalizationTool.CreateString(DescriptionKey, Description))
    .SetFeatureTags(FeatureTag.Skills)
    .SetFeatureGroups(FeatureGroup.Feat)
    .AddBuffSkillBonus(stat: StatType.SkillKnowledgeArcana, value: 2)
    .AddBuffSkillBonus(stat: StatType.SkillUseMagicDevice, value: 2)
    .Configure();
```

Notice that they both support multiple values, so a combat feat can use `Feat` and `CombatFeat`.

With all of the UI configuration done, how do we change the bonus to +4 after the character has 10 ranks in the skills?

If you look at the input parameters for `BuffSkillBonus` and the decompiled code it doesn't look promising. The bonus it applies is provided as an `int` value and never changes. We'll have to find another way to change the bonus value.

This is the end of the tutorial. It's up to you to figure out how to finish the implementation of Magical Aptitude. There are several ways you could implement this feat. One solution is provided in the tutorial project under the "Solutions" folder. When you've finished your implementation, or if you're stuck and really can't figure it out, take a look at the solution.

Some tips to get you started:

* Look at existing game blueprints and see how they implement scaling bonuses
* The [Wrath Game Structure](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki) section of the wiki has some useful information