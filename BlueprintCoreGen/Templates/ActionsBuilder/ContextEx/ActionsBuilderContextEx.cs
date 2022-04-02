using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCoreGen.Actions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most <see cref="ContextAction"/> types. Some
  /// <see cref="ContextAction"/> types are in more specific extensions such as
  /// <see cref="AVEx.ActionsBuilderAVEx">AVEx</see> or <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderContextEx
  {

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Actions.SwordlordAdaptiveTacticsAdd">SwordlordAdaptiveTacticsAdd</see>
    /// </summary>
    /// 
    /// <param name="source"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(SwordlordAdaptiveTacticsAdd))]
    public static ActionsBuilder SwordlordAdaptiveTacticsAdd(this ActionsBuilder builder, string source)
    {
      var add = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      add.m_Source = BlueprintTool.GetRef<BlueprintUnitFactReference>(source);
      return builder.Add(add);
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionSwarmAttack"/>
    /// </summary>
    [Implements(typeof(ContextActionSwarmAttack))]
    public static ActionsBuilder SwarmAttack(this ActionsBuilder builder, ActionsBuilder attackActions)
    {
      var attack = ElementTool.Create<ContextActionSwarmAttack>();
      attack.AttackActions = attackActions.Build();
      return builder.Add(attack);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionAddRandomTrashItem"/>
    /// </summary>
    [Implements(typeof(ContextActionAddRandomTrashItem))]
    public static ActionsBuilder GiveRandomTrashToPlayer(
        this ActionsBuilder builder,
        TrashLootType type,
        int maxCost,
        bool identify = false,
        bool silent = false)
    {
      var addTrash = ElementTool.Create<ContextActionAddRandomTrashItem>();
      addTrash.m_LootType = type;
      addTrash.m_MaxCost = maxCost;
      addTrash.m_Identify = identify;
      addTrash.m_Silent = silent;
      return builder.Add(addTrash);
    }
  }
}