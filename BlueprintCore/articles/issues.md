# Known Issues

### NuGet Package Restore Fails: Unable to find path for some files

This is an issue with file path length limitations on Windows. By default the file path cannot exceed 260 characters. See [this thread](https://github.com/NuGet/Home/issues/3324#issuecomment-977921700) for more details.

You can either follow the workaround in the linked thread or you can move your project closer to the root of your filesystem. The longest path produced by NuGet is `packages\WW-Blueprint-Core.1.2.1\contentFiles/any/net472/BlueprintCore/Blueprints/Configurators/Armies/Brain/TacticalCombatCanAttackThisTurnConsiderationConfigurator.cs`, 156 characters. The path to your project's packages folder can be at most 104 characters.