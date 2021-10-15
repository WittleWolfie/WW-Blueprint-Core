using System;
using System.Runtime.Serialization;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.NewEx;
using BlueprintCore.Actions.New;
using BlueprintCore.Blueprints;
using BlueprintCore.Tests.Asserts;
using Kingmaker.AI.Blueprints;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;
using Xunit;

namespace BlueprintCore.Tests.Blueprints
{
  [Collection("Harmony")]
  public abstract class BlueprintConfiguratorTest<T, TBuilder> : IDisposable
      where T : BlueprintScriptableObject
      where TBuilder : BlueprintConfigurator<T, TBuilder>
  {
    // Serves as the guid for the primary test blueprint. Concrete child classes must instantiate
    // create and register a blueprint using this guid;
    protected static readonly string Guid = "137f7548-e57f-4e4a-8d76-7f2d174c6d5d";

    //----- BlueprintAbility -----//
    protected static readonly string AbilityGuid = "0897de3e-4097-4cfa-bcfc-755119e36bf7";
    protected readonly BlueprintAbility Ability = CreateBlueprint<BlueprintAbility>(AbilityGuid);

    protected static readonly string ExtraAbilityGuid = "9292a096-a5ad-446e-a199-d62014a73391";
    protected readonly BlueprintAbility ExtraAbility =
        CreateBlueprint<BlueprintAbility>(ExtraAbilityGuid);

    protected static readonly string AnotherAbilityGuid = "f3fba7a2-a64e-44a4-a6de-9333c3409807";
    protected readonly BlueprintAbility AnotherAbility =
        CreateBlueprint<BlueprintAbility>(AnotherAbilityGuid);

    //----- BlueprintAiCastSpell -----//
    protected static readonly string AiCastSpellGuid = "ffbe7e22-1b9d-4ced-80d4-22d96887a62d";
    protected readonly BlueprintAiCastSpell AiCastSpell =
        CreateBlueprint<BlueprintAiCastSpell>(AiCastSpellGuid);

    //----- BlueprintArchetype -----//
    protected static readonly string ArchetypeGuid = "e6a3b7d6-1a5f-4852-8dca-e50e14f57ea7";
    protected readonly BlueprintArchetype Archetype =
        CreateBlueprint<BlueprintArchetype>(ArchetypeGuid);

    protected static readonly string ExtraArchetypeGuid = "e449b280-532f-45c9-9f63-ceec44fa909c";
    protected readonly BlueprintArchetype ExtraArchetype =
        CreateBlueprint<BlueprintArchetype>(ExtraArchetypeGuid);

    //----- BlueprintBuff -----//
    protected static readonly string BuffGuid = "efcfcdbe-2988-4ab4-941f-2d81f02e1e0b";
    protected readonly BlueprintBuff Buff = CreateBlueprint<BlueprintBuff>(BuffGuid);

    protected static readonly string ExtraBuffGuid = "4d6ceec1-c5c5-4043-a766-347fed4ed2e3";
    protected readonly BlueprintBuff ExtraBuff = CreateBlueprint<BlueprintBuff>(ExtraBuffGuid);

    //----- BlueprintCharacterClass -----//
    protected static readonly string ClassGuid = "7c05a373-6efe-4730-a0f3-c997ac1e1759";
    protected readonly BlueprintCharacterClass Clazz =
        CreateBlueprint<BlueprintCharacterClass>(ClassGuid);

    protected static readonly string ExtraClassGuid = "47a46eba-c4c6-44cc-9809-20b4d6ad8d41";
    protected readonly BlueprintCharacterClass ExtraClass =
        CreateBlueprint<BlueprintCharacterClass>(ExtraClassGuid);

    //----- BlueprintEtude -----//
    protected static readonly string EtudeGuid = "8c1589b0-f30c-488c-bd88-4fd90ea40113";
    protected readonly BlueprintEtude Etude = CreateBlueprint<BlueprintEtude>(EtudeGuid);

    protected static readonly string ExtraEtudeGuid = "284819da-8952-4ded-a2b5-cfc4aee7ba01";
    protected BlueprintEtude ExtraEtude =
        CreateBlueprint<BlueprintEtude>(ExtraEtudeGuid);

    //----- BlueprintFeature -----//
    protected static readonly string FeatureGuid = "43a37f22-fc6a-44e9-b66e-d3dd41ef6ebc";
    protected readonly BlueprintFeature Feature = CreateBlueprint<BlueprintFeature>(FeatureGuid);

    protected static readonly string ExtraFeatureGuid = "d43e5551-054a-488b-a8fa-97826b5df653";
    protected readonly BlueprintFeature ExtraFeature =
        CreateBlueprint<BlueprintFeature>(ExtraFeatureGuid);

    //----- BlueprintParametrizedFeature -----//
    protected static readonly string ParameterizedFeatureGuid =
        "80b7137f-2404-450b-a361-6e125297f4c3";
    protected readonly BlueprintParametrizedFeature ParameterizedFeature =
        CreateBlueprint<BlueprintParametrizedFeature>(ParameterizedFeatureGuid);
    protected static readonly string ExtraParameterizedFeatureGuid =
        "0e195595-459a-405d-8c61-1e8365b12418";
    protected readonly BlueprintParametrizedFeature ExtraParameterizedFeature =
        CreateBlueprint<BlueprintParametrizedFeature>(ExtraParameterizedFeatureGuid);

    //----- BlueprintUnitFact -----//
    protected static readonly string FactGuid = "f7dba63d-9b33-436d-9841-ca2821b89a1b";
    protected readonly BlueprintUnitFact Fact = CreateBlueprint<BlueprintUnitFact>(FactGuid);

    protected static readonly string ExtraFactGuid = "06d8783f-3b21-4b79-b2d0-061d13f30768";
    protected readonly BlueprintUnitFact ExtraFact =
        CreateBlueprint<BlueprintUnitFact>(ExtraFactGuid);

    //----- Common Objects -----// 
    protected readonly Sprite Sprite =
        (Sprite)FormatterServices.GetUninitializedObject(typeof(Sprite));

    protected BlueprintConfiguratorTest() { }

    public void Dispose()
    {
      BlueprintPatch.Clear();
      LoggerPatch.Logger.Reset();
    }

    protected static TBlueprint CreateBlueprint<TBlueprint>(string guid)
        where TBlueprint : SimpleBlueprint, new()
    {
      var blueprint = Util.Create<TBlueprint>(guid);
      BlueprintPatch.Add(blueprint);
      return blueprint;
    }

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

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
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

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
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

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
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
      Assert.Contains(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
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
      Assert.Contains(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
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
      Assert.Contains(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.LearnSpell, prereq.ParameterType);
      Assert.Equal(Ability.ToReference<BlueprintAbilityReference>(), prereq.m_Spell);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.LearnSpell, prereq.ParameterType);
      Assert.Equal(Ability.ToReference<BlueprintAbilityReference>(), prereq.m_Spell);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
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
