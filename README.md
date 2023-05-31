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

I chose to to make Database-Seeder app separately because that way I could run it in azure container image. I have SQL server on Azure and Database seeding with over 3 million journeys was time consuming so it was better to run app in cloud as container image.

You can find my demo of this project running as Azure Web App Here:
+ https://helsinki-city-bike-app.azurewebsites.net/***** CURRENTLY NOT RUNNING ON AZURE

<h1>How To Build</h1>

If you want to build this solution, follow this tutorial.

<h2>Prerequisites:</h2>

+ Make sure you have .NET 7.0 SDK installed or Download here: https://dotnet.microsoft.com/en-us/download
+ I recommend to use Visual Studio 2022 as IDE. Download here: https://visualstudio.microsoft.com/
+ You need to have SQL Server and connection string to connect with app.
+ When installing Visual Studio install ASP.NET workloads:
![Näyttökuva (240)](https://user-images.githubusercontent.com/55025026/212563331-cb5d4748-13e6-4de6-874b-8f474b52823a.png)


<h2>Download app from Github:</h2>

Start visual studio community 2022 and you can download this repository straight to IDE:

![Näyttökuva (241)](https://user-images.githubusercontent.com/55025026/212563600-cdc574e4-9434-4a11-acc3-26ddd90d8d2b.png)

Add reposity url in the field and choose where you want to download it:
![Näyttökuva (242)](https://user-images.githubusercontent.com/55025026/212563759-047dd38a-4ceb-4cb4-bb0f-545de96b19c3.png)

<h2>Connecting to SQL:</h2>

Next step is to add your SQL database connection string to both appsettings.json files found in Helsinki-City-Bike-App and Helsinki-City-Bike-Database-Seeder project. Paste your connection string inside quotas under the "AppDbContext": "YourConnectionString".

<h2>Buildh</h2>

Before first time building the app set the Helsinki-City-Bike-App-Database-Seeder as Startup Project.

Right click the Helsinki-City-Bike-Database-Seeder in solution explorer and left click "Set as Startup Project":

![Näyttökuva (259)](https://user-images.githubusercontent.com/55025026/214257443-24c647e5-1690-4778-9f36-26b73b025feb.png)

From top left choose the either http or https protocol and run the app (If you choose https there will be prompt window to ask you to generate self-signed sertificate)

![Näyttökuva (264)](https://user-images.githubusercontent.com/55025026/214259831-713f8065-c22d-4a1b-b5d4-e8e2f4258adf.png)

App will now start seeding the database. If you dont want to wait the whole dataset to be saved in database stop running the app after few minutes (so you have at least some data to play with the web application itself).

Right click the Helsinki-City-Bike-App in solution explorer and left click "Set as Startup Project":
![Näyttökuva (266)](https://user-images.githubusercontent.com/55025026/214263310-e54a3b20-a352-47e7-9a85-0c8e8ff1e937.png)

And run the app with http or https protocol. Server will start now and visual studio opens the build app in web browser.


<h1>How To Run Tests</h1>

You can run NUnit tests by clicking Test -> Run All Tests
![Näyttökuva (271)](https://user-images.githubusercontent.com/55025026/216923437-b07fd7ca-90dd-431c-a1a0-3fb02a577e05.png)


