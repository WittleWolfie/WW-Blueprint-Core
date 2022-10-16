using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using System.Linq;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Util for building <c>CueSelection</c>
  /// </summary>
  public static class CueSelections
  {
    /// <summary>
    /// Creates a new <c>CueSelection</c> with the provided list of cues and <c>Strategy.Default</c>.
    /// </summary>
    /// 
    /// <remarks>Use <see cref="WithRandomStrategy(CueSelection)"/> to change the strategy.</remarks>
    public static CueSelection New(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      var selection = new CueSelection() { Cues = cues.Select(c => c.Reference).ToList() };
      return selection;
    }

    /// <summary>
    /// Sets the strategy to <c>Strategy.Random</c>. By default it is <c>Strategy.First</c>.
    /// </summary>
    public static CueSelection WithRandomStrategy(this CueSelection selection)
    {
      selection.Strategy = Strategy.Random;
      return selection;
    }
  }
}
