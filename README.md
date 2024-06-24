Opis Projektu
SimpleShop to aplikacja internetowa stworzona przy użyciu ASP.NET Core, która zarządza sklepem internetowym. Aplikacja umożliwia zarządzanie użytkownikami, produktami, zamówieniami oraz rolami użytkowników. Autoryzacja i uwierzytelnianie użytkowników odbywa się za pomocą tokenów JWT.

Struktura Projektu
Projekt jest podzielony na cztery warstwy:

SimpleShop.Core: Definiuje encje, interfejsy oraz logikę domenową.
SimpleShop.Application: Zawiera logikę aplikacyjną oraz implementacje interfejsów.
SimpleShop.Infrastructure: Implementacje repozytoriów oraz konfiguracja dostępu do danych.
SimpleShop.API: Prezentacja i kontrolery.

Wymagania
.NET 8 SDK
Visual Studio 2022
SQL Server
Konfiguracja
Plik konfiguracyjny appsettings.json
Upewnij się, że plik appsettings.json jest poprawnie skonfigurowany:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SimpleShop;Trusted_Connection=True;TrustServerCertificate=true;"
  },
  "Jwt": {
    "Key": "NaTymEtapieNieTrzebaRobicJakichsTurboSecureKey",
    "Issuer": "SimpleShop",
    "Audience": "SimpleShop_Clients"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Instalacja Paczek NuGet
Upewnij się, że wszystkie wymagane paczki NuGet są zainstalowane w odpowiednich projektach:

SimpleShop.Core
SimpleShop.Application
SimpleShop.Infrastructure
SimpleShop.API

Wykonaj migracje bazy danych:

Wybierz startup project jako Simpleshop.API
W Package menager console wybierz SimpleShop.Infrastructure

W konsoli wpisz polecenia add-migration init
a nastepnie update-database

Uruchomienie Projektu
Otwórz rozwiązanie w Visual Studio 2022.
Ustaw projekt SimpleShop.API jako projekt startowy.
Uruchom aplikację (F5 lub Ctrl+F5).
Aplikacja będzie dostępna pod adresem https://localhost:7100 (dla HTTPS) lub http://localhost:5103 (dla HTTP).

Użytkownicy i Role
Seeder
Projekt zawiera seeder, który dodaje domyślnych użytkowników oraz role do bazy danych.

Domyślni użytkownicy:

Admin
Username: admin
Password: admin123
Role: Admin

User
Username: user
Password: user123
Role: User

Logowanie
Otwórz narzędzie Postman lub dowolne inne narzędzie do testowania API.
Wykonaj żądanie POST na endpoint https://localhost:7100/api/auth/login z ciałem:

{
  "username": "user",
  "password": "user123"
}
lub


{
  "username": "admin",
  "password": "admin123"
}

Otrzymasz token JWT w odpowiedzi. Skopiuj token.

Używanie Tokena JWT
Użyj wygenerowanego tokena JWT do autoryzacji żądań do zabezpieczonych endpointów.
Dodaj nagłówek Authorization z wartością Bearer {twój_token} do każdego żądania.
Przykład żądania GET do endpointu /api/Orders z użyciem tokena:

curl -X 'GET' \
  'https://localhost:7100/api/Orders' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer {twój_token}'
  
Endpointy API
AuthController
POST /api/auth/login: Logowanie użytkownika. Wymaga podania username i password. Zwraca token JWT.
OrdersController
GET /api/Orders: Pobiera wszystkie zamówienia. Wymaga autoryzacji (role: User, Admin).
UsersController
GET /api/Users: Pobiera wszystkich użytkowników. Wymaga autoryzacji (role: Admin).
ProductsController
GET /api/Products: Pobiera wszystkie produkty. Wymaga autoryzacji (role: User, Admin).
RoleController
GET /api/Roles: Pobiera wszystkie role. Wymaga autoryzacji (role: Admin).
