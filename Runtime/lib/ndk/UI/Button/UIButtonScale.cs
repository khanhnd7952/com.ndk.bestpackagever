using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace lib.ndk.UI.Button
{
    //[ExecuteInEditMode]
    public class UIButtonScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        float minScale = 0.85f;
        float scaleDuration = 0.15f;

        private Vector3 originalScale;
        private bool isScaling = false;

        private void Start()
        {
            originalScale = transform.localScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isScaling = true;
            transform.DOScale(new Vector3(minScale * originalScale.x, minScale * originalScale.y, 1f), scaleDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isScaling)
            {
                isScaling = false;
                transform.DOScale(originalScale, scaleDuration);
            }
        }
    }
}