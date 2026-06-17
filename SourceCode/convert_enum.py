"""
将反编译的 const 字段声明格式的 C# 枚举转换为标准 C# 枚举格式。

输入格式:
    public enum eXxx
    {
        // Fields
        public int value__;
        public const eXxx NAME = value;
        ...
    }

输出格式:
    public enum eXxx : int
    {
        NAME = value,
        ...
    }
"""

import re
import sys
from pathlib import Path


def convert_enum(input_path: str, output_path: str = None) -> None:
    with open(input_path, "r", encoding="utf-8") as f:
        lines = f.readlines()

    output_lines = []
    in_enum = False

    for line in lines:
        line_stripped = line.rstrip("\n\r")
        stripped_l = line_stripped.lstrip()
        indent_len = len(line_stripped) - len(stripped_l)
        indent = line[:indent_len]

        # 检测 enum 开始: public enum <Name> ...
        enum_match = re.match(r"public\s+enum\s+(\w+)", stripped_l)
        if enum_match and not in_enum:
            in_enum = True
            enum_name = enum_match.group(1)
            output_lines.append(f"{indent}public enum {enum_name} : int\n")
            output_lines.append(f"{indent}{{\n")
            continue

        if not in_enum:
            if stripped_l.startswith("// Namespace:") or stripped_l.startswith("// TypeDefIndex:"):
                continue
            continue

        # 跳过注释和 value__ 字段
        if stripped_l.startswith("// Fields"):
            continue
        if "value__" in stripped_l:
            continue

        # 检测 const 行: public const <EnumName> NAME = VALUE;
        const_match = re.match(
            r"public\s+const\s+\w+\s+(\w+)\s*=\s*(-?\d+)\s*;", stripped_l
        )
        if const_match:
            name = const_match.group(1)
            value = const_match.group(2)
            output_lines.append(f"{indent}{name} = {value},\n")
            continue

        # 闭合大括号
        if stripped_l == "}":
            output_lines.append("}\n")
            in_enum = False
            continue

    if output_path is None:
        input_path_obj = Path(input_path)
        output_path = str(input_path_obj.parent / f"{input_path_obj.stem}_converted{input_path_obj.suffix}")

    with open(output_path, "w", encoding="utf-8") as f:
        f.writelines(output_lines)

    member_count = sum(1 for l in output_lines if "= " in l and l.strip().endswith(","))
    print(f"转换完成！输出文件: {output_path}")
    print(f"共转换 {member_count} 个枚举成员。")


if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("用法: python convert_enum.py <输入文件路径> [输出文件路径]")
        sys.exit(1)

    input_file = sys.argv[1]
    output_file = sys.argv[2] if len(sys.argv) > 2 else None
    convert_enum(input_file, output_file)
