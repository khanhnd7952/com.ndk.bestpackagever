using UnityEngine;

namespace lib.ndk
{
    public abstract class sSingleton<T> : MonoBehaviour where T : sSingleton<T>
    {
        public bool DontDestroyOnLoad = false;

        public static T gInstance { get; private set; }

        protected virtual void Awake()
        {
            if (gInstance == null)
            {
                gInstance = this as T;
                Init();
                if (DontDestroyOnLoad) DontDestroyOnLoad(this.gameObject);
            }
            else Destroy(this.gameObject);
        }

        protected virtual void Init()
        {
        }
    }
}