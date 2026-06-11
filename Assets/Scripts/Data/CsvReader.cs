using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

public static class CsvReader
{
    public static List<string[]> Parse(string csvText)
    {
        var rows = new List<string[]>();
        var lines = csvText.Split('\n');
        foreach (var rawLine in lines)
        {
            string line = rawLine.Trim();
            if (string.IsNullOrEmpty(line)) continue;
            rows.Add(ParseLine(line));
        }
        return rows;
    }

    private static string[] ParseLine(string line)
    {
        var fields = new List<string>();
        var current = new System.Text.StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(c);
            }
        }
        fields.Add(current.ToString()); // 最后一个字段
        return fields.ToArray();
    }

    /// <summary>
    /// 将 CSV 文本解析为 UnitConfig 列表。
    /// CSV 表头（第一行）的列名直接匹配 UnitConfig 的 public 字段名，自动填充。
    /// 新增字段只需：1) Excel 加一列  2) UnitConfig 加同名 public 字段
    /// </summary>
    public static List<UnitConfig> ParseToConfigs(string csvText)
    {
        var rows = Parse(csvText);
        if (rows.Count < 2) return new List<UnitConfig>();

        string[] headers = rows[0];
        var configs = new List<UnitConfig>();

        // 缓存 UnitConfig 字段信息，避免每行重复反射
        var fieldMap = new Dictionary<string, FieldInfo>();
        foreach (var fi in typeof(UnitConfig).GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            fieldMap[fi.Name] = fi;
        }

        for (int r = 1; r < rows.Count; r++)
        {
            string[] fields = rows[r];
            var config = new UnitConfig();

            for (int c = 0; c < headers.Length && c < fields.Length; c++)
            {
                string key = headers[c];
                if (!fieldMap.TryGetValue(key, out var field)) continue;

                string rawVal = fields[c];
                if (string.IsNullOrEmpty(rawVal)) continue;

                SetFieldValue(config, field, rawVal, key);
            }

            configs.Add(config);
        }

        return configs;
    }

    private static void SetFieldValue(UnitConfig config, FieldInfo field, string rawVal, string fieldName)
    {
        object val;
        if (field.FieldType == typeof(int))
        {
            int.TryParse(rawVal, out int intVal);
            val = intVal;
        }
        else if (field.FieldType == typeof(float))
        {
            float.TryParse(rawVal, NumberStyles.Float, CultureInfo.InvariantCulture, out float floatVal);
            val = floatVal;
        }
        else
        {
            val = rawVal;
        }

        field.SetValue(config, val);
    }
}
