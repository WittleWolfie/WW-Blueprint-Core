﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Components;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.CustomConfigurators
{
  /// <summary>Builder API for creating and modifying blueprints.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Implementation is based on the
  /// <see href="https://en.wikipedia.org/wiki/Curiously_recurring_template_pattern">Curiously Recurring Template Pattern</see>.
  /// </para>
  /// 
  /// <list type="table">
  /// <listheader>Key Features</listheader>
  /// <item>
  ///   <term>Blueprint Creation</term>
  ///   <description>
  ///     Each configurator provides a builder API for creating and modifying a specific type of blueprint. The
  ///     configurator API includes methods to set or modify fields and create or remove <see cref="BlueprintComponent"/>s.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Blueprint Component Safety</term>
  ///   <description>
  ///     <para>
  ///     Most <see cref="BlueprintComponent"/> types only function in specific blueprints. The configurator API only
  ///     exposes methods for component types supported by that blueprint. This relies on manual tuning and type
  ///     attributes from the game library; it is not guaranteed to be correct but is safer than allowing any
  ///     component types.
  ///     </para>
  ///     <para>
  ///     See <see href="https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints">Wrath Blueprints</see>
  ///     for more information on component and blueprint type safety.
  ///     </para>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Validation</term>
  ///   <description>
  ///     <para>
  ///     When <see cref="Configure"/> is called the blueprint is run through validation to detect configuration issues
  ///     which are logged as warnings. In addition to confirming the Blueprint Component Safety, validation checks
  ///     complicated configuration problems such as
  ///     <see href="https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/[Wrath]-Abilities">AbilityEffects</see>
  ///     usage.
  ///     </para>
  ///     <para>
  ///     Validation uses a combination of code from the game library and manually tuned logic. See
  ///     <see cref="Validator"/> for more details on how validation works.
  ///     </para>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Builder Style API</term>
  ///   <description>
  ///     <para>
  ///     The API is designed to minimize boilerplate required to modify blueprints and create components.
  ///     Configurators work seamlessly with the <see cref="ActionsBuilder"/> and <see cref="ConditionsBuilder"/> APIs.
  ///     </para>
  ///     <para>
  ///     Some complicated components, notably <see cref="ContextRankConfig"/>, cannot be well implemented within the
  ///     configurator API and have their own helper classes: <see cref="ContextRankConfigs">ContextRankConfigs</see>.
  ///     </para>
  ///   </description>
  /// </item>
  /// </list>
  /// TODO: Update the example
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
  public abstract class RootConfigurator<T, TBuilder>
    where T: BlueprintScriptableObject
    where TBuilder : RootConfigurator<T, TBuilder>
  {
    /// <summary>Describes how to resolve conflicts when multiple unique components are added to a blueprint.</summary>
    /// 
    /// <remarks>
    /// When adding a component that is unique, the function accepts a <see cref="ComponentMerge"/> and
    /// <see cref="Action"/> argument to resolve the conflict. Whenever possible, a reasonable default behavior is
    /// provided.
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

    protected readonly TBuilder Self;
    protected readonly T Blueprint;

    private bool Configured = false;
    private readonly Validator Validator;
    private readonly List<object> ToValidate = new();

    private readonly List<BlueprintComponent> Components = new();
    private readonly HashSet<UniqueComponent> UniqueComponents = new();
    private readonly List<BlueprintComponent> ComponentsToRemove = new();
    private readonly List<Action<T>> InternalOnConfigure = new();
    private readonly List<Action<T>> ExternalOnConfigure = new();

    protected RootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint)
    {
      Self = (TBuilder)this;
      Blueprint = blueprint.Instance;
      Validator = new(Blueprint.name, typeof(T).Name);
    }

    /// <summary>Commits the configuration changes to the blueprint.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// After commiting the changes the blueprint is validated and any errors are logged as a warning.
    /// </para>
    /// Throws <see cref="InvalidOperationException"/> if called twice on the same configurator.
    /// </remarks>
    ///
    /// <returns>The configured blueprint.</returns>
    public Blueprint<T, BlueprintReference<T>> Configure()
    {
      if (Configured)
      {
        throw new InvalidOperationException($"{Blueprint.name} has already been configured.");
      }

      Configured = true;
      Logger.Verbose($"Configuring {Blueprint.name}.");
      ConfigureComponents();
      OnConfigurePrivate();
      Blueprint.OnEnable();

      Validator.Check(Blueprint);
      ToValidate.ForEach(obj => Validator.Check(obj));
      if (Validator.HasErrors())
      {
        Logger.Warn(Validator.GetErrorString());
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
    /// Creates a new <see cref="BlueprintComponent"/> of the specified type and adds it to the blueprint.
    /// </summary>
    /// 
    /// <remarks>
    /// This is intended to support component types not implemented in the configurator API, such as custom components
    /// of your own or from another mod library.
    /// </remarks>
    /// 
    /// <param name="init">Optional initialization <see cref="Action"/> run on the component.</param>
    public TBuilder AddComponent<C>(Action<C>? init = null) where C : BlueprintComponent, new()
    {
      var component = new C();
      init?.Invoke(component);
      return AddComponent(component);
    }

    /// <summary>Adds the specified <see cref="BlueprintComponent"/> to the blueprint with merge handling.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// This is intended to support component types not implemented in the configurator API, such as custom components
    /// of your own or from another mod library.
    /// </para>
    /// <para>
    /// Use this for components which should be unique within the blueprint.
    /// </para>
    /// </remarks>
    public TBuilder AddUniqueComponent(
        BlueprintComponent component,
        ComponentMerge behavior = ComponentMerge.Fail,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      UniqueComponents.Add(new UniqueComponent(component, behavior, merge));
      return Self;
    }

    /// <summary>
    /// Edits the first <see cref="BlueprintComponent"/> of the specified type in the blueprint.
    /// </summary>
    /// 
    /// <param name="edit">Action invoked with the component as an input argument. Run when <see cref="Configure"/> is called.</param>
    public TBuilder EditComponent<C>(Action<C> edit) where C : BlueprintComponent
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<C>();
            if (component is not null) { edit.Invoke(component); }
          });
    }

    /// <summary>Removed components from the blueprint matching the specified predicate.</summary>
    /// 
    /// <remarks>Has no effect on components added with the configurator.</remarks>
    public TBuilder RemoveComponents(Func<BlueprintComponent, bool> predicate)
    {
      ComponentsToRemove.AddRange(Blueprint.Components.Where(predicate));
      return Self;
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

    //----- Start: Configure & Validate

    protected void Validate(object? obj)
    {
      if (obj is not null)
      {
        ToValidate.Add(obj);
      }
    }

    private void ConfigureComponents()
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
            component.Merge!(current, component.Component);
            break;
          case ComponentMerge.Fail:
          default:
            throw new InvalidOperationException($"Failed merging components of type {current.GetType()}");
        }
      }

      if (Blueprint.Components is not null)
      {
        Blueprint.Components = Blueprint.Components.Except(ComponentsToRemove).ToArray();
      }
      Blueprint.AddComponents(Components.ToArray());
    }

    private void OnConfigurePrivate()
    {
      InternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
      ExternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
    }

    private struct UniqueComponent
    {
      public BlueprintComponent Component { get; }
      public ComponentMerge Behavior { get; }
      public Action<BlueprintComponent, BlueprintComponent>? Merge { get; }

      public UniqueComponent(
          BlueprintComponent component,
          ComponentMerge behavior,
          Action<BlueprintComponent, BlueprintComponent>? merge)
      {
        Component = component;
        Behavior = behavior;
        Merge = merge;
      }
    }
  }
}