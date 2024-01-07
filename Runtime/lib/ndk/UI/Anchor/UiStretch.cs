using System;
using lib.ndk.Tool;
using UnityEngine;

namespace lib.ndk.UI.Anchor
{
    [RequireComponent(typeof(DisablePicking))]
    [ExecuteInEditMode]
    public class UiStretch : MonoBehaviour
    {
        private void Update()
        {
#if UNITY_EDITOR
            if (Application.isPlaying) return;
            Stretch();
#endif
        }

        void Stretch()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();

            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.pivot = 0.5f * Vector2.one;

            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }
    }
}