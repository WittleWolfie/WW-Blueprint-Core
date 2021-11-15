using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Sound;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintAreaMechanics"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaMechanics))]
  public class AreaMechanicsConfigurator : BaseBlueprintConfigurator<BlueprintAreaMechanics, AreaMechanicsConfigurator>
  {
     private AreaMechanicsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaMechanicsConfigurator For(string name)
    {
      return new AreaMechanicsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaMechanicsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaMechanics>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaMechanicsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaMechanics>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaMechanics.Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArea"/></param>
    [Generated]
    public AreaMechanicsConfigurator SetArea(string value)
    {
      return OnConfigureInternal(bp => bp.Area = BlueprintTool.GetRef<BlueprintAreaReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaMechanics.Scene"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaMechanicsConfigurator SetScene(SceneReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Scene = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaMechanics.AdditionalDataBank"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaMechanicsConfigurator SetAdditionalDataBank(AkBankReference value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AdditionalDataBank = value);
    }
  }
}
