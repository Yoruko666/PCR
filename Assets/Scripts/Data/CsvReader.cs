using System.Collections.Generic;

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

    public static List<UnitConfig> ParseToConfigs(string csvText)
    {
        var rows = Parse(csvText);
        if (rows.Count < 2) return new List<UnitConfig>(); // 至少要有表头+1行数据

        string[] headers = rows[0];
        var configs = new List<UnitConfig>();

        for (int r = 1; r < rows.Count; r++)
        {
            string[] fields = rows[r];
            var config = new UnitConfig();

            for (int c = 0; c < headers.Length && c < fields.Length; c++)
            {
                string key = headers[c];
                string val = fields[c];

                switch (key)
                {
                    case "Id":              config.Id = val; break;
                    case "Name":            config.Name = val; break;
                    case "MaxHP":           config.MaxHP = ParseInt(val); break;
                    case "AttackPower":     config.AttackPower = ParseInt(val); break;
                    case "AttackRange":     config.AttackRange = ParseFloat(val); break;
                    case "AnimRun":         config.AnimRun = val; break;
                    case "AnimAttack":      config.AnimAttack = val; break;
                    case "AnimIdle":        config.AnimIdle = val; break;
                    case "SpineDataAddr":   config.SpineDataAddr = val; break;
                }
            }
            configs.Add(config);
        }
        return configs;
    }

    private static int ParseInt(string s)
    {
        int.TryParse(s, out int v);
        return v;
    }

    private static float ParseFloat(string s)
    {
        float.TryParse(s, System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out float v);
        return v;
    }
}
