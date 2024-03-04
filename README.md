MyTravels API
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
