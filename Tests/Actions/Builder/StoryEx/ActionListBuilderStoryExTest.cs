using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.StoryEx;
using BlueprintCore.Tests.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Xunit;

namespace BlueprintCore.Tests.Actions.Builder.StoryEx
{
  public class ActionListBuilderStoryExTest : ActionListBuilderTestBase
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void CompleteEtude()
    {
      var actions = ActionListBuilder.New().CompleteEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.False(completeEtude.Evaluate);
    }

    [Fact]
    public void CompleteEtude_WithEvaluator()
    {
      var evaluator = ElementTool.Create<Dialog>();

      var actions = ActionListBuilder.New().CompleteEtude(EtudeGuid, evaluator: evaluator).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.Equal(evaluator, completeEtude.EtudeEvaluator);
      Assert.True(completeEtude.Evaluate);
    }

    [Fact]
    public void ChangeRomance()
    {
      var value = ElementTool.Create<IntConstant>();
      value.Value = 12;

      var actions = ActionListBuilder.New().ChangeRomance(RomanceGuid, value).Build();

      Assert.Single(actions.Actions);
      var changeRomance = (ChangeRomance)actions.Actions[0];
      ElementAsserts.IsValid(changeRomance);

      Assert.Equal(
          Romance.ToReference<BlueprintRomanceCounterReference>(), changeRomance.m_Romance);
      Assert.Equal(12, changeRomance.ValueEvaluator.GetValue());
    }

    [Fact]
    public void ChangeUnitName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions = ActionListBuilder.New().ChangeUnitName(ClickedUnit, name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ChangeUnitName_WithAppendName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions =
          ActionListBuilder.New().ChangeUnitName(ClickedUnit, name, appendName: true).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.True(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ResetUnitName()
    {
      var actions = ActionListBuilder.New().ResetUnitName(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.False(changeName.AddToTheName);
      Assert.True(changeName.ReturnTheOldName);
    }
  }
}
