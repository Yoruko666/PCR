"""
SQL INSERT → CSV 通用转换工具

将 SQL INSERT 语句数据导出为 Unity 可读的 CSV 配表。
自动从 CREATE TABLE 语句解析列名，或从 INSERT 数据推断。

用法:
  python sql_to_csv.py input.sql output.csv             # 指定输入输出
  python sql_to_csv.py unit_rarity.sql                   # 输出同名 CSV
  python sql_to_csv.py ../Assets/Configs/*.sql           # 批量转换
"""
import csv
import re
import os
import sys
import glob


def extract_columns_from_create(sql_text):
    """从 CREATE TABLE 语句中提取列名列表"""
    match = re.search(r"CREATE\s+TABLE.*?\((.*?)\)\s*;", sql_text, re.DOTALL)
    if not match:
        return None

    columns = []
    for col_def in match.group(1).split(","):
        col_def = col_def.strip()
        if not col_def:
            continue
        # 跳过 PRIMARY KEY, UNIQUE, FOREIGN KEY, CONSTRAINT, INDEX 等
        if re.match(r"PRIMARY\s+|UNIQUE\s+|FOREIGN\s+|KEY\s+|CONSTRAINT\s+|INDEX\s+", col_def, re.I):
            continue
        # 提取列名 (支持 `name`, 'name', name)
        m = re.match(r"""['`"]?([a-zA-Z_]\w*)['`"]?\s""", col_def)
        if m:
            columns.append(m.group(1))
    return columns if columns else None


def extract_columns_from_insert(sql_text):
    """从第一条 INSERT 的数据量推断列数"""
    m = re.search(r"insert\s+into\s+\w+\s+values\s*\((.*?)\);", sql_text, re.DOTALL)
    if not m:
        return None
    vals = [v.strip().strip("'\"") for v in m.group(1).split(",")]
    # 用数字编号作为临时列名
    return [f"col{i}" for i in range(len(vals))]


def parse_inserts(sql_text):
    """解析所有 INSERT 语句，返回行数据列表"""
    rows = []
    for line in sql_text.split("\n"):
        line = line.strip()
        if line.startswith(("insert into", "INSERT INTO")):
            m = re.search(r"values\s*\((.*?)\)\s*;", line, re.DOTALL | re.I)
            if m:
                vals = [v.strip().strip("'\"") for v in m.group(1).split(",")]
                rows.append(vals)
    return rows


def convert(input_path, output_path):
    """将 SQL 文件转换为 CSV"""
    with open(input_path, "r", encoding="utf-8") as f:
        sql_text = f.read()

    # 提取列名
    columns = extract_columns_from_create(sql_text)
    if columns is None:
        columns = extract_columns_from_insert(sql_text)
        print(f"  未找到 CREATE TABLE，从数据推断列数: {len(columns)}")

    # 解析数据行
    rows = parse_inserts(sql_text)
    if not rows:
        print(f"  ❌ 未找到任何 INSERT 数据")
        return False

    # 写入 CSV
    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)
    with open(output_path, "w", newline="", encoding="utf-8") as f:
        writer = csv.writer(f)
        writer.writerow(columns)
        for row in rows:
            writer.writerow(row)

    print(f"  ✅ {len(rows)} 条数据 -> {output_path}")
    return True


if __name__ == "__main__":
    if len(sys.argv) < 2:
        script_name = os.path.basename(__file__)
        print(f"用法: python {script_name} input.sql [output.csv]")
        print(f"      python {script_name} ../Assets/Configs/*.sql   (批量)")
        sys.exit(1)

    input_pattern = sys.argv[1]
    input_files = glob.glob(input_pattern) if ("*" in input_pattern or "?" in input_pattern) else [input_pattern]

    if not input_files:
        print(f"❌ 找不到文件: {input_pattern}")
        sys.exit(1)

    for input_path in input_files:
        print(f"\n处理: {input_path}")
        if len(sys.argv) >= 3 and len(input_files) == 1:
            output_path = sys.argv[2]
        else:
            # 同名输出，改后缀为 .csv
            output_path = os.path.splitext(input_path)[0] + ".csv"
        convert(input_path, output_path)
