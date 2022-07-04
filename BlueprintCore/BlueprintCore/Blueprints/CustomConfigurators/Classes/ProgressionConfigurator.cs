using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Linq;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ProgressionConfigurator
    : BaseProgressionConfigurator<BlueprintProgression, ProgressionConfigurator>
  {
    private ProgressionConfigurator(Blueprint<BlueprintReference<BlueprintProgression>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static ProgressionConfigurator For(Blueprint<BlueprintReference<BlueprintProgression>> blueprint)
    {
      return new ProgressionConfigurator(blueprint);
    }
    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static ProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintProgression>(name, guid);
      return For(name);
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator SetClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return SetClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator SetClasses(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return SetClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator AddToClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return AddToClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator AddToClasses(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return AddToClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.RemoveFromClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator RemoveFromClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return RemoveFromClasses(c => classes.Contains(c.m_Class));
    }

    private ClassWithLevel[] Convert(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return classes.Select(
          c => new ClassWithLevel()
          {
            m_Class = c.clazz.Reference,
            AdditionalLevel = c.additionalLevel
          })
        .ToArray();
    }

    private ClassWithLevel[] Convert(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return classes.Select(c => new ClassWithLevel() { m_Class = c.Reference }).ToArray();
    }
  }
}
