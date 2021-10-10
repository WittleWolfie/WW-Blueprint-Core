using System;
using Owlcat.Runtime.Core.Logging;

namespace BlueprintCore.Utils
{
  public class LogWrapper
  {
    public static bool EnableVerboseLogs = true;

    public static LogWrapper Get(string prefix)
    {
      LogChannel channel = LogChannelFactory.GetOrCreate($"WW-Character-Options-Plus::{prefix}");
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