using System.Linq;
using BlueprintCore.Actions.Builder;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace BlueprintCore.Blueprints.Facts
{
  public abstract class BlueprintUnitFactConfigurator<T, TBuilder>
      : BlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BlueprintConfigurator<T, TBuilder>
  {

    protected BlueprintUnitFactConfigurator(string name) : base(name) { }

    /** (Field) m_DisplayName */
    public TBuilder SetDisplayName(LocalizedString name)
    {
      OnConfigureInternal(blueprint => blueprint.m_DisplayName = name);
      return Self;
    }

    /** (Field) m_Description */
    public TBuilder SetDescription(LocalizedString description)
    {
      OnConfigureInternal(blueprint => blueprint.m_Description = description);
      return Self;
    }

    /** (Field) m_DescriptionShort */
    public TBuilder SetDescriptionShort(LocalizedString description)
    {
      OnConfigureInternal(blueprint => blueprint.m_DescriptionShort = description);
      return Self;
    }

    /** (Field) m_Icon */
    public TBuilder SetIcon(Sprite icon)
    {
      OnConfigureInternal(blueprint => blueprint.m_Icon = icon);
      return Self;
    }

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
            facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray(),
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