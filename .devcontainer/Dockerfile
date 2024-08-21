FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN dotnet tool install --global dotnet-ef

# Install SQL Server command-line tools
RUN apt-get update && apt-get install -y curl gnupg
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list
RUN apt-get update && ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev

# Set the PATH environment variable
ENV PATH="$PATH:/opt/mssql-tools/bin"

# Install PowerShell
RUN apt-get update && apt-get install -y powershell

# Set the default shell to PowerShell
ENV SHELL="/usr/bin/pwsh" \
    POWERSHELL_DISTRIBUTION_CHANNEL="PSDocker-Ubuntu-20.04"

ENV PATH="$PATH:/root/.dotnet/tools"