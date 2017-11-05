using System;
using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employeesFromRepo = PerformanceReviewRepository.GetAll<Employee>();
            var employees = Mapper.Map<IEnumerable<EmployeeDto>>(employeesFromRepo);

            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult GetEmployeeById(int id)
        {
            var employeeFromRepo = PerformanceReviewRepository.Get<Employee>(id);

            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            var employee = Mapper.Map<EmployeeDto>(employeeFromRepo);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody]CreateEmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var employeeEntity = Mapper.Map<Employee>(employee);
            PerformanceReviewRepository.Insert(employeeEntity);

            var newEmployee = Mapper.Map<EmployeeDto>(employeeEntity);

            return CreatedAtRoute("GetEmployee", new { id = newEmployee.Id }, newEmployee);
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if (!PerformanceReviewRepository.Exists<Employee>(id))
            {
                return NotFound();
            }

            var employeeFromRepo = PerformanceReviewRepository.Get<Employee>(id);

            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            Mapper.Map(employee, employeeFromRepo);

            try
            {
                PerformanceReviewRepository.Update(employeeFromRepo);
            }
            catch (Exception)
            {
                throw new Exception($"Updating employee {id} failed on commit");
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeFromRepo = PerformanceReviewRepository.Get<Employee>(id);

            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            try
            {
                PerformanceReviewRepository.Delete(employeeFromRepo);
            }
            catch (Exception)
            {
                throw new Exception($"Deleting employee {id} failed on commit");
            }

            return NoContent();
        }
    }
}
