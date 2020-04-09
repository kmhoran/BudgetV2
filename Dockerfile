FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet restore

RUN dotnet publish WebApi/WebApi.csproj -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS runtime
WORKDIR /app/
COPY --from=build /app/out ./
EXPOSE 5000

ENTRYPOINT ["dotnet", "WebApi.dll","--urls", "http://0.0.0.0:5000"]