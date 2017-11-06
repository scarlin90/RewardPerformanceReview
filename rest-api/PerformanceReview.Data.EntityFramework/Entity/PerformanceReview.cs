
using System.Collections.Generic;

namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class PerformanceReview : BaseEntity
    {
        public string ReviewBody { get; set; }

        public List<Feedback> Feedback { get; set; } 

    }
}
