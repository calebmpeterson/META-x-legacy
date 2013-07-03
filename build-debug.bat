@echo OFF

set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319

rem use NuGet to install dependencies
nuget install packages.config -OutputDirectory packages

rmdir /q /s bin\Debug

msbuild UI.csproj