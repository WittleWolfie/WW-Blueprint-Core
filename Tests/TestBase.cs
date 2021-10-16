using System;
using Xunit;

namespace BlueprintCore.Test
{
  [Collection("Harmony")]
  public class TestBase : IDisposable
  {
    public TestBase()
    {
      TestData.Init();
    }

    public void Dispose()
    {
      TestData.Clear();
      LoggerPatch.Logger.Reset();
    }
  }
}
