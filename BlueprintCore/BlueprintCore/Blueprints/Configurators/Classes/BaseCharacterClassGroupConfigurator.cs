//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCharacterClassGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCharacterClassGroupConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCharacterClassGroup
    where TBuilder : BaseCharacterClassGroupConfigurator<T, TBuilder>
  {
    protected BaseCharacterClassGroupConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/>
    /// </summary>
    ///
    /// <param name="characterClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCharacterClasses(params Blueprint<BlueprintCharacterClassReference>[] characterClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CharacterClasses = characterClasses.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/>
    /// </summary>
    ///
    /// <param name="characterClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCharacterClasses(params Blueprint<BlueprintCharacterClassReference>[] characterClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CharacterClasses = bp.m_CharacterClasses ?? new BlueprintCharacterClassReference[0];
          bp.m_CharacterClasses = CommonTool.Append(bp.m_CharacterClasses, characterClasses.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/>
    /// </summary>
    ///
    /// <param name="characterClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCharacterClasses(params Blueprint<BlueprintCharacterClassReference>[] characterClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CharacterClasses is null) { return; }
          bp.m_CharacterClasses = bp.m_CharacterClasses.Where(val => !characterClasses.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCharacterClasses(Func<BlueprintCharacterClassReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CharacterClasses is null) { return; }
          bp.m_CharacterClasses = bp.m_CharacterClasses.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/>
    /// </summary>
    public TBuilder ClearCharacterClasses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CharacterClasses = new BlueprintCharacterClassReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCharacterClasses(Action<BlueprintCharacterClassReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CharacterClasses is null) { return; }
          bp.m_CharacterClasses.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_CharacterClasses is null)
      {
        Blueprint.m_CharacterClasses = new BlueprintCharacterClassReference[0];
      }
    }
  }
}
