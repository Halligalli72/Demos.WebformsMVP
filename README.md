# Demos.WebformsMVP: Demonstrerar MVP pattern med ASP.Net Web Forms

Exemplet demonstrerar hur ett MVP pattern (Model-View-Presenter) kan appliceras i ett gammalt ASP.Net Web Forms webbprojekt.  
På detta sätt blir koden mer strukturerad, får bättre testbarhet och förbereds för framtida byte av vymotor.

Komma igång:  
1. Installera SQL Server Express (instans: .\SQLEXPRESS)  
2. Skapa en tom databas som heter 'WebformsMVPDemo' (samma som namnet i web.config)  
3. Kör scripten under 'Demos.WebformsMVP.DataAccess\Database' i SQL Server Management Studio för att skapa tabeller och fylla med data.  
4. Bygg solution och kör enhetstesterna.  
5. Sätt projektet 'Demos.WebformsMVP.WebUI' som startup och starta debug.  

Kontrollera innehållet i databasen med följande SQL:  
* SELECT * FROM UserProfile  
* SELECT * FROM Activity  
* SELECT * FROM ActivityType  


Hur dependency injection (DI) är uppsatt i webbapplikationen (ASP.NET Web Forms):
* AutoFac används som DI ramverk.
* DI konfigureras i "global.asax.cs"
* Alla Web Forms vyer ärver från "DemoBasePage.cs", där applikationstjänsterna injectas m h a AutoFac attributet [InjectProperties]