using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlueprintCore.BlueprintCore.Extensions;

internal static class MatchExtensions
{
  public static int GetEnd(this Match match) => match.Index + match.Length;
  public static (int Start, int End) GetBounds(this Match match) => (match.Index, match.GetEnd());
}
