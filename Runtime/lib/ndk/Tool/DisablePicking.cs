using System;
using UnityEditor;
using UnityEngine;

namespace lib.ndk.Tool
{
    public class DisablePicking : MonoBehaviour
    {
#if UNITY_EDITOR
        // private void OnValidate()
        // {
        //     SceneVisibilityManager.instance.DisablePicking(gameObject, false);
        // }
#endif
    }
}