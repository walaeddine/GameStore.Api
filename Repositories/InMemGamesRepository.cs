namespace GameStore.Api.Repositories;
public class InMemGamesRepository
{
    private readonly List<Game> games = new()
    {
        new Game()
        {
        Id = 1,
        Name = "Street Fighter 2",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991, 2, 1),
        ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
        Id = 2,
        Name = "Final Fantasy 14",
        Genre = "Roleplaying",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010, 9, 30),
        ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
        Id = 3,
        Name = "Fifa 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022, 9, 27),
        ImageUri = "https://placehold.co/100"
        }
    };

    public IEnumerable<Game> GetAll() => games;
    public Game? Get(int id) => games.Find(g => g.Id.Equals(id));
    public void Create(Game game)
    {
        game.Id = games.Max(g => g.Id) + 1;
        games.Add(game);
    }
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(g => g.Id.Equals(updatedGame.Id));
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(g => g.Id.Equals(id));
        games.RemoveAt(index);
    }
}
