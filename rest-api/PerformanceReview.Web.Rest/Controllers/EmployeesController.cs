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
            var employeeFromRepo = PerformanceReviewRepository.Get<Employee>(id);

            if(employeeFromRepo == null)
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
