using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaNode"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaNode))]
  public abstract class BaseEncyclopediaNodeConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintEncyclopediaNode
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseEncyclopediaNodeConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaNode.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTitle(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Title = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaNode.m_Expanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetExpanded(bool value)
    {
      return OnConfigureInternal(bp => bp.m_Expanded = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaNode.ChildPages"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TBuilder AddToChildPages(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ChildPages.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEncyclopediaNode.ChildPages"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TBuilder RemoveFromChildPages(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(name));
            bp.ChildPages =
                bp.ChildPages
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }
  }
}
