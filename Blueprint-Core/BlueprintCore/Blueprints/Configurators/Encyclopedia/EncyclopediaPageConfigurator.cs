using BlueprintCore.Blueprints.Configurators.Encyclopedia;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Encyclopedia;

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
  }
}
