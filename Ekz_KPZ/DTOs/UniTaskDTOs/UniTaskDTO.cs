using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UniTaskDTOs
{
    public class UniTaskDTO:BaseDTOs.BaseIdDTO
    {
        public string Description { get; set; }

        public DateOnly? TaskDate { get; set; }

        public string Priority { get; set; }

        public Status? Status { get; set; }

        public int? Grade { get; set; }
        public bool? IsPresent { get; set; }
    }
}
