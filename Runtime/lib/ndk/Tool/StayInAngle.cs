using UnityEngine;

namespace lib.ndk.Tool
{
    public class StayInAngle : MonoBehaviour
    {
        [SerializeField] private Vector3 eulerAngle;

        private void Update()
        {
            transform.eulerAngles = eulerAngle;
        }
    }
}