# ==========================================
# ETAPA 1 - BUILD
# ==========================================
#É feito dessa forma para diminuir o tamanho então pegamos o SDK e Criamos um BUILD
#Versão 8.0 do SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
#Qual o diretório que eu reconheço como raiz do projeto
WORKDIR /src

# Copy everything
# Copia apenas o csproj que influencia o restore  sem os arquivos do codigo fonte
# [Origem , Destino]
# Futuramente quando for feito a separação vamos ter qe trazer os outreos csproj 
# Mas o restore fica apenas no projeto que referência todos os outros ex.
# API Referência os demais o restore nela deveria resolver
#O Padrão é copiar a solution tbm
# OU ["OrganizerBackEnd.sln", "."]
COPY ["OrganizerBackEnd.sln", "/src"]
COPY ["OrganizerTestes/OrganizerTestes.csproj","OrganizerTestes/"]
COPY ["OrganizerBackEnd/OrganizerBackEnd.csproj","OrganizerBackEnd/"]
RUN cat /src/OrganizerBackEnd.sln
#restaurar a partir da solution
RUN dotnet restore OrganizerBackEnd.sln
#Quandos se tem apenas um csproj
# RUN dotnet restore "OrganizerBackEnd/OrganizerBackEnd.csproj"

#Copia o restante do código-fonte necessário para o build.
#A separação em relação ao csproj permite melhor aproveitamento do cache.
COPY . .
WORKDIR /src/OrganizerBackEnd
#Isso aqui ainda faz sentido ? 
#não sei se o restore ja cuidaria disso  e eu apenas precisaria copiar os arquivos
#Roda os testes              
FROM build AS test
WORKDIR /src
RUN dotnet test OrganizerBackEnd.sln -c Release


#Roda o publish para gerar a dll da API
FROM test AS publish
WORKDIR /src/OrganizerBackEnd
RUN dotnet publish "OrganizerBackEnd.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

#Coloca API para roda. eu poderia ter um .sh sendo chamado 
#no entry point que poderia ter mais regras/validação
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
#DEFINE a porta que esta servindo a API
ENV ASPNETCORE_URLS=http://+:8080
# Copia apenas o resultado do publish
COPY --from=publish /app/publish .
# Porta padrão da aplicação
EXPOSE 8080
ENTRYPOINT ["dotnet", "OrganizerBackEnd.dll"]