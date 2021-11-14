using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Sound;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Etudes;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintComponentList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintComponentList))]
  public class ComponentListConfigurator : BaseBlueprintConfigurator<BlueprintComponentList, ComponentListConfigurator>
  {
     private ComponentListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ComponentListConfigurator For(string name)
    {
      return new ComponentListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ComponentListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintComponentList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ComponentListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintComponentList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Tutorial"><see cref="BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorialSingle))]
    public ComponentListConfigurator AddEtudeBracketEnableTutorialSingle(
        string m_Tutorial)
    {
      
      var component =  new EtudeBracketEnableTutorialSingle();
      component.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(m_Tutorial);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Tutorials"><see cref="BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorials))]
    public ComponentListConfigurator AddEtudeBracketEnableTutorials(
        string[] m_Tutorials)
    {
      
      var component =  new EtudeBracketEnableTutorials();
      component.m_Tutorials = m_Tutorials.Select(bp => BlueprintTool.GetRef<BlueprintTutorial.Reference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCorruptionFreeZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCorruptionFreeZone))]
    public ComponentListConfigurator AddEtudeCorruptionFreeZone(
        bool m_ClearAllCorruption)
    {
      
      var component =  new EtudeCorruptionFreeZone();
      component.m_ClearAllCorruption = m_ClearAllCorruption;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCooking"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCooking))]
    public ComponentListConfigurator AddEtudeDisableCooking()
    {
      return AddComponent(new EtudeDisableCooking());
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCraft))]
    public ComponentListConfigurator AddEtudeDisableCraft()
    {
      return AddComponent(new EtudeDisableCraft());
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeOverrideCorruptionGrowth))]
    public ComponentListConfigurator AddEtudeOverrideCorruptionGrowth(
        int m_CorruptionGrowth)
    {
      
      var component =  new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = m_CorruptionGrowth;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCompleteTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCompleteTrigger))]
    public ComponentListConfigurator AddEtudeCompleteTrigger(
        ActionsBuilder Actions)
    {
      
      var component =  new EtudeCompleteTrigger();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePlayTrigger))]
    public ComponentListConfigurator AddEtudePlayTrigger(
        bool m_Once,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      
      var component =  new EtudePlayTrigger();
      component.m_Once = m_Once;
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioEvents))]
    public ComponentListConfigurator AddEtudeBracketAudioEvents(
        AkEventReference[] OnEtudeStart,
        AkEventReference[] OnEtudeStop)
    {
      foreach (var item in OnEtudeStart)
      {
        ValidateParam(item);
      }
      foreach (var item in OnEtudeStop)
      {
        ValidateParam(item);
      }
      
      var component =  new EtudeBracketAudioEvents();
      component.OnEtudeStart = OnEtudeStart;
      component.OnEtudeStop = OnEtudeStop;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioObjects))]
    public ComponentListConfigurator AddEtudeBracketAudioObjects(
        string ConnectedObjectName)
    {
      
      var component =  new EtudeBracketAudioObjects();
      component.ConnectedObjectName = ConnectedObjectName;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketCampingAction))]
    public ComponentListConfigurator AddEtudeBracketCampingAction(
        ActionsBuilder Actions,
        bool SkipRest)
    {
      
      var component =  new EtudeBracketCampingAction();
      component.Actions = Actions.Build();
      component.SkipRest = SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDetachPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDetachPet))]
    public ComponentListConfigurator AddEtudeBracketDetachPet(
        UnitEvaluator Master,
        PetType PetType)
    {
      ValidateParam(Master);
      ValidateParam(PetType);
      
      var component =  new EtudeBracketDetachPet();
      component.Master = Master;
      component.PetType = PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisablePlayerRespec"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisablePlayerRespec))]
    public ComponentListConfigurator AddEtudeBracketDisablePlayerRespec()
    {
      return AddComponent(new EtudeBracketDisablePlayerRespec());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisableRandomEncounters))]
    public ComponentListConfigurator AddEtudeBracketDisableRandomEncounters()
    {
      return AddComponent(new EtudeBracketDisableRandomEncounters());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableAzataIsland"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_GlobalMap"><see cref="BlueprintGlobalMap"/></param>
    /// <param name="m_GlobalMapSpell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableAzataIsland))]
    public ComponentListConfigurator AddEtudeBracketEnableAzataIsland(
        string m_GlobalMap,
        string m_GlobalMapSpell)
    {
      
      var component =  new EtudeBracketEnableAzataIsland();
      component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(m_GlobalMap);
      component.m_GlobalMapSpell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(m_GlobalMapSpell);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableWarcamp"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_GlobalMap"><see cref="BlueprintGlobalMap"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableWarcamp))]
    public ComponentListConfigurator AddEtudeBracketEnableWarcamp(
        string m_GlobalMap)
    {
      
      var component =  new EtudeBracketEnableWarcamp();
      component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(m_GlobalMap);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketFollowUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="SummonPool"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketFollowUnit))]
    public ComponentListConfigurator AddEtudeBracketFollowUnit(
        UnitEvaluator Leader,
        bool UseSummonPool,
        UnitEvaluator Unit,
        string SummonPool,
        bool AlwaysRun,
        bool CanBeSlowerThanLeader)
    {
      ValidateParam(Leader);
      ValidateParam(Unit);
      
      var component =  new EtudeBracketFollowUnit();
      component.Leader = Leader;
      component.UseSummonPool = UseSummonPool;
      component.Unit = Unit;
      component.SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(SummonPool);
      component.AlwaysRun = AlwaysRun;
      component.CanBeSlowerThanLeader = CanBeSlowerThanLeader;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketForceCombatMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketForceCombatMode))]
    public ComponentListConfigurator AddEtudeBracketForceCombatMode()
    {
      return AddComponent(new EtudeBracketForceCombatMode());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketIgnoreGameover))]
    public ComponentListConfigurator AddEtudeBracketIgnoreGameover(
        ActionsBuilder ActionList,
        EtudeBracketGameModeWaiter m_GameModeWaiter)
    {
      ValidateParam(m_GameModeWaiter);
      
      var component =  new EtudeBracketIgnoreGameover();
      component.ActionList = ActionList.Build();
      component.m_GameModeWaiter = m_GameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMakePassive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMakePassive))]
    public ComponentListConfigurator AddEtudeBracketMakePassive(
        UnitEvaluator Unit)
    {
      ValidateParam(Unit);
      
      var component =  new EtudeBracketMakePassive();
      component.Unit = Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMarkUnitEssential"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMarkUnitEssential))]
    public ComponentListConfigurator AddEtudeBracketMarkUnitEssential(
        UnitEvaluator Target)
    {
      ValidateParam(Target);
      
      var component =  new EtudeBracketMarkUnitEssential();
      component.Target = Target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMusic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMusic))]
    public ComponentListConfigurator AddEtudeBracketMusic(
        AkEventReference StartTheme,
        AkEventReference StopTheme)
    {
      ValidateParam(StartTheme);
      ValidateParam(StopTheme);
      
      var component =  new EtudeBracketMusic();
      component.StartTheme = StartTheme;
      component.StopTheme = StopTheme;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideActionsOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideActionsOnClick))]
    public ComponentListConfigurator AddEtudeBracketOverrideActionsOnClick(
        UnitEvaluator Unit,
        ActionsBuilder Actions,
        float m_Distance)
    {
      ValidateParam(Unit);
      
      var component =  new EtudeBracketOverrideActionsOnClick();
      component.Unit = Unit;
      component.Actions = Actions.Build();
      component.m_Distance = m_Distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideBark"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideBark))]
    public ComponentListConfigurator AddEtudeBracketOverrideBark(
        UnitEvaluator Unit,
        SharedStringAsset WhatToBarkShared,
        bool BarkDurationByText,
        float m_Distance)
    {
      ValidateParam(Unit);
      ValidateParam(WhatToBarkShared);
      
      var component =  new EtudeBracketOverrideBark();
      component.Unit = Unit;
      component.WhatToBarkShared = WhatToBarkShared;
      component.BarkDurationByText = BarkDurationByText;
      component.m_Distance = m_Distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideDialog))]
    public ComponentListConfigurator AddEtudeBracketOverrideDialog(
        UnitEvaluator Unit,
        string Dialog,
        float m_Distance)
    {
      ValidateParam(Unit);
      
      var component =  new EtudeBracketOverrideDialog();
      component.Unit = Unit;
      component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(Dialog);
      component.m_Distance = m_Distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherInclemency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideWeatherInclemency))]
    public ComponentListConfigurator AddEtudeBracketOverrideWeatherInclemency(
        InclemencyType Inclemency,
        EtudeBracketGameModeWaiter m_GameModeWaiter)
    {
      ValidateParam(Inclemency);
      ValidateParam(m_GameModeWaiter);
      
      var component =  new EtudeBracketOverrideWeatherInclemency();
      component.Inclemency = Inclemency;
      component.m_GameModeWaiter = m_GameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherProfile"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideWeatherProfile))]
    public ComponentListConfigurator AddEtudeBracketOverrideWeatherProfile(
        WeatherProfileExtended m_WeatherProfile,
        EtudeBracketGameModeWaiter m_GameModeWaiter)
    {
      ValidateParam(m_WeatherProfile);
      ValidateParam(m_GameModeWaiter);
      
      var component =  new EtudeBracketOverrideWeatherProfile();
      component.m_WeatherProfile = m_WeatherProfile;
      component.m_GameModeWaiter = m_GameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPinCompanionInParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketPinCompanionInParty))]
    public ComponentListConfigurator AddEtudeBracketPinCompanionInParty(
        UnitEvaluator Unit)
    {
      ValidateParam(Unit);
      
      var component =  new EtudeBracketPinCompanionInParty();
      component.Unit = Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPreventDirectControl"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketPreventDirectControl))]
    public ComponentListConfigurator AddEtudeBracketPreventDirectControl(
        UnitEvaluator Unit)
    {
      ValidateParam(Unit);
      
      var component =  new EtudeBracketPreventDirectControl();
      component.Unit = Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketProgressBar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketProgressBar))]
    public ComponentListConfigurator AddEtudeBracketProgressBar(
        int MaxProgress,
        LocalizedString Title)
    {
      ValidateParam(Title);
      
      var component =  new EtudeBracketProgressBar();
      component.MaxProgress = MaxProgress;
      component.Title = Title;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketRestPhase"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketRestPhase))]
    public ComponentListConfigurator AddEtudeBracketRestPhase(
        bool MultiplePhases,
        RestPhase Phase,
        RestPhase FirstPhase,
        RestPhase LastPhase,
        ActionsBuilder OnStart,
        ActionsBuilder OnStop,
        bool HasStarted)
    {
      ValidateParam(Phase);
      ValidateParam(FirstPhase);
      ValidateParam(LastPhase);
      
      var component =  new EtudeBracketRestPhase();
      component.MultiplePhases = MultiplePhases;
      component.Phase = Phase;
      component.FirstPhase = FirstPhase;
      component.LastPhase = LastPhase;
      component.OnStart = OnStart.Build();
      component.OnStop = OnStop.Build();
      component.HasStarted = HasStarted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSetCompanionPosition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Companion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSetCompanionPosition))]
    public ComponentListConfigurator AddEtudeBracketSetCompanionPosition(
        string m_Companion,
        EntityReference m_Locator,
        bool m_ShouldRelease)
    {
      ValidateParam(m_Locator);
      
      var component =  new EtudeBracketSetCompanionPosition();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(m_Companion);
      component.m_Locator = m_Locator;
      component.m_ShouldRelease = m_ShouldRelease;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketShowObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketShowObjects))]
    public ComponentListConfigurator AddEtudeBracketShowObjects(
        EntityReference[] Objects)
    {
      foreach (var item in Objects)
      {
        ValidateParam(item);
      }
      
      var component =  new EtudeBracketShowObjects();
      component.Objects = Objects;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSummonpoolOverrideDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SummonPool"><see cref="BlueprintSummonPool"/></param>
    /// <param name="Dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSummonpoolOverrideDialog))]
    public ComponentListConfigurator AddEtudeBracketSummonpoolOverrideDialog(
        string m_SummonPool,
        string Dialog,
        float m_Distance)
    {
      
      var component =  new EtudeBracketSummonpoolOverrideDialog();
      component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(m_SummonPool);
      component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(Dialog);
      component.m_Distance = m_Distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketTriggerAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketTriggerAction))]
    public ComponentListConfigurator AddEtudeBracketTriggerAction(
        ActionsBuilder OnActivated,
        ActionsBuilder OnDeactivated)
    {
      
      var component =  new EtudeBracketTriggerAction();
      component.OnActivated = OnActivated.Build();
      component.OnDeactivated = OnDeactivated.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePartyEncumbrance))]
    public ComponentListConfigurator AddEtudeIgnorePartyEncumbrance()
    {
      return AddComponent(new EtudeIgnorePartyEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePersonalEncumbrance))]
    public ComponentListConfigurator AddEtudeIgnorePersonalEncumbrance()
    {
      return AddComponent(new EtudeIgnorePersonalEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePeacefulZone))]
    public ComponentListConfigurator AddEtudePeacefulZone()
    {
      return AddComponent(new EtudePeacefulZone());
    }

    /// <summary>
    /// Adds <see cref="CapitalCompanionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CapitalCompanionLogic))]
    public ComponentListConfigurator AddCapitalCompanionLogic(
        bool m_RestAllRemoteCompanions)
    {
      
      var component =  new CapitalCompanionLogic();
      component.m_RestAllRemoteCompanions = m_RestAllRemoteCompanions;
      return AddComponent(component);
    }
  }
}
