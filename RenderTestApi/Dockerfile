

# ---- Build Stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ./RenderTestApi.csproj ./
RUN dotnet restore

# Copy rest of the app
COPY . ./
RUN dotnet publish RenderTestApi.csproj -c Release -o /app/publish

# ---- Runtime Stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port for Render
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "RenderTestApi.dll"]
