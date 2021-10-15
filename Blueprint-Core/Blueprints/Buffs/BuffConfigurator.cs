using BlueprintCore.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Units;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Blueprints.Buffs
{
  public class BuffConfigurator
      : BlueprintUnitFactConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BlueprintBuff.Flags EnableFlags;
    private BlueprintBuff.Flags DisableFlags;

    private BuffConfigurator(string name) : base(name) { }

    /**
     * Creates a BuffConfigurator for the specified blueprint.
     *
     * Use this function if the blueprint already exists. If you're using Owlcat's
     * WrathModificationTemplate all of your JSON blueprints already exist.
     */
    public static BuffConfigurator For(string name)
    {
      return new BuffConfigurator(name);
    }

    /**
     * Creates a BlueprintBuff and returns its BuffConfigurator.
     * 
     * Use this function to create a Blueprint if you provided a mapping to Guids with an associated
     * guid for the given name.
     */
    public static BuffConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBuff>(name);
      return For(name);
    }

    /** Creates a BlueprintBuff and returns its BuffConfigurator. */
    public static BuffConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBuff>(name, assetId);
      return For(name);
    }

    /** AddEffectFastHealing */
    public BuffConfigurator FastHealing(int baseValue, ContextValue bonusValue = null)
    {
      var fastHealing = new AddEffectFastHealing
      {
        Heal = baseValue,
        Bonus = bonusValue ?? 0
      };
      return AddComponent(fastHealing);
    }

    /** RemoveWhenCombatEnded */
    public BuffConfigurator RemoveWhenCombatEnds()
    {
      AddUniqueComponent(new RemoveWhenCombatEnded(), ComponentMerge.Skip);
      return this;
    }

    /** (Field) m_Flags */
    public BuffConfigurator AddFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        EnableFlags |= flag;
      }
      return this;
    }

    /** (Field) m_Flags */
    public BuffConfigurator RemoveFlags(params BlueprintBuff.Flags[] flags)
    {
      foreach (BlueprintBuff.Flags flag in flags)
      {
        DisableFlags |= flag;
      }
      return this;
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
        // TODO: This is useful but need a way to prevent this from failing tests
        //AddValidationWarning($"Buff frequency will be ignored: {Name} - {Blueprint.Frequency}");
        if (Blueprint.TickEachSecond)
        {
          AddValidationWarning(
              $"ITickEachRound component is present. TickEachSecond will be ignored.");
        }
      }
    }
  }
}