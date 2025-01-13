# 2024 project web API lampen

Web Services-applicatie (RESTful API) opbouw met ASP.NET Core. Een webservice is een applicatie die communicatie tussen systemen mogelijk maakt via internetprotocollen. Dit wordt gedaan adhv de REST API manier:  HTTP-methoden (GET, POST, PUT, DELETE) en gebruikt dataformaat JSON. Omdat de focus op het bouwen van API’s ligt en niet op het bouwen van websites, wordt er geen views (MVC) gebruikt en kan je enkel data terugsturen (en ontvangen) in JSON formaat.

de API heeft 3 entiteiten en zijn als volgt gerelateerd:
•	Een lamp verwijst naar een fabrikant via een fabrikantId.
•	Een lamp heeft een lijst van stijlen via hun stijlIds.

  * 15 API ENDPOINTS:
     - 6 GET-endpoints (3 voor lijsten, 3 voor details)
     - 3 POST-endpoints (voor het toevoegen van entiteiten)
     - 3 PUT-endpoints (voor het bijwerken van entiteiten)
     - 3 DELETE-endpoints (voor het verwijderen van entiteiten)
  * Taal: C#
  * Technologieën:
     - ASP.NET Core (webdevelopment framework die webapp's op .NET platform bouwt) voor het bouwen van de RESTful API.
     - Swagger (API-documentatie en testing via Swagger UI)
     - HTTP (Protocol voor communicatie tussen client en server) methoden: GET POST PUT DELETE
     - JSON
     - Data Annotations (Validatie van data in C#)
     - Entity Framework voor databasebeheer
     - Automapper voor dataconversie
     - Serilog voor logging
    
* switch between an in-memory database and a SQL Server database
