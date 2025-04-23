using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }
        public int ExpectedDays { get; set; }
    }
}
