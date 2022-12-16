

namespace DTOs.StudentDTOs
{
    public class CreateStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<StudentTasksDTO> StudentTasksDTOs { get; set; }

    }
}
