//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
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
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintComponentList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseComponentListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintComponentList
    where TBuilder : BaseComponentListConfigurator<T, TBuilder>
  {
    protected BaseComponentListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintComponentList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TutorAC</term><description>5436bba9ec6c6bc48b8ee9a59a4d9a9f</description></item>
    /// <item><term>TutorDamage</term><description>67d1119ed39e3e34f9846643657f88cd</description></item>
    /// <item><term>TutorDiceRoll</term><description>bb18d66d664e7514ea0acbf5b9670276</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tutorial">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableTutorialSingle(
        Blueprint<BlueprintTutorial.Reference>? tutorial = null)
    {
      var component = new EtudeBracketEnableTutorialSingle();
      component.m_Tutorial = tutorial?.Reference ?? component.m_Tutorial;
      if (component.m_Tutorial is null)
      {
        component.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorials"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CampingTrigger</term><description>6601a017a5dc33a4f8af119b1611fc69</description></item>
    /// <item><term>Tutorials_Chapter02</term><description>b21b9dcb071cb2e4eaf91c66c0431e6d</description></item>
    /// <item><term>Tutorials_Prologue</term><description>148f8a3289094484e827dce6eed48ad5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tutorials">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableTutorials(params Blueprint<BlueprintTutorial.Reference>[] tutorials)
    {
      var component = new EtudeBracketEnableTutorials();
      component.m_Tutorials = tutorials.Select(bp => bp.Reference).ToArray();
      if (component.m_Tutorials is null)
      {
        component.m_Tutorials = new BlueprintTutorial.Reference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCorruptionFreeZone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DHOutdoorDefault</term><description>0ad51df6001a4f8479cd1efa2506ea54</description></item>
    /// <item><term>Nexus03Final</term><description>a7065c0d6f6b83d4e9eb259279b7d66c</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeCorruptionFreeZone(
        bool? clearAllCorruption = null)
    {
      var component = new EtudeCorruptionFreeZone();
      component.m_ClearAllCorruption = clearAllCorruption ?? component.m_ClearAllCorruption;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Caves_1</term><description>fb8827a1b4515af408f92e1ac1bdf794</description></item>
    /// <item><term>Labyrinth</term><description>6522a51898a9b014a805a5802e97e91e</description></item>
    /// <item><term>Neathholm</term><description>1ec30c09b7ccabb4f856365af7d57a49</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeDisableCraft()
    {
      return AddComponent(new EtudeDisableCraft());
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Kenabres_CorruptionFree</term><description>24671efbec02423b923a32d471c3e0d1</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeOverrideCorruptionGrowth(
        int? corruptionGrowth = null)
    {
      var component = new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = corruptionGrowth ?? component.m_CorruptionGrowth;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCompleteTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EtudeCompleteTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1ArenaCombat</term><description>8e64ed1e12bc30c498402e99c95e75e3</description></item>
    /// <item><term>MythicAeon_RankUp03_Option01</term><description>f8794eb6fa9590342868a3f3d11373b3</description></item>
    /// <item><term>ZigguratRiot</term><description>5ecb3695c95e4bd4b836a0deac1ecfd7</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeCompleteTrigger(
        ActionsBuilder? actions = null)
    {
      var component = new EtudeCompleteTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EtudePlayTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>01_DevouredByDarkness</term><description>67d3321ed01a4e58a9ed3e13f94f1d04</description></item>
    /// <item><term>Klejm_DefaultActor</term><description>174755983e355f944bcc394c9ce6f9f0</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudePlayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        bool? isActivateOnLoadArea = null,
        bool? once = null)
    {
      var component = new EtudePlayTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.IsActivateOnLoadArea = isActivateOnLoadArea ?? component.IsActivateOnLoadArea;
      component.m_Once = once ?? component.m_Once;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableCompanionPartyChecks"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Daeran_Q2_Stage_0</term><description>162afa0be21e6f84dbaac42696b3ea17</description></item>
    /// <item><term>Daeran_Q2_Stage_3_SkillchecksBlocker</term><description>8c2981a2486c40d0b87c2e481b07c495</description></item>
    /// <item><term>Daeran_Q2_Stage_5</term><description>d63ef3e130688d94ba5a976830aae5de</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDisableCompanionPartyChecks(
        List<Blueprint<BlueprintUnitReference>>? companions = null,
        DisableCompanionPartyChecks.ModeType? mode = null)
    {
      var component = new DisableCompanionPartyChecks();
      component.m_Companions = companions?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Companions;
      if (component.m_Companions is null)
      {
        component.m_Companions = new BlueprintUnitReference[0];
      }
      component.m_Mode = mode ?? component.m_Mode;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAllowMythicPortrait"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AllowedToChangeMythicVisual</term><description>3c8d242ff4974629a3f097e58c9cd3a8</description></item>
    /// <item><term>DLC1_Megaepic</term><description>99622b80d692457890f58f73ed864f30</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketAllowMythicPortrait()
    {
      return AddComponent(new EtudeBracketAllowMythicPortrait());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_KenabresInThePast_DemonAttack_Audio</term><description>889de41c810a460d979da3f5a21cbca3</description></item>
    /// <item><term>DLC3_SongBird_Whisper_Audio</term><description>61a1ddf4236e442ea519520ce6005fa0</description></item>
    /// <item><term>WarCamp_Peaceful_Audio</term><description>aa31ae323e6e54341bc59ce6fba7c08e</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketAudioEvents(
        AkEventReference[]? onEtudeStart = null,
        AkEventReference[]? onEtudeStop = null)
    {
      var component = new EtudeBracketAudioEvents();
      Validate(onEtudeStart);
      component.OnEtudeStart = onEtudeStart ?? component.OnEtudeStart;
      if (component.OnEtudeStart is null)
      {
        component.OnEtudeStart = new AkEventReference[0];
      }
      Validate(onEtudeStop);
      component.OnEtudeStop = onEtudeStop ?? component.OnEtudeStop;
      if (component.OnEtudeStop is null)
      {
        component.OnEtudeStop = new AkEventReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioObjects"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_KenabresInThePast_Peaceful_Audio</term><description>958e97c093f2405caf2ee25ee23974bb</description></item>
    /// <item><term>GhostsLair_SideBoss_GhostOracle_Audio</term><description>e5c316917b72473fb60eb55305f25499</description></item>
    /// <item><term>ZigguratSound</term><description>f2035ebb6d074f33aaa1ec362d0f1929</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketAudioObjects(
        string? connectedObjectName = null)
    {
      var component = new EtudeBracketAudioObjects();
      component.ConnectedObjectName = connectedObjectName ?? component.ConnectedObjectName;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketCampingAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FinneanLab_indoor</term><description>9c6f8cfea11d49339f0f91cfeede6e13</description></item>
    /// <item><term>IvoryLabyrinth_Prison</term><description>f97f4de6a5073df49b9cac68859f05ae</description></item>
    /// <item><term>Threshold</term><description>207fad718f41237449b0acf414cc991a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketCampingAction(
        ActionsBuilder? actions = null,
        bool? skipRest = null)
    {
      var component = new EtudeBracketCampingAction();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.SkipRest = skipRest ?? component.SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDetachPet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataChanged_DragonDetach</term><description>ab819e3a5ef50824da38424ec7dba195</description></item>
    /// <item><term>DreamFirstVisit</term><description>82c30aaad229dd146bbe3615608c3e34</description></item>
    /// <item><term>TricksterCouncilDefault</term><description>d3306da844810c74984e37a41d6d6f99</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDetachPet(
        UnitEvaluator? master = null,
        PetType? petType = null)
    {
      var component = new EtudeBracketDetachPet();
      Validate(master);
      component.Master = master ?? component.Master;
      component.PetType = petType ?? component.PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableCampingEncounters"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC2_Catacombs_For_RE</term><description>cb95b10bc71448bbbf9773e0d19eb5e2</description></item>
    /// <item><term>DLC2_Stop_RE</term><description>8b91b3737c444cf2a1cfb2177a6af2f0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDisableCampingEncounters()
    {
      return AddComponent(new EtudeBracketDisableCampingEncounters());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisablePlayerRespec"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NoDragon</term><description>39008f5a372a6dc42bddfcf4f334bd95</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDisablePlayerRespec()
    {
      return AddComponent(new EtudeBracketDisablePlayerRespec());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Disable_KenabresRE_AfterCh2</term><description>a9d6a5d7f329469da1a7475a0d7b8f1f</description></item>
    /// <item><term>LegendGarrisonGM_NoRE</term><description>1b60bc29f8a24d08a8af2c276aee38eb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDisableRandomEncounters()
    {
      return AddComponent(new EtudeBracketDisableRandomEncounters());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableAzataIsland"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataIsland_GlobalSpell</term><description>765b5d6d0e6f4505a6471db58b3fa6ce</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="globalMapSpell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableAzataIsland(
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null,
        Blueprint<BlueprintGlobalMagicSpell.Reference>? globalMapSpell = null)
    {
      var component = new EtudeBracketEnableAzataIsland();
      component.m_GlobalMap = globalMap?.Reference ?? component.m_GlobalMap;
      if (component.m_GlobalMap is null)
      {
        component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      component.m_GlobalMapSpell = globalMapSpell?.Reference ?? component.m_GlobalMapSpell;
      if (component.m_GlobalMapSpell is null)
      {
        component.m_GlobalMapSpell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableWarcamp"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableWarcamp(
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null)
    {
      var component = new EtudeBracketEnableWarcamp();
      component.m_GlobalMap = globalMap?.Reference ?? component.m_GlobalMap;
      if (component.m_GlobalMap is null)
      {
        component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnsureAudio"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter01</term><description>df17ab913c348644b9bd3fe3f9781a84</description></item>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// <item><term>DLC3_Roguelike</term><description>3964ed959f554763bbe951818b34aead</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketEnsureAudio(
        AudioFilePackagesSettings.AudioChunk? chunk = null)
    {
      var component = new EtudeBracketEnsureAudio();
      component.Chunk = chunk ?? component.Chunk;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketFollowUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AneviaFollow</term><description>b5f1df4ce72c8cd459eb18a1cffc091b</description></item>
    /// <item><term>MagesFlamingSpearSquadFollowing3rdFloor</term><description>edca0df833a2e1441ab6763adb1ff1cd</description></item>
    /// <item><term>Wintersun_Default</term><description>87839550c801db944b102f61084fd245</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="leader">
    /// <para>
    /// Tooltip: Main character if not specified
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketFollowUnit(
        bool? alwaysRun = null,
        bool? canBeSlowerThanLeader = null,
        UnitEvaluator? leader = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null,
        UnitEvaluator? unit = null,
        bool? useSummonPool = null)
    {
      var component = new EtudeBracketFollowUnit();
      component.AlwaysRun = alwaysRun ?? component.AlwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader ?? component.CanBeSlowerThanLeader;
      Validate(leader);
      component.Leader = leader ?? component.Leader;
      component.SummonPool = summonPool?.Reference ?? component.SummonPool;
      if (component.SummonPool is null)
      {
        component.SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      component.UseSummonPool = useSummonPool ?? component.UseSummonPool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketForceCombatMode"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>XCOM_Battle</term><description>f830cff9020aa434c8b8a49980af4035</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketForceCombatMode()
    {
      return AddComponent(new EtudeBracketForceCombatMode());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SuppressGameOver</term><description>ce50ca45416742f09ac11ecb85fe6212</description></item>
    /// <item><term>ThresholdCamp_Attack</term><description>2598fbc6c16e7ec4abc5ec50f484fd4f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketIgnoreGameover(
        ActionsBuilder? actionList = null,
        EtudeBracketGameModeWaiter? gameModeWaiter = null)
    {
      var component = new EtudeBracketIgnoreGameover();
      component.ActionList = actionList?.Build() ?? component.ActionList;
      if (component.ActionList is null)
      {
        component.ActionList = Utils.Constants.Empty.Actions;
      }
      Validate(gameModeWaiter);
      component.m_GameModeWaiter = gameModeWaiter ?? component.m_GameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMakePassive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreshkagalArena_NenioIgnoreCombat</term><description>35399489cd494583af28e059e5726d6c</description></item>
    /// <item><term>PartyAssemble</term><description>5722b2a325c3d7043968fe44bd4b443c</description></item>
    /// <item><term>Woljif_Nexus_EXRemotePassive</term><description>e6055ae3cde11e9418628e1d446ac193</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketMakePassive(
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketMakePassive();
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMarkUnitEssential"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArehskagalArena_NenioFight</term><description>ff6e6564583c4757bb5759ec3f41827b</description></item>
    /// <item><term>Labyrinth</term><description>6522a51898a9b014a805a5802e97e91e</description></item>
    /// <item><term>ZosielQ0</term><description>6d1bb3f8743892a4aaf498f7fc5212f0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketMarkUnitEssential(
        UnitEvaluator? target = null)
    {
      var component = new EtudeBracketMarkUnitEssential();
      Validate(target);
      component.Target = target ?? component.Target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMusic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssaultFinished_Audio</term><description>6851b9b86373937429e7bf68079c2501</description></item>
    /// <item><term>GrayGarrison_FinalSiege_MythicPower_Sound</term><description>7d6099395babdc5488ae6d6ac72d8944</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketMusic(
        AkEventReference? startTheme = null,
        AkEventReference? stopTheme = null)
    {
      var component = new EtudeBracketMusic();
      Validate(startTheme);
      component.StartTheme = startTheme ?? component.StartTheme;
      Validate(stopTheme);
      component.StopTheme = stopTheme ?? component.StopTheme;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideActionsOnClick"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_BeforeQuest</term><description>a271248ab27e0be49bbc08a423214a16</description></item>
    /// <item><term>ExoticCapitalTraderInCapital</term><description>f5d08d5c41d6b584ca59081039a19f20</description></item>
    /// <item><term>WarCamp_DefaultPeaceful_Outdoor</term><description>27d07416c620e0e48865bd88d74cbb82</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketOverrideActionsOnClick(
        ActionsBuilder? actions = null,
        float? distance = null,
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketOverrideActionsOnClick();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_Distance = distance ?? component.m_Distance;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideBark"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_AfterQuest</term><description>d40a0634e36e06f4fa674d3cb273c60a</description></item>
    /// <item><term>AeonQ7_AfterQuest_VileniaInTavern</term><description>4050a834028925b4ca33f21dcc7b4c9e</description></item>
    /// <item><term>MutasafenLab_BarksAfter</term><description>137bd44a0ba94b778bbd077c51301861</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="barkDurationByText">
    /// <para>
    /// Tooltip: Bark duration depends on text length
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketOverrideBark(
        bool? barkDurationByText = null,
        float? distance = null,
        UnitEvaluator? unit = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var component = new EtudeBracketOverrideBark();
      component.BarkDurationByText = barkDurationByText ?? component.BarkDurationByText;
      component.m_Distance = distance ?? component.m_Distance;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      Validate(whatToBarkShared);
      component.WhatToBarkShared = whatToBarkShared ?? component.WhatToBarkShared;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_DuringQuest</term><description>fb99a426b8bf1f247a2272920a1fd13d</description></item>
    /// <item><term>Pulura_Chapter05_LeaderDialogOverride</term><description>615082e2ce01e6a4ea3164d74695da41</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialog">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketOverrideDialog(
        Blueprint<BlueprintDialogReference>? dialog = null,
        float? distance = null,
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketOverrideDialog();
      component.Dialog = dialog?.Reference ?? component.Dialog;
      if (component.Dialog is null)
      {
        component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.m_Distance = distance ?? component.m_Distance;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherInclemency"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Coronation_LocustUltimate</term><description>026bc6aeff8f4b6180822db75115a66d</description></item>
    /// <item><term>DLC2_AbyssWeather4</term><description>80703dd7e4104a94bc8c4e41b1925f86</description></item>
    /// <item><term>Prologue_Kenabres_Weather</term><description>f7fa92f20aa04f1f8d3a33575bbf3c67</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketOverrideWeatherInclemency(
        EtudeBracketGameModeWaiter? gameModeWaiter = null,
        InclemencyType? inclemency = null,
        bool? instantly = null)
    {
      var component = new EtudeBracketOverrideWeatherInclemency();
      Validate(gameModeWaiter);
      component.m_GameModeWaiter = gameModeWaiter ?? component.m_GameModeWaiter;
      component.Inclemency = inclemency ?? component.Inclemency;
      component.m_Instantly = instantly ?? component.m_Instantly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherProfile"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeskariHasArrived</term><description>9daf0401427a8e444941bdd1a8c6e301</description></item>
    /// <item><term>Ending_Legend_OtherPlane</term><description>8983b7ee630d407f94ce0688b30645c1</description></item>
    /// <item><term>SarkorianWedding_Ghost_Mechanics</term><description>ba17c86a4c334cefab1e0a4ea6cef63c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketOverrideWeatherProfile(
        EtudeBracketGameModeWaiter? gameModeWaiter = null,
        WeatherProfileExtended? weatherProfile = null)
    {
      var component = new EtudeBracketOverrideWeatherProfile();
      Validate(gameModeWaiter);
      component.m_GameModeWaiter = gameModeWaiter ?? component.m_GameModeWaiter;
      Validate(weatherProfile);
      component.m_WeatherProfile = weatherProfile ?? component.m_WeatherProfile;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPinCompanionInParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LannQ1_pin</term><description>2785eac7f7ff4668b83e7564fcb3530e</description></item>
    /// <item><term>RegillLockedInParty</term><description>9079a2dd777d415d869d4b58665d200c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketPinCompanionInParty(
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketPinCompanionInParty();
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPreventDirectControl"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LichSkeletonInDrezen</term><description>9eed74c36e7b42878d87201aa58c79e7</description></item>
    /// <item><term>PetDragonAzata_Nexus</term><description>8ec49bab42a211e4f85f593718ecc536</description></item>
    /// <item><term>PetDragonAzata_ThroneRoom</term><description>e4a1eb7ccc927bb41afbe8b20f00861f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketPreventDirectControl(
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketPreventDirectControl();
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketProgressBar"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DH_ProgressBar</term><description>4d82ae4995764612a08163fe14ab36b5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="title">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddEtudeBracketProgressBar(
        int? maxProgress = null,
        LocalString? title = null)
    {
      var component = new EtudeBracketProgressBar();
      component.MaxProgress = maxProgress ?? component.MaxProgress;
      component.Title = title?.LocalizedString ?? component.Title;
      if (component.Title is null)
      {
        component.Title = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSetCompanionPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DaeranRomance_BarksAfterSex</term><description>54998634e0121484c8f2de44b09f3766</description></item>
    /// <item><term>MilitaryGreyborRankUpPosition</term><description>eec01ec25a200874db7a93e10cccf808</description></item>
    /// <item><term>Trever_Position</term><description>0e84f374f8b74246a24c1e0a997ba6a6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="ignoreWhenEx">
    /// <para>
    /// InfoBox: Don&amp;apos;t do anything if companion is Ex
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketSetCompanionPosition(
        Blueprint<BlueprintUnitReference>? companion = null,
        bool? ignoreWhenEx = null,
        EntityReference? locator = null)
    {
      var component = new EtudeBracketSetCompanionPosition();
      component.m_Companion = companion?.Reference ?? component.m_Companion;
      if (component.m_Companion is null)
      {
        component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      component.m_IgnoreWhenEx = ignoreWhenEx ?? component.m_IgnoreWhenEx;
      Validate(locator);
      component.m_Locator = locator ?? component.m_Locator;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSummonpoolOverrideDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BribeSummonpoolInteractions</term><description>1a7f6d97ee806d1469bee16129ee23c8</description></item>
    /// <item><term>LooterSummonpoolInteractions</term><description>264f738049ac8eb409e7f9eeb228e972</description></item>
    /// <item><term>ThiefSummonpoolInteractions</term><description>e8315e9e744c3ca48b1674350c386b96</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialog">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketSummonpoolOverrideDialog(
        Blueprint<BlueprintDialogReference>? dialog = null,
        float? distance = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
    {
      var component = new EtudeBracketSummonpoolOverrideDialog();
      component.Dialog = dialog?.Reference ?? component.Dialog;
      if (component.Dialog is null)
      {
        component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.m_Distance = distance ?? component.m_Distance;
      component.m_SummonPool = summonPool?.Reference ?? component.m_SummonPool;
      if (component.m_SummonPool is null)
      {
        component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketTriggerAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLabFalseName</term><description>2bbe2729cac14033a4aa094f2df60fdc</description></item>
    /// <item><term>TricksterCouncil_Council_Lexicon2</term><description>e57f6011fd7d3694681f195960cea161</description></item>
    /// <item><term>Woljif_Q2_VoetielMeeting</term><description>70707ba408d17784e8cbf59d3fe25e18</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketTriggerAction(
        ActionsBuilder? onActivated = null,
        ActionsBuilder? onDeactivated = null)
    {
      var component = new EtudeBracketTriggerAction();
      component.OnActivated = onActivated?.Build() ?? component.OnActivated;
      if (component.OnActivated is null)
      {
        component.OnActivated = Utils.Constants.Empty.Actions;
      }
      component.OnDeactivated = onDeactivated?.Build() ?? component.OnDeactivated;
      if (component.OnDeactivated is null)
      {
        component.OnDeactivated = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_InIllusion</term><description>bbe6e346380ca6b4abba758b9b304727</description></item>
    /// <item><term>DuelWithRegill</term><description>bbc142f9b3172a64e9717cf7000d2b6c</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeIgnorePartyEncumbrance()
    {
      return AddComponent(new EtudeIgnorePartyEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_InIllusion</term><description>bbe6e346380ca6b4abba758b9b304727</description></item>
    /// <item><term>DrezenCapital_DefaultMechanic</term><description>30862a76dd4a11049be42d3de26159fb</description></item>
    /// <item><term>WarCamp_EarlyBeginning</term><description>4be1dcbb5f0a05f43b8915e14251b76c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeIgnorePersonalEncumbrance()
    {
      return AddComponent(new EtudeIgnorePersonalEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_KenabresInThePast_Peaceful_Audio</term><description>958e97c093f2405caf2ee25ee23974bb</description></item>
    /// <item><term>Prologue_Kenabres_Peaceful_Audio</term><description>4b0f1642257755343b193bfc99c78bdc</description></item>
    /// <item><term>WarCamp_EarlyBeginning</term><description>4be1dcbb5f0a05f43b8915e14251b76c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudePeacefulZone()
    {
      return AddComponent(new EtudePeacefulZone());
    }
  }
}
