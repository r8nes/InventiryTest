using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace InventoryTest.Service
{
    public class JsonFileStorageService : IStorageService
    {
        private bool _inProgressNow;

        public void Save(string key, object data, Action<bool> callback = null)
        {
            if (!_inProgressNow)
            {
                SaveAsync(key, data, callback);
            }
            else
            {
                callback?.Invoke(false);
            }
        }

        public async void SaveAsync(string key, object data, Action<bool> callback = null)
        {
            string path = BuildPath(key);
            string json = JsonConvert.SerializeObject(data);

            using (var fileStream = new StreamWriter(path))
            {
                await fileStream.WriteAsync(json);
            }

            callback?.Invoke(true);
        }

        public void Load<T>(string key, Action<T> callback)
        {
            string path = BuildPath(key);

            using (var fileStream = new StreamReader(path))
            {
                var json = fileStream.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);

                callback?.Invoke(data);
            }
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}

