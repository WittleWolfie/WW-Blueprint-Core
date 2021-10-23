using BlueprintCore.Utils;
using System.Reflection;

namespace BlueprintCore
{
  /// <summary>
  /// Container class for library initialization.
  /// </summary>
  public static class Main
  {
    /// <summary>
    /// Should be updated when a new version is pushed.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>Should be updated when a new version is released.</para>
    /// 
    /// <para>
    /// Normally you would query this from the assembly, but declaring it explicitly should provide compatibility with
    /// tools like ILMerge.
    /// </para>
    /// </remarks>
    //public static readonly Version CurrentVersion = new Version(0, 2, 0); 

    private static bool Initialized = false;

    /// <summary>
    /// Call this to initalize the library before using it.
    /// </summary>
    /// 
    /// <remarks>
    /// Should be called before any library classes are referenced to ensure log messages are correctly associated with
    /// your assembly.
    /// </remarks>
    public static void Init()
    {
      if (Initialized)
      {
        Logger.Info("Already initialized!");
        return;
      }
      Initialized = true;

      var caller = Assembly.GetCallingAssembly().GetName();
      var id = $"BlueprintCore::{caller.Name}";

      LogWrapper.PrefixBase = id;
      Logger = LogWrapper.GetInternal("Init");
      Logger.Info($"Initialized by: {caller.Name}");
      //  PatchLatest(id);
    }

    public static void TotallyNewFunction()
    {
      Logger.Info("Hey this is a totally new function!");
    }

    private static LogWrapper Logger;

    /// <summary>
    /// Ensures the latest harmony patches are installed and redirects any existing patch references to the latest
    /// version.
    /// </summary>
    //private static void PatchLatest(string id)
    //{
    //  var harmony = new Harmony(id);


    //  List<string> siblingIds = new();
    //  foreach (var method in Harmony.GetAllPatchedMethods())
    //  {
    //    foreach (var owner in Harmony.GetPatchInfo(method).Owners)
    //    {
    //      if (owner.StartsWith("BlueprintCore::"))
    //      {
    //        siblingIds.Add(owner);
    //        Logger.Verbose($"Found patches from another copy of BlueprintCore: {owner}");
    //      }
    //    }
    //  }

    //  var latestVersion = CurrentVersion;
    //  var latestId = id;
    //  foreach (var sibling = )
    //  {

    //  }
    //}
  }
}
