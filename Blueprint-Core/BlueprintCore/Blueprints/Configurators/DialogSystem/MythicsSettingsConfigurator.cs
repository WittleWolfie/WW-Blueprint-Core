using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Tutorial;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintMythicsSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMythicsSettings))]
  public class MythicsSettingsConfigurator : BaseBlueprintConfigurator<BlueprintMythicsSettings, MythicsSettingsConfigurator>
  {
     private MythicsSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MythicsSettingsConfigurator For(string name)
    {
      return new MythicsSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MythicsSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintMythicsSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MythicsSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintMythicsSettings>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintMythicInfo"/></param>
    [Generated]
    public MythicsSettingsConfigurator AddToMythicsInfos(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_MythicsInfos = CommonTool.Append(bp.m_MythicsInfos, values.Select(name => BlueprintTool.GetRef<BlueprintMythicInfoReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintMythicInfo"/></param>
    [Generated]
    public MythicsSettingsConfigurator RemoveFromMythicsInfos(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintMythicInfoReference>(name));
            bp.m_MythicsInfos =
                bp.m_MythicsInfos
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator AddToMythicAlignments(params MythicAlignment[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_MythicAlignments = CommonTool.Append(bp.m_MythicAlignments, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator RemoveFromMythicAlignments(params MythicAlignment[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_MythicAlignments = bp.m_MythicAlignments.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicsSettings.m_TutorialChooseMythic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintTutorial"/></param>
    [Generated]
    public MythicsSettingsConfigurator SetTutorialChooseMythic(string value)
    {
      return OnConfigureInternal(bp => bp.m_TutorialChooseMythic = BlueprintTool.GetRef<BlueprintTutorial.Reference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator AddToCharcaterLevelRestrictions(params int[] values)
    {
      return OnConfigureInternal(bp => bp.CharcaterLevelRestrictions.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator RemoveFromCharcaterLevelRestrictions(params int[] values)
    {
      return OnConfigureInternal(bp => bp.CharcaterLevelRestrictions = bp.CharcaterLevelRestrictions.Where(item => !values.Contains(item)).ToList());
    }
  }
}
