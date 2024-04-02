using GameStore.API.Data;
using GameStore.API.dtos;
using GameStore.API.Entities;

namespace GameStore.API.Mapping;
public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}