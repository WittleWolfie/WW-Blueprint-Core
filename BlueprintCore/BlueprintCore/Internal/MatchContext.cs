using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlueprintCore.BlueprintCore.Internal;

internal class MatchContext
{
  public Match Match { get; }
  public string OriginalText { get; }
  public string Preceding { get; }
  public string Following { get; }

  public MatchContext(Match match, string originalText)
  {
    Match = match;
    OriginalText = originalText;
    Preceding = OriginalText.Substring(0, Match.Index);
    Following = OriginalText.Substring(Match.GetEnd());
  }

  public bool IsMatchStandaloneWord()
  {
    bool precedingOk = Preceding.Length > 0 ? char.IsWhiteSpace(Preceding.Last()) || char.IsPunctuation(Preceding.Last()) : true;
    bool followingOk = Following.Length > 0 ? char.IsWhiteSpace(Following.First()) || char.IsPunctuation(Following.First()) : true;

    return precedingOk && followingOk;
  }
}
