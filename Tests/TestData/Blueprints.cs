using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Test.TestData
{
  public static class Blueprints
  {
    public static readonly Blueprint<BlueprintArchetypeReference> Archetype = Guids.Archetype;
    public static readonly Blueprint<BlueprintArchetypeReference> ArchetypeAlt = Guids.ArchetypeAlt;

    public static readonly Blueprint<BlueprintBuffReference> Buff = Guids.Buff;

    public static readonly Blueprint<BlueprintCharacterClassReference> Clazz = Guids.Class;
    public static readonly Blueprint<BlueprintCharacterClassReference> ClazzAlt = Guids.ClassAlt;

    public static readonly Blueprint<BlueprintFeatureReference> Feature = Guids.Feature;
    public static readonly Blueprint<BlueprintFeatureReference> FeatureAlt = Guids.FeatureAlt;
    public static readonly Blueprint<BlueprintFeatureBaseReference> FeatureBase = Guids.FeatureBase;
    public static readonly Blueprint<BlueprintFeatureBaseReference> FeatureBaseAlt = Guids.FeatureBaseAlt;

    public static readonly Blueprint<BlueprintUnitPropertyReference> Property = Guids.Property;
    public static readonly Blueprint<BlueprintUnitPropertyReference> PropertyAlt = Guids.PropertyAlt;
  }
}
