//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintLoot
    where TBuilder : BaseLootConfigurator<T, TBuilder>
  {
    protected BaseLootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Type = copyFrom.Type;
          bp.IsSuperTrash = copyFrom.IsSuperTrash;
          bp.Identify = copyFrom.Identify;
          bp.Setting = copyFrom.Setting;
          bp.m_Area = copyFrom.m_Area;
          bp.ContainerName = copyFrom.ContainerName;
          bp.Items = copyFrom.Items;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Type = copyFrom.Type;
          bp.IsSuperTrash = copyFrom.IsSuperTrash;
          bp.Identify = copyFrom.Identify;
          bp.Setting = copyFrom.Setting;
          bp.m_Area = copyFrom.m_Area;
          bp.ContainerName = copyFrom.ContainerName;
          bp.Items = copyFrom.Items;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.Type"/>
    /// </summary>
    public TBuilder SetType(LootType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.IsSuperTrash"/>
    /// </summary>
    public TBuilder SetIsSuperTrash(bool isSuperTrash = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsSuperTrash = isSuperTrash;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.Identify"/>
    /// </summary>
    public TBuilder SetIdentify(bool identify = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Identify = identify;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.Setting"/>
    /// </summary>
    public TBuilder SetSetting(LootSetting setting)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Setting = setting;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.m_Area"/>
    /// </summary>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArea(Blueprint<BlueprintAreaReference> area)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Area = area?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoot.m_Area"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArea(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Area is null) { return; }
          action.Invoke(bp.m_Area);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.ContainerName"/>
    /// </summary>
    public TBuilder SetContainerName(string containerName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ContainerName = containerName;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoot.ContainerName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyContainerName(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ContainerName is null) { return; }
          action.Invoke(bp.ContainerName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLoot.Items"/>
    /// </summary>
    public TBuilder SetItems(params LootEntry[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(items);
          bp.Items = items;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLoot.Items"/>
    /// </summary>
    public TBuilder AddToItems(params LootEntry[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Items = bp.Items ?? new LootEntry[0];
          bp.Items = CommonTool.Append(bp.Items, items);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoot.Items"/>
    /// </summary>
    public TBuilder RemoveFromItems(params LootEntry[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Items is null) { return; }
          bp.Items = bp.Items.Where(val => !items.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLoot.Items"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromItems(Func<LootEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Items is null) { return; }
          bp.Items = bp.Items.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLoot.Items"/>
    /// </summary>
    public TBuilder ClearItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Items = new LootEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLoot.Items"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyItems(Action<LootEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Items is null) { return; }
          bp.Items.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Area is null)
      {
        Blueprint.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      if (Blueprint.Items is null)
      {
        Blueprint.Items = new LootEntry[0];
      }
    }
  }
}
