FROM mcr.microsoft.com/azure-sql-edge:latest
WORKDIR /shoppingmall
COPY shoppingmall/. ./shoppingmall/
WORKDIR /shoppingmall/
RUN dotnet publish -c Release -o publish shoppingmall-master.sln


LABEL Name=shoppingmall Version=0.0.1
RUN apt-get -y update && apt-get install -y fortunes
ENV ACCEPT_EULA Y
ENV MSSQL_USER SA
ENV SA_PASSWORD="MyPass@word"
EXPOSE 1433

CMD ["sh", "-c", "/usr/games/fortune -a | cowsay"]


# ######

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY YourProjectName/*.csproj ./ YourProjectName /
RUN dotnet restore

# copy everything else and build app
COPY YourProjectName /. ./ YourProjectName /
WORKDIR /app/ YourProjectName
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/ YourProjectName /out ./
ENTRYPOINT ["dotnet", " YourProjectName.dll"]