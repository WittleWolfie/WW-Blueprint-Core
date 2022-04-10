using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.Localization;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDlc"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class DlcConfigurator : BaseBlueprintConfigurator<BlueprintDlc, DlcConfigurator>
  {
    private DlcConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DlcConfigurator For(string name)
    {
      return new DlcConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DlcConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDlc>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlc.Description"/> (Auto Generated)
    /// </summary>
    
    public DlcConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);

      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlc.RewardReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rewardReferences"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    
    public DlcConfigurator SetRewardReferences(string[]? rewardReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RewardReferences = rewardReferences.Select(name => BlueprintTool.GetRef<BlueprintDlcRewardReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlc.RewardReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rewardReferences"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    
    public DlcConfigurator AddToRewardReferences(params string[] rewardReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RewardReferences = CommonTool.Append(bp.RewardReferences, rewardReferences.Select(name => BlueprintTool.GetRef<BlueprintDlcRewardReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlc.RewardReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rewardReferences"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    
    public DlcConfigurator RemoveFromRewardReferences(params string[] rewardReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = rewardReferences.Select(name => BlueprintTool.GetRef<BlueprintDlcRewardReference>(name));
            bp.RewardReferences =
                bp.RewardReferences
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="DlcStoreCheat"/> (Auto Generated)
    /// </summary>
    
    
    public DlcConfigurator AddDlcStoreCheat(
        bool isAvailableInEditor = default,
        bool isAvailableInDevBuild = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreCheat();
      component.m_IsAvailableInEditor = isAvailableInEditor;
      component.m_IsAvailableInDevBuild = isAvailableInDevBuild;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreEpic"/> (Auto Generated)
    /// </summary>
    
    
    public DlcConfigurator AddDlcStoreEpic(
        string epicId,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreEpic();
      component.m_EpicId = epicId;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreGog"/> (Auto Generated)
    /// </summary>
    
    
    public DlcConfigurator AddDlcStoreGog(
        ulong gogId = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreGog();
      component.m_GogId = gogId;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreSteam"/> (Auto Generated)
    /// </summary>
    
    
    public DlcConfigurator AddDlcStoreSteam(
        uint steamId = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreSteam();
      component.m_SteamId = steamId;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
