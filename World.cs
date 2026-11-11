/* World class for modeling the entire in-game world
 */

class World {
  Room entry;
  
  public World () {
    // The second value is the message shown when the player enters.
    Room entry    = new Room("Entry", "placeholder message");
    Room hubroom = new Room("Beredsskabsrum", "placeholder message");
    Room office = new Room("Kontor", "placeholder message");
    Room controlroom = new Room("Kontrolrum", "placeholder message");
    Room soproom = new Room("Personalerum", "placeholder message");
    Room lockerroom = new Room("Omklædningsrum", "placeholder message");
    Room labroom = new Room("Laboratoriet", "placeholder message");
    Room situationroom = new Room("SituationrumPlaceholder", "placeholder message");
    Room quizroom = new Room("QuizrumPlaceholder", "placeholder message");
    Room corridorwest = new Room("Gang mod vest", "placeholder message");
    Room corridornorth = new Room("Gang mod nord", "placeholder message");
    Room exitroom = new Room("ExitrumPlaceholder", "placeholder message");

    // Place the items in the rooms where the player can find them.
    entry.AddItem(new Item("1", "Personalekort", "Bruges til at låse bestemte døre op", "Nøglekort", false));
    soproom.AddItem(new Item("2", "SOP", "Indeholder sikkerhedsprocedurer og låser minimappet op", "Dokument", true));
    labroom.AddItem(new Item("3", "Øjenskyl", "Bruges i en situation, hvor spilleren har fået kemikalier i øjnene", "Medicin", true));
    hubroom.AddItem(new Item("4", "Evakueringsplan", "Kan læses for at få information om evakuering", "Dokument", false));

    //left side of the map
    entry.AddEdge("door", corridorwest);
    corridorwest.AddEdge("west", entry);
    corridorwest.AddEdge("east", hubroom);

    //middle of the map
    hubroom.AddEdge("west", corridorwest);
    hubroom.AddEdge("south", office);
    hubroom.AddEdge("north", corridornorth);
    hubroom.AddEdge("east", situationroom);

    //bottom half of the map
    office.AddEdge("north", hubroom);
    office.AddEdge("south", controlroom);
    controlroom.AddEdge("south", soproom);
    controlroom.AddEdge("north", office);
    soproom.AddEdge("east", lockerroom);
    soproom.AddEdge("north", controlroom);
    lockerroom.AddEdge("west", soproom);

    //right side of the map
    situationroom.AddEdge("west", hubroom);
    situationroom.AddEdge("east", quizroom);
    quizroom.AddEdge("west", situationroom);
    quizroom.AddEdge("east", exitroom);

    //top half of the map
    corridornorth.AddEdge("south", hubroom);
    corridornorth.AddEdge("north", labroom);
    labroom.AddEdge("south", corridornorth);
    labroom.IsLocked = true;
    

    
    
    this.entry = entry;
  }
  
  public Room GetEntry () {
    return entry;
  }
}
