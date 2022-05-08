using BlueprintCoreGen.CodeGen.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Processes BuilderExtensions and Configurators to generate builder and configurator classes.
  /// </summary>
  public static class ClassProcessor
  {
    public static readonly List<IClassFile> ActionClasses = new();
    public static readonly List<IClassFile> ConditionClasses = new();
    public static readonly List<IClassFile> ConfiguratorClasses = new();

    public static void Run(Type[] gameTypes)
    {
      var templatesRoot = Path.Combine(Directory.GetCurrentDirectory(), "Templates");

      ActionClasses.AddRange(
          BuilderExtensions.Get(BuilderType.Action).Select(
              extension => ClassFactory.CreateBuilderExtension(extension)));

      ConditionClasses.AddRange(
          BuilderExtensions.Get(BuilderType.Condition).Select(
              extension => ClassFactory.CreateBuilderExtension(extension)));

      ConfiguratorClasses.AddRange(
        Configurators.Get(gameTypes).Select(configurator => ClassFactory.CreateConfigurator(configurator)));
    }

    public static List<Type> GetUnhandledTypes(
        Type baseType, ICollection<Type> handledTypes, Type[] gameTypes, bool includeAbstractTypes = false)
    {
      List<Type> unhandledTypes = new();
      foreach (Type type in gameTypes.Where(t => t.IsSubclassOf(baseType)))
      {
        if (!handledTypes.Contains(type) && (!type.IsAbstract || includeAbstractTypes))
        {
          unhandledTypes.Add(type);
        }
      }
      return unhandledTypes;
    }
  }
}
