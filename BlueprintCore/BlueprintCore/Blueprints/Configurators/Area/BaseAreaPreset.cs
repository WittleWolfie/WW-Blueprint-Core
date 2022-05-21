//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Root;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Settings.Difficulty;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaPresetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaPreset
    where TBuilder : BaseAreaPresetConfigurator<T, TBuilder>
  {
    protected BaseAreaPresetConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_Area"/>
    /// </summary>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArea(Blueprint<BlueprintArea, BlueprintAreaReference> area)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Area = area?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Area"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyArea(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Area is null) { return; }
          action.Invoke(bp.m_Area);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_EnterPoint"/>
    /// </summary>
    ///
    /// <param name="enterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEnterPoint(Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> enterPoint)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EnterPoint = enterPoint?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_EnterPoint"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="enterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEnterPoint(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EnterPoint is null) { return; }
          action.Invoke(bp.m_EnterPoint);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_GlobalMapLocation"/>
    /// </summary>
    ///
    /// <param name="globalMapLocation">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalMapLocation(Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference> globalMapLocation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalMapLocation = globalMapLocation?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_GlobalMapLocation"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="globalMapLocation">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyGlobalMapLocation(Action<BlueprintGlobalMapPoint.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalMapLocation is null) { return; }
          action.Invoke(bp.m_GlobalMapLocation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/>
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAlsoLoadMechanics(params Blueprint<BlueprintAreaMechanics, BlueprintAreaMechanicsReference>[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlsoLoadMechanics = alsoLoadMechanics.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/>
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAlsoLoadMechanics(params Blueprint<BlueprintAreaMechanics, BlueprintAreaMechanicsReference>[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlsoLoadMechanics = bp.AlsoLoadMechanics ?? new();
          bp.AlsoLoadMechanics.AddRange(alsoLoadMechanics.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/>
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAlsoLoadMechanics(params Blueprint<BlueprintAreaMechanics, BlueprintAreaMechanicsReference>[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlsoLoadMechanics is null) { return; }
          bp.AlsoLoadMechanics = bp.AlsoLoadMechanics.Where(val => !alsoLoadMechanics.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAlsoLoadMechanics(Func<BlueprintAreaMechanicsReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlsoLoadMechanics is null) { return; }
          bp.AlsoLoadMechanics = bp.AlsoLoadMechanics.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/>
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAlsoLoadMechanics()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlsoLoadMechanics = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAlsoLoadMechanics(Action<BlueprintAreaMechanicsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlsoLoadMechanics is null) { return; }
          bp.AlsoLoadMechanics.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.MakeAutosave"/>
    /// </summary>
    public TBuilder SetMakeAutosave(bool makeAutosave = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MakeAutosave = makeAutosave;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.MakeAutosave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMakeAutosave(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MakeAutosave);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_OverrideGameDifficulty"/>
    /// </summary>
    public TBuilder SetOverrideGameDifficulty(DifficultyPresetAsset overrideGameDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overrideGameDifficulty);
          bp.m_OverrideGameDifficulty = overrideGameDifficulty;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_OverrideGameDifficulty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverrideGameDifficulty(Action<DifficultyPresetAsset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OverrideGameDifficulty is null) { return; }
          action.Invoke(bp.m_OverrideGameDifficulty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_PlayerCharacter"/>
    /// </summary>
    ///
    /// <param name="playerCharacter">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPlayerCharacter(Blueprint<BlueprintUnit, BlueprintUnitReference> playerCharacter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerCharacter = playerCharacter?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_PlayerCharacter"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="playerCharacter">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPlayerCharacter(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PlayerCharacter is null) { return; }
          action.Invoke(bp.m_PlayerCharacter);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.CharGen"/>
    /// </summary>
    public TBuilder SetCharGen(bool charGen = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CharGen = charGen;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CharGen"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCharGen(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CharGen);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.Alignment"/>
    /// </summary>
    public TBuilder SetAlignment(Alignment alignment)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Alignment = alignment;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.Alignment"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAlignment(Action<Alignment> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Alignment);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.PartyXp"/>
    /// </summary>
    public TBuilder SetPartyXp(int partyXp)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PartyXp = partyXp;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.PartyXp"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPartyXp(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PartyXp);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.Companions"/>
    /// </summary>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCompanions(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] companions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Companions = companions.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.Companions"/>
    /// </summary>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCompanions(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] companions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Companions = bp.Companions ?? new();
          bp.Companions.AddRange(companions.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.Companions"/>
    /// </summary>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCompanions(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] companions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Companions is null) { return; }
          bp.Companions = bp.Companions.Where(val => !companions.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.Companions"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCompanions(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Companions is null) { return; }
          bp.Companions = bp.Companions.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.Companions"/>
    /// </summary>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearCompanions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Companions = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.Companions"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCompanions(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Companions is null) { return; }
          bp.Companions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.CompanionsRemote"/>
    /// </summary>
    ///
    /// <param name="companionsRemote">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCompanionsRemote(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] companionsRemote)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompanionsRemote = companionsRemote.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.CompanionsRemote"/>
    /// </summary>
    ///
    /// <param name="companionsRemote">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCompanionsRemote(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] companionsRemote)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompanionsRemote = bp.CompanionsRemote ?? new();
          bp.CompanionsRemote.AddRange(companionsRemote.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.CompanionsRemote"/>
    /// </summary>
    ///
    /// <param name="companionsRemote">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCompanionsRemote(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] companionsRemote)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CompanionsRemote is null) { return; }
          bp.CompanionsRemote = bp.CompanionsRemote.Where(val => !companionsRemote.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.CompanionsRemote"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="companionsRemote">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCompanionsRemote(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CompanionsRemote is null) { return; }
          bp.CompanionsRemote = bp.CompanionsRemote.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.CompanionsRemote"/>
    /// </summary>
    ///
    /// <param name="companionsRemote">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearCompanionsRemote()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompanionsRemote = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CompanionsRemote"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="companionsRemote">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCompanionsRemote(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CompanionsRemote is null) { return; }
          bp.CompanionsRemote.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.ExCompanions"/>
    /// </summary>
    ///
    /// <param name="exCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExCompanions(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] exCompanions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExCompanions = exCompanions.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.ExCompanions"/>
    /// </summary>
    ///
    /// <param name="exCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToExCompanions(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] exCompanions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExCompanions = bp.ExCompanions ?? new();
          bp.ExCompanions.AddRange(exCompanions.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.ExCompanions"/>
    /// </summary>
    ///
    /// <param name="exCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromExCompanions(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] exCompanions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExCompanions is null) { return; }
          bp.ExCompanions = bp.ExCompanions.Where(val => !exCompanions.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.ExCompanions"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="exCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromExCompanions(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExCompanions is null) { return; }
          bp.ExCompanions = bp.ExCompanions.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.ExCompanions"/>
    /// </summary>
    ///
    /// <param name="exCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearExCompanions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExCompanions = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ExCompanions"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="exCompanions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyExCompanions(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExCompanions is null) { return; }
          bp.ExCompanions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.StartGameActions"/>
    /// </summary>
    public TBuilder SetStartGameActions(ActionsBuilder startGameActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartGameActions = startGameActions?.Build();
          if (bp.StartGameActions is null)
          {
            bp.StartGameActions = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartGameActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartGameActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartGameActions is null) { return; }
          action.Invoke(bp.StartGameActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_Campaign"/>
    /// </summary>
    ///
    /// <param name="campaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCampaign(Blueprint<BlueprintCampaign, BlueprintCampaignReference> campaign)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Campaign = campaign?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Campaign"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="campaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCampaign(Action<BlueprintCampaignReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Campaign is null) { return; }
          action.Invoke(bp.m_Campaign);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.UnlockedFlags"/>
    /// </summary>
    public TBuilder SetUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in unlockedFlags) { Validate(item); }
          bp.UnlockedFlags = unlockedFlags.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.UnlockedFlags"/>
    /// </summary>
    public TBuilder AddToUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnlockedFlags = bp.UnlockedFlags ?? new();
          bp.UnlockedFlags.AddRange(unlockedFlags);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.UnlockedFlags"/>
    /// </summary>
    public TBuilder RemoveFromUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnlockedFlags is null) { return; }
          bp.UnlockedFlags = bp.UnlockedFlags.Where(val => !unlockedFlags.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.UnlockedFlags"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnlockedFlags(Func<UnlockValuePair, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnlockedFlags is null) { return; }
          bp.UnlockedFlags = bp.UnlockedFlags.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.UnlockedFlags"/>
    /// </summary>
    public TBuilder ClearUnlockedFlags()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnlockedFlags = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.UnlockedFlags"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnlockedFlags(Action<UnlockValuePair> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnlockedFlags is null) { return; }
          bp.UnlockedFlags.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.StartedQuests"/>
    /// </summary>
    ///
    /// <param name="startedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] startedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartedQuests = startedQuests.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.StartedQuests"/>
    /// </summary>
    ///
    /// <param name="startedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] startedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartedQuests = bp.StartedQuests ?? new();
          bp.StartedQuests.AddRange(startedQuests.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.StartedQuests"/>
    /// </summary>
    ///
    /// <param name="startedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] startedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartedQuests is null) { return; }
          bp.StartedQuests = bp.StartedQuests.Where(val => !startedQuests.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.StartedQuests"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="startedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartedQuests(Func<BlueprintQuestObjectiveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartedQuests is null) { return; }
          bp.StartedQuests = bp.StartedQuests.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.StartedQuests"/>
    /// </summary>
    ///
    /// <param name="startedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearStartedQuests()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartedQuests = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartedQuests"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="startedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyStartedQuests(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartedQuests is null) { return; }
          bp.StartedQuests.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.FinishedQuests"/>
    /// </summary>
    ///
    /// <param name="finishedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFinishedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] finishedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FinishedQuests = finishedQuests.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.FinishedQuests"/>
    /// </summary>
    ///
    /// <param name="finishedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFinishedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] finishedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FinishedQuests = bp.FinishedQuests ?? new();
          bp.FinishedQuests.AddRange(finishedQuests.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.FinishedQuests"/>
    /// </summary>
    ///
    /// <param name="finishedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFinishedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] finishedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FinishedQuests is null) { return; }
          bp.FinishedQuests = bp.FinishedQuests.Where(val => !finishedQuests.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.FinishedQuests"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="finishedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFinishedQuests(Func<BlueprintQuestObjectiveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FinishedQuests is null) { return; }
          bp.FinishedQuests = bp.FinishedQuests.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.FinishedQuests"/>
    /// </summary>
    ///
    /// <param name="finishedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearFinishedQuests()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FinishedQuests = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FinishedQuests"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="finishedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyFinishedQuests(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FinishedQuests is null) { return; }
          bp.FinishedQuests.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.FailedQuests"/>
    /// </summary>
    ///
    /// <param name="failedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFailedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] failedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FailedQuests = failedQuests.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.FailedQuests"/>
    /// </summary>
    ///
    /// <param name="failedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFailedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] failedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FailedQuests = bp.FailedQuests ?? new();
          bp.FailedQuests.AddRange(failedQuests.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.FailedQuests"/>
    /// </summary>
    ///
    /// <param name="failedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFailedQuests(params Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>[] failedQuests)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FailedQuests is null) { return; }
          bp.FailedQuests = bp.FailedQuests.Where(val => !failedQuests.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.FailedQuests"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="failedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFailedQuests(Func<BlueprintQuestObjectiveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FailedQuests is null) { return; }
          bp.FailedQuests = bp.FailedQuests.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.FailedQuests"/>
    /// </summary>
    ///
    /// <param name="failedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearFailedQuests()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FailedQuests = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.FailedQuests"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="failedQuests">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyFailedQuests(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FailedQuests is null) { return; }
          bp.FailedQuests.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/>
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartEtudesNonRecursively(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartEtudesNonRecursively = startEtudesNonRecursively.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/>
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartEtudesNonRecursively(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartEtudesNonRecursively = bp.StartEtudesNonRecursively ?? new();
          bp.StartEtudesNonRecursively.AddRange(startEtudesNonRecursively.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/>
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartEtudesNonRecursively(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartEtudesNonRecursively is null) { return; }
          bp.StartEtudesNonRecursively = bp.StartEtudesNonRecursively.Where(val => !startEtudesNonRecursively.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartEtudesNonRecursively(Func<BlueprintEtudeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartEtudesNonRecursively is null) { return; }
          bp.StartEtudesNonRecursively = bp.StartEtudesNonRecursively.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/>
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearStartEtudesNonRecursively()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartEtudesNonRecursively = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyStartEtudesNonRecursively(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartEtudesNonRecursively is null) { return; }
          bp.StartEtudesNonRecursively.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.StartEtudes"/>
    /// </summary>
    ///
    /// <param name="startEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartEtudes(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] startEtudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartEtudes = startEtudes.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.StartEtudes"/>
    /// </summary>
    ///
    /// <param name="startEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartEtudes(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] startEtudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartEtudes = bp.StartEtudes ?? new();
          bp.StartEtudes.AddRange(startEtudes.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.StartEtudes"/>
    /// </summary>
    ///
    /// <param name="startEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartEtudes(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] startEtudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartEtudes is null) { return; }
          bp.StartEtudes = bp.StartEtudes.Where(val => !startEtudes.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.StartEtudes"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="startEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartEtudes(Func<BlueprintEtudeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartEtudes is null) { return; }
          bp.StartEtudes = bp.StartEtudes.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.StartEtudes"/>
    /// </summary>
    ///
    /// <param name="startEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearStartEtudes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartEtudes = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.StartEtudes"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="startEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyStartEtudes(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartEtudes is null) { return; }
          bp.StartEtudes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/>
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetForceCompleteEtudes(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForceCompleteEtudes = forceCompleteEtudes.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/>
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToForceCompleteEtudes(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForceCompleteEtudes = bp.ForceCompleteEtudes ?? new();
          bp.ForceCompleteEtudes.AddRange(forceCompleteEtudes.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/>
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromForceCompleteEtudes(params Blueprint<BlueprintEtude, BlueprintEtudeReference>[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ForceCompleteEtudes is null) { return; }
          bp.ForceCompleteEtudes = bp.ForceCompleteEtudes.Where(val => !forceCompleteEtudes.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromForceCompleteEtudes(Func<BlueprintEtudeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ForceCompleteEtudes is null) { return; }
          bp.ForceCompleteEtudes = bp.ForceCompleteEtudes.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/>
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearForceCompleteEtudes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForceCompleteEtudes = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyForceCompleteEtudes(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ForceCompleteEtudes is null) { return; }
          bp.ForceCompleteEtudes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.CuesSeen"/>
    /// </summary>
    ///
    /// <param name="cuesSeen">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCuesSeen(params Blueprint<BlueprintCueBase, BlueprintCueBaseReference>[] cuesSeen)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CuesSeen = cuesSeen.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.CuesSeen"/>
    /// </summary>
    ///
    /// <param name="cuesSeen">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCuesSeen(params Blueprint<BlueprintCueBase, BlueprintCueBaseReference>[] cuesSeen)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CuesSeen = bp.CuesSeen ?? new();
          bp.CuesSeen.AddRange(cuesSeen.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.CuesSeen"/>
    /// </summary>
    ///
    /// <param name="cuesSeen">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCuesSeen(params Blueprint<BlueprintCueBase, BlueprintCueBaseReference>[] cuesSeen)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CuesSeen is null) { return; }
          bp.CuesSeen = bp.CuesSeen.Where(val => !cuesSeen.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.CuesSeen"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="cuesSeen">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCuesSeen(Func<BlueprintCueBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CuesSeen is null) { return; }
          bp.CuesSeen = bp.CuesSeen.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.CuesSeen"/>
    /// </summary>
    ///
    /// <param name="cuesSeen">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearCuesSeen()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CuesSeen = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.CuesSeen"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="cuesSeen">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCuesSeen(Action<BlueprintCueBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CuesSeen is null) { return; }
          bp.CuesSeen.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.AnswersSelected"/>
    /// </summary>
    ///
    /// <param name="answersSelected">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAnswersSelected(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] answersSelected)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AnswersSelected = answersSelected.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.AnswersSelected"/>
    /// </summary>
    ///
    /// <param name="answersSelected">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAnswersSelected(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] answersSelected)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AnswersSelected = bp.AnswersSelected ?? new();
          bp.AnswersSelected.AddRange(answersSelected.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.AnswersSelected"/>
    /// </summary>
    ///
    /// <param name="answersSelected">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAnswersSelected(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] answersSelected)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AnswersSelected is null) { return; }
          bp.AnswersSelected = bp.AnswersSelected.Where(val => !answersSelected.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.AnswersSelected"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="answersSelected">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAnswersSelected(Func<BlueprintAnswerReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AnswersSelected is null) { return; }
          bp.AnswersSelected = bp.AnswersSelected.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.AnswersSelected"/>
    /// </summary>
    ///
    /// <param name="answersSelected">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAnswersSelected()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AnswersSelected = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AnswersSelected"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="answersSelected">
    /// <para>
    /// Blueprint of type BlueprintAnswer. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAnswersSelected(Action<BlueprintAnswerReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AnswersSelected is null) { return; }
          bp.AnswersSelected.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.HasKingdom"/>
    /// </summary>
    public TBuilder SetHasKingdom(bool hasKingdom = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasKingdom = hasKingdom;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.HasKingdom"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasKingdom(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasKingdom);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.KingdomManagementIsVisible"/>
    /// </summary>
    public TBuilder SetKingdomManagementIsVisible(bool kingdomManagementIsVisible = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomManagementIsVisible = kingdomManagementIsVisible;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.KingdomManagementIsVisible"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingdomManagementIsVisible(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.KingdomManagementIsVisible);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.ActiveEvents"/>
    /// </summary>
    ///
    /// <param name="activeEvents">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActiveEvents(params Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>[] activeEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActiveEvents = activeEvents.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.ActiveEvents"/>
    /// </summary>
    ///
    /// <param name="activeEvents">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToActiveEvents(params Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>[] activeEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActiveEvents = bp.ActiveEvents ?? new();
          bp.ActiveEvents.AddRange(activeEvents.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.ActiveEvents"/>
    /// </summary>
    ///
    /// <param name="activeEvents">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActiveEvents(params Blueprint<BlueprintKingdomEventBase, BlueprintKingdomEventBaseReference>[] activeEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActiveEvents is null) { return; }
          bp.ActiveEvents = bp.ActiveEvents.Where(val => !activeEvents.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.ActiveEvents"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="activeEvents">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActiveEvents(Func<BlueprintKingdomEventBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActiveEvents is null) { return; }
          bp.ActiveEvents = bp.ActiveEvents.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.ActiveEvents"/>
    /// </summary>
    ///
    /// <param name="activeEvents">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearActiveEvents()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActiveEvents = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.ActiveEvents"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="activeEvents">
    /// <para>
    /// Blueprint of type BlueprintKingdomEventBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyActiveEvents(Action<BlueprintKingdomEventBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActiveEvents is null) { return; }
          bp.ActiveEvents.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.AddResources"/>
    /// </summary>
    public TBuilder SetAddResources(KingdomResourcesAmount addResources)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddResources = addResources;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AddResources"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAddResources(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AddResources);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.AddConsumableEventBonus"/>
    /// </summary>
    public TBuilder SetAddConsumableEventBonus(int addConsumableEventBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddConsumableEventBonus = addConsumableEventBonus;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.AddConsumableEventBonus"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAddConsumableEventBonus(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AddConsumableEventBonus);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_KingdomDay"/>
    /// </summary>
    public TBuilder SetKingdomDay(int kingdomDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingdomDay = kingdomDay;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_KingdomDay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingdomDay(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_KingdomDay);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_KingdomIncomePerClaimed"/>
    /// </summary>
    public TBuilder SetKingdomIncomePerClaimed(KingdomResourcesAmount kingdomIncomePerClaimed)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingdomIncomePerClaimed = kingdomIncomePerClaimed;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_KingdomIncomePerClaimed"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingdomIncomePerClaimed(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_KingdomIncomePerClaimed);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_KingdomIncomePerUpgraded"/>
    /// </summary>
    public TBuilder SetKingdomIncomePerUpgraded(KingdomResourcesAmount kingdomIncomePerUpgraded)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_KingdomIncomePerUpgraded = kingdomIncomePerUpgraded;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_KingdomIncomePerUpgraded"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingdomIncomePerUpgraded(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_KingdomIncomePerUpgraded);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_Stats"/>
    /// </summary>
    public TBuilder SetStats(BlueprintAreaPreset.KingdomsStatsPreset stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(stats);
          bp.m_Stats = stats;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Stats"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStats(Action<BlueprintAreaPreset.KingdomsStatsPreset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Stats is null) { return; }
          action.Invoke(bp.m_Stats);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_Regions"/>
    /// </summary>
    public TBuilder SetRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in regions) { Validate(item); }
          bp.m_Regions = regions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.m_Regions"/>
    /// </summary>
    public TBuilder AddToRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Regions = bp.m_Regions ?? new BlueprintAreaPreset.KingdomsRegionPreset[0];
          bp.m_Regions = CommonTool.Append(bp.m_Regions, regions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.m_Regions"/>
    /// </summary>
    public TBuilder RemoveFromRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Regions is null) { return; }
          bp.m_Regions = bp.m_Regions.Where(val => !regions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.m_Regions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRegions(Func<BlueprintAreaPreset.KingdomsRegionPreset, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Regions is null) { return; }
          bp.m_Regions = bp.m_Regions.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.m_Regions"/>
    /// </summary>
    public TBuilder ClearRegions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Regions = new BlueprintAreaPreset.KingdomsRegionPreset[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_Regions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRegions(Action<BlueprintAreaPreset.KingdomsRegionPreset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Regions is null) { return; }
          bp.m_Regions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaPreset.m_History"/>
    /// </summary>
    public TBuilder SetHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in history) { Validate(item); }
          bp.m_History = history;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAreaPreset.m_History"/>
    /// </summary>
    public TBuilder AddToHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_History = bp.m_History ?? new BlueprintAreaPreset.KingdomsEventHistoryPreset[0];
          bp.m_History = CommonTool.Append(bp.m_History, history);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.m_History"/>
    /// </summary>
    public TBuilder RemoveFromHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_History is null) { return; }
          bp.m_History = bp.m_History.Where(val => !history.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAreaPreset.m_History"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromHistory(Func<BlueprintAreaPreset.KingdomsEventHistoryPreset, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_History is null) { return; }
          bp.m_History = bp.m_History.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAreaPreset.m_History"/>
    /// </summary>
    public TBuilder ClearHistory()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_History = new BlueprintAreaPreset.KingdomsEventHistoryPreset[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaPreset.m_History"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyHistory(Action<BlueprintAreaPreset.KingdomsEventHistoryPreset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_History is null) { return; }
          bp.m_History.ForEach(action);
        });
    }
  }
}
