using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace lib.ndk.UI.BaseUI.Example
{
    public class UIController : MonoBehaviour
    {
        private Stack<PanelUI> saveLastStates = new Stack<PanelUI>();

        [ShowInInspector]
        List<PanelUI> saveLastStatesIns
        {
            get
            {
                var result = new List<PanelUI>();
                foreach (PanelUI gameUI in saveLastStates)
                {
                    result.Add(gameUI);
                }

                return result;
            }
        }

        [ReadOnly] public PanelUI currentUI;


        [Button]
        public void SwitchState(PanelUI newUI)
        {
            if (currentUI == newUI) return;
            TransactionState(currentUI, newUI);
            if (currentUI != null) saveLastStates.Push(currentUI);
            currentUI = newUI;
        }

        void TransactionState(PanelUI from, PanelUI to)
        {
            if (from == null)
            {
                to.SShow();
            }
            else
            {
                from.HHide();
                from.onHideDoneFixedTransision = to.SShow;
            }
        }

        [Button]
        public void BackToLastState()
        {
            if (saveLastStates.Count == 0) return;
            var next = saveLastStates.Pop();
            TransactionState(currentUI, next);
            currentUI = next;
        }


        [Button]
        public void EnableTouch()
        {
            Debug.Log("Enable Touch");
            EventSystem.current.enabled = false;
        }

        [Button]
        public void DisableTouch()
        {
            Debug.Log("Disable Touch");
            EventSystem.current.enabled = true;
        }

        public Action onStateChange;
        
    }
}