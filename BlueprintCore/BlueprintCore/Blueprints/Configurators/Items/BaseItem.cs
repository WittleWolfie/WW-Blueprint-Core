//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.DLC;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItem"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintItem
    where TBuilder : BaseItemConfigurator<T, TBuilder>
  {
    protected BaseItemConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AboutIzyagna</term><description>fa1f67444ec844508ea2eb6549581d5d</description></item>
    /// <item><term>KenabresWardstone</term><description>6e09b855929d419893eb2fbaeec80e51</description></item>
    /// <item><term>ZoeyPendantTeleport</term><description>9a90929e2db1be448b495509170a4251</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddItemShowInfoCallback(
        ActionsBuilder? action = null,
        bool? once = null)
    {
      var component = new AddItemShowInfoCallback();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      component.Once = once ?? component.Once;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BPCoins</term><description>995a5ff780c5fc541a0969e309c4de36</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuildPointsReplacement(
        int? cost = null)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost ?? component.Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ConsumableEventBonusItem</term><description>1ab90b3b5d7cd1045b86ae5b9410af70</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddConsumableEventBonusReplacement(
        int? cost = null)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost ?? component.Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcornPie_item</term><description>83864a3611c89f047b4242f139872fff</description></item>
    /// <item><term>GodspeedSalad_item</term><description>95de2a5a9e9f6f94381ace2b1c7d74ba</description></item>
    /// <item><term>SpicyPastry_item</term><description>b0a3bb682cfe6054bac65d0f4d68d3d0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="recipe">
    /// <para>
    /// Blueprint of type BlueprintCookingRecipe. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCopyRecipe(
        Blueprint<BlueprintCookingRecipe, BlueprintCookingRecipeReference>? recipe = null)
    {
      var component = new CopyRecipe();
      component.m_Recipe = recipe?.Reference ?? component.m_Recipe;
      if (component.m_Recipe is null)
      {
        component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ScrollHealMass</term><description>e19e85bfe282a1145a6075567a71970f</description></item>
    /// <item><term>ScrollOfInflictSeriousWounds</term><description>47d41dd302a14d04faa7df70697d23ec</description></item>
    /// <item><term>ScrollOfWrackingRay</term><description>e3af1f25d3d4fcf439f508377c7493cd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customSpell">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCopyScroll(
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? customSpell = null)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = customSpell?.Reference ?? component.m_CustomSpell;
      if (component.m_CustomSpell is null)
      {
        component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FinneanBaseItem</term><description>95c126deb99ba054aa5b84710520c035</description></item>
    /// <item><term>LexiconHalf2</term><description>b2e062dac1c7a7d45a21280601f2075f</description></item>
    /// <item><term>ZachariusFallenWandItem</term><description>622bb73ea55945b6a3d082e73166cc5c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialogReference">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddItemDialog(
        ConditionsBuilder? conditions = null,
        Blueprint<BlueprintDialog, BlueprintDialogReference>? dialogReference = null,
        LocalizedString? itemName = null)
    {
      var component = new ItemDialog();
      component.m_Conditions = conditions?.Build() ?? component.m_Conditions;
      if (component.m_Conditions is null)
      {
        component.m_Conditions = Utils.Constants.Empty.Conditions;
      }
      component.m_DialogReference = dialogReference?.Reference ?? component.m_DialogReference;
      if (component.m_DialogReference is null)
      {
        component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.m_ItemName = itemName ?? component.m_ItemName;
      if (component.m_ItemName is null)
      {
        component.m_ItemName = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DashingCavaliersGlovesItem</term><description>176da707c9c9d764e972a9da8b444ff3</description></item>
    /// <item><term>Owlcat_Item</term><description>6ea6d3b50bfa24e46a710beafbd95cd0</description></item>
    /// <item><term>SilverTongueAmuletItem</term><description>4d4231b4a395bba4b9819dfbb2dc785d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="changeTo">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="dlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddItemDlcRestriction(
        Blueprint<BlueprintItem, BlueprintItemReference>? changeTo = null,
        Blueprint<BlueprintDlcReward, BlueprintDlcRewardReference>? dlcReward = null,
        bool? hideInVendors = null)
    {
      var component = new ItemDlcRestriction();
      component.m_ChangeTo = changeTo?.Reference ?? component.m_ChangeTo;
      if (component.m_ChangeTo is null)
      {
        component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      component.m_DlcReward = dlcReward?.Reference ?? component.m_DlcReward;
      if (component.m_DlcReward is null)
      {
        component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      component.HideInVendors = hideInVendors ?? component.HideInVendors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FinneanBaseItem</term><description>95c126deb99ba054aa5b84710520c035</description></item>
    /// <item><term>TestFinneanItem</term><description>508d135c08de4661ba32b27e424e6a4c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="flagToCheck">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="polymorphItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddItemPolymorph(
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? flagToCheck = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        List<Blueprint<BlueprintItem, BlueprintItemReference>>? polymorphItems = null)
    {
      var component = new ItemPolymorph();
      component.m_FlagToCheck = flagToCheck?.Reference ?? component.m_FlagToCheck;
      if (component.m_FlagToCheck is null)
      {
        component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      component.m_PolymorphItems = polymorphItems?.Select(bp => bp.Reference)?.ToList() ?? component.m_PolymorphItems;
      if (component.m_PolymorphItems is null)
      {
        component.m_PolymorphItems = new();
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GoldCoins</term><description>f2bc0997c24e573448c6c91d2be88afa</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddMoneyReplacement(
        long? cost = null)
    {
      var component = new MoneyReplacement();
      component.Cost = cost ?? component.Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ElderBrass</term><description>0a8f3559cfcc4d38961bd9658d026cc8</description></item>
    /// <item><term>ElderFrost</term><description>c9c2580b9b6c43e992acae157615deb5</description></item>
    /// <item><term>ElderShockingBurst</term><description>a30a16ee048e4d1fb186c5cf4a0984b0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType? type = null)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type ?? component.m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Type Attack Enchant
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BombAttack2</term><description>22cef8e691a75674d8bc33ea986ea4fa</description></item>
    /// <item><term>OverwhelmingSoulOverwhelmingPowerFeature</term><description>6c24bf7cc2266f24f9b0c652799f1d91</description></item>
    /// <item><term>TouchEnchant2</term><description>2431f5f8d2ffe854784429b989d1e8a3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="type">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponTypeAttackEnchant(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintWeaponType, BlueprintWeaponTypeReference>? type = null)
    {
      var component = new WeaponTypeAttackEnchant();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_Type = type?.Reference ?? component.m_Type;
      if (component.m_Type is null)
      {
        component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
