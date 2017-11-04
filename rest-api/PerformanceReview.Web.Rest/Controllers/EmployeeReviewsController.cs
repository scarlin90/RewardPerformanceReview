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

        [HttpGet("{id}", Name = "GetEmployeeReview")]
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

        [HttpPost()]
        public IActionResult Post(int employeeId, [FromBody] CreateEmployeeReviewDto employeeReview)
        {
            if (employeeReview == null)
            {
                return BadRequest();
            }

            if (!PerformanceReviewRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }


            var employeeReviewEntity = Mapper.Map<EmployeeReview>(employeeReview);
            employeeReviewEntity.EmployeeId = employeeId;
            PerformanceReviewRepository.Insert(employeeReviewEntity);

            var newEmployeeReview = Mapper.Map<EmployeeReviewDto>(employeeReviewEntity);

            return CreatedAtRoute("GetEmployeeReview", new { id = newEmployeeReview.Id }, newEmployeeReview);

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
