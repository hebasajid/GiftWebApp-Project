#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GiftAPI/GiftAPI.csproj", "GiftAPI/"]
COPY ["GiftInfoLibraryy/GiftInfoLibraryy.csproj", "GiftInfoLibraryy/"]
RUN dotnet restore "GiftAPI/GiftAPI.csproj"
COPY . .
WORKDIR "/src/GiftAPI"
RUN dotnet build "GiftAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GiftAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GiftAPI.dll"]