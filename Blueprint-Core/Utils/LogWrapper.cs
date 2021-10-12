using System;
using Owlcat.Runtime.Core.Logging;

namespace BlueprintCore.Utils
{
  /** Wrapper around Owlcat's LogChannel which supports enabling or disabling Verbose log events. */
  public class LogWrapper
  {
    /** Controls whether verbose logs are output to the log. */
    public static bool EnableVerboseLogs = true;

    internal static LogWrapper GetInternal(string prefix)
    {
      return Get($"WW-BlueprintCore::{prefix}");
    }

    /** Returns a LogWrapper which applies the given prefix to all log events. */
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

    public virtual void Verbose(string msg)
    {
      if (EnableVerboseLogs) { Logger.Log(msg); }
    }
  }
}