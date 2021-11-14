using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.Blueprints;
using Kingmaker.QA.Arbiter;

namespace BlueprintCore.Blueprints.Configurators.QA.Arbiter
{
  /// <summary>Configurator for <see cref="BlueprintArbiterInstruction"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArbiterInstruction))]
  public class ArbiterInstructionConfigurator : BaseBlueprintConfigurator<BlueprintArbiterInstruction, ArbiterInstructionConfigurator>
  {
     private ArbiterInstructionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArbiterInstructionConfigurator For(string name)
    {
      return new ArbiterInstructionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArbiterInstructionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArbiterInstruction>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArbiterInstructionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArbiterInstruction>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="ArbiterAreaTest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Area"><see cref="BlueprintArea"/></param>
    /// <param name="OverrideAreaPreset"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    [Implements(typeof(ArbiterAreaTest))]
    public ArbiterInstructionConfigurator AddArbiterAreaTest(
        string Area,
        string OverrideAreaPreset,
        bool OverrideTimeOfDay,
        TimeOfDay TimeOfDay,
        bool MakeMapScreenshot,
        ArbiterElementList AreaParts)
    {
      ValidateParam(TimeOfDay);
      ValidateParam(AreaParts);
      
      var component =  new ArbiterAreaTest();
      component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(Area);
      component.OverrideAreaPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(OverrideAreaPreset);
      component.OverrideTimeOfDay = OverrideTimeOfDay;
      component.TimeOfDay = TimeOfDay;
      component.MakeMapScreenshot = MakeMapScreenshot;
      component.AreaParts = AreaParts;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArbiterWeaponTest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(ArbiterWeaponTest))]
    public ArbiterInstructionConfigurator AddArbiterWeaponTest(
        string Weapon)
    {
      
      var component =  new ArbiterWeaponTest();
      component.Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(Weapon);
      return AddComponent(component);
    }
  }
}
