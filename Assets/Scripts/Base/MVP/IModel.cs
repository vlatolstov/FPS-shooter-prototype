using System;

public interface IModel {
    void Subscribe<TData>(Action action) where TData : IData;
    void Unsubscribe<TData>(Action action) where TData : IData;
}
