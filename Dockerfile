# Use a imagem base do .NET SDK para compilar o código
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo de solução para o diretório de trabalho
COPY Tourmine.api.sln ./

# Copie todos os arquivos .csproj dos projetos para seus respectivos diretórios
COPY src/Tourmine.API/Tourmine.API.csproj ./src/Tourmine.API/
COPY src/Tourmine.Application/Tourmine.Application.csproj ./src/Tourmine.Application/
COPY src/Tourmine.Infrastructure/Tourmine.Infrastructure.csproj ./src/Tourmine.Infrastructure/

# Restaure as dependências
RUN dotnet restore

# Copie o restante do código do projeto para o contêiner
COPY src ./src

# Compile o projeto
RUN dotnet publish -c Release -o /app/out

# Use uma imagem de runtime para a execução do aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app

# Copie o aplicativo compilado da etapa anterior
COPY --from=build /app/out .

# Exponha a porta onde o serviço irá rodar
EXPOSE 8081

# Defina o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Tourmine.API.dll"]