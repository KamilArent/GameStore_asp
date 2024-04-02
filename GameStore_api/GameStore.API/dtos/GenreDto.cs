using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace GameStore.API.dtos;

public record class GenreDto(
    int Id,
    string Name
    );