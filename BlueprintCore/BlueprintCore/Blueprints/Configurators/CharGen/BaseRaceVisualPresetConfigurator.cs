//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Visual.CharacterSystem;
using System;

namespace BlueprintCore.Blueprints.Configurators.CharGen
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRaceVisualPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRaceVisualPresetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRaceVisualPreset
    where TBuilder : BaseRaceVisualPresetConfigurator<T, TBuilder>
  {
    protected BaseRaceVisualPresetConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintRaceVisualPreset>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.RaceId = copyFrom.RaceId;
          bp.MaleSkeleton = copyFrom.MaleSkeleton;
          bp.FemaleSkeleton = copyFrom.FemaleSkeleton;
          bp.m_Skin = copyFrom.m_Skin;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRaceVisualPreset.RaceId"/>
    /// </summary>
    public TBuilder SetRaceId(Race raceId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RaceId = raceId;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRaceVisualPreset.MaleSkeleton"/>
    /// </summary>
    public TBuilder SetMaleSkeleton(Skeleton maleSkeleton)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(maleSkeleton);
          bp.MaleSkeleton = maleSkeleton;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRaceVisualPreset.MaleSkeleton"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaleSkeleton(Action<Skeleton> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleSkeleton is null) { return; }
          action.Invoke(bp.MaleSkeleton);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRaceVisualPreset.FemaleSkeleton"/>
    /// </summary>
    public TBuilder SetFemaleSkeleton(Skeleton femaleSkeleton)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(femaleSkeleton);
          bp.FemaleSkeleton = femaleSkeleton;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRaceVisualPreset.FemaleSkeleton"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFemaleSkeleton(Action<Skeleton> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleSkeleton is null) { return; }
          action.Invoke(bp.FemaleSkeleton);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRaceVisualPreset.m_Skin"/>
    /// </summary>
    ///
    /// <param name="skin">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSkin(Blueprint<KingmakerEquipmentEntityReference> skin)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Skin = skin?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRaceVisualPreset.m_Skin"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySkin(Action<KingmakerEquipmentEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Skin is null) { return; }
          action.Invoke(bp.m_Skin);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Skin is null)
      {
        Blueprint.m_Skin = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(null);
      }
    }
  }
}
