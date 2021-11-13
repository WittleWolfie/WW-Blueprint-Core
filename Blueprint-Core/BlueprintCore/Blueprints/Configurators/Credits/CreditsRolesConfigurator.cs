using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Credits;
namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>Configurator for <see cref="BlueprintCreditsRoles"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsRoles))]
  public class CreditsRolesConfigurator : BaseBlueprintConfigurator<BlueprintCreditsRoles, CreditsRolesConfigurator>
  {
     private CreditsRolesConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsRolesConfigurator For(string name)
    {
      return new CreditsRolesConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CreditsRolesConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCreditsRoles>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsRolesConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCreditsRoles>(name, assetId);
      return For(name);
    }

  }
}
