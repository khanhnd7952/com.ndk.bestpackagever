using UnityEngine;

namespace lib.ndk.Tool
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform following;
        
        private void Update()
        {
            if (following == null) enabled = false;
            transform.position = following.position;
        }
    }
}