@echo off
cd /d "D:\Sweath\MAUI\DesignApp"

:: Log start time
echo === Run at %date% %time% === >> git_auto_log.txt

:: Add only if there are changes
git diff --quiet && git diff --cached --quiet
IF %ERRORLEVEL% NEQ 0 (
    git add .
    git commit -m "Auto-commit on %date% %time%"
    git push origin Developer-One
    echo Changes pushed. >> git_auto_log.txt
) ELSE (
    echo No changes to commit. >> git_auto_log.txt
)

echo. >> git_auto_log.txt
