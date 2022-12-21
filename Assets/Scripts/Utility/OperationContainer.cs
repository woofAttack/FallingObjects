using System;
using System.Collections.Generic;

public class OperationContainer<T> where T: IDestructible
{
    private List<T> _list = new List<T>();
    private Action<T> _operation;

    public OperationContainer(Action<T> operation)
    {
        _operation = operation;
    }

    public void AddNew(T obj)
    {
        _list.Add(obj);
        obj.OnDestroyObject += Remove;
    }

    public void InvokeOperation()
    {
        foreach(var collectingObject in _list)
        {
            _operation.Invoke(collectingObject);
        }
    }

    private void Remove(IDestructible obj) => Remove((T)obj);

    private void Remove(T obj)
    {
        _list.Remove(obj);
        obj.OnDestroyObject -= Remove;
    }
}