using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Test.Blueprints.Configurators;
using BlueprintCore.Test.Patches;
using BlueprintCore.Test.TestData;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.Utility;
using System.Collections.Generic;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Abilities
{
  public class AbilityConfiguratorTest : RootConfiguratorTest<BlueprintAbility, AbilityConfigurator>
  {
    public AbilityConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintAbility>(Guids.Ability);
    }

    protected override AbilityConfigurator GetConfigurator()
    {
      return AbilityConfigurator.For(Guids.Ability).SetType(AbilityType.Extraordinary);
    }

    protected override BlueprintAbility GetBlueprint()
    {
      return BlueprintTool.Get<BlueprintAbility>(Guids.Ability);
    }

    [Fact]
    public void SetCustomRange_UsingFeet()
    {
      var range = new Feet(5);
      GetConfigurator()
          .SetCustomRange(rangeInFeet: range)
          .Configure();

      var ability = GetBlueprint();
      Assert.Equal(expected: range, actual: ability.CustomRange);
      Assert.Equal(expected: AbilityRange.Custom, actual: ability.Range);
    }

    [Fact]
    public void SetCustomRange_UsingInt()
    {
      var range = new Feet(5);
      GetConfigurator()
          .SetCustomRange(rangeInFeet: 5)
          .Configure();

      var ability = GetBlueprint();
      Assert.Equal(expected: range, actual: ability.CustomRange);
      Assert.Equal(expected: AbilityRange.Custom, actual: ability.Range);
    }

    [Fact]
    public void AllowTargeting_WithValues()
    {
      GetConfigurator()
          .SetRange(AbilityRange.Close)
          .AllowTargeting(point: true, enemies: true, friends: true, self: false)
          .Configure();

      var ability = GetBlueprint();
      Assert.True(ability.CanTargetPoint);
      Assert.True(ability.CanTargetEnemies);
      Assert.True(ability.CanTargetFriends);
      Assert.False(ability.CanTargetSelf);
    }

    [Fact]
    public void AllowTargeting_WithExistingValues()
    {
      // First pass
      GetConfigurator()
          .SetRange(AbilityRange.Close)
          .AllowTargeting(point: true, enemies: true, friends: true, self: false)
          .Configure();

      AbilityConfigurator.For(Guids.Ability)
          .AllowTargeting()
          .Configure();

      var ability = GetBlueprint();
      Assert.True(ability.CanTargetPoint);
      Assert.True(ability.CanTargetEnemies);
      Assert.True(ability.CanTargetFriends);
      Assert.False(ability.CanTargetSelf);
    }

    private class TestAbilityDeliverEffect : AbilityDeliverEffect
    {
      public override IEnumerator<AbilityDeliveryTarget> Deliver(
          AbilityExecutionContext context, TargetWrapper target)
      { return null; }
    }
  }
}
