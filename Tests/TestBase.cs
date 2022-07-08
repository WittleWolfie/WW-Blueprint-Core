using BlueprintCore.Test.Patches;
using Xunit;

namespace BlueprintCore.Test
{
  [Collection("Harmony")]
  public class TestBase
  {
    public TestBase()
    {
      BlueprintPatch.Init();
      LoggerPatch.Logger.Reset();
    }
  }
}
