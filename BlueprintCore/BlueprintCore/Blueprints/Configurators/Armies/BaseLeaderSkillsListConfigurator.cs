//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLeaderSkillsList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLeaderSkillsListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintLeaderSkillsList
    where TBuilder : BaseLeaderSkillsListConfigurator<T, TBuilder>
  {
    protected BaseLeaderSkillsListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLeaderSkillsList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Skills = copyFrom.m_Skills;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkillsList.m_Skills"/>
    /// </summary>
    ///
    /// <param name="skills">
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
    public TBuilder SetSkills(params Blueprint<BlueprintLeaderSkillReference>[] skills)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Skills = skills.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLeaderSkillsList.m_Skills"/>
    /// </summary>
    ///
    /// <param name="skills">
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
    public TBuilder AddToSkills(params Blueprint<BlueprintLeaderSkillReference>[] skills)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Skills = bp.m_Skills ?? new BlueprintLeaderSkillReference[0];
          bp.m_Skills = CommonTool.Append(bp.m_Skills, skills.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLeaderSkillsList.m_Skills"/>
    /// </summary>
    ///
    /// <param name="skills">
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
    public TBuilder RemoveFromSkills(params Blueprint<BlueprintLeaderSkillReference>[] skills)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Skills is null) { return; }
          bp.m_Skills = bp.m_Skills.Where(val => !skills.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLeaderSkillsList.m_Skills"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSkills(Func<BlueprintLeaderSkillReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Skills is null) { return; }
          bp.m_Skills = bp.m_Skills.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLeaderSkillsList.m_Skills"/>
    /// </summary>
    public TBuilder ClearSkills()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Skills = new BlueprintLeaderSkillReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkillsList.m_Skills"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySkills(Action<BlueprintLeaderSkillReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Skills is null) { return; }
          bp.m_Skills.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Skills is null)
      {
        Blueprint.m_Skills = new BlueprintLeaderSkillReference[0];
      }
    }
  }
}
