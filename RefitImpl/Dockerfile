FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["RefitTest/RefitTest.csproj", "RefitTest/"]
RUN dotnet restore "RefitTest/RefitTest.csproj"
COPY . .
WORKDIR "/src/RefitTest"
RUN dotnet build "RefitTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RefitTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RefitTest.dll"]
