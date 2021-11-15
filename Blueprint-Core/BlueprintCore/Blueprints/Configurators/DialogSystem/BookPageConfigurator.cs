using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public BookPageConfigurator AddToCues(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Cues.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public BookPageConfigurator RemoveFromCues(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.Cues =
                bp.Cues
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public BookPageConfigurator AddToAnswers(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Answers.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public BookPageConfigurator RemoveFromAnswers(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name));
            bp.Answers =
                bp.Answers
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.OnShow"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetOnShow(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnShow = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.ImageLink"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetImageLink(SpriteLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ImageLink = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.ForeImageLink"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetForeImageLink(SpriteLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ForeImageLink = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetTitle(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Title = value);
    }
  }
}
