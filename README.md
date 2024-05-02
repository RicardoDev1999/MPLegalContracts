# MP (Match-Profiler) Legal Contracts

## Getting Started

### Running the WebApi.

- Via Docker Compose (With SQL Database but no debugger): 
1. Navigate to the project directory: `cd <project-location>`
2. Run `docker compose up`

- Via Visual Studio (With In-Memory Database):
1. Open Visual Studio
2. Choose the project
3. Set the default project to MPLegalContracts.API
4. Set the launch settings to https.
5. Run the debugger.

- Via Visual Studio with Docker Compose (With SQL Database and debugger):
1. Open Visual Studio
2. Choose the project
3. Set the default project to docker-compose
4. Set the launch settings to "Docker Compose"
5. Run the debugger. (This executes docker compose with debugger attached on the web api)

### Running the WebAPP

- Running the WebApp:
1. Run `cd <project-location>/MPLegalContracts.Application`
2. Run `(npm / pnpm / bun) install` and then `(npm / pnpm / bun) run dev`

The WebApi will launch on the same port on all the setups mentioned above.

### Prerequisites

To install and run this software, you will need the following:

- [.NET 8 Core SDK](https://dotnet.microsoft.com/download) - The software development kit for .NET Core.
- [Node.js](https://nodejs.org/) - JavaScript runtime environment.
- [Docker](https://www.docker.com/) - The containerization platform used for deployment.

## Usage

Provide instructions on how to use your project.

## Running the tests

1. Open Visual Studio.
2. Choose the project.
3. Set the default project to MPLegalContracts.Tests (assuming that's the name of your test project).
4. Build the solution to ensure that all the necessary dependencies are resolved.
5. Open the Test Explorer window by going to Test > Windows > Test Explorer.
6. In the Test Explorer window, you will see a list of all the available tests.
7. Click on the "Run All" button to execute all the tests.
8. You can also run individual tests by selecting them and clicking on the "Run Selected Tests" button.

## Built With

* [.NET](https://dotnet.microsoft.com/) - The web framework used
* [EF Core](https://docs.microsoft.com/en-us/ef/core/) - ORM for database operations
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019) - Database system
* [Node.js](https://nodejs.org/) - JavaScript runtime environment
* [Docker](https://www.docker.com/) - Containerization platform
* [Vue.js](https://vuejs.org/) - JavaScript framework for building user interfaces
* [Tailwind CSS](https://tailwindcss.com/) - CSS framework

## Authors

[Ricardo Duarte](https://github.com/RicardoDev1999)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details
