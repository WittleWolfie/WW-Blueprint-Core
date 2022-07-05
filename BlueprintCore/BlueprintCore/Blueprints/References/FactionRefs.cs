using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintFaction blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class FactionRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> AngelTeam = "ff7b854fc400a64419f4f45273eed7ee";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Attack_everyone = "f69acd336dd8e2b4ca9e9618c7142658";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Bandits = "28460a5d00a62b742b80c90c37559644";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Bosses = "2d609e6d09b676345a878f4266f408f0";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Civilians = "5b8795a258cf0244c9ebae471e399d3a";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Crusaders = "9b14690df00add445a925445562c69f4";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> CutsceneNeutrals = "d64258e86eeb1d8479f35a9b16f6590a";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Demons = "26140a3088fadfb44ab11601d5e16113";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> DrezenChorussina = "2648700405e96f049988ac15fd5da6a9";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> DrezenCultists = "c393ee9c1e09f114f907819cb3296468";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> DummyFaction = "f53d9de2a5cd4144596a0ef9e26ffa9c";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> FireRaisingDH = "beea40746983fb4419fb87cf6493c39c";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> FireRaisingTargetDH = "ac0404156a3e64140b75eddff416e15b";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Friends = "4e1f333e518d4794bb41b025e991edb0";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> HellsDecreeAbilityTargetedRageFaction = "cd8d42c97e3dc134193cb8d5d4d35a73";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> HelpingPlayer = "31359684b6f0ca9438e1fd6be6766cb0";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> IvorySanctum_BaphometGroup = "14bbfd021a3168844bb51ad1ac02729a";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> IvorySanctum_DeskariGroup = "30aba4d88481d964a83b67cd5c4f92a0";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Militia = "305b44ce6a0d11f478e718977027c8b3";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Mobs = "0f539babafb47fe4586b719d02aff7c4";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> NeutralGuards = "419c5165bae99664b92252b7dcc0a2db";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Neutrals = "d8de50cc80eb4dc409a983991e0b77ad";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Ooze = "24a215bb66e34153b4d648829c088ae6";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Ooze_dlc2 = "85e3fd9173cb404997c6f9bc1742e117";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> PerpetuallyAnnoyedFaction = "572cce024818db7409655b91e971907b";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Player = "72f240260881111468db610b6c37c099";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> PrologueTeam1 = "04931988cfcd3f441a5f3db8ba1d2305";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> PrologueTeam2 = "ec0392b15ca923b4a9e9a25505b62f64";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Revolutioners = "02112ecbc15d79e458704b85113b51e8";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Slaves = "d46ea2ccf90a9a3448d3e85086a239ad";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Summoned = "1b08d9ed04518ec46a9b3e4e23cb5105";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> TheIvoryLabyrinth_ApoGroup = "ba56a2c4a601f7244a1adcfff86ecd3c";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> TheIvoryLabyrinth_SvenGroup = "d7c9aad4e3188674d96cb1499d84e60d";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> Traps = "d75c5993785785d468211d9a1a3c87a6";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> TrueNeutrals = "6e3318c9f3f1b044c8e72823ba2f9000";
    public static readonly Blueprint<BlueprintReference<BlueprintFaction>> WildAnimals = "b1525b4b33efe0241b4cbf28486cd2cc";

    public static readonly List<Blueprint<BlueprintReference<BlueprintFaction>>> All =
      new()
      {
          AngelTeam,
          Attack_everyone,
          Bandits,
          Bosses,
          Civilians,
          Crusaders,
          CutsceneNeutrals,
          Demons,
          DrezenChorussina,
          DrezenCultists,
          DummyFaction,
          FireRaisingDH,
          FireRaisingTargetDH,
          Friends,
          HellsDecreeAbilityTargetedRageFaction,
          HelpingPlayer,
          IvorySanctum_BaphometGroup,
          IvorySanctum_DeskariGroup,
          Militia,
          Mobs,
          NeutralGuards,
          Neutrals,
          Ooze,
          Ooze_dlc2,
          PerpetuallyAnnoyedFaction,
          Player,
          PrologueTeam1,
          PrologueTeam2,
          Revolutioners,
          Slaves,
          Summoned,
          TheIvoryLabyrinth_ApoGroup,
          TheIvoryLabyrinth_SvenGroup,
          Traps,
          TrueNeutrals,
          WildAnimals,
      };
  }
}
