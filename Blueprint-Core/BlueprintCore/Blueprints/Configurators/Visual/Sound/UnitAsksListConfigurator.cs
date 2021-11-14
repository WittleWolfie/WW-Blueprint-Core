using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Visual.Sound;
using System;

namespace BlueprintCore.Blueprints.Configurators.Visual.Sound
{
  /// <summary>Configurator for <see cref="BlueprintUnitAsksList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitAsksList))]
  public class UnitAsksListConfigurator : BaseBlueprintConfigurator<BlueprintUnitAsksList, UnitAsksListConfigurator>
  {
     private UnitAsksListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitAsksListConfigurator For(string name)
    {
      return new UnitAsksListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitAsksListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitAsksList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitAsksListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitAsksList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="UnitAsksComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitAsksComponent))]
    public UnitAsksListConfigurator AddUnitAsksComponent(
        string[] SoundBanks,
        string PreviewSound,
        UnitAsksComponent.Bark Aggro,
        UnitAsksComponent.Bark Pain,
        UnitAsksComponent.Bark Fatigue,
        UnitAsksComponent.Bark Death,
        UnitAsksComponent.Bark Unconscious,
        UnitAsksComponent.Bark LowHealth,
        UnitAsksComponent.Bark CriticalHit,
        UnitAsksComponent.Bark Order,
        UnitAsksComponent.Bark OrderMove,
        UnitAsksComponent.Bark Selected,
        UnitAsksComponent.Bark RefuseEquip,
        UnitAsksComponent.Bark RefuseCast,
        UnitAsksComponent.Bark CheckSuccess,
        UnitAsksComponent.Bark CheckFail,
        UnitAsksComponent.Bark RefuseUnequip,
        UnitAsksComponent.Bark Discovery,
        UnitAsksComponent.Bark Stealth,
        UnitAsksComponent.Bark StormRain,
        UnitAsksComponent.Bark StormSnow,
        UnitAsksComponent.AnimationBark[] AnimationBarks,
        UnitEntityData m_Unit,
        UnitAsksComponent.Bark m_CurrentlyActiveBark)
    {
      foreach (var item in SoundBanks)
      {
        ValidateParam(item);
      }
      ValidateParam(Aggro);
      ValidateParam(Pain);
      ValidateParam(Fatigue);
      ValidateParam(Death);
      ValidateParam(Unconscious);
      ValidateParam(LowHealth);
      ValidateParam(CriticalHit);
      ValidateParam(Order);
      ValidateParam(OrderMove);
      ValidateParam(Selected);
      ValidateParam(RefuseEquip);
      ValidateParam(RefuseCast);
      ValidateParam(CheckSuccess);
      ValidateParam(CheckFail);
      ValidateParam(RefuseUnequip);
      ValidateParam(Discovery);
      ValidateParam(Stealth);
      ValidateParam(StormRain);
      ValidateParam(StormSnow);
      foreach (var item in AnimationBarks)
      {
        ValidateParam(item);
      }
      ValidateParam(m_Unit);
      ValidateParam(m_CurrentlyActiveBark);
      
      var component =  new UnitAsksComponent();
      component.SoundBanks = SoundBanks;
      component.PreviewSound = PreviewSound;
      component.Aggro = Aggro;
      component.Pain = Pain;
      component.Fatigue = Fatigue;
      component.Death = Death;
      component.Unconscious = Unconscious;
      component.LowHealth = LowHealth;
      component.CriticalHit = CriticalHit;
      component.Order = Order;
      component.OrderMove = OrderMove;
      component.Selected = Selected;
      component.RefuseEquip = RefuseEquip;
      component.RefuseCast = RefuseCast;
      component.CheckSuccess = CheckSuccess;
      component.CheckFail = CheckFail;
      component.RefuseUnequip = RefuseUnequip;
      component.Discovery = Discovery;
      component.Stealth = Stealth;
      component.StormRain = StormRain;
      component.StormSnow = StormSnow;
      component.AnimationBarks = AnimationBarks;
      component.m_Unit = m_Unit;
      component.m_CurrentlyActiveBark = m_CurrentlyActiveBark;
      return AddComponent(component);
    }
  }
}
