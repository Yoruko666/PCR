using System;
using System.Collections.Generic;

public abstract class SingletonTree<TOwnerClass> : BaseSingletonTree
{
    protected SingletonNode currentNode;

    protected SingletonTree()
        : base()
    {
    }

    /// <summary>
    /// 初始化树结构（仅首次调用有效），并根据 TOwnerClass 定位当前节点。
    /// </summary>
    public void OnceInit()
    {
        if (rootNode == null)
        {
            rootNode = new SingletonNode();
            dicNode[ROOT_KEY] = rootNode;
            setupTree();
        }

        string key = typeof(TOwnerClass).FullName;
        if (key != null && dicNode.TryGetValue(key, out SingletonNode node))
        {
            currentNode = node;
        }
    }

    /// <summary>
    /// 根据 TOwnerClass 全名查找节点并设为当前节点。
    /// </summary>
    public void Init()
    {
        if (rootNode != null)
        {
            string key = typeof(TOwnerClass).FullName;
            if (key != null && dicNode.TryGetValue(key, out SingletonNode node))
            {
                currentNode = node;
            }
        }
    }

    /// <summary>
    /// 根据指定的起始节点键名查找节点并设为当前节点。
    /// </summary>
    public void Init(string _findStartNodeKey)
    {
        if (dicNode.TryGetValue(_findStartNodeKey, out SingletonNode node))
        {
            currentNode = node;
        }
    }

    /// <summary>
    /// 子类实现此方法，在 OnceInit 中构建树结构。
    /// </summary>
    protected abstract void setupTree();

    /// <summary>
    /// 添加子节点到指定父节点，并注册到全局字典。
    /// </summary>
    protected void addNode(SingletonNode _parentNode, Type _childKey, SingletonNode _childNode)
    {
        string key = _childKey.FullName;
        _parentNode.AddChild(key, _childNode);
        dicNode[key] = _childNode;
    }

    /// <summary>
    /// 创建新节点并添加到指定父节点，同时注册到全局字典。
    /// </summary>
    public SingletonNode AddNode(ISingletonNodeForInstanceEditing _parentNode, Type _childKey)
    {
        var child = new SingletonNode();
        string key = _childKey.FullName;
        ((SingletonNode)_parentNode).AddChild(key, child);
        dicNode[key] = child;
        return child;
    }

    /// <summary>
    /// 创建新节点并添加到指定父节点，但不注册到全局字典。
    /// </summary>
    public SingletonNode AddNodeNotDic(ISingletonNodeForInstanceEditing _parentNode, Type _childKey)
    {
        var child = new SingletonNode();
        string key = _childKey.FullName;
        ((SingletonNode)_parentNode).AddChild(key, child);
        return child;
    }

    /// <summary>
    /// 从指定父节点移除子节点，并从全局字典移除注册。
    /// </summary>
    public void RemoveNode(ISingletonNodeForInstanceEditing _parentNode, string _key)
    {
        ((SingletonNode)_parentNode).RemoveChild(_key);
        dicNode.Remove(_key);
    }

    /// <summary>
    /// 从指定父节点移除子节点，并从全局字典移除注册。
    /// </summary>
    public void RemoveNode(ISingletonNodeForInstanceEditing _parentNode, Type _childKey)
    {
        string key = _childKey.FullName;
        ((SingletonNode)_parentNode).RemoveChild(key);
        dicNode.Remove(key);
    }

    /// <summary>
    /// 从指定父节点移除子节点，但不从全局字典移除。
    /// </summary>
    public void RemoveNodeNotDic(ISingletonNodeForInstanceEditing _parentNode, Type _childKey)
    {
        string key = _childKey.FullName;
        ((SingletonNode)_parentNode).RemoveChild(key);
    }

    /// <summary>
    /// 从当前节点获取指定类型的实例。
    /// </summary>
    public T Get<T>() where T : class
    {
        return currentNode?.Get<T>();
    }

    /// <summary>
    /// 从当前节点按指定键名获取实例。
    /// </summary>
    public T Get<T>(string _key) where T : class
    {
        return currentNode?.Get<T>(_key);
    }

    /// <summary>
    /// 获取当前节点（以接口形式）。
    /// </summary>
    public ISingletonNodeForInstanceEditing GetCurrentNodeForInstanceEditing()
    {
        return currentNode;
    }

    /// <summary>
    /// 获取当前节点。
    /// </summary>
    public SingletonNode GetCurrentNode()
    {
        return currentNode;
    }

    /// <summary>
    /// 清除所有节点。
    /// </summary>
    public static void Clear()
    {
        rootNode = null;
        dicNode?.Clear();
    }

    /// <summary>
    /// 根据键名获取节点。
    /// </summary>
    public ISingletonNodeForInstanceEditing GetNode(string _key)
    {
        if (dicNode.TryGetValue(_key, out SingletonNode node))
        {
            return node;
        }
        return null;
    }

    /// <summary>
    /// 将已有子节点添加到指定父节点，并注册到全局字典。
    /// </summary>
    public void AddNode(SingletonNode _parent, string _key, SingletonNode _childNode)
    {
        _parent.AddChild(_key, _childNode);
        dicNode[_key] = _childNode;
    }
}
