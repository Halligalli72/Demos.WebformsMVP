# Demos.WebformsMVP
Demonstrerar MVP pattern med web forms (MVP = Model-View-Presenter)
==================================================================================

L�sningen demonstrerar hur ett MVP (Model-View-Presenter) pattern kan appliceras i Web Forms.
P� detta s�tt blir koden mer strukturerad och f�r b�ttre testbarhet.

Komma ig�ng:
1. Installera SQL Server Express (instans: .\SQLEXPRESS)
2. Skapa en databas som heter 'WebformsMVPDemo' (samma som namnet i web.config/app.config)
3. K�r scriptet 'WebFormsMVPModel.edmx.sql' i SQL Server Managment Studio.
4. Bygg solution och k�r enhetstesterna.
4. S�tt projektet 'Demos.WebformsMVP.WebUI' som startup och starta debug.


Kontrollera inneh�llet i databasen med f�ljande SQL:
	SELECT * FROM UserProfile
	SELECT * FROM Activity
	SELECT * FROM ActivityType

/Mattias F�lt
