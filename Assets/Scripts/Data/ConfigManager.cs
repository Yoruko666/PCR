using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }

    private Dictionary<(int unitId, int rarity), UnitRarityConfig> unitRarityConfigs = new();
    private Dictionary<int, SkillActionConfig> skillActionConfigs = new();
    private Dictionary<int, SkillDataConfig> skillDataConfigs = new();
    private Dictionary<int, UnitAttackPatternConfig> unitAttackPatternConfigs = new();
    private Dictionary<int, UnitDataConfig> unitDataConfigs = new();
    private Dictionary<int, UnitSkillDataConfig> unitSkillDataConfigs = new();

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
        LoadCsvToList("Assets/Configs/Csv/unit_rarity.csv", unitRarityConfigs, cfg => (cfg.unit_id, cfg.rarity));
        LoadCsv("Assets/Configs/Csv/skill_action.csv", ref skillActionConfigs, (cfg) => cfg.action_id);
        LoadCsv("Assets/Configs/Csv/skill_data.csv", ref skillDataConfigs, (cfg) => cfg.skill_id);
        LoadCsv("Assets/Configs/Csv/unit_attack_pattern.csv", ref unitAttackPatternConfigs, (cfg) => cfg.pattern_id);
        LoadCsv("Assets/Configs/Csv/unit_data.csv", ref unitDataConfigs, (cfg) => cfg.unit_id);
        LoadCsv("Assets/Configs/Csv/unit_skill_data.csv", ref unitSkillDataConfigs, (cfg) => cfg.unit_id);
    }

    private void LoadCsv<T>(string relativePath, ref Dictionary<int, T> dict, System.Func<T, int> keySelector) where T : new()
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
            int key = keySelector(cfg);
            if (key != 0)
                dict[key] = cfg;
        }

        Debug.Log($"[ConfigManager] 加载了 {configs.Count} 条 {typeof(T).Name}");
    }

    private void LoadCsvToList<T>(string relativePath, Dictionary<(int, int), T> dict, System.Func<T, (int, int)> keySelector) where T : new()
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
            var key = keySelector(cfg);
            if (key.Item1 != 0)
                dict[key] = cfg;
        }

        Debug.Log($"[ConfigManager] 加载了 {configs.Count} 条 {typeof(T).Name}");
    }

    // ============ UnitRarity ============

    public UnitRarityConfig GetUnitRarityConfig(int unitId, int rarity)
    {
        unitRarityConfigs.TryGetValue((unitId, rarity), out var cfg);
        return cfg;
    }

    public List<UnitRarityConfig> GetAllRarityConfigs(int unitId)
    {
        var result = new List<UnitRarityConfig>();
        foreach (var kv in unitRarityConfigs)
        {
            if (kv.Key.unitId == unitId)
                result.Add(kv.Value);
        }
        result.Sort((a, b) => a.rarity.CompareTo(b.rarity));
        return result;
    }

    // ============ UnitData (unit_data.csv) ============

    public UnitDataConfig GetUnitDataConfig(int unitId)
    {
        unitDataConfigs.TryGetValue(unitId, out var cfg);
        return cfg;
    }

    // ============ UnitSkillData (unit_skill_data.csv) ============

    public UnitSkillDataConfig GetUnitSkillData(int unitId)
    {
        unitSkillDataConfigs.TryGetValue(unitId, out var cfg);
        return cfg;
    }

    // ============ SkillAction (skill_action.csv) ============

    public SkillActionConfig GetSkillActionConfig(int actionId)
    {
        skillActionConfigs.TryGetValue(actionId, out var cfg);
        return cfg;
    }

    public List<SkillActionConfig> GetSkillActions(int skillId)
    {
        var result = new List<SkillActionConfig>();
        var skillData = GetSkillDataConfig(skillId);
        if (skillData == null) return result;

        foreach (int actionId in skillData.GetActionIds())
        {
            var action = GetSkillActionConfig(actionId);
            if (action != null)
                result.Add(action);
        }
        return result;
    }

    // ============ SkillData (skill_data.csv) ============

    public SkillDataConfig GetSkillDataConfig(int skillId)
    {
        skillDataConfigs.TryGetValue(skillId, out var cfg);
        return cfg;
    }

    public Dictionary<int, SkillDataConfig> GetAllSkillData() => skillDataConfigs;
    public Dictionary<int, SkillActionConfig> GetAllSkillActions() => skillActionConfigs;

    // ============ UnitAttackPattern (unit_attack_pattern.csv) ============

    public UnitAttackPatternConfig GetUnitAttackPattern(int patternId)
    {
        unitAttackPatternConfigs.TryGetValue(patternId, out var cfg);
        return cfg;
    }

    public UnitAttackPatternConfig GetAttackPatternByUnitId(int unitId)
    {
        foreach (var kv in unitAttackPatternConfigs)
        {
            if (kv.Value.unit_id == unitId)
                return kv.Value;
        }
        return null;
    }

    public (List<int> startSequence, List<int> loopSequence) GetAttackSequence(int unitId)
    {
        var pattern = GetAttackPatternByUnitId(unitId);
        if (pattern == null)
            return (new List<int>(), new List<int>());

        return (pattern.GetStartSequence(), pattern.GetLoopSequence());
    }
}
