using UnityEngine;

namespace lib.ndk.Extension.ScaleOnTableDevice
{
    public class ScaleOnIpadDevice : MonoBehaviour
    {
        public float scaleRatio = 1f;

        private void Awake()
        {
            if (DeviceTypeChecker.GetDeviceType() == ENUM_Device_Type.Tablet)
            {
                transform.localScale *= scaleRatio;
            }
        }
    }
}