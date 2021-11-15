using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
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
    /// Sets <see cref="BlueprintKingdomEvent.IsOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetIsOpportunity(bool value)
    {
      return OnConfigureInternal(bp => bp.IsOpportunity = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.ForceOneTimeOnly"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetForceOneTimeOnly(bool value)
    {
      return OnConfigureInternal(bp => bp.ForceOneTimeOnly = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.m_DependsOnQuest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintQuest"/></param>
    [Generated]
    public KingdomEventConfigurator SetDependsOnQuest(string value)
    {
      return OnConfigureInternal(bp => bp.m_DependsOnQuest = BlueprintTool.GetRef<BlueprintQuestReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.m_Tags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetTags(BlueprintKingdomEvent.TagList value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Tags = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.RequiredTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetRequiredTags(EventLocationTagList value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RequiredTags = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.OnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetOnTrigger(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnTrigger = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.StatsOnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetStatsOnTrigger(KingdomStats.Changes value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StatsOnTrigger = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.UnapplyTriggerOnResolve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetUnapplyTriggerOnResolve(bool value)
    {
      return OnConfigureInternal(bp => bp.UnapplyTriggerOnResolve = value);
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
