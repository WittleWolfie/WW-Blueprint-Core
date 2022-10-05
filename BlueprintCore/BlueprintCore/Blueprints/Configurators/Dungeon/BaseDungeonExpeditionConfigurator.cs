//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonExpedition"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonExpeditionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonExpedition
    where TBuilder : BaseDungeonExpeditionConfigurator<T, TBuilder>
  {
    protected BaseDungeonExpeditionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonExpedition>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Name = copyFrom.Name;
          bp.Description = copyFrom.Description;
          bp.m_FinalIsland = copyFrom.m_FinalIsland;
          bp.m_ModificatorProbability = copyFrom.m_ModificatorProbability;
          bp.m_Rewards = copyFrom.m_Rewards;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonExpedition.Name"/>
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
    /// Modifies <see cref="BlueprintDungeonExpedition.Name"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonExpedition.Description"/>
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
    /// Modifies <see cref="BlueprintDungeonExpedition.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonExpedition.m_FinalIsland"/>
    /// </summary>
    ///
    /// <param name="finalIsland">
    /// <para>
    /// Tooltip: The last unique island with a boss fight.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIsland. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFinalIsland(Blueprint<BlueprintDungeonIslandReference> finalIsland)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FinalIsland = finalIsland?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonExpedition.m_FinalIsland"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFinalIsland(Action<BlueprintDungeonIslandReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FinalIsland is null) { return; }
          action.Invoke(bp.m_FinalIsland);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonExpedition.m_ModificatorProbability"/>
    /// </summary>
    public TBuilder SetModificatorProbability(float modificatorProbability)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ModificatorProbability = modificatorProbability;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonExpedition.m_Rewards"/>
    /// </summary>
    ///
    /// <param name="rewards">
    /// <para>
    /// Tooltip: Possible rewards for completing islands in the expedition, random one from the list per island.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIslandReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRewards(params Blueprint<BlueprintDungeonIslandRewardReference>[] rewards)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Rewards = rewards.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonExpedition.m_Rewards"/>
    /// </summary>
    ///
    /// <param name="rewards">
    /// <para>
    /// Tooltip: Possible rewards for completing islands in the expedition, random one from the list per island.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIslandReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToRewards(params Blueprint<BlueprintDungeonIslandRewardReference>[] rewards)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Rewards = bp.m_Rewards ?? new BlueprintDungeonIslandRewardReference[0];
          bp.m_Rewards = CommonTool.Append(bp.m_Rewards, rewards.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonExpedition.m_Rewards"/>
    /// </summary>
    ///
    /// <param name="rewards">
    /// <para>
    /// Tooltip: Possible rewards for completing islands in the expedition, random one from the list per island.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintDungeonIslandReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromRewards(params Blueprint<BlueprintDungeonIslandRewardReference>[] rewards)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Rewards is null) { return; }
          bp.m_Rewards = bp.m_Rewards.Where(val => !rewards.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonExpedition.m_Rewards"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRewards(Func<BlueprintDungeonIslandRewardReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Rewards is null) { return; }
          bp.m_Rewards = bp.m_Rewards.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonExpedition.m_Rewards"/>
    /// </summary>
    public TBuilder ClearRewards()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Rewards = new BlueprintDungeonIslandRewardReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonExpedition.m_Rewards"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRewards(Action<BlueprintDungeonIslandRewardReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Rewards is null) { return; }
          bp.m_Rewards.ForEach(action);
        });
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
      if (Blueprint.m_FinalIsland is null)
      {
        Blueprint.m_FinalIsland = BlueprintTool.GetRef<BlueprintDungeonIslandReference>(null);
      }
      if (Blueprint.m_Rewards is null)
      {
        Blueprint.m_Rewards = new BlueprintDungeonIslandRewardReference[0];
      }
    }
  }
}
