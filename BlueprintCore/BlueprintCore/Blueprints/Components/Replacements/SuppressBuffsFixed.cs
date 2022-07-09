using BlueprintCore.UnitParts.Replacements;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TabletopTweaks.Core.NewComponents.OwlcatReplacements
{
  /// <summary>
  /// Working replacement for Owlcat's SuppressBuffs. Instantiate using constructors.
  /// </summary>
  /// 
  /// <remarks>
  /// Based on SuppressBuffsTTT from
  /// <see href="https://github.com/Vek17/TabletopTweaks-Core/blob/master/TabletopTweaks-Core/">TabletopTweaks-Core</see>
  /// </remarks>
  [TypeId("7100c63b-d277-4076-ac12-4ad3b0b45ad4")]
  public class SuppressBuffsFixed : UnitFactComponentDelegate
  {
    // TODO: Constructor

    public override void OnPostLoad()
    {
      OnActivate();
    }

    public override void OnActivate()
    {
      var unitPartBuffSuppress = Owner.Ensure<UnitPartBuffSupressFixed>();
      if (Continuous)
      {
        unitPartBuffSuppress.AddContinuousEntry(Fact, m_Buffs, Schools, Descriptor);
        return;
      }
      unitPartBuffSuppress.AddNormalEntry(Fact, m_Buffs, Schools, Descriptor);
    }

    public override void OnDeactivate()
    {
      var unitPartBuffSuppress = Owner.Ensure<UnitPartBuffSupressFixed>();
      unitPartBuffSuppress.RemoveEntry(Fact);
    }

    [SerializeField]
    [FormerlySerializedAs("Buffs")]
    public BlueprintBuffReference[] m_Buffs = new BlueprintBuffReference[0];

    [SerializeField]
    public SpellSchool[] Schools = new SpellSchool[0];

    [SerializeField]
    public SpellDescriptorWrapper Descriptor = SpellDescriptor.None;

    [SerializeField]
    public bool Continuous = false;
  }
}