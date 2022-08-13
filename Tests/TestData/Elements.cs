

using BlueprintCore.Utils;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;

namespace BlueprintCore.Test.TestData
{
  public static class Elements
  {
    public static readonly FloatConstant FloatConst = ElementTool.Create<FloatConstant>();
    public static readonly FloatConstant FloatConstAlt = ElementTool.Create<FloatConstant>();

    public static readonly IntConstant IntConst = ElementTool.Create<IntConstant>();
    public static readonly IntConstant IntConstAlt = ElementTool.Create<IntConstant>();
  }
}
