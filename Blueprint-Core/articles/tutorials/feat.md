# Adding a Feat

Our first feat is [Stealthy](https://aonprd.com/FeatDisplay.aspx?ItemName=Stealthy).

To keep our code organized, create a new folder called `Feats`. Inside the folder create a new class called `Stealthy`. This is where we'll create the feat.

Mechanics in Wrath are often represented by Blueprints. The wiki page on [Blueprints](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) goes into a little more detail but for now we just need to know that feats are represented in game by `BlueprintFeature`.

Since we are creating a `BlueprintFeature`, we can use [FeatureConfigurator](xref:BlueprintCore.Blueprints.Configurators.Classes.FeatureConfigurator). However, before we can use that we should define a method which creates the feat:

```C#
public class Stealthy
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
public class Stealthy
{
  private static readonly string FeatName = "StealthyFeat";
  private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";
}
```

Use your tool of choice to generate a Guid. Visual Studio can generate one using **Tools > Create GUID**. You can generate one programmatically using [Guid.NewGuid()](https://docs.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=net-6.0#System_Guid_NewGuid), but be sure to save it and reuse it or else you'll have a new Guid every time you load the game.

Now we can create our feat:

```C#
FeatureConfigurator.New(FeatName, FeatGuid).Configure();
```

We have successfully added the to the game! It has no effect and it wouldn't even show up as an option. If you can't select it there's really no point in adding an effect, so let's fix that first.

Selectable options like feats, deities, and backgrounds are grouped into lists stored in `BlueprintFeatureSelection`. If we want our feat to show up we'll need to add it to one of these. Luckily we already know there is a list called *BasicFeatSelection* which has all generally available feats. If you browse the game's blueprints you'll find feat lists that represent bonus feats granted by classes such as *FighterFeatSelect*. Eventually we might want to add our feat to some of those lists but right now we'll just add it to *BasicFeatSelection*.

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

![Basic feat selection contents](~/images/basic_feat_selection.png)

Looks like the feats are stored in a field called `m_AllFeatures`. Since the field is an array, our configurator should have a method called `AddToAllFeatures`, but if you try that it will fail to compile. As it turns out, `BlueprintFeatureSelection` has an unused field inside called `m_Features`. The configurator is written to remove the ambiguity between `AllFeatures` and `Features`. Instead you can use [AddToFeatures](xref:BlueprintCore.Blueprints.Configurators.Classes.Selection.FeatureSelectionConfigurator.AddToFeatures(System.String[])).

[!NOTE]
Sooner or later you are going to have to read the game code to figure things out. Pick your choice of [decompiler](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Modding-Resources#decompilers) and open up `%WrathPath%/Wrath_Data/Managed/Assembly-CSharp.dll`. It's not as scary as it may sound.

```C#
FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToFeatures(FeatName).Configure();
```

Notice that the code snippet passes in `FeatName` rather than `FeatGuid`. Either would work here.

When the library needs to reference a blueprint it accepts a string with a parameter comment indicating the type of blueprint expected. That string can be the blueprint's Guid or, if you provide a mapping from name to Guid, it can be the name. Usually you must specify the mapping using [BlueprintTool.AddGuidsByName](xref:BlueprintCore.Utils.BlueprintTool.AddGuidsByName(System.ValueTuple{System.String,System.String}[])), but when we created our feat using the `New(string name, string guid)` syntax the mapping was automatically registered.

We only need one more change before we're ready to start testing. We need to actually call our method from our blueprints init patch:

```C#
public static void PostFix()
{
  Stealthy.Create();
}
```

Build and install the mod, then start game and create a new character or level up an existing one.

[!TIP]
It is very helpful when modding to use a tool such as [ToyBox](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/8), which enables cheats in game. This way you can spawn enemies, level characters, and otherwise set the game state to whatever needed to test your mod.

[!WARNING]
Don't test mods on a real save file or you run the risk of breaking it.



SCRATCH

TODO: Add Remote Console setup as pre-work.

We'll worry about getting to show up later, for now let's add an effect.

There are many different ways to provide a bonus to skill checks. As a starting point you can just rely on auto-complete and start searching:

![Feature autocomplete for Skill](~/images/skill_feature_autocomplete.png)

There are a ton of options! It sounds like [AddBuffSkillBonus](xref:BlueprintCore.Blueprints.Configurators.Facts.BaseUnitFactConfigurator`2.AddBuffSkillBonus(Kingmaker.EntitySystem.Stats.StatType,Kingmaker.Enums.ModifierDescriptor,System.Int32)) does what we want, so let's give that a try.