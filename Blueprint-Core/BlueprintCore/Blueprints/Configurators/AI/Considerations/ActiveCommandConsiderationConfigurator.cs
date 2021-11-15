using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.UnitLogic.Commands.Base;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ActiveCommandConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ActiveCommandConsideration))]
  public class ActiveCommandConsiderationConfigurator : BaseConsiderationConfigurator<ActiveCommandConsideration, ActiveCommandConsiderationConfigurator>
  {
     private ActiveCommandConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActiveCommandConsiderationConfigurator For(string name)
    {
      return new ActiveCommandConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ActiveCommandConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ActiveCommandConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActiveCommandConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ActiveCommandConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ActiveCommandConsideration.CommandType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ActiveCommandConsiderationConfigurator SetCommandType(UnitCommand.CommandType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CommandType = value);
    }

    /// <summary>
    /// Sets <see cref="ActiveCommandConsideration.HasCommandScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ActiveCommandConsiderationConfigurator SetHasCommandScore(float value)
    {
      return OnConfigureInternal(bp => bp.HasCommandScore = value);
    }

    /// <summary>
    /// Sets <see cref="ActiveCommandConsideration.NoCommandScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ActiveCommandConsiderationConfigurator SetNoCommandScore(float value)
    {
      return OnConfigureInternal(bp => bp.NoCommandScore = value);
    }
  }
}
