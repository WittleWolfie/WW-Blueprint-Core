using BlueprintCore.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
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
  }
}
