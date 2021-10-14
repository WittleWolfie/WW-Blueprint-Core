using BlueprintCore.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace BlueprintCore.Utils
{
  /** Helper class for creating contextValues. */
  public static class ContextValues
  {
    public static ContextValue Simple(int value)
    {
      return new ContextValue { ValueType = ContextValueType.Simple, Value = value };
    }

    public static ContextValue Rank(AbilityRankType type)
    {
      return new ContextValue { ValueType = ContextValueType.Rank, ValueRank = type };
    }

    public static ContextValue Shared(AbilitySharedValue type)
    {
      return new ContextValue { ValueType = ContextValueType.Shared, ValueShared = type };
    }

    public static ContextValue Property(UnitProperty property, bool toCaster = false)
    {
      return new ContextValue
      {
        ValueType = toCaster ? ContextValueType.CasterProperty : ContextValueType.TargetProperty,
        Property = property
      };
    }

    public static ContextValue CustomProperty(string property, bool toCaster = false)
    {
      return new ContextValue
      {
        ValueType =
            toCaster ? ContextValueType.CasterProperty : ContextValueType.TargetProperty,
        m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(property)
      };
    }
  }
}