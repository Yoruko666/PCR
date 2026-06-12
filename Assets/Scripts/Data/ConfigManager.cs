using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }

    public string ConfigPath = "Assets/Configs/CharacterConfig.csv";
    public string SkillConfigPath = "Assets/Configs/SkillConfig.csv";
    public string SkillEffectConfigPath = "Assets/Configs/SkillEffectConfig.csv";
    public string UnitRarityConfigPath = "Assets/Configs/UnitRarityConfig.csv";

    private Dictionary<string, UnitConfig> unitConfigs = new();
    private Dictionary<string, SkillConfig> skillConfigs = new();
    private Dictionary<string, List<SkillEffectConfig>> skillEffectConfigs = new();
    private Dictionary<string, UnitRarityConfig> unitRarityConfigs = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllConfigs();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadAllConfigs()
    {
        LoadCsv(ConfigPath, ref unitConfigs, (cfg) => cfg.Id);
        LoadCsv(SkillConfigPath, ref skillConfigs, (cfg) => cfg.Id);
        LoadSkillEffects();
        LoadCsv(UnitRarityConfigPath, ref unitRarityConfigs, (cfg) => $"{cfg.unit_id}_{cfg.rarity}");
    }

    private void LoadCsv<T>(string relativePath, ref Dictionary<string, T> dict, System.Func<T, string> keySelector) where T : new()
    {
        string fullPath = Path.Combine(Application.dataPath, "..", relativePath);
        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"[ConfigManager] 配表文件不存在: {fullPath}");
            return;
        }

        string csvText = File.ReadAllText(fullPath);
        var configs = CsvReader.ParseToConfigs<T>(csvText);
        foreach (var cfg in configs)
        {
            string key = keySelector(cfg);
            if (!string.IsNullOrEmpty(key))
                dict[key] = cfg;
        }

        Debug.Log($"[ConfigManager] 加载了 {configs.Count} 条 {typeof(T).Name}");
    }

    private void LoadSkillEffects()
    {
        string fullPath = Path.Combine(Application.dataPath, "..", SkillEffectConfigPath);
        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"[ConfigManager] 配表文件不存在: {fullPath}");
            return;
        }

        string csvText = File.ReadAllText(fullPath);
        var effects = CsvReader.ParseToConfigs<SkillEffectConfig>(csvText);
        foreach (var effect in effects)
        {
            if (!skillEffectConfigs.ContainsKey(effect.SkillId))
                skillEffectConfigs[effect.SkillId] = new List<SkillEffectConfig>();
            skillEffectConfigs[effect.SkillId].Add(effect);
        }

        Debug.Log($"[ConfigManager] 加载了 {effects.Count} 条技能效果");
    }

    public UnitConfig GetConfig(string id)
    {
        unitConfigs.TryGetValue(id, out var cfg);
        return cfg;
    }

    public SkillConfig GetSkillConfig(string id)
    {
        skillConfigs.TryGetValue(id, out var cfg);
        return cfg;
    }

    public List<SkillEffectConfig> GetSkillEffects(string skillId)
    {
        skillEffectConfigs.TryGetValue(skillId, out var list);
        return list ?? new List<SkillEffectConfig>();
    }

    public UnitRarityConfig GetUnitRarityConfig(int unitId, int rarity)
    {
        unitRarityConfigs.TryGetValue($"{unitId}_{rarity}", out var cfg);
        return cfg;
    }

    public List<UnitRarityConfig> GetAllRarityConfigs(int unitId)
    {
        var result = new List<UnitRarityConfig>();
        foreach (var kv in unitRarityConfigs)
        {
            if (kv.Key.StartsWith($"{unitId}_"))
                result.Add(kv.Value);
        }
        result.Sort((a, b) => a.rarity.CompareTo(b.rarity));
        return result;
    }
}
