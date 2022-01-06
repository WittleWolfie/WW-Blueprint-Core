using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Utils;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Configurators.Abilities
{
  public class AbilityAreaEffectConfiguratorTest
      : BaseBlueprintConfiguratorTest<BlueprintAbilityAreaEffect, AbilityAreaEffectConfigurator>
  {
    public AbilityAreaEffectConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintAbilityAreaEffect>(Guid);
    }

    protected override AbilityAreaEffectConfigurator GetConfigurator(string guid)
    {
      return AbilityAreaEffectConfigurator.For(guid);
    }

    [Fact]
    public void SetTargetType()
    {
      GetConfigurator(Guid)
          .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Enemy)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.Equal(BlueprintAbilityAreaEffect.TargetType.Enemy, aoe.m_TargetType);
    }

    [Fact]
    public void ApplySpellResistance()
    {
      GetConfigurator(Guid)
          .ApplySpellResistance()
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.True(aoe.SpellResistance);
    }

    [Fact]
    public void ApplySpellResistance_False()
    {
      GetConfigurator(Guid)
          .ApplySpellResistance(false)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.False(aoe.SpellResistance);
    }

    [Fact]
    public void SetAffectEnemies()
    {
      GetConfigurator(Guid)
          .SetAffectEnemies()
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.True(aoe.AffectEnemies);
    }

    [Fact]
    public void SetAffectEnemies_False()
    {
      GetConfigurator(Guid)
          .SetAffectEnemies(false)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.False(aoe.AffectEnemies);
    }

    [Fact]
    public void SetAggroEnemies()
    {
      GetConfigurator(Guid)
          .SetAggroEnemies()
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.False(aoe.AggroEnemies);
    }

    [Fact]
    public void SetAggroEnemies_True()
    {
      GetConfigurator(Guid)
          .SetAggroEnemies(true)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.True(aoe.AggroEnemies);
    }

    [Fact]
    public void SetAffectDead()
    {
      GetConfigurator(Guid)
          .SetAffectDead()
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.True(aoe.AffectDead);
    }

    [Fact]
    public void SetAffectDead_False()
    {
      GetConfigurator(Guid)
          .SetAffectDead(false)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.False(aoe.AffectDead);
    }

    [Fact]
    public void SetIgnoreSleepingUnits()
    {
      GetConfigurator(Guid)
          .SetIgnoreSleepingUnits()
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.True(aoe.IgnoreSleepingUnits);
    }

    [Fact]
    public void SetIgnoreSleepingUnits_False()
    {
      GetConfigurator(Guid)
          .SetIgnoreSleepingUnits(false)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.False(aoe.IgnoreSleepingUnits);
    }

    [Fact]
    public void SetShape()
    {
      GetConfigurator(Guid)
          .SetShape(AreaEffectShape.Wall)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.Equal(AreaEffectShape.Wall, aoe.Shape);
    }

    [Fact]
    public void SetSize()
    {
      GetConfigurator(Guid)
          .SetSize(4)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.Equal(4, aoe.Size.Value);
    }

    [Fact]
    public void SetFx()
    {
      GetConfigurator(Guid)
          .SetFx(Prefab)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.Equal(Prefab, aoe.Fx);
    }

    [Fact]
    public void SetSizeInTacticalCombat()
    {
      GetConfigurator(Guid)
          .SetSizeInTacticalCombat(3)
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);

      Assert.Equal(3, aoe.m_SizeInCells);
      Assert.True(aoe.CanBeUsedInTacticalCombat);
    }

    [Fact]
    public void DisableInTacticalCombat()
    {
      // First pass
      GetConfigurator(Guid)
          .SetSizeInTacticalCombat(3)
          .Configure();

      GetConfigurator(Guid)
          .DisableInTacticalCombat()
          .Configure();

      var aoe = BlueprintTool.Get<BlueprintAbilityAreaEffect>(Guid);
      Assert.False(aoe.CanBeUsedInTacticalCombat);
    }
  }
}
