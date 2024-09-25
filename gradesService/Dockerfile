# Etapa 1: Construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solo el archivo .csproj y restaurar dependencias
COPY ./GradesService/gradesService/gradesService.csproj ./GradesService/gradesService/
RUN dotnet restore ./GradesService/gradesService/gradesService.csproj

# Copiar todo el código fuente
COPY . .

# Publicar la aplicación
WORKDIR /app/GradesService/gradesService
RUN dotnet publish -c Release -o /out

# Etapa 2: Ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "gradesService.dll"]
