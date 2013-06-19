@echo OFF

set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319

rmdir /q /s bin\Release

msbuild UI.csproj /p:Configuration=Release