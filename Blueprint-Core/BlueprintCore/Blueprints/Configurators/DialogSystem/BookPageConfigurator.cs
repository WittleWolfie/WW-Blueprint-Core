using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintBookPage"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBookPage))]
  public class BookPageConfigurator : BaseCueBaseConfigurator<BlueprintBookPage, BookPageConfigurator>
  {
     private BookPageConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BookPageConfigurator For(string name)
    {
      return new BookPageConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BookPageConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBookPage>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BookPageConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBookPage>(name, assetId);
      return For(name);
    }
  }
}
