

using DTOs.BaseDTOs;

namespace DTOs.StudentDTOs
{
    public class UpdateStudentDTO : BaseIdDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
