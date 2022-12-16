using DTOs.StudentDTOs;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<T>> GetAllAsync<T>();
        Task DeleteByIdAsync(int id);
        Task<int> CreateAsync(CreateStudentDTO model);
        Task UpdateAsync(UpdateStudentDTO model);
    }
}
