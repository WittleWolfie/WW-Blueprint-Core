using BlueprintCore.Utils;
using Xunit;

namespace BlueprintCore.Test.Utils;

public class EncyclopediaToolTest
{
  // TODO: Check what tags like this: "{t|SourceRollDetails}" mean.

  #region DATA
  const string TaggedCase1 = "LocalizedString:ac47105f-7964-47f5-bde2-c799cee6fe06:You get a +1 {g|Encyclopedia:Bonus}bonus{/g} on {g|Encyclopedia:Attack}attack{/g} and {g|Encyclopedia:Damage}damage rolls{/g} with ranged weapons at ranges of up to 30 feet.";

  const string TaggedCase2 = "LocalizedString:22ff7210-9f57-43f0-a619-736449f9b8f7:These spiked gauntlets grant the wearer's animal companion (as well as Azata's dragon or Lich's skeletal champion) a +6 {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Strength}Strength{/g} {g|Encyclopedia:Ability_Scores}ability score{/g}. At the beginning of the battle, the creature must pass a {g|Encyclopedia:Saving_Throw}Will saving throw{/g} ({g|Encyclopedia:DC}DC{/g} 17) or start {g|Encyclopedia:Attack}attacking{/g} party members. If the initial saving throw is failed, the creature can make new saving throws each {g|Encyclopedia:Combat_Round}round{/g} to stop the effect.";

  const string TaggedCase3 = "LocalizedString:54f2985b-f688-431b-bd30-37296e0636a6:Every {g|Encyclopedia:Attack}attack{/g} during a combat entails the following calculations:\nFirst, the attacker makes an attack {g|Encyclopedia:Dice}roll{/g} and compares the result to the target's {g|Encyclopedia:Armor_Class}AC{/g} to see if the attack was a hit or a miss.\nIf the attack hits, the attackers make a {g|Encyclopedia:Damage}damage roll{/g} to see how much damage it deals.\nAttack is an attempt to harm an enemy during combat. To make an attack roll, you roll a d20, and then add various {g|Encyclopedia:Bonus}bonuses{/g} and {g|Encyclopedia:Penalty}penalties{/g}: from the equipped weapon, various abilities, active {g|Encyclopedia:Spell}spells{/g} and other factors. The sum of all these numbers make up the attack roll result that is then compared to the target's AC.\n{br}For example, in the last combat your character {t|SourceUnit} attacked the enemy {t|TargetUnit} and got {t|SourceRollPlusBonus}. Let's break down this result.\nRolling the d20 resulted in {t|SourceRoll}\n{t|SourceRollDetails}";

  const string UntaggedCase1 = "LocalizedString:ac47105f-7964-47f5-bde2-c799cee6fe06:You get a +1 bonus on attack and damage rolls with ranged weapons at ranges of up to 30 feet.";

  const string UntaggedCase2 = "LocalizedString:22ff7210-9f57-43f0-a619-736449f9b8f7:These spiked gauntlets grant the wearer's animal companion (as well as Azata's dragon or Lich's skeletal champion) a +6 bonus to Strength ability score. At the beginning of the battle, the creature must pass a Will saving throw (DC 17) or start attacking party members. If the initial saving throw is failed, the creature can make new saving throws each round to stop the effect.";

  const string UntaggedCase3 = "LocalizedString:54f2985b-f688-431b-bd30-37296e0636a6:Every attack during a combat entails the following calculations:\nFirst, the attacker makes an attack roll and compares the result to the target's AC to see if the attack was a hit or a miss.\nIf the attack hits, the attackers make a damage roll to see how much damage it deals.\nAttack is an attempt to harm an enemy during combat. To make an attack roll, you roll a d20, and then add various bonuses and penalties: from the equipped weapon, various abilities, active spells and other factors. The sum of all these numbers make up the attack roll result that is then compared to the target's AC.\n{br}For example, in the last combat your character {t|SourceUnit} attacked the enemy {t|TargetUnit} and got {t|SourceRollPlusBonus}. Let's break down this result.\nRolling the d20 resulted in {t|SourceRoll}\n{t|SourceRollDetails}";
  #endregion

  (string Tagged, string Untagged)[] Cases = new[] { (TaggedCase1, UntaggedCase1), (TaggedCase2, UntaggedCase2), (TaggedCase3, UntaggedCase3) };


  [Fact]
  public void EncyclopediaEntriesLoad()
  {
    Assert.True(EncyclopediaTool.EncyclopediaEntries.Length > 0);
    Assert.True(!string.IsNullOrEmpty(EncyclopediaTool.EncyclopediaEntries[0].Entry));
    Assert.True(EncyclopediaTool.EncyclopediaEntries[0].Patterns.Count > 0);
  }

  [Fact]
  public void TaggingWorks()
  {
    foreach (var (tagged, untagged) in Cases)
    {
      Assert.Equal(tagged, EncyclopediaTool.TagEncyclopediaEntries(untagged));
    }
  }

  [Fact]
  public void UntaggingWorks()
  {
    foreach (var (tagged, untagged) in Cases)
    {
      Assert.Equal(untagged, EncyclopediaTool.UntagEncyclopediaEntries(tagged));
    }
  }
}
