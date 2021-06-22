FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservico_Crud.csproj", ""]
RUN dotnet restore "./Microservico_Crud.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Microservico_Crud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservico_Crud.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservico_Crud.dll"]