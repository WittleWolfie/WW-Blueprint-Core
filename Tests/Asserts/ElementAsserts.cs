using Kingmaker.ElementsSystem;
using Xunit;

namespace BlueprintCore.Test.Asserts
{
  public class ElementAsserts
  {
    /** Basic validation that Element.CreateInstance() was used. */
    public static void IsValid(Element element)
    {
      Assert.NotNull(element.name);
      // Technically this should assert name format but it isn't critical.
      Assert.True(element.name.Length > 2);
    }
  }
}
