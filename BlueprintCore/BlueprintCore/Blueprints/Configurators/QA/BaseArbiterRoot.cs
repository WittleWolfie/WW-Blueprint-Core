//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.QA.Arbiter;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArbiterRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArbiterRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArbiterRoot
    where TBuilder : BaseArbiterRootConfigurator<T, TBuilder>
  {
    protected BaseArbiterRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArbiterRoot.ProjectId"/>
    /// </summary>
    public TBuilder SetProjectId(string projectId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ProjectId = projectId;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArbiterRoot.ProjectId"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProjectId(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ProjectId is null) { return; }
          action.Invoke(bp.ProjectId);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArbiterRoot.Resolution"/>
    /// </summary>
    public TBuilder SetResolution(Vector2Int resolution)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Resolution = resolution;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArbiterRoot.Resolution"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResolution(Action<Vector2Int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Resolution);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/>
    /// </summary>
    public TBuilder SetIgnoreScenesInReport(SceneReference[] ignoreScenesInReport)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in ignoreScenesInReport) { Validate(item); }
          bp.IgnoreScenesInReport = ignoreScenesInReport;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/>
    /// </summary>
    public TBuilder AddToIgnoreScenesInReport(params SceneReference[] ignoreScenesInReport)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreScenesInReport = bp.IgnoreScenesInReport ?? new SceneReference[0];
          bp.IgnoreScenesInReport = CommonTool.Append(bp.IgnoreScenesInReport, ignoreScenesInReport);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/>
    /// </summary>
    public TBuilder RemoveFromIgnoreScenesInReport(params SceneReference[] ignoreScenesInReport)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IgnoreScenesInReport is null) { return; }
          bp.IgnoreScenesInReport = bp.IgnoreScenesInReport.Where(val => !ignoreScenesInReport.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIgnoreScenesInReport(Func<SceneReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IgnoreScenesInReport is null) { return; }
          bp.IgnoreScenesInReport = bp.IgnoreScenesInReport.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/>
    /// </summary>
    public TBuilder ClearIgnoreScenesInReport()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreScenesInReport = new SceneReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArbiterRoot.IgnoreScenesInReport"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIgnoreScenesInReport(Action<SceneReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IgnoreScenesInReport is null) { return; }
          bp.IgnoreScenesInReport.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/>
    /// </summary>
    public TBuilder SetIgnoreScenesInReportByFilter(string[] ignoreScenesInReportByFilter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreScenesInReportByFilter = ignoreScenesInReportByFilter;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/>
    /// </summary>
    public TBuilder AddToIgnoreScenesInReportByFilter(params string[] ignoreScenesInReportByFilter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreScenesInReportByFilter = bp.IgnoreScenesInReportByFilter ?? new string[0];
          bp.IgnoreScenesInReportByFilter = CommonTool.Append(bp.IgnoreScenesInReportByFilter, ignoreScenesInReportByFilter);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/>
    /// </summary>
    public TBuilder RemoveFromIgnoreScenesInReportByFilter(params string[] ignoreScenesInReportByFilter)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IgnoreScenesInReportByFilter is null) { return; }
          bp.IgnoreScenesInReportByFilter = bp.IgnoreScenesInReportByFilter.Where(val => !ignoreScenesInReportByFilter.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIgnoreScenesInReportByFilter(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IgnoreScenesInReportByFilter is null) { return; }
          bp.IgnoreScenesInReportByFilter = bp.IgnoreScenesInReportByFilter.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/>
    /// </summary>
    public TBuilder ClearIgnoreScenesInReportByFilter()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreScenesInReportByFilter = new string[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArbiterRoot.IgnoreScenesInReportByFilter"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIgnoreScenesInReportByFilter(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IgnoreScenesInReportByFilter is null) { return; }
          bp.IgnoreScenesInReportByFilter.ForEach(action);
        });
    }
  }
}
