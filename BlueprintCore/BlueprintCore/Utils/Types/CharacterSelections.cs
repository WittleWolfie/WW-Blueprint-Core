using Kingmaker.DialogSystem;
using Kingmaker.EntitySystem.Stats;
using System.Linq;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Util for building <c>CharacterSelection</c>
  /// </summary>
  public static class CharacterSelections
  {
    /// <summary>
    /// Creates a new <c>CueSelection</c>.
    /// </summary>
    public static CharacterSelection New(CharacterSelection.Type type, params StatType[] comparisonStats)
    {
      return new CharacterSelection() { SelectionType = type, ComparisonStats = comparisonStats };
    }
  }
}
