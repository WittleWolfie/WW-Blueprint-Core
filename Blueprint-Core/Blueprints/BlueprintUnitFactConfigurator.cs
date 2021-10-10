using System.Linq;
using BlueprintCore.Actions.Builder;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace BlueprintCore.Blueprints
{
  public abstract class BlueprintUnitFactConfigurator<T, TBuilder>
      : BlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BlueprintConfigurator<T, TBuilder>
  {

    protected BlueprintUnitFactConfigurator(string name) : base(name) { }

    /**
     * AddFacts
     *
     * @param facts BlueprintUnitFact
     */
    public TBuilder AddFacts(
        string[] facts,
        int casterLevel = 0,
        bool hasDifficultyRequirements = false,
        bool invertDifficultyRequirements = false,
        GameDifficultyOption minDifficulty = GameDifficultyOption.Story)
    {
      var addFacts = new AddFacts
      {
        m_Facts =
          facts
              .Select(
                  fact => BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact))
              .ToArray(),
        CasterLevel = casterLevel,
        HasDifficultyRequirements = hasDifficultyRequirements,
        InvertDifficultyRequirements = invertDifficultyRequirements,
        MinDifficulty = minDifficulty
      };
      return AddComponent(addFacts);
    }

    /** AddInitiatorSkillRollTrigger */
    public TBuilder OnSkillCheck(
        StatType skill, ActionListBuilder actions, bool onlySuccess = true)
    {
      var trigger = new AddInitiatorSkillRollTrigger
      {
        OnlySuccess = onlySuccess,
        Skill = skill,
        Action = actions.Build()
      };
      return AddComponent(trigger);
    }

    protected override void ConfigureInternal() { }

    protected override void ValidateInternal() { }
  }
}