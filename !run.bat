echo off
cd /d %~dp0
call %HOMEPATH%\anaconda3\scripts\activate.bat

REM conda activate base

:LOOP
echo �V�����t�@�C�����Ȃ����`�F�b�N....���̃E�B���h�E����Ē�~
python scripts/make_png.py
powershell sleep 1

goto :LOOP

