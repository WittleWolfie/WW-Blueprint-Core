using System;
using BlueprintCore.Utils;
using HarmonyLib;
using Owlcat.Runtime.Core.Logging;

namespace BlueprintCore.Test.Patches
{
  public static class LoggerPatch
  {
    public static readonly TestLogWrapper Logger = new(null);

    [HarmonyPatch(typeof(LogWrapper))]
    static class LogWrapper_Patch
    {
      [HarmonyPriority(Priority.First)]
      [HarmonyPatch(nameof(LogWrapper.Get)), HarmonyPrefix]

      static bool Prefix(ref LogWrapper __result)
      {
        __result = Logger;
        return false;
      }
    }
  }

  /**
   * Suppress log events to remove dependency on game logger. Supports throwing on error and warn.
   */
  public class TestLogWrapper : LogWrapper
  {
    public bool ThrowOnError { get; set; }
    public bool ThrowOnWarn { get; set; }

    public void Reset()
    {
      ThrowOnError = true;
      ThrowOnWarn = true;
    }

    public TestLogWrapper(LogChannel logger) : base(logger, "Test") { }

    public override void Error(string msg, Exception e = null)
    {
      if (ThrowOnError) { throw new InvalidOperationException(msg, e); }
    }
    public override void Warn(string msg)
    {
      if (ThrowOnWarn) { throw new InvalidOperationException(msg); }
    }
    public override void Verbose(string msg) { }
    public override void Info(string msg) { }
  }
}