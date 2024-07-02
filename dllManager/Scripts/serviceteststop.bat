@echo off
setlocal

rem Leer variables de entorno
set "EXE_NAME=%~1"
set "EXE_PATH=%~2"
set "REMOTE_SERVER=%~3"

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

rem Detener el proceso
echo Deteniendo el proceso %EXE_NAME% en el servidor %REMOTE_SERVER%
psexec \\%REMOTE_SERVER% taskkill /IM %EXE_NAME% /F

rem Verificar si el proceso se detuvo
psexec \\%REMOTE_SERVER% tasklist | find "%EXE_NAME%" >nul
if %errorlevel% == 0 (
    echo Error: No se pudo detener el proceso %EXE_NAME%.
    endlocal
    exit /b 1
) else (
    echo El proceso %EXE_NAME% se ha detenido correctamente.
)

rem Iniciar el proceso de nuevo
echo Iniciando el proceso %EXE_NAME% en el servidor %REMOTE_SERVER%
psexec \\%REMOTE_SERVER% %EXE_PATH%

rem Verificar si el proceso se inició correctamente
psexec \\%REMOTE_SERVER% tasklist | find "%EXE_NAME%" >nul
if %errorlevel% == 0 (
    echo El proceso %EXE_NAME% se ha iniciado correctamente.
) else (
    echo Error: No se pudo iniciar el proceso %EXE_NAME%.
)

endlocal
