FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY PerformanceReview.Web.Rest/PerformanceReview.Web.Rest.csproj PerformanceReview.Web.Rest/
RUN dotnet restore
COPY . .
WORKDIR /src/PerformanceReview.Web.Rest
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PerformanceReview.Web.Rest.dll"]
