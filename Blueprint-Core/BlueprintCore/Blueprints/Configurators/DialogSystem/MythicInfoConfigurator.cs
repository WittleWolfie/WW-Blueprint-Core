using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintMythicInfo"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMythicInfo))]
  public class MythicInfoConfigurator : BaseBlueprintConfigurator<BlueprintMythicInfo, MythicInfoConfigurator>
  {
     private MythicInfoConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MythicInfoConfigurator For(string name)
    {
      return new MythicInfoConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MythicInfoConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintMythicInfo>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MythicInfoConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintMythicInfo>(name, assetId);
      return For(name);
    }

  }
}
