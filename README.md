# Demos.WebformsMVP: Demonstrerar MVP pattern med ASP.Net Web Forms

Lösningen demonstrerar hur ett MVP pattern (Model-View-Presenter) kan appliceras i ett gammalt ASP.Net Web Forms webbprojekt.  
På detta sätt blir koden mer strukturerad, får bättre testbarhet och förbereds för framtida byte av vymotor.

Komma igång:  
1. Installera SQL Server Express (instans: .\SQLEXPRESS)  
2. Skapa en databas som heter 'WebformsMVPDemo' (samma som namnet i web.config/app.config)  
3. Kör scriptet 'WebFormsMVPModel.edmx.sql' i SQL Server Managment Studio.  
4. Bygg solution och kör enhetstesterna.  
4. Sätt projektet 'Demos.WebformsMVP.WebUI' som startup och starta debug.  


Kontrollera innehållet i databasen med följande SQL:  
* SELECT * FROM UserProfile  
* SELECT * FROM Activity  
* SELECT * FROM ActivityType  

