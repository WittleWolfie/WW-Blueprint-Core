using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Localization;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ConsiderationCustom"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ConsiderationCustom))]
  public class ConsiderationCustomConfigurator : BaseConsiderationConfigurator<ConsiderationCustom, ConsiderationCustomConfigurator>
  {
     private ConsiderationCustomConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConsiderationCustomConfigurator For(string name)
    {
      return new ConsiderationCustomConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ConsiderationCustomConfigurator New(string name)
    {
      BlueprintTool.Create<ConsiderationCustom>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConsiderationCustomConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ConsiderationCustom>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ConsiderationCustom.Consideration"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="Consideration"/></param>
    [Generated]
    public ConsiderationCustomConfigurator SetConsideration(string value)
    {
      return OnConfigureInternal(bp => bp.Consideration = BlueprintTool.GetRef<ConsiderationReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ConsiderationCustom.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsiderationCustomConfigurator SetTitle(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Title = value);
    }

    /// <summary>
    /// Sets <see cref="ConsiderationCustom.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsiderationCustomConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }
  }
}
