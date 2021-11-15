using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;

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

    /// <summary>
    /// Sets <see cref="BlueprintMythicInfo._mythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicInfoConfigurator Set_mythic(Mythic value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp._mythic = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicInfo._etudeReference"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintEtude"/></param>
    [Generated]
    public MythicInfoConfigurator Set_etudeReference(string value)
    {
      return OnConfigureInternal(bp => bp._etudeReference = BlueprintTool.GetRef<BlueprintEtudeReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicInfo._mythicName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicInfoConfigurator Set_mythicName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp._mythicName = value);
    }
  }
}
