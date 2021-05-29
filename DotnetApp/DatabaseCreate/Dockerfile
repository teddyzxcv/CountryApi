FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# Заметка, для поиск докерфайла
LABEL maintainer="teddyzxcv"

# Добавляет проект в контейнере.
ADD /DatabaseCreate /src

#Настроить рабочий директории.
WORKDIR /src

# Выполнение команд.
RUN dotnet restore
RUN dotnet publish -c Release -o .

# Вход в прога.
ENTRYPOINT dotnet DatabaseCreate.dll
