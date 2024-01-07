using System;
using lib.ndk.Tool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace lib.ndk.UI.Button
{
    public abstract class UIButtonToggle : UIButton
    {
        [SerializeField] protected GameObject activeGroup, deactiveGroup;

        void OnEnable()
        {
            UpdateDisplay();
        }

        protected override void OnClick()
        {
            base.OnClick();
            Debug.Log("Click Toggle");
            InverseState();
            UpdateDisplay();
        }


        void UpdateDisplay()
        {
            activeGroup.SetActive(GetCurrentState());
            deactiveGroup.SetActive(!GetCurrentState());
        }

        protected abstract void InverseState();

        protected abstract bool GetCurrentState();
    }
}