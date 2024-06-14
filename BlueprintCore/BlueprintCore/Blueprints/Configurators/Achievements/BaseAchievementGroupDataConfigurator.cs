//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Achievements
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AchievementGroupData"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAchievementGroupDataConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : AchievementGroupData
    where TBuilder : BaseAchievementGroupDataConfigurator<T, TBuilder>
  {
    protected BaseAchievementGroupDataConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<AchievementGroupData>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Title = copyFrom.Title;
          bp.Description = copyFrom.Description;
          bp.PS4 = copyFrom.PS4;
          bp.PS5 = copyFrom.PS5;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<AchievementGroupData>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Title = copyFrom.Title;
          bp.Description = copyFrom.Description;
          bp.PS4 = copyFrom.PS4;
          bp.PS5 = copyFrom.PS5;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementGroupData.Title"/>
    /// </summary>
    public TBuilder SetTitle(AchievementLocalizedString title)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(title);
          bp.Title = title;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementGroupData.Title"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTitle(Action<AchievementLocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Title is null) { return; }
          action.Invoke(bp.Title);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementGroupData.Description"/>
    /// </summary>
    public TBuilder SetDescription(AchievementLocalizedString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(description);
          bp.Description = description;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementGroupData.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<AchievementLocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementGroupData.PS4"/>
    /// </summary>
    public TBuilder SetPS4(AchievementGroupData.PlatformSettingsPS4 pS4)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(pS4);
          bp.PS4 = pS4;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementGroupData.PS4"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPS4(Action<AchievementGroupData.PlatformSettingsPS4> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PS4 is null) { return; }
          action.Invoke(bp.PS4);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementGroupData.PS5"/>
    /// </summary>
    public TBuilder SetPS5(AchievementGroupData.PlatformSettingsPS5 pS5)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(pS5);
          bp.PS5 = pS5;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementGroupData.PS5"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPS5(Action<AchievementGroupData.PlatformSettingsPS5> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PS5 is null) { return; }
          action.Invoke(bp.PS5);
        });
    }
  }
}
