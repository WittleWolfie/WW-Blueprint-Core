using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.StoryEx;
using BlueprintCore.Test.Asserts;
using BlueprintCore.Utils;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.StoryEx
{
  public class ActionsBuilderStoryExTest : TestBase
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void CompleteEtude()
    {
      var actions = ActionsBuilder.New().CompleteEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.False(completeEtude.Evaluate);
    }

    [Fact]
    public void CompleteEtude_WithEvaluator()
    {
      var evaluator = ElementTool.Create<Dialog>();

      var actions = ActionsBuilder.New().CompleteEtude(EtudeGuid, evaluator: evaluator).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.Equal(evaluator, completeEtude.EtudeEvaluator);
      Assert.True(completeEtude.Evaluate);
    }

    [Fact]
    public void ChangeRomance()
    {
      var value = ElementTool.Create<IntConstant>();
      value.Value = 12;

      var actions = ActionsBuilder.New().ChangeRomance(RomanceGuid, value).Build();

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

      var actions = ActionsBuilder.New().ChangeUnitName(TestUnit, name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(TestUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ChangeUnitName_WithAppendName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions =
          ActionsBuilder.New().ChangeUnitName(TestUnit, name, appendName: true).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(TestUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.True(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ResetUnitName()
    {
      var actions = ActionsBuilder.New().ResetUnitName(TestUnit).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(TestUnit, changeName.Unit);
      Assert.False(changeName.AddToTheName);
      Assert.True(changeName.ReturnTheOldName);
    }
  }
}
