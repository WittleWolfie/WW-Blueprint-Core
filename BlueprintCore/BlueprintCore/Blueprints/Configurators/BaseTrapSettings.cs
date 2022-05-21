//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTrapSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTrapSettingsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTrapSettings
    where TBuilder : BaseTrapSettingsConfigurator<T, TBuilder>
  {
    protected BaseTrapSettingsConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettings.ActorLevel"/>
    /// </summary>
    public TBuilder SetActorLevel(int actorLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActorLevel = actorLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettings.ActorLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActorLevel(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ActorLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettings.ActorStatMod"/>
    /// </summary>
    public TBuilder SetActorStatMod(BlueprintTrapSettings.IntRange actorStatMod)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActorStatMod = actorStatMod;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettings.ActorStatMod"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActorStatMod(Action<BlueprintTrapSettings.IntRange> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ActorStatMod);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettings.TrapActor"/>
    /// </summary>
    ///
    /// <param name="trapActor">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTrapActor(Blueprint<BlueprintUnit, BlueprintUnitReference> trapActor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrapActor = trapActor?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettings.TrapActor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTrapActor(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrapActor is null) { return; }
          action.Invoke(bp.TrapActor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettings.DisableDC"/>
    /// </summary>
    public TBuilder SetDisableDC(BlueprintTrapSettings.IntRange disableDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableDC = disableDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettings.DisableDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableDC(Action<BlueprintTrapSettings.IntRange> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisableDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTrapSettings.PerceptionDC"/>
    /// </summary>
    public TBuilder SetPerceptionDC(BlueprintTrapSettings.IntRange perceptionDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PerceptionDC = perceptionDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettings.PerceptionDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPerceptionDC(Action<BlueprintTrapSettings.IntRange> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PerceptionDC);
        });
    }
  }
}
