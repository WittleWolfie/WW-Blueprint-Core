//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintProjectile"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseProjectileConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintProjectile
    where TBuilder : BaseProjectileConfigurator<T, TBuilder>
  {
    protected BaseProjectileConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="CannotSneakAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MagicMissile01</term><description>741743ccd287a854fbb68ce70f75fa05</description></item>
    /// <item><term>MagicMissile03</term><description>caadaf27d789793459a3e32cb0615d14</description></item>
    /// <item><term>MagicMissile04</term><description>43295b5988021f741a28b8bf0424a412</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddCannotSneakAttack()
    {
      return AddComponent(new CannotSneakAttack());
    }
  }
}
