using System;
using System.Collections.Generic;

using UnityEngine;

public class BaseDataContainer {
    private Dictionary<Type, IData> _dataContainer = new();

    public BaseDataContainer(IEnumerable<IData> data) {
        foreach (var item in data) {
            AddData(item);
        }
    }

    private void AddData<T>(T data) where T : IData {
        var type = data.GetType();

        if (!_dataContainer.ContainsKey(type)) {
            _dataContainer.Add(type, data);
        }
    }

    public T GetData<T>() where T : IData {
        var type = typeof(T);

        if (_dataContainer.TryGetValue(type, out IData data)) {
            return (T)data;
        }
        return default;
    }
}
