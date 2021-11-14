using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintCharacterClassGroup"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCharacterClassGroup))]
  public class CharacterClassGroupConfigurator : BaseBlueprintConfigurator<BlueprintCharacterClassGroup, CharacterClassGroupConfigurator>
  {
     private CharacterClassGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CharacterClassGroupConfigurator For(string name)
    {
      return new CharacterClassGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CharacterClassGroupConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCharacterClassGroup>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CharacterClassGroupConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCharacterClassGroup>(name, assetId);
      return For(name);
    }
  }
}
