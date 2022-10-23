using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;

namespace BlueprintCore.Utils.Types
{
  /// <summary>
  /// Util for creating <c>DamageTypeDescription</c>.
  /// </summary>
  public static class DamageTypes
  {
    public static DamageTypeDescription Energy(
      DamageEnergyType type, DamageAlignment alignment = 0, DamageRealityType reality = 0, bool precision = false)
    {
      var description = Create(DamageType.Energy, alignment, reality, precision);
      description.Energy = type;
      return description;
    }

    public static DamageTypeDescription Physical(
      PhysicalDamageMaterial material = 0,
      PhysicalDamageForm form = 0,
      int enhancement = 0,
      int enhancementTotal = 0,
      DamageAlignment alignment = 0,
      DamageRealityType reality = 0,
      bool precision = false)
    {
      var description = Create(DamageType.Physical, alignment, reality, precision);
      description.Physical.Enhancement = enhancement;
      description.Physical.EnhancementTotal = enhancementTotal;
      if (material > 0)
        description.Physical.Material = material;
      if (form > 0)
        description.Physical.Form = form;
      return description;
    }

    public static DamageTypeDescription Force(
      DamageAlignment alignment = 0, DamageRealityType reality = 0, bool precision = false)
    {
      return Create(DamageType.Force, alignment, reality, precision);
    }

    public static DamageTypeDescription Direct(
      DamageAlignment alignment = 0, DamageRealityType reality = 0, bool precision = false)
    {
      return Create(DamageType.Direct, alignment, reality, precision);
    }

    public static DamageTypeDescription Untyped(
      DamageAlignment alignment = 0, DamageRealityType reality = 0, bool precision = false)
    {
      return Create(DamageType.Untyped, alignment, reality, precision);
    }

    private static DamageTypeDescription Create(
      DamageType type, DamageAlignment alignment, DamageRealityType reality, bool precision)
    {
      var description = new DamageTypeDescription() { Type = type };
      description.Common.Precision = precision;
      if (alignment > 0)
        description.Common.Alignment = alignment;
      if (reality > 0)
        description.Common.Reality = reality;
      return description;
    }
  }
}
