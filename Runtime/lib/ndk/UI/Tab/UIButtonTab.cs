using System;
using lib.ndk.Tool;
using UnityEngine;
using UnityEngine.EventSystems;

namespace lib.ndk.UI.Tab
{
    public class UIButtonTab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject activeButton;

        public void ActiveButton(bool isActive)
        {
            activeButton.SetActive(isActive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!this.CanClick()) return;
            onClick?.Invoke(this);
        }

        public Action<UIButtonTab> onClick;
    }
}