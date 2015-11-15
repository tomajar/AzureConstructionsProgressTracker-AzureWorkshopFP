# Projekt treningowy do warsztatu "Wykorzystanie usług Azure do budowania skalowalnych systemów" 

Warsztat dla: [Future Processing](https://www.future-processing.pl/)

Warsztat w wersji 7h

## Instrukcja

### Zadanie 1 - prosta aplikacja na Azure

- Stwórz dwie usługi: Azure Web App oraz Azure SQL Database.
- Stwórz fork tego repozytorium na własne konto GitHub.
- Uruchom aplikację z tego repozytorium, wykorzystując funkcję Continuous Deployment, usługi Web App.
- Skonfiguruj Web App, aby korzystała ze stworzonej SQL Database (nadpisz connection string w ustawieniach Web App).

Kryteria akceptacji:
- Potrafisz urochumić aplikację i dodać nowy projekt do systemu.

### Zadanie 2 - storage


``` git 
git checkout ex-2-start-storage 

```

- Załóż usługe Storage Account.
- Przy pomocy [Azure Storage Explorer](https://azurestorageexplorer.codeplex.com/) dodaj dowolny plik i pobrać go z portalu Azure.
- W repozytorium przełączyć się na branch: 
- Uzupełnij implentację klasy FilesStorageService, tak aby zapisywała ona pliki w Azure Storage i zwracała adres nowego bloba (skorzystaj z podpowiedzi w kodzie)

Kryteria akceptacji:
- Potrafisz dodać nowy wpis ze zdjęciem do dziennika projektu oraz wyświetlić to zdjęcie na liście wpisów.

### Zadanie 3 - przetwarzanie w tle

``` git 
git checkout ex-3-start-background-processing

```
Część pierwsza

- Stwórz usługę Service Bus Namespace
- Zaimplementuj komunikację pomiędzy Web App a Web Job przy pomocy Service Bus. 
	- Uzupełnij implementację w miejscach wskazanych komentarzem "TODO ex3:"
    - Uzupełnij brakujące wartości w konfiguracji
- Przy pracy nad tym zadaniem przydatne może się okazać kożystanie z Web Job Dashboard. Ponizszy artykuł pokazuje jak go uruchomić:
    - http://blogs.msdn.com/b/jmstall/archive/2014/01/27/getting-a-dashboard-for-local-development-with-the-webjobs-sdk.aspx
    - Aktualizacja do artykułu: zamiast klucza "AzureJobsRuntime", należy odpowiednio ustawić "AzureWebJobsDashboard" i "AzureWebJobsStorage".
    
Kryteria akceptacji:
- Zdjecia dodawane przez aplikację, są zmniejszane przez Web Job i na liście wpisów wyświetlane są ich miniatury.

Część druga:
- Skonfiguruj aplikację konsolową PictureOptimizer aby została automatycznie wgrana jako Web Job

Pełne rozwiązanie:
``` git 
git checkout ex-3-extra-background-processing-as-web-job

```


### Zadanie 4 - application insights

- Skonfiguruj aplikację, aby wysyłała dane telemetryczne do usługi Application Insights

Pełne rozwiązanie:

``` git 
git checkout ex-4-finish-application-insights

```