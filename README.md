# LearnFromAI

LearnFromAI is a production-ready e-learning web application built using .NET Core 8, SQL database, Entity Framework, and Docker. The application includes user login functionality and is designed to be run using a devcontainer in Visual Studio Code.

## Project Structure

The project follows a standard .NET Core 8 web application structure:

- `Pages/`: Contains Razor pages and their corresponding page models.
- `Data/`: Contains the database context and entity classes.
- `wwwroot/`: Contains static files such as CSS, JavaScript, and images.
- `Dockerfile`: Defines the Docker image for the application.
- `docker-compose.yml`: Defines the services and their configurations for running the application with Docker Compose.
- `.devcontainer/`: Contains the devcontainer configuration files.

## Technologies Used

- .NET Core 8: The main framework for building the web application.
- SQL Database: The database provider for storing application data.
- Entity Framework Core: The ORM (Object-Relational Mapping) framework for interacting with the database.
- ASP.NET Core Identity: The authentication and authorization framework for user login functionality.
- Docker: Used for containerizing the application and running it in a devcontainer.
- Visual Studio Code: The IDE used for development, with devcontainer support.
- PowerShell: The shell used for running commands in the devcontainer.

## Getting Started

To start developing the LearnFromAI application, follow these steps:

1. Clone the repository to your local machine.
2. Open the project in Visual Studio Code.
3. Make sure you have the Remote Development extension pack installed.
4. Open the Command Palette (Ctrl+Shift+P) and run the "Remote-Containers: Reopen in Container" command.
5. Wait for the devcontainer to be built and the project to be loaded.

## Devcontainer Commands

Inside the devcontainer, you can use the following commands:

- `dotnet run`: Starts the application.
- `dotnet ef database update`: Applies any pending database migrations.
- `dotnet ef migrations add <MigrationName>`: Adds a new database migration with the specified name.
- `dotnet build`: Builds the application.
- `dotnet test`: Runs the unit tests.

To stop the application, press `Ctrl+C` in the terminal where you ran `dotnet run`.

## Docker Compose Commands

To run the application using Docker Compose, use the following commands:

- `docker-compose up --build`: Builds and starts the application and database containers.
- `docker-compose down`: Stops and removes the containers.

## Contributing

Contributions to the LearnFromAI project are welcome! If you find any issues or have suggestions for improvements, please create an issue or submit a pull request.

## License

This project [unlicensed](LICENSE).