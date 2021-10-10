using Kingmaker.Blueprints;

namespace BlueprintCore.Tests
{
  public static class Util
  {
    public static T Create<T>(string assetId) where T : SimpleBlueprint, new()
    {
      T result = new() { AssetGuid = BlueprintGuid.Parse(assetId) };
      return result;
    }
  }
}