using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Linq;

namespace BlueprintCoreGen.Templates.BlueprintComponents
{
  abstract class FactTemplates<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : FactTemplates<T, TBuilder>
  {
    private FactTemplates(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/>
    /// </summary>
    [Implements(typeof(AddContextStatBonus))]
    public TBuilder AddContextStatBonus(
        StatType stat,
        ContextValue value,
        ModifierDescriptor descriptor = default,
        int multiplier = 1,
        int? minimal = null)
    {
      ValidateParam(value);

      var component = new AddContextStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.Value = value ?? ContextValues.Constant(0);
      component.HasMinimal = minimal is not null;
      component.Minimal = minimal ?? 0;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.FactLogic.AddFacts">AddFacts</see>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Implements(typeof(AddFacts))]
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
    [Implements(typeof(AddInitiatorSkillRollTrigger))]
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

    /// <summary>
    /// Adds <see cref="AddFactContextActions"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionLists</see></remarks>
    [Implements(typeof(AddFactContextActions))]
    public TBuilder AddFactContextActions(
        ActionsBuilder? onActivated = null,
        ActionsBuilder? onDeactivated = null,
        ActionsBuilder? onNewRound = null,
        ComponentMerge behavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      if (onActivated == null && onDeactivated == null && onNewRound == null)
      {
        throw new InvalidOperationException("No actions provided.");
      }
      var contextActions = new AddFactContextActions
      {
        Activated = onActivated?.Build() ?? Constants.Empty.Actions,
        Deactivated = onDeactivated?.Build() ?? Constants.Empty.Actions,
        NewRound = onNewRound?.Build() ?? Constants.Empty.Actions
      };
      return AddUniqueComponent(contextActions, behavior, merge ?? MergeFactContextActions);
    }

    [Implements(typeof(AddFactContextActions))]
    private static void MergeFactContextActions(
        BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AddFactContextActions;
      var target = other as AddFactContextActions;
      source!.Activated.Actions = CommonTool.Append(source.Activated.Actions, target!.Activated.Actions);
      source.Deactivated.Actions = CommonTool.Append(source.Deactivated.Actions, target.Deactivated.Actions);
      source.NewRound.Actions = CommonTool.Append(source.NewRound.Actions, target.NewRound.Actions);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public TBuilder AddContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }
  }
}
