using System;
using Gameplay.Controller;
using lib.ndk.Tool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace lib.ndk.UI.Button
{
    public class UIButton : MonoBehaviour, IPointerClickHandler
    {
        protected virtual void OnClick()
        {
            onClick?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!this.CanClick(0.2f)) return;
            if (SoundController.gInstance != null) SoundController.gInstance.PlayClickButton();
            if (VibrationController.gInstance != null) VibrationController.gInstance.PlayVibrationClickBtn();
            OnClick();
        }

        public UnityEvent onClick;
    }
}