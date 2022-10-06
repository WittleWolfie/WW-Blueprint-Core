//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmyLeader"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyLeaderConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmyLeader
    where TBuilder : BaseArmyLeaderConfigurator<T, TBuilder>
  {
    protected BaseArmyLeaderConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmyLeader>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_LeaderName = copyFrom.m_LeaderName;
          bp.m_Portrait = copyFrom.m_Portrait;
          bp.m_StartingLevel = copyFrom.m_StartingLevel;
          bp.m_LeaderProgression = copyFrom.m_LeaderProgression;
          bp.m_Unit = copyFrom.m_Unit;
          bp.m_baseSkills = copyFrom.m_baseSkills;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmyLeader>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_LeaderName = copyFrom.m_LeaderName;
          bp.m_Portrait = copyFrom.m_Portrait;
          bp.m_StartingLevel = copyFrom.m_StartingLevel;
          bp.m_LeaderProgression = copyFrom.m_LeaderProgression;
          bp.m_Unit = copyFrom.m_Unit;
          bp.m_baseSkills = copyFrom.m_baseSkills;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyLeader.m_LeaderName"/>
    /// </summary>
    ///
    /// <param name="leaderName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLeaderName(LocalString leaderName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LeaderName = leaderName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_LeaderName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeaderName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LeaderName is null) { return; }
          action.Invoke(bp.m_LeaderName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyLeader.m_Portrait"/>
    /// </summary>
    ///
    /// <param name="portrait">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPortrait(Blueprint<BlueprintPortraitReference> portrait)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Portrait = portrait?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_Portrait"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPortrait(Action<BlueprintPortraitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Portrait is null) { return; }
          action.Invoke(bp.m_Portrait);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyLeader.m_StartingLevel"/>
    /// </summary>
    ///
    /// <param name="startingLevel">
    /// <para>
    /// Tooltip: 1 - это Element0 в LeaderProgression От этого числа зависят стартовые атрибуты и сколько опыта нужно для лвлапа
    /// </para>
    /// </param>
    public TBuilder SetStartingLevel(int startingLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingLevel = startingLevel;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyLeader.m_LeaderProgression"/>
    /// </summary>
    ///
    /// <param name="leaderProgression">
    /// <para>
    /// Blueprint of type BlueprintLeaderProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLeaderProgression(Blueprint<BlueprintLeaderProgression.Reference> leaderProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LeaderProgression = leaderProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_LeaderProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeaderProgression(Action<BlueprintLeaderProgression.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LeaderProgression is null) { return; }
          action.Invoke(bp.m_LeaderProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyLeader.m_Unit"/>
    /// </summary>
    ///
    /// <param name="unit">
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
    public TBuilder SetUnit(Blueprint<BlueprintUnitReference> unit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Unit = unit?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_Unit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnit(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Unit is null) { return; }
          action.Invoke(bp.m_Unit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyLeader.m_baseSkills"/>
    /// </summary>
    ///
    /// <param name="baseSkills">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBaseSkills(params Blueprint<BlueprintLeaderSkillReference>[] baseSkills)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_baseSkills = baseSkills.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArmyLeader.m_baseSkills"/>
    /// </summary>
    ///
    /// <param name="baseSkills">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToBaseSkills(params Blueprint<BlueprintLeaderSkillReference>[] baseSkills)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_baseSkills = bp.m_baseSkills ?? new BlueprintLeaderSkillReference[0];
          bp.m_baseSkills = CommonTool.Append(bp.m_baseSkills, baseSkills.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmyLeader.m_baseSkills"/>
    /// </summary>
    ///
    /// <param name="baseSkills">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBaseSkills(params Blueprint<BlueprintLeaderSkillReference>[] baseSkills)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_baseSkills is null) { return; }
          bp.m_baseSkills = bp.m_baseSkills.Where(val => !baseSkills.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmyLeader.m_baseSkills"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBaseSkills(Func<BlueprintLeaderSkillReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_baseSkills is null) { return; }
          bp.m_baseSkills = bp.m_baseSkills.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmyLeader.m_baseSkills"/>
    /// </summary>
    public TBuilder ClearBaseSkills()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_baseSkills = new BlueprintLeaderSkillReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyLeader.m_baseSkills"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBaseSkills(Action<BlueprintLeaderSkillReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_baseSkills is null) { return; }
          bp.m_baseSkills.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_LeaderName is null)
      {
        Blueprint.m_LeaderName = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Portrait is null)
      {
        Blueprint.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(null);
      }
      if (Blueprint.m_LeaderProgression is null)
      {
        Blueprint.m_LeaderProgression = BlueprintTool.GetRef<BlueprintLeaderProgression.Reference>(null);
      }
      if (Blueprint.m_Unit is null)
      {
        Blueprint.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.m_baseSkills is null)
      {
        Blueprint.m_baseSkills = new BlueprintLeaderSkillReference[0];
      }
    }
  }
}
