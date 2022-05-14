//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Cutscene"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCutsceneConfigurator<T, TBuilder>
    : BaseGateConfigurator<T, TBuilder>
    where T : Cutscene
    where TBuilder : BaseCutsceneConfigurator<T, TBuilder>
  {
    protected BaseCutsceneConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="StopCutsceneWhenExitingArea"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RestCutscene</term><description>e45b17a590873794ebf427e00f5462fa</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddStopCutsceneWhenExitingArea()
    {
      return AddComponent(new StopCutsceneWhenExitingArea());
    }
  }
}
