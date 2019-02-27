FROM microsoft/dotnet:2.2-aspnetcore-runtime AS Base
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

# Install npm packages first, this is slow so we want to minimise the number of un-cached runs
WORKDIR /src/InPort.WebUI/ClientApp/
COPY InPort.WebUI/ClientApp/package.json .
COPY InPort.WebUI/ClientApp/package-lock.json .

RUN npm install

# Restore dotnet before build to allow for caching
WORKDIR /
COPY InPort.Application/InPort.Application.csproj /src/InPort.Application/
COPY InPort.Common/InPort.Common.csproj /src/InPort.Common/
COPY InPort.Domain/InPort.Domain.csproj /src/InPort.Domain/
COPY InPort.Infrastructure/InPort.Infrastructure.csproj /src/InPort.Infrastructure/
COPY InPort.Persistence/InPort.Persistence.csproj /src/InPort.Persistence/
COPY InPort.WebUI/InPort.WebUI.csproj /src/InPort.WebUI/

RUN dotnet restore /src/InPort.WebUI/InPort.WebUI.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/InPort.WebUI/InPort.WebUI.csproj --no-restore -c Release
RUN dotnet publish /src/InPort.WebUI/InPort.WebUI.csproj --no-restore -c Release -o /app

# Copy compiled app to runtime container
FROM base AS final
COPY --from=build /app .
CMD ["dotnet", "InPort.WebUI.dll"]
