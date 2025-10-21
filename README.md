# NBPTableProject
A simple web application that fetches and displays the latest exchange rates from the National Bank of Poland (NBP). Built with React on the frontend and .NET API on the backend.

# Features
3 available endpoint to get NBP table B rates, update and save rates on local SQLite database, get rates from database,
worker in the background with configured interval from appsettings.json:
    "NBPWorker": {
    "IntervalSeconds": 10
    },
Fetches exchange rates from a .NET API,
Displays data in a clean, responsive table,
Refresh button to update rates on demand,
Error handling for network issues or missing configuration.

# Technologies Used:
Frontend: React, JavaScript, CSS
Backend: ASP.NET Core Web API

# Getting Started
1. Clone the repository
2. Setup Backend
- Run dotnet ef database update to create database locally (dotnet ef migrations add Init also if necessary at the beginning),
- Open the .NET API project in Visual Studio.
- Run the API (the best will be IIS Express).
- Copy localhost address e.g. https://localhost:44384
3. Setup Frontend
- in .env file fill the address to api e.g. REACT_APP_API_BASE=https://localhost:44384
- npm install
- npm start
App should work!











