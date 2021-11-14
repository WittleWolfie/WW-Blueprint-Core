using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Linq;
using UnityEngine;

namespace BlueprintCoreGen.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and component support for blueprints inheriting from <see cref="BlueprintUnitFact"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitFact))]
  public abstract class BaseUnitFactConfigurator<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    protected BaseUnitFactConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_DisplayName"/>
    /// </summary>
    public TBuilder SetDisplayName(LocalizedString name)
    {
      OnConfigureInternal(blueprint => blueprint.m_DisplayName = name);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_Description"/>
    /// </summary>
    public TBuilder SetDescription(LocalizedString description)
    {
      OnConfigureInternal(blueprint => blueprint.m_Description = description);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_DescriptionShort"/>
    /// </summary>
    public TBuilder SetDescriptionShort(LocalizedString description)
    {
      OnConfigureInternal(blueprint => blueprint.m_DescriptionShort = description);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitFact.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      OnConfigureInternal(blueprint => blueprint.m_Icon = icon);
      return Self;
    }

    // [GenerateComponents]
  }
}