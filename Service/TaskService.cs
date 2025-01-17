using AutoMapper;
using GestionDeTareasApi.Context;
using GestionDeTareasApi.DTos;
using GestionDeTareasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareasApi.Service
{
    public class TaskService : ITaskService
    {
        private readonly GestionDeTareasContext _context;
        private readonly IMapper _mapper;
        public TaskService(GestionDeTareasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaskDtos> CreateAsync(CreateTaskDtos taskDto, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            if (task != null)
            {
               await _context.Set<TaskItem>().AddAsync(task, cancellationToken); 
               await _context.SaveChangesAsync(cancellationToken);
               
               return _mapper.Map<TaskDtos>(task); 
            }

            return null;
        }

        public async Task<TaskDtos> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var taskItem = await _context.Set<TaskItem>().FindAsync(id);
            if (taskItem != null)
            {
                _context.Set<TaskItem>().Remove(taskItem);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null;
        }

        public async Task<IEnumerable<TaskDtos>> FilterByStatus(Status status, CancellationToken cancellationToken)
        {
            var query = _context.Set<TaskItem>()
                        .Where(t => t.Status == status);

            var queryList = await query.ToListAsync(cancellationToken); 

            return _mapper.Map<IEnumerable<TaskDtos>>(queryList);
        }

        public async Task<IEnumerable<TaskDtos>> GetlAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<TaskItem> taskItemsList = await _context.Set<TaskItem>().ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TaskDtos>>(taskItemsList);
        }

        public async Task<TaskDtos> UpdateAsync(Guid id, UpdateTaskDtos updateTaskDtos, CancellationToken cancellationToken)
        {
            var task = await _context.Set<TaskItem>().FindAsync(id);
            if (task is not null)
            {
                task = _mapper.Map<UpdateTaskDtos,TaskItem>(updateTaskDtos,task);
                _context.Set<TaskItem>().Attach(task);
                _context.Set<TaskItem>().Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<TaskDtos>(task);
            }

            return null;
        }
    }
}
