using Kingmaker.EntitySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Utils.Assets
{
  /// <summary>
  /// Extension methods to simplify working with Unity assets
  /// </summary>
  public static class AssetExtensions
  {
    /// <summary>
    /// Anchors to a unit. When <paramref name="unit"/> moves or rotates, <paramref name="obj"/> will as well.
    /// </summary>
    /// 
    /// <param name="offset">Offsets the anchor</param>
    /// <param name="rotation">Rotates the object</param>
    public static void AnchorToUnit(
      this GameObject obj, UnitEntityData unit, Vector3? offset = null, Quaternion? rotation = null)
    {
      var anchor = obj.AddComponent<SnapToTransformWithRotation>();
      anchor.Track(unit.View.transform, offset, rotation);
    }

    /// <summary>
    /// Anchors to another object. When <paramref name="target"/> moves or rotates, <paramref name="obj"/> will as well.
    /// </summary>
    /// 
    /// <param name="offset">Offsets the anchor</param>
    /// <param name="rotation">Rotates the object</param>
    public static void AnchorTo(
      this GameObject obj, GameObject target, Vector3? offset = null, Quaternion? rotation = null)
    {
      var anchor = obj.AddComponent<SnapToTransformWithRotation>();
      anchor.Track(target, offset, rotation);
    }

    public static GameObject Copy(this GameObject obj)
    {
      return GameObject.Instantiate(obj);
    }

    public static Transform ChildTransform(this GameObject obj, string path)
    {
      return obj.transform.Find(path);
    }

    public static GameObject ChildObject(this GameObject obj, string path)
    {
      return obj.ChildTransform(path)?.gameObject;
    }

    public static List<GameObject> ChildObjects(this GameObject obj, params string[] paths)
    {
      return paths.Select(p => obj.transform.Find(p)?.gameObject).ToList();
    }

    public static void DestroyChildren(this GameObject obj, params string[] paths)
    {
      obj.ChildObjects(paths).ForEach(GameObject.Destroy);
    }

    public static void DestroyChildrenImmediate(this GameObject obj, params string[] paths)
    {
      obj.ChildObjects(paths).ForEach(GameObject.DestroyImmediate);
    }

    public static void DestroyComponents<T>(this GameObject obj) where T : UnityEngine.Object
    {
      var componentList = obj.GetComponents<T>();
      foreach (var c in componentList)
        GameObject.DestroyImmediate(c);
    }

    public static T EditComponent<T>(this GameObject obj, Action<T> build) where T : Component
    {
      var component = obj.GetComponent<T>();
      build(component);
      return component;
    }

    public static T AddComponent<T>(this GameObject obj, Action<T> init) where T : Component
    {
      var component = obj.AddComponent<T>();
      init(component);
      return component;
    }
  }

  public class SnapToTransformWithRotation : MonoBehaviour
  {
    private Transform Transform;
    private Vector3 Offset;
    private Quaternion Rotation;

    private void Update()
    {
      if (Transform is null)
      {
        enabled = false;
        return;
      }
      transform.position = Transform.position + Offset;
      transform.rotation = Transform.rotation * Rotation;
    }

    internal void Track(GameObject obj, Vector3? offset = null, Quaternion? rotation = null)
    {
      Track(obj.transform, offset, rotation);
    }

    internal void Track(Transform target, Vector3? offset = null, Quaternion? rotation = null)
    {
      Transform = target;
      Offset = offset ?? Vector3.zero;
      Rotation = rotation ?? Quaternion.identity;
      enabled = true;
    }
  }
}
