@echo off
cd /d "D:\Sweath\MAUI\DesignApp"

:: Add only if there are changes
git diff --quiet && git diff --cached --quiet
IF %ERRORLEVEL% NEQ 0 (
    git add .
    git commit -m "Auto-commit on %date% %time%"
    git push origin Developer-One
) ELSE (
    echo No changes to commit.
)
