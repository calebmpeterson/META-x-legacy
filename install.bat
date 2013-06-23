@echo OFF

set TARGET=%CD%\bin\Release\Xel.exe
set STARTUP_DIR="%UserProfile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup"
set SHORTCUT=%STARTUP_DIR%\Xel

shortcut /target:%TARGET% /shortcut:%SHORTCUT%