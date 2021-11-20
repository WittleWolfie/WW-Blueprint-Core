using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintPet"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPet))]
  public class PetConfigurator : BaseBlueprintConfigurator<BlueprintPet, PetConfigurator>
  {
    private PetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PetConfigurator For(string name)
    {
      return new PetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static PetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintPet>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PetConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintPet>(name, assetId);
      return For(name);
    }
  }
}
