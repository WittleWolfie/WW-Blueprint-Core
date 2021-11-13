using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintCharacterClass"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCharacterClass))]
  public class CharacterClassConfigurator : BaseBlueprintConfigurator<BlueprintCharacterClass, CharacterClassConfigurator>
  {
     private CharacterClassConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CharacterClassConfigurator For(string name)
    {
      return new CharacterClassConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CharacterClassConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCharacterClass>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CharacterClassConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCharacterClass>(name, assetId);
      return For(name);
    }

  }
}
