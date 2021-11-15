using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public CharacterClassGroupConfigurator AddToCharacterClasses(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_CharacterClasses = CommonTool.Append(bp.m_CharacterClasses, values.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public CharacterClassGroupConfigurator RemoveFromCharacterClasses(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name));
            bp.m_CharacterClasses =
                bp.m_CharacterClasses
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
