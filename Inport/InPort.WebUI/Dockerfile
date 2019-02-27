FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

# Install node and npm
ENV NODE_VERSION 8.12.0
ENV NODE_DOWNLOAD_SHA 3df19b748ee2b6dfe3a03448ebc6186a3a86aeab557018d77a0f7f3314594ef6
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz

RUN wget "$NODE_DOWNLOAD_URL" -O nodejs.tar.gz \
	&& echo "$NODE_DOWNLOAD_SHA  nodejs.tar.gz" | sha256sum -c - \
	&& tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
	&& rm nodejs.tar.gz \
	&& ln -s /usr/local/bin/node /usr/local/bin/nodejs

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

# Primero instale los paquetes npm, esto es lento, por lo que queremos minimizar el número de ejecuciones sin caché
WORKDIR /src/InPort.WebUI/ClientApp/
COPY InPort.WebUI/ClientApp/package.json .
COPY InPort.WebUI/ClientApp/package-lock.json .

RUN npm install

# Restaurar dotnet antes de construir para permitir el almacenamiento en caché
WORKDIR /src
COPY ["InPort.WebUI/InPort.WebUI.csproj", "InPort.WebUI/"]
COPY ["InPort.Aplication.Core/InPort.Aplication.Core.csproj", "InPort.Aplication.Core/"]
COPY ["InPort.Infra.CrossCutting.Bus/InPort.Infra.CrossCutting.Bus.csproj", "InPort.Infra.CrossCutting.Bus/"]
COPY ["InPort.Domain.Core/InPort.Domain.Core.csproj", "InPort.Domain.Core/"]
COPY ["InPort.Domain/InPort.Domain.csproj", "InPort.Domain/"]
COPY ["InPort.Infra.Data/InPort.Infra.Data.csproj", "InPort.Infra.Data/"]
COPY ["InPort.Infra.CrossCutting.IoC/InPort.Infra.CrossCutting.IoC.csproj", "InPort.Infra.CrossCutting.IoC/"]
COPY ["InPort.Infra.CrossCutting.Identity/InPort.Infra.CrossCutting.Identity.csproj", "InPort.Infra.CrossCutting.Identity/"]
COPY ["InPort.Aplication/InPort.Aplication.csproj", "InPort.Aplication/"]
COPY ["InPort.Infra.Core/InPort.Infra.Core.csproj", "InPort.Infra.Core/"]
RUN dotnet restore "InPort.WebUI/InPort.WebUI.csproj"

# Copia archivos fuente y compila
COPY . .
WORKDIR "/src/InPort.WebUI"
RUN dotnet build "InPort.WebUI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InPort.WebUI.csproj" -c Release -o /app

# Copiar la aplicación compilada al contenedor de tiempo de ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InPort.WebUI.dll"]