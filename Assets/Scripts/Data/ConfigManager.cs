using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }

    private const string CsvDir = "Assets/Configs/csv/";
    private const string SkillTimeDir = "Assets/Configs/SkillTimeData/";

    private Dictionary<int, UnitData> unitDatas = new();
    private Dictionary<int, UnitRarity> unitRarities = new();
    private Dictionary<int, UnitSkillData> unitSkillDatas = new();
    private Dictionary<int, SkillData> skillDatas = new();
    private Dictionary<int, SkillAction> skillActions = new();
    private Dictionary<int, UnitAttackPattern> unitAttackPatterns = new();
    private Dictionary<int, List<SkillAction>> skillActionGroups = new();
    private Dictionary<int, UnitSkillTimeData> skillTimeDatas = new();

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
        LoadCsv("unit_data.csv", ref unitDatas, cfg => cfg.unit_id);
        LoadCsv("unit_rarity.csv", ref unitRarities, cfg => cfg.unit_id * 10 + cfg.rarity);
        LoadCsv("unit_skill_data.csv", ref unitSkillDatas, cfg => cfg.unit_id);
        LoadCsv("skill_data.csv", ref skillDatas, cfg => cfg.skill_id);
        LoadCsv("unit_attack_pattern.csv", ref unitAttackPatterns, cfg => cfg.pattern_id);
        LoadSkillActions();
    }

    private void LoadCsv<T>(string fileName, ref Dictionary<int, T> dict, System.Func<T, int> keySelector) where T : new()
    {
        string fullPath = Path.Combine(Application.dataPath, "..", CsvDir, fileName);
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
            dict[key] = cfg;
        }

        Debug.Log($"[ConfigManager] 加载了 {configs.Count} 条 {typeof(T).Name}");
    }

    private void LoadSkillActions()
    {
        string fullPath = Path.Combine(Application.dataPath, "..", CsvDir, "skill_action.csv");
        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"[ConfigManager] 配表文件不存在: {fullPath}");
            return;
        }

        string csvText = File.ReadAllText(fullPath);
        var actions = CsvReader.ParseToConfigs<SkillAction>(csvText);
        foreach (var action in actions)
        {
            skillActions[action.action_id] = action;

            // 找出这个 action 属于哪个 skill，归组
            foreach (var kv in skillDatas)
            {
                var skill = kv.Value;
                if (skill.action_1 == action.action_id || skill.action_2 == action.action_id ||
                    skill.action_3 == action.action_id || skill.action_4 == action.action_id ||
                    skill.action_5 == action.action_id || skill.action_6 == action.action_id ||
                    skill.action_7 == action.action_id || skill.action_8 == action.action_id ||
                    skill.action_9 == action.action_id || skill.action_10 == action.action_id)
                {
                    if (!skillActionGroups.ContainsKey(skill.skill_id))
                        skillActionGroups[skill.skill_id] = new List<SkillAction>();
                    skillActionGroups[skill.skill_id].Add(action);
                    break;
                }
            }
        }

        Debug.Log($"[ConfigManager] 加载了 {actions.Count} 条 SkillAction");
    }

    public UnitData GetUnitData(int unitId)
    {
        unitDatas.TryGetValue(unitId, out var cfg);
        return cfg;
    }

    public UnitRarity GetUnitRarity(int unitId, int rarity)
    {
        unitRarities.TryGetValue(unitId * 10 + rarity, out var cfg);
        return cfg;
    }

    public List<UnitRarity> GetAllRarities(int unitId)
    {
        var result = new List<UnitRarity>();
        for (int r = 1; r <= 6; r++)
        {
            if (unitRarities.TryGetValue(unitId * 10 + r, out var cfg))
                result.Add(cfg);
        }
        return result;
    }

    public UnitSkillData GetUnitSkillData(int unitId)
    {
        unitSkillDatas.TryGetValue(unitId, out var cfg);
        return cfg;
    }

    public SkillData GetSkillData(int skillId)
    {
        skillDatas.TryGetValue(skillId, out var cfg);
        return cfg;
    }

    public SkillAction GetSkillAction(int actionId)
    {
        skillActions.TryGetValue(actionId, out var action);
        return action;
    }

    public List<SkillAction> GetSkillActions(int skillId)
    {
        skillActionGroups.TryGetValue(skillId, out var list);
        return list ?? new List<SkillAction>();
    }

    public UnitAttackPattern GetAttackPattern(int patternId)
    {
        unitAttackPatterns.TryGetValue(patternId, out var cfg);
        return cfg;
    }

    public UnitSkillTimeData GetSkillTimeData(int unitId)
    {
        if (skillTimeDatas.TryGetValue(unitId, out var data))
            return data;

        string fullPath = Path.Combine(Application.dataPath, "..", SkillTimeDir, $"{unitId}.json");
        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"[ConfigManager] 技能时间数据不存在: {fullPath}");
            return null;
        }

        string json = File.ReadAllText(fullPath);
        data = JsonConvert.DeserializeObject<UnitSkillTimeData>(json);
        if (data != null)
            skillTimeDatas[unitId] = data;

        return data;
    }
}
