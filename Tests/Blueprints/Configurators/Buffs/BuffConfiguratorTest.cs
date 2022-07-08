using BlueprintCore.Test.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using System;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Buffs
{
  public class BuffConfiguratorTest : BaseUnitFactConfiguratorTest<BlueprintBuff, BuffConfigurator>
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
    public void SetIsClassFeature()
    {
      GetConfigurator(Guid)
          .SetIsClassFeature()
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.IsClassFeature);
    }

    [Fact]
    public void SetIsClassFeature_False()
    {
      GetConfigurator(Guid)
          .SetIsClassFeature(false)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.False(buff.IsClassFeature);
    }

    [Fact]
    public void SetFlags()
    {
      // First pass
      GetConfigurator(Guid).SetFlags(BlueprintBuff.Flags.Harmful).Configure();

      GetConfigurator(Guid)
          .SetFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.RemoveOnRest)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.IsFromSpell));
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.RemoveOnRest));
      Assert.False(buff.m_Flags.HasFlag(BlueprintBuff.Flags.Harmful));
    }

    [Fact]
    public void AddFlags()
    {
      GetConfigurator(Guid)
          .AddToFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
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
          .SetFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      GetConfigurator(Guid)
          .AddToFlags(BlueprintBuff.Flags.StayOnDeath)
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
          .SetFlags(BlueprintBuff.Flags.IsFromSpell, BlueprintBuff.Flags.Harmful)
          .Configure();

      GetConfigurator(Guid)
          .RemoveFromFlags(BlueprintBuff.Flags.Harmful)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.m_Flags.HasFlag(BlueprintBuff.Flags.IsFromSpell));
      Assert.False(buff.m_Flags.HasFlag(BlueprintBuff.Flags.Harmful));
    }

    [Fact]
    public void SetStackingType()
    {
      GetConfigurator(Guid)
          .SetStackingType(StackingType.Poison)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.Equal(StackingType.Poison, buff.Stacking);
    }

    [Fact]
    public void SetStackingType_Rank()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            GetConfigurator(Guid)
                .SetStackingType(StackingType.Rank)
                .Configure());
    }

    [Fact]
    public void SetRanks()
    {
      GetConfigurator(Guid)
          .SetRanks(3)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.Equal(StackingType.Rank, buff.Stacking);
      Assert.Equal(3, buff.Ranks);
    }

    [Fact]
    public void SetTickEachSecond()
    {
      GetConfigurator(Guid)
          .SetTickEachSecond()
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.True(buff.TickEachSecond);
    }

    [Fact]
    public void SetTickEachSecond_False()
    {
      GetConfigurator(Guid)
          .SetTickEachSecond(false)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.False(buff.TickEachSecond);
    }

    [Fact]
    public void SetFxOnStart()
    {
      GetConfigurator(Guid)
          .SetFxOnStart(Prefab)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.Equal(Prefab, buff.FxOnStart);
    }

    [Fact]
    public void SetFxOnRemove()
    {
      GetConfigurator(Guid)
          .SetFxOnRemove(Prefab)
          .Configure();

      var buff = BlueprintTool.Get<BlueprintBuff>(Guid);
      Assert.Equal(Prefab, buff.FxOnRemove);
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
