create database dipl_database;
use dipl_database;


create table recipes(
id int not null auto_increment,
recipename varchar(100),
calories int not null,
vegan boolean default false, 
vegetarian boolean default false, 
duration int not null, 
occasion tinyint null, 
regional boolean default false,
origin tinyint null,
instruction varchar(10000),
ingredients varchar(1000),
dateadded date,

constraint id_PK primary key(id)
)engine=InnoDB;
 
 create table users(
 userId int not null auto_increment,
 firstname varchar(100) not null,
 lastname varchar(100) not null,
 age int not null,
 gender tinyint null,
 birthdate date not null,
 email varchar(100) not null,
 passwrd varchar(100) not null,
 username varchar(100) not null,
isAdmin boolean default false,
 
 constraint userId_PK primary key(userId)
 )engine=InnoDB;
 
insert into users values(null, "Admin", "User", 18, null, date("2000-12-09"), "albert.greinoecker@htlinn.ac.at", sha1("rUdebOys!2020"),"albert", true);


insert into recipes values(null, "Zucchiniaufstrich", 281,  false, true, 20, null, false, null, "Die Zubereitung dauert insgesamt 20 Minuten 
und sollte für dich machbar sein; Zuerst wäschst du die Zucchinis und schneidest ihre beiden Enden ab; Wenn du keinen allzu bitteren 
Geschmack von den Zucchini bevorzugst, dann solltest du die Zucchinis schälen, bevor du zum nächsten Schritt übergehst; Danach 
reibst du das zubereitete Gemüse mit einer Käsereibe und gibst es in eine Schüssel. Als Nächstes schneidest du den gewaschenen 
Schnittlauch in Röllchen und gibst sie auch in die Schüssel; Nachdem du die Zwiebel geschält hast, hackst du sie in feine Stücke und 
vermischst sie gemeinsam mit Frischkäse und der Zucchini-Zwiebel-Masse zu einem cremigen Aufstrich; Zu guter Letzt fügst du dem 
Aufstrich eine Prise Paprikapulver und einen halben Teelöffel Salz hinzu, mischst erneut und lässt die Mischung für eine Stunde im Kühlschrank stehen; 
Der Aufstrich lässt sich auch nach deinem Belieben scharf würzen. Dafür ersetzt du das Paprikapulver gegen die scharfe Variante;Wir hoffen, 
dass dieses Rezept bei dir gut ankommt und die Zucchinis ihre gesunde Wirkung entfalten können!", "200g, Zucchini; Eine kleine, Zwiebel;
75g, Frischkäse; 75g, Magertopfen; Einen Bund, Schnittlauch; Paprikapulver; Salz;", date("2020-06-01"));

insert into recipes values(null, "Zucchini Fries", 692,  false, true, 30, null, false, null, "Heize zuerst den Ofen auf 220°C vor; Schneide dann die 
Zucchini in kleine Streifen(Frie´s); Dann nimmst du dir eine große Schüssel und gibst das Paniermehl, den 
Parmesan, das Knoblauchpulver, das Salz und den Pfeffer hinein; Schlage dann 
die Eier auf und gib sie in eine flache Schale; Dann nimmst du die Zucchinistreifen 
und umhüllst sie gut mit den Eiern, bevor du sie in den Paniermix dippst; Lege die 
Zucchini auf ein Backblech und backe sie für 15-20 Minuten; In der Zwischenzeit 
kannst du dir einen leckeren Joghurtdip dazu anrühren;
","400g, Zucchini; 50g, Tasse Paniermehl; 40g, Tasse Parmesan;1 Löffel, Knoblauchpulver;1 Löffel, getrocknetes Basilikum;1 Teelöffel, Salz;1 Teelöffel, Pfeffer; 
1, Eier;250g, fettarmes Joghurt;1 Löffel, Zitronensaft;2 Bund, frischen Schnittlauch;Ein bisschen, Salz; Ein bisschen, Pfeffer;", date("2020-06-01"));

insert into recipes values(null, "Veganer Kaiserschmarrn", 360,  true, true, 20, null, true, 0, "Zuerst verrührst du die Sojamilch und das Sojamehl 
gut in einer Schüssel und gibst danach den braunen Zucker, Mehl, das Backpulver und die Rosinen hinzu;Gib in eine beschichtete Pfanne etwas 
Rapsöl hinein und lasse sie heiß werden.;Sobald du mit dem Eingießen des Teigs beginnst, reduziere die Hitze leicht, damit die Unterseite des
 Kaiserschmarrns in der Pfanne nicht anbrennt.;Achte darauf, dass der aufgegossene Teig gleichmäßig liegt, sonst wird der Kaiserschmarrn 
 danach zur Hälfte ungenießbar sein.;Warte, bis seine Oberfläche nur noch ganz wenig flüssig ist und der Rand des Teigs durchgebacken 
 aussieht.;Danach wendest du den Teig, so dass die Oberfläche auf den Pfannenboden liegt, zerteilst ihn vorsichtig mit einer Gabel und fügst 
 noch einmal etwas Öl hinzu.;Jetzt noch kurz fertigbacken und danach ist dein veganer Kaiserschmarren servierbereit.", "250ml, Sojadrink 
 (mit Calciumzusatz);
4 Esslöffel,Mehl (2 EL, Weizenmehl und 2 EL, Weizenvollkornmehl);1Esslöffel, Sojamehl;1Teelöffel, Backpulver;1 Esslöffel, Zucker;
Eine kleine Packung, Rosinen;Ein Schuss, Rapsöl;", date("2020-06-01"));

insert into recipes values(null, "Käsezigarren", 100,  false, true, 40, null, false, 8, "Kräuter hacken, Käse klein bröseln. Kräuter, 
Käse und Ei in eine Schüssel geben, pfeffern und gut vermischen.;Aus dem Yufka-Teig Rechtecke formen. Auf das untere Ende je ca. 
1 EL von der Kräuter-Käse-Mischung geben.;Dann den Teig links und rechts leicht über die Füllung schlagen, dass später nichts auslaufen 
kann und das Ganze zu einer Zigarrenform aufrollen.;Die Enden mit wassernassen Fingern verkleben. So verfahren, bis der Teig und/oder 
die Füllung aufgebraucht ist. Die fertigen Röllchen bei ca. 200°C in den Ofen geben und backen bis sie schön goldbraun geworden sind.;
Den Yufka-Teig vor und während der Verarbeitung mit einem feuchten Küchentuch abdecken, damit er nicht rissig wird. Gerissene Stellen 
lassen sich sonst mit Wasser wieder zuschmieren.;", "3 EL,Petersilie, gehackt;
 3 EL, Minze, gehackt;2 EL, Dill, gehackt;1 Pkg., (360 Gramm, in türkischen Läden), Teig (Yufka-Teig); 400 g, Feta-Käse, möglichst fettarm;
 1 Stk., Ei(er);Pfeffer;Salz;", date("2020-06-01"));
 
 insert into recipes values(null, "Käsezigaretten-Börek", 665,  false, true, 40, null, false, 8, "Den Backofen auf 180°C (Ober- und Unterhitze) vorheizen.;Kräuter hacken, Käse klein bröseln. Kräuter, Käse und Ei in eine Schüssel geben, pfeffern und
gut vermischen.;Aus dem Yufka-Teig Rechtecke formen. Auf das untere Ende je ca. 1 EL von
der Kräuter-Käse-Mischung geben.;Dann den Teig links und rechts leicht über die Füllung
schlagen, dass später nichts auslaufen kann und das Ganze zu einer Zigarrenform aufrollen.;Die Enden mit wassernassen Fingern verkleben. So verfahren, bis der Teig und / oder die
Füllung aufgebraucht ist. (Genug Öl in einer Pfanne erhitzen, dass die Röllchen darin
schwimmen. Die Röllchen in das sehr heiße Fett geben und knusprig braun frittieren.;
Als fettsparende Alternative zum Frittieren:; Milch, Joghurt, Ei, Rapsöl und Salz verquirlen. Die Käsezigaretten auf ein mit Backpapier
belegtes Backbleck legen und mit der Mischung bestreichen.;Wenn du möchtest kannst du die
Röllchen noch mit Sesam bestreuen. Dieser enthält hochwertige Fette, ist reich an
Ballaststoffen und sorgt so für ein längeres Sättigungsgefühl.;Anschließend auf der mittleren Schiene im Backofen ca. 20-30 min backen.
", "3 EL, Petersilie, gehackt;3 EL, Minze, gehackt;2 EL, Dill, gehackt;1 Pck., Teig (Yufka-Teig);400 g, Feta-Käse, möglichst fettarm;1, Ei;Pfeffer;(Öl zum Frittieren);
zum Bestreichen:1/8 l, Milch, fettreduziert;80 g, Joghurt, fettreduziert;1, Ei;1 EL, Rapsöl;1 Messerspitze, Salz bestreichen;zum Bestreuen:1 EL, Sesamsamen
", date("2020-06-01"));

insert into recipes values(null, "Tomaten-Mozzarella", 234,  false, true, 10, null, false, null, "Wasche zuerst den Rucola die Tomaten und die Frühlingszwiebel mit kaltem Wasser kurz ab.;
Danach verteilst du den Rucola auf einer Servierplatte mit höherem Rand.; Anschließend schneidest
du die Tomaten, den Mozzarella, die Jungzwiebel und die Knoblauchzehe auf und verteilst sie auf
dem Rucola.;
Salz, Pfeffer, Kräuter, Öl und den Balsamico-Essig zusammen mischen und auf der Platte verteilen.;
Zum Schluss kannst du noch die Parmesanspäne darüber geben, und fertig ist das 10 Minuten
Gericht.;Viel Spaß beim Nachkochen und guten Appetit!;
", "50g Bund Rucola;100g Tomaten;30g Frühlingszwiebel;1 Knoblauchzehe;1 EL (5g) Olivenöl;1 EL (5g) Balsamico-Essig;100g Packung Mozzarella;1 EL (10g) Parmesanspäne zum drüberstreuen;Salz, Pfeffer ;Kräuter (z.B.: Basilikum oder Oregano);
", date("2020-06-01"));

insert into recipes values(null, "Menemen", 524,  false, true, 30, null, false, null, "Zuerst wird die Zwiebel geschält und ganz fein geschnitten.; 
Auch die Paprika werden in kleine Würfel geschnitten, nachdem sie gewaschen und vom Kerngehäuse befreit wurden.;
Die Tomate wird mit einem Messer oder dem Schäler geschält und in Spalten geschnitten.; So kann man gut die Kerne 
entfernen und das restliche Fruchtfleisch klein schneiden.;
In einer Pfanne wird das Olivenöl erhitzt und die Zwiebeln darin angeschwitzt.; 
Sobald sie glasig sind, kommen die Paprika dazu und werden mit gebraten.;
Hitze reduzieren und die Tomate dazugeben.; Diese sollte so saftig sein, dass das 
Gemüse nun im eigenen Saft garziehen kann.; Ansonsten etwas Wasser oder Brühe dazugeben.;
Die Eier werden verquirlt (in einer Schüssel verrührt) und zum Stocken in die Pfanne gegeben, 
sobald die Flüssigkeit verkocht ist.; Mit Salz und Pfeffer gewürzt auf Fladenbrot anrichten.;
", "3 Stk, Paprikaschote; 1, Zwiebel; 2, Eier;1, Tomate; 1 EL, Olivenöl; 1 Prise, Salz; 1 Prise, Pfeffer; 1 scheibe, Fladenbrot;", date("2020-06-01"));

insert into recipes values(null, "Nudeln mit Thunfisch", 2683,  false, true, 40, null, true, null, "Du musst die Nudeln in Salzwasser al dente kochen, 
dann abgießen, und anschließend musst du die Nudeln in Rapsöl schwenken;Als nächstes musst du die Nudeln mit dem Thunfisch vermischen 
und mit Parmesan, Bergkäse und Mozzarella bestreuen und belegen;Zu guter Letzt musst du die Nudeln bei 220°C im vorgeheizten Backofen
 ca. 25 min. goldgelb überbacken. 
", "400g, Vollkornnudeln;1 EL, Rapsöl;1 EL, Salz; 1 Dosen, Thunfisch; 1 Kugel, Mozzarella; 150g, Bergkäse;4 EL, Parmesan gerieben;", date("2020-06-01"));

insert into recipes values(null, "Toast Hawaii", 206,  false, false, 20, null, true, null, "Als erstes ein kleiner Tipp wie du beim Aufräumen Zeit und Arbeit sparen kannst: Wenn du das
Toastbrot vorbereitest, kannst du das Backblech als deinen Arbeitsplatz verwenden, so musst du
danach nicht den Tisch beziehungsweise die Küche putzen!;Jetzt geht’s aber richtig los!;Auf das Toastbrot legst du eine Scheibe Käse, eine Scheibe Schinken und eine Scheibe Ananas und
das mehrmals, damit mehr Personen etwas davon haben, denn geteiltes Essen ist gutes Essen, oder
war es Freude? Auch egal, auf jeden Fall habe ich bei den Zutaten eventuell Pizzagewürz oder Kräuter
hingeschrieben, da man den Käse auch mit Kräutern bestreuen kann, um einen intensiveren
Geschmack zu bekommen.;Anschließend gibt man die Toasts auf ein vorbereitetes Backblech (wenn man es nicht schon als
Arbeitsfläche verwendet hat) und schiebt dieses dann für ca. 10 Minuten bei 180°C bei Ober- und
Unterhitze in das vorgeheizte Backrohr. Danach werden die leckeren Toasts herausgeben und
serviert.
", "10 Scheiben Vollkorn-Toastbrot;10 Scheiben Schinken in Bioqualität;10 Scheiben Gouda (Käsesorte variabel);Eine Ananas;Evtl. Pizzagewürz/Kräuter", date("2020-06-01"));

insert into recipes values(null, "Low-Carb Pizza", 801,  false, false, 30, null, true, null, "Am Anfang musst du in einer Schüssel 2 Eier verrühren. ;
Den Thunfisch abtropfen lassen, zu den Eiern geben und alles gut durchmischen.; Die Mischung auf ein Backblech mit Backpapier geben und rund formen.; 
Der Boden sollte ca. 0,5 cm dick sein.; Den Thunfischboden im vorgeheizten Backofen 10-15 min bei 180° backen.; Danach aus dem Ofen nehmen, 
mit Tomatensauce bestreichen und mit Salz, Pfeffer und Oregano würzen.;
Die Schinkenscheiben klein reißen und die Pizza damit belegen.; Mit Käse bestreuen das dritte Ei aufschlagen und auf die Pizza geben.;
Danach die Pizza wieder in den Ofen geben und ca. 20 Min backen, bis das Ei gar ist und der Käse eine schöne goldene Farbe hat.;
Die Pizza kann nach Geschmack natürlich auch anders belegt werden.; 
", "1 ½ Dosen, Thunfisch, im eigenen Saft;3, Eier;2 Scheiben, Kochschinken;80g, Käse, geriebener nach Belieben ;Salz und Pfeffer;
Oregano;20 g, Tomatensauce;", date("2020-06-01"));

insert into recipes values(null, "Wurstsalat", 1044,  false, false, 20, null, true, null, "Schäle den Knoblauch und die Zwiebel und schneide beides in möglichst kleine Würfel. ;
Gib die Würfel in eine Schüssel und verrühre sie mit Olivenöl.; 
Schneide den Leberkäse und den Käse in 3 cm lange Streifen. ;
Paprika waschen, entkernen und in ebenso große Stücke schneiden.; Das Ei hart kochen, auskühlen lassen und vierteilen.; 	 
Danach schütte alles, was du für das Dressing brauchst, in eine Schüssel und vermische es mit der Klobürste.; Nein Spaß mit dem Schneebesen.; Anschließend füllst du Deinen Wurstsalat in Gläser stellst ihn kalt.; 	 
Wenn du Leberkäse nicht magst oder gerade nicht zur Hand hast, kannst du auch eine andere Wurstsorte verwenden.; Hauptsache, das Produkt stammt aus artgerechter Tierhaltung.; 
Würziger Käse verleiht dem Wurstsalat einen besonderen Geschmack.;	 
Du kannst auch Cocktailtomaten und/oder Schnittlauch untermischen, oder, falls dir ein guter Mundgeruch wichtig ist, Zwiebel und Knoblauch dadurch ersetzen.; 
", "40 dag, Bio-Leberkäse,geschnitten;40 dag, Gouda;4, rote Paprika;4, gelbe Paprika;1/2, rote Zwiebel;4 ,Knoblauchzehen;4, hart gekochte Eier;	6 El, Apfelessig;4 EL, Olivenöl;Salz;Pfeffer; ", 
date("2020-06-22"));

insert into recipes values(null, "Carvings", 1,  true, true, 30, null, true, null, "Jeder kennt sie, die Kuchen Carvings. Das Verlangen nach etwas Süßem am Nachmittag. Du willst
wissen, wie du dir in weniger als 5 Minuten einen leckeren Kuchen zubereiten kannst? Ganz ohne
dreckige Rührschüssel und Backofen?
Wir zeigen es dir! Der Trend heißt Tassenkuchen! Was du dafür brauchst sind lediglich wenige
Zutaten und eine Mikrowelle. Diese findest du sicher in der Küche deines Büros oder in der Uni.;Das Kokosöl in eine hitzebeständige Tasse geben und für einige Sekunden in der Mikrowelle flüssig
werden lassen.;Etwas abkühlen.;Den Honig und das Ei dazugeben und gut verrühren,;nachdem verrühren Mehl, Kakao- und
Backpulver ebenfalls hinzufügen und alles solange vermengen, bis gerade so ein Teig entsteht.;Eine
Hälfte der Coconut Chips mit der Hand zerbröckeln und unterheben.;Den Tassenkuchen in der Mikrowelle bei 900 Watt für 1-1 ½ Minuten backen und zum Schluss mit
den restlichen Coconut Chips garnieren.;
", "1 TL,Bio-Kokosöl;2 TL,Honig (oder Agavendicksaft);1,Ei;2 EL,Dinkelvollkornmehl;1 EL,Kakaopulver, ungesüßt;1/3 TL,Backpulver;20 g,Coconut Chips; ", 
date("2020-06-22"));

insert into recipes values(null, "Cacik", 450,  false, true, 15, null, false, null, "Die Gurke schälen; der Länge nach durchschneiden und ganz fein in würfeln schneiden; Joghurt und Olivenöl cremig rühren; und die Gurkenwürfeln unter den Joghurt mischen;
dann den Knoblauch schälen; durch die Knoblauchpresse drücken; und in den Joghurt einrühren; Je nach Geschmack salzen; je nach gewünschter Konsistenz Wasser unterrühren;
Zum Schluss Dill und Pfefferminze einrühren; oder einfach über den Joghurt streuen;
", "500g,Joghurt;300g,Salatgurke;1Bund,Dill;1TL,getrocknete Pfefferminze;2,Knoblauchzehen;3EL,Olivenöl;Salz;Wasser;", 
date("2020-06-22"));
