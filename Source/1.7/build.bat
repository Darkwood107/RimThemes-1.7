@echo off
rem Build RimThemes for RimWorld 1.7 (.NET 10 SDK required)
rem Usage: build.bat "D:\SteamLibrary\steamapps\common\RimWorld"
set RW=%~1
if "%RW%"=="" (
  dotnet build "%~dp0RimThemes.csproj" -c Release
) else (
  dotnet build "%~dp0RimThemes.csproj" -c Release -p:RimWorldDir="%RW%"
)
