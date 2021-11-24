# BlueprintCore Tutorials

Tutorials explain how to modify the game using this library. They are a work in progress and more will be added.

Tutorial names indicate what type of modification to the game they explain. For example, [Adding a Feat](feat.md) explains how to use the library to create a new feat.

You can do them in any order but the recommended order is:

1. Pre-work
2. [Adding a Feat](feat.md)
3. WIP

### Pre-work

Before going through any of these tutorials you should work through the [OwlcatModdingWiki Beginner Guide](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Beginner-Guide). The tutorials require:

* A C# project configured for installation using [Unity Mod Manager](https://www.nexusmods.com/site/mods/21)
* A [Public Assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicise-Assemblies)
    * Be sure to configure the `WrathPath` environment variable
* [Optional] Download [RemoteConsole](https://github.com/OwlcatOpenSource/RemoteConsole/releases)
    * This will show game log events making it easier to debug issues

Once that's done, install the [BlueprintCore NuGet package](https://www.nuget.org/packages/WW-Blueprint-Core). In Visual Studio you can use the built-in NuGet Package Manager:

1. Open the package manager
    * **Tools > NuGet Package Manager > Manage NuGet Packages**
2. Select **Browse** and search for "WW-BlueprintCore"
3. Select and install the latest version
    * If you have multipe projects in your solution, make sure it is installed to the correct project
![Search and install NuGet package](~/images/install_with_nuget.png)

Now you need to add two more references:

* `Owlcat.Runtime.Visual.dll`
* `Owlcat.Runtime.UI.dll`

If you have defined the `WrathPath` environment variable add the following lines to your *.csproj file:

```xml
<ItemGroup>
  <Reference Include="Owlcat.Runtime.UI">
    <HintPath>$(WrathPath)\Owlcat.Runtime.UI.dll</HintPath>
  </Reference>
  <Reference Include="Owlcat.Runtime.Visual">
    <HintPath>$(WrathPath)\Owlcat.Runtime.Visual.dll</HintPath>
  </Reference>
</ItemGroup>
```

Otherwise right-click **References > Add Reference**, navigate to `<WrathInstallDir>/Wrath_Data/Managed/`, and select the files.

Build your project to make sure everything is configured correctly. Now you're ready to start the tutorials. All of the code for the tutorial is [available on GitHub](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/Tutorials).