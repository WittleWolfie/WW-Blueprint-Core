using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Test.Blueprints.Configurators;
using BlueprintCore.Test.Patches;
using BlueprintCore.Test.TestData;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Buffs
{
  public class BuffConfiguratorTest : RootConfiguratorTest<BlueprintBuff, BuffConfigurator>
  {
    public BuffConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintBuff>(Guids.Buff);
    }

    protected override BuffConfigurator GetConfigurator()
    {
      return BuffConfigurator.For(Guids.Buff);
    }

    protected override BlueprintBuff GetBlueprint()
    {
      return BlueprintTool.Get<BlueprintBuff>(Guids.Buff);
    }

    [Fact]
    public void SetRanks()
    {
      GetConfigurator()
          .SetRanks(3)
          .Configure();

      var buff = GetBlueprint();
      Assert.Equal(StackingType.Rank, buff.Stacking);
      Assert.Equal(3, buff.Ranks);
    }
  }
}
