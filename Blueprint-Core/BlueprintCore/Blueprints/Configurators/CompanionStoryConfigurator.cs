using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintCompanionStory"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCompanionStory))]
  public class CompanionStoryConfigurator : BaseBlueprintConfigurator<BlueprintCompanionStory, CompanionStoryConfigurator>
  {
     private CompanionStoryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CompanionStoryConfigurator For(string name)
    {
      return new CompanionStoryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CompanionStoryConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCompanionStory>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CompanionStoryConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCompanionStory>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.m_Companion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public CompanionStoryConfigurator SetCompanion(string value)
    {
      return OnConfigureInternal(bp => bp.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetTitle(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Title = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Image"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetImage(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Image = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Gender"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetGender(Gender value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Gender = value);
    }
  }
}
