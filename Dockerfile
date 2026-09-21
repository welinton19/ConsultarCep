FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["ConsultarCep/ConsultarCep.csproj", "ConsultarCep/"]
COPY ["ConsultarCep.Application/ConsultarCep.Application.csproj", "ConsultarCep.Application/"]
COPY ["ConsultarCep.Domain/ConsultarCep.Domain.csproj", "ConsultarCep.Domain/"]
RUN dotnet restore "ConsultarCep/ConsultarCep.csproj"
COPY . .
WORKDIR "/src/ConsultarCep"
RUN dotnet build "ConsultarCep.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "ConsultarCep.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsultarCep.dll"]