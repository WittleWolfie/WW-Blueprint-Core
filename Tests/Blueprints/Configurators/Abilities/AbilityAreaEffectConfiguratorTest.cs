using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Test.Patches;
using BlueprintCore.Test.TestData;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Configurators.Abilities
{
  public class AbilityAreaEffectConfiguratorTest :
    RootConfiguratorTest<BlueprintAbilityAreaEffect, AbilityAreaEffectConfigurator>
  {
    public AbilityAreaEffectConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintAbilityAreaEffect>(Guids.AbilityAoE);
    }

    protected override AbilityAreaEffectConfigurator GetConfigurator()
    {
      return AbilityAreaEffectConfigurator.For(Guids.AbilityAoE);
    }

    protected override BlueprintAbilityAreaEffect GetBlueprint()
    {
      return BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guids.AbilityAoE);
    }

    [Fact]
    public void SetSizeInCells()
    {
      GetConfigurator()
          .SetSizeInCells(5)
          .Configure();

      var aoe = GetBlueprint();
      Assert.True(aoe.CanBeUsedInTacticalCombat);
    }
  }
}
