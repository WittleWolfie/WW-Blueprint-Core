using BlueprintCore.Blueprints;
using BlueprintCore.Blueprints.Buffs;
using BlueprintCore.Tests.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Xunit;

namespace BlueprintCore.Tests.Buffs
{
  public class BuffConfiguratorTest
      : BlueprintUnitFactConfiguratorTest<BlueprintBuff, BuffConfigurator>
  {
    public BuffConfiguratorTest() : base()
    {
      CreateBlueprint<BlueprintBuff>(Guid);
    }

    protected override BuffConfigurator GetConfigurator(string guid)
    {
      return BuffConfigurator.For(guid);
    }

    [Fact]
    public void RemoveWhenCombatEnds()
    {
      BuffConfigurator.For(Guid)
          .RemoveWhenCombatEnds()
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      var removeBuff = buff.GetComponent<RemoveWhenCombatEnded>();
      Assert.NotNull(removeBuff);
    }

    [Fact]
    public void AddFlags()
    {
      BuffConfigurator.For(Guid)
          .AddFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.IsFromSpell));
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.Harmful));
    }

    [Fact]
    public void AddFlags_WithExisting()
    {
      // First pass
      BuffConfigurator.For(Guid)
          .AddFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      BuffConfigurator.For(Guid)
          .AddFlags(BlueprintBuff.Flags.StayOnDeath)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.IsFromSpell));
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.Harmful));
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.StayOnDeath));
    }

    [Fact]
    public void RemoveFlags()
    {
      // First pass
      BuffConfigurator.For(Guid)
          .AddFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      BuffConfigurator.For(Guid)
          .RemoveFlags(BlueprintBuff.Flags.Harmful)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.IsFromSpell));
      Assert.False(buff.m_Flags.HasFlag(BlueprintBuff.Flags.Harmful));
    }
  }
}
