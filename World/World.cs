/* World class for modeling the entire in-game world
 */

class World {
  Room entry;

  public World () {
    // The second value is the message shown when the player enters
    Room reception       = new Room("Reception", "placeholder message");
    Room teknikrum       = new Room("Teknikrum", "placeholder message");
    Room mellemgang      = new Room("Mellemgang", "placeholder message");
    Room kontrolrum      = new Room("Kontrolrum", "placeholder message");
    Room gangmodvest     = new Room("Gang mod Vest", "placeholder message");
    Room faellesomraade  = new Room("Fællesområde", "placeholder message");
    Room gangmodnord     = new Room("Gang mod Nord", "placeholder message");
    Room laboratoriet    = new Room("Laboratoriet", "placeholder message");
    Room kemikalielager  = new Room("Kemikalielager", "placeholder message");
    Room kontor          = new Room("Kontor", "placeholder message");
    Room foerstehjaelp   = new Room("Førstehjælpsrum", "placeholder message");
    Room kantine         = new Room("Kantine", "placeholder message");
    Room depot           = new Room("Depot", "placeholder message");
    Room omklaedningsrum = new Room("Omklædningsrum", "placeholder message");
    Room udgang        = new Room("Exit", "placeholder message");
    Room samlingspunkt   = new Room("Samlingspunkt", "placeholder message");

    // Place the items in the rooms where the player can find them.
    reception.AddItem(new Item("1", "Personalekort", "Bruges til at låse bestemte døre op", "Nøglekort", false));
    kantine.AddItem(new Item("2", "SOP", "Indeholder evakueringsplan og låser minimappet op", "Dokument", true));
    laboratoriet.AddItem(new Item("3", "Øjenskyl", "Bruges i en situation, hvor spilleren har fået kemikalier i øjnene", "Medicin", true));
    faellesomraade.AddItem(new Item("4", "Evakueringsplan", "Kan læses for at få information om evakuering", "Dokument", false));

    //1. og 2. søjle/venstre af map
    reception.AddEdge("east", mellemgang);
    reception.AddEdge("south", teknikrum);

    teknikrum.AddEdge("north", reception);
    teknikrum.AddEdge("east", gangmodvest);

    mellemgang.AddEdge("west", reception);
    mellemgang.AddEdge("north", kontrolrum);
    mellemgang.AddEdge("east", faellesomraade);
    mellemgang.AddEdge("south", gangmodvest);

    kontrolrum.AddEdge("south", mellemgang);
    kontrolrum.AddEdge("east", gangmodnord);

    gangmodvest.AddEdge("west", teknikrum);
    gangmodvest.AddEdge("north", mellemgang);
    gangmodvest.AddEdge("east", kontor);

    //3. søjle midten af mappet
    laboratoriet.AddEdge("south", gangmodnord);
    laboratoriet.IsLocked = true;

    gangmodnord.AddEdge("north", laboratoriet);
    gangmodnord.AddEdge("west", kontrolrum);
    gangmodnord.AddEdge("east", kemikalielager);
    gangmodnord.AddEdge("south", faellesomraade);

    faellesomraade.AddEdge("north", gangmodnord);
    faellesomraade.AddEdge("west", mellemgang);
    faellesomraade.AddEdge("south", kontor);

    kontor.AddEdge("north", faellesomraade);
    kontor.AddEdge("west", gangmodvest);
    kontor.AddEdge("east", foerstehjaelp);
    kontor.AddEdge("south", udgang);

    udgang.AddEdge("north", kontor);
    udgang.AddEdge("south", samlingspunkt);

    samlingspunkt.AddEdge("north", udgang);

    //højre side af mappet søjle 4,5 og 6

    kemikalielager.AddEdge("west", gangmodnord);

    foerstehjaelp.AddEdge("west", kontor);
    foerstehjaelp.AddEdge("east", kantine);

    kantine.AddEdge("west", foerstehjaelp);
    kantine.AddEdge("east", depot);
    kantine.AddEdge("south", omklaedningsrum);

    depot.AddEdge("west", kantine);

    omklaedningsrum.AddEdge("north", kantine);

    this.entry = reception; //sætter start rum
  }

  public Room GetEntry () {
    return entry;
  }
}
