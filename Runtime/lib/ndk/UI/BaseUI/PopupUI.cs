using UnityEngine;

namespace lib.ndk.UI.BaseUI
{
    public class PopupUI<T> : PanelUI where T : PopupUI<T>
    {
        public static T gInstance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if (gInstance == null)
            {
                gInstance = this as T;
            }
            else Destroy(this.gameObject);
        }
    }

}