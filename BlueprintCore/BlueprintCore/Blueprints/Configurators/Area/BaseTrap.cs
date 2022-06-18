//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.ElementsSystem;
using Kingmaker.Visual.Animation.Kingmaker;
using System;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTrap"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTrapConfigurator<T, TBuilder>
    : BaseMapObjectConfigurator<T, TBuilder>
    where T : BlueprintTrap
    where TBuilder : BaseTrapConfigurator<T, TBuilder>
  {
    protected BaseTrapConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.PerceptionDC"/>
    /// </summary>
    public TBuilder SetPerceptionDC(int perceptionDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PerceptionDC = perceptionDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.PerceptionDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPerceptionDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PerceptionDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.PerceptionRadius"/>
    /// </summary>
    public TBuilder SetPerceptionRadius(float perceptionRadius)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PerceptionRadius = perceptionRadius;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.PerceptionRadius"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPerceptionRadius(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PerceptionRadius);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.DisableDC"/>
    /// </summary>
    public TBuilder SetDisableDC(int disableDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableDC = disableDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.DisableDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisableDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.DisableTriggerMargin"/>
    /// </summary>
    public TBuilder SetDisableTriggerMargin(int disableTriggerMargin)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableTriggerMargin = disableTriggerMargin;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.DisableTriggerMargin"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableTriggerMargin(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisableTriggerMargin);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.IsHiddenWhenInactive"/>
    /// </summary>
    public TBuilder SetIsHiddenWhenInactive(bool isHiddenWhenInactive = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsHiddenWhenInactive = isHiddenWhenInactive;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.IsHiddenWhenInactive"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsHiddenWhenInactive(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsHiddenWhenInactive);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.AllowedForRandomEncounters"/>
    /// </summary>
    public TBuilder SetAllowedForRandomEncounters(bool allowedForRandomEncounters = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AllowedForRandomEncounters = allowedForRandomEncounters;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.AllowedForRandomEncounters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAllowedForRandomEncounters(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AllowedForRandomEncounters);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.DisarmAnimation"/>
    /// </summary>
    public TBuilder SetDisarmAnimation(UnitAnimationInteractionType disarmAnimation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisarmAnimation = disarmAnimation;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.DisarmAnimation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisarmAnimation(Action<UnitAnimationInteractionType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisarmAnimation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.m_Actor"/>
    /// </summary>
    ///
    /// <param name="actor">
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
    public TBuilder SetActor(Blueprint<BlueprintUnitReference> actor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actor = actor?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.m_Actor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActor(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actor is null) { return; }
          action.Invoke(bp.m_Actor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.TriggerConditions"/>
    /// </summary>
    public TBuilder SetTriggerConditions(ConditionsBuilder triggerConditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TriggerConditions = triggerConditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.TriggerConditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTriggerConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TriggerConditions is null) { return; }
          action.Invoke(bp.TriggerConditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.DisableConditions"/>
    /// </summary>
    public TBuilder SetDisableConditions(ConditionsBuilder disableConditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableConditions = disableConditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.DisableConditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DisableConditions is null) { return; }
          action.Invoke(bp.DisableConditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.TrapActions"/>
    /// </summary>
    public TBuilder SetTrapActions(ActionsBuilder trapActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrapActions = trapActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.TrapActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrapActions is null) { return; }
          action.Invoke(bp.TrapActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrap.DisableActions"/>
    /// </summary>
    public TBuilder SetDisableActions(ActionsBuilder disableActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableActions = disableActions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrap.DisableActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DisableActions is null) { return; }
          action.Invoke(bp.DisableActions);
        });
    }

    /// <summary>
    /// Adds <see cref="Experience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>00_FindEchoLair</term><description>876fc5d40aa5d8b47ac0138cf0a680ae</description></item>
    /// <item><term>CR7_GhoulHuntmaster_RangerRanged</term><description>e884bd90f8936a743ac534bba620c549</description></item>
    /// <item><term>Ziforian_normal</term><description>7ef2998dbeb7fda43a47ce842f4d142d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="playerGainsNoExp">
    /// <para>
    /// InfoBox: When true, Exp will be used in encounter CR calculation, but player will not gained it
    /// </para>
    /// </param>
    public TBuilder AddExperience(
        IntEvaluator? count = null,
        int? cR = null,
        bool? dummy = null,
        EncounterType? encounter = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? modifier = null,
        bool? playerGainsNoExp = null)
    {
      var component = new Experience();
      Validate(count);
      component.Count = count ?? component.Count;
      component.CR = cR ?? component.CR;
      component.Dummy = dummy ?? component.Dummy;
      component.Encounter = encounter ?? component.Encounter;
      component.Modifier = modifier ?? component.Modifier;
      component.PlayerGainsNoExp = playerGainsNoExp ?? component.PlayerGainsNoExp;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_Actor is null)
      {
        Blueprint.m_Actor = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.TriggerConditions is null)
      {
        Blueprint.TriggerConditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.DisableConditions is null)
      {
        Blueprint.DisableConditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.TrapActions is null)
      {
        Blueprint.TrapActions = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.DisableActions is null)
      {
        Blueprint.DisableActions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
