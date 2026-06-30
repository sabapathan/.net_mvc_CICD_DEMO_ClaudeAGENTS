# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["EcommerceApi.sln", "."]
COPY ["src/EcommerceApi.Api/EcommerceApi.Api.csproj", "src/EcommerceApi.Api/"]
COPY ["src/EcommerceApi.Domain/EcommerceApi.Domain.csproj", "src/EcommerceApi.Domain/"]
COPY ["src/EcommerceApi.Application/EcommerceApi.Application.csproj", "src/EcommerceApi.Application/"]
COPY ["src/EcommerceApi.Infrastructure/EcommerceApi.Infrastructure.csproj", "src/EcommerceApi.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "EcommerceApi.sln"

# Copy all source files
COPY . .

# Build the application
RUN dotnet build "EcommerceApi.sln" -c Release --no-restore

# Publish stage
FROM build AS publish
RUN dotnet publish "src/EcommerceApi.Api/EcommerceApi.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-build \
    --no-self-contained

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Create non-root user for security
RUN addgroup --system dotnet && adduser --system --ingroup dotnet dotnet

# Copy published files
COPY --from=publish /app/publish .
COPY --from=publish --chown=dotnet:dotnet /app/publish .

USER dotnet

# Health check
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
    CMD dotnet /app/health-check.dll || exit 1

EXPOSE 5000 5001
ENTRYPOINT ["dotnet", "EcommerceApi.Api.dll"]
