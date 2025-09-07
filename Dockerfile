# CONSTRUCCION POR CAPAS
# Imagen para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Creamos un directorio
WORKDIR /app

# Copiar archivos locales
COPY . ./

# Compilamos
RUN dotnet publish -o out

# Imagen del runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .

# Creamos un volumen para los datos
VOLUME ["/app/data"]

# Exponemos el puerto 8023 (cambiar por tu puerto específico)
EXPOSE 8023

# Creamos la variable de entorno para la configuración
ENV APP_ENVIRONMENT=Production
ENV LANG=es_ES.UTF-8

# Comando de ejecución
ENTRYPOINT ["dotnet", "ParkingApp1.dll"]
