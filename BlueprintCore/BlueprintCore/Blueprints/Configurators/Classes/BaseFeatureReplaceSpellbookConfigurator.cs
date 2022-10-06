//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureReplaceSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFeatureReplaceSpellbookConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintFeatureReplaceSpellbook
    where TBuilder : BaseFeatureReplaceSpellbookConfigurator<T, TBuilder>
  {
    protected BaseFeatureReplaceSpellbookConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFeatureReplaceSpellbook>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Spellbook = copyFrom.m_Spellbook;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFeatureReplaceSpellbook>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Spellbook = copyFrom.m_Spellbook;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureReplaceSpellbook.m_Spellbook"/>
    /// </summary>
    ///
    /// <param name="spellbook">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSpellbook(Blueprint<BlueprintSpellbookReference> spellbook)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Spellbook = spellbook?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureReplaceSpellbook.m_Spellbook"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellbook(Action<BlueprintSpellbookReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Spellbook is null) { return; }
          action.Invoke(bp.m_Spellbook);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Spellbook is null)
      {
        Blueprint.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
    }
  }
}
