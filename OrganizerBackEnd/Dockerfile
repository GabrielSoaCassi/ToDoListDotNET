# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copia apenas o necessário pro restore (cache bom)
COPY OrganizerBackEnd.sln .
COPY OrganizerBackEnd/OrganizerBackEnd.csproj OrganizerBackEnd/
COPY OrganizerTestes/OrganizerTestes.csproj OrganizerTestes/

RUN dotnet restore

# copia resto do código
COPY . .

# build + test
RUN dotnet test OrganizerBackEnd.sln -c Release --no-restore

# publish (aqui ele já compila tudo)
RUN dotnet publish OrganizerBackEnd/OrganizerBackEnd.csproj \
    -c Release \
    -o /app/publish \
    --no-restore


# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "OrganizerBackEnd.dll"]