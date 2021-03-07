#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TAN.Core.3.1.Rest.Api.Swagger/TAN.Core.3.1.Rest.Api.Swagger.csproj", "TAN.Core.3.1.Rest.Api.Swagger/"]
RUN dotnet restore "TAN.Core.3.1.Rest.Api.Swagger/TAN.Core.3.1.Rest.Api.Swagger.csproj"
COPY . .
WORKDIR "/src/TAN.Core.3.1.Rest.Api.Swagger"
RUN dotnet build "TAN.Core.3.1.Rest.Api.Swagger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TAN.Core.3.1.Rest.Api.Swagger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TAN.Core.3.1.Rest.Api.Swagger.dll"]