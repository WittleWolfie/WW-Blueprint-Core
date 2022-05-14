//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellbookConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpellbook
    where TBuilder : BaseSpellbookConfigurator<T, TBuilder>
  {
    protected BaseSpellbookConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AddCustomSpells"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EldritchScionSpellbook</term><description>e2763fbfdb91920458c4686c3e7ed085</description></item>
    /// <item><term>LichSkeletalMagusSpellbookMinor</term><description>c9ff1f4b3b26dcb47ba75b218ccadd23</description></item>
    /// <item><term>MagusSpellbook</term><description>5d8d04e76dff6c5439de99af0d57be63</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spellList">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCustomSpells(
        int? casterLevel = null,
        int? count = null,
        int? maxSpellLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintSpellList, BlueprintSpellListReference>? spellList = null)
    {
      var component = new AddCustomSpells();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      component.Count = count ?? component.Count;
      component.MaxSpellLevel = maxSpellLevel ?? component.MaxSpellLevel;
      component.m_SpellList = spellList?.Reference ?? component.m_SpellList;
      if (component.m_SpellList is null)
      {
        component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IsAlchemistSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistSpellbook</term><description>027d37761f3804042afa96fe3e9086cc</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddIsAlchemistSpellbook()
    {
      return AddComponent(new IsAlchemistSpellbook());
    }

    /// <summary>
    /// Adds <see cref="IsSinMagicSpecialistSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ThassilonianAbjurationSpellbook</term><description>58b15cc36ceda8942a7a29aafa755452</description></item>
    /// <item><term>ThassilonianEvocationSpellbook</term><description>05b105ddee654db4fb1547ba48ffa160</description></item>
    /// <item><term>ThassilonianTransmutationSpellbook</term><description>5785f40e7b1bfc94ea078e7156aa9711</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddIsSinMagicSpecialistSpellbook()
    {
      return AddComponent(new IsSinMagicSpecialistSpellbook());
    }
  }
}
