//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventBase"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomEventBaseConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintKingdomEventBase
    where TBuilder : BaseKingdomEventBaseConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventBaseConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="EventFinalResults"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_StartKTC</term><description>9b7fdf9a6d722d942879c7922daa507f</description></item>
    /// <item><term>KTC_ElyankaComing</term><description>b631d3337a4d5134f8f1f163c6d9f59a</description></item>
    /// <item><term>WenduagKTC_WenduagComeNeathholm</term><description>b0281d9068d670845927a1827be6e7bb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEventFinalResults(
        EventResult[]? results = null)
    {
      var component = new EventFinalResults();
      foreach (var item in results) { Validate(item); }
      component.Results = results ?? component.Results;
      if (component.Results is null)
      {
        component.Results = new EventResult[0];
      }
      return AddComponent(component);
    }
  }
}
