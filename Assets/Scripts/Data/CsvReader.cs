using System.Collections.Generic;
using System.Reflection;
using System.Globalization;

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
        fields.Add(current.ToString());
        return fields.ToArray();
    }

    /// <summary>
    /// 将 CSV 文本解析为指定类型的配置列表。
    /// CSV 表头（第一行）的列名直接匹配 T 的 public 字段名，自动填充。
    /// </summary>
    public static List<T> ParseToConfigs<T>(string csvText) where T : new()
    {
        var rows = Parse(csvText);
        if (rows.Count < 2) return new List<T>();

        string[] headers = rows[0];
        var configs = new List<T>();

        var fieldMap = new Dictionary<string, FieldInfo>();
        foreach (var fi in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            fieldMap[fi.Name] = fi;
        }

        for (int r = 1; r < rows.Count; r++)
        {
            string[] fields = rows[r];
            var config = new T();

            for (int c = 0; c < headers.Length && c < fields.Length; c++)
            {
                string key = headers[c];
                if (!fieldMap.TryGetValue(key, out var field)) continue;

                string rawVal = fields[c];
                if (string.IsNullOrEmpty(rawVal)) continue;

                SetFieldValue(config, field, rawVal);
            }

            configs.Add(config);
        }

        return configs;
    }

    private static void SetFieldValue(object config, FieldInfo field, string rawVal)
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
