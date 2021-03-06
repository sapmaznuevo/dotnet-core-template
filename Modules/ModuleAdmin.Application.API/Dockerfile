﻿FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

#PROJECTS
 COPY "dotnet-core-common/CoreCommon.Application.API/CoreCommon.Application.API.csproj" "dotnet-core-common/CoreCommon.Application.API/CoreCommon.Application.API.csproj"
 COPY "dotnet-core-common/CoreCommon.Business.Service/CoreCommon.Business.Service.csproj" "dotnet-core-common/CoreCommon.Business.Service/CoreCommon.Business.Service.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.Domain/CoreCommon.Data.Domain.csproj" "dotnet-core-common/CoreCommon.Data.Domain/CoreCommon.Data.Domain.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.ElasticSearch/CoreCommon.Data.ElasticSearch.csproj" "dotnet-core-common/CoreCommon.Data.ElasticSearch/CoreCommon.Data.ElasticSearch.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.EntityFrameworkBase/CoreCommon.Data.EntityFrameworkBase.csproj" "dotnet-core-common/CoreCommon.Data.EntityFrameworkBase/CoreCommon.Data.EntityFrameworkBase.csproj"
 COPY "dotnet-core-common/CoreCommon.Infra/CoreCommon.Infra.csproj" "dotnet-core-common/CoreCommon.Infra/CoreCommon.Infra.csproj"
 COPY "dotnet-core-common/CoreCommon.ModuleBase/CoreCommon.ModuleBase.csproj" "dotnet-core-common/CoreCommon.ModuleBase/CoreCommon.ModuleBase.csproj"
 COPY "dotnet-core-template/Application/CoreTemplate.Application.API/CoreTemplate.Application.AllAPI.csproj" "dotnet-core-template/Application/CoreTemplate.Application.API/CoreTemplate.Application.AllAPI.csproj"
 COPY "dotnet-core-template/Application/CoreTemplate.Application.WorkerService/CoreTemplate.Application.WorkerService.csproj" "dotnet-core-template/Application/CoreTemplate.Application.WorkerService/CoreTemplate.Application.WorkerService.csproj"
 COPY "dotnet-core-template/Modules/ModuleAccount.Application.API/ModuleAccount.Application.API.csproj" "dotnet-core-template/Modules/ModuleAccount.Application.API/ModuleAccount.Application.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleAccount/ModuleAccount.csproj" "dotnet-core-template/Modules/ModuleAccount/ModuleAccount.csproj"
 COPY "dotnet-core-template/Modules/ModuleAccountApi/ModuleAccountApi.csproj" "dotnet-core-template/Modules/ModuleAccountApi/ModuleAccountApi.csproj"
 COPY "dotnet-core-template/Modules/ModuleAdmin.Application.API/ModuleAdmin.Application.API.csproj" "dotnet-core-template/Modules/ModuleAdmin.Application.API/ModuleAdmin.Application.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleAdmin/ModuleAdmin.csproj" "dotnet-core-template/Modules/ModuleAdmin/ModuleAdmin.csproj"
 COPY "dotnet-core-template/Modules/ModuleAdminApi/ModuleAdminApi.csproj" "dotnet-core-template/Modules/ModuleAdminApi/ModuleAdminApi.csproj"
 COPY "dotnet-core-template/Modules/ModuleCommon.Application.API/ModuleCommon.Application.API.csproj" "dotnet-core-template/Modules/ModuleCommon.Application.API/ModuleCommon.Application.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleCommon/ModuleCommon.csproj" "dotnet-core-template/Modules/ModuleCommon/ModuleCommon.csproj"
 COPY "dotnet-core-template/Modules/ModuleCommonApi/ModuleCommonApi.csproj" "dotnet-core-template/Modules/ModuleCommonApi/ModuleCommonApi.csproj"
 COPY "dotnet-core-template/Modules/ModuleTemplate.Application.API/ModuleTemplate.Application.API.csproj" "dotnet-core-template/Modules/ModuleTemplate.Application.API/ModuleTemplate.Application.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleTemplate/ModuleTemplate.csproj" "dotnet-core-template/Modules/ModuleTemplate/ModuleTemplate.csproj"
 COPY "dotnet-core-template/Modules/ModuleTemplateApi/ModuleTemplateApi.csproj" "dotnet-core-template/Modules/ModuleTemplateApi/ModuleTemplateApi.csproj"


RUN dotnet restore "dotnet-core-template/Modules/ModuleAdmin.Application.API/ModuleAdmin.Application.API.csproj"
COPY . /src/.
WORKDIR "/src/dotnet-core-template/Modules/ModuleAdmin.Application.API/"
RUN dotnet build "ModuleAdmin.Application.API.csproj" -c Release -o /app/build
#RUN dotnet build -c $Configuration -o /app
RUN dotnet publish "ModuleAdmin.Application.API.csproj" --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ModuleAdmin.Application.API.dll"]
