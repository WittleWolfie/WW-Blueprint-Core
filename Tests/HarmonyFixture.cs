using System;
using System.Reflection;
using Xunit;

namespace BlueprintCore.Test
{
  public class HarmonyFixture : IDisposable
  {
    private const string Id = "WW_BlueprintCore.Test";
    private readonly Harmony harmony;

    public HarmonyFixture()
    {
      harmony = new Harmony(Id);
      harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    public void Dispose() { }
  }

  [CollectionDefinition("Harmony")]
  public class HarmonyCollection : ICollectionFixture<HarmonyFixture> { }
}