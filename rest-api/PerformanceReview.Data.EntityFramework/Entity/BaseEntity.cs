using System;

namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreTime = DateTime.Now;
            ModTime = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime CreTime { get; set; }

        public DateTime ModTime { get; set; }
    }
}
