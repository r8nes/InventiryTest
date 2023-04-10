﻿using System;

namespace InventoryTest.Service
{
    public interface IStorageService : IService
    {
        public void Save(string key, object data, Action<bool> callback = null);
        public void Load<T>(string key, Action<T> callback);
    }
}

