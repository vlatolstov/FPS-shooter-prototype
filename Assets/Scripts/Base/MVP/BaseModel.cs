using System;
using System.Collections.Generic;

public abstract class BaseModel<T> : IModel where T : BaseDataContainer {

    protected T DataContainer { get; private set; }
    private Dictionary<Type, IList<Action>> _dataListeners = new();

    protected BaseModel(T container) {
        DataContainer = container;
    }

    protected void ChangeData<TData>(Action<TData, T> action) where TData : IData {

        action?.Invoke(DataContainer.GetData<TData>(), DataContainer);

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

