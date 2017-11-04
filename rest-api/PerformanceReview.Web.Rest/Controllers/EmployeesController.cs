using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerformanceReview.Data.EntityFramework.Entity;
using PerformanceReview.Data.EntityFramework.Repository;
using PerformanceReview.Web.Rest.Models;

namespace PerformanceReview.Web.Rest.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private IPerformanceReviewRepository PerformanceReviewRepository { get; set; }

        public EmployeesController(IPerformanceReviewRepository performanceReviewRepository)
        {
            PerformanceReviewRepository = performanceReviewRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var employeesFromRepo = PerformanceReviewRepository.GetAll<Employee>();
            var employees = Mapper.Map<IEnumerable<EmployeeDto>>(employeesFromRepo);

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            //// Cleardown
            //var employees = PerformanceReviewRepository.GetAll<Employee>().ToList();

            //foreach(var employee in employees)
            //{
            //    PerformanceReviewRepository.Delete(employee);
            //}

            //var performanceReviews = PerformanceReviewRepository.GetAll<Data.EntityFramework.Entity.PerformanceReview>().ToList();

            //foreach (var performanceReviewss in performanceReviews)
            //{
            //    PerformanceReviewRepository.Delete(performanceReviewss);
            //}

            //var employeeReviews = PerformanceReviewRepository.GetAll<EmployeeReview>().ToList();

            //foreach (var er in employeeReviews)
            //{
            //    PerformanceReviewRepository.Delete(er);
            //}

            //var feedbackList = PerformanceReviewRepository.GetAll<Feedback>().ToList();

            //foreach (var f in feedbackList)
            //{
            //    PerformanceReviewRepository.Delete(f);
            //}

            //var assignedReviewers = PerformanceReviewRepository.GetAll<AssignedReviewer>().ToList();

            //foreach (var assignedReviewerq in assignedReviewers)
            //{
            //    PerformanceReviewRepository.Delete(assignedReviewerq);
            //}

            //// Add Employee
            //var employeeInserted = new Employee { IsAdmin = true, Username = "admin", Password = "paswword" };
            //PerformanceReviewRepository.Insert(employeeInserted);

            //var performanceReview = new Data.EntityFramework.Entity.PerformanceReview { ReviewBody = "Body", };
            //PerformanceReviewRepository.Insert(performanceReview);

            //var employeeReview = new EmployeeReview { EmployeeId = employeeInserted.Id, PerformanceReviewId = performanceReview.Id};
            //PerformanceReviewRepository.Insert(employeeReview);

            //var feedback = new Feedback { PerformanceReviewId = performanceReview.Id, EmployeeId = employeeInserted.Id };
            //PerformanceReviewRepository.Insert(feedback);

            //var assignedReviewer = new AssignedReviewer { PerformanceReviewId = performanceReview.Id, EmployeeId = employeeInserted.Id };
            //PerformanceReviewRepository.Insert(assignedReviewer);

            var employeeFromRepo = PerformanceReviewRepository.Get<Employee>(id);

            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            var employee = Mapper.Map<EmployeeDto>(employeeFromRepo);

            return Ok(employee);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
