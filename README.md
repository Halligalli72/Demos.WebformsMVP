# Demos.WebformsMVP
Demonstrerar MVP pattern med web forms (MVP = Model-View-Presenter)
==================================================================================

Lösningen demonstrerar hur ett MVP (Model-View-Presenter) pattern kan appliceras i Web Forms.
På detta sätt blir koden mer strukturerad och får bättre testbarhet.

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

/Mattias Fält
