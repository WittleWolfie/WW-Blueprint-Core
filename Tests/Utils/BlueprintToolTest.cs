using System;
using System.Collections.Generic;
using BlueprintCore.Utils;
using Xunit;

namespace BlueprintCore.Test.Blueprints
{
  [Collection("Harmony")]
  public class BlueprintToolTest
  {
    private static readonly string UnusedGuid = "137f7548-e57f-4e4a-8d76-7f2d174c6d5d";

    //----- BlueprintAbility (By Name) -----//
    private static readonly string AbilityGuid = "0897de3e-4097-4cfa-bcfc-755119e36bf7";
    private BlueprintAbility Ability;

    //----- BlueprintBuff (By Name)  -----//
    private static readonly string BuffGuid = "efcfcdbe-2988-4ab4-941f-2d81f02e1e0b";
    private BlueprintBuff Buff;

    //----- BlueprintFeature -----//
    private static readonly string FeatureGuid = "43a37f22-fc6a-44e9-b66e-d3dd41ef6ebc";
    private BlueprintFeature Feature;

    public BlueprintToolTest() : base()
    {
      BlueprintPatch.Init();
      LoggerPatch.Logger.Reset();

      Ability = BlueprintPatch.Create<BlueprintAbility>(AbilityGuid);
      Buff = BlueprintPatch.Create<BlueprintBuff>(BuffGuid);
      Feature = BlueprintPatch.Create<BlueprintFeature>(FeatureGuid);
    }

    [Fact]
    public void AddGuidsByName()
    {
      BlueprintTool.AddGuidsByName(("Ability", AbilityGuid), ("Buff", BuffGuid));

      Assert.Equal(Ability, BlueprintTool.Get<BlueprintAbility>("Ability"));
      Assert.Equal(Buff, BlueprintTool.Get<BlueprintBuff>("Buff"));
      Assert.ThrowsAny<Exception>(() => BlueprintTool.Get<BlueprintFeature>("Feature"));
    }

    [Fact]
    public void AddGuidsByName_UsingDictionary()
    {
      BlueprintTool.AddGuidsByName(
          new Dictionary<string, string> { { "Buff", BuffGuid }, { "Feature", FeatureGuid } });

      Assert.Equal(Buff, BlueprintTool.Get<BlueprintBuff>("Buff"));
      Assert.Equal(Feature, BlueprintTool.Get<BlueprintFeature>("Feature"));
      Assert.ThrowsAny<Exception>(() => BlueprintTool.Get<BlueprintAbility>("Ability"));
    }

    [Fact]
    public void AddGuidsByName_WithSafeCollision()
    {
      BlueprintTool.AddGuidsByName(("Ability", AbilityGuid));

      BlueprintTool.AddGuidsByName(("Ability", AbilityGuid));

      Assert.NotNull(BlueprintTool.Get<BlueprintAbility>("Ability"));
    }

    [Fact]
    public void AddGuidsByName_WithUnSafeCollision()
    {
      BlueprintTool.AddGuidsByName(("Ability", AbilityGuid));

      Assert.Throws<InvalidOperationException>(
          () => BlueprintTool.AddGuidsByName(("Ability", BuffGuid)));
    }

    [Fact]
    public void Create()
    {
      var blueprint = BlueprintTool.Create<BlueprintBuff>("Buff", UnusedGuid);

      Assert.Equal("Buff", blueprint.name);
      Assert.Equal(blueprint, BlueprintTool.Get<BlueprintBuff>(UnusedGuid));
    }

    [Fact]
    public void Create_AlreadyExists()
    {
      Assert.Throws<InvalidOperationException>(
          () => BlueprintTool.Create<BlueprintBuff>("Buff", BuffGuid));
    }

    [Fact]
    public void Create_ByName()
    {
      // Add mapping first
      BlueprintTool.AddGuidsByName(("Buff", UnusedGuid));

      var blueprint = BlueprintTool.Create<BlueprintBuff>("Buff");

      Assert.Equal("Buff", blueprint.name);
      Assert.Equal(blueprint, BlueprintTool.Get<BlueprintBuff>("Buff"));
    }

    [Fact]
    public void Create_ByName_WithoutGuidByName()
    {
      Assert.ThrowsAny<Exception>(() => BlueprintTool.Create<BlueprintBuff>("Buff"));
    }

    [Fact]
    public void Get()
    {
      Assert.NotNull(BlueprintTool.Get<BlueprintAbility>(AbilityGuid));
    }

    [Fact]
    public void Get_DoesNotExist()
    {
      Assert.Throws<InvalidOperationException>(() => BlueprintTool.Get<BlueprintBuff>(UnusedGuid));
    }

    [Fact]
    public void Get_WrongType()
    {
      Assert.Throws<InvalidOperationException>(() => BlueprintTool.Get<BlueprintBuff>(AbilityGuid));
    }

    [Fact]
    public void Get_ByName()
    {
      // Add mapping first
      BlueprintTool.AddGuidsByName(("Buff", BuffGuid));

      Assert.NotNull(BlueprintTool.Get<BlueprintBuff>("Buff"));
    }

    [Fact]
    public void Get_ByName_WithoutGuidByName()
    {
      Assert.ThrowsAny<Exception>(() => BlueprintTool.Get<BlueprintBuff>("Buff"));
    }

    [Fact]
    public void GetRef()
    {
      var blueprintRef = BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityGuid);

      Assert.Equal(BlueprintGuid.Parse(AbilityGuid), blueprintRef.deserializedGuid);
    }

    [Fact]
    public void GetRef_NullGuid()
    {
      var blueprintRef = BlueprintTool.GetRef<BlueprintAbilityReference>(null);

      Assert.Equal(BlueprintGuid.Empty, blueprintRef.deserializedGuid);
    }

    [Fact]
    public void GetRef_DoesNotExist()
    {
      var blueprintRef = BlueprintTool.GetRef<BlueprintAbilityReference>(UnusedGuid);

      Assert.Equal(BlueprintGuid.Parse(UnusedGuid), blueprintRef.deserializedGuid);
    }

    [Fact]
    public void GetRef_ByName()
    {
      // Add mapping first
      BlueprintTool.AddGuidsByName(("Buff", BuffGuid));

      var blueprintRef = BlueprintTool.GetRef<BlueprintBuffReference>("Buff");

      Assert.Equal(BlueprintGuid.Parse(BuffGuid), blueprintRef.deserializedGuid);
    }

    [Fact]
    public void GetRef_ByName_WithoutGuidByName()
    {
      Assert.ThrowsAny<Exception>(() => BlueprintTool.GetRef<BlueprintBuffReference>("Buff"));
    }
  }
}
