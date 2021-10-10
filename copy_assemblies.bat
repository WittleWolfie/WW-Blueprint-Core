ECHO "Copying DLLs from %WRATH_DIR%\Wrath_Data\Managed\ to %cd%\Assemblies\"
XCOPY "%WRATH_DIR%\Wrath_Data\Managed\*.dll" "%cd%\Assemblies" /Y /I
XCOPY "%WRATH_DIR%\Wrath_Data\Managed\UnityModManager\UnityModManager.dll" "%cd%\Assemblies" /Y /I