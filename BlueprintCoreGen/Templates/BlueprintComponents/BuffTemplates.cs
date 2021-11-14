using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using System;

namespace BlueprintCoreGen.Templates.BlueprintComponents
{
  abstract class BuffTemplates<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : BuffTemplates<T, TBuilder>
  {
    private BuffTemplates(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="AddEffectFastHealing"/>
    /// </summary>
    [Implements(typeof(AddEffectFastHealing))]
    public TBuilder FastHealing(int baseValue, ContextValue bonusValue = null)
    {
      var fastHealing = new AddEffectFastHealing
      {
        Heal = baseValue,
        Bonus = bonusValue ?? 0
      };
      return AddComponent(fastHealing);
    }

    /// <summary>
    /// Adds <see cref="RemoveWhenCombatEnded"/>
    /// </summary>
    [Implements(typeof(RemoveWhenCombatEnded))]
    public TBuilder RemoveWhenCombatEnds()
    {
      return AddUniqueComponent(new RemoveWhenCombatEnded(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.Mechanics.Buffs.BuffSleeping">BuffSleeping</see>
    /// </summary>
    [Implements(typeof(BuffSleeping))]
    public TBuilder BuffSleeping(
        int? wakeupPerceptionDC = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var sleeping = new BuffSleeping();
      if (wakeupPerceptionDC is not null) { sleeping.WakeupPerceptionDC = wakeupPerceptionDC.Value; }
      return AddUniqueComponent(sleeping, mergeBehavior, merge);
    }
  }
}
