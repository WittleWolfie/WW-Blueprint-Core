using System;
using Xunit;

namespace BlueprintCore.Test
{
  [Collection("Harmony")]
  public class TestBase
  {
    public TestBase()
    {
      TestData.Init();
      LoggerPatch.Logger.Reset();
    }
  }
}
