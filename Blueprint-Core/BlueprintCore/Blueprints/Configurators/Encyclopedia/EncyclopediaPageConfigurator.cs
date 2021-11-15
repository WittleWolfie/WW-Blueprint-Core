using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaPage"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaPage))]
  public abstract class BaseEncyclopediaPageConfigurator<T, TBuilder>
      : BaseEncyclopediaNodeConfigurator<T, TBuilder>
      where T : BlueprintEncyclopediaPage
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseEncyclopediaPageConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaPage.m_ParentAsset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintEncyclopediaNode"/></param>
    [Generated]
    public TBuilder SetParentAsset(string value)
    {
      return OnConfigureInternal(bp => bp.m_ParentAsset = BlueprintTool.GetRef<BlueprintEncyclopediaNodeReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToBlocks(params BlueprintEncyclopediaBlock[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Blocks.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromBlocks(params BlueprintEncyclopediaBlock[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Blocks = bp.Blocks.Where(item => !values.Contains(item)).ToList());
    }
  }

  /// <summary>Configurator for <see cref="BlueprintEncyclopediaPage"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaPage))]
  public class EncyclopediaPageConfigurator : BaseEncyclopediaNodeConfigurator<BlueprintEncyclopediaPage, EncyclopediaPageConfigurator>
  {
     private EncyclopediaPageConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EncyclopediaPageConfigurator For(string name)
    {
      return new EncyclopediaPageConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static EncyclopediaPageConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintEncyclopediaPage>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EncyclopediaPageConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintEncyclopediaPage>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaPage.m_ParentAsset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintEncyclopediaNode"/></param>
    [Generated]
    public EncyclopediaPageConfigurator SetParentAsset(string value)
    {
      return OnConfigureInternal(bp => bp.m_ParentAsset = BlueprintTool.GetRef<BlueprintEncyclopediaNodeReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EncyclopediaPageConfigurator AddToBlocks(params BlueprintEncyclopediaBlock[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Blocks.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EncyclopediaPageConfigurator RemoveFromBlocks(params BlueprintEncyclopediaBlock[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Blocks = bp.Blocks.Where(item => !values.Contains(item)).ToList());
    }
  }
}
