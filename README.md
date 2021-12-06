# Demos.WebformsMVP: Demonstrates the MVP pattern applied in a legacy ASP.Net Web Forms application

The solution demonstrates how a MVP pattern (Model-View-Presenter) can be applied to an old ASP.Net Web Forms web project.  
This way, the code get a better structure, gets more testable and will be prepared for another view engine than ASP.Net Web Forms.

Get started:  
1. Install SQL Server Express (instance: .\SQLEXPRESS)  
2. Create an empty database named 'WebformsMVPDemo' (same as Database property in web.config)  
3. Run the sql scripts in 'Demos.WebformsMVP.DataAccess\Database' with SQL Server Management Studio to create tables and fill then with sample data.  
4. Build the solution and run the unit tests.  
5. Set the project 'Demos.WebformsMVP.WebUI' as startup project and start debug.  

Inspect the database content with the following SQL queries:  
* SELECT * FROM UserProfile  
* SELECT * FROM Activity  
* SELECT * FROM ActivityType  


How dependency injection (DI) is configured in the web application (ASP.NET Web Forms):
* AutoFac is used as DI framework. Also Autofac.Web is used to integrate better with ASP.NET Web Forms.
* DI is configured in "global.asax.cs"
* All Web Forms views can inherit from base class "BasePage.cs", where the application services are injected with the AutoFac attribute [InjectProperties]