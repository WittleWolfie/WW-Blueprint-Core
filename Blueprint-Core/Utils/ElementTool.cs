using Kingmaker.ElementsSystem;

namespace BlueprintCore.Utils
{
  public static class ElementTool
  {
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