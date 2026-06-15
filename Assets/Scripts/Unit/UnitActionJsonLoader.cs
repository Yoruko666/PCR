using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 从 UNIT_xxx.json 加载技能动作数据，填充到 UnitActionController。
/// 使用 Newtonsoft.Json 预处理 {"data": {...}} 包装，然后 JsonUtility 完成最终反序列化。
/// </summary>
public static class UnitActionJsonLoader
{
    public static UnitActionController LoadAndPopulate(string unitId, GameObject targetGo)
    {
        string jsonText = ReadJsonText(unitId);
        if (string.IsNullOrEmpty(jsonText)) return null;

        // 1. 用 Newtonsoft 解析 JSON
        JObject root;
        try
        {
            root = JObject.Parse(jsonText);
        }
        catch (JsonReaderException e)
        {
            Debug.LogError($"[UnitActionJsonLoader] UNIT_{unitId}.json 解析失败: {e.Message}");
            return null;
        }

        // 2. 递归移除所有 {"data": {...}} 包装
        UnwrapDataWrappers(root);

        // 3. 移除 Unity 序列化元字段 (m_GameObject, m_Enabled, m_Script, m_Name)
        root.Remove("m_GameObject");
        root.Remove("m_Enabled");
        root.Remove("m_Script");
        root.Remove("m_Name");

        // 4. 转为 JSON 字符串，用 JsonUtility 反序列化到实际类型（处理 AnimationCurve / Color 等）
        string cleanedJson = root.ToString(Formatting.None);
        var controller = targetGo.GetComponent<UnitActionController>();
        if (controller == null)
            controller = targetGo.AddComponent<UnitActionController>();

        JsonUtility.FromJsonOverwrite(cleanedJson, controller);

        return controller;
    }

    /// <summary>
    /// 递归遍历 JToken 树，将所有 { "data": {...} } 形式的对象替换为其内部值。
    /// </summary>
    private static void UnwrapDataWrappers(JToken token)
    {
        if (token is JObject obj)
        {
            // 如果对象只有一个 "data" 属性，且值是个对象，则用内部对象替换当前节点
            if (obj.Count == 1 && obj["data"] is JObject innerObj)
            {
                UnwrapDataWrappers(innerObj);
                obj.Replace(innerObj);
                return; // 替换后不再继续遍历当前节点
            }

            // 否则正常遍历所有子属性
            var props = obj.Properties().ToList();
            foreach (var prop in props)
                UnwrapDataWrappers(prop.Value);
        }
        else if (token is JArray arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] is JObject itemObj && itemObj.Count == 1 && itemObj["data"] is JToken dataVal)
                {
                    UnwrapDataWrappers(dataVal);

                    if (dataVal is JObject dataObj)
                        arr[i] = dataObj;
                    else
                        arr[i] = dataVal;
                }
                else
                {
                    UnwrapDataWrappers(arr[i]);
                }
            }
        }
    }

    private static string ReadJsonText(string unitId)
    {
        string path = Application.dataPath + $"/Configs/Prefabs/UNIT_{unitId}.json";
        if (!System.IO.File.Exists(path))
        {
            Debug.LogWarning($"[UnitActionJsonLoader] 找不到 UNIT_{unitId}.json: {path}");
            return null;
        }
        return System.IO.File.ReadAllText(path);
    }
}
