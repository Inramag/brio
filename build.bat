@echo off


dotnet publish -c Release -r win-x64 --self-contained true -p:DebugType=None -p:DebugSymbols=false

xcopy "src\assets" "build\data\assets" /S /Y /I /E

.\build\bin\main.exe