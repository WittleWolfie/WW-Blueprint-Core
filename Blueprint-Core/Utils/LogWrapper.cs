using System;
using Owlcat.Runtime.Core.Logging;

namespace BlueprintCore.Utils
{
  /// <summary>
  /// Wrapper around <see cref="LogChannel"/> which supports dynamically enabling or disabling verbose logging.
  /// </summary>
  /// 
  /// <remarks>
  /// These log events print to the same output as Wrath's game log events. They can be viewed using
  /// <see href="https://github.com/OwlcatOpenSource/RemoteConsole/releases">RemoteConsole</see> or by appending
  /// <c>logging</c> to the executable startup arguments. If you are not using the console, logs print to
  /// <c>AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\GameLog*.txt</c>.
  /// </remarks>
  public class LogWrapper
  {
    public static bool EnableVerboseLogs = true;

    internal static LogWrapper GetInternal(string prefix)
    {
      return Get($"WW-BlueprintCore::{prefix}");
    }

    /// <summary>
    /// Returns a <see cref="LogWrapper"/> which prepends the given prefix to all log events.
    /// </summary>
    public static LogWrapper Get(string prefix)
    {
      LogChannel channel = LogChannelFactory.GetOrCreate(prefix);
      channel.SetSeverity(LogSeverity.Message);
      return new LogWrapper(channel);
    }

    private readonly LogChannel Logger;

    protected LogWrapper(LogChannel logger)
    {
      Logger = logger;
    }

    public virtual void Error(string msg, Exception e = null)
    {
      Logger.Error(msg);
      if (e != null) { Logger.Exception(e); }
    }

    public virtual void Info(string msg)
    {
      Logger.Log(msg);
    }

    public virtual void Warn(string msg)
    {
      Logger.Warning(msg);
    }

    /// <summary>
    /// If <see cref="EnableVerboseLogs"/> is false these log are ignored.
    /// </summary>
    public virtual void Verbose(string msg)
    {
      if (EnableVerboseLogs) { Logger.Log(msg); }
    }
  }
}