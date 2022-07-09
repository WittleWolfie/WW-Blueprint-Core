using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using Owlcat.QA.Validation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Components.Replacements
{
  /// <summary>
  /// Working replacement for Owlcat's AddStatBonusIfHasFact.
  /// </summary>
  /// 
  /// <remarks>
  /// Based on AddStatBonusIfHasFactTTT from
  /// <see href="https://github.com/Vek17/TabletopTweaks-Core/blob/master/TabletopTweaks-Core/">TabletopTweaks-Core</see>
  /// </remarks>
  [AllowMultipleComponents]
  [TypeId("3dcfce44-a7dd-48fe-9331-3681a43dbfa4")]
  public class AddStatBonusIfHasFactFixed :
    UnitBuffComponentDelegate, IUnitGainFactHandler, IUnitSubscriber, ISubscriber, IUnitLostFactHandler
  {
    public ReferenceArrayProxy<BlueprintUnitFact, BlueprintUnitFactReference> RequiredFacts
    {
      get
      {
        return m_RequiredFacts;
      }
    }

    public ReferenceArrayProxy<BlueprintUnitFact, BlueprintUnitFactReference> ExcludeFacts
    {
      get
      {
        return m_ExcludeFacts;
      }
    }

    public override void OnTurnOn()
    {
      Update();
    }

    public override void OnTurnOff()
    {
      Cancel();
    }

    private bool ShouldApplyBonus()
    {
      foreach (BlueprintUnitFact blueprint in ExcludeFacts)
      {
        if (Owner.HasFact(blueprint))
        {
          return false;
        }
      }

      bool hasAnyFacts = false;
      bool hasAllFacts = true;
      foreach (BlueprintUnitFact blueprint in RequiredFacts)
      {
        bool hasFact = Owner.HasFact(blueprint);
        hasAnyFacts = hasAnyFacts || hasFact;
        hasAllFacts = hasAllFacts && hasFact;
      }

      bool allFacts = RequireAllFacts || m_RequiredFacts.Length == 1;
      var shouldApply = allFacts ? hasAllFacts : hasAnyFacts;
      return InvertCondition ? !shouldApply : shouldApply;
    }

    private void Update()
    {
      ModifiableValue stat = Owner.Stats.GetStat(Stat);
      if (stat == null) { return; }

      if (ShouldApplyBonus())
      {
        stat.AddModifierUnique(Bonus.Calculate(Context), Runtime, Descriptor);
        return;
      }
      stat.RemoveModifiersFrom(Runtime);
    }

    private void Cancel()
    {
      ModifiableValue stat = Owner.Stats.GetStat(Stat);
      if (stat == null) { return; }

      stat.RemoveModifiersFrom(Runtime);
    }

    public void HandleUnitGainFact(EntityFact fact)
    {
      if (fact.Blueprint is BlueprintUnitFact bp && (RequiredFacts.HasReference(bp) || ExcludeFacts.HasReference(bp)))
      {
        Update();
      }
    }

    public void HandleUnitLostFact(EntityFact fact)
    {
      if (fact.Blueprint is BlueprintUnitFact bp && (RequiredFacts.HasReference(bp) || ExcludeFacts.HasReference(bp)))
      {
        Update();
      }
    }

    /// <param name="stat">Stat to which the bonus applies</param>
    /// <param name="bonus">Bonus value to apply</param>
    /// <param name="requiredFacts">List of facts the unit must have.</param>
    /// <param name="excludeFacts">
    /// List of facts which block the bonus. This is checked first and applies regardless of
    /// <paramref name="requireAllFacts"/>
    /// </param>
    /// <param name="descriptor">Descriptor used for effect stacking behavior.</param>
    /// <param name="requireAllFacts">
    /// Defaults to true.
    /// <list type="table">
    /// <item>
    ///   <term>true</term>
    ///   <description>Bonus applies only if the unit has all facts in <paramref name="requiredFacts"/></description>
    /// </item>
    /// <item>
    ///   <term>false</term>
    ///   <description>Bonus applies if the unit has any fact in <paramref name="requiredFacts"/></description>
    /// </item>
    /// </list>
    /// </param>
    /// <param name="invertCondition">
    /// Defaults to false.
    /// <list type="table">
    /// <listheader>
    ///   <term>invertCondition</term>
    ///   <term>requireAllFacts</term>
    /// </listheader>
    /// <item>
    ///   <term><c>false</c></term>
    ///   <term><c>false</c></term>
    ///   <description>Bonus applies only if the unit has any fact in <paramref name="requiredFacts"/></description>
    /// </item>
    /// <item>
    ///   <term><c>false</c></term>
    ///   <term><c>true</c></term>
    ///   <description>Bonus applies if the unit has all facts in <paramref name="requiredFacts"/></description>
    /// </item>
    /// <item>
    ///   <term><c>true</c></term>
    ///   <term><c>false</c></term>
    ///   <description>Bonus applies only if the unit has no fact in <paramref name="requiredFacts"/></description>
    /// </item>
    /// <item>
    ///   <term><c>true</c></term>
    ///   <term><c>true</c></term>
    ///   <description>Bonus applies only if the unit does not have all facts in <paramref name="requiredFacts"/></description>
    /// </item>
    /// </list>
    /// </param>
    public AddStatBonusIfHasFactFixed(
      StatType stat,
      ContextValue bonus,
      List<Blueprint<BlueprintUnitFactReference>> requiredFacts,
      List<Blueprint<BlueprintUnitFactReference>>? excludeFacts = null,
      ModifierDescriptor descriptor = ModifierDescriptor.None,
      bool requireAllFacts = true,
      bool invertCondition = false)
    {
      Stat = stat;
      Bonus = bonus;
      m_RequiredFacts = requiredFacts.Select(fact => fact.Reference).ToArray();

      m_ExcludeFacts = excludeFacts?.Select(fact => fact.Reference).ToArray() ?? new BlueprintUnitFactReference[0];
      Descriptor = descriptor;
      RequireAllFacts = requireAllFacts;
      InvertCondition = invertCondition;
    }

    // Required parameters
    public StatType Stat;
    public ContextValue Bonus;
    [SerializeField]
    [ValidateNotEmpty]
    public BlueprintUnitFactReference[] m_RequiredFacts;

    // Optional parameters
    public BlueprintUnitFactReference[] m_ExcludeFacts;
    public ModifierDescriptor Descriptor;
    public bool RequireAllFacts;
    public bool InvertCondition;
  }
}