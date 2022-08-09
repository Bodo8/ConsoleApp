ConsoleApp48

Jeżeli aplikacja może się rozbudowywać w przyszłości dodałbym do projektu drugi projekt ConsoleApp.Library w którym będzie główna domena aplikacji zastosował mechanizm DependencyInjection. Jednym z lepszych i sprawdzonych pakietów nuget do wygodnego DI  jest pakiet Ninject. 
Dobrze by było dodać jeszcze Project z unit testami: ConsoleApp.Library.Tests.Unit
w którym będzie można na bieżąco tworzyć testy i na ich podstawie klasy i metody z zgodnie z TDD.
Teraz dobrze by było podzielić klasę DataReader na mniejsze klasy zgodnie z zasadą „Single responsybility”.
 Osobno można zrobić klasę odczytującą plik csv:  CsvProcessor implementującą interface IsourceProcessor. Lepszą praktyką jest wstrzykiwanie do klas ogólnych typów jak na przykład interfejs zgodnie z zasadą Dependency inversion, kod jest wtedy bardziej elastyczny, łatwiejszy do rozbudowy i utrzymania.  CsvProcessor użyje popularnego pakietu nuget CsvHelper dzięki niemu łątwiejsze będzie ujednolicenie danych z pliku csv, dzięki użyciu klasy mapującej: CsvImportedObjectMap i Converterów dla większości pól. 
Można dodać klasę MainClass która będzie miała publiczną metodę RunApp sterującą kolejnością działań i wywołującą na koniec prywatną metodę ShowResult().
Przygotowanie danych do wyświetlenia zajmie się klasa ImportedObjectService implementująca interface  IImportedObjectService.
Jeśli chodzi op  ImportedObject i ImportedObjectBaseClass nie widać tutaj potrzeby podziału na klasę nadrzędna i dziedziczącą. Lepszym wyjściem będzie będzie użycie jednej klasy np.  ImportedObject z wszystkimi polami z publicznymi getterami i setterami w katalogu Models. Z kodu nie dokońca widać potrzebę istnienia pola NumberOfChildren ponieważ ilość dzieci baz i tabel można określić z ilości elementów w słownikach i listach.
Plik z danymi data.csv lepiej przenieść do osobnego katalogu assets.
