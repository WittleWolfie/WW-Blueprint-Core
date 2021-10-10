using System;
using System.Reflection;
using HarmonyLib;
using Xunit;

namespace BlueprintCore.Tests
{
  public class HarmonyFixture : IDisposable
  {
    private const string Id = "WW_BlueprintCore.Tests";
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