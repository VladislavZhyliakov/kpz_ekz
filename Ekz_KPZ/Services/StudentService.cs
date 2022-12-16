using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using DTOs.StudentDTOs;
using Services.Interfaces;
using Domain;
using Domain.Enums;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Student> _repository;

        public StudentService(IMapper mapper, IGenericRepository<Student> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> CreateAsync(CreateStudentDTO model)
        {
            var newEntity = _mapper.Map<Student>(model);
            
            newEntity.StudentUniTasks = new List<StudentUniTask>();
            foreach(var s in model.StudentTasksDTOs)
            {
                newEntity.StudentUniTasks.Add(_mapper.Map<StudentUniTask>(s));
            }
            return await _repository.CreateAsync(newEntity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = (await _repository.GetByCondition(e => e.Id == id)).FirstOrDefault();

            if(entity is null)
            {
                throw new Exception("Student not found!");
            }

            await _repository.DeleteAsync(entity);
        }

        public async Task<List<T>> GetAllAsync<T>()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<List<T>>(entities.ToList());
        }

        public async Task UpdateAsync(UpdateStudentDTO dto)
        {
            var entity = (await _repository.GetByCondition(e => e.Id == dto.Id)).FirstOrDefault();

            if (entity is null)
            {
                throw new Exception("Student not found!");
            }

            _mapper.Map(dto, entity);
            
            await _repository.UpdateAsync(entity);
        }
    }
}
