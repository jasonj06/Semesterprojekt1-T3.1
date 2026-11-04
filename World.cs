/* World class for modeling the entire in-game world
 */

class World {
  Room entry;
  
  public World () {
    Room entry    = new Room("Entry");
    Room hubroom = new Room("Beredsskabsrum");
    Room office = new Room("Kontor");
    Room controlroom = new Room("Kontrolrum");
    Room soproom = new Room("Personalerum");
    Room lockerroom = new Room("Omklædsningrum");
    Room labroom = new Room("Laboratoriet");
    Room situationroom = new Room("SituationrumPlaceholder");   
    Room quizroom = new Room("QuizrumPlaceholder");
    Room corridorwest = new Room("Gang mod vest");
    Room corridornorth = new Room("Gang mod nord");
    Room exitroom = new Room("ExitrumPlaceholder");

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
    

    
    
    this.entry = entry;
  }
  
  public Room GetEntry () {
    return entry;
  }
}
