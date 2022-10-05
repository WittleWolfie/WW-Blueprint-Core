//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LeadersRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLeadersRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : LeadersRoot
    where TBuilder : BaseLeadersRootConfigurator<T, TBuilder>
  {
    protected BaseLeadersRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<LeadersRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ExpTable = copyFrom.m_ExpTable;
          bp.m_Leaders = copyFrom.m_Leaders;
          bp.m_AttackLeaderFeature = copyFrom.m_AttackLeaderFeature;
          bp.m_DeffenceLeaderFeature = copyFrom.m_DeffenceLeaderFeature;
          bp.m_BaseManaRegen = copyFrom.m_BaseManaRegen;
          bp.FirstLeadCost = copyFrom.FirstLeadCost;
          bp.ReducedLeadCost = copyFrom.ReducedLeadCost;
          bp.LeadCostMultiply = copyFrom.LeadCostMultiply;
          bp.m_ArmyLeaderAssignmentCooldownDays = copyFrom.m_ArmyLeaderAssignmentCooldownDays;
          bp.m_CheaperLeadersProject = copyFrom.m_CheaperLeadersProject;
          bp.m_TalentedLeadersProject = copyFrom.m_TalentedLeadersProject;
          bp.m_ExperiencedLeadersProject = copyFrom.m_ExperiencedLeadersProject;
          bp.m_ExcellentLeadersProject = copyFrom.m_ExcellentLeadersProject;
          bp.SkillsListName = copyFrom.SkillsListName;
          bp.ManaName = copyFrom.ManaName;
          bp.AttackBonusName = copyFrom.AttackBonusName;
          bp.DeffBonusName = copyFrom.DeffBonusName;
          bp.SpellStrengthName = copyFrom.SpellStrengthName;
          bp.LeaderHireText = copyFrom.LeaderHireText;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ExpTable"/>
    /// </summary>
    ///
    /// <param name="expTable">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExpTable(Blueprint<BlueprintStatProgressionReference> expTable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExpTable = expTable?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ExpTable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExpTable(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExpTable is null) { return; }
          action.Invoke(bp.m_ExpTable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLeaders(params Blueprint<BlueprintArmyLeaderReference>[] leaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leaders = leaders.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLeaders(params Blueprint<BlueprintArmyLeaderReference>[] leaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leaders = bp.m_Leaders ?? new BlueprintArmyLeaderReference[0];
          bp.m_Leaders = CommonTool.Append(bp.m_Leaders, leaders.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLeaders(params Blueprint<BlueprintArmyLeaderReference>[] leaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leaders is null) { return; }
          bp.m_Leaders = bp.m_Leaders.Where(val => !leaders.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="LeadersRoot.m_Leaders"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLeaders(Func<BlueprintArmyLeaderReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leaders is null) { return; }
          bp.m_Leaders = bp.m_Leaders.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    public TBuilder ClearLeaders()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leaders = new BlueprintArmyLeaderReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_Leaders"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLeaders(Action<BlueprintArmyLeaderReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leaders is null) { return; }
          bp.m_Leaders.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_AttackLeaderFeature"/>
    /// </summary>
    ///
    /// <param name="attackLeaderFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAttackLeaderFeature(Blueprint<BlueprintFeatureReference> attackLeaderFeature)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackLeaderFeature = attackLeaderFeature?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_AttackLeaderFeature"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAttackLeaderFeature(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AttackLeaderFeature is null) { return; }
          action.Invoke(bp.m_AttackLeaderFeature);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_DeffenceLeaderFeature"/>
    /// </summary>
    ///
    /// <param name="deffenceLeaderFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDeffenceLeaderFeature(Blueprint<BlueprintFeatureReference> deffenceLeaderFeature)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DeffenceLeaderFeature = deffenceLeaderFeature?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_DeffenceLeaderFeature"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeffenceLeaderFeature(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DeffenceLeaderFeature is null) { return; }
          action.Invoke(bp.m_DeffenceLeaderFeature);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_BaseManaRegen"/>
    /// </summary>
    public TBuilder SetBaseManaRegen(int baseManaRegen)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BaseManaRegen = baseManaRegen;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.FirstLeadCost"/>
    /// </summary>
    public TBuilder SetFirstLeadCost(int firstLeadCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FirstLeadCost = firstLeadCost;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.ReducedLeadCost"/>
    /// </summary>
    public TBuilder SetReducedLeadCost(int reducedLeadCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ReducedLeadCost = reducedLeadCost;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.LeadCostMultiply"/>
    /// </summary>
    public TBuilder SetLeadCostMultiply(float leadCostMultiply)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeadCostMultiply = leadCostMultiply;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ArmyLeaderAssignmentCooldownDays"/>
    /// </summary>
    public TBuilder SetArmyLeaderAssignmentCooldownDays(int armyLeaderAssignmentCooldownDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyLeaderAssignmentCooldownDays = armyLeaderAssignmentCooldownDays;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_CheaperLeadersProject"/>
    /// </summary>
    ///
    /// <param name="cheaperLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCheaperLeadersProject(Blueprint<BlueprintKingdomProjectReference> cheaperLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CheaperLeadersProject = cheaperLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_CheaperLeadersProject"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheaperLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CheaperLeadersProject is null) { return; }
          action.Invoke(bp.m_CheaperLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_TalentedLeadersProject"/>
    /// </summary>
    ///
    /// <param name="talentedLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTalentedLeadersProject(Blueprint<BlueprintKingdomProjectReference> talentedLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TalentedLeadersProject = talentedLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_TalentedLeadersProject"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTalentedLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TalentedLeadersProject is null) { return; }
          action.Invoke(bp.m_TalentedLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ExperiencedLeadersProject"/>
    /// </summary>
    ///
    /// <param name="experiencedLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExperiencedLeadersProject(Blueprint<BlueprintKingdomProjectReference> experiencedLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExperiencedLeadersProject = experiencedLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ExperiencedLeadersProject"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExperiencedLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExperiencedLeadersProject is null) { return; }
          action.Invoke(bp.m_ExperiencedLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ExcellentLeadersProject"/>
    /// </summary>
    ///
    /// <param name="excellentLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExcellentLeadersProject(Blueprint<BlueprintKingdomProjectReference> excellentLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcellentLeadersProject = excellentLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ExcellentLeadersProject"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExcellentLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcellentLeadersProject is null) { return; }
          action.Invoke(bp.m_ExcellentLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.SkillsListName"/>
    /// </summary>
    ///
    /// <param name="skillsListName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetSkillsListName(LocalString skillsListName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkillsListName = skillsListName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.SkillsListName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySkillsListName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SkillsListName is null) { return; }
          action.Invoke(bp.SkillsListName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.ManaName"/>
    /// </summary>
    ///
    /// <param name="manaName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetManaName(LocalString manaName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ManaName = manaName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.ManaName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyManaName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ManaName is null) { return; }
          action.Invoke(bp.ManaName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.AttackBonusName"/>
    /// </summary>
    ///
    /// <param name="attackBonusName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetAttackBonusName(LocalString attackBonusName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AttackBonusName = attackBonusName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.AttackBonusName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAttackBonusName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AttackBonusName is null) { return; }
          action.Invoke(bp.AttackBonusName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.DeffBonusName"/>
    /// </summary>
    ///
    /// <param name="deffBonusName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDeffBonusName(LocalString deffBonusName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeffBonusName = deffBonusName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.DeffBonusName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeffBonusName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DeffBonusName is null) { return; }
          action.Invoke(bp.DeffBonusName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.SpellStrengthName"/>
    /// </summary>
    ///
    /// <param name="spellStrengthName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetSpellStrengthName(LocalString spellStrengthName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellStrengthName = spellStrengthName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.SpellStrengthName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellStrengthName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpellStrengthName is null) { return; }
          action.Invoke(bp.SpellStrengthName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.LeaderHireText"/>
    /// </summary>
    ///
    /// <param name="leaderHireText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLeaderHireText(LocalString leaderHireText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderHireText = leaderHireText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.LeaderHireText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeaderHireText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderHireText is null) { return; }
          action.Invoke(bp.LeaderHireText);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_ExpTable is null)
      {
        Blueprint.m_ExpTable = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_Leaders is null)
      {
        Blueprint.m_Leaders = new BlueprintArmyLeaderReference[0];
      }
      if (Blueprint.m_AttackLeaderFeature is null)
      {
        Blueprint.m_AttackLeaderFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (Blueprint.m_DeffenceLeaderFeature is null)
      {
        Blueprint.m_DeffenceLeaderFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (Blueprint.m_CheaperLeadersProject is null)
      {
        Blueprint.m_CheaperLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      if (Blueprint.m_TalentedLeadersProject is null)
      {
        Blueprint.m_TalentedLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      if (Blueprint.m_ExperiencedLeadersProject is null)
      {
        Blueprint.m_ExperiencedLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      if (Blueprint.m_ExcellentLeadersProject is null)
      {
        Blueprint.m_ExcellentLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(null);
      }
      if (Blueprint.SkillsListName is null)
      {
        Blueprint.SkillsListName = Utils.Constants.Empty.String;
      }
      if (Blueprint.ManaName is null)
      {
        Blueprint.ManaName = Utils.Constants.Empty.String;
      }
      if (Blueprint.AttackBonusName is null)
      {
        Blueprint.AttackBonusName = Utils.Constants.Empty.String;
      }
      if (Blueprint.DeffBonusName is null)
      {
        Blueprint.DeffBonusName = Utils.Constants.Empty.String;
      }
      if (Blueprint.SpellStrengthName is null)
      {
        Blueprint.SpellStrengthName = Utils.Constants.Empty.String;
      }
      if (Blueprint.LeaderHireText is null)
      {
        Blueprint.LeaderHireText = Utils.Constants.Empty.String;
      }
    }
  }
}
