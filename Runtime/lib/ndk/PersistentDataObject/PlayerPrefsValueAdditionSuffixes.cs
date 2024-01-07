using Newtonsoft.Json;
using UnityEngine;

namespace lib.ndk.PersistentDataObject
{
    public class PlayerPrefsValueAdditionSuffixes<T>
    {
        private string key;
        private T defaultValue;

        public PlayerPrefsValueAdditionSuffixes(string key, T defaultValue)
        {
            this.key = key;
            this.defaultValue = defaultValue;
        }

        string GetPrefKey(string suffixes)
        {
            return key + "_" + suffixes;
        }

        public T GetValue(string suffixes)
        {
            if (PlayerPrefs.HasKey(GetPrefKey(suffixes)))
            {
                string serializedValue = PlayerPrefs.GetString(GetPrefKey(suffixes));
                return JsonConvert.DeserializeObject<T>(serializedValue);
            }
            else
            {
                return defaultValue;
            }
        }

        public void SetValue(string suffixes, T value)
        {
            string serializedValue = JsonConvert.SerializeObject(value);
            PlayerPrefs.SetString(GetPrefKey(suffixes), serializedValue);
        }
    }
}