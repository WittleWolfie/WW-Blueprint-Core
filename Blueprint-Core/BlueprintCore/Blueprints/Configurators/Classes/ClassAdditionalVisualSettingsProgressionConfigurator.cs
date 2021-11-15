using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintClassAdditionalVisualSettingsProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClassAdditionalVisualSettingsProgression))]
  public class ClassAdditionalVisualSettingsProgressionConfigurator : BaseBlueprintConfigurator<BlueprintClassAdditionalVisualSettingsProgression, ClassAdditionalVisualSettingsProgressionConfigurator>
  {
     private ClassAdditionalVisualSettingsProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClassAdditionalVisualSettingsProgressionConfigurator For(string name)
    {
      return new ClassAdditionalVisualSettingsProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ClassAdditionalVisualSettingsProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettingsProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClassAdditionalVisualSettingsProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettingsProgression>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsProgressionConfigurator AddToEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Entries = CommonTool.Append(bp.Entries, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsProgressionConfigurator RemoveFromEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Entries = bp.Entries.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
