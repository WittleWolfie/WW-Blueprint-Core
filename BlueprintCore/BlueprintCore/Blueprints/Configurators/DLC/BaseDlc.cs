//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDlc"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDlcConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDlc
    where TBuilder : BaseDlcConfigurator<T, TBuilder>
  {
    protected BaseDlcConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="DlcStoreCheat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isAvailableInDevBuild">
    /// <para>
    /// Tooltip: Is the DLC available in development build
    /// </para>
    /// </param>
    /// <param name="isAvailableInEditor">
    /// <para>
    /// Tooltip: Is the DLC available in editor playmode
    /// </para>
    /// </param>
    public TBuilder AddDlcStoreCheat(
        bool? isAvailableInDevBuild = null,
        bool? isAvailableInEditor = null)
    {
      var component = new DlcStoreCheat();
      component.m_IsAvailableInDevBuild = isAvailableInDevBuild ?? component.m_IsAvailableInDevBuild;
      component.m_IsAvailableInEditor = isAvailableInEditor ?? component.m_IsAvailableInEditor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreEpic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorderAndCommanderPack</term><description>566f5b21c1c147debc88578ea6092a6f</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDlcStoreEpic(
        string? epicId = null)
    {
      var component = new DlcStoreEpic();
      component.m_EpicId = epicId ?? component.m_EpicId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreGog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDlcStoreGog(
        ulong? gogId = null)
    {
      var component = new DlcStoreGog();
      component.m_GogId = gogId ?? component.m_GogId;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreSteam"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDlcStoreSteam(
        uint? steamId = null)
    {
      var component = new DlcStoreSteam();
      component.m_SteamId = steamId ?? component.m_SteamId;
      return AddComponent(component);
    }
  }
}
