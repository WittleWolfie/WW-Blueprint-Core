//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using Kingmaker.Settings.Difficulty;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintClockworkScenario"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseClockworkScenarioConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintClockworkScenario
    where TBuilder : BaseClockworkScenarioConfigurator<T, TBuilder>
  {
    protected BaseClockworkScenarioConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.m_ScenarioName"/>
    /// </summary>
    public TBuilder SetScenarioName(string scenarioName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScenarioName = scenarioName;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_ScenarioName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyScenarioName(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScenarioName is null) { return; }
          action.Invoke(bp.m_ScenarioName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.ScenarioAuthor"/>
    /// </summary>
    public TBuilder SetScenarioAuthor(BlueprintClockworkScenario.ScenarioQA scenarioAuthor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ScenarioAuthor = scenarioAuthor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.ScenarioAuthor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyScenarioAuthor(Action<BlueprintClockworkScenario.ScenarioQA> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ScenarioAuthor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.TestMode"/>
    /// </summary>
    public TBuilder SetTestMode(BlueprintClockworkScenario.ClockworkTestMode testMode)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TestMode = testMode;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.TestMode"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTestMode(Action<BlueprintClockworkScenario.ClockworkTestMode> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TestMode);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.startMode"/>
    /// </summary>
    public TBuilder SetStartMode(BlueprintClockworkScenario.StartMode startMode)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.startMode = startMode;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.startMode"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartMode(Action<BlueprintClockworkScenario.StartMode> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.startMode);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.Preset"/>
    /// </summary>
    ///
    /// <param name="preset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPreset(Blueprint<BlueprintAreaPreset, BlueprintAreaPresetReference> preset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Preset = preset?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.Preset"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="preset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPreset(Action<BlueprintAreaPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Preset is null) { return; }
          action.Invoke(bp.Preset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.Save"/>
    /// </summary>
    public TBuilder SetSave(string save)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Save = save;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.Save"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySave(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Save is null) { return; }
          action.Invoke(bp.Save);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.RemoteSave"/>
    /// </summary>
    public TBuilder SetRemoteSave(string remoteSave)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RemoteSave = remoteSave;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.RemoteSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRemoteSave(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RemoteSave is null) { return; }
          action.Invoke(bp.RemoteSave);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.BlueprintPlayerUnit"/>
    /// </summary>
    ///
    /// <param name="blueprintPlayerUnit">
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
    public TBuilder SetBlueprintPlayerUnit(Blueprint<BlueprintUnit, BlueprintUnitReference> blueprintPlayerUnit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BlueprintPlayerUnit = blueprintPlayerUnit?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.BlueprintPlayerUnit"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="blueprintPlayerUnit">
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
    public TBuilder ModifyBlueprintPlayerUnit(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BlueprintPlayerUnit is null) { return; }
          action.Invoke(bp.BlueprintPlayerUnit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.OverridePresetDifficulty"/>
    /// </summary>
    public TBuilder SetOverridePresetDifficulty(DifficultyPresetAsset overridePresetDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overridePresetDifficulty);
          bp.OverridePresetDifficulty = overridePresetDifficulty;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.OverridePresetDifficulty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverridePresetDifficulty(Action<DifficultyPresetAsset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverridePresetDifficulty is null) { return; }
          action.Invoke(bp.OverridePresetDifficulty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.OnAreaEnterDelay"/>
    /// </summary>
    public TBuilder SetOnAreaEnterDelay(float onAreaEnterDelay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnAreaEnterDelay = onAreaEnterDelay;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.OnAreaEnterDelay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnAreaEnterDelay(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OnAreaEnterDelay);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.AreaTimeout"/>
    /// </summary>
    public TBuilder SetAreaTimeout(float areaTimeout)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AreaTimeout = areaTimeout;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.AreaTimeout"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaTimeout(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AreaTimeout);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.CutsceneTimeout"/>
    /// </summary>
    public TBuilder SetCutsceneTimeout(float cutsceneTimeout)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CutsceneTimeout = cutsceneTimeout;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.CutsceneTimeout"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCutsceneTimeout(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CutsceneTimeout);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.TaskTimeout"/>
    /// </summary>
    public TBuilder SetTaskTimeout(float taskTimeout)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TaskTimeout = taskTimeout;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.TaskTimeout"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTaskTimeout(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TaskTimeout);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.TaskMaxAttempts"/>
    /// </summary>
    public TBuilder SetTaskMaxAttempts(int taskMaxAttempts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TaskMaxAttempts = taskMaxAttempts;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.TaskMaxAttempts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTaskMaxAttempts(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TaskMaxAttempts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.AreaGameOverLimit"/>
    /// </summary>
    public TBuilder SetAreaGameOverLimit(int areaGameOverLimit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AreaGameOverLimit = areaGameOverLimit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.AreaGameOverLimit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaGameOverLimit(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AreaGameOverLimit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.AutoLevelUp"/>
    /// </summary>
    public TBuilder SetAutoLevelUp(bool autoLevelUp = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoLevelUp = autoLevelUp;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.AutoLevelUp"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoLevelUp(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoLevelUp);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.AutoUseRest"/>
    /// </summary>
    public TBuilder SetAutoUseRest(bool autoUseRest = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoUseRest = autoUseRest;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.AutoUseRest"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoUseRest(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoUseRest);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.CheaterCombat"/>
    /// </summary>
    public TBuilder SetCheaterCombat(bool cheaterCombat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheaterCombat = cheaterCombat;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.CheaterCombat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheaterCombat(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CheaterCombat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.CheaterTacticalCombat"/>
    /// </summary>
    public TBuilder SetCheaterTacticalCombat(bool cheaterTacticalCombat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheaterTacticalCombat = cheaterTacticalCombat;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.CheaterTacticalCombat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheaterTacticalCombat(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CheaterTacticalCombat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.SellTrashOnly"/>
    /// </summary>
    public TBuilder SetSellTrashOnly(bool sellTrashOnly = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SellTrashOnly = sellTrashOnly;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.SellTrashOnly"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySellTrashOnly(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SellTrashOnly);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.DoNotStartTrade"/>
    /// </summary>
    public TBuilder SetDoNotStartTrade(bool doNotStartTrade = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotStartTrade = doNotStartTrade;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotStartTrade"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDoNotStartTrade(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DoNotStartTrade);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.SaveLoadSmokeTest"/>
    /// </summary>
    ///
    /// <param name="saveLoadSmokeTest">
    /// <para>
    /// Tooltip: При входе в каждую локацию попытается сохраниться и загрузить этот сейв
    /// </para>
    /// </param>
    public TBuilder SetSaveLoadSmokeTest(bool saveLoadSmokeTest = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SaveLoadSmokeTest = saveLoadSmokeTest;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.SaveLoadSmokeTest"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="saveLoadSmokeTest">
    /// <para>
    /// Tooltip: При входе в каждую локацию попытается сохраниться и загрузить этот сейв
    /// </para>
    /// </param>
    public TBuilder ModifySaveLoadSmokeTest(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SaveLoadSmokeTest);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.UploadSavesToSavesStorage"/>
    /// </summary>
    public TBuilder SetUploadSavesToSavesStorage(bool uploadSavesToSavesStorage = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UploadSavesToSavesStorage = uploadSavesToSavesStorage;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.UploadSavesToSavesStorage"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUploadSavesToSavesStorage(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UploadSavesToSavesStorage);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.ScenarioParts"/>
    /// </summary>
    ///
    /// <param name="scenarioParts">
    /// <para>
    /// Blueprint of type BlueprintClockworkScenarioPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetScenarioParts(params Blueprint<BlueprintClockworkScenarioPart, BlueprintClockworkScenarioPartReference>[] scenarioParts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ScenarioParts = scenarioParts.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.ScenarioParts"/>
    /// </summary>
    ///
    /// <param name="scenarioParts">
    /// <para>
    /// Blueprint of type BlueprintClockworkScenarioPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToScenarioParts(params Blueprint<BlueprintClockworkScenarioPart, BlueprintClockworkScenarioPartReference>[] scenarioParts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ScenarioParts = bp.ScenarioParts ?? new();
          bp.ScenarioParts.AddRange(scenarioParts.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.ScenarioParts"/>
    /// </summary>
    ///
    /// <param name="scenarioParts">
    /// <para>
    /// Blueprint of type BlueprintClockworkScenarioPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromScenarioParts(params Blueprint<BlueprintClockworkScenarioPart, BlueprintClockworkScenarioPartReference>[] scenarioParts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ScenarioParts is null) { return; }
          bp.ScenarioParts = bp.ScenarioParts.Where(val => !scenarioParts.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.ScenarioParts"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="scenarioParts">
    /// <para>
    /// Blueprint of type BlueprintClockworkScenarioPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromScenarioParts(Func<BlueprintClockworkScenarioPartReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ScenarioParts is null) { return; }
          bp.ScenarioParts = bp.ScenarioParts.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.ScenarioParts"/>
    /// </summary>
    ///
    /// <param name="scenarioParts">
    /// <para>
    /// Blueprint of type BlueprintClockworkScenarioPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearScenarioParts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ScenarioParts = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.ScenarioParts"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="scenarioParts">
    /// <para>
    /// Blueprint of type BlueprintClockworkScenarioPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyScenarioParts(Action<BlueprintClockworkScenarioPartReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ScenarioParts is null) { return; }
          bp.ScenarioParts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.RetrySkillChecks"/>
    /// </summary>
    public TBuilder SetRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in retrySkillChecks) { Validate(item); }
          bp.RetrySkillChecks = retrySkillChecks.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.RetrySkillChecks"/>
    /// </summary>
    public TBuilder AddToRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RetrySkillChecks = bp.RetrySkillChecks ?? new();
          bp.RetrySkillChecks.AddRange(retrySkillChecks);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.RetrySkillChecks"/>
    /// </summary>
    public TBuilder RemoveFromRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RetrySkillChecks is null) { return; }
          bp.RetrySkillChecks = bp.RetrySkillChecks.Where(val => !retrySkillChecks.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRetrySkillChecks(Func<EntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RetrySkillChecks is null) { return; }
          bp.RetrySkillChecks = bp.RetrySkillChecks.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.RetrySkillChecks"/>
    /// </summary>
    public TBuilder ClearRetrySkillChecks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RetrySkillChecks = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRetrySkillChecks(Action<EntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RetrySkillChecks is null) { return; }
          bp.RetrySkillChecks.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder SetHighPriorityAnswers(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] highPriorityAnswers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HighPriorityAnswers = highPriorityAnswers.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder AddToHighPriorityAnswers(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] highPriorityAnswers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HighPriorityAnswers = bp.HighPriorityAnswers ?? new();
          bp.HighPriorityAnswers.AddRange(highPriorityAnswers.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder RemoveFromHighPriorityAnswers(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] highPriorityAnswers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HighPriorityAnswers is null) { return; }
          bp.HighPriorityAnswers = bp.HighPriorityAnswers.Where(val => !highPriorityAnswers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder RemoveFromHighPriorityAnswers(Func<BlueprintAnswerReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HighPriorityAnswers is null) { return; }
          bp.HighPriorityAnswers = bp.HighPriorityAnswers.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/>
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder ClearHighPriorityAnswers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HighPriorityAnswers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="highPriorityAnswers">
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
    public TBuilder ModifyHighPriorityAnswers(Action<BlueprintAnswerReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.HighPriorityAnswers is null) { return; }
          bp.HighPriorityAnswers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDoNotSellItems(params Blueprint<BlueprintItem, BlueprintItemReference>[] doNotSellItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotSellItems = doNotSellItems.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToDoNotSellItems(params Blueprint<BlueprintItem, BlueprintItemReference>[] doNotSellItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotSellItems = bp.DoNotSellItems ?? new();
          bp.DoNotSellItems.AddRange(doNotSellItems.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromDoNotSellItems(params Blueprint<BlueprintItem, BlueprintItemReference>[] doNotSellItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotSellItems is null) { return; }
          bp.DoNotSellItems = bp.DoNotSellItems.Where(val => !doNotSellItems.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotSellItems"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromDoNotSellItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotSellItems is null) { return; }
          bp.DoNotSellItems = bp.DoNotSellItems.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.DoNotSellItems"/>
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearDoNotSellItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotSellItems = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotSellItems"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="doNotSellItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyDoNotSellItems(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotSellItems is null) { return; }
          bp.DoNotSellItems.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.DoNotInterract"/>
    /// </summary>
    public TBuilder SetDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in doNotInterract) { Validate(item); }
          bp.DoNotInterract = doNotInterract.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.DoNotInterract"/>
    /// </summary>
    public TBuilder AddToDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterract = bp.DoNotInterract ?? new();
          bp.DoNotInterract.AddRange(doNotInterract);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotInterract"/>
    /// </summary>
    public TBuilder RemoveFromDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterract is null) { return; }
          bp.DoNotInterract = bp.DoNotInterract.Where(val => !doNotInterract.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotInterract"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDoNotInterract(Func<ClockworkEntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterract is null) { return; }
          bp.DoNotInterract = bp.DoNotInterract.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.DoNotInterract"/>
    /// </summary>
    public TBuilder ClearDoNotInterract()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterract = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotInterract"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDoNotInterract(Action<ClockworkEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterract is null) { return; }
          bp.DoNotInterract.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder SetDoNotInterractUnits(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] doNotInterractUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterractUnits = doNotInterractUnits.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder AddToDoNotInterractUnits(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] doNotInterractUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterractUnits = bp.DoNotInterractUnits ?? new();
          bp.DoNotInterractUnits.AddRange(doNotInterractUnits.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder RemoveFromDoNotInterractUnits(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] doNotInterractUnits)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterractUnits is null) { return; }
          bp.DoNotInterractUnits = bp.DoNotInterractUnits.Where(val => !doNotInterractUnits.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder RemoveFromDoNotInterractUnits(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterractUnits is null) { return; }
          bp.DoNotInterractUnits = bp.DoNotInterractUnits.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/>
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder ClearDoNotInterractUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotInterractUnits = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="doNotInterractUnits">
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
    public TBuilder ModifyDoNotInterractUnits(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotInterractUnits is null) { return; }
          bp.DoNotInterractUnits.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder SetDoNotUseAnswer(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] doNotUseAnswer)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotUseAnswer = doNotUseAnswer.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder AddToDoNotUseAnswer(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] doNotUseAnswer)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotUseAnswer = bp.DoNotUseAnswer ?? new();
          bp.DoNotUseAnswer.AddRange(doNotUseAnswer.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder RemoveFromDoNotUseAnswer(params Blueprint<BlueprintAnswer, BlueprintAnswerReference>[] doNotUseAnswer)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotUseAnswer is null) { return; }
          bp.DoNotUseAnswer = bp.DoNotUseAnswer.Where(val => !doNotUseAnswer.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder RemoveFromDoNotUseAnswer(Func<BlueprintAnswerReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotUseAnswer is null) { return; }
          bp.DoNotUseAnswer = bp.DoNotUseAnswer.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/>
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder ClearDoNotUseAnswer()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotUseAnswer = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="doNotUseAnswer">
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
    public TBuilder ModifyDoNotUseAnswer(Action<BlueprintAnswerReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotUseAnswer is null) { return; }
          bp.DoNotUseAnswer.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
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
    public TBuilder SetDoNotEnterAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] doNotEnterAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotEnterAreas = doNotEnterAreas.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
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
    public TBuilder AddToDoNotEnterAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] doNotEnterAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotEnterAreas = bp.DoNotEnterAreas ?? new();
          bp.DoNotEnterAreas.AddRange(doNotEnterAreas.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
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
    public TBuilder RemoveFromDoNotEnterAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] doNotEnterAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotEnterAreas is null) { return; }
          bp.DoNotEnterAreas = bp.DoNotEnterAreas.Where(val => !doNotEnterAreas.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
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
    public TBuilder RemoveFromDoNotEnterAreas(Func<BlueprintAreaReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotEnterAreas is null) { return; }
          bp.DoNotEnterAreas = bp.DoNotEnterAreas.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/>
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
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
    public TBuilder ClearDoNotEnterAreas()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotEnterAreas = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="doNotEnterAreas">
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
    public TBuilder ModifyDoNotEnterAreas(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DoNotEnterAreas is null) { return; }
          bp.DoNotEnterAreas.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.m_OnTickCheckers"/>
    /// </summary>
    public TBuilder SetOnTickCheckers(params IOnTickChecker[] onTickCheckers)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in onTickCheckers) { Validate(item); }
          bp.m_OnTickCheckers = onTickCheckers.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.m_OnTickCheckers"/>
    /// </summary>
    public TBuilder AddToOnTickCheckers(params IOnTickChecker[] onTickCheckers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OnTickCheckers = bp.m_OnTickCheckers ?? new();
          bp.m_OnTickCheckers.AddRange(onTickCheckers);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.m_OnTickCheckers"/>
    /// </summary>
    public TBuilder RemoveFromOnTickCheckers(params IOnTickChecker[] onTickCheckers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OnTickCheckers is null) { return; }
          bp.m_OnTickCheckers = bp.m_OnTickCheckers.Where(val => !onTickCheckers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.m_OnTickCheckers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOnTickCheckers(Func<IOnTickChecker, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OnTickCheckers is null) { return; }
          bp.m_OnTickCheckers = bp.m_OnTickCheckers.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.m_OnTickCheckers"/>
    /// </summary>
    public TBuilder ClearOnTickCheckers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OnTickCheckers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_OnTickCheckers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOnTickCheckers(Action<IOnTickChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OnTickCheckers is null) { return; }
          bp.m_OnTickCheckers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.m_AreaTests"/>
    /// </summary>
    public TBuilder SetAreaTests(Dictionary<BlueprintArea,List<AreaTest>> areaTests)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(areaTests);
          bp.m_AreaTests = areaTests;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_AreaTests"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaTests(Action<Dictionary<BlueprintArea,List<AreaTest>>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AreaTests is null) { return; }
          action.Invoke(bp.m_AreaTests);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/>
    /// </summary>
    public TBuilder SetConditionalCommandLists(params ConditionalCommandList[] conditionalCommandLists)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in conditionalCommandLists) { Validate(item); }
          bp.m_ConditionalCommandLists = conditionalCommandLists.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/>
    /// </summary>
    public TBuilder AddToConditionalCommandLists(params ConditionalCommandList[] conditionalCommandLists)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConditionalCommandLists = bp.m_ConditionalCommandLists ?? new();
          bp.m_ConditionalCommandLists.AddRange(conditionalCommandLists);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/>
    /// </summary>
    public TBuilder RemoveFromConditionalCommandLists(params ConditionalCommandList[] conditionalCommandLists)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConditionalCommandLists is null) { return; }
          bp.m_ConditionalCommandLists = bp.m_ConditionalCommandLists.Where(val => !conditionalCommandLists.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromConditionalCommandLists(Func<ConditionalCommandList, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConditionalCommandLists is null) { return; }
          bp.m_ConditionalCommandLists = bp.m_ConditionalCommandLists.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/>
    /// </summary>
    public TBuilder ClearConditionalCommandLists()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConditionalCommandLists = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyConditionalCommandLists(Action<ConditionalCommandList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConditionalCommandLists is null) { return; }
          bp.m_ConditionalCommandLists.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClockworkScenario.m_ComponentId"/>
    /// </summary>
    public TBuilder SetComponentId(Dictionary<string,int> componentId)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(componentId);
          bp.m_ComponentId = componentId;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClockworkScenario.m_ComponentId"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyComponentId(Action<Dictionary<string,int>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ComponentId is null) { return; }
          action.Invoke(bp.m_ComponentId);
        });
    }

    /// <summary>
    /// Adds <see cref="AreaTest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Area Test
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>123</term><description>535217378b8a4ca3ba5a45f0002de07c</description></item>
    /// <item><term>Drezen_Prison</term><description>eab84d625d847bf48864dbe56d30e0b6</description></item>
    /// <item><term>WarCamp_Start_Simple</term><description>cc9b472d6185c754f9f7f8090aef6c8b</description></item>
    /// </list>
    /// </remarks>
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
    /// <param name="areaPart">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAreaTest(
        Blueprint<BlueprintArea, BlueprintAreaReference>? area = null,
        Blueprint<BlueprintAreaPart, BlueprintAreaPartReference>? areaPart = null,
        ClockworkCommandList? commandList = null,
        Condition? condition = null,
        bool? everyVisit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AreaTest();
      component.Area = area?.Reference ?? component.Area;
      if (component.Area is null)
      {
        component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      component.AreaPart = areaPart?.Reference ?? component.AreaPart;
      if (component.AreaPart is null)
      {
        component.AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(null);
      }
      Validate(commandList);
      component.CommandList = commandList ?? component.CommandList;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.EveryVisit = everyVisit ?? component.EveryVisit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ConditionalCommandList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Conditional Command List
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>chap0</term><description>95c4212a36594186b509e87d00d2d480</description></item>
    /// <item><term>mDemon3chap</term><description>6383f35b37eb4a83a8a8458f2937156c</description></item>
    /// <item><term>WoljifQ</term><description>d79f05dbd35b468fa16312f30d61a5e1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddConditionalCommandList(
        ClockworkCommandList? commandList = null,
        Condition? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new ConditionalCommandList();
      Validate(commandList);
      component.CommandList = commandList ?? component.CommandList;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ExploreFlyingIsles"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Area Test
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraTest</term><description>13f5cd02e13249978ea885e86ba155a0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="areas">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddExploreFlyingIsles(
        List<Blueprint<BlueprintArea, BlueprintAreaReference>>? areas = null,
        bool? justIgnoreWalls = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        float? waitTimeAfterCamRotation = null)
    {
      var component = new ExploreFlyingIsles();
      component.Areas = areas?.Select(bp => bp.Reference)?.ToList() ?? component.Areas;
      if (component.Areas is null)
      {
        component.Areas = new();
      }
      component.JustIgnoreWalls = justIgnoreWalls ?? component.JustIgnoreWalls;
      component.WaitTimeAfterCamRotation = waitTimeAfterCamRotation ?? component.WaitTimeAfterCamRotation;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelUpPlan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/MythicLevelUpPlan
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Fighter</term><description>de62074c6cc24ce89073a349aebefef6</description></item>
    /// <item><term>Lich_Fighter</term><description>b0ec7b4817594e7aa941d4c2cd6d04a6</description></item>
    /// <item><term>Trickster_Fighter</term><description>3e0f32cbd70a4773aff644efc48451ab</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="beginnerMythic">
    /// <para>
    /// InfoBox: Первые 2 уровня доступен только Mythic Hero
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="earlyMythic">
    /// <para>
    /// InfoBox: План срабатывает при левелапе на 3 уровень
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="lateMythic">
    /// <para>
    /// InfoBox: План срабатывает при левелапе на 9 уровень
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddMythicLevelUpPlan(
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? beginnerMythic = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? earlyMythic = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? lateMythic = null)
    {
      var component = new MythicLevelUpPlan();
      component.BeginnerMythic = beginnerMythic?.Reference ?? component.BeginnerMythic;
      if (component.BeginnerMythic is null)
      {
        component.BeginnerMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.EarlyMythic = earlyMythic?.Reference ?? component.EarlyMythic;
      if (component.EarlyMythic is null)
      {
        component.EarlyMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.LateMythic = lateMythic?.Reference ?? component.LateMythic;
      if (component.LateMythic is null)
      {
        component.LateMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NavmeshHolesChecker"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/NavmeshHolesChecker
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Fighter</term><description>de62074c6cc24ce89073a349aebefef6</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddNavmeshHolesChecker(
        bool? isInit = null,
        float? lastHeight = null,
        float? maxDeltaHeightPerFrame = null)
    {
      var component = new NavmeshHolesChecker();
      component.m_IsInit = isInit ?? component.m_IsInit;
      component.m_LastHeight = lastHeight ?? component.m_LastHeight;
      component.MaxDeltaHeightPerFrame = maxDeltaHeightPerFrame ?? component.MaxDeltaHeightPerFrame;
      return AddComponent(component);
    }
  }
}
