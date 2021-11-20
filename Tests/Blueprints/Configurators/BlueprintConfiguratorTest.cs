using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Configurators
{
  [Collection("Harmony")]
  public abstract class BaseBlueprintConfiguratorTest<T, TBuilder> : TestBase
      where T : BlueprintScriptableObject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    // Serves as the guid for the primary test blueprint. Concrete child classes must instantiate
    // create and register a blueprint using this guid;
    protected static readonly string Guid = "137f7548-e57f-4e4a-8d76-7f2d174c6d5d";

    /** Creates and returns a configurator of type TBuilder. */
    protected abstract TBuilder GetConfigurator(string guid);

    [Fact]
    public void AddComponent_WithInit()
    {
      GetConfigurator(Guid).AddComponent<DlcCondition>(c => c.m_HideInstead = true).Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var component = blueprint.GetComponent<DlcCondition>();
      Assert.NotNull(component);

      Assert.True(component.m_HideInstead);
    }

    [Fact]
    public void EditComponent()
    {
    }
  }

  public class BlueprintConfiguratorTest
      : BaseBlueprintConfiguratorTest<BlueprintPet, BlueprintConfigurator<BlueprintPet>>
  {
    public BlueprintConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintPet>(Guid);
    }

    protected override BlueprintConfigurator<BlueprintPet> GetConfigurator(string guid)
    {
      return BlueprintConfigurator<BlueprintPet>.For(guid);
    }
  }
}
