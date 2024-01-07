using UnityEngine;

namespace lib.ndk.nLogger
{
    public static class L
    {
        public static bool EnableLog = true;

        public static void Log(string message)
        {
            if (!EnableLog) return;
            Debug.Log($"<color=green>{message}</color>");
        }
    }
}