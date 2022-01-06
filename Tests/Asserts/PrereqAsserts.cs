using Xunit;

namespace BlueprintCore.Test.Asserts
{
  public class PrereqAsserts
  {
    public static void Check(
        Prerequisite prereq,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      Assert.Equal(group, prereq.Group);
      Assert.Equal(checkInProgression, prereq.CheckInProgression);
      Assert.Equal(hideInUI, prereq.HideInUI);
    }
  }
}
