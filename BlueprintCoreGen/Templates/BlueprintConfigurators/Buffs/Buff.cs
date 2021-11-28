using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Units;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System;

namespace BlueprintCoreGen.Blueprints.Configurators.Buffs
{
  /// <summary>Configurator for <see cref="BlueprintBuff"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBuff))]
  public class BuffConfigurator : BaseUnitFactConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BuffConfigurator(string name) : base(name) { }

    /// <summary>Returns a configurator for the given blueprint.</summary>
    /// 
    /// <remarks>
    /// Use this function if the blueprint exists in the game library. If you're using
    /// <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModifiationTemplate</see> your
    /// JSON blueprints should already exist.
    /// </remarks>
    public static BuffConfigurator For(string name)
    {
      return new BuffConfigurator(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    /// 
    /// <remarks>
    /// When this is called the mapping from name to Guid is stored so you can reference it by name in other calls to
    /// BlueprintCore. The mapping is equivalent to calling <see cref="BlueprintTool.AddGuidsByName"/>
    /// </remarks>
    public static BuffConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintBuff>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.IsClassFeature"/>
    /// </summary>
    public BuffConfigurator SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IsClassFeature = isClassFeature);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator SetFlags(params BlueprintBuff.Flags[] flags)
    {
      BlueprintBuff.Flags buffFlags = 0;
      flags.ForEach(f => buffFlags |= f);
      return OnConfigureInternal(bp => bp.m_Flags = buffFlags);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator AddToFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(blueprint => flags.ForEach(f => blueprint.m_Flags |= f));
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator RemoveFromFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(blueprint => flags.ForEach(f => blueprint.m_Flags &= ~f));
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Stacking"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetRanks(int)"/> for <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetStackingType(StackingType type)
    {
      if (type == StackingType.Rank)
      {
        throw new InvalidOperationException("Use SetRanks() for StackingType.Rank.");
      }

      return OnConfigureInternal(blueprint => blueprint.Stacking = type);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Ranks"/>
    /// </summary>
    ///
    /// <remarks>Also sets <see cref="BlueprintBuff.Stacking"/> to <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetRanks(int ranks)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.Stacking = StackingType.Rank;
            blueprint.Ranks = ranks;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.TickEachSecond"/>
    /// </summary>
    public BuffConfigurator SetTickEachSecond(bool tickEachSecond = true)
    {
      return OnConfigureInternal(blueprint => blueprint.TickEachSecond = tickEachSecond);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Frequency"/>
    /// </summary>
    public BuffConfigurator SetFrequency(DurationRate rate)
    {
      return OnConfigureInternal(blueprint => blueprint.Frequency = rate);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnStart"/>
    /// </summary>
    public BuffConfigurator SetFxOnStart(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnStart = prefab);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnRemove"/>
    /// </summary>
    public BuffConfigurator SetFxOnRemove(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnRemove = prefab);
    }

    // [GenerateComponents]

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponent<ITickEachRound>() == null)
      {
        AddValidationWarning($"ITickEachRound component is missing. Frequency and TickEachSecond will be ignored.");
      }
    }
  }
}