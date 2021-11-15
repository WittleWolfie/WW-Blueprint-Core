using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintCheck"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCheck))]
  public class CheckConfigurator : BaseCueBaseConfigurator<BlueprintCheck, CheckConfigurator>
  {
     private CheckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CheckConfigurator For(string name)
    {
      return new CheckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CheckConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCheck>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CheckConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCheck>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetType(StatType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.DC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetDC(int value)
    {
      return OnConfigureInternal(bp => bp.DC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.Hidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetHidden(bool value)
    {
      return OnConfigureInternal(bp => bp.Hidden = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator AddToDCModifiers(params DCModifier[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DCModifiers = CommonTool.Append(bp.DCModifiers, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator RemoveFromDCModifiers(params DCModifier[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DCModifiers = bp.DCModifiers.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.m_Success"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public CheckConfigurator SetSuccess(string value)
    {
      return OnConfigureInternal(bp => bp.m_Success = BlueprintTool.GetRef<BlueprintCueBaseReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.m_Fail"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public CheckConfigurator SetFail(string value)
    {
      return OnConfigureInternal(bp => bp.m_Fail = BlueprintTool.GetRef<BlueprintCueBaseReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.m_UnitEvaluator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetUnitEvaluator(UnitEvaluator value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_UnitEvaluator = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetExperience(DialogExperience value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Experience = value);
    }
  }
}
