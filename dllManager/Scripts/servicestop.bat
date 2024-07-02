@echo off
setlocal

rem Leer variables de entorno
set "SERVICE_NAME=%~1"
set "REMOTE_SERVER=%~2"

rem Verificar si las variables están configuradas
if "%SERVICE_NAME%"=="" (
    echo Error: La variable de entorno SERVICE_NAME no está configurada.
    endlocal
    exit /b 1
)

if "%REMOTE_SERVER%"=="" (
    echo Error: La variable de entorno REMOTE_SERVER no está configurada.
    endlocal
    exit /b 1
)

rem Verificar el estado del servicio
sc \\%REMOTE_SERVER% query "%SERVICE_NAME%" | find "RUNNING" >nul
if %errorlevel% == 0 (
      
    rem Detener el servicio
    sc \\%REMOTE_SERVER% stop "%SERVICE_NAME%"
    
    rem Verificar si el servicio se detuvo
    sc \\%REMOTE_SERVER% query "%SERVICE_NAME%" | find "STOPPED" >nul
    if %errorlevel% == 0 (
        echo El servicio %SERVICE_NAME% se ha detenido correctamente.
    ) else (
        echo Error: No se pudo detener el servicio %SERVICE_NAME%.
    )
) else (
    echo Error: El servicio %SERVICE_NAME% no está en ejecución.
)

endlocal
