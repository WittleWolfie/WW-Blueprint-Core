namespace BlueprintCore.Test
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