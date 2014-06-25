@echo OFF

set STARTUP_DIR="%UserProfile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup"
set SHORTCUT=%STARTUP_DIR%\META-x.lnk

del %SHORTCUT%
