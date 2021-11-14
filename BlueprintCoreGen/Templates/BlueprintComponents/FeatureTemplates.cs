using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using System;

namespace BlueprintCoreGen.Templates.BlueprintComponents
{
  abstract class FeatureTemplates<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : FeatureTemplates<T, TBuilder>
  {
    private FeatureTemplates(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteSelectionPossible">PrerequisiteSelectionPossible</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// A feature selection with this component only shows up if the character is eligible for at least one feature.
    /// This is useful when a character has access to different feature selections based on some criteria.
    /// </para>
    /// 
    /// <para>
    /// See ExpandedDefense and WildTalentBonusFeatAir3 blueprints for example usages.
    /// </para>
    /// </remarks>
    public TBuilder PrerequisiteSelectionPossible(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var selectionPossible = PrereqTool.Create<PrerequisiteSelectionPossible>(group, checkInProgression, hideInUI);
      selectionPossible.m_ThisFeature = Blueprint.ToReference<BlueprintFeatureSelectionReference>();
      return AddComponent(selectionPossible);
    }
  }
}
