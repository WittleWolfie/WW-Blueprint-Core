using BlueprintCore.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Units;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using System;

namespace BlueprintCore.Blueprints.Buffs
{
  /// <summary>Configurator for <see cref="BlueprintBuff"/>.</summary>
  /// <inheritdoc/>
  public class BuffConfigurator : BlueprintUnitFactConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BlueprintBuff.Flags EnableFlags;
    private BlueprintBuff.Flags DisableFlags;

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
    /// Use this function to create a new blueprint if you provided a mapping with
    /// <see cref="BlueprintTool.AddGuidsByName"/>. Otherwise use <see cref="New(string, string)"/>.
    /// </remarks>
    public static BuffConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBuff>(name);
      return For(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    public static BuffConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBuff>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="AddEffectFastHealing"/>
    /// </summary>
    public BuffConfigurator FastHealing(int baseValue, ContextValue bonusValue = null)
    {
      var fastHealing = new AddEffectFastHealing
      {
        Heal = baseValue,
        Bonus = bonusValue ?? 0
      };
      return AddComponent(fastHealing);
    }

    /// <summary>
    /// Adds <see cref="RemoveWhenCombatEnded"/>
    /// </summary>
    public BuffConfigurator RemoveWhenCombatEnds()
    {
      AddUniqueComponent(new RemoveWhenCombatEnded(), ComponentMerge.Skip);
      return this;
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator AddFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        EnableFlags |= flag;
      }
      return this;
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator RemoveFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        DisableFlags |= flag;
      }
      return this;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.Mechanics.Buffs.BuffSleeping">BuffSleeping</see>
    /// </summary>
    public BuffConfigurator BuffSleeping(
        int? wakeupPerceptionDC = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var sleeping = new BuffSleeping();
      if (wakeupPerceptionDC is not null) { sleeping.WakeupPerceptionDC = wakeupPerceptionDC.Value; }
      return AddUniqueComponent(sleeping, mergeBehavior, merge);
    }

    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableFlags > 0) { Blueprint.m_Flags |= EnableFlags; }
      if (DisableFlags > 0) { Blueprint.m_Flags &= ~DisableFlags; }
    }

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