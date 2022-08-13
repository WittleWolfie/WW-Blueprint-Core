using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Linq;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Configurators
{
  [Collection("Harmony")]
  public abstract class RootConfiguratorTest<T, TBuilder> : TestBase
      where T : BlueprintScriptableObject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    /// <summary>
    /// Creates and returns a configurator of type TBuilder.
    /// </summary>
    protected abstract TBuilder GetConfigurator();

    /// <summary>
    /// Returns the blueprint under test.
    /// </summary>
    protected abstract T GetBlueprint();

    [Fact]
    public void AddComponent_WithInit()
    {
      GetConfigurator().AddComponent<DlcCondition>(c => c.m_HideInstead = true).Configure();

      T blueprint = GetBlueprint();
      var component = blueprint.GetComponent<DlcCondition>();
      Assert.NotNull(component);

      Assert.True(component.m_HideInstead);
    }

    [Fact]
    public void EditComponent()
    {
      // First pass
      GetConfigurator().AddComponent<DlcCondition>(c => c.m_HideInstead = true).Configure();

      GetConfigurator().EditComponent<DlcCondition>(c => c.m_HideInstead = false).Configure();

      T blueprint = GetBlueprint();
      var component = blueprint.GetComponent<DlcCondition>();
      Assert.NotNull(component);

      Assert.False(component.m_HideInstead);
    }

    [Fact]
    public void EditComponents()
    {
      // First pass
      GetConfigurator()
        .AddComponent(ContextRankConfigs.BaseAttack(max: 5))
        .AddComponent(ContextRankConfigs.MythicLevel(max: 6))
        .AddComponent(ContextRankConfigs.BaseAttack(max: 6))
        .AddComponent(ContextRankConfigs.BaseAttack(max: 10))
        .Configure();

      GetConfigurator()
        .EditComponents<ContextRankConfig>(
          c => c.m_Max = 20,
          c => c.m_BaseValueType == ContextRankBaseValueType.BaseAttack && c.m_Max > 5)
        .Configure();

      T blueprint = GetBlueprint();
      var components = blueprint.GetComponents<ContextRankConfig>();
      Assert.Equal(expected: 4, actual: components.Count());

      Assert.Equal(expected: ContextRankBaseValueType.BaseAttack, actual: components.ElementAt(0).m_BaseValueType);
      Assert.Equal(expected: 5, actual: components.ElementAt(0).m_Max);

      Assert.Equal(expected: ContextRankBaseValueType.MythicLevel, actual: components.ElementAt(1).m_BaseValueType);
      Assert.Equal(expected: 6, actual: components.ElementAt(1).m_Max);

      Assert.Equal(expected: ContextRankBaseValueType.BaseAttack, actual: components.ElementAt(2).m_BaseValueType);
      Assert.Equal(expected: 20, actual: components.ElementAt(2).m_Max);

      Assert.Equal(expected: ContextRankBaseValueType.BaseAttack, actual: components.ElementAt(3).m_BaseValueType);
      Assert.Equal(expected: 20, actual: components.ElementAt(3).m_Max);
    }
  }
}
