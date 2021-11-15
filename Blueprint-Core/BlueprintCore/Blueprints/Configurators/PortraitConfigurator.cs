using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintPortrait"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPortrait))]
  public class PortraitConfigurator : BaseBlueprintConfigurator<BlueprintPortrait, PortraitConfigurator>
  {
     private PortraitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PortraitConfigurator For(string name)
    {
      return new PortraitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static PortraitConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintPortrait>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PortraitConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintPortrait>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintPortrait.Data"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PortraitConfigurator SetData(PortraitData value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Data = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintPortrait.m_BackupPortrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintPortrait"/></param>
    [Generated]
    public PortraitConfigurator SetBackupPortrait(string value)
    {
      return OnConfigureInternal(bp => bp.m_BackupPortrait = BlueprintTool.GetRef<BlueprintPortraitReference>(value));
    }

    /// <summary>
    /// Adds <see cref="PortraitDollSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Race"><see cref="BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(PortraitDollSettings))]
    public PortraitConfigurator AddPortraitDollSettings(
        Gender Gender,
        string m_Race)
    {
      ValidateParam(Gender);
      
      var component =  new PortraitDollSettings();
      component.Gender = Gender;
      component.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(m_Race);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PortraitPremiumSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PortraitPremiumSetting))]
    public PortraitConfigurator AddPortraitPremiumSetting()
    {
      return AddComponent(new PortraitPremiumSetting());
    }
  }
}
