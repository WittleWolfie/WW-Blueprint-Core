//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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
    protected BaseItemThiefToolConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemThiefTool>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Consumable = copyFrom.m_Consumable;
          bp.m_SkillCheckBonus = copyFrom.m_SkillCheckBonus;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemThiefTool>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Consumable = copyFrom.m_Consumable;
          bp.m_SkillCheckBonus = copyFrom.m_SkillCheckBonus;
        });
    }

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
  }
}
