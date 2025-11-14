FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY ConfessionApp.Core/*.csproj ./ConfessionApp.Core/
COPY ConfessionApp.Application/*.csproj ./ConfessionApp.Application/
COPY ConfessionApp.Infrastructure/*.csproj ./ConfessionApp.Infrastructure/
COPY ConfessionApp.WebApi/*.csproj ./ConfessionApp.WebApi/
RUN dotnet restore


COPY . .
WORKDIR "/src/ConfessionApp.WebApi"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080 

ENTRYPOINT ["dotnet", "ConfessionApp.WebApi.dll"]