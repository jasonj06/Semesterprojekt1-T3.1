/* World class for modeling the entire in-game world
 */

class World {
  Room entry;


  public World()
  {
      // Efter rummets navn kommer forkortelsen, kolonnen og rækken på kortet.
      Room reception = new Room("Reception", "RE", 0, 2,
          "Du står i receptionen. Alarmen lyder, og området er forladt. " +
          "På skranken ligger papirer og forskellige efterladte genstande. " +
          "Måske er der noget brugbart");

      Room teknikrum = new Room("Teknikrum", "TR", 3, 1,
          "Du træder ind i teknikrummet. Maskinerne summer, og advarselslamper blinker. " +
          "Værktøj og teknisk udstyr ligger spredt omkring dig. " +
          "Det kunne være værd at undersøge rummet nærmere.");

      Room mellemgang = new Room("Mellemgang", "MG", 1, 2,
          "Du befinder dig i en smal mellemgang. Nødlyset blinker, " +
          "og du kan høre alarmen i det fjerne. " +
          "Langs væggene står enkelte skabe.");

      Room kontrolrum = new Room("Kontrolrum", "KR", 1, 1,
          "Du træder ind i kontrolrummet. Flere skærme viser advarsler, " +
          "og der ligger dokumenter på arbejdsstationerne. " +
          "Måske kan du finde oplysninger, som hjælper dig videre.");

      Room gangmodvest = new Room("Gang mod Vest", "GV", 1, 3,
          "Du bevæger dig ned ad gangen mod vest. Luften føles varm, " +
          "og der lugter svagt af røg." +
          "Det kan være en god idé at se sig omkring.");

      Room faellesomraade = new Room("Fællesområde", "FO", 2, 2,
          "Du kommer ind i fællesområdet. Stole er væltet, og papirer ligger på gulvet. " +
          "På væggen hænger forskellige opslag om virksomhedens sikkerhedsprocedurer. ");

      Room gangmodnord = new Room("Gang mod Nord", "GN", 2, 1,
          "Du træder ind i en lang gang mod nord. Nødlyset oplyser kun dele af området, " +
          "og flere døre fører videre gennem bygningen. ");

      Room laboratoriet = new Room("Laboratoriet", "LA", 2, 0,
          "Du træder forsigtigt ind i laboratoriet. Flere arbejdsstationer er forladte, " +
          "Der står forskelligt sikkerhedsudstyr i lokalet, som måske kan blive nyttigt senere.");

      Room kemikalielager = new Room("Kemikalielager", "KL", 0, 3,
          "Du befinder dig i kemikalielageret. Store beholdere står på hylderne, " +
          "og en kraftig lugt får dig til at være ekstra opmærksom. ");

      Room kontor = new Room("Kontor", "KO", 2, 3,
          "Du kommer ind på et forladt kontor. Computerskærmene lyser stadig, " +
          "og mapper ligger spredt over skrivebordene. ");

      Room foerstehjaelp = new Room("Førstehjælpsrum", "FH", 3, 3,
          "Du træder ind i førstehjælpsrummet. Et grønt førstehjælpsskilt hænger på væggen, " +
          "og skabe med medicinsk udstyr står langs siderne. ");

      Room kantine = new Room("Kantine", "KA", 4, 3,
          "Du befinder dig i kantinen." +
          "På opslagstavlen hænger forskellige dokumenter og billeder.");

      Room depot = new Room("Depot", "DE", 5, 3,
          "Du træder ind i depotet. Et lille mørkt rum med hylderne fyldt med kasser, værktøj og udstyr.");

      Room omklaedningsrum = new Room("Omklædningsrum", "OM", 4, 4,
          "Du kommer ind i omklædningsrummet. Flere skabe står åbne, " +
          "og arbejdstøj ligger spredt på bænkene. ");

      Room udgang = new Room("Exit", "EX", 2, 4,
          "Du får øje på bygningens udgang. Den friske luft kan næsten mærkes, " +
          "men du skal stadig sikre dig, at du kan komme sikkert ud.");

      Room samlingspunkt = new Room("Samlingspunkt", "SP", 2, 5,
          "Du er nået frem til samlingsstedet uden for bygningen. " +
          "Andre medarbejdere er samlet her, mens beredskabet arbejder på at håndtere ulykken. " +
          "Du er nu i sikkerhed. " +
          "Bereskabet vil stille dig nogle spørgsmål");

  // Place the items in the rooms where the player can find them.

  // Brandslukker - erstatter personalekort
  teknikrum.AddItem(new Item("1", "Brandslukker",
      "Bruges til at slukke en mindre brand, hvis det er sikkert",
      "Sikkerhedsudstyr", true));

  // SOP - beholdes
  kantine.AddItem(new Item("2", "SOP",
      "Indeholder sikkerhedsprocedurer og låser minimappet op",
      "Dokument", true));

  // Førstehjælpskasse - erstatter øjenskyl
  foerstehjaelp.AddItem(new Item("3", "Førstehjælpskasse",
      "Bruges til at behandle skader og forbrændinger",
      "Førstehjælp", true));

  // Evakueringsplan - beholdes
  faellesomraade.AddItem(new Item("4", "Evakueringsplan",
      "Kan læses for at få information om evakuering",
      "Dokument", false));

  // Brandøkse - nyt item
  depot.AddItem(new Item("5", "Brandøkse",
      "Bruges til at åbne bestemte blokerede passager",
      "Værktøj", false));


    //1. og 2. søjle/venstre af map
    reception.AddEdge("east", mellemgang);
    reception.AddEdge("south", kemikalielager);

    kemikalielager.AddEdge("north", reception);
    kemikalielager.AddEdge("east", gangmodvest);

    mellemgang.AddEdge("west", reception);
    mellemgang.AddEdge("north", kontrolrum);
    mellemgang.AddEdge("east", faellesomraade);
    mellemgang.AddEdge("south", gangmodvest);

    kontrolrum.AddEdge("south", mellemgang);
    kontrolrum.AddEdge("east", gangmodnord);

    gangmodvest.AddEdge("west", kemikalielager);
    gangmodvest.AddEdge("north", mellemgang);
    gangmodvest.AddEdge("east", kontor);

    //3. søjle midten af mappet
    laboratoriet.AddEdge("south", gangmodnord);
    laboratoriet.IsLocked = true;

    gangmodnord.AddEdge("north", laboratoriet);
    gangmodnord.AddEdge("west", kontrolrum);
    gangmodnord.AddEdge("east", teknikrum);
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

    teknikrum.AddEdge("west", gangmodnord);

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
