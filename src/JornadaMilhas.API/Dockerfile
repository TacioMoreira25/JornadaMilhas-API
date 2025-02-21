# Etapa base - Ambiente de execução
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar e restaurar pacotes do projeto
COPY ["src/JornadaMilhas.API/JornadaMilhas.API.csproj", "src/JornadaMilhas.API/"]
COPY ["src/JornadaMilhas.Dados/JornadaMilhas.Dados.csproj", "src/JornadaMilhas.Dados/"]
COPY ["src/JornadaMilhas.Dominio/JornadaMilhas.Dominio.csproj", "src/JornadaMilhas.Dominio/"]

RUN dotnet restore "src/JornadaMilhas.API/JornadaMilhas.API.csproj"

COPY . .
WORKDIR "/src/JornadaMilhas.API"
RUN dotnet build "JornadaMilhas.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "JornadaMilhas.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final - Executar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JornadaMilhas.API.dll"]
