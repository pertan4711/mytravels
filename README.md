# MyTravels - Ett sätt att organisera dina bilder
Visonen med MyTravels är att användaren enkelt ska kunna lägga till bilder som systemet kan gruppera och passa in i en resa. Antingen via datum eller via andra EXIF-data som finns registrerade tillsammans med själva bilden vid fototillfället. Systemet ska inte lagra bilderna, snarare organisera dem och visa var dessa är tagna med GoogleMaps på en karta.

### Features:
- Lista resor
- Lista bilder tillhörande specifik resa
- Lägga till nya resor
- Drag-and-drop
- Spara resor i API
- Använd SQLite-databas

MyTravels består av en API-del som är skriven i C# .NET och en webb-applikation, skriven i react som konsumerar API-delarna. Nedan följer en kort redogörelse av hur systemet är uppdelat. Det finns specifika readme-filer i respektive katalog.

## MyTravels API
Är ett rest-API som  sparar information om mina resor uppdelat på delresor och media.
Det går att hämta, lägga till och ta bort resor. Detsamma gäller för media.
All data sparas i en databas, SQL-Lite som kan initieras med kommandot "update database" i 
Package Managment Console i Visual Studio 2022.

Öppna projektet i Visual Studio 2022 med solutionfilen, "MyTravels.API.sln". Bygg och 
starta tjänsten som går att komma åt på portarna 4711 (https) och 4712 (http).

För att överhuvudtaget komma åt data måste en fiktiv inloggning göras. Denna är inte 
implementerad utan skapar en "bearer token" som måste inkluderas i alla anrop. Annars 
fås ett Authentication-fel tillbaka. Enklast kan detta automatiseras i postman. 

Är modifiering av pluralsightkursen "ASP.NET Core 6 Web API Fundamentals" med Kevin Docx. 

## MyTravels APP
Är en react-applikation som visar en lista av inlagda resor. Här ska användaren kunna hantera bilder som är sparade på en extern källa. Systemet skall hjälpa användaren att organisera bilder, flytta ihop dem till resor och underresor. Dokumentera och dyl.

- React
- Asynkrona anrop med axios


### Referenser
- Pluralsightkurs: "ASP.NET Core 6 Web API Fundamentals" med Kevin Docx
- Pluralsightkurs: "React 18 Fundamentals" med Roland Guijt
