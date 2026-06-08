# ─── Estágio base: dependências comuns ───────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS base
WORKDIR /app

# ─── Estágio dev: roda com watch, código vem de volume ───────────────────────
FROM base AS dev
# dotnet watch precisa do SDK completo, não precisa copiar código aqui
# o código será montado via volume no compose
ENTRYPOINT ["dotnet", "watch", "run", "--no-launch-profile"]

# ─── Estágio build: compila o release ────────────────────────────────────────
FROM base AS build
COPY . .
RUN dotnet publish -c Release -o /publish

# ─── Estágio prod: imagem enxuta só com o runtime ────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS prod
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "OrganizerBackEnd.dll"]