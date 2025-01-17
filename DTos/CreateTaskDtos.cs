namespace GestionDeTareasApi.DTos
{
    public record CreateTaskDtos
    (
        string DescriptionAboutTask,
        DateOnly DuaDate,
        Status StatusTask,
        int AdditionalData
    );

}
