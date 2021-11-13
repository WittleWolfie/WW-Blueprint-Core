using BlueprintCore.Blueprints.Configurators.Kingdom;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomProject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomProject))]
  public abstract class BaseKingdomProjectConfigurator<T, TBuilder>
      : BaseKingdomEventBaseConfigurator<T, TBuilder>
      where T : BlueprintKingdomProject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseKingdomProjectConfigurator(string name) : base(name) { }

  }

  /// <summary>Configurator for <see cref="BlueprintKingdomProject"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomProject))]
  public class KingdomProjectConfigurator : BaseKingdomEventBaseConfigurator<BlueprintKingdomProject, KingdomProjectConfigurator>
  {
     private KingdomProjectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomProjectConfigurator For(string name)
    {
      return new KingdomProjectConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomProjectConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomProject>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomProjectConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomProject>(name, assetId);
      return For(name);
    }

  }
}
