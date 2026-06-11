@echo off
chcp 65001 >nul
echo 正在导出配表...

D:\PYTHON\anaconda\python.exe export_config.py

if %errorlevel% equ 0 (
    echo 导出成功！
) else (
    echo 导出失败，请检查是否已安装 openpyxl：pip install openpyxl
)

pause
