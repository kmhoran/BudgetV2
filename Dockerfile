FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

COPY . ./
RUN echo "dotnet --version"
RUN dotnet --version
RUN dotnet restore

RUN dotnet publish WebApi/WebApi.csproj -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]