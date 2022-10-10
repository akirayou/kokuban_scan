echo off
cd /d %~dp0
call %HOMEPATH%\anaconda3\scripts\activate.bat

REM conda activate base

:LOOP
echo 新しいファイルがないかチェック....このウィンドウを閉じて停止
python scripts/make_png.py
powershell sleep 1

goto :LOOP

