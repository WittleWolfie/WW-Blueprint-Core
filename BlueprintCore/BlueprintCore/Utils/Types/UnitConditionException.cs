using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using System.Linq;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Util class for constructing <see cref="UnitConditionExceptions"/>.
  /// </summary>
  public class UnitConditionException
  {
    /// <summary>
    /// Returns a <see cref="UnitConditionExceptions"/> that checks if the target has any of the provided features.
    /// </summary>
    /// 
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static UnitConditionExceptions TargetHasFeatures(
      params Blueprint<BlueprintFeatureReference>[] features)
    {
      return
        new UnitConditionExceptionsTargetHasFacts()
        {
          m_ExceptionFacts = features.Select(bp => bp.Reference).ToArray()
        };
    }
  }
}
