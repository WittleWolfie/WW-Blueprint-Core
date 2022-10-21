using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Utility;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities
{
  /// <summary>
  /// Maps to each spell list supported by <see cref="AbilityConfigurator.AddToSpellLists(int, SpellList[])"/>.
  /// </summary>
  public enum SpellList
  {
    Aeon,
    AeonMythic,
    AirDomain,
    Alchemist,
    Angel,
    AngelMythic,
    AnimalDomain,
    ArmagsBlade,
    ArtificeDomain,
    Azata,
    AzataMythic,
    Bard,
    BattleSpirit,
    Bloodrager,
    BonesSpirit,
    ChaosDomain,
    CharmDomain,
    Cleric,
    CommunityDomain,
    DarknessDomain,
    DeathDomain,
    Demon,
    DemonMythic,
    DestructionDomain,
    Druid,
    EarthDomain,
    EvilDomain,
    Feyspeaker,
    FireDomain,
    FlamesSpirit,
    FrostSpirit,
    GloryDomain,
    GoodDomain,
    HealingDomain,
    Hunter,
    Inquisitor,
    KnowledgeDomain,
    LawDomain,
    LiberationDomain,
    Lich,
    LichBardMinor,
    LichInquisitorMinor,
    LichMythic,
    LifeSpirit,
    LuckDomain,
    MadnessDomain,
    MagicDomain,
    Magus,
    NatureSpirit,
    NobilityDomain,
    Paladin,
    PlantDomain,
    ProtectionDomain,
    Ranger,
    ReposeDomain,
    RuneDomain,
    Shaman,
    SpiritWarden,
    StoneSpirit,
    StrengthDomain,
    SunDomain,
    TravelDomain,
    TrickeryDomain,
    Trickster,
    TricksterMythic,
    WarDomain,
    Warpriest,
    WaterDomain,
    WavesSpirit,
    WeatherDomain,
    WindSpirit,
    Witch,
    Wizard,
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintAbility"/>.
  /// </summary>
  /// <inheritdoc/>
  public class AbilityConfigurator : BaseAbilityConfigurator<BlueprintAbility, AbilityConfigurator>
  {
    private AbilityConfigurator(Blueprint<BlueprintReference<BlueprintAbility>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static AbilityConfigurator For(Blueprint<BlueprintReference<BlueprintAbility>> blueprint)
    {
      return new AbilityConfigurator(blueprint);
    }
    
    // TODO:
    //  - AddToSpellList(): Create SpellListComponent and update spell list.
    //    - Make sure to handle things like Thassilonian and MysticTheurge correctly
    //  - AddCraftInfo(): Setup craft stuff

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static AbilityConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbility>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Spell specific version of <see cref="New(string, string)"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Sets the ability type to <c>AbilityType.Spell</c>.
    /// </para>
    /// <para>
    /// TODO: See also the other utility methods for managing spells.
    /// </para>
    /// </remarks>
    /// <param name="school">Adds a matching <c>SpellComponent</c></param>
    /// <param name="spellDescriptors">If specified, adds a <c>SpellDescriptorComponent</c> with </param>
    /// <param name="canSpecialize">
    /// Set this to true if the spell is a valid target for Spell Specialization to update those selections.
    /// </param>
    public static AbilityConfigurator NewSpell(
      string name,
      string guid,
      SpellSchool school,
      bool canSpecialize = true,
      params SpellDescriptor[] spellDescriptors)
    {
      var configurator = New(name, guid);
      configurator.SetType(AbilityType.Spell).AddSpellComponent(school);
      if (spellDescriptors.Any())
        configurator.AddSpellDescriptorComponent(spellDescriptors.Aggregate((result, flag) => result | flag));

      if (canSpecialize)
        configurator.OnConfigure(bp => AddToSpellSpecialization(bp));

      return configurator;
    }

    private static readonly Dictionary<SpellList, string> SpellListGuids =
      new()
      {
        { SpellList.Aeon, SpellListRefs.AeonSpellList.ToString() },
        { SpellList.AeonMythic, SpellListRefs.AeonSpellMythicList.ToString() },
        { SpellList.AirDomain, SpellListRefs.AirDomainSpellList.ToString() },
        { SpellList.Alchemist, SpellListRefs.AlchemistSpellList.ToString() },
        { SpellList.Angel, SpellListRefs.AngelClericSpelllist.ToString() },
        { SpellList.AngelMythic, SpellListRefs.AngelMythicSpelllist.ToString() },
        { SpellList.AnimalDomain, SpellListRefs.AnimalDomainSpellList.ToString() },
        { SpellList.ArmagsBlade, SpellListRefs.ArmagsBladeSpellList.ToString() },
        { SpellList.ArtificeDomain, SpellListRefs.ArtificeDomainSpellList.ToString() },
        { SpellList.Bard, SpellListRefs.BardSpellList.ToString() },
        { SpellList.BattleSpirit, SpellListRefs.BattleSpiritSpellList.ToString() },
        { SpellList.Bloodrager, SpellListRefs.BloodragerSpellList.ToString() },
        { SpellList.BonesSpirit, SpellListRefs.BonesSpiritSpellList.ToString() },
        { SpellList.ChaosDomain, SpellListRefs.ChaosDomainSpellList.ToString() },
        { SpellList.CharmDomain, SpellListRefs.ChaosDomainSpellList.ToString() },
        { SpellList.Cleric, SpellListRefs.ClericSpellList.ToString() },
        { SpellList.CommunityDomain, SpellListRefs.CommunityDomainSpellList.ToString() },
        { SpellList.DarknessDomain, SpellListRefs.DarknessDomainSpellList.ToString() },
        { SpellList.DeathDomain, SpellListRefs.DeathDomainSpellList.ToString() },
        { SpellList.Demon, SpellListRefs.DemonUsualSpelllist.ToString() },
        { SpellList.DemonMythic, SpellListRefs.DemonSpelllist.ToString() },
        { SpellList.DestructionDomain, SpellListRefs.DestructionDomainSpellList.ToString() },
        { SpellList.Druid, SpellListRefs.DruidSpellList.ToString() },
        { SpellList.EarthDomain, SpellListRefs.EarthDomainSpellList.ToString() },
        { SpellList.EvilDomain, SpellListRefs.EvilDomainSpellList.ToString() },
        { SpellList.Feyspeaker, SpellListRefs.FeyspeakerSpelllist.ToString() },
        { SpellList.FireDomain, SpellListRefs.FireDomainSpellList.ToString() },
        { SpellList.FlamesSpirit, SpellListRefs.FlamesSpiritSpellList.ToString() },
        { SpellList.FrostSpirit, SpellListRefs.FrostSpiritSpellList.ToString() },
        { SpellList.GloryDomain, SpellListRefs.GloryDomainSpellList.ToString() },
        { SpellList.GoodDomain, SpellListRefs.GoodDomainSpellList.ToString() },
        { SpellList.HealingDomain, SpellListRefs.HealingDomainSpellList.ToString() },
        { SpellList.Hunter, SpellListRefs.HunterSpelllist.ToString() },
        { SpellList.Inquisitor, SpellListRefs.InquisitorSpellList.ToString() },
        { SpellList.KnowledgeDomain, SpellListRefs.KnowledgeDomainSpellList.ToString() },
        { SpellList.LawDomain, SpellListRefs.LawDomainSpellList.ToString() },
        { SpellList.LiberationDomain, SpellListRefs.LiberationDomainSpellList.ToString() },
        { SpellList.Lich, SpellListRefs.LichWizardSpelllist.ToString() },
        { SpellList.LichBardMinor, SpellListRefs.LichSkeletalIBardMinorSpelllist.ToString() },
        { SpellList.LichInquisitorMinor, SpellListRefs.LichSkeletalInquisitorMinorSpelllist.ToString() },
        { SpellList.LichMythic, SpellListRefs.LichMythicSpelllist.ToString() },
        { SpellList.LifeSpirit, SpellListRefs.LifeSpiritSpellList.ToString() },
        { SpellList.LuckDomain, SpellListRefs.LuckDomainSpellList.ToString() },
        { SpellList.MadnessDomain, SpellListRefs.MadnessDomainSpellList.ToString() },
        { SpellList.MagicDomain, SpellListRefs.MagicDomainSpellList.ToString() },
        { SpellList.Magus, SpellListRefs.MagusSpellList.ToString() },
        { SpellList.NatureSpirit, SpellListRefs.NatureSpiritSpellList.ToString() },
        { SpellList.NobilityDomain, SpellListRefs.NobilityDomainSpellList.ToString() },
        { SpellList.Paladin, SpellListRefs.PaladinSpellList.ToString() },
        { SpellList.PlantDomain, SpellListRefs.PlantDomainSpellList.ToString() },
        { SpellList.ProtectionDomain, SpellListRefs.ProtectionDomainSpellList.ToString() },
        { SpellList.Ranger, SpellListRefs.RangerSpellList.ToString() },
        { SpellList.ReposeDomain, SpellListRefs.ReposeDomainSpellList.ToString() },
        { SpellList.RuneDomain, SpellListRefs.RuneDomainSpellList.ToString() },
        { SpellList.Shaman, SpellListRefs.ShamanSpelllist.ToString() },
        { SpellList.SpiritWarden, SpellListRefs.SpiritWardenSpellList.ToString() },
        { SpellList.StoneSpirit, SpellListRefs.StoneSpiritSpellList.ToString() },
        { SpellList.StrengthDomain, SpellListRefs.StrengthDomainSpellList.ToString() },
        { SpellList.SunDomain, SpellListRefs.SunDomainSpellList.ToString() },
        { SpellList.TravelDomain, SpellListRefs.TravelDomainSpellList.ToString() },
        { SpellList.TrickeryDomain, SpellListRefs.TrickeryDomainSpellList.ToString() },
        { SpellList.Trickster, SpellListRefs.TricksterSpelllist.ToString() },
        { SpellList.TricksterMythic, SpellListRefs.TricksterSpelllistMythic.ToString() },
        { SpellList.WarDomain, SpellListRefs.WarDomainSpellList.ToString() },
        { SpellList.Warpriest, SpellListRefs.WarpriestSpelllist.ToString() },
        { SpellList.WaterDomain, SpellListRefs.WaterDomainSpellList.ToString() },
        { SpellList.WavesSpirit, SpellListRefs.WavesSpiritSpellList.ToString() },
        { SpellList.WeatherDomain, SpellListRefs.WeatherDomainSpellList.ToString() },
        { SpellList.WindSpirit, SpellListRefs.WindSpiritSpellList.ToString() },
        { SpellList.Witch, SpellListRefs.WitchSpellList.ToString() },
        { SpellList.Wizard, SpellListRefs.WizardSpellList.ToString() },
      };

    /// <summary>
    /// Configures this ability as a spell of the specified level for each spell list.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// For each of the <paramref name="spellLists"/> a <c>SpellListComponent</c> is added and the corresponding spell
    /// list is modified to include the spell at the specified <paramref name="level"/>.
    /// </para>
    /// 
    /// <para>
    /// Most related spell lists are automatically handled, e.g. Wizard Spell School lists, Thassillonian Spell School
    /// lists, Prestige Class Spell Lists, etc.
    /// </para>
    /// 
    /// <para>
    /// If you want to add a spell list not defined in <see cref="SpellList"/> use
    /// <see cref="AddToSpellList(int, Blueprint{BlueprintSpellListReference}, bool)"/>.
    /// </para>
    /// </remarks>
    public AbilityConfigurator AddToSpellLists(int level, params SpellList[] spellLists)
    {
      foreach (var list in spellLists)
      {
        AddSpellListComponent(spellLevel: level, spellList: SpellListGuids[list]);
        OnConfigureInternal(bp => AddToSpellList(bp, level, list));
      }
      return Self;
    }

    public AbilityConfigurator AddToSpellList(
      int level, Blueprint<BlueprintSpellListReference> spellList, bool addSpellListComponent = true)
    {
      return this;
    }

    private static void AddToSpellList(BlueprintAbility spell, int level, SpellList spellList)
    {
      SpellListConfigurator.For(SpellListGuids[spellList])
        .ModifySpellsByLevel(list => AddToSpellList(spell, level, list))
        .Configure();

      switch (spellList)
      {

      }
    }

    private static void AddToSpellList(BlueprintAbility spell, int level, SpellLevelList spellList)
    {
      if (spellList.SpellLevel != level)
        return;
      spellList.Spells.Add(spell);
    }

    private static readonly List<string> SpellSpecializations =
      new()
      {
        ParametrizedFeatureRefs.SpellSpecializationFirst.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization1.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization2.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization3.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization4.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization5.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization6.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization7.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization8.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization9.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization10.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization11.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization12.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization13.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization14.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization15.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization16.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization17.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization18.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization19.ToString(),
        ParametrizedFeatureRefs.SpellSpecialization20.ToString(),
      };
    private static void AddToSpellSpecialization(BlueprintAbility spell)
    {
      foreach (var selection in SpellSpecializations)
      {
        ParametrizedFeatureConfigurator.For(selection)
          .AddToBlueprintParameterVariants(spell.ToReference<AnyBlueprintReference>())
          .Configure();
      }
    }

    /// <inheritdoc cref="BaseAbilityConfigurator{T, TBuilder}.SetCustomRange(Feet)"/>
    /// 
    /// <remarks>
    /// Sets <see cref="BlueprintAbility.Range"/> to AbilityRange.Custom.
    /// </remarks>
    public new AbilityConfigurator SetCustomRange(Feet rangeInFeet)
    {
      base.SetCustomRange(rangeInFeet);
      return OnConfigureInternal(bp => bp.Range = AbilityRange.Custom);
    }

    /// <inheritdoc cref="SetCustomRange(Feet)"/>
    public AbilityConfigurator SetCustomRange(int rangeInFeet)
    {
      return SetCustomRange(new Feet(rangeInFeet));
    }

    /// <summary>
    /// Convenience function to set all targeting behaviors:
    /// <see cref="BlueprintAbility.CanTargetPoint"/>,
    /// <see cref="BlueprintAbility.CanTargetEnemies"/>,
    /// <see cref="BlueprintAbility.CanTargetFriends"/>,
    /// and <see cref="BlueprintAbility.CanTargetSelf"/>
    /// </summary>
    public AbilityConfigurator AllowTargeting(
        bool? point = null, bool? enemies = null, bool? friends = null, bool? self = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.CanTargetPoint = point ?? blueprint.CanTargetPoint;
            blueprint.CanTargetEnemies = enemies ?? blueprint.CanTargetEnemies;
            blueprint.CanTargetFriends = friends ?? blueprint.CanTargetFriends;
            blueprint.CanTargetSelf = self ?? blueprint.CanTargetSelf;
          });
      return this;
    }
  }
}
