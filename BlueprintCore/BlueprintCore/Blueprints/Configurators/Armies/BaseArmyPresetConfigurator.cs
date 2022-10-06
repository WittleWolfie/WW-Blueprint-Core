//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmyPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyPresetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmyPreset
    where TBuilder : BaseArmyPresetConfigurator<T, TBuilder>
  {
    protected BaseArmyPresetConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmyPreset>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Morale = copyFrom.Morale;
          bp.Squads = copyFrom.Squads;
          bp.m_Leader = copyFrom.m_Leader;
          bp.m_ArmyType = copyFrom.m_ArmyType;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmyPreset>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Morale = copyFrom.Morale;
          bp.Squads = copyFrom.Squads;
          bp.m_Leader = copyFrom.m_Leader;
          bp.m_ArmyType = copyFrom.m_ArmyType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyPreset.Morale"/>
    /// </summary>
    ///
    /// <param name="morale">
    /// <para>
    /// InfoBox: See morale limits in MoraleRoot
    /// </para>
    /// </param>
    public TBuilder SetMorale(int morale)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Morale = morale;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyPreset.Squads"/>
    /// </summary>
    public TBuilder SetSquads(params BlueprintArmyPreset.UnitAndCount[] squads)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(squads);
          bp.Squads = squads;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArmyPreset.Squads"/>
    /// </summary>
    public TBuilder AddToSquads(params BlueprintArmyPreset.UnitAndCount[] squads)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Squads = bp.Squads ?? new BlueprintArmyPreset.UnitAndCount[0];
          bp.Squads = CommonTool.Append(bp.Squads, squads);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmyPreset.Squads"/>
    /// </summary>
    public TBuilder RemoveFromSquads(params BlueprintArmyPreset.UnitAndCount[] squads)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Squads is null) { return; }
          bp.Squads = bp.Squads.Where(val => !squads.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmyPreset.Squads"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSquads(Func<BlueprintArmyPreset.UnitAndCount, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Squads is null) { return; }
          bp.Squads = bp.Squads.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmyPreset.Squads"/>
    /// </summary>
    public TBuilder ClearSquads()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Squads = new BlueprintArmyPreset.UnitAndCount[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPreset.Squads"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySquads(Action<BlueprintArmyPreset.UnitAndCount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Squads is null) { return; }
          bp.Squads.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyPreset.m_Leader"/>
    /// </summary>
    ///
    /// <param name="leader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLeader(Blueprint<BlueprintArmyLeaderReference> leader)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leader = leader?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPreset.m_Leader"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeader(Action<BlueprintArmyLeaderReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leader is null) { return; }
          action.Invoke(bp.m_Leader);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyPreset.m_ArmyType"/>
    /// </summary>
    ///
    /// <param name="armyType">
    /// <para>
    /// InfoBox: Determines which pawn army will have. Note: moving armies will have Travelling type automatically
    /// </para>
    /// </param>
    public TBuilder SetArmyType(ArmyType armyType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyType = armyType;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Squads is null)
      {
        Blueprint.Squads = new BlueprintArmyPreset.UnitAndCount[0];
      }
      if (Blueprint.m_Leader is null)
      {
        Blueprint.m_Leader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(null);
      }
    }
  }
}
