using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace one_do.Domain
{
    public class TaskItem
    {
        
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}