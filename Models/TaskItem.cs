namespace GestionDeTareasApi.Models
{
    public sealed class TaskItem
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public DateOnly DuaDate { get; set; }

        public Status Status { get; set; }

        public int AdditionalData { get; set; }
    }
}
