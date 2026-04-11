@echo off

setlocal GOOS=windows
setlocal GOARCH=amd64
go build -o ./build/bin/brio.exe ./src/boot.go
if errorlevel 1 exit /b %errorlevel%

dotnet publish -c Release -r win-x64 --self-contained true -p:DebugType=None -p:DebugSymbols=false
build/bin/brio.exe