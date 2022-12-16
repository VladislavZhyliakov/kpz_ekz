
namespace Domain.Entities
{
    public class StudentUniTask:BaseModel
    {
        public int? Grade { get; set; }
        public bool? IsPresent { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? UniTaskId { get; set; }
        public virtual UniTask UniTask { get; set; }
    }
}
