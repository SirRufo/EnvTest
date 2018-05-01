FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY EnvTest/EnvTest.csproj EnvTest/
RUN dotnet restore EnvTest/EnvTest.csproj
COPY . .
WORKDIR /src/EnvTest
RUN dotnet build EnvTest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EnvTest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EnvTest.dll"]
