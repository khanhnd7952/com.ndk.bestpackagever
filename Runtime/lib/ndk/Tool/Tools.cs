using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace lib.ndk.Tool
{
    public static class Tools
    {
        #region DelayClick_________________________________________________________________________________________________________

        private static readonly List<MonoBehaviour> DelayButtons = new List<MonoBehaviour>();

        public static async void DelayCallBack(Action action, float time)
        {
            await Task.Delay((int) (time * 1000f));
            action?.Invoke();
        }

        public static bool CanClick(this MonoBehaviour button, float timeDelay = 0.2f)
        {
            if (DelayButtons.Contains(button))
            {
                Debug.Log("Click chậm thôi: " + button.name);
                return false;
            }
            DelayButtons.Add(button);
            DelayCallBack(() => { DelayButtons.Remove(button); }, timeDelay);
            //SoundController.PlayClickSound();
            return true;
        }

        #endregion
    }
}