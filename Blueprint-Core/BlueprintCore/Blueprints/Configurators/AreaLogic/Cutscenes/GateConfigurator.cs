using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Gate"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(Gate))]
  public abstract class BaseGateConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : Gate
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseGateConfigurator(string name) : base(name) { }
  }

  /// <summary>Configurator for <see cref="Gate"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(Gate))]
  public class GateConfigurator : BaseBlueprintConfigurator<Gate, GateConfigurator>
  {
     private GateConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GateConfigurator For(string name)
    {
      return new GateConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GateConfigurator New(string name)
    {
      BlueprintTool.Create<Gate>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GateConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<Gate>(name, assetId);
      return For(name);
    }
  }
}
