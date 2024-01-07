using System.Threading.Tasks;
using UnityEngine;

namespace lib.ndk.Extension
{
    public static class AudioSourceExtension
    {
        public static async void SmoothVolume(this AudioSource source, float volume , float speed = 0.02f)
        {
            float dir = Mathf.Sign(volume - source.volume);
            while (Mathf.Abs(source.volume - volume) > speed)
            {
                source.volume += 0.02f * dir;
                await Task.Delay(100);
            }

            source.volume = volume;
        }
    }
}