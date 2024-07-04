# Proyecto dllManager

Este proyecto es una aplicación de Windows Forms en C# que facilita la gestión de archivos DLL en diferentes entornos (producción y pruebas). Utiliza variables de entorno para configurar las rutas y nombres de los servidores y servicios involucrados.

## Funcionalidades

- **Carga de Variables de Entorno**: En el evento `Load` del formulario principal, se cargan las variables de entorno necesarias para la configuración de la aplicación.
- **Copia de DLLs**: Copia archivos DLL seleccionados desde un directorio local a un servidor. Si la DLL ya existe en el servidor, se renombra la existente antes de copiar la nueva versión.
- **Reinicio de Servicios**: Permite reiniciar servicios web en los entornos seleccionados si se copian ciertos archivos DLL específicos.

## Variables de Entorno

A continuación se detallan las variables de entorno utilizadas por la aplicación:

- `SERVICE_NAME`: Nombre del servicio de producción.
- `SRV_WEB_01`: Dirección del primer servidor web de producción.
- `SRV_WEB_02`: Dirección del segundo servidor web de producción.
- `SERVER_PROD_NAME`: Nombre del servidor de producción.
- `SERVER_TEST_NAME`: Nombre del servidor de pruebas.
- `SERVER_PROD_PATH`: Ruta en el servidor de producción.
- `SERVER_TEST_PATH`: Ruta en el servidor de pruebas.
- `PROD_LOCAL_PATH`: Ruta local de producción.
- `TEST_LOCAL_PATH`: Ruta local de pruebas.
- `TEST_SERVICE_NAME`: Nombre del servicio de pruebas.
- `TEST_SERVICE_PATH`: Ruta del servicio de pruebas.
- `WEBTEST`: Dirección del servidor web de pruebas.
- `AUTOLT_SCRIPT_PATH`: Ruta del script de AutoIt.

## Uso

1. **Configuración de Variables de Entorno**: Asegúrate de que todas las variables de entorno necesarias estén configuradas correctamente.
2. **Ejecución de la Aplicación**: Inicia la aplicación. Se cargará el formulario principal con las opciones para seleccionar el entorno y los archivos DLL a gestionar.
3. **Selección de Entorno**: Selecciona si deseas trabajar en el entorno de producción o de pruebas.
4. **Selección de DLLs**: Marca las casillas de verificación de las DLLs que deseas copiar.
5. **Copia de DLLs**: Presiona el botón correspondiente para copiar las DLLs seleccionadas al servidor. Si es necesario, confirmará acciones adicionales como el reinicio de servicios.

## Requisitos

- **.NET Framework**: Este proyecto requiere .NET Framework para ejecutarse.
- **Bibliotecas de Terceros**: Se utiliza la biblioteca `DotNetEnv` para cargar variables de entorno.

## Autor

Proyecto desarrollado por Sergio Meza Guardiola.

## Licencia

Este proyecto está licenciado bajo los términos de la Licencia MIT.
