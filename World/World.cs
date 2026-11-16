/* World class for modeling the entire in-game world
 */

class World {
  Room entry;


  public World()
  {
      // Rumbeskrivelser
      Room reception = new Room("Reception",
          "Du står i receptionen. Alarmen lyder, og området er forladt. " +
          "På skranken ligger papirer og forskellige efterladte genstande. " +
          "Måske er der noget brugbart, hvis du søger i området.");
  
      Room teknikrum = new Room("Teknikrum",
          "Du træder ind i teknikrummet. Maskinerne summer, og advarselslamper blinker. " +
          "Værktøj og teknisk udstyr ligger spredt omkring. " +
          "Det kunne være værd at undersøge rummet nærmere.");
  
      Room mellemgang = new Room("Mellemgang",
          "Du befinder dig i en smal mellemgang. Nødlyset blinker, " +
          "og du kan høre alarmen i det fjerne. " +
          "Langs væggene står enkelte skabe, som måske gemmer på noget.");
  
      Room kontrolrum = new Room("Kontrolrum",
          "Du træder ind i kontrolrummet. Flere skærme viser advarsler, " +
          "og der ligger dokumenter på arbejdsstationerne. " +
          "Måske kan du finde oplysninger, som hjælper dig videre.");
  
      Room gangmodvest = new Room("Gang mod Vest",
          "Du bevæger dig ned ad gangen mod vest. Luften føles varm, " +
          "og der lugter svagt af røg. Flere genstande ligger langs væggene. " +
          "Det kan være en god idé at se sig omkring.");
  
      Room faellesomraade = new Room("Fællesområde",
          "Du kommer ind i fællesområdet. Stole er væltet, og papirer ligger på gulvet. " +
          "På væggen hænger forskellige opslag om virksomhedens sikkerhedsprocedurer. " +
          "Måske findes der nyttige oplysninger her.");
  
      Room gangmodnord = new Room("Gang mod Nord",
          "Du træder ind i en lang gang mod nord. Nødlyset oplyser kun dele af området, " +
          "og flere døre fører videre gennem bygningen. " +
          "Du overvejer, om der er noget, du bør undersøge, inden du fortsætter.");
  
      Room laboratoriet = new Room("Laboratoriet",
          "Du træder forsigtigt ind i laboratoriet. Flere arbejdsstationer er forladte, " +
          "og advarselsskilte hænger på væggene. " +
          "Der står forskelligt sikkerhedsudstyr i lokalet, som måske kan blive nyttigt.");
  
      Room kemikalielager = new Room("Kemikalielager",
          "Du befinder dig i kemikalielageret. Store beholdere står på hylderne, " +
          "og en kraftig lugt får dig til at være ekstra opmærksom. " +
          "Du bør vurdere omgivelserne grundigt, før du foretager dig noget.");
  
      Room kontor = new Room("Kontor",
          "Du kommer ind på et forladt kontor. Computerskærmene lyser stadig, " +
          "og mapper ligger spredt over skrivebordene. " +
          "Måske er der noget vigtigt blandt de efterladte ting.");
  
      Room foerstehjaelp = new Room("Førstehjælpsrum",
          "Du træder ind i førstehjælpsrummet. Et grønt førstehjælpsskilt hænger på væggen, " +
          "og skabe med medicinsk udstyr står langs siderne. " +
          "Det virker som et oplagt sted at søge efter hjælpemidler.");
  
      Room kantine = new Room("Kantine",
          "Du befinder dig i kantinen. Maden står efterladt på bordene, " +
          "og medarbejderne ser ud til at være flygtet hurtigt. " +
          "På opslagstavlen hænger forskellige dokumenter, som måske er værd at undersøge.");
  
      Room depot = new Room("Depot",
          "Du træder ind i depotet. Hylderne er fyldt med kasser, værktøj og udstyr. " +
          "Noget af udstyret kan måske hjælpe dig gennem bygningen. " +
          "Det kunne være en god idé at søge her.");
  
      Room omklaedningsrum = new Room("Omklædningsrum",
          "Du kommer ind i omklædningsrummet. Flere skabe står åbne, " +
          "og arbejdstøj ligger spredt på bænkene. " +
          "Måske har nogen efterladt noget, som du kan få brug for.");
  
      Room udgang = new Room("Exit",
          "Du får øje på bygningens udgang. Den friske luft kan næsten mærkes, " +
          "men du skal stadig sikre dig, at du kan komme sikkert ud.");
  
      Room samlingspunkt = new Room("Samlingspunkt",
          "Du er nået frem til samlingsstedet uden for bygningen. " +
          "Andre medarbejdere er samlet her, mens beredskabet arbejder på at håndtere ulykken. " +
          "Du er nu i sikkerhed.");
  }


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
