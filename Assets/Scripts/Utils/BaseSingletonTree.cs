using System.Collections.Generic;

public class BaseSingletonTree
{
    protected const string ROOT_KEY = "Root";
    protected static SingletonNode rootNode;
    protected static Dictionary<string, SingletonNode> dicNode;

    public BaseSingletonTree()
    {
        if (dicNode == null)
        {
            dicNode = new Dictionary<string, SingletonNode>();
        }
    }
}
