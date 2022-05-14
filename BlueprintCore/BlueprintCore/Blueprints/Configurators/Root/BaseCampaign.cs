//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Settings;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCampaign"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCampaignConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCampaign
    where TBuilder : BaseCampaignConfigurator<T, TBuilder>
  {
    protected BaseCampaignConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignCustomCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customCompanion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBlueprintCampaignCustomCompanion(
        Blueprint<BlueprintUnit, BlueprintUnitReference>? customCompanion = null)
    {
      var component = new BlueprintCampaignCustomCompanion();
      component.m_CustomCompanion = customCompanion?.Reference ?? component.m_CustomCompanion;
      if (component.m_CustomCompanion is null)
      {
        component.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignRestBehaviour"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    public TBuilder AddBlueprintCampaignRestBehaviour(
        bool? removeDeathDoor = null,
        GameDifficultyOption? removeDeathDoorDifficultyMax = null)
    {
      var component = new BlueprintCampaignRestBehaviour();
      component.m_RemoveDeathDoor = removeDeathDoor ?? component.m_RemoveDeathDoor;
      component.m_RemoveDeathDoorDifficultyMax = removeDeathDoorDifficultyMax ?? component.m_RemoveDeathDoorDifficultyMax;
      return AddComponent(component);
    }
  }
}
