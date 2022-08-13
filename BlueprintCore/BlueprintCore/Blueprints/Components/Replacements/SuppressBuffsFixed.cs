using BlueprintCore.UnitParts.Replacements;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Components.Replacements
{
  /// <summary>
  /// Working replacement for Owlcat's SuppressBuffs. Instantiate using the constructor and configure with its methods.
  /// </summary>
  /// 
  /// <remarks>
  /// Based on SuppressBuffsTTT from
  /// <see href="https://github.com/Vek17/TabletopTweaks-Core/blob/master/TabletopTweaks-Core/">TabletopTweaks-Core</see>
  /// </remarks>
  [TypeId("7100c63b-d277-4076-ac12-4ad3b0b45ad4")]
  public class SuppressBuffsFixed : UnitFactComponentDelegate
  {
    public override void OnPostLoad()
    {
      OnActivate();
    }

    public override void OnActivate()
    {
      var unitPartBuffSuppress = Owner.Ensure<UnitPartBuffSuppressFixed>();
      if (ApplyToNewBuffs)
      {
        unitPartBuffSuppress.AddContinuousEntry(Fact, m_Buffs, Schools, Descriptor);
        return;
      }
      unitPartBuffSuppress.AddNormalEntry(Fact, m_Buffs, Schools, Descriptor);
    }

    public override void OnDeactivate()
    {
      var unitPartBuffSuppress = Owner.Ensure<UnitPartBuffSuppressFixed>();
      unitPartBuffSuppress.RemoveEntry(Fact);
    }

    /// <param name="applyToNewBuffs">If true, effects added after suppression is applied are affected.</param>
    public SuppressBuffsFixed(bool applyToNewBuffs = false)
    {
      ApplyToNewBuffs = applyToNewBuffs;
    }

    public SuppressBuffsFixed ApplyToBuffs(params Blueprint<BlueprintBuffReference>[] buffs)
    {
      m_Buffs = buffs.Select(b => b.Reference).ToArray();
      return this;
    }

    public SuppressBuffsFixed ApplyToSpellSchools(params SpellSchool[] spellSchools)
    {
      Schools = spellSchools;
      return this;
    }

    public SuppressBuffsFixed ApplyToSpellDescriptors(params SpellDescriptor[] spellDescriptors)
    {
      Descriptor = spellDescriptors.Aggregate((SpellDescriptor)0, (s1, s2) => s1 | s2);
      return this;
    }

    public SuppressBuffsFixed ApplyToSpellDescriptors(SpellDescriptorWrapper spellDescriptorWrapper)
    {
      Descriptor = spellDescriptorWrapper;
      return this;
    }

    [SerializeField]
    public BlueprintBuffReference[] m_Buffs = new BlueprintBuffReference[0];

    [SerializeField]
    public SpellSchool[] Schools = new SpellSchool[0];

    [SerializeField]
    public SpellDescriptorWrapper Descriptor = SpellDescriptor.None;

    [SerializeField]
    public bool ApplyToNewBuffs;
  }
}