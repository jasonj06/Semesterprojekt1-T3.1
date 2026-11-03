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
    
    entry.AddEdge("door", corridorwest);
    corridorwest.AddEdge("door", hubroom);
    hubroom.AddEdge("south", office);
    hubroom.AddEdge("north", corridornorth);
    hubroom.AddEdge("east", situationroom);
    office.AddEdge("south", controlroom);
    controlroom.AddEdge("door", soproom);
    soproom.AddEdge("door", lockerroom);
    
    this.entry = entry;
  }
  
  public Room GetEntry () {
    return entry;
  }
}
