//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemThiefTool"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemThiefToolConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintItemThiefTool
    where TBuilder : BaseItemThiefToolConfigurator<T, TBuilder>
  {
    protected BaseItemThiefToolConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemThiefTool.m_Consumable"/>
    /// </summary>
    ///
    /// <param name="consumable">
    /// <para>
    /// InfoBox: If true will be destroyed after first use
    /// </para>
    /// </param>
    public TBuilder SetConsumable(bool consumable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Consumable = consumable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemThiefTool.m_Consumable"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="consumable">
    /// <para>
    /// InfoBox: If true will be destroyed after first use
    /// </para>
    /// </param>
    public TBuilder ModifyConsumable(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Consumable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemThiefTool.m_SkillCheckBonus"/>
    /// </summary>
    public TBuilder SetSkillCheckBonus(int skillCheckBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SkillCheckBonus = skillCheckBonus;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemThiefTool.m_SkillCheckBonus"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySkillCheckBonus(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_SkillCheckBonus);
        });
    }
  }
}
