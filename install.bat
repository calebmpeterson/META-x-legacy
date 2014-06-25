@echo OFF

set TARGET=%CD%\bin\Release\META-x.exe
set STARTUP_DIR="%UserProfile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup"
set SHORTCUT=%STARTUP_DIR%\META-x

shortcut /target:%TARGET% /shortcut:%SHORTCUT%
