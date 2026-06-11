"""
Excel → CSV 配表导出工具

使用方法：
  1. python export_config.py --template    # 生成空白 Excel 模板
  2. 在 Excel 中编辑配表后保存为 .xlsx 文件
  3. python export_config.py               # 导出为 CSV

依赖安装：
  pip install openpyxl

命令行：
  python export_config.py                          # 使用默认配置
  python export_config.py --input 配表.xlsx --output 目标.csv
  python export_config.py --template               # 生成空白模板
"""

import argparse
import csv
import os
from openpyxl import load_workbook, Workbook

# 列映射：Excel 列名 → CSV 列名
COLUMN_MAP = {
    "Id":             "Id",
    "角色ID":          "Id",
    "Name":           "Name",
    "名称":            "Name",
    "角色名":           "Name",
    "MaxHP":          "MaxHP",
    "HP":             "MaxHP",
    "最大HP":          "MaxHP",
    "AttackPower":    "AttackPower",
    "Attack":         "AttackPower",
    "AttackRange":    "AttackRange",
    "攻击范围":          "AttackRange",
    "AnimRun":        "AnimRun",
    "走路动画":          "AnimRun",
    "跑步动画":          "AnimRun",
    "AnimAttack":     "AnimAttack",
    "攻击动画":          "AnimAttack",
    "AnimIdle":       "AnimIdle",
    "待机动画":          "AnimIdle",
    "空闲动画":          "AnimIdle",
    "SpineDataAddr":  "SpineDataAddr",
    "Spine地址":        "SpineDataAddr",
    "骨骼地址":          "SpineDataAddr",
}

# 输出 CSV 的列顺序
CSV_COLUMNS = [
    "Id", "Name", "MaxHP", "AttackPower", "AttackRange",
    "AnimRun", "AnimAttack", "AnimIdle", "SpineDataAddr",
]


def excel_to_csv(input_path, output_path, sheet_name=None):
    """将 Excel 文件导出为 CSV 配表"""

    wb = load_workbook(input_path, data_only=True)

    # 选择工作表
    if sheet_name:
        ws = wb[sheet_name]
    else:
        # 默认取第一个有数据的工作表
        ws = wb.active

    rows = list(ws.iter_rows(values_only=True))
    if not rows:
        print(f"错误：工作表 '{ws.title}' 为空")
        return False

    # 解析表头
    raw_headers = [str(cell).strip() if cell else "" for cell in rows[0]]
    headers = []
    col_indices = []

    print(f"\n表头识别结果：")
    for i, raw in enumerate(raw_headers):
        mapped = COLUMN_MAP.get(raw, raw)
        if mapped in CSV_COLUMNS:
            col_indices.append((i, mapped))
            print(f"  [{i}] {raw:12s} → {mapped}")
        else:
            print(f"  [{i}] {raw:12s} -> 未识别，跳过")

    if not col_indices:
        print("错误：未找到任何可识别的列")
        return False

    # 构建 CSV 内容
    csv_rows = []
    csv_rows.append(CSV_COLUMNS)  # 表头

    for row_idx, row in enumerate(rows[1:], start=2):
        values = {}
        for col_idx, col_name in col_indices:
            cell_val = row[col_idx]
            if cell_val is None:
                values[col_name] = ""
            elif isinstance(cell_val, float):
                # 整数就去掉小数点
                if cell_val == int(cell_val):
                    values[col_name] = str(int(cell_val))
                else:
                    values[col_name] = str(cell_val)
            else:
                values[col_name] = str(cell_val).strip()

        # 必须有数字 Id
        id_str = values.get("Id", "")
        if not id_str or not id_str.isdigit():
            print(f"  跳过第 {row_idx} 行：Id 非数字")
            continue

        csv_row = [values.get(col, "") for col in CSV_COLUMNS]
        csv_rows.append(csv_row)

    # 写入 CSV
    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)
    with open(output_path, "w", newline="", encoding="utf-8") as f:
        writer = csv.writer(f)
        writer.writerows(csv_rows)

    print(f"\n== 导出完成: {len(csv_rows) - 1} 个角色 -> {output_path}")
    return True


