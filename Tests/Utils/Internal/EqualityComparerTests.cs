using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.BlueprintCore.Utils.Internal;
using Xunit;

namespace BlueprintCore.Test.Utils.Internal;

public class EqualityComparerTests
{
  [Fact]
  public void EqualityComparerWorks()
  {
    var sample = new[] { "Mary", "had", "a", "mary", "lamb", "dumb?" };
    var comparer = EqualityComparerExtensions.CreateEqualityComparer<string>(
      StringComparer.InvariantCultureIgnoreCase.Equals,
      StringComparer.InvariantCultureIgnoreCase.GetHashCode);
    var unique = sample.Distinct(comparer).Count();
    Assert.Equal(5, unique);
  }
}
