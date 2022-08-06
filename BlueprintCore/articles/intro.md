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
    * `%WrathPath%\Wrath_Data\Managed\Newtonsoft.Json.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Core.dll`
    * `$WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.UI.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Validation.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Visual.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.AssetBundleModule.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.CoreModule.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityModManager\0Harmony.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityModManager\UnityModManager.dll`
    * **Important:**
        * Make sure your assembly references do not declare `<Private>false</Private>` or DLL Merging will fail
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
7. (Optional) Create a new text file called `LocalizedStrings.json`
    * Use this to define text used in your mod, see [Text](usage/utils.md#text) for more details
    * Be sure to distribute this file with your mod assembly
8. (Optional) Create a Unity AssetBundle called `assets`
    * Use this to import Unity assets, see [Unity Assets](usage/utils.md#unity-assets) for more details
    * Be sure to distribute this file with your mod assembly
8. You're ready to go!

If you already have a project or are having trouble, take a look at [BlueprintCore Tutorial.csproj](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreTutorial/BlueprintCoreTutorial/BlueprintCoreTutorial.csproj).

Your project file should look almost identical to the tutorial project file, with the exception that you may have additional package and assembly references. In particular make sure:

* Your publicized assembly is called `Assembly-CSharp.dll`
* Your assembly references do not set `<Private>false</Private>`
* All referenced assemblies are included

Without these `ILRepack` will fail.

### Optional: Reduce Assembly Size with ILStrip

BPCore is a large library with wrappers for thousands of game types. It has a big footprint: 7MB at the time of
writing.

The impact of this isn't significant but if you want to keep your assembly small use [ILStrip](https://brokenevent.com/projects/ilstrip). ILStrip removes unreferenced classes from an assembly, significantly reducing the size of mods using BPCore. It reduced the tutorial assembly from to ~400KB from ~8MB.

1. Download [ILStrip.CLI.zip](https://github.com/BrokenEvent/ILStrip/releases/latest)
2. Extract the files into a folder in your project's solution directory. I recommend creating a `tools` directory next to the `lib` directory.

![ILStrip Directory Setup](~/images/ilstrip_dir.png)

3. Add ILStrip to your project
     * Open your .csproj file and add a new target:
     ```xml
     <!-- Minimizes the assembly size -->
     <Target Name="ILStrip" AfterTargets="ILRepack">
       <ItemGroup>
         <LocalAssembly Include="$(AssemblyName).dll" />
         <ILStrip Include="&quot;$(SolutionDir)\tools\BrokenEvent.ILStrip.CLI.exe&quot;" />
     
         <!-- BlueprintCore Entry Points -->
         <Entry Include="BlueprintCore.Utils.Assets.AssetTool/BlueprintsCaches_Patch" />
         <Entry Include="BlueprintCore.Utils.Assets.AssetTool/BundlesLoadService_Patch" />
         <Entry Include="BlueprintCore.Utils.LocalizationTool/LocalizationManager_Patch" />
         <Entry Include="BlueprintCore.UnitParts.Replacements.UnitPartBuffSuppressFixed/Buff_OnAttach_Suppression_Patch" />
     
         <!-- Replace with Your Mod Entry Points -->
         <Entry Include="BlueprintCoreTutorial.Main" />
         <Entry Include="BlueprintCoreTutorial.Main/BlueprintsCaches_Patch" />
       </ItemGroup>

       <Exec
         WorkingDirectory="$(OutputPath)"
         Command="@(ILStrip) @(LocalAssembly) @(LocalAssembly) -e @(Entry, ' -e ')"/>
     </Target>
     ```
     * Each `Entry` item is an entry point for your code. This includes any class called through reflection and any Harmony patches.
     * BPCore Patch Notes will call out any new entry points needed
     * ILStrip breaks debugging symbols; disable it when using [Wrath2Debug](https://github.com/thehambeard/Wrath2Debug/releases/latest)

#### Troubleshooting

You can open your assembly in the decompiler of your choice to sanity check. Make sure you see all the expected namespaces and classes.

**ILStrip Removes Used Code**

Chances are you are missing an entry point. Make sure every Harmony patch and every class referenced through reflection, such as the class with UMM's `Load` method, are listed as an `Entry` in the ILStrip target.

**ILStrip Fails to Resolve Entry Point**

Make sure you're using the correct name. Keep in mind nested and generic classes have different reference syntax:

* Default: `BlueprintCore.Utils.LocalizationTool`
* Nested: `BlueprintCore.Utils.LocalizationTool/LocalizationManager_Patch`
* Generic: ``BlueprintCore.Utils.Blueprint`1``
    * The number is the number of type arguments

If you're not sure what's wrong, remove all `Entry` items and build. In the Build Output ILStrip prints a line for every type indicating whether it is used or unused:

![ILStrip Build Output](~/images/ilstrip_out.png)

### Optional: Automatic Mod Deployment

Using a [Copy task](https://docs.microsoft.com/en-us/visualstudio/msbuild/copy-task?view=vs-2022) you can automatically deploy your mod each time you build.

Add a DeployMod target to your .csproj file, using your mod's name in place of `BlueprintCoreTutorial`:

```xml
<!-- Automatic Deployment Setup -->
<Target Name="DeployMod" AfterTargets="ILStrip">
  <ItemGroup>
    <Assembly Include="$(OutputPath)\BlueprintCoreTutorial.dll" />
    <ModConfig Include="$(OutputPath)\Info.json" />
    <Strings Include="$(OutputPath)\LocalizedStrings.json" />
    <Assets Include="$(OutputPath)\assets" />
  </ItemGroup>

  <Copy SourceFiles="@(Assembly)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
  <Copy SourceFiles="@(ModConfig)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
  <Copy SourceFiles="@(Strings)" DestinationFolder="$(WrathPath)\Mods\$(MSBuildProjectName)" />
  <Copy SourceFiles="@(Assets)" DestinationFolder="$(WrathPath)\Mods\$(MSBuildProjectName)" />
</Target>
```

Make sure to use a different `Assembly` item name than in the ILStrip target. Although they are declared in the context of the target, they are global for the project file.

If you are not using ILStrip replace `AfterTargets="ILStrip"` with `AfterTargets="ILRepack"`.

## Using BlueprintCore

For a step-by-step walkthrough see [Tutorials](tutorials/overview.md).

If you're having problems check [Known Issues](usage/issues.md).

If you're interested in contributing see [How to Contribute](contributing.md).

For general usage details see the links below:

* [Blueprints](usage/blueprints.md) - Creating, modifying, and referencing blueprints
* [Actions and Conditions](usage/builders.md) - Using actions and conditions
* [Text, Logging, and Utils](usage/utils.md) - General utility classes
* [Understanding the API](usage/api.md) - Design and creation of the API