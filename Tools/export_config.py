"""
Excel → CSV 配表导出工具

使用方法：
  1. python export_config.py --template    # 生成空白 Excel 模板
  2. 在 Excel 中编辑配表后保存为 .xlsx 文件（第一行为英文字段名）
  3. python export_config.py               # 导出为 CSV（表头=Excel第一行，原样保留）

依赖安装：
  pip install openpyxl

修改规范：新增字段只需：
  1. 在 Excel 中添加一列（第一行写英文名）
  2. 在 C# UnitConfig.cs 中添加同名 public 字段
"""

import argparse
import csv
import os
from openpyxl import load_workbook, Workbook


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

    # 第1行作为 CSV 表头，原样保留
    headers = [str(cell).strip() if cell else "" for cell in rows[0]]
    headers = [h for h in headers if h]  # 跳过空表头列

    if not headers:
        print("错误：Excel 第一行为空")
        return False

    print(f"\n表头: {headers}")

    # 构建 CSV 内容
    csv_rows = [headers]

    for row_idx, row in enumerate(rows[1:], start=2):
        values = []
        # 只取有表头的列（跳过 Excel 多余的空列）
        for col_idx in range(len(headers)):
            cell_val = row[col_idx] if col_idx < len(row) else None
            if cell_val is None:
                values.append("")
            elif isinstance(cell_val, float):
                values.append(str(int(cell_val)) if cell_val == int(cell_val) else str(cell_val))
            else:
                values.append(str(cell_val).strip())

        # 第一列（Id）必须为非空数字
        id_val = values[0]
        if not id_val or not id_val.isdigit():
            print(f"  跳过第 {row_idx} 行：Id 非数字")
            continue

        csv_rows.append(values)

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

    # 列信息：(英文列名, 示例值, 中文注释)
    columns = [
        ("Id",            1001,    "角色ID"),
        ("Name",          "日和莉",  "名称"),
        ("MaxHP",         5800,    "最大HP"),
        ("AttackPower",   1580,    "攻击力"),
        ("AttackRange",   200,     "攻击范围"),
        ("AnimRun",       "01_run","跑步动画"),
        ("AnimAttack",    "01_attack","攻击动画"),
        ("AnimIdle",      "01_stand","待机动画"),
        ("SpineDataAddr", "1001",  "Spine地址"),
    ]

    wb = Workbook()
    ws = wb.active
    ws.title = "角色配置"

    # 第1行：表头（英文列名，也是 CSV 键名）
    ws.append([col[0] for col in columns])

    # 第2行：中文注释
    ws.append([col[2] for col in columns])

    # 第3行：示例数据
    ws.append([col[1] for col in columns])

    # 设置列宽
    for i in range(len(columns)):
        ws.column_dimensions[chr(65 + i)].width = 14

    # 冻结前两行（表头+注释）
    ws.freeze_panes = "A3"

    # 保存
    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)
    wb.save(output_path)

    print(f"\n== 模板已生成: {output_path}")
    print(f"   第1行=英文字段名（CSV键名），第2行=中文注释，第3行=示例数据")
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
