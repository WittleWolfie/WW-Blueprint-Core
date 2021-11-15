using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintFeatureSelectMythicSpellbook"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureSelectMythicSpellbook))]
  public class FeatureSelectMythicSpellbookConfigurator : BaseFeatureConfigurator<BlueprintFeatureSelectMythicSpellbook, FeatureSelectMythicSpellbookConfigurator>
  {
     private FeatureSelectMythicSpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureSelectMythicSpellbookConfigurator For(string name)
    {
      return new FeatureSelectMythicSpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FeatureSelectMythicSpellbookConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeatureSelectMythicSpellbook>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureSelectMythicSpellbookConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeatureSelectMythicSpellbook>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator AddToCachedItems(params IFeatureSelectionItem[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedItems.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator RemoveFromCachedItems(params IFeatureSelectionItem[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedItems = bp.m_CachedItems.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator AddToAllowedSpellbooks(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_AllowedSpellbooks = CommonTool.Append(bp.m_AllowedSpellbooks, values.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator RemoveFromAllowedSpellbooks(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name));
            bp.m_AllowedSpellbooks =
                bp.m_AllowedSpellbooks
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelectMythicSpellbook.m_MythicSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellList"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator SetMythicSpellList(string value)
    {
      return OnConfigureInternal(bp => bp.m_MythicSpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(value));
    }
  }
}
