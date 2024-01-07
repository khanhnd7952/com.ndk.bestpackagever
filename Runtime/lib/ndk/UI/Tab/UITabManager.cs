using System;
using UnityEngine;
using UnityEngine.Events;

namespace lib.ndk.UI.Tab
{
    public class UITabManager : MonoBehaviour
    {
        [Serializable]
        public struct Tab
        {
            public string tabId;
            public UIButtonTab uiButton;
            public GameObject[] tabContents;
            public UnityEvent onClick;
        }

        public Tab[] tabs;

        private void Awake()
        {
            foreach (Tab tab in tabs)
            {
                tab.uiButton.onClick += ClickTab;
            }
        }

        private void Start()
        {
            ClickTab(tabs[0].uiButton);
        }

        public void ClickTab(UIButtonTab uiButton)
        {
            foreach (Tab tab in tabs)
            {
                bool active = uiButton == tab.uiButton;
                tab.uiButton.ActiveButton(active);
                foreach (GameObject tabTabContent in tab.tabContents)
                {
                    tabTabContent.SetActive(active);
                }

                if (active)
                {
                    tab.onClick?.Invoke();
                }
            }
        }
    }
}