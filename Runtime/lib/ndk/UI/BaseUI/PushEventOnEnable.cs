using System;
using UnityEngine;

namespace lib.ndk.UI.BaseUI
{
    public class PushEventOnEnable : MonoBehaviour
    {
        private void OnEnable()
        {
            onEnable?.Invoke();
        }

        public Action onEnable;
    }
}