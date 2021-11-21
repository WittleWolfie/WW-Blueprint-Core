using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Validation;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: Add "Set" methods for configurator template fields
namespace BlueprintCoreGen.Blueprints.Configurators
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

    // [Replace("Get", "GetInternal")]
    protected static readonly LogWrapper Logger = LogWrapper.Get("BlueprintConfigurator");

    private readonly List<BlueprintComponent> Components = new();
    private readonly HashSet<UniqueComponent> UniqueComponents = new();
    private readonly List<BlueprintComponent> ComponentsToRemove = new();
    private readonly List<Action<T>> InternalOnConfigure = new();
    private readonly List<Action<T>> ExternalOnConfigure = new();
    private readonly ValidationContext Context = new();

    private bool Configured = false;
    private readonly StringBuilder ValidationWarnings = new();

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
      ConfigureInternal();

      ConfigureComponents();
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

    // [GenerateComponents]

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

    protected void ValidateParam<T>(IEnumerable<T> objects)
    {
      if (objects is null) { return; }
      foreach (var obj in objects) { ValidateParam(obj); }
    }

    private void OnConfigure()
    {
      InternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
      ExternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
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
            component.Merge(current, component.Component);
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

    private void ValidateBase()
    {
      var validationContext = new ValidationContext();
      Blueprint.Validate(validationContext);
      foreach (var error in validationContext.Errors) { AddValidationWarning(error); }

      ValidateComponents();
    }

    // TODO: Refactor validation to rely on Validator. That way it can be used externally.
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

      // Make sure there are no conflicting ContextRankConfigs
      var duplicateRankTypes =
          Blueprint.GetComponents<ContextRankConfig>()
              .Select(config => config.m_Type)
              .GroupBy(type => type)
              .Where(group => group.Count() > 1)
              .Select(group => group.Key);
      if (duplicateRankTypes.Any())
      {
        AddValidationWarning(
            $"Duplicate ContextRankConfig.m_Type values found. Only one of each type is used: {string.Join(",", duplicateRankTypes)}");
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