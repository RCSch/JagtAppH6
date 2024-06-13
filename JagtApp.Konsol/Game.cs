namespace JagtApp.Konsol
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public GameRequirements GameClass { get; set; }

        public Game(int gameId, string gameName, GameRequirements gameClass)
        {
            GameId = gameId;
            GameName = gameName;
            GameClass = gameClass;
        }
    }
}