# Known Issues

### Build Fails: ILRepack: Failed to load assembly

Make sure the assembly listed is in the location described. Usually this means that an assembly referenced by your assembly is not in the working directory for ILRepack. Thhe configuration suggested for BlueprintCore uses `OutputPath` as the working directory:

```xml
<ILRepack OutputType="Dll" MainAssembly="@(OutputAssembly)" OutputAssembly="@(OutputAssembly)" InputAssemblies="@(InputAssemblies)" WorkingDirectory="$(OutputPath)" />
```

To make sure dependent assemblies are copied to `OutputPath` in Visual Studio open the assembly dependency properties and set `Copy Local` to `Yes`. Alternatively, remove `<Private>False</Private>` from the reference in your project file.

If you do not want to copy assemblies to output you'll need to change the ILRepack configuration to use a working directory with all required assemblies.

### Fails to resolve assembly: Assembly-CSharp

This specific failure is usually caused by the assembly publicizer. When the publicize task runs it creates `Assembly-CSharp_public.dll`, but ILRepack is looking for `Assembly-CSharp.dll`. You can fix this by updating your assembly reference and renaming the file after publicizing:

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

After updating your project file, rebuild your solution and it should work.