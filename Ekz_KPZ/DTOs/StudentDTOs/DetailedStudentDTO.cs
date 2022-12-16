using DTOs.BaseDTOs;
using DTOs.UniTaskDTOs;

namespace DTOs.StudentDTOs
{
    public class DetailedStudentDTO : BaseIdDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<UniTaskDTO> UniTasks { get; set; }

    }
}
