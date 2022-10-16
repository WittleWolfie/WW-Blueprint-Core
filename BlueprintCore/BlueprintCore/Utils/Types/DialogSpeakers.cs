using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Util for building <c>DialogSpeaker</c>
  /// </summary>
  public static class DialogSpeakers
  {
    /// <summary>
    /// Creates a new <c>DialogSpeaker</c>.
    /// </summary>
    public static DialogSpeaker New(
      Blueprint<BlueprintUnitReference> speaker,
      Blueprint<BlueprintUnitReference> speakerPortrait = null,
      bool moveCamera = true,
      bool notRevealInFoW = false,
      bool switchDual = false)
    {
      return
        new DialogSpeaker()
        {
          m_Blueprint = speaker.Reference,
          m_SpeakerPortrait = speakerPortrait?.Reference ?? BlueprintTool.GetRef<BlueprintUnitReference>(null),
          MoveCamera = moveCamera,
          NotRevealInFoW = notRevealInFoW,
          SwitchDual = switchDual
        };
    }
  }
}
