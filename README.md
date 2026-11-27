# Lernperiode-2

## Grobplanung

Einen Server Manager in z.B einem Spiel. In diesem Programm kann man einen Spielserver *simulieren und Informationen wie, wie viele spieler drauf sind, den status und statistiken von den Spielern. Ich will mit Textdateien die Informationen wie Server einstellung und Logs speichern und das Textdateien auch eingelesen werden können. 


## HA: 16.10
- [x] Server Manager Menü erstellen
- [x] Funktion die einen Server Start simuliert und auch beenden können

Heute habe ich ein Zahlen erraten spiel gemacht um zuschauen wo ich stehe, ich habe es dann geschafft. Dann habe ich ideen für mein Projekt gesucht und versucht etwas mit Text datei zu finden. Da bin ich dann zu dieser Idee gekommen.

## 23.10
- [x] Textdatei mit Visual Studio verbinden und den Text daraus liest.
- [x] Informationen in einer Textdatei speichern.
- [x] Eine Statistik die anzeigt, wie viele spieler drauf sind.

  ## HA:
- [X] Anzeigen wie überlastet der Server gerade ist.

Heute habe ich herausgefunden wie man Text Dateien mit C# verbindet und auch geschafft die Werte durch die Text Datei zu verändern.


## 30.10
<del>-- [ ] Einen Timer programmieren, der Anzeigt wie lange der Server Online ist.
<del>-- [ ] Möglichkeit Textdateien zu importieren
<del>-- [ ] In der ServerInfo.Txt Einstellungen wie Server name, maximal Spieler anzahl einstellen können
<del>- [ ] Einen Security-Passwort bevor man Zugang zum Server Manager bekommt</del>

Im Gespräch mit Herr Colic habe ich entschieden ein neues Projekt zu starten. Dieses neue Projekt wird ein Monster inspector, indem man verschiedene Monster zur Auswahl hat und jeder verschieden Stats hat, die in einer Textdatei gespeichert sind. 
- [x] Das erste Monster erstellen
- [x] Werte vom Monster aus einer Textdatei lesen und in der Console ausgeben

Heute habe ich ein neues Projekt gestartet, weil ich mein altes nicht so gut fande und es keinen richtigen nutzen hatte. Jetzt mache ich einen Monster-Inspector in den man Monster auswählen kann und ihre stats dann sieht, diese stats sind in einer textdatei gespeichert.


## 06.11
- [x] Die werte von der Textdatei spliten (werte nach "=")
- [x] Die werte dann in int wenn sie zahlen sind und in string wenn sie Wörter sind umwandeln um sie dann später zu nutzen.
- [x] Neues Monster hinzufügen
- [x] Das Neue Monster im gleichen schema wie beim letzten verschiedene Stats geben
- [x] Die Möglichkeit Textdateien dort zu importieren und so ein Monster mit den stats von der text datei anzeigen.

Heute habe ich gelernt wie man bestimmte texte splittet und sie dann in string oder int umwandelt. Dann habe ich noch ein neues Monster erstellt und alles in eine funktion gemacht, damit man nicht für jedes Monster eigene funktion braucht. Als letztes habe ich mit hilfe geschafft zu ermöglichen das so ein Windows datei screen kommt wo man dann seine datei importieren kann (in dem fall eine .txt) und falls man die txt nach der struktur geschrieben hat sollte sie richtig angezeigt werden.


## 13.11
- [x] Bei einer fehlerhaften Datei, eine fehlermeldung anzeigen anstatt abzustürzen (mit try und catch)
- [x] Die Möglichkeit wieder ins Hauptmenu zurück zukommen und es besser gestalten.
- [x] Neue Monster eigenschaften hinzufügen (wie Defense, Speed, usw.)
- [x] Maximale Powerlevel anhand der Stats berechnen und anschliessend eine Rarität geben.
      
HA:
- [x] Monstertyp bestimmen anhand der Statistiken

Heute habe ich als erstes eine If-funktion gemacht damit man nachdem man die Stats von einen Monster angeschaut hat wieder ins Menu kommt. Anschliessend habe ich mein code sauber gemacht und Menu bisschen verschönert. Dann habe ich neue Monster Eigenschaften hinzufügt aber diesmal es mit Case gemacht, was ich neu gelernt habe. Powerlevel wird berechnet anhand der Stats, manche stats bringen mehr und machen weniger. Mit Powerlevel konnte ich dann auch bestimmen welche Rarität ein Monster hat anhand der Powerlevel. Am ende habe ich noch geaddet das eine fehler Meldung kommt wenn man eine ungültige datei importiert.


## 20.11
- [x] Eine neue funktion bei der man ein eigenes Monster erstellen kann (name, alter, stärke, usw.)
- [x] Erstelles Monster als .txt datei speichern
- [x] Eine Monster libary bei der du alle Monster siehst die du erstellt hast
      
HA:
- [x] Bei der Libary die Monster anschauen also auch die Stats

In der Heutigen Sitzung habe ich die Funktion im Programm gemacht, dass man eigene Monster im Program drinne erstellen kann und sie auch als .txt Datei auf seinen PC speichern kann. Am ende habe ich noch eine Libary gemacht wo alle Monster die man erstellt hat drinne stehen, doch ich bin noch nicht sehr zufrieden und werde es noch überarbeiten.

## 27.11
- [x] Eine neue Funktion bei der man in ein Menu kommt wo die erstellen Monster steht und man 2 auswählen kann (sie werden dann grün)
- [ ] Wenn zwei gewählt wurden dann kann man Start machen und es werden beide gemessen.


HA:
- [ ] Dungeon mode, zuerst ein Menu bei den man seinen Maincharakter wählen kann
- [ ] Neue variablen speziell für dungeon mode (Gold, exp) und sie auch in ein Shop nutzen
