using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Blueprints;
using BlueprintCore.Test.Asserts;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints
{
  [Collection("Harmony")]
  public abstract class BlueprintConfiguratorTest<T, TBuilder> : TestBase
      where T : BlueprintScriptableObject
      where TBuilder : BlueprintConfigurator<T, TBuilder>
  {
    // Serves as the guid for the primary test blueprint. Concrete child classes must instantiate
    // create and register a blueprint using this guid;
    protected static readonly string Guid = "137f7548-e57f-4e4a-8d76-7f2d174c6d5d";

    /**
     * Wrapper which should be called when a function is exposed to blueprint types that do not
     * support it.
     * 
     * For example, SpellDescriptors are only valid for Ability, AbilityAreaEffect, Buff, and
     * Feature. Since BlueprintScriptableObject is the only type they share in common, the
     * functionality is included in BlueprintConfigurator. Those tests can call this function to
     * validate that supported types work properly and unsupported types throw an exception.
     */
    protected void RunTest(Action test, params Type[] validTypes)
    {
      var currentType = typeof(T);
      foreach (Type type in validTypes)
      {
        if (type.IsAssignableFrom(currentType))
        {
          test.Invoke();
          return;
        }
      }
      Assert.Throws<InvalidOperationException>(test);
    }

    /** Creates and returns a configurator of type TBuilder. */
    protected abstract TBuilder GetConfigurator(string guid);

    //----- Start: FactContextActions

    [Fact]
    public void FactContextActions()
    {
      GetConfigurator(Guid)
          .FactContextActions(
              onActivated: ActionListBuilder.New().MeleeAttack().MeleeAttack(),
              onDeactivated: ActionListBuilder.New().MeleeAttack(),
              onNewRound: ActionListBuilder.New().SwitchToDemoralizeTarget())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Equal(2, contextActions.Activated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[1]);

      Assert.Single(contextActions.Deactivated.Actions);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[0]);

      Assert.Single(contextActions.NewRound.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(contextActions.NewRound.Actions[0]);
    }

    [Fact]
    public void FactContextActions_WithActivatedOnly()
    {
      GetConfigurator(Guid)
          .FactContextActions(onActivated: ActionListBuilder.New().MeleeAttack().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Equal(2, contextActions.Activated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[1]);

      Assert.NotNull(contextActions.Deactivated.Actions);
      Assert.NotNull(contextActions.NewRound.Actions);
    }

    [Fact]
    public void FactContextActions_WithDeactivatedOnly()
    {
      GetConfigurator(Guid)
          .FactContextActions(onDeactivated: ActionListBuilder.New().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Single(contextActions.Deactivated.Actions);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[0]);

      Assert.NotNull(contextActions.Activated.Actions);
      Assert.NotNull(contextActions.NewRound.Actions);
    }

    [Fact]
    public void FactContextActions_WithNewRoundOnly()
    {
      GetConfigurator(Guid)
          .FactContextActions(onNewRound: ActionListBuilder.New().SwitchToDemoralizeTarget())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Single(contextActions.NewRound.Actions);
      Assert.IsType<SwitchToDemoralizeTarget>(contextActions.NewRound.Actions[0]);

      Assert.NotNull(contextActions.Activated.Actions);
      Assert.NotNull(contextActions.Deactivated.Actions);
    }

    [Fact]
    public void FactContextActions_WithMerge()
    {
      // First pass
      GetConfigurator(Guid)
          .FactContextActions(
              onActivated: ActionListBuilder.New().MeleeAttack().MeleeAttack(),
              onDeactivated: ActionListBuilder.New().MeleeAttack(),
              onNewRound: ActionListBuilder.New().SwitchToDemoralizeTarget())
          .Configure();

      GetConfigurator(Guid)
          .FactContextActions(
              onActivated: ActionListBuilder.New().SwitchToDemoralizeTarget(),
              onDeactivated: ActionListBuilder.New().MeleeAttack(),
              onNewRound: ActionListBuilder.New().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Equal(3, contextActions.Activated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[1]);
      Assert.IsType<SwitchToDemoralizeTarget>(contextActions.Activated.Actions[2]);

      Assert.Equal(2, contextActions.Deactivated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[1]);

      Assert.Equal(2, contextActions.NewRound.Actions.Length);
      Assert.IsType<SwitchToDemoralizeTarget>(contextActions.NewRound.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.NewRound.Actions[1]);
    }

    //----- Start: AddPrerequisiteAlignment

    [Fact]
    public void AddPrerequisiteAlignment()
    {
      RunTest(
          AddPrerequisiteAlignment_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void AddPrerequisiteAlignment_Action()
    {
      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood, AlignmentMaskType.LawfulNeutral)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteAlignment>();
      Assert.NotNull(prereq);

      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulGood));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulNeutral));
    }

    [Fact]
    public void AddPrerequisiteAlignment_WithExisting()
    {
      RunTest(
          AddPrerequisiteAlignment_WithExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void AddPrerequisiteAlignment_WithExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood, AlignmentMaskType.LawfulNeutral)
          .Configure();

      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.ChaoticGood)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteAlignment>();
      Assert.NotNull(prereq);

      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulGood));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulNeutral));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.ChaoticGood));
    }

    //----- Start: RemovePrerequisiteAlignment

    [Fact]
    public void RemovePrerequisiteAlignment()
    {
      RunTest(
          RemovePrerequisiteAlignment_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void RemovePrerequisiteAlignment_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood, AlignmentMaskType.LawfulNeutral)
          .Configure();

      GetConfigurator(Guid)
          .RemovePrerequisiteAlignment(AlignmentMaskType.LawfulGood)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteAlignment>();
      Assert.NotNull(prereq);

      Assert.False(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulGood));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulNeutral));
    }

    //----- Start: PrerequisiteArchetype

    [Fact]
    public void PrerequisiteArchetype()
    {
      RunTest(
          PrerequisiteArchetype_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteArchetype_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteArchetype(ClassGuid, ArchetypeGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteArchetypeLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
      Assert.Equal(1, prereq.Level);
    }

    [Fact]
    public void PrerequisiteArchetype_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteArchetype_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteArchetype_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteArchetype(
              ClassGuid,
              ArchetypeGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteArchetypeLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
      Assert.Equal(1, prereq.Level);
    }

    [Fact]
    public void PrerequisiteArchetype_WithLevel()
    {
      RunTest(
          PrerequisiteArchetype_WithLevel_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteArchetype_WithLevel_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteArchetype(ClassGuid, ArchetypeGuid, 5)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteArchetypeLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
      Assert.Equal(5, prereq.Level);
    }

    //----- Start: PrerequisiteCasterType

    [Fact]
    public void PrerequisiteCasterType()
    {
      RunTest(
          PrerequisiteCasterType_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCasterType_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterType(/* isArcane= */ true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterType>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.IsArcane);
    }

    [Fact]
    public void PrerequisiteCasterType_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteCasterType_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCasterType_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterType(
              /* isArcane= */ true,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterType>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.True(prereq.IsArcane);
    }

    [Fact]
    public void PrerequisiteCasterType_WithExisting()
    {
      RunTest(
          PrerequisiteCasterType_WithExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCasterType_WithExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteCasterType(/* isArcane= */ true)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteCasterType(/* isArcane= */ false)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterType>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.IsArcane);
    }

    //----- Start: PrerequisiteCasterTypeSpellLevel

    [Fact]
    public void PrerequisiteCasterTypeSpellLevel()
    {
      RunTest(
          PrerequisiteCasterTypeSpellLevel_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCasterTypeSpellLevel_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterTypeSpellLevel(
              /* isArcane= */ true, /* onlySpontaneous= */ true, 3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterTypeSpellLevel>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.IsArcane);
      Assert.True(prereq.OnlySpontaneous);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    [Fact]
    public void PrerequisiteCasterTypeSpellLevel_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteCasterTypeSpellLevel_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCasterTypeSpellLevel_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterTypeSpellLevel(
              /* isArcane= */ true,
              /* onlySpontaneous= */ true,
              /* minLevel= */ 3,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterTypeSpellLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.True(prereq.IsArcane);
      Assert.True(prereq.OnlySpontaneous);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    //----- Start: PrerequisiteCharacterLevel

    [Fact]
    public void PrerequisiteCharacterLevel()
    {
      RunTest(
          PrerequisiteCharacterLevel_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCharacterLevel_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(6)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCharacterLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(6, prereq.Level);
    }

    [Fact]
    public void PrerequisiteCharacterLevel_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteCharacterLevel_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCharacterLevel_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(
              6,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCharacterLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(6, prereq.Level);
    }

    [Fact]
    public void PrerequisiteCharacterLevel_WithExisting()
    {
      RunTest(
          PrerequisiteCharacterLevel_WithExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCharacterLevel_WithExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(6)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCharacterLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(3, prereq.Level);
    }

    //----- Start: PrerequisiteClassLevel

    [Fact]
    public void PrerequisiteClassLevel()
    {
      RunTest(
          PrerequisiteClassLevel_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassLevel_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ClassGuid, 2)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(2, prereq.Level);
      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassLevel_ReplaceExisting()
    {
      RunTest(
          PrerequisiteClassLevel_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassLevel_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ClassGuid, 2)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ExtraClassGuid, 3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(
          ExtraClass.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(3, prereq.Level);
      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassLevel_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteClassLevel_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassLevel_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(
              ClassGuid,
              2,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(2, prereq.Level);
      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassLevel_Negated()
    {
      RunTest(
          PrerequisiteClassLevel_Negated_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassLevel_Negated_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ClassGuid, 2, /* negate= */ true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(2, prereq.Level);
      Assert.True(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassSpellLevel()
    {
      RunTest(
          PrerequisiteClassSpellLevel_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassSpellLevel_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(ClassGuid, 3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassSpellLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    [Fact]
    public void PrerequisiteClassSpellLevel_ReplaceExisting()
    {
      RunTest(
          PrerequisiteClassSpellLevel_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassSpellLevel_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(ExtraClassGuid, 5)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(ClassGuid, 1)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassSpellLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(1, prereq.RequiredSpellLevel);
    }

    [Fact]
    public void PrerequisiteClassSpellLevel_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteClassSpellLevel_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteClassSpellLevel_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(
              ClassGuid,
              3,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassSpellLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    //----- Start: PrerequisiteEtude

    [Fact]
    public void PrerequisiteEtude()
    {
      RunTest(
          PrerequisiteEtude_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteEtude_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteEtude(EtudeGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteEtude>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
      Assert.False(prereq.NotPlaying);
    }

    [Fact]
    public void PrerequisiteEtude_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteEtude_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteEtude_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteEtude(
              EtudeGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteEtude>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
      Assert.False(prereq.NotPlaying);
    }

    [Fact]
    public void PrerequisiteEtude_NotPlaying()
    {
      RunTest(
          PrerequisiteEtude_NotPlaying_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteEtude_NotPlaying_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteEtude(EtudeGuid, /* playing= */ false)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteEtude>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
      Assert.True(prereq.NotPlaying);
    }

    //----- Start: PrerequisiteFeature

    [Fact]
    public void PrerequisiteFeature()
    {
      RunTest(
          PrerequisiteFeature_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteFeature_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeature(FeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    [Fact]
    public void PrerequisiteFeature_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteFeature_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteFeature_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeature(
              FeatureGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    //----- Start: PrerequisiteFeaturesFromList

    [Fact]
    public void PrerequisiteFeaturesFromList()
    {
      RunTest(
          PrerequisiteFeaturesFromList_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteFeaturesFromList_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeaturesFromList(new string[] { FeatureGuid, ExtraFeatureGuid })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeaturesFromList>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.m_Features.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Equal(1, prereq.Amount);
    }

    [Fact]
    public void PrerequisiteFeaturesFromList_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteFeaturesFromList_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteFeaturesFromList_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeaturesFromList(
              new string[] { FeatureGuid, ExtraFeatureGuid },
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeaturesFromList>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.m_Features.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Equal(1, prereq.Amount);
    }

    [Fact]
    public void PrerequisiteFeaturesFromList_WithRequiredNumber()
    {
      RunTest(
          PrerequisiteFeaturesFromList_WithRequiredNumber_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteFeaturesFromList_WithRequiredNumber_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeaturesFromList(new string[] { FeatureGuid, ExtraFeatureGuid }, 2)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeaturesFromList>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.m_Features.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Equal(2, prereq.Amount);
    }

    //----- Start: PrerequisiteIsPet

    [Fact]
    public void PrerequisiteIsPet()
    {
      RunTest(
          PrerequisiteIsPet_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteIsPet_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteIsPet()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteIsPet>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteIsPet_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteIsPet_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteIsPet_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteIsPet(
              group: Prerequisite.GroupType.Any, checkInProgression: true, hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteIsPet>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteIsPet_Negated()
    {
      RunTest(
          PrerequisiteIsPet_Negated_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteIsPet_Negated_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteIsPet(/* negate= */ true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteIsPet>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.Not);
    }

    //----- Start: PrerequisiteMainCharacter

    [Fact]
    public void PrerequisiteMainCharacter()
    {
      RunTest(
          PrerequisiteMainCharacter_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteMainCharacter_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteMainCharacter()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteMainCharacter_ReplaceExisting()
    {
      RunTest(
          PrerequisiteMainCharacter_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteMainCharacter_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteCompanion()
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteMainCharacter()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteMainCharacter_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteMainCharacter_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteMainCharacter_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteMainCharacter(
              group: Prerequisite.GroupType.Any, checkInProgression: true, hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.False(prereq.Companion);
    }

    //----- Start: PrerequisiteCompanion

    [Fact]
    public void PrerequisiteCompanion()
    {
      RunTest(
          PrerequisiteCompanion_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCompanion_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCompanion()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteCompanion_ReplaceExisting()
    {
      RunTest(
          PrerequisiteCompanion_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCompanion_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteMainCharacter()
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteCompanion()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteCompanion_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteCompanion_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteCompanion_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteCompanion(
              group: Prerequisite.GroupType.Any, checkInProgression: true, hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.True(prereq.Companion);
    }

    //----- Start: PrerequisiteMythicLevel

    [Fact]
    public void PrerequisiteMythicLevel()
    {
      RunTest(
          PrerequisiteMythicLevel_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteMythicLevel_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(2)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMythicLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.Level);
    }

    [Fact]
    public void PrerequisiteMythicLevel_ReplaceExisting()
    {
      RunTest(
          PrerequisiteMythicLevel_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteMythicLevel_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(2)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(6)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMythicLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(6, prereq.Level);
    }

    [Fact]
    public void PrerequisiteMythicLevel_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteMythicLevel_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteMythicLevel_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(
              2,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMythicLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.Level);
    }

    //----- Start: RemoveSpellDescriptors

    [Fact]
    public void PrerequisiteNoArchetype()
    {
      RunTest(
          PrerequisiteNoArchetype_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNoArchetype_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoArchetype(ClassGuid, ArchetypeGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoArchetype>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
    }

    [Fact]
    public void PrerequisiteNoArchetype_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteNoArchetype_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNoArchetype_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoArchetype(
              ClassGuid,
              ArchetypeGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoArchetype>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
    }

    //----- Start: PrerequisiteNoClass

    [Fact]
    public void PrerequisiteNoClass()
    {
      RunTest(
          PrerequisiteNoClass_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNoClass_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoClass(ClassGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
    }

    [Fact]
    public void PrerequisiteNoClass_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteNoClass_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNoClass_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoClass(
              ClassGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoClassLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
    }

    //----- Start: PrerequisiteNoFeature

    [Fact]
    public void PrerequisiteNoFeature()
    {
      RunTest(
          PrerequisiteNoFeature_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNoFeature_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoFeature(FeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    [Fact]
    public void PrerequisiteNoFeature_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteNoFeature_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNoFeature_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoFeature(
              FeatureGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    //----- Start: PrerequisiteNotProficient

    [Fact]
    public void PrerequisiteNotProficient()
    {
      RunTest(
          PrerequisiteNotProficient_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNotProficient_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNotProficient>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteNotProficient_ReplaceExisting()
    {
      RunTest(
          PrerequisiteNotProficient_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNotProficient_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Sling, WeaponCategory.Starknife },
              new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Heavy })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNotProficient>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Sling, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Starknife, prereq.WeaponProficiencies);

      Assert.Single(prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Heavy, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteNotProficient_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteNotProficient_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteNotProficient_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              },
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNotProficient>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    //----- Start: PrerequisiteParameterizedSpellFeature

    [Fact]
    public void PrerequisiteParameterizedSpellFeature()
    {
      RunTest(
          PrerequisiteParameterizedSpellFeature_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedSpellFeature_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellFeature(FeatureGuid, AbilityGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.LearnSpell, prereq.ParameterType);
      Assert.Equal(TestAbility.ToReference<BlueprintAbilityReference>(), prereq.m_Spell);
    }

    [Fact]
    public void PrerequisiteParameterizedSpellFeature_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteParameterizedSpellFeature_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedSpellFeature_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellFeature(
              FeatureGuid,
              AbilityGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.LearnSpell, prereq.ParameterType);
      Assert.Equal(TestAbility.ToReference<BlueprintAbilityReference>(), prereq.m_Spell);
    }

    //----- Start: PrerequisiteParameterizedWeaponFeature

    [Fact]
    public void PrerequisiteParameterizedWeaponFeature()
    {
      RunTest(
          PrerequisiteParameterizedWeaponFeature_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedWeaponFeature_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponFeature(FeatureGuid, WeaponCategory.Sling)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.WeaponCategory, prereq.ParameterType);
      Assert.Equal(WeaponCategory.Sling, prereq.WeaponCategory);
    }

    [Fact]
    public void PrerequisiteParameterizedWeaponFeature_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteParameterizedWeaponFeature_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedWeaponFeature_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponFeature(
              FeatureGuid,
              WeaponCategory.Flail,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.WeaponCategory, prereq.ParameterType);
      Assert.Equal(WeaponCategory.Flail, prereq.WeaponCategory);
    }

    //----- Start: PrerequisiteParameterizedSpellSchoolFeature

    [Fact]
    public void PrerequisiteParameterizedSpellSchoolFeature()
    {
      RunTest(
          PrerequisiteParameterizedSpellSchoolFeature_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedSpellSchoolFeature_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellSchoolFeature(FeatureGuid, SpellSchool.Illusion)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.SpellSchool, prereq.ParameterType);
      Assert.Equal(SpellSchool.Illusion, prereq.SpellSchool);
    }

    [Fact]
    public void PrerequisiteParameterizedSpellSchoolFeature_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteParameterizedSpellSchoolFeature_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedSpellSchoolFeature_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellSchoolFeature(
              FeatureGuid,
              SpellSchool.Abjuration,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.SpellSchool, prereq.ParameterType);
      Assert.Equal(SpellSchool.Abjuration, prereq.SpellSchool);
    }

    //----- Start: PrerequisiteParameterizedWeaponSubcategory

    [Fact]
    public void PrerequisiteParameterizedWeaponSubcategory()
    {
      RunTest(
          PrerequisiteParameterizedWeaponSubcategory_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedWeaponSubcategory_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponSubcategory(FeatureGuid, WeaponSubCategory.Thrown)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedWeaponSubcategory>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(WeaponSubCategory.Thrown, prereq.SubCategory);
    }

    [Fact]
    public void PrerequisiteParameterizedWeaponSubcategory_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteParameterizedWeaponSubcategory_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteParameterizedWeaponSubcategory_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponSubcategory(
              FeatureGuid,
              WeaponSubCategory.Natural,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedWeaponSubcategory>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(WeaponSubCategory.Natural, prereq.SubCategory);
    }

    //----- Start: PrerequisitePet

    [Fact]
    public void PrerequisitePet()
    {
      RunTest(
          PrerequisitePet_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisitePet_Action()
    {
      GetConfigurator(Guid)
          .PrerequisitePet(PetType.AzataHavocDragon)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePet>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(PetType.AzataHavocDragon, prereq.Type);
      Assert.False(prereq.NoCompanion);
    }

    [Fact]
    public void PrerequisitePet_Negated()
    {
      RunTest(
          PrerequisitePet_Negated_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisitePet_Negated_Action()
    {
      GetConfigurator(Guid)
          .PrerequisitePet(PetType.AzataHavocDragon, negate: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePet>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(PetType.AzataHavocDragon, prereq.Type);
      Assert.True(prereq.NoCompanion);
    }

    [Fact]
    public void PrerequisitePet_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisitePet_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisitePet_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisitePet(
              PetType.AnimalCompanion,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePet>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(PetType.AnimalCompanion, prereq.Type);
      Assert.False(prereq.NoCompanion);
    }

    //----- Start: PrerequisitePlayerHasFeature

    [Fact]
    public void PrerequisitePlayerHasFeature()
    {
      RunTest(
          PrerequisitePlayerHasFeature_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisitePlayerHasFeature_Action()
    {
      GetConfigurator(Guid)
          .PrerequisitePlayerHasFeature(FeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePlayerHasFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    [Fact]
    public void PrerequisitePlayerHasFeature_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisitePlayerHasFeature_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisitePlayerHasFeature_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisitePlayerHasFeature(
              FeatureGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePlayerHasFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    //----- Start: PrerequisiteProficient

    [Fact]
    public void PrerequisiteProficient()
    {
      RunTest(
          PrerequisiteProficient_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteProficient_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteProficiency>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteProficient_ReplaceExisting()
    {
      RunTest(
          PrerequisiteProficient_ReplaceExisting_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteProficient_ReplaceExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Sling, WeaponCategory.Starknife },
              new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Heavy })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteProficiency>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Sling, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Starknife, prereq.WeaponProficiencies);

      Assert.Single(prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Heavy, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteProficient_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteProficient_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteProficient_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              },
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteProficiency>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    //----- Start: PrerequisiteStat

    [Fact]
    public void PrerequisiteStat()
    {
      RunTest(
          PrerequisiteStat_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteStat_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteStat(StatType.SaveWill, 5)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteStatValue>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(StatType.SaveWill, prereq.Stat);
      Assert.Equal(5, prereq.Value);
    }

    [Fact]
    public void PrerequisiteStat_WithCommonPrereqValues()
    {
      RunTest(
          PrerequisiteStat_WithCommonPrereqValues_Action,
          typeof(BlueprintArchetype),
          typeof(BlueprintCharacterClass),
          typeof(BlueprintFeature));
    }

    private void PrerequisiteStat_WithCommonPrereqValues_Action()
    {
      GetConfigurator(Guid)
          .PrerequisiteStat(
              StatType.SaveReflex,
              2,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteStatValue>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(StatType.SaveReflex, prereq.Stat);
      Assert.Equal(2, prereq.Value);
    }

    //----- Start: AddSpellDescriptors

    [Fact]
    public void AddSpellDescriptors()
    {
      RunTest(
          AddSpellDescriptors_Action,
          typeof(BlueprintAbility),
          typeof(BlueprintAbilityAreaEffect),
          typeof(BlueprintFeature),
          typeof(BlueprintBuff));
    }

    private void AddSpellDescriptors_Action()
    {
      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Fire, SpellDescriptor.Evil)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var descriptors = blueprint.GetComponent<SpellDescriptorComponent>();
      Assert.NotNull(descriptors);

      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Fire));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Evil));
    }

    [Fact]
    public void AddSpellDescriptors_WithExisting()
    {
      RunTest(
          AddSpellDescriptors_WithExisting_Action,
          typeof(BlueprintAbility),
          typeof(BlueprintAbilityAreaEffect),
          typeof(BlueprintFeature),
          typeof(BlueprintBuff));
    }

    private void AddSpellDescriptors_WithExisting_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Fire, SpellDescriptor.Evil)
          .Configure();

      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Law)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var descriptors = blueprint.GetComponent<SpellDescriptorComponent>();
      Assert.NotNull(descriptors);

      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Fire));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Evil));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Law));
    }

    //----- Start: RemoveSpellDescriptors

    [Fact]
    public void RemoveSpellDescriptors()
    {
      RunTest(
          RemoveSpellDescriptors_Action,
          typeof(BlueprintAbility),
          typeof(BlueprintAbilityAreaEffect),
          typeof(BlueprintFeature),
          typeof(BlueprintBuff));
    }

    private void RemoveSpellDescriptors_Action()
    {
      // First pass
      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Fire, SpellDescriptor.Evil)
          .Configure();

      GetConfigurator(Guid)
          .RemoveSpellDescriptors(SpellDescriptor.Fire)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var descriptors = blueprint.GetComponent<SpellDescriptorComponent>();
      Assert.NotNull(descriptors);

      Assert.False(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Fire));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Evil));
    }
  }
}
