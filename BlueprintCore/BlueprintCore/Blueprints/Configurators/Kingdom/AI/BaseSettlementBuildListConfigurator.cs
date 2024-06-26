//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Kingdom.AI;
using Kingmaker.UI.Settlement;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SettlementBuildList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettlementBuildListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : SettlementBuildList
    where TBuilder : BaseSettlementBuildListConfigurator<T, TBuilder>
  {
    protected BaseSettlementBuildListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SettlementBuildList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_BuildArea = copyFrom.m_BuildArea;
          bp.SlotSetupPrefab = copyFrom.SlotSetupPrefab;
          bp.List = copyFrom.List;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SettlementBuildList>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_BuildArea = copyFrom.m_BuildArea;
          bp.SlotSetupPrefab = copyFrom.SlotSetupPrefab;
          bp.List = copyFrom.List;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettlementBuildList.m_BuildArea"/>
    /// </summary>
    ///
    /// <param name="buildArea">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBuildArea(Blueprint<BlueprintAreaEnterPointReference> buildArea)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BuildArea = buildArea?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="SettlementBuildList.m_BuildArea"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBuildArea(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BuildArea is null) { return; }
          action.Invoke(bp.m_BuildArea);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettlementBuildList.SlotSetupPrefab"/>
    /// </summary>
    public TBuilder SetSlotSetupPrefab(SettlementsBuildSlots slotSetupPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(slotSetupPrefab);
          bp.SlotSetupPrefab = slotSetupPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="SettlementBuildList.SlotSetupPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySlotSetupPrefab(Action<SettlementsBuildSlots> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SlotSetupPrefab is null) { return; }
          action.Invoke(bp.SlotSetupPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SettlementBuildList.List"/>
    /// </summary>
    public TBuilder SetList(params SettlementBuildList.Entry[] list)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(list);
          bp.List = list.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="SettlementBuildList.List"/>
    /// </summary>
    public TBuilder AddToList(params SettlementBuildList.Entry[] list)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.List = bp.List ?? new();
          bp.List.AddRange(list);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="SettlementBuildList.List"/>
    /// </summary>
    public TBuilder RemoveFromList(params SettlementBuildList.Entry[] list)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.List is null) { return; }
          bp.List = bp.List.Where(val => !list.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="SettlementBuildList.List"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromList(Func<SettlementBuildList.Entry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.List is null) { return; }
          bp.List = bp.List.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="SettlementBuildList.List"/>
    /// </summary>
    public TBuilder ClearList()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.List = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="SettlementBuildList.List"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyList(Action<SettlementBuildList.Entry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.List is null) { return; }
          bp.List.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_BuildArea is null)
      {
        Blueprint.m_BuildArea = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.List is null)
      {
        Blueprint.List = new();
      }
    }
  }
}
