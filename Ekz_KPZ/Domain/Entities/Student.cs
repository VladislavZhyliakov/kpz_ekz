namespace Domain.Entities
{
    public class Student:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<StudentUniTask> StudentUniTasks { get; set; }

    }
}
