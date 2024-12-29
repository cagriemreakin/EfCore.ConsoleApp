using Bogus;
using EFCore.Demo.Infra.Entities;
using EFCore.Demo.Infra.Entities.Base;

namespace EFCore.Demo.Infra.DataGenerators;

public abstract class DataGenerator
{
    public static List<MovieEntity> GenerateMovieEntities(int count)
    {
        var locale = "tr";
        var genreFaker = GenreFaker(locale);
        var directorFaker = DirectorFaker(locale);
        var actorFaker = ActorFaker(locale);

        var genres = genreFaker.Generate(5);
        var directors = directorFaker.Generate(5);
        var actors = actorFaker.Generate(20);

        var movieFaker = new Faker<MovieEntity>(locale)
            .RuleFor(a => a.Id, f => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, f => f.Date.Past(5))
            .RuleFor(a => a.ModifiedDate, f => f.Date.Past(2))
            .RuleFor(a => a.Name, f => f.Lorem.Sentence(3))
            .RuleFor(a => a.DirectorId, f => f.PickRandom(directors).Id)
            .RuleFor(a => a.GenreId, f => f.PickRandom(genres).Id)
            .RuleFor(a => a.Director, f => f.PickRandom(directors))
            .RuleFor(a => a.Genre, f => f.PickRandom(genres))
            .RuleFor(a => a.Actors, f => f.PickRandom(actors, f.Random.Int(2, 5)).ToArray());

        return movieFaker.Generate(count);
    }

    private static Faker<ActorEntity> ActorFaker(string locale)
    {
        var actorFaker = new Faker<ActorEntity>(locale)
            .RuleFor(a => a.Id, f => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, f => f.Date.Past(5))
            .RuleFor(a => a.ModifiedDate, f => f.Date.Past(2))
            .RuleFor(a => a.FirstName, f => f.Name.FirstName())
            .RuleFor(a => a.LastName, f => f.Name.LastName())
            .RuleFor(a => a.Movies, f => []);
        return actorFaker;
    }

    private static Faker<DirectorEntity> DirectorFaker(string locale)
    {
        var directorFaker = new Faker<DirectorEntity>(locale)
            .RuleFor(d => d.Id, f => Guid.NewGuid())
            .RuleFor(d => d.CreatedDate, f => f.Date.Past(5))
            .RuleFor(d => d.ModifiedDate, f => f.Date.Past(2))
            .RuleFor(d => d.FirstName, f => f.Name.FirstName())
            .RuleFor(d => d.LastName, f => f.Name.LastName());
        return directorFaker;
    }

    private static Faker<GenreEntity> GenreFaker(string locale)
    {
        var genreFaker = new Faker<GenreEntity>(locale)
            .RuleFor(g => g.Id, f => Guid.NewGuid())
            .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
            .RuleFor(g => g.ModifiedDate, f => f.Date.Past(2))
            .RuleFor(g => g.Name, f => f.Commerce.Categories(1).First());
        return genreFaker;
    }
}