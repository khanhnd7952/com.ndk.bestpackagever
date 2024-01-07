using UnityEngine;

namespace lib.ndk.Tool
{
    public class Rotater : MonoBehaviour
    {
        [SerializeField] private float rps = 1;

        [SerializeField] private bool canRotate = false;

        public void StartRotate()
        {
            canRotate = true;
        }

        public void StopRotate()
        {
            canRotate = false;
        }

        public void SetSpeed(float rps)
        {
            this.rps = rps;
        }

        private void FixedUpdate()
        {
            if (!canRotate) return;
            transform.Rotate(Vector3.forward, 360f * rps * Time.fixedDeltaTime);
        }
    }
}