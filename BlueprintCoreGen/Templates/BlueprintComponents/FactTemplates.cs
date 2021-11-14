using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Linq;

namespace BlueprintCoreGen.Templates.BlueprintComponents
{
  abstract class FactTemplates<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : FactTemplates<T, TBuilder>
  {
    private FactTemplates(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.FactLogic.AddFacts">AddFacts</see>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
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
            facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray(),
        CasterLevel = casterLevel,
        HasDifficultyRequirements = hasDifficultyRequirements,
        InvertDifficultyRequirements = invertDifficultyRequirements,
        MinDifficulty = minDifficulty
      };
      return AddComponent(addFacts);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSkillRollTrigger"/>
    /// </summary>
    public TBuilder OnSkillCheck(
        StatType skill, ActionsBuilder actions, bool onlySuccess = true)
    {
      var trigger = new AddInitiatorSkillRollTrigger
      {
        OnlySuccess = onlySuccess,
        Skill = skill,
        Action = actions.Build()
      };
      return AddComponent(trigger);
    }
  }
}
