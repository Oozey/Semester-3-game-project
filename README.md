# Semester-3-game-project
Semester 3 Unity Arduino school project
Welkom bij de Git van mijn Unity / Arduino Game project.
Hier lees je alles wat je nodig hebt om de code te begrijpen en om de code te laten werken met de Arduino
Benodigdheden :
-Up to date versie van Unity
-Arduino UNO R3 of een nieuwere versie
-1 Breadboard
-4 Jumperwire Male-Male
-2 buttons (knoppen)

Unity Objecten:
De verschillende objecten bestaan uit:
-De camera (Het beeld wat je ziet)
-Sphere (De speler)
-Directional Light (standaard licht)
-De baan (Alle objecten waar de baan uit bestaat)
-Obstakels (Alle obstakels op de baan)
-GM Script (Game Master script die ervoor zorgt dat sommige objecten goed zijn verbonden met de Unity Code)

Unity Code:
-CameraMovement(De code die ervoor zorgt dat de camera bij de sphere(De speler) blijft)
-GM (De code die verbonden is met het object GM Script, Deze code zorgt ervoor dat je de baan kan genereren)
-moveplayer (Hier staat de connectie in van de Arduino naar Unity, deze code zorgt er ook voor dat de speler zich kan bewegen van links naar rechts)
-stats (Stats is een klein stukje code waarin de tijd wordt bijgehouden en de 'runstatus' dus of je bent gecrashed of niet)

Arduino Code:
De Arduino code laat de 2 knoppen uitlezen en laat het ook uitschrijven.
