using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceReview.Data.EntityFramework.Entity;
using PerformanceReview.Data.EntityFramework.Repository;

namespace PerformanceReview.Web.Rest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IEmployeeRepository EmployeeRepository { get; set; }

        public ValuesController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public Task<Employee> Get(string username)
        {
            if (EmployeeRepository.GetAllAsync().Count().Result == 0)
            {
                EmployeeRepository.InsertAsync(
                    new Employee
                    {
                        IsAdmin = true,
                        Username = username,
                        Password = "Pass"
                    });
            }

            return EmployeeRepository.GetEmployeeByUsernameAsync(username);
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
