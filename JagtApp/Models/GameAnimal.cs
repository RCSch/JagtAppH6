using JagtApp.Enums;

namespace JagtApp.Models
{
    public class GameAnimal //Klassen Game beskriver de enkelte vildtarter. I de tilfælde, hvor hanner og hunner har forskellige jagttider vil der være særskilte opslag for disse i databasen.
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public GameClass GameClass { get; set; }
        public List<HuntingSeason> HuntingSeasons { get; set; }

        public GameAnimal() { }

        public GameAnimal(int gameId, string gameName, GameClass gameClass)
        {
            Id = gameId;
            GameName = gameName;
            GameClass = gameClass;
            HuntingSeasons = new List<HuntingSeason>();
        }
    }
}
