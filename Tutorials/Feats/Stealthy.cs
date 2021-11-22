using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;

namespace Tutorials.Feats
{
  public class Stealthy
  {
    private static readonly string FeatName = "StealthyFeat";
    private static readonly string FeatGuid = "E47A36AB-EBCC-4D94-9888-B795ABD398F3";
    private static readonly string BasicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";

    public static void Create()
    {
      FeatureConfigurator.New(FeatName, FeatGuid).Configure();

      FeatureSelectionConfigurator.For(BasicFeatSelectionGuid).AddToFeatures(FeatName).Configure();
    }
  }
}
