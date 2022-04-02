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
    /// Adds <see cref="ContextActionStealBuffs"/>
    /// </summary>
    [Implements(typeof(ContextActionStealBuffs))]
    public static ActionsBuilder StealBuffs(this ActionsBuilder builder, SpellDescriptor descriptor)
    {
      var steal = ElementTool.Create<ContextActionStealBuffs>();
      steal.m_Descriptor = descriptor;
      return builder.Add(steal);
    }

    /// <summary>
    /// Adds <see cref="ContextRestoreResource"/>
    /// </summary>
    /// 
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Implements(typeof(ContextRestoreResource))]
    public static ActionsBuilder RestoreResource(
        this ActionsBuilder builder, string resource, ContextValue? amount = null)
    {
      var restore = ElementTool.Create<ContextRestoreResource>();
      restore.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);

      if (amount != null)
      {
        restore.ContextValueRestoration = true;
        restore.Value = amount;
      }
      return builder.Add(restore);
    }

    /// <summary>
    /// Adds <see cref="ContextSpendResource"/>
    /// </summary>
    /// 
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Implements(typeof(ContextSpendResource))]
    public static ActionsBuilder SpendResource(
        this ActionsBuilder builder, string resource, ContextValue? amount = null)
    {
      var spend = ElementTool.Create<ContextSpendResource>();
      spend.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);

      if (amount != null)
      {
        spend.ContextValueSpendure = true;
        spend.Value = amount;
      }
      return builder.Add(spend);
    }

    // Default GUIDs for Demoralize buffs
    private const string Shaken = "25ec6cb6ab1845c48a95f9c20b034220";
    private const string Frightened = "f08a7239aa961f34c8301518e71d4cdf";
    private const string DisplayWeaponProwess = "ac8d4d2e375a8c841a19ed46696e5af2";
    private const string ShatterConfidenceFeature = "14225a2e4561bfd46874c9a4a97e7133";
    private const string ShatterConfidenceBuff = "51f5a63f1a0cb9047acdad77fc437312";

    /// <summary>
    /// Adds <see cref="Demoralize"/>
    /// </summary>
    [Implements(typeof(Demoralize))]
    public static ActionsBuilder Demoralize(
        this ActionsBuilder builder,
        int bonus = 0,
        bool dazzlingDisplay = false,
        string effect = Shaken,
        string greaterEffect = Frightened,
        string swordlordProwess = DisplayWeaponProwess,
        string shatterConfidenceFeature = ShatterConfidenceFeature,
        string shatterConfidenceBuff = ShatterConfidenceBuff,
        ActionsBuilder? tricksterRank3Actions = null)
    {
      var demoralize = ElementTool.Create<Demoralize>();
      demoralize.Bonus = bonus;
      demoralize.DazzlingDisplay = dazzlingDisplay;
      demoralize.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(effect);
      demoralize.m_GreaterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(greaterEffect);
      demoralize.m_SwordlordProwessFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(swordlordProwess);
      demoralize.m_ShatterConfidenceFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(shatterConfidenceFeature);
      demoralize.m_ShatterConfidenceBuff =
          BlueprintTool.GetRef<BlueprintBuffReference>(shatterConfidenceBuff);
      demoralize.TricksterRank3Actions = tricksterRank3Actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(demoralize);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    /// 
    /// <param name="enhancements"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment">BlueprintItemEnchantment</see></param>
    [Implements(typeof(EnhanceWeapon))]
    public static ActionsBuilder MagicWeapon(
        this ActionsBuilder builder,
        string[] enhancements,
        ContextDurationValue duration,
        ContextValue level,
        bool greater = false,
        bool useSecondaryHand = false)
    {
      return EnhanceWeaponInternal(
          builder,
          EnhanceWeapon.EnchantmentApplyType.MagicWeapon,
          enhancements,
          duration,
          level,
          greater,
          useSecondaryHand: useSecondaryHand);
    }

    /// <inheritdoc cref="MagicWeapon"/>
    [Implements(typeof(EnhanceWeapon))]
    public static ActionsBuilder MagicFang(
        this ActionsBuilder builder,
        string[] enhancements,
        ContextDurationValue duration,
        ContextValue level,
        bool greater = false)
    {
      return EnhanceWeaponInternal(
          builder,
          EnhanceWeapon.EnchantmentApplyType.MagicFang,
          enhancements,
          duration,
          level,
          greater);
    }

    private static ActionsBuilder EnhanceWeaponInternal(
        ActionsBuilder builder,
        EnhanceWeapon.EnchantmentApplyType type,
        string[] enhancements,
        ContextDurationValue duration,
        ContextValue level,
        bool greater,
        bool useSecondaryHand = false)
    {
      var enhance = ElementTool.Create<EnhanceWeapon>();
      enhance.EnchantmentType = type;
      enhance.m_Enchantment =
          enhancements
              .Select(
                  enhancement =>
                      BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enhancement))
              .ToArray();
      enhance.DurationValue = duration;
      enhance.EnchantLevel = level;
      enhance.Greater = greater;
      enhance.UseSecondaryHand = useSecondaryHand;
      return builder.Add(enhance);
    }

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