using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="TargetMainCharacter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetMainCharacter))]
  public class TargetMainCharacterConfigurator : BaseConsiderationConfigurator<TargetMainCharacter, TargetMainCharacterConfigurator>
  {
     private TargetMainCharacterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetMainCharacterConfigurator For(string name)
    {
      return new TargetMainCharacterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TargetMainCharacterConfigurator New(string name)
    {
      BlueprintTool.Create<TargetMainCharacter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetMainCharacterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TargetMainCharacter>(name, assetId);
      return For(name);
    }
  }
}
