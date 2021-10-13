using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Xunit;

namespace BlueprintCore.Tests.Conditions.Builder
{
  [Collection("Harmony")]
  public class ConditionsCheckerBuilderTestBase : IDisposable
  {
    protected static readonly string FactGuid = "f7dba63d-9b33-436d-9841-ca2821b89a1b";
    protected readonly BlueprintUnitFact Fact = CreateBlueprint<BlueprintUnitFact>(FactGuid);
    protected static readonly string BuffGuid = "f3b38c34-2526-4ba6-a682-a751e5c05305";
    protected readonly BlueprintBuff Buff = CreateBlueprint<BlueprintBuff>(BuffGuid);

    public ConditionsCheckerBuilderTestBase() { }

    public void Dispose()
    {
      BlueprintPatch.Clear();
    }

    protected static T CreateBlueprint<T>(string guid) where T : SimpleBlueprint, new()
    {
      var blueprint = Util.Create<T>(guid);
      BlueprintPatch.Add(blueprint);
      return blueprint;
    }
  }
}
