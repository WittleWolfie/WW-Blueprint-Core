using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintAreaTransition"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaTransition))]
  public class AreaTransitionConfigurator : BaseBlueprintConfigurator<BlueprintAreaTransition, AreaTransitionConfigurator>
  {
     private AreaTransitionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaTransitionConfigurator For(string name)
    {
      return new AreaTransitionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaTransitionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaTransition>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaTransitionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaTransition>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaTransition.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaTransitionConfigurator AddToActions(params ConditionAction[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Actions = CommonTool.Append(bp.m_Actions, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaTransition.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaTransitionConfigurator RemoveFromActions(params ConditionAction[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Actions = bp.m_Actions.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
