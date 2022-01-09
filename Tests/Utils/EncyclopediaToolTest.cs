using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.BlueprintCore.Utils;
using Xunit;

namespace BlueprintCore.Test.Utils;

public class EncyclopediaToolTest
{
  [Fact]
  public void EncyclopediaEntriesLoad()
  {
    Assert.True(EncyclopediaTool.EncyclopediaEntries.Length > 0);
    Assert.True(string.IsNullOrEmpty(EncyclopediaTool.EncyclopediaEntries[0].Entry));
    Assert.True(EncyclopediaTool.EncyclopediaEntries[0].Patterns.Count > 0);
  }
}
