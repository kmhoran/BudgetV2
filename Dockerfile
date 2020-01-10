# Create the build environment image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as build-env
WORKDIR /app/
# copy files to current directory
COPY . ./

# publish to /out
RUN dotnet publish WebApi/WebApi.csproj -c Release -o /app/out
# change to published directory and set entrypoint
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app/
COPY --from=build-env /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"]