//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="TargetMainCharacter"/>.
  /// </summary>
  /// <inheritdoc/>
  public class TargetMainCharacterConfigurator
    : BaseTargetMainCharacterConfigurator<TargetMainCharacter, TargetMainCharacterConfigurator>
  {
    private TargetMainCharacterConfigurator(Blueprint<BlueprintReference<TargetMainCharacter>> blueprint) : base(blueprint) { }

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
    public static TargetMainCharacterConfigurator For(Blueprint<BlueprintReference<TargetMainCharacter>> blueprint)
    {
      return new TargetMainCharacterConfigurator(blueprint);
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
    public static TargetMainCharacterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TargetMainCharacter>(name, guid);
      return For(name);
    }


    public TargetMainCharacterConfigurator CopyFrom(
      Blueprint<BlueprintReference<TargetMainCharacter>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
