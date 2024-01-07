using System;
using UnityEditor;
using UnityEngine;

namespace lib.ndk.UI.Tool
{
    public static class UITool
    {
#if UNITY_EDITOR
        public static bool IsSelected(this GameObject goj)
        {
            try
            {
                return (GameObject)Selection.activeObject == goj;

            }
            catch (Exception e)
            {
                return false;
            }
        }
#endif
    }
}