using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCore.BlueprintCore.Utils.Internal;

internal static class EnumerableExtensions
{
  // O(n * log n) time complexity. But more convenient.
  public static IEnumerable<T> Distinct<T>(this IEnumerable<T> seq, Comparison<T> comparison)
  {
    SortedSet<T> unique = new SortedSet<T>(Comparer<T>.Create(comparison));
    foreach (T val in seq)
    {
      if (!unique.Contains(val))
      {
        unique.Add(val);
        yield return val;
      }
    }
  }

  public static IEnumerable<(int, T)> Enumerate<T>(this IEnumerable<T> seq)
  {
    int i = 0;
    foreach (var val in seq)
    {
      yield return (i, val);
      i++;
    }
  }
}
