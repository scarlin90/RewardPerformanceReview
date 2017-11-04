using System;
namespace PerformanceReview.Web.Rest.Models
{
    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreTime { get; set; }

        public DateTime ModTime { get; set; }
    }
}
