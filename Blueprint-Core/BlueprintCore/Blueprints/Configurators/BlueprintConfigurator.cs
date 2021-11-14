using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Validation;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Designers.Mechanics.Enums;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DLC;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.PubSubSystem;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Settings;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Fluent API for creating and modifying blueprints.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Implementation is done using the
  /// <see href="https://en.wikipedia.org/wiki/Curiously_recurring_template_pattern">Curiously Recurring Template Pattern</see>.
  /// </para>
  /// 
  /// <list type="table">
  /// <listheader>Key Features</listheader>
  /// <item>
  ///   <term>Blueprint Creation</term>
  ///   <description>
  ///     Each configurator provides a function to create a new blueprint and register it in the game library.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Component Type Safety</term>
  ///   <description>
  ///     <para>
  ///     Blueprints are very permissive; any <see cref="BlueprintComponent"/> can be added to any blueprint type. In
  ///     reality many component types are only functional on certain types of blueprints, defined using attributes.
  ///     </para>
  ///     <para>
  ///     The configurator API mimics the inheritance structure of blueprint types in the game to restrict the available
  ///     types of components. The API does not perfectly implement these restrictions because inheritance cannot
  ///     represent the restrictions completely. In those cases type safety is provided through validation.
  ///     </para>
  ///     <para>
  ///     See <see href="https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints">Wrath Blueprints</see>
  ///     for more information on component and blueprint type safety.
  ///     </para>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Validation</term>
  ///   <description>
  ///     <para>
  ///     When <see cref="Configure"/> is called a combination of Owlcat provided and custom validation logic checks the
  ///     blueprint for errors. All errors are then logged. This validates the blueprint only contains supported
  ///     component types as well as checking for some implicit usage errors, such as
  ///     <see href="https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/[Wrath]-Abilities">AbilityEffects</see>
  ///     usage.
  ///     </para>
  ///     <para>See <see cref="Validator"/> for more details on how validation works.</para>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Fluent API</term>
  ///   <description>
  ///     <para>
  ///     The API is designed to minimize boilerplate required to modify blueprints and create components. Configurators
  ///     work with the <see cref="ActionsBuilder"/> and
  ///     <see cref="Conditions.Builder.ConditionsBuilder">ConditionsBuilder</see> APIs as well.
  ///     </para>
  ///     <para>
  ///     Complicated components such as
  ///     <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see> which do not
  ///     work well with the configurator API have their own helper classes.
  ///     e.g. <see cref="Components.ContextRankConfigs">ContextRankConfigs</see>
  ///     </para>
  ///   </description>
  /// </item>
  /// </list>
  /// 
  /// <example>
  /// Add the Skald's Vigor and Greater Skald's Vigor feats (minus UI icons):
  /// <code>
  /// var skaldClass = "WW-SkaldClass";
  /// var inspiredRageFeature = "WW-InspiredRageFeature";
  /// var inspiredRageBuff = "WW-InspiredRageBuff";
  /// var skaldsVigorBuff = "WW-SkaldsVigorBuff";
  /// var skaldsVigorFeat = "WW-SkaldsVigorFeat";
  /// var greaterSkaldsVigorFeat = "WW-GreaterSkaldsVigorFeat";
  ///   
  /// // Register the names
  /// BlueprintTool.AddGuidsByName(
  ///     (skaldClass, "6afa347d804838b48bda16acb0573dc0"),
  ///     (inspiredRageFeature, "1a639eadc2c3ed546bc4bb236864cd0c"),
  ///     (inspiredRageBuff, "75b3978757908d24aaaecaf2dc209b89"),
  ///     // New blueprints and guids
  ///     (skaldsVigorBuff, "35fa838eb545491fbe73d593a3c456ed"),
  ///     (skaldsVigorFeat, "59f825ec85744ac29e7d49201561638d"),
  ///     (greaterSkaldsVigorFeat, "b97fa348973a4c5a916d78e9ed029e1f"));
  ///  
  /// // Load the icons and strings (not provided by library)
  /// var skaldsVigorIcon = LoadSkaldsVigorIcon();
  /// var greaterSkaldsVigorIcon = LoadGreaterSkaldsVigorIcon();
  /// var skaldsVigorName = LoadSkaldsVigorName();
  /// var greaterSkaldsVigorName = LoadGreaterSkaldsVigorName();
  /// var skaldsVigorDescription = LoadSkaldsVigorDescription();
  /// var greaterSkaldsVigorDescription = LoadGreaterSkaldsVigorDescription();
  /// 
  /// // Create the buff
  /// BuffConfigurator.New(skaldsVigorBuff)
  ///     .ContextRankConfig(
  ///         // Sets a context rank value to 1 + 2 * (SkaldLevels / 8).
  ///         ContextRankConfigs.ClassLevel(new string[] { skaldClass }).DivideByThenDoubleThenAdd1(8))
  ///     // Adds fast healing to the buff. The base value is 1 and the context rank value is added. Before level 8
  ///     // it provides 2; at level 8 it increases to 4; at level 16 it increases to 6.
  ///     .FastHealing(1, bonusValue: ContextValues.Rank())
  ///     .Configure();
  ///   
  /// // Creates an action to apply the buff. Permanent duration is used because it stays active as long as Inspired
  /// // Rage is active.
  /// var applyBuff = ActionsBuilder.New().ApplyBuff(skaldsVigorBuff, permanent: true, dispellable: false);
  /// BuffConfigurator.For(inspiredRageBuff)
  ///     .FactContextActions(
  ///         onActivated:
  ///             ActionsBuilder.New()
  ///                 // When the Inspired Rage buff is applied to the caster, Skald's Vigor is applied if they have
  ///                 // the feat.
  ///                 .Conditional(
  ///                     ConditionsBuilder.New().TargetIsYourself().HasFact(skaldsVigorFeat),
  ///                     ifTrue: applyBuff)
  ///                 // For characters other than the caster, Skald's Vigor is only applied if the caster has the
  ///                 // greater feat. Note: Technically this will apply the buff to the caster twice, but by default
  ///                 // buffs do not stack so it has no effect.
  ///                 .Conditional(
  ///                     ConditionsBuilder.New().CasterHasFact(greaterSkaldsVigorFeat), ifTrue: applyBuff),
  ///         onDeactivated:
  ///             // Removes Skald's Vigor when Inspired Rage ends.
  ///             // There is actually a bug with this implementation; Lingering Song will extend the duration of
  ///             // Skald's Vigor when it should not. The fix for this is beyond the scope of this example.
  ///             ActionsBuilder.New().RemoveBuff(skaldsVigorBuff))
  ///     .Configure();
  /// </code>
  /// </example>
  /// </remarks>
  [Configures(typeof(BlueprintScriptableObject))]
  public abstract class BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    /// <summary>Describes how to resolve conflicts when multiple unique components are added to a blueprint.</summary>
    /// 
    /// <remarks>
    /// When adding a component that is unique, the function accepts a <see cref="ComponentMerge"/> and
    /// <see cref="Action"/> argument to resolve the conflict. Whenever possible, a reasonable default behavior is
    /// provided. Usually this is in the form of concatenating two components that represent lists or combining flags.
    /// </remarks>
    public enum ComponentMerge
    {
      /// <summary>Default. Throws an exception.</summary>
      Fail = 0,
      /// <summary>Skips the new component. Useful for components without per-instance behavior.</summary>
      Skip,
      /// <summary>The new component is used and the existing component is removed.</summary>
      Replace,
      /// <summary>The two components are merged into one. Requires an <see cref="Action"/> to define merge behavior.</summary>
      Merge
    }

    protected static readonly LogWrapper Logger = LogWrapper.GetInternal("BlueprintConfigurator");

    private readonly List<BlueprintComponent> Components = new();
    private readonly HashSet<UniqueComponent> UniqueComponents = new();
    private readonly List<BlueprintComponent> ComponentsToRemove = new();
    private readonly List<Action<T>> InternalOnConfigure = new();
    private readonly List<Action<T>> ExternalOnConfigure = new();
    private readonly ValidationContext Context = new();

    private bool Configured = false;
    private readonly StringBuilder ValidationWarnings = new();

    protected long EnableSpellDescriptors;
    protected long DisableSpellDescriptors;

    protected AlignmentMaskType EnablePrerequisiteAlignment;
    protected AlignmentMaskType DisablePrerequisiteAlignment;

    protected readonly TBuilder Self = null;
    protected readonly string Name;
    protected readonly T Blueprint;

    protected BaseBlueprintConfigurator(string name)
    {
      Self = (TBuilder)this;
      Name = name;
      Blueprint = BlueprintTool.Get<T>(name);
    }

    /// <summary>Commits the configuration changes to the blueprint.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// After commiting the changes the blueprint is validated and any errors are logged as a warning.
    /// </para>
    /// Throws <see cref="InvalidOperationException"/> if called twice on the same configurator.
    /// </remarks>
    public T Configure()
    {
      if (Configured)
      {
        throw new InvalidOperationException($"{Name} has already been configured.");
      }

      Configured = true;
      Logger.Verbose($"Configuring {Name}.");
      ConfigureBase();
      ConfigureInternal();

      AddComponents();
      OnConfigure();
      Blueprint.OnEnable();

      Logger.Verbose($"Validating configuration for {Name}.");
      ValidateBase();
      ValidateInternal();

      if (ValidationWarnings.Length > 0)
      {
        ValidationWarnings.Insert(
            /* index= */ 0,
            $"{Name} - {typeof(T)} has warnings:{Environment.NewLine}");
        Logger.Warn(ValidationWarnings.ToString());
      }
      return Blueprint;
    }


    /// <summary>Adds the specified <see cref="BlueprintComponent"/> to the blueprint.</summary>
    /// 
    /// <remarks>
    /// It is recommended to only call this from within a configurator class or when adding a component type not
    /// supported by the configurator.
    /// </remarks>
    public TBuilder AddComponent(BlueprintComponent component)
    {
      Components.Add(component);
      return Self;
    }

    /// <summary>
    /// Adds a <see cref="BlueprintComponent"/> of the specified type to the blueprint.
    /// </summary>
    /// 
    /// <remarks>
    /// It is recommended to only call this from within a configurator class or when adding a component type not
    /// supported by the configurator.
    /// </remarks>
    /// 
    /// <param name="init">Optional initialization <see cref="Action"/> run on the component.</param>
    public TBuilder AddComponent<C>(Action<C> init) where C : BlueprintComponent, new()
    {
      var component = new C();
      init?.Invoke(component);
      return AddComponent(component);
    }

    /// <summary>Executes the specified actions when <see cref="Configure"/> is called.</summary>
    /// 
    /// <remarks>
    /// Runs as the last step of configuration, after all components are added and all other changes are applied.
    /// </remarks>
    public TBuilder OnConfigure(params Action<T>[] actions)
    {
      ExternalOnConfigure.AddRange(actions);
      return Self;
    }

    /// <summary>Internal function comparable to <see cref="OnConfigure(Action{T}[])"/>.</summary>
    /// 
    /// <remarks>
    /// Runs after all configuration is done but before <see cref="OnConfigure(Action{T}[])"/>. Configurator functions
    /// should use this to ensure the blueprint is configured before user configuration actions are run.
    /// </remarks>
    protected TBuilder OnConfigureInternal(params Action<T>[] actions)
    {
      InternalOnConfigure.AddRange(actions);
      return Self;
    }

    /// <summary>Adds the specified <see cref="BlueprintComponent"/> to the blueprint with merge handling.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// It is recommended to only call this from within a configurator class or when adding a component type not
    /// supported by the configurator.
    /// </para>
    /// <para>
    /// Use this for types without the <see cref="AllowMultipleComponentsAttribute"/>.
    /// </para>
    /// </remarks>
    public TBuilder AddUniqueComponent(
        BlueprintComponent component,
        ComponentMerge behavior = ComponentMerge.Fail,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      UniqueComponents.Add(new UniqueComponent(component, behavior, merge));
      return Self;
    }

    /// <summary>Removed components from the blueprint matching the specified predicate.</summary>
    /// 
    /// <remarks>Has no effect on components added with the configurator.</remarks>
    public TBuilder RemoveComponents(Func<BlueprintComponent, bool> predicate)
    {
      ComponentsToRemove.AddRange(Blueprint.Components.Where(predicate));
      return Self;
    }


    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.FactLogic.AddFacts">AddFacts</see>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    public TBuilder AddFacts(
        string[] facts,
        int casterLevel = 0,
        bool hasDifficultyRequirements = false,
        bool invertDifficultyRequirements = false,
        GameDifficultyOption minDifficulty = GameDifficultyOption.Story)
    {
      var addFacts = new AddFacts
      {
        m_Facts =
            facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray(),
        CasterLevel = casterLevel,
        HasDifficultyRequirements = hasDifficultyRequirements,
        InvertDifficultyRequirements = invertDifficultyRequirements,
        MinDifficulty = minDifficulty
      };
      return AddComponent(addFacts);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSkillRollTrigger"/>
    /// </summary>
    public TBuilder OnSkillCheck(
        StatType skill, ActionsBuilder actions, bool onlySuccess = true)
    {
      var trigger = new AddInitiatorSkillRollTrigger
      {
        OnlySuccess = onlySuccess,
        Skill = skill,
        Action = actions.Build()
      };
      return AddComponent(trigger);
    }

    /// <summary>
    /// Adds <see cref="AddFactContextActions"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionLists</see></remarks>
    [Implements(typeof(AddFactContextActions))]
    public TBuilder FactContextActions(
        ActionsBuilder onActivated = null,
        ActionsBuilder onDeactivated = null,
        ActionsBuilder onNewRound = null,
        ComponentMerge behavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      if (onActivated == null && onDeactivated == null && onNewRound == null)
      {
        throw new InvalidOperationException("No actions provided.");
      }
      var contextActions = new AddFactContextActions
      {
        Activated = onActivated?.Build() ?? Constants.Empty.Actions,
        Deactivated = onDeactivated?.Build() ?? Constants.Empty.Actions,
        NewRound = onNewRound?.Build() ?? Constants.Empty.Actions
      };
      return AddUniqueComponent(contextActions, behavior, merge ?? MergeFactContextActions);
    }

    [Implements(typeof(AddFactContextActions))]
    private static void MergeFactContextActions(
        BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AddFactContextActions;
      var target = other as AddFactContextActions;
      source.Activated.Actions = CommonTool.Append(source.Activated.Actions, target.Activated.Actions);
      source.Deactivated.Actions = CommonTool.Append(source.Deactivated.Actions, target.Deactivated.Actions);
      source.NewRound.Actions = CommonTool.Append(source.NewRound.Actions, target.NewRound.Actions);
    }

    /// <summary>
    /// Adds <see cref="AllowOnZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllowOnZoneSettings))]
    public TBuilder AddAllowOnZoneSettings(
        GlobalMapZone[] m_AllowedNaturalSettings)
    {
      foreach (var item in m_AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      
      var component =  new AllowOnZoneSettings();
      component.m_AllowedNaturalSettings = m_AllowedNaturalSettings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DlcReward"><see cref="BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(DlcCondition))]
    public TBuilder AddDlcCondition(
        string m_DlcReward,
        bool m_HideInstead)
    {
      
      var component =  new DlcCondition();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_DlcReward);
      component.m_HideInstead = m_HideInstead;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreCheat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreCheat))]
    public TBuilder AddDlcStoreCheat(
        bool m_IsAvailableInEditor,
        bool m_IsAvailableInDevBuild)
    {
      
      var component =  new DlcStoreCheat();
      component.m_IsAvailableInEditor = m_IsAvailableInEditor;
      component.m_IsAvailableInDevBuild = m_IsAvailableInDevBuild;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreEpic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreEpic))]
    public TBuilder AddDlcStoreEpic(
        string m_EpicId)
    {
      
      var component =  new DlcStoreEpic();
      component.m_EpicId = m_EpicId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreGog"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreGog))]
    public TBuilder AddDlcStoreGog(
        ulong m_GogId)
    {
      
      var component =  new DlcStoreGog();
      component.m_GogId = m_GogId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreSteam"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreSteam))]
    public TBuilder AddDlcStoreSteam(
        uint m_SteamId)
    {
      
      var component =  new DlcStoreSteam();
      component.m_SteamId = m_SteamId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCorruptionClear"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffOnCorruptionClear))]
    public TBuilder AddAddBuffOnCorruptionClear(
        string m_Buff,
        int m_TargetBuffRank)
    {
      
      var component =  new AddBuffOnCorruptionClear();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.m_TargetBuffRank = m_TargetBuffRank;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ComponentsList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_List"><see cref="BlueprintComponentList"/></param>
    [Generated]
    [Implements(typeof(ComponentsList))]
    public TBuilder AddComponentsList(
        string m_List)
    {
      
      var component =  new ComponentsList();
      component.m_List = BlueprintTool.GetRef<BlueprintComponentListReference>(m_List);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnlockableFlagComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BlueprintKingdomProject"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(UnlockableFlagComponent))]
    public TBuilder AddUnlockableFlagComponent(
        string m_BlueprintKingdomProject)
    {
      
      var component =  new UnlockableFlagComponent();
      component.m_BlueprintKingdomProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(m_BlueprintKingdomProject);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelsToPets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BlueprintPet"><see cref="BlueprintPet"/></param>
    [Generated]
    [Implements(typeof(AddClassLevelsToPets))]
    public TBuilder AddAddClassLevelsToPets(
        string m_BlueprintPet)
    {
      
      var component =  new AddClassLevelsToPets();
      component.m_BlueprintPet = BlueprintTool.GetRef<BlueprintPet.Reference>(m_BlueprintPet);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPlayerLeaveCombatTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPlayerLeaveCombatTrigger))]
    public TBuilder AddAddPlayerLeaveCombatTrigger(
        ActionsBuilder Actions)
    {
      
      var component =  new AddPlayerLeaveCombatTrigger();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeVendorPrices"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeVendorPrices))]
    public TBuilder AddChangeVendorPrices(
        ChangeVendorPrices.Entry[] m_PriceOverrides,
        Dictionary<BlueprintItem,long> m_ItemsToCosts)
    {
      foreach (var item in m_PriceOverrides)
      {
        ValidateParam(item);
      }
      foreach (var item in m_ItemsToCosts)
      {
        ValidateParam(item);
      }
      
      var component =  new ChangeVendorPrices();
      component.m_PriceOverrides = m_PriceOverrides;
      component.m_ItemsToCosts = m_ItemsToCosts;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(ReplaceDamageDice))]
    public TBuilder AddReplaceDamageDice(
        string m_WeaponType,
        ReplaceDamageDice.Progression[] Progressions)
    {
      foreach (var item in Progressions)
      {
        ValidateParam(item);
      }
      
      var component =  new ReplaceDamageDice();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.Progressions = Progressions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAcceptBurnOnCast"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAcceptBurnOnCast))]
    public TBuilder AddAbilityAcceptBurnOnCast(
        int BurnValue)
    {
      
      var component =  new AbilityAcceptBurnOnCast();
      component.BurnValue = BurnValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffActions))]
    public TBuilder AddAddBuffActions(
        ActionsBuilder Activated,
        ActionsBuilder Deactivated,
        ActionsBuilder NewRound)
    {
      
      var component =  new AddBuffActions();
      component.Activated = Activated.Build();
      component.Deactivated = Deactivated.Build();
      component.NewRound = NewRound.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitPropertyComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitPropertyComponent))]
    public TBuilder AddUnitPropertyComponent(
        string Name,
        PropertySettings m_Settings,
        int m_BaseValue,
        UnitPropertyComponent.ExternalProperty[] m_AddExternalProperties,
        string[] m_AddLocalProperties)
    {
      ValidateParam(m_Settings);
      foreach (var item in m_AddExternalProperties)
      {
        ValidateParam(item);
      }
      foreach (var item in m_AddLocalProperties)
      {
        ValidateParam(item);
      }
      
      var component =  new UnitPropertyComponent();
      component.Name = Name;
      component.m_Settings = m_Settings;
      component.m_BaseValue = m_BaseValue;
      component.m_AddExternalProperties = m_AddExternalProperties;
      component.m_AddLocalProperties = m_AddLocalProperties;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorAttackRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorAttackRollTrigger))]
    public TBuilder AddAddInitiatorAttackRollTrigger(
        bool OnlyHit,
        bool CriticalHit,
        bool SneakAttack,
        bool OnOwner,
        bool CheckWeapon,
        WeaponCategory WeaponCategory,
        bool AffectFriendlyTouchSpells,
        ActionsBuilder Action)
    {
      ValidateParam(WeaponCategory);
      
      var component =  new AddInitiatorAttackRollTrigger();
      component.OnlyHit = OnlyHit;
      component.CriticalHit = CriticalHit;
      component.SneakAttack = SneakAttack;
      component.OnOwner = OnOwner;
      component.CheckWeapon = CheckWeapon;
      component.WeaponCategory = WeaponCategory;
      component.AffectFriendlyTouchSpells = AffectFriendlyTouchSpells;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorAttackWithWeaponTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AddInitiatorAttackWithWeaponTrigger))]
    public TBuilder AddAddInitiatorAttackWithWeaponTrigger(
        bool WaitForAttackResolve,
        bool OnlyHit,
        bool OnMiss,
        bool OnlyOnFullAttack,
        bool OnlyOnFirstAttack,
        bool OnlyOnFirstHit,
        bool CriticalHit,
        bool OnAttackOfOpportunity,
        bool NotCriticalHit,
        bool OnlySneakAttack,
        bool NotSneakAttack,
        string m_WeaponType,
        bool CheckWeaponCategory,
        WeaponCategory Category,
        bool CheckWeaponGroup,
        WeaponFighterGroup Group,
        bool CheckWeaponRangeType,
        WeaponRangeType RangeType,
        bool ActionsOnInitiator,
        bool ReduceHPToZero,
        bool DamageMoreTargetMaxHP,
        bool CheckDistance,
        Feet DistanceLessEqual,
        bool AllNaturalAndUnarmed,
        bool DuelistWeapon,
        bool NotExtraAttack,
        bool OnCharge,
        bool IgnoreAutoHit,
        ActionsBuilder Action)
    {
      ValidateParam(Category);
      ValidateParam(Group);
      ValidateParam(RangeType);
      ValidateParam(DistanceLessEqual);
      
      var component =  new AddInitiatorAttackWithWeaponTrigger();
      component.WaitForAttackResolve = WaitForAttackResolve;
      component.OnlyHit = OnlyHit;
      component.OnMiss = OnMiss;
      component.OnlyOnFullAttack = OnlyOnFullAttack;
      component.OnlyOnFirstAttack = OnlyOnFirstAttack;
      component.OnlyOnFirstHit = OnlyOnFirstHit;
      component.CriticalHit = CriticalHit;
      component.OnAttackOfOpportunity = OnAttackOfOpportunity;
      component.NotCriticalHit = NotCriticalHit;
      component.OnlySneakAttack = OnlySneakAttack;
      component.NotSneakAttack = NotSneakAttack;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckWeaponCategory = CheckWeaponCategory;
      component.Category = Category;
      component.CheckWeaponGroup = CheckWeaponGroup;
      component.Group = Group;
      component.CheckWeaponRangeType = CheckWeaponRangeType;
      component.RangeType = RangeType;
      component.ActionsOnInitiator = ActionsOnInitiator;
      component.ReduceHPToZero = ReduceHPToZero;
      component.DamageMoreTargetMaxHP = DamageMoreTargetMaxHP;
      component.CheckDistance = CheckDistance;
      component.DistanceLessEqual = DistanceLessEqual;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.DuelistWeapon = DuelistWeapon;
      component.NotExtraAttack = NotExtraAttack;
      component.OnCharge = OnCharge;
      component.IgnoreAutoHit = IgnoreAutoHit;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetAttackRollTrigger))]
    public TBuilder AddAddTargetAttackRollTrigger(
        bool OnlyHit,
        bool CriticalHit,
        bool OnlyMelee,
        bool NotReach,
        bool CheckCategory,
        bool Not,
        WeaponCategory[] Categories,
        bool AffectFriendlyTouchSpells,
        ActionsBuilder ActionsOnAttacker,
        ActionsBuilder ActionOnSelf)
    {
      foreach (var item in Categories)
      {
        ValidateParam(item);
      }
      
      var component =  new AddTargetAttackRollTrigger();
      component.OnlyHit = OnlyHit;
      component.CriticalHit = CriticalHit;
      component.OnlyMelee = OnlyMelee;
      component.NotReach = NotReach;
      component.CheckCategory = CheckCategory;
      component.Not = Not;
      component.Categories = Categories;
      component.AffectFriendlyTouchSpells = AffectFriendlyTouchSpells;
      component.ActionsOnAttacker = ActionsOnAttacker.Build();
      component.ActionOnSelf = ActionOnSelf.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetBeforeAttackRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetBeforeAttackRollTrigger))]
    public TBuilder AddAddTargetBeforeAttackRollTrigger(
        bool OnlyMelee,
        bool NotReach,
        bool CheckDescriptor,
        SpellDescriptorWrapper SpellDescriptors,
        ActionsBuilder ActionsOnAttacker,
        ActionsBuilder ActionOnSelf)
    {
      ValidateParam(SpellDescriptors);
      
      var component =  new AddTargetBeforeAttackRollTrigger();
      component.OnlyMelee = OnlyMelee;
      component.NotReach = NotReach;
      component.CheckDescriptor = CheckDescriptor;
      component.SpellDescriptors = SpellDescriptors;
      component.ActionsOnAttacker = ActionsOnAttacker.Build();
      component.ActionOnSelf = ActionOnSelf.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDiceOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AdditionalDiceOnAttack))]
    public TBuilder AddAdditionalDiceOnAttack(
        bool OnlyOnFullAttack,
        bool OnlyOnFirstAttack,
        bool OnHit,
        bool OnlyOnFirstHit,
        bool CriticalHit,
        bool OnAttackOfOpportunity,
        bool NotCriticalHit,
        bool OnlySneakAttack,
        bool NotSneakAttack,
        string m_WeaponType,
        bool CheckWeaponCategory,
        WeaponCategory Category,
        bool CheckWeaponGroup,
        WeaponFighterGroup Group,
        bool CheckWeaponRangeType,
        WeaponRangeType RangeType,
        bool ReduceHPToZero,
        bool CheckDistance,
        Feet DistanceLessEqual,
        bool AllNaturalAndUnarmed,
        bool DuelistWeapon,
        bool NotExtraAttack,
        bool OnCharge,
        ConditionsBuilder InitiatorConditions,
        ConditionsBuilder TargetConditions,
        bool m_RandomizeDamage,
        ContextDiceValue Value,
        DamageTypeDescription DamageType,
        List<AdditionalDiceOnAttack.DamageEntry> m_DamageEntries)
    {
      ValidateParam(Category);
      ValidateParam(Group);
      ValidateParam(RangeType);
      ValidateParam(DistanceLessEqual);
      ValidateParam(Value);
      ValidateParam(DamageType);
      foreach (var item in m_DamageEntries)
      {
        ValidateParam(item);
      }
      
      var component =  new AdditionalDiceOnAttack();
      component.OnlyOnFullAttack = OnlyOnFullAttack;
      component.OnlyOnFirstAttack = OnlyOnFirstAttack;
      component.OnHit = OnHit;
      component.OnlyOnFirstHit = OnlyOnFirstHit;
      component.CriticalHit = CriticalHit;
      component.OnAttackOfOpportunity = OnAttackOfOpportunity;
      component.NotCriticalHit = NotCriticalHit;
      component.OnlySneakAttack = OnlySneakAttack;
      component.NotSneakAttack = NotSneakAttack;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckWeaponCategory = CheckWeaponCategory;
      component.Category = Category;
      component.CheckWeaponGroup = CheckWeaponGroup;
      component.Group = Group;
      component.CheckWeaponRangeType = CheckWeaponRangeType;
      component.RangeType = RangeType;
      component.ReduceHPToZero = ReduceHPToZero;
      component.CheckDistance = CheckDistance;
      component.DistanceLessEqual = DistanceLessEqual;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.DuelistWeapon = DuelistWeapon;
      component.NotExtraAttack = NotExtraAttack;
      component.OnCharge = OnCharge;
      component.InitiatorConditions = InitiatorConditions.Build();
      component.TargetConditions = TargetConditions.Build();
      component.m_RandomizeDamage = m_RandomizeDamage;
      component.Value = Value;
      component.DamageType = DamageType;
      component.m_DamageEntries = m_DamageEntries;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalStatBonusOnAttackDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalStatBonusOnAttackDamage))]
    public TBuilder AddAdditionalStatBonusOnAttackDamage(
        ConditionEnum FullAttack,
        ConditionEnum FirstAttack,
        bool CheckCategory,
        WeaponCategory Category,
        bool CheckTwoHanded,
        float Bonus)
    {
      ValidateParam(FullAttack);
      ValidateParam(FirstAttack);
      ValidateParam(Category);
      
      var component =  new AdditionalStatBonusOnAttackDamage();
      component.FullAttack = FullAttack;
      component.FirstAttack = FirstAttack;
      component.CheckCategory = CheckCategory;
      component.Category = Category;
      component.CheckTwoHanded = CheckTwoHanded;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllAttacksEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllAttacksEnhancement))]
    public TBuilder AddAllAttacksEnhancement(
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AllAttacksEnhancement();
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BashingFinish"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BashingFinish))]
    public TBuilder AddBashingFinish()
    {
      return AddComponent(new BashingFinish());
    }

    /// <summary>
    /// Adds <see cref="DestructiveShockwave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DestructiveShockwave))]
    public TBuilder AddDestructiveShockwave()
    {
      return AddComponent(new DestructiveShockwave());
    }

    /// <summary>
    /// Adds <see cref="ShieldMaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldMaster))]
    public TBuilder AddShieldMaster()
    {
      return AddComponent(new ShieldMaster());
    }

    /// <summary>
    /// Adds <see cref="AbilityAoERadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAoERadius))]
    public TBuilder AddAbilityAoERadius(
        Feet m_Radius,
        Kingmaker.UnitLogic.Abilities.Components.TargetType m_TargetType,
        bool m_CanBeUsedInTacticalCombat,
        int m_DiameterInCells)
    {
      ValidateParam(m_Radius);
      ValidateParam(m_TargetType);
      
      var component =  new AbilityAoERadius();
      component.m_Radius = m_Radius;
      component.m_TargetType = m_TargetType;
      component.m_CanBeUsedInTacticalCombat = m_CanBeUsedInTacticalCombat;
      component.m_DiameterInCells = m_DiameterInCells;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityMagusSpellRecallCostCalculator"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ImprovedFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityMagusSpellRecallCostCalculator))]
    public TBuilder AddAbilityMagusSpellRecallCostCalculator(
        string m_ImprovedFeature)
    {
      
      var component =  new AbilityMagusSpellRecallCostCalculator();
      component.m_ImprovedFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_ImprovedFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityUseOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityUseOnRest))]
    public TBuilder AddAbilityUseOnRest(
        AbilityUseOnRestType Type,
        int BaseValue,
        bool AddCasterLevel,
        bool MultiplyByCasterLevel,
        int MaxCasterLevel)
    {
      ValidateParam(Type);
      
      var component =  new AbilityUseOnRest();
      component.Type = Type;
      component.BaseValue = BaseValue;
      component.AddCasterLevel = AddCasterLevel;
      component.MultiplyByCasterLevel = MultiplyByCasterLevel;
      component.MaxCasterLevel = MaxCasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCellsRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetCellsRestriction))]
    public TBuilder AddAbilityTargetCellsRestriction(
        List<int> m_AllowedColumns,
        bool m_FactionDependent,
        bool m_OnlyEmptyCells,
        int m_Diameter)
    {
      
      var component =  new AbilityTargetCellsRestriction();
      component.m_AllowedColumns = m_AllowedColumns;
      component.m_FactionDependent = m_FactionDependent;
      component.m_OnlyEmptyCells = m_OnlyEmptyCells;
      component.m_Diameter = m_Diameter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetHasCondition))]
    public TBuilder AddAbilityTargetHasCondition(
        UnitCondition Condition,
        bool Not)
    {
      ValidateParam(Condition);
      
      var component =  new AbilityTargetHasCondition();
      component.Condition = Condition;
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasConditionOrBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHasConditionOrBuff))]
    public TBuilder AddAbilityTargetHasConditionOrBuff(
        bool Not,
        UnitCondition Condition,
        string[] m_Buffs)
    {
      ValidateParam(Condition);
      
      var component =  new AbilityTargetHasConditionOrBuff();
      component.Not = Not;
      component.Condition = Condition;
      component.m_Buffs = m_Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasOneOfConditionsOrHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetHasOneOfConditionsOrHP))]
    public TBuilder AddAbilityTargetHasOneOfConditionsOrHP(
        UnitCondition[] Condition,
        bool NeedHPCondition,
        int CurrentHPLessThan,
        bool InvertedHP)
    {
      foreach (var item in Condition)
      {
        ValidateParam(item);
      }
      
      var component =  new AbilityTargetHasOneOfConditionsOrHP();
      component.Condition = Condition;
      component.NeedHPCondition = NeedHPCondition;
      component.CurrentHPLessThan = CurrentHPLessThan;
      component.InvertedHP = InvertedHP;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsAnimalCompanion))]
    public TBuilder AddAbilityTargetIsAnimalCompanion(
        bool Not)
    {
      
      var component =  new AbilityTargetIsAnimalCompanion();
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMount"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsSuitableMount))]
    public TBuilder AddAbilityTargetIsSuitableMount()
    {
      return AddComponent(new AbilityTargetIsSuitableMount());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMountSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsSuitableMountSize))]
    public TBuilder AddAbilityTargetIsSuitableMountSize()
    {
      return AddComponent(new AbilityTargetIsSuitableMountSize());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetRangeRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetRangeRestriction))]
    public TBuilder AddAbilityTargetRangeRestriction(
        Feet Distance,
        CompareOperation.Type CompareType)
    {
      ValidateParam(Distance);
      ValidateParam(CompareType);
      
      var component =  new AbilityTargetRangeRestriction();
      component.Distance = Distance;
      component.CompareType = CompareType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyBattleResultsTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DemonArmies"><see cref="BlueprintArmyPreset"/></param>
    /// <param name="m_CrusadeLeader"><see cref="BlueprintArmyLeader"/></param>
    [Generated]
    [Implements(typeof(ArmyBattleResultsTrigger))]
    public TBuilder AddArmyBattleResultsTrigger(
        ActionsBuilder OnCrusadersVictory,
        ActionsBuilder OnDemonsVictory,
        RegionId m_AssignedRegion,
        bool m_DemonsFromList,
        string[] m_DemonArmies,
        ArmyType m_DemonsArmyType,
        bool m_SpecificCrusadeLeader,
        string m_CrusadeLeader)
    {
      ValidateParam(m_AssignedRegion);
      ValidateParam(m_DemonsArmyType);
      
      var component =  new ArmyBattleResultsTrigger();
      component.OnCrusadersVictory = OnCrusadersVictory.Build();
      component.OnDemonsVictory = OnDemonsVictory.Build();
      component.m_AssignedRegion = m_AssignedRegion;
      component.m_DemonsFromList = m_DemonsFromList;
      component.m_DemonArmies = m_DemonArmies.Select(bp => BlueprintTool.GetRef<BlueprintArmyPresetReference>(bp)).ToList();
      component.m_DemonsArmyType = m_DemonsArmyType;
      component.m_SpecificCrusadeLeader = m_SpecificCrusadeLeader;
      component.m_CrusadeLeader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(m_CrusadeLeader);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomRegionClaimedTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Regions"><see cref="BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomRegionClaimedTrigger))]
    public TBuilder AddKingdomRegionClaimedTrigger(
        string[] m_Regions,
        ActionsBuilder m_Actions)
    {
      
      var component =  new KingdomRegionClaimedTrigger();
      component.m_Regions = m_Regions.Select(bp => BlueprintTool.GetRef<BlueprintRegionReference>(bp)).ToArray();
      component.m_Actions = m_Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementSiegeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SettlementLocation"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(SettlementSiegeTrigger))]
    public TBuilder AddSettlementSiegeTrigger(
        bool m_SpecificLocation,
        string m_SettlementLocation,
        ActionsBuilder m_OnSiegeStart,
        ActionsBuilder m_OnSiegeEnd,
        ActionsBuilder m_OnSettlementDestroyed)
    {
      
      var component =  new SettlementSiegeTrigger();
      component.m_SpecificLocation = m_SpecificLocation;
      component.m_SettlementLocation = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(m_SettlementLocation);
      component.m_OnSiegeStart = m_OnSiegeStart.Build();
      component.m_OnSiegeEnd = m_OnSiegeEnd.Build();
      component.m_OnSettlementDestroyed = m_OnSettlementDestroyed.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitRecruitedTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ArmyUnits"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ArmyUnitRecruitedTrigger))]
    public TBuilder AddArmyUnitRecruitedTrigger(
        MercenariesIncludeOption m_MercenariesFilter,
        bool m_ByTag,
        ArmyProperties m_ArmyTag,
        bool m_ByUnits,
        string[] m_ArmyUnits,
        int m_MinCount,
        ActionsBuilder m_Action)
    {
      ValidateParam(m_MercenariesFilter);
      ValidateParam(m_ArmyTag);
      
      var component =  new ArmyUnitRecruitedTrigger();
      component.m_MercenariesFilter = m_MercenariesFilter;
      component.m_ByTag = m_ByTag;
      component.m_ArmyTag = m_ArmyTag;
      component.m_ByUnits = m_ByUnits;
      component.m_ArmyUnits = m_ArmyUnits.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToArray();
      component.m_MinCount = m_MinCount;
      component.m_Action = m_Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LeaderRecruitedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LeaderRecruitedTrigger))]
    public TBuilder AddLeaderRecruitedTrigger(
        ActionsBuilder m_Action)
    {
      
      var component =  new LeaderRecruitedTrigger();
      component.m_Action = m_Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonUnitsAfterArmyBattle"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonUnitsAfterArmyBattle))]
    public TBuilder AddSummonUnitsAfterArmyBattle(
        SummonUnitsAfterArmyBattle.SummonGroup[] m_Groups)
    {
      foreach (var item in m_Groups)
      {
        ValidateParam(item);
      }
      
      var component =  new SummonUnitsAfterArmyBattle();
      component.m_Groups = m_Groups;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyAbilityTags))]
    public TBuilder AddArmyAbilityTags(
        ArmyProperties Properties)
    {
      ValidateParam(Properties);
      
      var component =  new ArmyAbilityTags();
      component.Properties = Properties;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GarrisonDefeatedTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Location"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(GarrisonDefeatedTrigger))]
    public TBuilder AddGarrisonDefeatedTrigger(
        string m_Location,
        ActionsBuilder Actions)
    {
      
      var component =  new GarrisonDefeatedTrigger();
      component.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(m_Location);
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PlayerVisitGlobalMapLocationTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Location"><see cref="BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(PlayerVisitGlobalMapLocationTrigger))]
    public TBuilder AddPlayerVisitGlobalMapLocationTrigger(
        string m_Location,
        ActionsBuilder Actions)
    {
      
      var component =  new PlayerVisitGlobalMapLocationTrigger();
      component.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(m_Location);
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEquipmentToPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Items"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(AddEquipmentToPet))]
    public TBuilder AddAddEquipmentToPet(
        string[] m_Items)
    {
      
      var component =  new AddEquipmentToPet();
      component.m_Items = m_Items.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateEnterTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OnIsleStateEnterTrigger))]
    public TBuilder AddOnIsleStateEnterTrigger(
        IsleEvaluator m_IsleEvaluator,
        string m_TargetState,
        ActionsBuilder m_Actions)
    {
      ValidateParam(m_IsleEvaluator);
      
      var component =  new OnIsleStateEnterTrigger();
      component.m_IsleEvaluator = m_IsleEvaluator;
      component.m_TargetState = m_TargetState;
      component.m_Actions = m_Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateExitTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OnIsleStateExitTrigger))]
    public TBuilder AddOnIsleStateExitTrigger(
        IsleEvaluator m_IsleEvaluator,
        string m_TargetState,
        ActionsBuilder m_Actions)
    {
      ValidateParam(m_IsleEvaluator);
      
      var component =  new OnIsleStateExitTrigger();
      component.m_IsleEvaluator = m_IsleEvaluator;
      component.m_TargetState = m_TargetState;
      component.m_Actions = m_Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActivateTrigger))]
    public TBuilder AddActivateTrigger(
        bool m_Once,
        bool m_AlsoOnAreaLoad,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      
      var component =  new ActivateTrigger();
      component.m_Once = m_Once;
      component.m_AlsoOnAreaLoad = m_AlsoOnAreaLoad;
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaDidLoadTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AreaDidLoadTrigger))]
    public TBuilder AddAreaDidLoadTrigger(
        ActionsBuilder Actions,
        ConditionsBuilder Conditions)
    {
      
      var component =  new AreaDidLoadTrigger();
      component.Actions = Actions.Build();
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionRecruitTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CompanionBlueprint"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionRecruitTrigger))]
    public TBuilder AddCompanionRecruitTrigger(
        string m_CompanionBlueprint,
        ActionsBuilder Actions)
    {
      
      var component =  new CompanionRecruitTrigger();
      component.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(m_CompanionBlueprint);
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionUnrecruitTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CompanionBlueprint"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionUnrecruitTrigger))]
    public TBuilder AddCompanionUnrecruitTrigger(
        string m_CompanionBlueprint,
        bool TriggerOnDeath,
        ActionsBuilder Actions)
    {
      
      var component =  new CompanionUnrecruitTrigger();
      component.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(m_CompanionBlueprint);
      component.TriggerOnDeath = TriggerOnDeath;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomEventTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomEventTrigger))]
    public TBuilder AddCustomEventTrigger(
        string Id,
        ActionsBuilder Actions)
    {
      
      var component =  new CustomEventTrigger();
      component.Id = Id;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageTypeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageTypeTrigger))]
    public TBuilder AddDamageTypeTrigger(
        UnitEvaluator Unit,
        ActionsBuilder Actions,
        bool AnyDamageType,
        DamageEnergyType DamageEType)
    {
      ValidateParam(Unit);
      ValidateParam(DamageEType);
      
      var component =  new DamageTypeTrigger();
      component.Unit = Unit;
      component.Actions = Actions.Build();
      component.AnyDamageType = AnyDamageType;
      component.DamageEType = DamageEType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeactivateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeactivateTrigger))]
    public TBuilder AddDeactivateTrigger(
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      
      var component =  new DeactivateTrigger();
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeviceInteractionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeviceInteractionTrigger))]
    public TBuilder AddDeviceInteractionTrigger(
        ActionsBuilder Actions,
        ActionsBuilder RestrictedActions)
    {
      
      var component =  new DeviceInteractionTrigger();
      component.Actions = Actions.Build();
      component.RestrictedActions = RestrictedActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitCombatTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvaluatedUnitCombatTrigger))]
    public TBuilder AddEvaluatedUnitCombatTrigger(
        UnitEvaluator Unit,
        ActionsBuilder Actions,
        bool TriggerOnExit)
    {
      ValidateParam(Unit);
      
      var component =  new EvaluatedUnitCombatTrigger();
      component.Unit = Unit;
      component.Actions = Actions.Build();
      component.TriggerOnExit = TriggerOnExit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitDeathTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvaluatedUnitDeathTrigger))]
    public TBuilder AddEvaluatedUnitDeathTrigger(
        bool AnyUnit,
        UnitEvaluator Unit,
        ActionsBuilder Actions)
    {
      ValidateParam(Unit);
      
      var component =  new EvaluatedUnitDeathTrigger();
      component.AnyUnit = AnyUnit;
      component.Unit = Unit;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitHealthTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvaluatedUnitHealthTrigger))]
    public TBuilder AddEvaluatedUnitHealthTrigger(
        UnitEvaluator Unit,
        bool Once,
        int Percentage,
        bool TriggerOnAlreadyLowerHeath,
        ActionsBuilder Actions)
    {
      ValidateParam(Unit);
      
      var component =  new EvaluatedUnitHealthTrigger();
      component.Unit = Unit;
      component.Once = Once;
      component.Percentage = Percentage;
      component.TriggerOnAlreadyLowerHeath = TriggerOnAlreadyLowerHeath;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExperienceTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ExperienceTrigger))]
    public TBuilder AddExperienceTrigger(
        int Experience,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      
      var component =  new ExperienceTrigger();
      component.Experience = Experience;
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GenericInteractionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GenericInteractionTrigger))]
    public TBuilder AddGenericInteractionTrigger(
        EntityReference MapObject,
        ActionsBuilder Actions,
        ActionsBuilder RestrictedActions)
    {
      ValidateParam(MapObject);
      
      var component =  new GenericInteractionTrigger();
      component.MapObject = MapObject;
      component.Actions = Actions.Build();
      component.RestrictedActions = RestrictedActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemInContainerTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ItemToCheck"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemInContainerTrigger))]
    public TBuilder AddItemInContainerTrigger(
        string m_ItemToCheck,
        MapObjectEvaluator MapObject,
        ActionsBuilder OnAddActions,
        ActionsBuilder OnRemoveActions)
    {
      ValidateParam(MapObject);
      
      var component =  new ItemInContainerTrigger();
      component.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(m_ItemToCheck);
      component.MapObject = MapObject;
      component.OnAddActions = OnAddActions.Build();
      component.OnRemoveActions = OnRemoveActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MapObjectDestroyTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MapObjectDestroyTrigger))]
    public TBuilder AddMapObjectDestroyTrigger(
        ActionsBuilder DestroyedActions,
        ActionsBuilder DestructionFailedActions)
    {
      
      var component =  new MapObjectDestroyTrigger();
      component.DestroyedActions = DestroyedActions.Build();
      component.DestructionFailedActions = DestructionFailedActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MapObjectPerceptionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MapObjectPerceptionTrigger))]
    public TBuilder AddMapObjectPerceptionTrigger(
        ActionsBuilder Actions)
    {
      
      var component =  new MapObjectPerceptionTrigger();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PartyInventoryTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Item"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(PartyInventoryTrigger))]
    public TBuilder AddPartyInventoryTrigger(
        string m_Item,
        ActionsBuilder OnAddActions,
        ActionsBuilder OnRemoveActions)
    {
      
      var component =  new PartyInventoryTrigger();
      component.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(m_Item);
      component.OnAddActions = OnAddActions.Build();
      component.OnRemoveActions = OnRemoveActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PerceptionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PerceptionTrigger))]
    public TBuilder AddPerceptionTrigger(
        UnitEvaluator Unit,
        MapObjectEvaluator MapObject,
        ActionsBuilder OnSpotted)
    {
      ValidateParam(Unit);
      ValidateParam(MapObject);
      
      var component =  new PerceptionTrigger();
      component.Unit = Unit;
      component.MapObject = MapObject;
      component.OnSpotted = OnSpotted.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PlayerOpenItemDescriptionFirstTimeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Item"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(PlayerOpenItemDescriptionFirstTimeTrigger))]
    public TBuilder AddPlayerOpenItemDescriptionFirstTimeTrigger(
        string m_Item,
        ActionsBuilder Action)
    {
      
      var component =  new PlayerOpenItemDescriptionFirstTimeTrigger();
      component.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(m_Item);
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestTrigger))]
    public TBuilder AddRestTrigger(
        bool Once,
        RestResult RestResults,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      ValidateParam(RestResults);
      
      var component =  new RestTrigger();
      component.Once = Once;
      component.RestResults = RestResults;
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ScriptZoneTrigger))]
    public TBuilder AddScriptZoneTrigger(
        EntityReference ScriptZone,
        string UnitRef,
        ConditionsBuilder OnEnterConditions,
        ActionsBuilder OnEnterActions,
        ConditionsBuilder OnExitConditions,
        ActionsBuilder OnExitActions)
    {
      ValidateParam(ScriptZone);
      
      var component =  new ScriptZoneTrigger();
      component.ScriptZone = ScriptZone;
      component.UnitRef = UnitRef;
      component.OnEnterConditions = OnEnterConditions.Build();
      component.OnEnterActions = OnEnterActions.Build();
      component.OnExitConditions = OnExitConditions.Build();
      component.OnExitActions = OnExitActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillCheckInteractionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillCheckInteractionTrigger))]
    public TBuilder AddSkillCheckInteractionTrigger(
        ActionsBuilder OnSuccess,
        ActionsBuilder OnFailure)
    {
      
      var component =  new SkillCheckInteractionTrigger();
      component.OnSuccess = OnSuccess.Build();
      component.OnFailure = OnFailure.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpawnUnitTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TargetUnit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(SpawnUnitTrigger))]
    public TBuilder AddSpawnUnitTrigger(
        string m_TargetUnit,
        ActionsBuilder Actions)
    {
      
      var component =  new SpawnUnitTrigger();
      component.m_TargetUnit = BlueprintTool.GetRef<BlueprintUnitReference>(m_TargetUnit);
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellCastTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellCastTrigger))]
    public TBuilder AddSpellCastTrigger(
        EntityReference ScriptZone,
        string[] m_Spells,
        ActionsBuilder Actions)
    {
      ValidateParam(ScriptZone);
      
      var component =  new SpellCastTrigger();
      component.ScriptZone = ScriptZone;
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SummonPool"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolTrigger))]
    public TBuilder AddSummonPoolTrigger(
        int Count,
        SummonPoolTrigger.ChangeTypes ChangeType,
        string m_SummonPool,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      ValidateParam(ChangeType);
      
      var component =  new SummonPoolTrigger();
      component.Count = Count;
      component.ChangeType = ChangeType;
      component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(m_SummonPool);
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TimeOfDayChangedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TimeOfDayChangedTrigger))]
    public TBuilder AddTimeOfDayChangedTrigger(
        ActionsBuilder Actions)
    {
      
      var component =  new TimeOfDayChangedTrigger();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UIEventTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UIEventTrigger))]
    public TBuilder AddUIEventTrigger(
        UIEventType EventType,
        ConditionsBuilder Conditions,
        ActionsBuilder Actions)
    {
      ValidateParam(EventType);
      
      var component =  new UIEventTrigger();
      component.EventType = EventType;
      component.Conditions = Conditions.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitHealthTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Unit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(UnitHealthTrigger))]
    public TBuilder AddUnitHealthTrigger(
        string m_Unit,
        int Percentage,
        ActionsBuilder Actions)
    {
      
      var component =  new UnitHealthTrigger();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(m_Unit);
      component.Percentage = Percentage;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TrapTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TrapTrigger))]
    public TBuilder AddTrapTrigger(
        MapObjectEvaluator Trap,
        ActionsBuilder OnActivation,
        ActionsBuilder OnDisarm)
    {
      ValidateParam(Trap);
      
      var component =  new TrapTrigger();
      component.Trap = Trap;
      component.OnActivation = OnActivation.Build();
      component.OnDisarm = OnDisarm.Build();
      return AddComponent(component);
    }

    //----- Start: Configure & Validate

    /// <summary>Type specific configuration implemented in child classes.</summary>
    /// 
    /// <remarks>Components are added to the blueprint after this step.</remarks>
    protected virtual void ConfigureInternal() { }

    /// <summary>Type specific validation implemented in child classes.</summary>
    /// 
    /// <remarks>Implementations should report errors using <see cref="AddValidationWarning(string)"/>.</remarks>
    protected virtual void ValidateInternal() { }

    protected void AddValidationWarning(string msg) { ValidationWarnings.AppendLine(msg); }

    protected void ValidateParam(object obj) { Validator.Check(obj).ForEach(AddValidationWarning); }

    private void ConfigureBase()
    {
      ConfigurePrerequisiteAlignment();
      ConfigureSpellDescriptors();
    }

    private void OnConfigure()
    {
      InternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
      ExternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
    }

    private void AddComponents()
    {
      foreach (UniqueComponent component in UniqueComponents)
      {
        var current = Blueprint.GetComponentMatchingType(component.Component);
        if (current == null)
        {
          Components.Add(component.Component);
          continue;
        }
        switch (component.Behavior)
        {
          case ComponentMerge.Skip:
            break;
          case ComponentMerge.Replace:
            ComponentsToRemove.Add(current);
            Components.Add(component.Component);
            break;
          case ComponentMerge.Merge:
            component.Merge(current, component.Component);
            break;
          case ComponentMerge.Fail:
          default:
            throw new InvalidOperationException($"Failed merging components of type {current.GetType()}");
        }
      }

      Blueprint.Components = Blueprint.Components.Except(ComponentsToRemove).ToArray();
      Blueprint.AddComponents(Components.ToArray());
    }

    private void ValidateBase()
    {
      var validationContext = new ValidationContext();
      Blueprint.Validate(validationContext);
      foreach (var error in validationContext.Errors) { AddValidationWarning(error); }

      ValidateComponents();
    }

    private void ConfigurePrerequisiteAlignment()
    {
      var component = Blueprint.GetComponent<PrerequisiteAlignment>();
      if (component == null)
      {
        // Don't create a component to remove prerequisite alignments
        if (EnablePrerequisiteAlignment == 0) { return; }

        component = new PrerequisiteAlignment();
        AddComponent(component);
      }
      component.Alignment |= EnablePrerequisiteAlignment;
      component.Alignment &= ~DisablePrerequisiteAlignment;
    }

    private void ConfigureSpellDescriptors()
    {
      var component = Blueprint.GetComponent<SpellDescriptorComponent>();
      if (component == null)
      {
        // Don't create a component to remove descriptors
        if (EnableSpellDescriptors == 0) { return; }

        component = new SpellDescriptorComponent();
        AddComponent(component);
      }
      component.Descriptor.m_IntValue |= EnableSpellDescriptors;
      component.Descriptor.m_IntValue &= ~DisableSpellDescriptors;
    }

    /// <summary>
    /// Validates each <see cref="BlueprintComponent"/> using its own validation, attributes, and custom logic.
    /// </summary>
    private void ValidateComponents()
    {
      if (Blueprint.Components == null) { return; }
      var componentTypes = new HashSet<Type>();
      foreach (BlueprintComponent component in Blueprint.Components)
      {
        component.ApplyValidation(Context);

        var componentType = component.GetType();
        Attribute[] attrs = Attribute.GetCustomAttributes(componentType);

        if (componentTypes.Contains(componentType)
            && !attrs.Where(attr => attr is AllowMultipleComponentsAttribute).Any())
        {
          AddValidationWarning($"Multiple {componentType} present but only one is allowed.");
        }
        else { componentTypes.Add(componentType); }

        List<AllowedOnAttribute> allowedOn =
            attrs
                .Where(attr => attr is AllowedOnAttribute)
                .Select(attr => attr as AllowedOnAttribute)
                .ToList();
        bool componentAllowed = false;
        var blueprintType = Blueprint.GetType();
        foreach (AllowedOnAttribute attr in allowedOn)
        {
          // Need .NET 5.0 for IsAssignableTo()
          if (IsAssignableTo(blueprintType, attr.Type))
          {
            componentAllowed = true;
            break;
          }
        }

        if (allowedOn.Count > 0 && !componentAllowed)
        {
          AddValidationWarning($"Component of {componentType} not allowed on {blueprintType}");
        }
      }

      Context.Errors.ToList().ForEach(str => AddValidationWarning(str));
    }

    private static bool IsAssignableTo(Type child, Type parent)
    {
      return child == parent || child.IsSubclassOf(parent);
    }

    private struct UniqueComponent
    {
      public BlueprintComponent Component { get; }
      public ComponentMerge Behavior { get; }
      public Action<BlueprintComponent, BlueprintComponent> Merge { get; }

      public UniqueComponent(
          BlueprintComponent component,
          ComponentMerge behavior,
          Action<BlueprintComponent, BlueprintComponent> merge)
      {
        Component = component;
        Behavior = behavior;
        Merge = merge;
      }
    }
  }

  /// <summary>Configurator for any blueprint inheriting from <see cref="BlueprintScriptableObject"/>.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Prefer using the explicit configurator implementations wherever available.
  /// </para>
  /// 
  /// <para>
  /// BlueprintConfigurator is useful for types not supported by the library. Because it is generically typed it will
  /// not expose functions for all supported component types or functions for fields. Instead you can use
  /// <see cref="BaseBlueprintConfigurator{T, TBuilder}.AddComponent">AddComponent</see>,
  /// <see cref="BaseBlueprintConfigurator{T, TBuilder}.AddUniqueComponent">AddUniqueComponent</see>,
  /// and <see cref="BaseBlueprintConfigurator{T, TBuilder}.OnConfigure">OnConfigure</see>. This enables the
  /// configurator API without a specific type implementation and ensures your blueprints are validated.
  /// </para>
  /// 
  /// <example>
  /// <code>
  /// BlueprintConfigurator&lt;BlueprintDlc>.New(DlcGuid)
  ///     .OnConfigure(dlc => dlc.Description = LocalizedDlcDescription)
  ///     .Configure();
  /// </code>
  /// </example>
  /// </remarks>
  [Configures(typeof(BlueprintScriptableObject))]
  public class BlueprintConfigurator<T> : BaseBlueprintConfigurator<T, BlueprintConfigurator<T>>
      where T : BlueprintScriptableObject, new()
  {
    private BlueprintConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BlueprintConfigurator<T> For(string name)
    {
      return new BlueprintConfigurator<T>(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BlueprintConfigurator<T> New(string name)
    {
      BlueprintTool.Create<T>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BlueprintConfigurator<T> New(string name, string assetId)
    {
      BlueprintTool.Create<T>(name, assetId);
      return For(name);
    }
  }
}
