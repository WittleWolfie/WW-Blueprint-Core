using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.AreaLogic.Cutscenes.Components;

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
