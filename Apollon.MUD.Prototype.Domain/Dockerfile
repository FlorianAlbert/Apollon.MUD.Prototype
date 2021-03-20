#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Apollon.MUD.Prototype.Domain/Apollon.MUD.Prototype.Domain.csproj", "Apollon.MUD.Prototype.Domain/"]
RUN dotnet restore "Apollon.MUD.Prototype.Domain/Apollon.MUD.Prototype.Domain.csproj"
COPY . .
WORKDIR "/src/Apollon.MUD.Prototype.Domain"
RUN dotnet build "Apollon.MUD.Prototype.Domain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apollon.MUD.Prototype.Domain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apollon.MUD.Prototype.Domain.dll"]