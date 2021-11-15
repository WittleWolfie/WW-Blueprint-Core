using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.AreaLogic.Cutscenes.Components;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes
{
  /// <summary>Configurator for <see cref="Cutscene"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(Cutscene))]
  public class CutsceneConfigurator : BaseGateConfigurator<Cutscene, CutsceneConfigurator>
  {
     private CutsceneConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CutsceneConfigurator For(string name)
    {
      return new CutsceneConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CutsceneConfigurator New(string name)
    {
      BlueprintTool.Create<Cutscene>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CutsceneConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<Cutscene>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.Priority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetPriority(CutscenePriority value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Priority = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.NonSkippable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetNonSkippable(bool value)
    {
      return OnConfigureInternal(bp => bp.NonSkippable = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.ForbidDialogs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetForbidDialogs(bool value)
    {
      return OnConfigureInternal(bp => bp.ForbidDialogs = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.ForbidRandomIdles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetForbidRandomIdles(bool value)
    {
      return OnConfigureInternal(bp => bp.ForbidRandomIdles = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.IsBackground"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetIsBackground(bool value)
    {
      return OnConfigureInternal(bp => bp.IsBackground = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.Sleepless"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetSleepless(bool value)
    {
      return OnConfigureInternal(bp => bp.Sleepless = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.AllowCopies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetAllowCopies(bool value)
    {
      return OnConfigureInternal(bp => bp.AllowCopies = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.AwakeRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetAwakeRange(float value)
    {
      return OnConfigureInternal(bp => bp.AwakeRange = value);
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.Anchors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator AddToAnchors(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Anchors = CommonTool.Append(bp.Anchors, values));
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.Anchors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator RemoveFromAnchors(params EntityReference[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Anchors = bp.Anchors.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="Cutscene.MarkedUnitHandling"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetMarkedUnitHandling(Cutscene.MarkedUnitHandlingType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MarkedUnitHandling = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.DefaultParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetDefaultParameters(ParametrizedContextSetter value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultParameters = value);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.OnStopped"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetOnStopped(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnStopped = value.Build());
    }

    /// <summary>
    /// Adds <see cref="StopCutsceneWhenExitingArea"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StopCutsceneWhenExitingArea))]
    public CutsceneConfigurator AddStopCutsceneWhenExitingArea()
    {
      return AddComponent(new StopCutsceneWhenExitingArea());
    }

    /// <summary>
    /// Adds <see cref="DestroyCutsceneOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DestroyCutsceneOnLoad))]
    public CutsceneConfigurator AddDestroyCutsceneOnLoad()
    {
      return AddComponent(new DestroyCutsceneOnLoad());
    }
  }
}
