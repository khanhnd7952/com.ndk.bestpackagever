using System;
using UnityEngine;

namespace lib.ndk.UI.Tool
{
    public class FamilyComponent : MonoBehaviour
    {
        [SerializeField] private Component sourceComponent;

        
        [SerializeField] private bool isLinking = false;
        [SerializeField] private string componentTag;
        [SerializeField] private Component linkComponent;

        private void Update()
        {
            if (sourceComponent == null || linkComponent == null) return;
            
            

        }
    }
}