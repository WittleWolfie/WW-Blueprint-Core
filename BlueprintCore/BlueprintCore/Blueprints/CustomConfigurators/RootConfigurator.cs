using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.CustomConfigurators
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

  /// <summary>Builder API for creating and modifying blueprints.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Each supported blueprint type has a corresponding <c>Configurator</c> class to create and modify blueprints of
  /// that type, e.g. <see cref="Classes.FeatureConfigurator"/> supports <c>BlueprintFeature</c>. Configurators exist for all
  /// blueprint types inheriting from <see cref="BlueprintScriptableObject"/>, excluding any that are not used in the
  /// base game.
  /// </para>
  /// 
  /// <b>Creating a Blueprint</b>
  /// <para>Use <c>New(string, string)</c> to create a blueprint:</para>
  /// <c>FeatureConfigurator.New(MyBlueprintName, MyBlueprintGuid)</c>
  /// <para>Once <c>New()</c> is called the blueprint is added to the game library and can be referenced.</para>
  /// 
  /// <b>Using the Configurator</b>
  /// <para>
  /// <c>New()</c> returns a configurator with methods to set or modify blueprint fields and add or modify
  /// <see cref="BlueprintComponent">BlueprintComponents</see>:
  /// </para>
  /// <c>
  /// FeatureConfigurator.New(MyBlueprintName, MyBlueprintGuid).AddToGroups(FeatureGroup.Feat).AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood).Configure();
  /// </c>
  /// <para>
  /// Each method call returns the configurator allowing you to chain calls. Nothing is modified on the blueprint until
  /// <c>Configure()</c> is called, at which point the changes are applied and validated. Potential problems with the
  /// blueprint are logged as warnings.
  /// </para>
  /// 
  /// <b>Modifying an Existing Blueprint</b>
  /// <para>Use <c>For(Blueprint)</c> to modify existing blueprints:</para>
  /// <c>CharacterClassConfigurator.For(WizardClassGuid)</c>
  /// <para>Usage is otherwise identical to creating a new blueprint.</para>
  /// 
  /// For more information see <see href="https://wittlewolfie.github.io/WW-Blueprint-Core/articles/intro.html#using-blueprintcore">Using BlueprintCore</see>.
  /// </remarks>
  public abstract class RootConfigurator<T, TBuilder>
    where T: BlueprintScriptableObject
    where TBuilder : RootConfigurator<T, TBuilder>
  {
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

    protected RootConfigurator(Blueprint<BlueprintReference<T>> blueprint)
    {
      Self = (TBuilder)this;
      Blueprint = blueprint.Reference.Get();
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
    /// <returns>The resulting blueprint.</returns>
    public T Configure()
    {
      if (Configured)
      {
        throw new InvalidOperationException($"{Blueprint.name} has already been configured.");
      }

      Configured = true;
      Logger.Verbose($"Configuring {Blueprint.name}.");
      ConfigureComponents();
      OnConfigurePrivate();

      OnConfigureCompleted();
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

    // Child classes can take action after the blueprint is configured, e.g. set sane defaults for blueprint fields.
    protected virtual void OnConfigureCompleted() {}

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
