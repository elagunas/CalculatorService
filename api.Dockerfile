#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Api/CalculatorService.Api/CalculatorService.Api.csproj", "src/Api/CalculatorService.Api/"]
COPY ["src/Infrastructure/CalculatorService.Persistence/CalculatorService.Persistence.csproj", "src/Infrastructure/CalculatorService.Persistence/"]
COPY ["src/Core/CalculatorService.Application/CalculatorService.Application.csproj", "src/Core/CalculatorService.Application/"]
COPY ["src/Api/CalculatorService.Api.Contracts/CalculatorService.Api.Contracts.csproj", "src/Api/CalculatorService.Api.Contracts/"]
COPY ["src/Core/CalculatorService.Domain/CalculatorService.Domain.csproj", "src/Core/CalculatorService.Domain/"]
RUN dotnet restore "src/Api/CalculatorService.Api/CalculatorService.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/CalculatorService.Api"
RUN dotnet build "CalculatorService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculatorService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorService.Api.dll"]