using Kingmaker.Blueprints.Classes.Prerequisites;

namespace BlueprintCore.Utils
{
  /** Utility class for operating on Prerequisite types. */
  public static class PrereqTools
  {
    /** Helper to instantiate Prerequisite types since they all have these three fields. */
    public static T Create<T>(
        Prerequisite.GroupType group, bool checkInProgression, bool hideInUI)
        where T : Prerequisite, new()
    {
      return new T
      {
        Group = group,
        CheckInProgression = checkInProgression,
        HideInUI = hideInUI
      };
    }
  }
}