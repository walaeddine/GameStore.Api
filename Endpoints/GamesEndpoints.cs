using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;
using Microsoft.VisualBasic;

namespace GameStore.Api.Endpoints;
public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("games/").WithParameterValidation();

        group.MapGet("/", async (IGameRepository repository) =>
        {
            var games = await repository.GetAllAsync();
            return games.Select(g => g.AsDto());
        });

        group.MapGet("/{id}", async (IGameRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();

        }).WithName(GetGameEndPointName);

        group.MapPost("/", (IGameRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };

            repository.CreateAsync(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game.AsDto());
        });

        group.MapPut("/{id}", async (IGameRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = await repository.GetAsync(id);

            if (existingGame is null)
                return Results.NotFound();

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            await repository.UpdateAsync(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IGameRepository repository, int id) =>
        {
            Game? existingGame = await repository.GetAsync(id);
            if (existingGame is null)
                return Results.BadRequest($"Game with id {id} does not exist in the database");

            await repository.DeleteAsync(id);
            return Results.NoContent();
        });

        return group;

    }
}