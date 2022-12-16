
using Domain.Enums;

namespace Domain.Entities
{
    public class UniTask:BaseModel
    {
        public string Description { get; set; }

        public DateOnly? TaskDate { get; set; }

        public string Priority { get; set; }

        public Status? Status { get; set; }

        public virtual List<StudentUniTask> StudentUniTasks { get; set; }

    }
}
