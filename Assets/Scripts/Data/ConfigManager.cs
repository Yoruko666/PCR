using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }

    public string ConfigPath = "Assets/Configs/CharacterConfig.csv";

    private Dictionary<string, UnitConfig> unitConfigs = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadConfigs();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadConfigs()
    {
        string fullPath = Path.Combine(Application.dataPath, "..", ConfigPath);
        if (!File.Exists(fullPath))
        {
            Debug.LogError($"[ConfigManager] 配表文件不存在: {fullPath}");
            return;
        }

        string csvText = File.ReadAllText(fullPath);

        var configs = CsvReader.ParseToConfigs(csvText);
        foreach (var cfg in configs)
            unitConfigs[cfg.Id] = cfg;

        Debug.Log($"[ConfigManager] 加载了 {configs.Count} 个角色配置");
    }

    public UnitConfig GetConfig(string id)
    {
        unitConfigs.TryGetValue(id, out var cfg);
        return cfg;
    }
}
