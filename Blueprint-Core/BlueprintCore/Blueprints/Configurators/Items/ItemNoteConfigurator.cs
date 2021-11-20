using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemNote"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemNote))]
  public class ItemNoteConfigurator : BaseItemConfigurator<BlueprintItemNote, ItemNoteConfigurator>
  {
    private ItemNoteConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemNoteConfigurator For(string name)
    {
      return new ItemNoteConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemNoteConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemNote>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemNoteConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemNote>(name, assetId);
      return For(name);
    }
  }
}
