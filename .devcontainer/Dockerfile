FROM mcr.microsoft.com/dotnet/sdk:8.0

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

# Create a non-root user
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

RUN groupadd --gid $USER_GID $USERNAME \
    && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME \
    && apt-get update \
    && apt-get install -y sudo \
    && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
    && chmod 0440 /etc/sudoers.d/$USERNAME

# Set the default user
USER $USERNAME

# Install dotnet-ef tool globally for the vscode user
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/home/$USERNAME/.dotnet/tools"