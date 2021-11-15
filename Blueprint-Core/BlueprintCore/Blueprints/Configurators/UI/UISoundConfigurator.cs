using BlueprintCore.Utils;
using Kingmaker.UI;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UI
{
  /// <summary>Configurator for <see cref="BlueprintUISound"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUISound))]
  public class UISoundConfigurator : BaseBlueprintConfigurator<BlueprintUISound, UISoundConfigurator>
  {
     private UISoundConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UISoundConfigurator For(string name)
    {
      return new UISoundConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UISoundConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUISound>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UISoundConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUISound>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.Sounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator AddToSounds(params BlueprintUISound.UISound[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Sounds.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.Sounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator RemoveFromSounds(params BlueprintUISound.UISound[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Sounds = bp.Sounds.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.ArmyManagement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator AddToArmyManagement(params BlueprintUISound.UISound[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ArmyManagement.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.ArmyManagement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator RemoveFromArmyManagement(params BlueprintUISound.UISound[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ArmyManagement = bp.ArmyManagement.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator AddToTooltip(params BlueprintUISound.UISound[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Tooltip.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUISound.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator RemoveFromTooltip(params BlueprintUISound.UISound[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Tooltip = bp.Tooltip.Where(item => !values.Contains(item)).ToList());
    }
  }
}
