using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUIInteractionTypeSprites"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUIInteractionTypeSprites))]
  public class UIInteractionTypeSpritesConfigurator : BaseBlueprintConfigurator<BlueprintUIInteractionTypeSprites, UIInteractionTypeSpritesConfigurator>
  {
    private UIInteractionTypeSpritesConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UIInteractionTypeSpritesConfigurator For(string name)
    {
      return new UIInteractionTypeSpritesConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UIInteractionTypeSpritesConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUIInteractionTypeSprites>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUIInteractionTypeSprites.Main"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UIInteractionTypeSpritesConfigurator SetMain(Sprite main)
    {
      ValidateParam(main);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Main = main;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUIInteractionTypeSprites.Active"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UIInteractionTypeSpritesConfigurator SetActive(Sprite active)
    {
      ValidateParam(active);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Active = active;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUIInteractionTypeSprites.Hover"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UIInteractionTypeSpritesConfigurator SetHover(Sprite hover)
    {
      ValidateParam(hover);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Hover = hover;
          });
    }
  }
}
