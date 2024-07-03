@echo off
setlocal

rem Leer variables de entorno
set "EXE_NAME=%~1"
set "EXE_PATH=%~2"
set "REMOTE_SERVER=%~3"
set "AUTOIT_SCRIPT_PATH=%~4"

rem Verificar si las variables están configuradas
if "%EXE_NAME%"=="" (
    echo Error: La variable de entorno EXE_NAME no está configurada.
    endlocal
    exit /b 1
)

if "%EXE_PATH%"=="" (
    echo Error: La variable de entorno EXE_PATH no está configurada.
    endlocal
    exit /b 1
)

if "%REMOTE_SERVER%"=="" (
    echo Error: La variable de entorno REMOTE_SERVER no está configurada.
    endlocal
    exit /b 1
)

if "%AUTOIT_SCRIPT_PATH%"=="" (
    echo Error: La variable de entorno AUTOIT_SCRIPT_PATH no está configurada.
    endlocal
    exit /b 1
)

rem Detener el proceso
echo Deteniendo el proceso %EXE_NAME% en el servidor %REMOTE_SERVER%
psexec \\%REMOTE_SERVER% taskkill /IM "%EXE_NAME%" /F

rem Verificar si el proceso se detuvo
rem psexec \\%REMOTE_SERVER% tasklist | find "%EXE_NAME%" >nul
if %errorlevel% == 0 (
    echo Error: No se pudo detener el proceso %EXE_NAME%.
    endlocal
    exit /b 1
) else (
    echo El proceso %EXE_NAME% se ha detenido correctamente.
)

rem Ejecutar el script de AutoIt para reiniciar la aplicación y hacer clic en OK
echo Ejecutando el script de AutoIt en el servidor %REMOTE_SERVER%
psexec \\%REMOTE_SERVER% "\\webtest\c$\Program Files (x86)\AutoIt3\AutoIt3.exe" "%AUTOIT_SCRIPT_PATH%"

endlocal