def list_sheets(input_path):
    """列出 Excel 文件中的所有工作表"""
    wb = load_workbook(input_path, read_only=True)
    print(f"\n工作表列表：")
    for name in wb.sheetnames:
        print(f"  - {name}")


def create_template(output_path):
    """生成空白 Excel 模板文件"""

    # 列信息：中文名（注释用） / CSV列名 / 示例值 / 类型提示
    columns = [
        ("角色ID",   "Id",            1001,    "文本"),
        ("名称",       "Name",          "日和莉",  "文本"),
        ("最大HP",     "MaxHP",         5800,    "整数"),
        ("攻击力",     "AttackPower",   1580,    "整数"),
        ("攻击范围",   "AttackRange",   200,     "浮点数"),
        ("走路动画",   "AnimRun",       "01_run","文本"),
        ("攻击动画",   "AnimAttack",    "01_attack","文本"),
        ("待机动画",   "AnimIdle",      "01_stand","文本"),
        ("Spine地址",  "SpineDataAddr", "1001",  "文本"),
    ]

    wb = Workbook()
    ws = wb.active
    ws.title = "角色配置"

    # 第1行：表头（英文列名，程序识别用）
    header_row = [col[1] for col in columns]
    ws.append(header_row)

    # 第2行：中文注释
    cn_row = [col[0] for col in columns]
    ws.append(cn_row)

    # 第3行：示例数据
    sample_row = [col[2] for col in columns]
    ws.append(sample_row)

    # 设置列宽
    col_widths = [14, 10, 10, 10, 12, 12, 12, 12, 16]
    for i, width in enumerate(col_widths, start=1):
        ws.column_dimensions[chr(64 + i)].width = width

    # 冻结首行
    ws.freeze_panes = "A2"

    # 保存
    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)
    wb.save(output_path)

    print(f"\n== 模板已生成: {output_path}")
    print(f"   Excel 列名说明（第1行英文=程序识别，第2行中文=提示，第3行=示例）")
    print(f"   编辑完成后运行 python export_config.py 导出为 CSV")
    return True


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Excel → CSV 配表导出工具")
    parser.add_argument("--input", default=None,
                        help="输入的 Excel 文件路径（默认：../Assets/Configs/CharacterConfig.xlsx）")
    parser.add_argument("--output", default=None,
                        help="输出的 CSV 文件路径（默认：../Assets/Configs/CharacterConfig.csv）")
    parser.add_argument("--sheet", default=None,
                        help="指定工作表名称（可选，默认使用第一个工作表）")
    parser.add_argument("--template", action="store_true",
                        help="生成空白 Excel 模板文件并退出")
    parser.add_argument("--list-sheets", action="store_true",
                        help="列出 Excel 文件中的所有工作表并退出")

    args = parser.parse_args()

    # 默认路径基于脚本所在目录
    script_dir = os.path.dirname(os.path.abspath(__file__))
    input_path = args.input or os.path.join(script_dir, "..", "Assets", "Configs", "CharacterConfig.xlsx")
    output_path = args.output or os.path.join(script_dir, "..", "Assets", "Configs", "CharacterConfig.csv")

    input_path = os.path.abspath(input_path)
    output_path = os.path.abspath(output_path)

    if args.list_sheets:
        if not os.path.exists(input_path):
            print(f"文件不存在：{input_path}")
        else:
            list_sheets(input_path)
    elif args.template:
        create_template(input_path)
    else:
        if not os.path.exists(input_path):
            print(f"❌ 文件不存在：{input_path}")
            print("请先在 Excel 中创建配表并保存为 .xlsx 格式")
            print(f"  预期路径：{input_path}")
            print("\n或者使用 --input 指定其他路径")
        else:
            excel_to_csv(input_path, output_path, args.sheet)
