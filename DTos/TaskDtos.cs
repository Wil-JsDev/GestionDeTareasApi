namespace GestionDeTareasApi.DTos
{
    public record TaskDtos
    (
    Guid Id,
    string Description,
    DateOnly DuaDate,
    Status Status,
    int AdditionalData
    );

}
