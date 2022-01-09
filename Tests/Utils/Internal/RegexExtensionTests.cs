using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlueprintCore.BlueprintCore.Utils.Internal;
using Xunit;

namespace BlueprintCore.Test.Utils.Internal;

public class RegexExtensionTests
{
  [Fact]
  public void SliceFromWorks()
  {
    const string sample = "Mary had a little lamb. Lamborghini! Brum brum!";
    Match match = Regex.Match(sample, @"lamb");
    var (before, matched, after) = match.SliceFrom(sample);
    var joined = before + matched + after;
    Assert.Equal(sample, joined);
  }
}
