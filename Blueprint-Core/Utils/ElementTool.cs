using Kingmaker.ElementsSystem;

namespace BlueprintCore.Utils
{
  /** Util class for operations on Element types. */
  public static class ElementTool
  {
    /**
     * This should be used whenever instantiating an object inheriting from Element. If the type
     * does not have a parameterless constructor, use Init() instead.
     */
    public static T Create<T>() where T : Element
    {
      return (T)Element.CreateInstance(typeof(T));
    }

    /**
     * Some Elements can't be created using Element.CreateInstance. this ensures they have a unique
     * name.
     */
    public static void Init(Element element)
    {
      element.name = $"${element.GetType()}${System.Guid.NewGuid()}";
    }
  }
}