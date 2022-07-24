//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Sound;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Actions;

namespace BlueprintCore.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving audiovisual effects such as dialogs, camera, cutscenes, and sounds.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAVEx
  {

    /// <summary>
    /// Adds <see cref="ChangeBookEventImage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0224</term><description>150a2e3902592f640a2e9feb1f8a5e0b</description></item>
    /// <item><term>Cue_0416</term><description>80b227612511fe74db93f3bf28c9a032</description></item>
    /// <item><term>Cue_0539</term><description>b53a2cc59cf1715488cc23e729a04ab3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ChangeBookEventImage(
        this ActionsBuilder builder,
        AssetLink<SpriteLink> image)
    {
      var element = ElementTool.Create<ChangeBookEventImage>();
      element.m_Image = image?.Get();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPlaySound"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelMinorAbilityVisualBuff</term><description>8c902ab79f74c5c40a8071d314a0bab0</description></item>
    /// <item><term>MandragoraSwarmDamageBuff</term><description>0f4923163104a8748b88e91ec7e14837</description></item>
    /// <item><term>TickSwarmDamageBuff</term><description>97fd811a706e31c43887e163b51660b0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="soundName">
    /// <para>
    /// Tooltip: Ak event name from Wwise library
    /// </para>
    /// </param>
    public static ActionsBuilder PlaySound(
        this ActionsBuilder builder,
        string soundName)
    {
      var element = ElementTool.Create<ContextActionPlaySound>();
      element.SoundName = soundName;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRunAnimationClip"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelRevealLight_Buff</term><description>b3f693c8d4a4c964796fb33f8a24a0ef</description></item>
    /// <item><term>NightcrawlerUnburrowedBuff</term><description>88b7ded46fa24358adafa0fff50eef4c</description></item>
    /// <item><term>TigerOfSin_SpawnActions</term><description>d8416de51062a1a43af32df8764870a2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RunAnimationClip(
        this ActionsBuilder builder,
        AssetLink<AnimationClipWrapperLink> clipWrapper,
        ExecutionMode mode = ExecutionMode.Interrupted,
        float? transitionIn = null,
        float? transitionOut = null)
    {
      var element = ElementTool.Create<ContextActionRunAnimationClip>();
      element.ClipWrapper = clipWrapper?.Get();
      element.Mode = mode;
      element.TransitionIn = transitionIn ?? element.TransitionIn;
      element.TransitionOut = transitionOut ?? element.TransitionOut;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShowBark"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AboutIzyagna</term><description>fa1f67444ec844508ea2eb6549581d5d</description></item>
    /// <item><term>HowToMythicADemon</term><description>e9fe24ad25c54b6b8f288ef822c549ce</description></item>
    /// <item><term>ZachariusNecromancy</term><description>de12840a4662481f937ff9542a6beb6b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="whatToBark">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="barkDurationByText">
    /// <para>
    /// Tooltip: Bark duration depends on text length
    /// </para>
    /// </param>
    public static ActionsBuilder ShowBark(
        this ActionsBuilder builder,
        LocalString whatToBark,
        bool? barkDurationByText = null,
        bool? showWhileUnconscious = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var element = ElementTool.Create<ContextActionShowBark>();
      element.WhatToBark = whatToBark?.LocalizedString;
      element.BarkDurationByText = barkDurationByText ?? element.BarkDurationByText;
      element.ShowWhileUnconscious = showWhileUnconscious ?? element.ShowWhileUnconscious;
      builder.Validate(whatToBarkShared);
      element.WhatToBarkShared = whatToBarkShared ?? element.WhatToBarkShared;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnFx"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_TrueForm_Cutscene</term><description>18d9251a3c5682a429e1c3769431f4ee</description></item>
    /// <item><term>InflictModerateWoundsMass</term><description>03944622fbe04824684ec29ff2cec6a7</description></item>
    /// <item><term>ZeroState</term><description>c6195ff24255d3f46a26323de9f1187a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SpawnFx(
        this ActionsBuilder builder,
        AssetLink<PrefabLink> prefabLink)
    {
      var element = ElementTool.Create<ContextActionSpawnFx>();
      element.PrefabLink = prefabLink?.Get();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CameraToPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/CameraToPosition
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>6264845f5654cdd48809fe36f5dc4ffb</description></item>
    /// <item><term>Cue_0024</term><description>c43f80ef0e950c3449a74dd8e403bf6e</description></item>
    /// <item><term>Wardstone_SoldiersAndDemonsFight</term><description>76de06039af340ddba4ed13149ecb72a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder CameraToPosition(
        this ActionsBuilder builder,
        PositionEvaluator? position = null)
    {
      var element = ElementTool.Create<CameraToPosition>();
      builder.Validate(position);
      element.Position = position ?? element.Position;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Play2DSound"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Play2DSound
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirAdventures_BookEvent</term><description>a07f6d1f93531e048928c5c9de328a92</description></item>
    /// <item><term>CommandAction1</term><description>ffd7ece2931543b08711654f927b28c8</description></item>
    /// <item><term>WillSaveGhoulCheckPassed_Actions</term><description>0a39e8f4368328949aca5616589abe5d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="setRace">
    /// <para>
    /// Tooltip: Sets Ak switch on player&amp;apos;s Race
    /// </para>
    /// </param>
    /// <param name="setSex">
    /// <para>
    /// Tooltip: Sets Ak switch on player&amp;apos;s Sex
    /// </para>
    /// </param>
    /// <param name="soundName">
    /// <para>
    /// Tooltip: Ak event name from Wwise library
    /// </para>
    /// </param>
    public static ActionsBuilder Play2DSound(
        this ActionsBuilder builder,
        bool? setRace = null,
        bool? setSex = null,
        string? soundName = null)
    {
      var element = ElementTool.Create<Play2DSound>();
      element.SetRace = setRace ?? element.SetRace;
      element.SetSex = setSex ?? element.SetSex;
      element.SoundName = soundName ?? element.SoundName;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Play3DSound"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Play3DSound
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0004</term><description>979c0288728143d4cadd65e43eb70f77</description></item>
    /// <item><term>CommandAction2</term><description>bf0933f5898f4fd280fbb4638979be84</description></item>
    /// <item><term>Tools_CheckPassedActions2</term><description>db695eb808004014b25ad3475123d544</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="setCurrentSpeaker">
    /// <para>
    /// Tooltip: Sets SoundSourceObject as current dialog speaker
    /// </para>
    /// </param>
    /// <param name="setRace">
    /// <para>
    /// Tooltip: Sets Ak switch on player&amp;apos;s Race
    /// </para>
    /// </param>
    /// <param name="setSex">
    /// <para>
    /// Tooltip: Sets Ak switch on player&amp;apos;s Sex
    /// </para>
    /// </param>
    /// <param name="soundName">
    /// <para>
    /// Tooltip: Ak event name from Wwise library
    /// </para>
    /// </param>
    public static ActionsBuilder Play3DSound(
        this ActionsBuilder builder,
        bool? setCurrentSpeaker = null,
        bool? setRace = null,
        bool? setSex = null,
        string? soundName = null,
        EntityReference? soundSourceObject = null)
    {
      var element = ElementTool.Create<Play3DSound>();
      element.SetCurrentSpeaker = setCurrentSpeaker ?? element.SetCurrentSpeaker;
      element.SetRace = setRace ?? element.SetRace;
      element.SetSex = setSex ?? element.SetSex;
      element.SoundName = soundName ?? element.SoundName;
      builder.Validate(soundSourceObject);
      element.SoundSourceObject = soundSourceObject ?? element.SoundSourceObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayAnimationOneShot"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0005</term><description>058d6563b283ae04294ba2c729383663</description></item>
    /// <item><term>Cue_0016</term><description>bb7b3fbefbb88e34a97bc895f76c368e</description></item>
    /// <item><term>Vrok_Chained</term><description>b04649a8dd8abf741a51728a4ba9c746</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PlayAnimationOneShot(
        this ActionsBuilder builder,
        AssetLink<AnimationClipWrapperLink>? clipWrapper = null,
        float? transitionIn = null,
        float? transitionOut = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<PlayAnimationOneShot>();
      element.m_ClipWrapper = clipWrapper?.Get() ?? element.m_ClipWrapper;
      element.TransitionIn = transitionIn ?? element.TransitionIn;
      element.TransitionOut = transitionOut ?? element.TransitionOut;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayCustomMusic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/PlayCustomMusic
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abducted_dialogue</term><description>43c9a316be2e45678606133610e80063</description></item>
    /// <item><term>FirstCultistAttack_dialogue</term><description>5d0e5f6591424935983d03c587618ba9</description></item>
    /// <item><term>ZachariusLostChapel_dialogue</term><description>484953d7dfcc1244fadfdeab34a363ff</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PlayCustomMusic(
        this ActionsBuilder builder,
        string? musicEventStart = null,
        string? musicEventStop = null)
    {
      var element = ElementTool.Create<PlayCustomMusic>();
      element.MusicEventStart = musicEventStart ?? element.MusicEventStart;
      element.MusicEventStop = musicEventStop ?? element.MusicEventStop;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayCutscene"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Play cutscene
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>(CR 6) Necromancer_SpawnActions</term><description>966067be66094e699fd7247f4507dd1a</description></item>
    /// <item><term>Cue_0049</term><description>5a2c83b1758ca624bbd3d87d7a3e15c2</description></item>
    /// <item><term>Zone3_Epigraph_SZ</term><description>fde009ee2ae62024baaac478de277b28</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cutscene">
    /// <para>
    /// Blueprint of type Cutscene. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder PlayCutscene(
        this ActionsBuilder builder,
        bool? checkExistence = null,
        Blueprint<CutsceneReference>? cutscene = null,
        ParametrizedContextSetter? parameters = null,
        bool? putInQueue = null)
    {
      var element = ElementTool.Create<PlayCutscene>();
      element.CheckExistence = checkExistence ?? element.CheckExistence;
      element.m_Cutscene = cutscene?.Reference ?? element.m_Cutscene;
      if (element.m_Cutscene is null)
      {
        element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      element.PutInQueue = putInQueue ?? element.PutInQueue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReloadMechanic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Arueshalae_DemonWarningKTC</term><description>58b51cce24b484e40ae075c5f56ad2e5</description></item>
    /// <item><term>KTC_LichRankUp_6</term><description>ca49b13b14484b81bbe33d0048861ba2</description></item>
    /// <item><term>WenduagKTC_WenduagRomance_TroublesInTheTavern</term><description>70260967f8e8efc40934a31a346221b0</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ReloadMechanic(
        this ActionsBuilder builder,
        bool? clearFx = null,
        string? desc = null)
    {
      var element = ElementTool.Create<ReloadMechanic>();
      element.ClearFx = clearFx ?? element.ClearFx;
      element.Desc = desc ?? element.Desc;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetSoundState"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SetSoundState
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirAdventures_BookEvent</term><description>a07f6d1f93531e048928c5c9de328a92</description></item>
    /// <item><term>CommandAction34</term><description>11f8d7b34e3f4153baa5f150098e62eb</description></item>
    /// <item><term>TerendelevPast_dialogue</term><description>848b9fe70613fd4408ff6c8ab4c95e14</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SetSoundState(
        this ActionsBuilder builder,
        AkStateReference? state = null)
    {
      var element = ElementTool.Create<SetSoundState>();
      builder.Validate(state);
      element.m_State = state ?? element.m_State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowBark"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/ShowBark
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>!Octavia_Companion_Warrior_Test</term><description>0f5938a10fd0d3644be33747d6d2b11c</description></item>
    /// <item><term>GreyborEnterZone</term><description>547cc0d248f5f6b459d09a4820f83831</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="barkDurationByText">
    /// <para>
    /// Tooltip: Bark duration depends on text length
    /// </para>
    /// </param>
    /// <param name="whatToBark">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder ShowBark(
        this ActionsBuilder builder,
        bool? barkDurationByText = null,
        MapObjectEvaluator? targetMapObject = null,
        UnitEvaluator? targetUnit = null,
        LocalString? whatToBark = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var element = ElementTool.Create<ShowBark>();
      element.BarkDurationByText = barkDurationByText ?? element.BarkDurationByText;
      builder.Validate(targetMapObject);
      element.TargetMapObject = targetMapObject ?? element.TargetMapObject;
      builder.Validate(targetUnit);
      element.TargetUnit = targetUnit ?? element.TargetUnit;
      element.WhatToBark = whatToBark?.LocalizedString ?? element.WhatToBark;
      if (element.WhatToBark is null)
      {
        element.WhatToBark = Utils.Constants.Empty.String;
      }
      builder.Validate(whatToBarkShared);
      element.WhatToBarkShared = whatToBarkShared ?? element.WhatToBarkShared;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnFx"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdditionalAtmosphericScenes</term><description>e04f6b926f3350d41ab2d07c55d9814d</description></item>
    /// <item><term>CommandAction1</term><description>8db12bd249514acaa8233858c4669d60</description></item>
    /// <item><term>Ziggurat_CorruptionReducer_Cleanse_CheckPassedActions</term><description>a53e004ccda24065b81f49c9ee3b0e49</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SpawnFx(
        this ActionsBuilder builder,
        AssetLink<PrefabLink>? fxPrefab = null,
        TransformEvaluator? target = null)
    {
      var element = ElementTool.Create<SpawnFx>();
      element.FxPrefab = fxPrefab?.Get() ?? element.FxPrefab;
      if (element.FxPrefab is null)
      {
        element.FxPrefab = Utils.Constants.Empty.PrefabLink;
      }
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StopCustomMusic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abducted_dialogue</term><description>43c9a316be2e45678606133610e80063</description></item>
    /// <item><term>Hepzamirah_MainDialogue</term><description>5662c8bcb913b3842a10f67034c096f3</description></item>
    /// <item><term>ZachariusLostChapel_dialogue</term><description>484953d7dfcc1244fadfdeab34a363ff</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder StopCustomMusic(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<StopCustomMusic>());
    }

    /// <summary>
    /// Adds <see cref="StopCutscene"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Stop cutscene
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abad_state_0</term><description>52edc4f040174899850aaeb0b853b1d8</description></item>
    /// <item><term>Cue_0026</term><description>7a0d1af8491b4c84d9355fa555c942e9</description></item>
    /// <item><term>ZombiesDead</term><description>c042c6cb0eaaafc418c94615e4aac891</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkType">
    /// <para>
    /// InfoBox: If set to &amp;apos;Controlled&amp;apos;, stops all cutscenes that marked selected unit.  If set to &amp;apos;Params&amp;apos; stops all cutscenes that have selected unit as a parameter.  &amp;apos;Controlled&amp;apos; is the old mode, you probably never need it.
    /// </para>
    /// </param>
    /// <param name="cutscene">
    /// <para>
    /// Blueprint of type Cutscene. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder StopCutscene(
        this ActionsBuilder builder,
        StopCutscene.UnitCheckType? checkType = null,
        Blueprint<CutsceneReference>? cutscene = null,
        UnitEvaluator? withUnit = null)
    {
      var element = ElementTool.Create<StopCutscene>();
      element.m_CheckType = checkType ?? element.m_CheckType;
      element.m_Cutscene = cutscene?.Reference ?? element.m_Cutscene;
      if (element.m_Cutscene is null)
      {
        element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(null);
      }
      builder.Validate(withUnit);
      element.WithUnit = withUnit ?? element.WithUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ToggleObjectFx"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2ArenaCombat</term><description>bdd2b9ebe0ec2f240b9ac1d6b4c430ab</description></item>
    /// <item><term>CommandAction3</term><description>36a68c2f8f96483ea8d42bf9a25089df</description></item>
    /// <item><term>Ziggurat_CorruptionReducer_Cleanse_CheckPassedActions</term><description>a53e004ccda24065b81f49c9ee3b0e49</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ToggleObjectFx(
        this ActionsBuilder builder,
        MapObjectEvaluator? target = null,
        bool? toggleOn = null)
    {
      var element = ElementTool.Create<ToggleObjectFx>();
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.ToggleOn = toggleOn ?? element.ToggleOn;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ToggleObjectMusic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArushalaeRedoubt_CustomMusicCave_fromCellar_Disable</term><description>b5980fc442390ed4783a2cad6b5d428c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ToggleObjectMusic(
        this ActionsBuilder builder,
        MapObjectEvaluator? target = null,
        bool? toggleOn = null)
    {
      var element = ElementTool.Create<ToggleObjectMusic>();
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.ToggleOn = toggleOn ?? element.ToggleOn;
      return builder.Add(element);
    }
  }
}
