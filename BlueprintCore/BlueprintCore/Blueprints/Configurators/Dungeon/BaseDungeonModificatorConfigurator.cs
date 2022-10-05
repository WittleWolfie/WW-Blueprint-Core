//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Enums;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonModificator"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonModificatorConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonModificator
    where TBuilder : BaseDungeonModificatorConfigurator<T, TBuilder>
  {
    protected BaseDungeonModificatorConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonModificator>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ImageLink = copyFrom.m_ImageLink;
          bp.Name = copyFrom.Name;
          bp.Description = copyFrom.Description;
          bp.m_Weight = copyFrom.m_Weight;
          bp.m_Tiers = copyFrom.m_Tiers;
          bp.OnActivate = copyFrom.OnActivate;
          bp.OnDeactivate = copyFrom.OnDeactivate;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.m_ImageLink"/>
    /// </summary>
    ///
    /// <param name="imageLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetImageLink(AssetLink<SpriteLink> imageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageLink = imageLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonModificator.m_ImageLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageLink is null) { return; }
          action.Invoke(bp.m_ImageLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonModificator.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.Description"/>
    /// </summary>
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonModificator.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.m_Weight"/>
    /// </summary>
    public TBuilder SetWeight(float weight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Weight = weight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = tiers.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonModificator.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = bp.m_Tiers ?? new BlueprintDungeonTierReference[0];
          bp.m_Tiers = CommonTool.Append(bp.m_Tiers, tiers.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonModificator.m_Tiers"/>
    /// </summary>
    ///
    /// <param name="tiers">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTiers(params Blueprint<BlueprintDungeonTierReference>[] tiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(val => !tiers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonModificator.m_Tiers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTiers(Func<BlueprintDungeonTierReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers = bp.m_Tiers.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonModificator.m_Tiers"/>
    /// </summary>
    public TBuilder ClearTiers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tiers = new BlueprintDungeonTierReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonModificator.m_Tiers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTiers(Action<BlueprintDungeonTierReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tiers is null) { return; }
          bp.m_Tiers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.OnActivate"/>
    /// </summary>
    public TBuilder SetOnActivate(ActionsBuilder onActivate)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnActivate = onActivate?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonModificator.OnActivate"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnActivate(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnActivate is null) { return; }
          action.Invoke(bp.OnActivate);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonModificator.OnDeactivate"/>
    /// </summary>
    public TBuilder SetOnDeactivate(ActionsBuilder onDeactivate)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnDeactivate = onDeactivate?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonModificator.OnDeactivate"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnDeactivate(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnDeactivate is null) { return; }
          action.Invoke(bp.OnDeactivate);
        });
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorArmyOverride"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorBesmarites</term><description>14edcd6f662c453183aa9c1295306a2b</description></item>
    /// <item><term>DungeonModificatorMindControl</term><description>d65481ede93c4826b98b78cb585ea0f7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="army">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDungeonModificatorArmyOverride(
        Blueprint<BlueprintDungeonArmyReference>? army = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DungeonModificatorArmyOverride();
      component.m_Army = army?.Reference ?? component.m_Army;
      if (component.m_Army is null)
      {
        component.m_Army = BlueprintTool.GetRef<BlueprintDungeonArmyReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorArcane</term><description>4328c8b0356b4e21b13400fbf14412a2</description></item>
    /// <item><term>DungeonModificatorHot</term><description>488374c585394717a689354c714b1fa9</description></item>
    /// <item><term>DungeonModificatorWildMagic</term><description>9106be5b6d5d4423bbd538be3dfe6464</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDungeonModificatorBuff(
        bool? applyOnlyOnce = null,
        Blueprint<BlueprintBuffReference>? buff = null,
        bool? removeOnLeave = null,
        DungeonModificatorTarget? target = null)
    {
      var component = new DungeonModificatorBuff();
      component.ApplyOnlyOnce = applyOnlyOnce ?? component.ApplyOnlyOnce;
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.RemoveOnLeave = removeOnLeave ?? component.RemoveOnLeave;
      component.Target = target ?? component.Target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorArcane</term><description>4328c8b0356b4e21b13400fbf14412a2</description></item>
    /// <item><term>DungeonModificatorIllnessAndCannibalism</term><description>a507161dd0724e5cb6fb16caa0003556</description></item>
    /// <item><term>DungeonModificatorUncotrollableRage</term><description>da74c014108547599047f6dca1937df4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDungeonModificatorFeature(
        Blueprint<BlueprintFeatureReference>? feature = null,
        DungeonModificatorTarget? target = null)
    {
      var component = new DungeonModificatorFeature();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Target = target ?? component.Target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorMindArmy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorMindControl</term><description>d65481ede93c4826b98b78cb585ea0f7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="army">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="buffOnSpawn">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="mindControlArmy">
    /// <para>
    /// Blueprint of type BlueprintDungeonArmy. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDungeonModificatorMindArmy(
        Blueprint<BlueprintDungeonArmyReference>? army = null,
        Blueprint<BlueprintBuffReference>? buffOnSpawn = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintDungeonArmyReference>? mindControlArmy = null,
        int? spawnProbability = null)
    {
      var component = new DungeonModificatorMindArmy();
      component.m_Army = army?.Reference ?? component.m_Army;
      if (component.m_Army is null)
      {
        component.m_Army = BlueprintTool.GetRef<BlueprintDungeonArmyReference>(null);
      }
      component.BuffOnSpawn = buffOnSpawn?.Reference ?? component.BuffOnSpawn;
      if (component.BuffOnSpawn is null)
      {
        component.BuffOnSpawn = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.MindControlArmy = mindControlArmy?.Reference ?? component.MindControlArmy;
      if (component.MindControlArmy is null)
      {
        component.MindControlArmy = BlueprintTool.GetRef<BlueprintDungeonArmyReference>(null);
      }
      component.SpawnProbability = spawnProbability ?? component.SpawnProbability;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorSpawnAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorElementalLocust</term><description>44ff5ead17a0419ba15b5ad2b01f200f</description></item>
    /// <item><term>DungeonModificatorIllnessAndCannibalism</term><description>a507161dd0724e5cb6fb16caa0003556</description></item>
    /// <item><term>DungeonModificatorNegativeEnergy</term><description>461523b537f04734805802d4c91b5e1c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="areaEffects">
    /// <para>
    /// Blueprint of type BlueprintAbilityAreaEffect. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDungeonModificatorSpawnAreaEffect(
        List<Blueprint<BlueprintAbilityAreaEffectReference>>? areaEffects = null,
        IntegerWeighted[]? count = null,
        bool? overrideCount = null,
        bool? spawnOnObjects = null)
    {
      var component = new DungeonModificatorSpawnAreaEffect();
      component.m_AreaEffects = areaEffects?.Select(bp => bp.Reference)?.ToArray() ?? component.m_AreaEffects;
      if (component.m_AreaEffects is null)
      {
        component.m_AreaEffects = new BlueprintAbilityAreaEffectReference[0];
      }
      Validate(count);
      component.Count = count ?? component.Count;
      if (component.Count is null)
      {
        component.Count = new IntegerWeighted[0];
      }
      component.OverrideCount = overrideCount ?? component.OverrideCount;
      component.SpawnOnObjects = spawnOnObjects ?? component.SpawnOnObjects;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorSpawnObjects"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorDevilRage</term><description>15a1186ed09c4ea9848d125d61403428</description></item>
    /// <item><term>DungeonModificatorWildMagic</term><description>9106be5b6d5d4423bbd538be3dfe6464</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objects">
    /// <para>
    /// Blueprint of type BlueprintDynamicMapObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDungeonModificatorSpawnObjects(
        IntegerWeighted[]? count = null,
        List<Blueprint<BlueprintDynamicMapObjectReference>>? objects = null,
        bool? overrideCount = null)
    {
      var component = new DungeonModificatorSpawnObjects();
      Validate(count);
      component.Count = count ?? component.Count;
      if (component.Count is null)
      {
        component.Count = new IntegerWeighted[0];
      }
      component.m_Objects = objects?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Objects;
      if (component.m_Objects is null)
      {
        component.m_Objects = new BlueprintDynamicMapObjectReference[0];
      }
      component.OverrideCount = overrideCount ?? component.OverrideCount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonModificatorSpawnUnits"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonModificatorElemental_Air</term><description>bb64ce9b7c4f4d608418864dc1a6c007</description></item>
    /// <item><term>DungeonModificatorElemental_Fire</term><description>01a70753a5f34e198b7b3bd97e8c9b0a</description></item>
    /// <item><term>DungeonModificatorElemental_Water</term><description>62768248d0b8453f8f83915c3f76fee6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="maxStage">
    /// <para>
    /// Tooltip: This army should appear not after this stage.
    /// </para>
    /// </param>
    /// <param name="minStage">
    /// <para>
    /// Tooltip: This army should appear not before this stage.
    /// </para>
    /// </param>
    /// <param name="tiers">
    /// <para>
    /// Tooltip: This army should appear only in these tiers.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="units">
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
    public TBuilder AddDungeonModificatorSpawnUnits(
        IntegerWeighted[]? count = null,
        bool? limitMaxStage = null,
        bool? limitMinStage = null,
        bool? limitTiers = null,
        int? maxStage = null,
        int? minStage = null,
        bool? overrideCount = null,
        List<Blueprint<BlueprintDungeonTierReference>>? tiers = null,
        List<Blueprint<BlueprintUnitReference>>? units = null)
    {
      var component = new DungeonModificatorSpawnUnits();
      Validate(count);
      component.Count = count ?? component.Count;
      if (component.Count is null)
      {
        component.Count = new IntegerWeighted[0];
      }
      component.LimitMaxStage = limitMaxStage ?? component.LimitMaxStage;
      component.LimitMinStage = limitMinStage ?? component.LimitMinStage;
      component.LimitTiers = limitTiers ?? component.LimitTiers;
      component.MaxStage = maxStage ?? component.MaxStage;
      component.MinStage = minStage ?? component.MinStage;
      component.OverrideCount = overrideCount ?? component.OverrideCount;
      component.m_Tiers = tiers?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Tiers;
      if (component.m_Tiers is null)
      {
        component.m_Tiers = new BlueprintDungeonTierReference[0];
      }
      component.m_Units = units?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Units;
      if (component.m_Units is null)
      {
        component.m_Units = new BlueprintUnitReference[0];
      }
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Tiers is null)
      {
        Blueprint.m_Tiers = new BlueprintDungeonTierReference[0];
      }
      if (Blueprint.OnActivate is null)
      {
        Blueprint.OnActivate = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.OnDeactivate is null)
      {
        Blueprint.OnDeactivate = Utils.Constants.Empty.Actions;
      }
    }
  }
}
