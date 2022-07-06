# Fresh statt Trash

Diplomarbeitsprojekt von **Maximilian Winkler** und **Fabian Volgger**
Webanwendung in *.NET*


Weiterführung durch **Jenewein Patrick** (Schuljahr 2022):
--> Rezepte können über ein Form hinzugefügt werden; die Daten werden in die Datenbank gespeichert:
    |-> die Form schickt an den Kontroller das Rezept, das dann in die Datenbank gespeichert wird

--> Rezepte werden auf einer Seite (Edit-Recipe) ausgelesen und können dann gelöscht oder bearbeitet werden
   |-> alle Rezepte werden ausgelesen und in Tabellenform dargestellt. Dann wird bei Delete die id an eine Methode im Kontroller übergeben, die das Rezept löscht.
   |-> Beim Update wird eine Methode aufgerufen, die das Rezept mit allen Attributen darstellt. Update funktioniert genau gleich wie INSERT.
   |-> soll noch mehr von den Rezepten angepasst werden muss nur das Form erweitert und die UPDATE-Methode ausgebaut werden.

--> Die Rezepte werden aus der Datenbank ausgelesen und nach Countries angezeigt.
   |-> Beim Klick auf eine Flagge wird eine Methode mit der ID vom Country aufgerufen, die alle Rezepte aus dem Country returnt.

--> Es können auch alle Rezepte ausgelesen werden und nach einem Filter sortiert werden:
   |-> Der Filter funktioniert genau gleich wie eine Form, das mit einer List<Recipes> kombiniert wird
   |-> Der Filter sind Attribute im Form, die gesetz werden
   |-> In der Methode wird ein Model mit einer List<Recipes> übergeben
   



 
