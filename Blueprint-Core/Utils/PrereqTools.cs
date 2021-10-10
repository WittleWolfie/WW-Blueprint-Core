using Kingmaker.Blueprints.Classes.Prerequisites;

namespace BlueprintCore.Utils
{
  public static class PrereqTools
  {
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