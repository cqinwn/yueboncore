#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Yuebon.WebApi/Yuebon.WebApi.csproj", "Yuebon.WebApi/"]
COPY ["CMS/Yuebon.CMS.Services/Yuebon.CMS.Services.csproj", "CMS/Yuebon.CMS.Services/"]
COPY ["CMS/Yuebon.CMS.IServices/Yuebon.CMS.IServices.csproj", "CMS/Yuebon.CMS.IServices/"]
COPY ["CMS/Yuebon.CMS.Dtos/Yuebon.CMS.Dtos.csproj", "CMS/Yuebon.CMS.Dtos/"]
COPY ["Yuebon.Core/Yuebon.Core.csproj", "Yuebon.Core/"]
COPY ["Yuebon.NetCore/Yuebon.Commons/Yuebon.Commons.csproj", "Yuebon.NetCore/Yuebon.Commons/"]
COPY ["CMS/Yuebon.CMS.Models/Yuebon.CMS.Models.csproj", "CMS/Yuebon.CMS.Models/"]
COPY ["CMS/Yuebon.CMS.Repositories/Yuebon.CMS.Repositories.csproj", "CMS/Yuebon.CMS.Repositories/"]
COPY ["CMS/Yuebon.CMS.IRepositories/Yuebon.CMS.IRepositories.csproj", "CMS/Yuebon.CMS.IRepositories/"]
COPY ["Security/Yuebon.Security.Dtos/Yuebon.Security.Dtos.csproj", "Security/Yuebon.Security.Dtos/"]
COPY ["Security/Yuebon.Security.Models/Yuebon.Security.Models.csproj", "Security/Yuebon.Security.Models/"]
COPY ["Yuebon.CodeGenerator.Core/Yuebon.CodeGenerator.Core.csproj", "Yuebon.CodeGenerator.Core/"]
COPY ["Yuebon.Extensions/Yuebon.Extensions.csproj", "Yuebon.Extensions/"]
COPY ["Security/Yuebon.Security.Services/Yuebon.Security.Services.csproj", "Security/Yuebon.Security.Services/"]
COPY ["Yuebon.EventBus/Yuebon.EventBus.csproj", "Yuebon.EventBus/"]
COPY ["Security/Yuebon.Security.IServices/Yuebon.Security.IServices.csproj", "Security/Yuebon.Security.IServices/"]
COPY ["Security/Yuebon.Security.Repositories/Yuebon.Security.Repositories.csproj", "Security/Yuebon.Security.Repositories/"]
COPY ["Security/Yuebon.Security.IRepositories/Yuebon.Security.IRepositories.csproj", "Security/Yuebon.Security.IRepositories/"]
COPY ["Security/Yuebon.Security.Seeds/Yuebon.Security.SeedData.csproj", "Security/Yuebon.Security.Seeds/"]
COPY ["Yuebon.EventBus.RabbitMQ/Yuebon.EventBus.RabbitMQ.csproj", "Yuebon.EventBus.RabbitMQ/"]
COPY ["Yuebon.NetCore/Yuebon.Quartz.Jobs/Yuebon.Quartz.Jobs.csproj", "Yuebon.NetCore/Yuebon.Quartz.Jobs/"]
COPY ["Yuebon.NetCore/Yuebon.Email.Core/Yuebon.Email.Core.csproj", "Yuebon.NetCore/Yuebon.Email.Core/"]
COPY ["Yuebon.NetCore/Yuebon.AspNetCore/Yuebon.AspNetCore.csproj", "Yuebon.NetCore/Yuebon.AspNetCore/"]
COPY ["Yuebon.NetCore/Yuebon.SMS.Core/Yuebon.SMS.Core.csproj", "Yuebon.NetCore/Yuebon.SMS.Core/"]
RUN dotnet restore "Yuebon.WebApi/Yuebon.WebApi.csproj"
COPY . .
WORKDIR "/src/Yuebon.WebApi"
RUN dotnet build "Yuebon.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yuebon.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yuebon.WebApi.dll"]