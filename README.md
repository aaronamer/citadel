# Citadel

This project demonstrates the capture of a name using Angular 14.1.3 and adding the captured name to an in memory database server.  
	- The project contains validation of the name on the front-end to ensure it is not empty or pure whitespace  
	- The project contains validation in the API to ensure the name is not empty or pure whitespace  
	- The project contains Karma unit tests for testing the front-end  
	- The project contains unit tests for testing the API  
  
## Running the Project  
  
Please ensure you have the Angular 14+ CLI and .Net 7.0 installed.  The project can be run from Visual Studio 2022 by simply clicking the run button.  No additional configuration is required.  
  
## API Libraries  
  
The below libraries are used in the API (Citadel).  
	- Microsoft.AspNetCore.SpaProxy (7.0.2): This is a proxy service which allows the SPA application to run at the same time as the API  
	- Microsoft.EntityFrameworkCore (7.0.2): This is the ORM used for adding names to the data store  
	- Microsoft.EntityFrameworkCore.InMemory (7.0.2): This is the in-memory data store for use with EF  
  
## API Test Libraries  
  
The below libraries are used in the API test project (Citadel.Tests).  
	- coverlet.collector (3.1.2): This is a requirement of the Moq library  
	- Microsoft.NET.Test.SDK (17.3.2): This is part of the MSTest unit testing framework  
	- Moq (4.18.4): This is the library used for mocking objects in the unit tests  
	- MSTest.TestAdapter (2.2.10): This is part of the MSTest unit testing framework  
	- MSTest.TestFramework (2.2.10): This is part of the MSTest unit testing framework  
  
## Angular Libraries  
  
The Angular application makes use of Bootstrap 5.2.0.
  
## Running Angular Tests  
1.  Open the command prompt  
2.  In the repository, change to the folder [repository]/Citadel/ClientApp  
3.  Type "ng test" press the enter key  
  
## Running API Unit Tests  
1.  Open the solution in Visual Studio  
2.  From the menu select Test -> Run All Tests  
  
![image](https://user-images.githubusercontent.com/1416218/214462729-6e52f21f-8ae5-48dd-9588-f1bd83ef74a4.png)
