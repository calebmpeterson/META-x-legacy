@echo OFF

set STARTUP_DIR="%UserProfile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup"
set SHORTCUT=%STARTUP_DIR%\Xel.lnk

del %SHORTCUT%