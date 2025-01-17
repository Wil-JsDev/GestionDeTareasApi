using GestionDeTareasApi.DTos;
using GestionDeTareasApi.Models;

namespace GestionDeTareasApi.Service
{
    public interface ITaskService
    {
        Task<TaskDtos> CreateAsync(CreateTaskDtos task, CancellationToken cancellationToken);

        Task<IEnumerable<TaskDtos>> GetlAllAsync(CancellationToken cancellationToken);

        Task<IEnumerable<TaskDtos>> FilterByStatus(Status status, CancellationToken cancellationToken);

        Task<TaskDtos> DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task<TaskDtos> UpdateAsync(Guid id, UpdateTaskDtos updateTaskDtos, CancellationToken cancellationToken);
    }
}
