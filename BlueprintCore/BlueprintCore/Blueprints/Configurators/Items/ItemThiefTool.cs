using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemThiefTool"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class ItemThiefToolConfigurator : BaseItemConfigurator<BlueprintItemThiefTool, ItemThiefToolConfigurator>
  {
    private ItemThiefToolConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemThiefToolConfigurator For(string name)
    {
      return new ItemThiefToolConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemThiefToolConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemThiefTool>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemThiefTool.m_Consumable"/> (Auto Generated)
    /// </summary>
    
    public ItemThiefToolConfigurator SetConsumable(bool consumable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Consumable = consumable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemThiefTool.m_SkillCheckBonus"/> (Auto Generated)
    /// </summary>
    
    public ItemThiefToolConfigurator SetSkillCheckBonus(int skillCheckBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SkillCheckBonus = skillCheckBonus;
          });
    }
  }
}
