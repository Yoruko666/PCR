using System;
using System.Collections.Generic;

public class SingletonNode : ISingletonNodeForInstanceEditing
{
    private SingletonNode parent;
    private Dictionary<string, SingletonNode> children;
    private Dictionary<string, object> dicInstance;

    public SingletonNode()
    {
        children = new Dictionary<string, SingletonNode>();
        dicInstance = new Dictionary<string, object>();
    }

    public void SetParent(SingletonNode _parent)
    {
        parent = _parent;
    }

    public void AddChild(string _key, SingletonNode _child)
    {
        _child.SetParent(this);
        children[_key] = _child;
    }

    public void RemoveChild(string _key)
    {
        if (children.TryGetValue(_key, out SingletonNode child))
        {
            child.SetParent(null);
            children.Remove(_key);
        }
    }

    public SingletonNode FindChild(string _key)
    {
        if (children.TryGetValue(_key, out SingletonNode child))
        {
            return child;
        }

        foreach (var kv in children)
        {
            SingletonNode result = kv.Value.FindChild(_key);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    public void AddInstance(object _instance)
    {
        AddInstance(_instance.GetType().FullName, _instance);
    }

    public void AddInstance(Type _type, object _instance)
    {
        AddInstance(_type.FullName, _instance);
    }

    public void AddInstance(string _className, object _instance)
    {
        dicInstance[_className] = _instance;
    }

    public void RemoveInstance(object _instance)
    {
        string foundKey = null;
        foreach (var kv in dicInstance)
        {
            if (kv.Value == _instance)
            {
                foundKey = kv.Key;
                break;
            }
        }
        if (foundKey != null)
        {
            dicInstance.Remove(foundKey);
        }
    }

    public void RemoveInstance(Type _type)
    {
        RemoveInstance(_type.FullName);
    }

    public void RemoveInstance(string _key)
    {
        dicInstance.Remove(_key);
    }

    public void AllRemoveInstance()
    {
        dicInstance.Clear();
    }

    public T Get<T>() where T : class
    {
        return Get<T>(typeof(T).FullName);
    }

    public T Get<T>(string _key) where T : class
    {
        if (dicInstance.TryGetValue(_key, out object instance) && instance is T result)
        {
            return result;
        }

        return getWithClassName<T>(_key, this);
    }

    private T getWithClassName<T>(string _className, SingletonNode _node) where T : class
    {
        foreach (var kv in _node.children)
        {
            SingletonNode child = kv.Value;
            if (child.dicInstance.TryGetValue(_className, out object instance) && instance is T result)
            {
                return result;
            }

            T found = getWithClassName<T>(_className, child);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }
}
