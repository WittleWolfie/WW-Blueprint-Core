using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.QA.Arbiter;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArbiterRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArbiterRoot))]
  public class ArbiterRootConfigurator : BaseBlueprintConfigurator<BlueprintArbiterRoot, ArbiterRootConfigurator>
  {
    private ArbiterRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArbiterRootConfigurator For(string name)
    {
      return new ArbiterRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArbiterRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArbiterRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArbiterRootConfigurator SetIgnoreScenesInReport(SceneReference[]? ignoreScenesInReport)
    {
      ValidateParam(ignoreScenesInReport);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreScenesInReport = ignoreScenesInReport;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArbiterRootConfigurator AddToIgnoreScenesInReport(params SceneReference[] ignoreScenesInReport)
    {
      ValidateParam(ignoreScenesInReport);
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreScenesInReport = CommonTool.Append(bp.IgnoreScenesInReport, ignoreScenesInReport ?? new SceneReference[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArbiterRootConfigurator RemoveFromIgnoreScenesInReport(params SceneReference[] ignoreScenesInReport)
    {
      ValidateParam(ignoreScenesInReport);
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreScenesInReport = bp.IgnoreScenesInReport.Where(item => !ignoreScenesInReport.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArbiterRootConfigurator SetIgnoreScenesInReportByFilter(string[]? ignoreScenesInReportByFilter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreScenesInReportByFilter = ignoreScenesInReportByFilter;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArbiterRootConfigurator AddToIgnoreScenesInReportByFilter(params string[] ignoreScenesInReportByFilter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreScenesInReportByFilter = CommonTool.Append(bp.IgnoreScenesInReportByFilter, ignoreScenesInReportByFilter ?? new string[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArbiterRootConfigurator RemoveFromIgnoreScenesInReportByFilter(params string[] ignoreScenesInReportByFilter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreScenesInReportByFilter = bp.IgnoreScenesInReportByFilter.Where(item => !ignoreScenesInReportByFilter.Contains(item)).ToArray();
          });
    }
  }
}
