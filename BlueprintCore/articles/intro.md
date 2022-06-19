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
    * `%WrathPath%\Wrath_Data\Managed\0Harmony.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Core.dll`
    * `$WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.UI.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Validation.dll`
    * `%WrathPath%\Wrath_Data\Managed\Owlcat.Runtime.Visual.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityEngine.CoreModule.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityModManager\0Harmony.dll`
    * `$WrathPath%\Wrath_Data\Managed\UnityModManager\UnityModManager.dll`
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
7. You're ready to go!

If you already have a project or are having trouble, take a look at [BlueprintCore Tutorial.csproj](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/BlueprintCore%20Tutorial/BlueprintCore%20Tutorial/BlueprintCore%20Tutorial.csproj).

Your project file should look almost identical to the tutorial project file, with the exception that you may have additional package and assembly references. In particular make sure:

* Your publicized assembly is called `Assembly-CSharp.dll`
* Your assembly references do not set `<Private>false</Private>`
* All referenced assemblies are included

Without these `ILRepack` will fail.

## Using BlueprintCore

For a step-by-step walkthrough see [Tutorials](tutorials/overview.md).

If you're having problems check [Known Issues](usage/issues.md).

If you're interested in contributing see [How to Contribute](contributing.md).

For general usage details see the links below:

* [Blueprints](usage/blueprints.md) - Creating, modifying, and referencing blueprints
* [Actions and Conditions](usage/builders.md) - Using actions and conditions
* [Text, Logging, and Utils](usage/utils.md) - General utility classes
* [Understanding the API](usage/api.md) - Design and creation of the API