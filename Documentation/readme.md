# Dokumentation

Applikationen börjar med att användaren legitimerar sig med ett personnummer som kollas upp i databasen. En ny användare får registrera sitt namn.

Ifall en person har en obetald faktura och på sätt en pågående parkering ombeds man först att betala faktura för att kunna fortsätta.

Databasen kollar ifall det finns ett SpaceShips registrerat på användaren. Om inte så får man möjligheten att registrera sitt skepp.

Alla möjliga SpacePorts listas med ID, Namn och Status. Status kan antingen vara Closed eller Available Spots och användaren får sedan välja en SpacePort.

En personkontroll görs för att se om användaren är med i någon Star Wars film.

En faktura(Invoice) och ett parkeringstillfälle(ParkingSession) lagras i databasen och användaren är fri att parkera. 



### Designbeslut

* Byggt Objektorienterat
  * Så få static metoder som möjligt
* Deployment redo applikation
* Method Chaining



### Saker vi kunde förbättrat

* Eventuellt kunnat generalisera <T> databasmetoder istället för att en inuti varje klass
* Planering, planering, PLANGERING