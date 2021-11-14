using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Formations;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>Configurator for <see cref="FollowersFormation"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FollowersFormation))]
  public class FollowersFormationConfigurator : BaseBlueprintConfigurator<FollowersFormation, FollowersFormationConfigurator>
  {
     private FollowersFormationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FollowersFormationConfigurator For(string name)
    {
      return new FollowersFormationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FollowersFormationConfigurator New(string name)
    {
      BlueprintTool.Create<FollowersFormation>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FollowersFormationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FollowersFormation>(name, assetId);
      return For(name);
    }
  }
}
