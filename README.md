<h1>Helsinki City Bike App</h1>

This is ASP.NET CORE App that displays data from journeys made with City Bikes in Capital area of Finlnad.
Backend service fetches and converts .csv data to objects and Entity Framework saves that data to sql server.
Razor pages handles the frontend UI.

Dataset that has information about HSL's city bike stations found here: 
+ https://opendata.arcgis.com/datasets/726277c507ef4914b0aec3cbcfcbfafc_0.csv
is saved as Station entities.
  
And Datasets about journeys found here:
+ https://dev.hsl.fi/citybikes/od-trips-2021/2021-05.csv
+ https://dev.hsl.fi/citybikes/od-trips-2021/2021-06.csv
+ https://dev.hsl.fi/citybikes/od-trips-2021/2021-07.csv
are saved as Journey entities.

There are two projects in this solution.

+ The Helsinki-City-Bike-Database-Seeder will fetch and parse csv data and saves that data in sql server.
+ Helsinki-City-Bike-App project is for creating basic Web App that shows data from sql server and it has and UI for CRUD operations.

You can find my demo of this project running as Azure Web App Here:
+ https://helsinki-city-bike-app.azurewebsites.net/

<h1>How To Build</h1>

If you want to build this solution, follow this tutorial.

Prerequisites:
+ I recommend to use Visual Studio 2022 as IDE. Download here: https://visualstudio.microsoft.com/
+ Make sure you have .NET 7.0 installed or Download here: https://dotnet.microsoft.com/en-us/download
