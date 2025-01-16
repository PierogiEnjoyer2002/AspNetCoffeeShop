
1. Pobieranie projektu z GitHub

Rozpakuj folder .zip w dogodnym miejscu na dysku.
Kliknij Open a project or solution → wskaż plik .sln z wypakowanego folderu.

2. Instalacja i wymagania
.NET 7 lub nowszy (z Visual Studio 2022).
SQL Server Express lub LocalDB (do obsługi bazy).

3. Konfiguracja bazy danych (migracje)
W Visual Studio → Tools → NuGet Package Manager → Package Manager Console.
W polu Default Project (u góry okna PM Console) wybierz projekt główny (z .csproj).
Wpisz:
Update-Database
To zastosuje migracje z folderu Migrations i utworzy lokalną bazę danych CoffeeShopDB w LocalDB (lub inną wskazaną w ConnectionString).
Jeśli proces przebiegnie bez błędów, baza i tabele (AspNetUsers, AspNetRoles, Products, Orders itd.) będą gotowe.

4. Uruchamianie aplikacji
W Visual Studio naciśnij przycisk „Start”.
Otworzy się przeglądarka z adresem https://localhost.
Strona główna (Home/Index) powinna się wyświetlić na ekranie.

5. Konta testowe i role
W projekcie zdefiniowano następujące testowe konta:

Admin
Email / Login: admin@coffee.pl
Hasło: Admin123!
Posiada rolę Admin.
Zwykły użytkownik
Email / Login: user@coffee.pl
Hasło: User123!
Posiada rolę User.

6. Dostępna funkcjonalność
Admin: przegląd produktów, dodawanie do koszyka, składanie zamówień, edycja kategorii, przegląd zamówień.
User: przegląd produktów, dodawanie do koszyka, składanie zamówień.
