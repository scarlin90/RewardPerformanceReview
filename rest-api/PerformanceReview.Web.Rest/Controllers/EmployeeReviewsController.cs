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
    [Route("api/employees/{employeeId}/employeereviews")]
    public class EmployeeReviewsController : Controller
    {
        private IPerformanceReviewRepository PerformanceReviewRepository { get; set; }

        public EmployeeReviewsController(IPerformanceReviewRepository performanceReviewRepository)
        {
            PerformanceReviewRepository = performanceReviewRepository;
        }

        // GET api/values
        [HttpGet()]
        public IActionResult GetEmployeeReviewsForEmployee(int employeeId)
        {

            if (!PerformanceReviewRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employeeReviewsForEmployeeFromRepo = PerformanceReviewRepository.GetEmployeeReviewsForEmployee(employeeId);

            var employeeReviewsForEmployee = Mapper.Map<IEnumerable<EmployeeReviewDto>>(employeeReviewsForEmployeeFromRepo);

            return Ok(employeeReviewsForEmployee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeReviewForEmployee(int employeeId, int id)
        {
            if (!PerformanceReviewRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employeeReviewForEmployeeFromRepo = PerformanceReviewRepository.GetEmployeeReviewForEmployee(employeeId, id);

            if(employeeReviewForEmployeeFromRepo == null)
            {
                return NotFound();
            }

            var employeeReviewForEmployee = Mapper.Map<EmployeeReviewDto>(employeeReviewForEmployeeFromRepo);
            return Ok(employeeReviewForEmployee);

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
