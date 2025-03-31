using System;
using System.Collections.Generic;

public abstract class BaseModel<T> : IModel where T : BaseDataContainer {

    private T _dataContainer;
    private Dictionary<Type, IList<Action>> _dataListeners;

    protected BaseModel(T container) {
        _dataContainer = container;
    }

    protected void ChangeData<TData>(Action<TData, T> action) where TData : IData {

        action?.Invoke(_dataContainer.GetData<TData>(), _dataContainer);

        var type = typeof(TData);

        if (_dataListeners.ContainsKey(type)) {
            foreach (var a in _dataListeners[type]) {
                a?.Invoke();
            }
        }
    }

    public void Subscribe<TData>(Action action) where TData : IData {
        var type = typeof(TData);

        if (!_dataListeners.ContainsKey(type))
            _dataListeners[type] = new List<Action>();

        _dataListeners[type].Add(action);
    }

    public void Unsubscribe<TData>(Action action) where TData : IData {
        var type = typeof(TData);

        if (_dataListeners.ContainsKey(type)) {
            _dataListeners[type].Remove(action);
        }
    }
}

