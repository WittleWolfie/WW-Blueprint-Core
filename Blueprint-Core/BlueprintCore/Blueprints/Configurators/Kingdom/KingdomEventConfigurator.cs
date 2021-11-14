using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintKingdomEvent"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEvent))]
  public class KingdomEventConfigurator : BaseKingdomEventBaseConfigurator<BlueprintKingdomEvent, KingdomEventConfigurator>
  {
     private KingdomEventConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomEventConfigurator For(string name)
    {
      return new KingdomEventConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomEventConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomEvent>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomEventConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomEvent>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="EventRecurrence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventRecurrence))]
    public KingdomEventConfigurator AddEventRecurrence(
        int RecurrencePeriod,
        bool TickOnStart,
        ActionsBuilder OnRecurrence,
        KingdomStats.Changes StatsOnRecurrence,
        LocalizedString Description)
    {
      ValidateParam(StatsOnRecurrence);
      ValidateParam(Description);
      
      var component =  new EventRecurrence();
      component.RecurrencePeriod = RecurrencePeriod;
      component.TickOnStart = TickOnStart;
      component.OnRecurrence = OnRecurrence.Build();
      component.StatsOnRecurrence = StatsOnRecurrence;
      component.Description = Description;
      return AddComponent(component);
    }
  }
}
