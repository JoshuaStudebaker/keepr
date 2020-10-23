FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet CHANGE_ME.dll