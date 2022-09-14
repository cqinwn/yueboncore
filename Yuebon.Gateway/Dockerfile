#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Yuebon.Gateway/Yuebon.Gateway.csproj", "Yuebon.Gateway/"]
RUN dotnet restore "Yuebon.Gateway/Yuebon.Gateway.csproj"
COPY . .
WORKDIR "/src/Yuebon.Gateway"
RUN dotnet build "Yuebon.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yuebon.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yuebon.Gateway.dll","-b","0.0.0.0"]