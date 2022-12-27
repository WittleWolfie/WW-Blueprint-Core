# Getting Started

## Using BlueprintCore

For a step-by-step walkthrough see [Tutorials](tutorials/overview.md).

If you're having problems check [Known Issues](usage/issues.md).

If you're interested in contributing see [How to Contribute](contributing.md).

Looking for examples? Here are some mods using BPCore:

* [CharacterOptions+](https://github.com/WittleWolfie/CharacterOptionsPlus)
* [Madison's Metagaming](https://github.com/madisoncfallin/MadisonsMetagaming)
* [Come and Get Me!](https://github.com/Envibel/ComeAndGetMe)

For general usage details see the links below:

* [Blueprints](usage/blueprints.md) - Creating, modifying, and referencing blueprints
* [Actions and Conditions](usage/builders.md) - Using actions and conditions
* [Text, Logging, and Utils](usage/utils.md) - General utility classes
* [Understanding the API](usage/api.md) - Design and creation of the API

##  Quick-Start

If you have an existing mod to which you're integrating BPCore you'll need to go through the [Full Setup](#full-setup). If you're starting a new mod you're in luck, BPCore now has [Project Templates](https://github.com/WittleWolfie/BPCoreTemplate)!

1. Download and install [Visual Studio](https://visualstudio.microsoft.com/vs/), skip if you already have it
    * When prompted for Workloads include ".NET desktop development", anything else is optional
    * Instructions were written for Visual Studio 2022
2. Download and install [Unity](https://unity3d.com/get-unity/download/archive) version `2020.3.33f1`, skip if you already have it
3. Open Unity and create a new project with the 3D template, **then close it**
    * I recommend using this directory structure:
        * `pathToMod/MyMod/MyModCode` - Directory for your C# solution
        * `pathToMod/MyMod/MyModUnity` - Unity project directory
    * **Seriously close it or you'll probably need to do some renaming of things in Unity yourself from BasicTemplate to your mod name**
4. Download the latest [BasicTemplate](https://github.com/WittleWolfie/BPCoreTemplate/releases/latest/download/BasicTemplate.zip)
5. Extract the contents
6. Open the folder `BPCoreTemplate`, right click `Setup.ps1`, and select `Run with Powershell`
![Run Setup with powershell](~/images/quick_start/run_powershell.png)
7. Follow the prompts (described below)
    * First prompt is your Wrath installation directory. If you use the default steam location you can just click okay.
    ![Select Wrath install directory](~/images/quick_start/select_wrath_dir.png)
    * Next prompt is the directory you want to use for your mod / C# project
    ![Select mod project directory](~/images/quick_start/select_mod_dir.png)
    * Next prompt is the directory for the Unity project you created
    ![Select Unity project directory](~/images/quick_start/select_unity_dir.png)
    * Last prompt is the name of the mod, **no spaces**
    ![Enter mod name](~/images/quick_start/mod_name.png)
8. Open the Unity project you created. You should have an `Assets` folder and an `Editor` folder now.
    ![Unity quick start](~/images/quick_start/unity.png)
    * From the top bar select **Assets** > **Build AssetBundles**
    * A moment later you should see a `StreamingAssets` folder. It may show as empty in Unity but open it up the folder in Explorer and it should contain a file called `<modname>_assets`.
    * You can close Unity
9. Navigate to your mod project folder and open `<ModName>.csproj` in Visual Studio
    * Right click the project and select **Clean**
    * When it completes (check the Output window at the bottom), right click again and select **Unload Project**
    * Right click one more time and select **Reload Project**
    * This fixes issues with Intellisense caching claiming your assembly reference is broken
10. Still in Visual Studio, right click the project and select **Add** > **Existing Item**
    * Navigate to the Unity project folder then `Assets/StreamingAssets` and select `<modname>_assets`
    * Right click `<modname>_assets` and set to `Copy if newer`
    ![Assets file properties](~/images/quick_start/assets_props.png)
11. Build the project
12. Launch Wrath and create or level up a character
    * If all went well you should see a new feat called "My Feat"
    ![Example feat from mod](~/images/quick_start/my_feat.png)

You're all set! If you want to keep your assembly size small you can additionally configure [ILStrip](#optional-reduce-assembly-size-with-ilstrip).

### Troubleshooting

#### Setup Doesn't Run

This can happen if your security policy prevents running unsigned PowerShell scripts.

1. Start Windows PowerShell with Run as Administartor
2. Navigate to the `BasicTemplat` directory (containing `Setup.ps1`)
3. Run this command: `PowerShell -ExecutionPolicy RemoteSigned -file Setup.ps1`

#### Unity Files Locked

Some users reported an issue where Unity "locks" files. This prevents the rename from happening. If this happens just follow the instructions in the [Skald's Vigor Tutorial](~/articles/tutorials/advanced/skalds_vigor.md#create-an-assetbundle).

#### Missing BlueprintCore / Publicizer

In Visual Studio open **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**. Make sure the package source is set to `nuget.org`:

![NuGet Package Source](~/images/quick_start/nuget_source.png)

Make sure all packages are installed and updated.

### Deploying and Releasing

Every time you build the project your mod is automatically installed on your local machine.

When you want to release your mod for others to install, select the `Release` build configuration and build. The release zip is automatically created in the output directory. You can navigate to the directory by right clicking your project in Visual Studio, selecting **Open Folder in File Explorer**, then navigating to the `bin/Release/net472` directory:

![Opening project files](~/images/quick_start/open_files.png)

![Release output directory](~/images/quick_start/release_zip.png)

If you want to generate the release zip in another folder just double click on your project file to edit, scroll to the bottom, and change `DestinationFile` in the `ZipDirectory` command:

```xml
<!-- Automatically creates a release zip -->
<Target Name="ZipRelease" AfterTargets="ILRepack" Condition="'$(Configuration)' == 'Release'">
  <ItemGroup>
    <Assembly Include="$(OutputPath)\$(AssemblyName).dll" />
    <ModConfig Include="$(OutputPath)\Info.json" />
    <Strings Include="$(OutputPath)\LocalizedStrings.json" />
    <Assets Include="$(OutputPath)\*_assets" />
  </ItemGroup>

  <Copy SourceFiles="@(Assembly)" DestinationFolder="$(OutputPath)\$(AssemblyName)" />
  <Copy SourceFiles="@(ModConfig)" DestinationFolder="$(OutputPath)\$(AssemblyName)" />
  <Copy SourceFiles="@(Strings)" DestinationFolder="$(OutputPath)\$(AssemblyName)" />
  <Copy SourceFiles="@(Assets)" DestinationFolder="$(OutputPath)\$(AssemblyName)" />
  <ZipDirectory
    SourceDirectory="$(OutputPath)\$(AssemblyName)"
    DestinationFile="$(OutputPath)\$(AssemblyName).zip"
    Overwrite="true"/>
</Target>
```

If you need to add additional files just add them as a new item under the `ItemGroup`, then add a copy command for that item.

## Full Setup

This assumes you have already created a C# project and are familiar with the basic mod setup in the [Beginner Guide](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Beginner-Guide).

1. Define the `WrathPath` environment variable if you have not already
    * WrathPath should be the root install directory, usually `C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure` for Steam
2. Create and reference a [public assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicize-Assemblies).
3. Install [WW-Blueprint-Core](https://www.nuget.org/packages/WW-Blueprint-Core/) using [NuGet](https://docs.microsoft.com/en-us/nuget/what-is-nuget).
4. Make sure your project is configured for .NET 4.7.2 and the latest C# language version
    * In your .csproj file you should have the following properties:
    ```xml
    <PropertyGroup>
      <LangVersion>latest</LangVersion>
      <TargetFramework>net472</TargetFramework>
    </PropertyGroup>
    ```
5. Add the required assembly references
    * In your .csproj file add the following:
    ```xml
    <ItemGroup>
		  <!-- Wrath Assemblies -->
		  <Reference Include="Assembly-CSharp-firstpass.dll">
			  <HintPath>$(WrathPath)\Wrath_Data\Managed\Assembly-CSharp-firstpass.dll</HintPath>
		  </Reference>
      <Reference Include="Newtonsoft.Json">
        <HintPath>$(WrathPath)\Wrath_Data\Managed\Newtonsoft.Json.dll</HintPath>
      </Reference>
		  <Reference Include="Owlcat.Runtime.Core">
			  <HintPath>$(WrathPath)\Wrath_Data\Managed\Owlcat.Runtime.Core.dll</HintPath>
		  </Reference>
		  <Reference Include="Owlcat.Runtime.UI">
			  <HintPath>$(WrathPath)\Wrath_Data\Managed\Owlcat.Runtime.UI.dll</HintPath>
		  </Reference>
		  <Reference Include="Owlcat.Runtime.Validation">
			  <HintPath>$(WrathPath)\Wrath_Data\Managed\Owlcat.Runtime.Validation.dll</HintPath>
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

		  <!-- UMM & Harmony -->
		  <Reference Include="0Harmony">
			  <HintPath>$(WrathPath)\Wrath_Data\Managed\UnityModManager\0Harmony.dll</HintPath>
		  </Reference>
		  <Reference Include="UnityModManager">
			  <HintPath>$(WrathPath)\Wrath_Data\Managed\UnityModManager\UnityModManager.dll</HintPath>
		  </Reference>
	  </ItemGroup>
    ```
    * **Important:** Make sure your assembly references do not declare `<Private>false</Private>` or DLL Merging will fail
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
8. (Optional) Create a Unity AssetBundle called `<modname>_assets`
    * Use this to import Unity assets, see [Unity Assets](usage/utils.md#unity-assets) for more details
    * Be sure to distribute this file with your mod assembly
8. You're ready to go!

If you already have a project or are having trouble, take a look at [BlueprintCore Tutorial.csproj](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCoreTutorial/BlueprintCoreTutorial/BlueprintCoreTutorial.csproj).

Your project file should look almost identical to the tutorial project file, with the exception that you may have additional package and assembly references. In particular make sure:

* Your publicized assembly is called `Assembly-CSharp.dll`
* Your assembly references do not set `<Private>false</Private>`
* All referenced assemblies are included

Without these `ILRepack` will fail.

## Optional: Reduce Assembly Size with ILStrip

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
         <Entry Include="BlueprintCore.Utils.Assets.AssetTool/AssetBundle_Patch" />
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

### Troubleshooting

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

## Optional: Automatic Mod Deployment

Using a [Copy task](https://docs.microsoft.com/en-us/visualstudio/msbuild/copy-task?view=vs-2022) you can automatically deploy your mod each time you build.

Add a DeployMod target to your .csproj file, using your mod's name in place of `BlueprintCoreTutorial`:

```xml
<!-- Automatic Deployment Setup -->
<Target Name="DeployMod" AfterTargets="ILStrip">
  <ItemGroup>
    <Assembly Include="$(OutputPath)\BlueprintCoreTutorial.dll" />
    <ModConfig Include="$(OutputPath)\Info.json" />
    <Strings Include="$(OutputPath)\LocalizedStrings.json" />
    <Assets Include="$(OutputPath)\*_assets" />
  </ItemGroup>

  <Copy SourceFiles="@(Assembly)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
  <Copy SourceFiles="@(ModConfig)" DestinationFolder="$(WrathPath)\Mods\BlueprintCoreTutorial" />
  <Copy SourceFiles="@(Strings)" DestinationFolder="$(WrathPath)\Mods\$(MSBuildProjectName)" />
  <Copy SourceFiles="@(Assets)" DestinationFolder="$(WrathPath)\Mods\$(MSBuildProjectName)" />
</Target>
```

Make sure to use a different `Assembly` item name than in the ILStrip target. Although they are declared in the context of the target, they are global for the project file.

If you are not using ILStrip replace `AfterTargets="ILStrip"` with `AfterTargets="ILRepack"`.