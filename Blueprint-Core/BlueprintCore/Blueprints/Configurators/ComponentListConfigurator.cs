using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
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
using System;
using System.Linq;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintComponentList"/>.
  /// </summary>
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
    public static ComponentListConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintComponentList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorial"><see cref="BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorialSingle))]
    public ComponentListConfigurator AddEtudeBracketEnableTutorialSingle(
        string tutorial = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketEnableTutorialSingle();
      component.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(tutorial);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorials"><see cref="BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorials))]
    public ComponentListConfigurator AddEtudeBracketEnableTutorials(
        string[] tutorials = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketEnableTutorials();
      component.m_Tutorials = tutorials.Select(name => BlueprintTool.GetRef<BlueprintTutorial.Reference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCorruptionFreeZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCorruptionFreeZone))]
    public ComponentListConfigurator AddEtudeCorruptionFreeZone(
        bool clearAllCorruption = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeCorruptionFreeZone();
      component.m_ClearAllCorruption = clearAllCorruption;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCooking"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCooking))]
    public ComponentListConfigurator AddEtudeDisableCooking(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeDisableCooking();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCraft))]
    public ComponentListConfigurator AddEtudeDisableCraft(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeDisableCraft();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeOverrideCorruptionGrowth))]
    public ComponentListConfigurator AddEtudeOverrideCorruptionGrowth(
        int corruptionGrowth = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = corruptionGrowth;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCompleteTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCompleteTrigger))]
    public ComponentListConfigurator AddEtudeCompleteTrigger(
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeCompleteTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePlayTrigger))]
    public ComponentListConfigurator AddEtudePlayTrigger(
        bool once = default,
        ConditionsBuilder conditions = null,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudePlayTrigger();
      component.m_Once = once;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioEvents))]
    public ComponentListConfigurator AddEtudeBracketAudioEvents(
        AkEventReference[] onEtudeStart = null,
        AkEventReference[] onEtudeStop = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(onEtudeStart);
      ValidateParam(onEtudeStop);
    
      var component = new EtudeBracketAudioEvents();
      component.OnEtudeStart = onEtudeStart;
      component.OnEtudeStop = onEtudeStop;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioObjects))]
    public ComponentListConfigurator AddEtudeBracketAudioObjects(
        string connectedObjectName,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketAudioObjects();
      component.ConnectedObjectName = connectedObjectName;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketCampingAction))]
    public ComponentListConfigurator AddEtudeBracketCampingAction(
        ActionsBuilder actions = null,
        bool skipRest = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketCampingAction();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipRest = skipRest;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDetachPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDetachPet))]
    public ComponentListConfigurator AddEtudeBracketDetachPet(
        UnitEvaluator master,
        PetType petType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(master);
    
      var component = new EtudeBracketDetachPet();
      component.Master = master;
      component.PetType = petType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisablePlayerRespec"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisablePlayerRespec))]
    public ComponentListConfigurator AddEtudeBracketDisablePlayerRespec(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketDisablePlayerRespec();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisableRandomEncounters))]
    public ComponentListConfigurator AddEtudeBracketDisableRandomEncounters(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketDisableRandomEncounters();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableAzataIsland"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="BlueprintGlobalMap"/></param>
    /// <param name="globalMapSpell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableAzataIsland))]
    public ComponentListConfigurator AddEtudeBracketEnableAzataIsland(
        string globalMap = null,
        string globalMapSpell = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketEnableAzataIsland();
      component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      component.m_GlobalMapSpell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(globalMapSpell);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableWarcamp"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="BlueprintGlobalMap"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableWarcamp))]
    public ComponentListConfigurator AddEtudeBracketEnableWarcamp(
        string globalMap = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketEnableWarcamp();
      component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketFollowUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketFollowUnit))]
    public ComponentListConfigurator AddEtudeBracketFollowUnit(
        UnitEvaluator leader,
        UnitEvaluator unit,
        bool useSummonPool = default,
        string summonPool = null,
        bool alwaysRun = default,
        bool canBeSlowerThanLeader = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(leader);
      ValidateParam(unit);
    
      var component = new EtudeBracketFollowUnit();
      component.Leader = leader;
      component.UseSummonPool = useSummonPool;
      component.Unit = unit;
      component.SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      component.AlwaysRun = alwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketForceCombatMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketForceCombatMode))]
    public ComponentListConfigurator AddEtudeBracketForceCombatMode(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketForceCombatMode();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketIgnoreGameover))]
    public ComponentListConfigurator AddEtudeBracketIgnoreGameover(
        EtudeBracketGameModeWaiter gameModeWaiter,
        ActionsBuilder actionList = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(gameModeWaiter);
    
      var component = new EtudeBracketIgnoreGameover();
      component.ActionList = actionList?.Build() ?? Constants.Empty.Actions;
      component.m_GameModeWaiter = gameModeWaiter;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMakePassive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMakePassive))]
    public ComponentListConfigurator AddEtudeBracketMakePassive(
        UnitEvaluator unit,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketMakePassive();
      component.Unit = unit;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMarkUnitEssential"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMarkUnitEssential))]
    public ComponentListConfigurator AddEtudeBracketMarkUnitEssential(
        UnitEvaluator target,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(target);
    
      var component = new EtudeBracketMarkUnitEssential();
      component.Target = target;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMusic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMusic))]
    public ComponentListConfigurator AddEtudeBracketMusic(
        AkEventReference startTheme,
        AkEventReference stopTheme,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(startTheme);
      ValidateParam(stopTheme);
    
      var component = new EtudeBracketMusic();
      component.StartTheme = startTheme;
      component.StopTheme = stopTheme;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideActionsOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideActionsOnClick))]
    public ComponentListConfigurator AddEtudeBracketOverrideActionsOnClick(
        UnitEvaluator unit,
        ActionsBuilder actions = null,
        float distance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketOverrideActionsOnClick();
      component.Unit = unit;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Distance = distance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideBark"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideBark))]
    public ComponentListConfigurator AddEtudeBracketOverrideBark(
        UnitEvaluator unit,
        SharedStringAsset whatToBarkShared,
        bool barkDurationByText = default,
        float distance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
      ValidateParam(whatToBarkShared);
    
      var component = new EtudeBracketOverrideBark();
      component.Unit = unit;
      component.WhatToBarkShared = whatToBarkShared;
      component.BarkDurationByText = barkDurationByText;
      component.m_Distance = distance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideDialog))]
    public ComponentListConfigurator AddEtudeBracketOverrideDialog(
        UnitEvaluator unit,
        string dialog = null,
        float distance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketOverrideDialog();
      component.Unit = unit;
      component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.m_Distance = distance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherInclemency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideWeatherInclemency))]
    public ComponentListConfigurator AddEtudeBracketOverrideWeatherInclemency(
        EtudeBracketGameModeWaiter gameModeWaiter,
        InclemencyType inclemency = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(gameModeWaiter);
    
      var component = new EtudeBracketOverrideWeatherInclemency();
      component.Inclemency = inclemency;
      component.m_GameModeWaiter = gameModeWaiter;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherProfile"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideWeatherProfile))]
    public ComponentListConfigurator AddEtudeBracketOverrideWeatherProfile(
        WeatherProfileExtended weatherProfile,
        EtudeBracketGameModeWaiter gameModeWaiter,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(weatherProfile);
      ValidateParam(gameModeWaiter);
    
      var component = new EtudeBracketOverrideWeatherProfile();
      component.m_WeatherProfile = weatherProfile;
      component.m_GameModeWaiter = gameModeWaiter;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPinCompanionInParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketPinCompanionInParty))]
    public ComponentListConfigurator AddEtudeBracketPinCompanionInParty(
        UnitEvaluator unit,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketPinCompanionInParty();
      component.Unit = unit;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPreventDirectControl"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketPreventDirectControl))]
    public ComponentListConfigurator AddEtudeBracketPreventDirectControl(
        UnitEvaluator unit,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketPreventDirectControl();
      component.Unit = unit;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketProgressBar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketProgressBar))]
    public ComponentListConfigurator AddEtudeBracketProgressBar(
        int maxProgress = default,
        LocalizedString title = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(title);
    
      var component = new EtudeBracketProgressBar();
      component.MaxProgress = maxProgress;
      component.Title = title ?? Constants.Empty.String;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketRestPhase"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketRestPhase))]
    public ComponentListConfigurator AddEtudeBracketRestPhase(
        bool multiplePhases = default,
        RestPhase phase = default,
        RestPhase firstPhase = default,
        RestPhase lastPhase = default,
        ActionsBuilder onStart = null,
        ActionsBuilder onStop = null,
        bool hasStarted = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketRestPhase();
      component.MultiplePhases = multiplePhases;
      component.Phase = phase;
      component.FirstPhase = firstPhase;
      component.LastPhase = lastPhase;
      component.OnStart = onStart?.Build() ?? Constants.Empty.Actions;
      component.OnStop = onStop?.Build() ?? Constants.Empty.Actions;
      component.HasStarted = hasStarted;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSetCompanionPosition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSetCompanionPosition))]
    public ComponentListConfigurator AddEtudeBracketSetCompanionPosition(
        EntityReference locator,
        string companion = null,
        bool shouldRelease = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(locator);
    
      var component = new EtudeBracketSetCompanionPosition();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      component.m_Locator = locator;
      component.m_ShouldRelease = shouldRelease;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketShowObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketShowObjects))]
    public ComponentListConfigurator AddEtudeBracketShowObjects(
        EntityReference[] objects = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(objects);
    
      var component = new EtudeBracketShowObjects();
      component.Objects = objects;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSummonpoolOverrideDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="BlueprintSummonPool"/></param>
    /// <param name="dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSummonpoolOverrideDialog))]
    public ComponentListConfigurator AddEtudeBracketSummonpoolOverrideDialog(
        string summonPool = null,
        string dialog = null,
        float distance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketSummonpoolOverrideDialog();
      component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.m_Distance = distance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketTriggerAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketTriggerAction))]
    public ComponentListConfigurator AddEtudeBracketTriggerAction(
        ActionsBuilder onActivated = null,
        ActionsBuilder onDeactivated = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeBracketTriggerAction();
      component.OnActivated = onActivated?.Build() ?? Constants.Empty.Actions;
      component.OnDeactivated = onDeactivated?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePartyEncumbrance))]
    public ComponentListConfigurator AddEtudeIgnorePartyEncumbrance(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeIgnorePartyEncumbrance();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePersonalEncumbrance))]
    public ComponentListConfigurator AddEtudeIgnorePersonalEncumbrance(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudeIgnorePersonalEncumbrance();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePeacefulZone))]
    public ComponentListConfigurator AddEtudePeacefulZone(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EtudePeacefulZone();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CapitalCompanionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CapitalCompanionLogic))]
    public ComponentListConfigurator AddCapitalCompanionLogic(
        bool restAllRemoteCompanions = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CapitalCompanionLogic();
      component.m_RestAllRemoteCompanions = restAllRemoteCompanions;
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }
}
