using BlueprintCore.Blueprints;
using BlueprintCore.Blueprints.Buffs;
using BlueprintCore.Test.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using System;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Buffs
{
  public class BuffConfiguratorTest : BlueprintUnitFactConfiguratorTest<BlueprintBuff, BuffConfigurator>
  {
    public BuffConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintBuff>(Guid);
    }

    protected override BuffConfigurator GetConfigurator(string guid)
    {
      return BuffConfigurator.For(guid).BuffSleeping();
    }

    [Fact]
    public void WithoutTickEachRoundComponent_HasValidationWarning()
    {
      Assert.Throws<InvalidOperationException>(() => BuffConfigurator.For(Guid).Configure());
    }

    [Fact]
    public void RemoveWhenCombatEnds()
    {
      GetConfigurator(Guid)
          .RemoveWhenCombatEnds()
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      var removeBuff = buff.GetComponent<RemoveWhenCombatEnded>();
      Assert.NotNull(removeBuff);
    }

    [Fact]
    public void AddFlags()
    {
      GetConfigurator(Guid)
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
      GetConfigurator(Guid)
          .AddFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      GetConfigurator(Guid)
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
      GetConfigurator(Guid)
          .AddFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      GetConfigurator(Guid)
          .RemoveFlags(BlueprintBuff.Flags.Harmful)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.IsFromSpell));
      Assert.False(buff.m_Flags.HasFlag(BlueprintBuff.Flags.Harmful));
    }

    [Fact]
    public void BuffSleeping()
    {
      GetConfigurator(Guid).Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      var sleeping = buff.GetComponent<BuffSleeping>();
      Assert.Equal(5, sleeping.WakeupPerceptionDC);
    }

    [Fact]
    public void BuffSleeping_WithWakeupDC()
    {
      // Don't use the base configurator which already has a component.
      BuffConfigurator.For(Guid)
          .BuffSleeping(wakeupPerceptionDC: 10)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      var sleeping = buff.GetComponent<BuffSleeping>();
      Assert.Equal(10, sleeping.WakeupPerceptionDC);
    }
  }
}
