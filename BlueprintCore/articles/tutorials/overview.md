# BlueprintCore Tutorials

Tutorials explain how to modify the game using this library. They are a work in progress and more will be added.

Tutorial names indicate what type of modification to the game they explain. For example, [Adding a Feat](feat.md) explains how to use the library to create a new feat.

You can do them in any order but the recommended order is:

1. Pre-work
2. [Adding a Feat](feat.md)
3. WIP

All tutorial code is [available on GitHub](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/Tutorials). Each tutorial has a challenge not covered in the tutorial. One possible solution to each challenge is available in the `Solutions` folder.

### Pre-work

Before going through any of these tutorials you should work through the [OwlcatModdingWiki Beginner Guide](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Beginner-Guide). The tutorials require:

* A C# project configured for installation using [Unity Mod Manager](https://www.nexusmods.com/site/mods/21)
* A [Public Assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicize-Assemblies)
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

Now you need to add a few references:

* `Owlcat.Runtime.Core.dll`
* `Owlcat.Runtime.Visual.dll`
* `Owlcat.Runtime.UI.dll`
* `UnityEngine.dll`
* `UnityEngine.CoreModule.dll`

If you have defined the `WrathPath` environment variable add the following lines to your *.csproj file:

```xml
<ItemGroup>
  <Reference Include="Owlcat.Runtime.Core">
    <HintPath>$(WrathPath)\Wrath_Data\Managed\Owlcat.Runtime.Core.dll</HintPath>
  </Reference>
  <Reference Include="Owlcat.Runtime.UI">
    <HintPath>$(WrathPath)\Wrath_Data\Managed\Owlcat.Runtime.UI.dll</HintPath>
  </Reference>
  <Reference Include="Owlcat.Runtime.Visual">
    <HintPath>$(WrathPath)\Wrath_Data\Managed\Owlcat.Runtime.Visual.dll</HintPath>
  </Reference>
  <Reference Include="UnityEngine">
    <HintPath>$(WrathPath)\Wrath_Data\Managed\UnityEngine.dll</HintPath>
  </Reference>
  <Reference Include="UnityEngine.CoreModule">
    <HintPath>$(WrathPath)\Wrath_Data\Managed\UnityEngine.CoreModule.dll</HintPath>
  </Reference>
</ItemGroup>
```

Otherwise right-click **References > Add Reference**, navigate to `<WrathInstallDir>/Wrath_Data/Managed/`, and select the files.

Next install [ILRepack.MSBuild.Task](https://www.nuget.org/packages/ILRepack.MSBuild.Task/) using NuGet and add the following to your *.csproj file, using your mod's assembly name in place of `BlueprintCoreTutorial`:

```xml
<!-- DLL Merging -->
<Target Name="ILRepack" AfterTargets="Build">
  <ItemGroup>
    <InputAssemblies Include="BlueprintCore.dll" />
    <InputAssemblies Include="BlueprintCoreTutorial.dll" />
    <OutputAssembly Include="BlueprintCoreTutorial.dll" />
  </ItemGroup>
    
  <Message Text="Merging: @(InputAssemblies) into @(OutputAssembly)" Importance="High" />

  <ILRepack
      OutputType="Dll"
      MainAssembly="@(OutputAssembly)"
      OutputAssembly="@(OutputAssembly)"
      InputAssemblies="@(InputAssemblies)"
      WorkingDirectory="$(OutputPath)" />
</Target>
```

This will merge all the assemblies you add to `InputAssemblies` into your mod's assembly, preventing conflicts from different mods using different assembly versions, and allowing you to release your mod as a single assembly. If you are using other assemblies such as [ModKit](https://github.com/cabarius/ToyBox/tree/master/ModKit) it is recommended to merge them as well.

Build your project to make sure everything is configured correctly. Now you're ready to start the tutorials. All of the code for the tutorial is [available on GitHub](https://github.com/WittleWolfie/WW-Blueprint-Core/tree/main/Tutorials).

Be sure to check [known issues](~articles/issues.md) if you run into any problems.