using BlueprintCoreGen.CodeGen.Methods;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace BlueprintCoreGen.CodeGen.Builders
{
  /// <summary>
  /// Contains basic information needed to generate a builder extension class.
  /// </summary>
  public interface IBuilderExtension
  {
    /// <summary>
    /// Relative file path of the class, e.g. Actions/Builder/AreaEx/ActionsBuilderAreaEx.cs.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Namespace for the extension class, e.g. BlueprintCore.Actions.Builder.AreaEx
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Name of the extension, e.g. AreaEx for ActionsBuilderAreaEx.
    /// </summary>
    public string ClassName { get; }

    /// <summary>
    /// Extension class summary comment.
    /// </summary>
    public string Summary { get; }

    /// <summary>
    /// Type name for the parent class, e.g. ActionsBuilder
    /// </summary>
    public string ParentType { get; }

    /// <summary>
    /// List of methods in the extension.
    /// </summary>
    public List<BuilderMethod> Methods { get; }
  }

  public enum BuilderType
  {
    Action,
    Condition
  }

  /// <summary>
  /// Contains configuration for the builder extension classes.
  /// </summary>
  /// 
  /// Configuration in this context is everything defined in IBuilderExtension, so it will determine the class names,
  /// file paths, class comment summary, which element types are implemented, etc.
  public static class BuilderExtensions
  {
    public static List<IBuilderExtension> Get(BuilderType type)
    {
      if (type == BuilderType.Action) { return ActionExtensions; }
      return ConditionExtensions;
    }

    private static readonly List<IBuilderExtension> ConditionExtensions =
      new()
      {
        new ConditionExtension(
          ExtensionType.AreaEx,
          "Extension to <see cref=\"ConditionsBuilder\"/> for conditions involving the game map, dungeons, or locations."
              + " See also <see cref=\"KingdomEx.ConditionsBuilderKingdomEx\">KingdomEx</see>.",
          "AreaConditions.json"),

        new ConditionExtension(
          ExtensionType.BasicEx,
          "Extension to <see cref=\"ConditionsBuilder\"/> for most game mechanics related conditions not included in"
              + " <see cref=\"ContextEx.ConditionsBuilderContextEx\">ContextEx</see>.",
          "BasicConditions.json"),

        new ConditionExtension(
          ExtensionType.ContextEx,
          "Extension to <see cref=\"ConditionsBuilder\"/> for most <see cref=\"ContextCondition\"/> types. Some"
              + " <see cref=\"ContextCondition\"/> types are in more specific extensions such as"
              + " <see cref=\"KingdomEx.ConditionsBuilderKingdomEx\">KingdomEx</see>.",
          "ContextConditions.json"),

        //new ConditionExtension(
        //  ExtensionType.KingdomEx,
        //  "Extension to <see cref=\"ConditionsBuilder\"/> for conditions involving the Kingdom and Crusade system.",
        //  "KingdomConditions.json"),

        //new ConditionExtension(
        //  ExtensionType.MiscEx,
        //  "Extension to <see cref=\"ConditionsBuilder\"/> for conditions without a better extension container such as"
        //      + " achievements vendor Conditions, and CustomEvent.",
        //  "MiscConditions.json"),

        //new ConditionExtension(
        //  ExtensionType.NewEx,
        //  "Extension to <see cref=\"ConditionsBuilder\"/> for conditions defined in BlueprintCore and not available in the"
        //      + " base game.",
        //  "NewConditions.json"),

        //new ConditionExtension(
        //  ExtensionType.StoryEx,
        //  "Extension to <see cref=\"ConditionsBuilder\"/> for conditions related to the story such as companion stories,"
        //      + " quests, name changes, and etudes.",
        //  "StoryConditions.json"),
      };

    private static readonly List<IBuilderExtension> ActionExtensions =
      new()
      {
        new ActionExtension(
          ExtensionType.AreaEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions involving the game map, dungeons, or locations."
              + " See also <see cref=\"KingdomEx.ActionsBuilderKingdomEx\">KingdomEx</see>.",
          "AreaActions.json"),

        new ActionExtension(
          ExtensionType.AVEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions involving audiovisual effects such as dialogs,"
              + " camera, cutscenes, and sounds.",
          "AVActions.json"),

        new ActionExtension(
          ExtensionType.BasicEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for most game mechanics related actions not included in"
              + " <see cref=\"ContextEx.ActionsBuilderContextEx\">ContextEx</see>.",
          "BasicActions.json"),

        new ActionExtension(
          ExtensionType.ContextEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for most <see cref=\"ContextAction\"/> types. Some"
              + " <see cref=\"ContextAction\"/> types are in more specific extensions such as"
              + " <see cref=\"AVEx.ActionsBuilderAVEx\">AVEx</see> or"
              + " <see cref=\"KingdomEx.ActionsBuilderKingdomEx\">KingdomEx</see>.",
          "ContextActions.json"),

        new ActionExtension(
          ExtensionType.KingdomEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions involving the Kingdom and Crusade system.",
          "KingdomActions.json"),

        new ActionExtension(
          ExtensionType.MiscEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions without a better extension container such as"
              + " achievements vendor actions, and CustomEvent.",
          "MiscActions.json"),

        //new ActionExtension(
        //  ExtensionType.NewEx,
        //  "Extension to <see cref=\"ActionsBuilder\"/> for actions defined in BlueprintCore and not available in the"
        //      + " base game.",
        //  "NewActions.json"),

        new ActionExtension(
          ExtensionType.StoryEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions related to the story such as companion stories,"
              + " quests, name changes, and etudes.",
          "StoryActions.json"),

        new ActionExtension(
          ExtensionType.UpgraderEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for all UpgraderOnlyActions.",
          "UpgraderActions.json"),
      };

    // Used in class names and namespaces directly
    private enum ExtensionType
    {
      AreaEx,
      AVEx,
      BasicEx,
      ContextEx,
      KingdomEx,
      MiscEx,
      NewEx,
      StoryEx,
      UpgraderEx,
    }

    private abstract class BuilderExtensionImpl : IBuilderExtension
    {
      public string FilePath { get; }

      public string Namespace { get; }

      public string ClassName { get; }

      public string Summary { get; }

      public string ParentType { get; }

      private readonly string OverrideFilePath;
      private List<BuilderMethod>? m_BuilderMethods;
      public List<BuilderMethod> Methods
      {
        get
        {
          if (m_BuilderMethods == null)
          {
            JArray array = JArray.Parse(File.ReadAllText(OverrideFilePath));
            m_BuilderMethods = array.ToObject<List<BuilderMethod>>();
          }
          return m_BuilderMethods!;
        }
      }

      protected BuilderExtensionImpl(
          BuilderType builderType, ExtensionType extensionType, string summary, string overrideFile)
      {
        Summary = summary;

        if (builderType == BuilderType.Action)
        {
          ClassName = $"ActionsBuilder{extensionType}";
          FilePath = $"Actions\\Builder\\{extensionType}\\{ClassName}.cs";
          Namespace = $"BlueprintCore.Actions.Builder.{extensionType}";
          ParentType = "ActionsBuilder";
          OverrideFilePath = $"CodeGen/Overrides/Actions/{overrideFile}";
        }
        else
        {
          ClassName = $"ConditionsBuilder{extensionType}";
          FilePath = $"Conditions\\Builder\\{extensionType}\\{ClassName}.cs";
          Namespace = $"BlueprintCore.Conditions.Builder.{extensionType}";
          ParentType = "ConditionsBuilder";
          OverrideFilePath = $"CodeGen/Overrides/Conditions/{overrideFile}";
        }
      }
    }

    private class ActionExtension : BuilderExtensionImpl
    {
      public ActionExtension(ExtensionType type, string summary, string overrideFile)
        : base(BuilderType.Action, type, summary, overrideFile)
      { }
    }

    private class ConditionExtension : BuilderExtensionImpl
    {
      public ConditionExtension(ExtensionType type, string summary, string overrideFile)
        : base(BuilderType.Condition, type, summary, overrideFile)
      { }
    }
  }
}
