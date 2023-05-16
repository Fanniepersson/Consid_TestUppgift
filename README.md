## Min applikation
### Här kan man som användare göra följande:
1. Se alla produkter, försäljare och lager
2. Hantera produkter, lägga till ny, radera eller uppdatera en befintlig.
3. Hantera försäljare, lägga till ny, radera eller uppdatera en befintlig.
4. Hantera lager, lägga till ny, radera eller uppdatera en befintlig.
5. Söka efter ett produkt namn och få upp information om produkten samt se vilket lager den finns i.


### Instruktioner för att köra webb applikationen
1. Kör applikationen i Visual Studio
2. I adressfältet, kopiera din localhost adress
3. Öppna UI koden i visual code
4. Gå till service mappen
5. I varje service component klistra in din localhost adress
 ![image](https://github.com/Fanniepersson/Consid_TestUppgift/assets/91312758/143d2cb4-3f16-43da-baeb-f6349aea16ba)
6. Klar!


### Reflektioner
Jag valde att skapa tabellerna supplier, product, warehouse med many-to-many relations mellan product och supplier, samt product och warehouse och då ha två kopplingstabeller(ProductSupplier och ProductWarehouse).
Jag valde att använda repository pattern för att skapa ett abstraktions lager mellan controllern och databasen och för att koden ser mer städad ut när den är uppdelad. Jag ville implementera ett UI och såg det som ett bra tillfälle att öva på det. Därför valde jag att skapa UI:t i Angular.

#### Jag valde att använda en Kanban board i Trello, för att få en tydlig överblick på vilka uppgifter jag gjort och vilka jag hade kvar att göra.
https://trello.com/b/124Pl5J4/considtestuppgift
