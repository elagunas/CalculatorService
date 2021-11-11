#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Client/CalculatorService.Client/CalculatorService.Client.csproj", "src/Client/CalculatorService.Client/"]
COPY ["src/Api/CalculatorService.Api.Contracts/CalculatorService.Api.Contracts.csproj", "src/Api/CalculatorService.Api.Contracts/"]
RUN dotnet restore "src/Client/CalculatorService.Client/CalculatorService.Client.csproj"
COPY . .
WORKDIR "/src/src/Client/CalculatorService.Client"
RUN dotnet build "CalculatorService.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculatorService.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorService.Client.dll"]