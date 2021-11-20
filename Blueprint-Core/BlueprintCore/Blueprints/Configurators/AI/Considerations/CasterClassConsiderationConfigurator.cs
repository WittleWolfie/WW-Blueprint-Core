using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="CasterClassConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CasterClassConsideration))]
  public class CasterClassConsiderationConfigurator : BaseConsiderationConfigurator<CasterClassConsideration, CasterClassConsiderationConfigurator>
  {
    private CasterClassConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CasterClassConsiderationConfigurator For(string name)
    {
      return new CasterClassConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CasterClassConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<CasterClassConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CasterClassConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<CasterClassConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CasterClassConsideration.NotCasterScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CasterClassConsiderationConfigurator SetNotCasterScore(float notCasterScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NotCasterScore = notCasterScore;
          });
    }

    /// <summary>
    /// Sets <see cref="CasterClassConsideration.ArcaneCasterScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CasterClassConsiderationConfigurator SetArcaneCasterScore(float arcaneCasterScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArcaneCasterScore = arcaneCasterScore;
          });
    }

    /// <summary>
    /// Sets <see cref="CasterClassConsideration.DivineCasterScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CasterClassConsiderationConfigurator SetDivineCasterScore(float divineCasterScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DivineCasterScore = divineCasterScore;
          });
    }
  }
}
