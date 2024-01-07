using System;
using Newtonsoft.Json;
using UnityEngine;

namespace lib.ndk.PersistentDataObject
{
    public class PlayerPrefsValue<T>
    {
        private string key;
        private T defaultValue;

        public PlayerPrefsValue(string key, T defaultValue)
        {
            this.key = key;
            this.defaultValue = defaultValue;
        }

        public T Value
        {
            get
            {
                if (PlayerPrefs.HasKey(key))
                {
                    string serializedValue = PlayerPrefs.GetString(key);
                    return Deserialize(serializedValue);
                }
                else
                {
                    return defaultValue;
                }
            }
            set
            {
                string serializedValue = Serialize(value);
                PlayerPrefs.SetString(key, serializedValue);
                onValueChange?.Invoke();
            }
        }

        private string Serialize(T value)
        {
            //return value.ToString(); // For primitive types, simply convert to string.
            return JsonConvert.SerializeObject(value); // For primitive types, simply convert to string.
        }

        private T Deserialize(string serializedValue)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(serializedValue);
            }
            catch (System.Exception)
            {
                Debug.LogWarning(
                    $"Failed to deserialize PlayerPrefs key '{key}' to type '{typeof(T)}'. Using default value.");
                return defaultValue;
            }
        }

        public Action onValueChange;
    }
}