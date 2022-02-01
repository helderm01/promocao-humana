#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/PromocaoHumana.Web", "PromocaoHumana.Web/"]
RUN dotnet restore "PromocaoHumana.Web/PromocaoHumana.Web.csproj"
COPY . .
WORKDIR "/src/PromocaoHumana.Web"
RUN dotnet build "PromocaoHumana.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PromocaoHumana.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m phuser
USER phuser

CMD ASPNETCORE_URLS=http://*:$PORT dotnet PromocaoHumana.Web.dll
