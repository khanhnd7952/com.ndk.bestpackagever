using UnityEngine;

namespace lib.ndk.Extension.Renderer
{
    public class DisableRendererOnStart : MonoBehaviour
    {
        private void Start()
        {
            UnityEngine.Renderer renderer = GetComponent<UnityEngine.Renderer>();
            if (renderer == null) return;
            renderer.enabled = false;
        }
    }
}