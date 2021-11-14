using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
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
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.Sound;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Etudes;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Linq;
namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Etudes
{
  /// <summary>Configurator for <see cref="BlueprintEtude"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEtude))]
  public class EtudeConfigurator : BaseFactConfigurator<BlueprintEtude, EtudeConfigurator>
  {
     private EtudeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EtudeConfigurator For(string name)
    {
      return new EtudeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static EtudeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintEtude>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EtudeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintEtude>(name, assetId);
      return For(name);
    }


    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Tutorial"><see cref="BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorialSingle))]
    public EtudeConfigurator AddEtudeBracketEnableTutorialSingle(
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
    public EtudeConfigurator AddEtudeBracketEnableTutorials(
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
    public EtudeConfigurator AddEtudeCorruptionFreeZone(
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
    public EtudeConfigurator AddEtudeDisableCooking()
    {
      return AddComponent(new EtudeDisableCooking());
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCraft))]
    public EtudeConfigurator AddEtudeDisableCraft()
    {
      return AddComponent(new EtudeDisableCraft());
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeOverrideCorruptionGrowth))]
    public EtudeConfigurator AddEtudeOverrideCorruptionGrowth(
        int m_CorruptionGrowth)
    {
      
      var component =  new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = m_CorruptionGrowth;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public EtudeConfigurator AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public EtudeConfigurator AddEveryDayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipDays)
    {
      
      var component =  new EveryDayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipDays = SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public EtudeConfigurator AddEveryWeekTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipWeeks)
    {
      
      var component =  new EveryWeekTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipWeeks = SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCompleteTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCompleteTrigger))]
    public EtudeConfigurator AddEtudeCompleteTrigger(
        ActionsBuilder Actions)
    {
      
      var component =  new EtudeCompleteTrigger();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeInvokeActionsDelayed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeInvokeActionsDelayed))]
    public EtudeConfigurator AddEtudeInvokeActionsDelayed(
        int m_Days,
        ActionsBuilder m_ActionList)
    {
      
      var component =  new EtudeInvokeActionsDelayed();
      component.m_Days = m_Days;
      component.m_ActionList = m_ActionList.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePlayTrigger))]
    public EtudeConfigurator AddEtudePlayTrigger(
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
    /// Adds <see cref="DisableMountRiding"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableMountRiding))]
    public EtudeConfigurator AddDisableMountRiding()
    {
      return AddComponent(new DisableMountRiding());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioEvents))]
    public EtudeConfigurator AddEtudeBracketAudioEvents(
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
    public EtudeConfigurator AddEtudeBracketAudioObjects(
        String ConnectedObjectName)
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
    public EtudeConfigurator AddEtudeBracketCampingAction(
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
    public EtudeConfigurator AddEtudeBracketDetachPet(
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
    public EtudeConfigurator AddEtudeBracketDisablePlayerRespec()
    {
      return AddComponent(new EtudeBracketDisablePlayerRespec());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisableRandomEncounters))]
    public EtudeConfigurator AddEtudeBracketDisableRandomEncounters()
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
    public EtudeConfigurator AddEtudeBracketEnableAzataIsland(
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
    public EtudeConfigurator AddEtudeBracketEnableWarcamp(
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
    public EtudeConfigurator AddEtudeBracketFollowUnit(
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
    public EtudeConfigurator AddEtudeBracketForceCombatMode()
    {
      return AddComponent(new EtudeBracketForceCombatMode());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketIgnoreGameover))]
    public EtudeConfigurator AddEtudeBracketIgnoreGameover(
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
    public EtudeConfigurator AddEtudeBracketMakePassive(
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
    public EtudeConfigurator AddEtudeBracketMarkUnitEssential(
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
    public EtudeConfigurator AddEtudeBracketMusic(
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
    public EtudeConfigurator AddEtudeBracketOverrideActionsOnClick(
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
    public EtudeConfigurator AddEtudeBracketOverrideBark(
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
    public EtudeConfigurator AddEtudeBracketOverrideDialog(
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
    public EtudeConfigurator AddEtudeBracketOverrideWeatherInclemency(
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
    public EtudeConfigurator AddEtudeBracketOverrideWeatherProfile(
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
    public EtudeConfigurator AddEtudeBracketPinCompanionInParty(
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
    public EtudeConfigurator AddEtudeBracketPreventDirectControl(
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
    public EtudeConfigurator AddEtudeBracketProgressBar(
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
    public EtudeConfigurator AddEtudeBracketRestPhase(
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
    public EtudeConfigurator AddEtudeBracketSetCompanionPosition(
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
    public EtudeConfigurator AddEtudeBracketShowObjects(
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
    public EtudeConfigurator AddEtudeBracketSummonpoolOverrideDialog(
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
    public EtudeConfigurator AddEtudeBracketTriggerAction(
        ActionsBuilder OnActivated,
        ActionsBuilder OnDeactivated)
    {
      
      var component =  new EtudeBracketTriggerAction();
      component.OnActivated = OnActivated.Build();
      component.OnDeactivated = OnDeactivated.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeGameOverTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeGameOverTrigger))]
    public EtudeConfigurator AddEtudeGameOverTrigger(
        ActionsBuilder OnGameOver)
    {
      
      var component =  new EtudeGameOverTrigger();
      component.OnGameOver = OnGameOver.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePartyEncumbrance))]
    public EtudeConfigurator AddEtudeIgnorePartyEncumbrance()
    {
      return AddComponent(new EtudeIgnorePartyEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePersonalEncumbrance))]
    public EtudeConfigurator AddEtudeIgnorePersonalEncumbrance()
    {
      return AddComponent(new EtudeIgnorePersonalEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePeacefulZone))]
    public EtudeConfigurator AddEtudePeacefulZone()
    {
      return AddComponent(new EtudePeacefulZone());
    }

    /// <summary>
    /// Adds <see cref="HideAllPets"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideAllPets))]
    public EtudeConfigurator AddHideAllPets(
        bool LeaveAzataDragon)
    {
      
      var component =  new HideAllPets();
      component.LeaveAzataDragon = LeaveAzataDragon;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CapitalCompanionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CapitalCompanionLogic))]
    public EtudeConfigurator AddCapitalCompanionLogic(
        bool m_RestAllRemoteCompanions)
    {
      
      var component =  new CapitalCompanionLogic();
      component.m_RestAllRemoteCompanions = m_RestAllRemoteCompanions;
      return AddComponent(component);
    }
  }
}
