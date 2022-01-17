using System.Text.RegularExpressions;

namespace BlueprintCore.Internal
{
  internal static class MatchExtensions
  {
    public static int GetEnd(this Match match) => match.Index + match.Length;
    public static (int Start, int End) GetBounds(this Match match) => (match.Index, match.GetEnd());
  }
}
