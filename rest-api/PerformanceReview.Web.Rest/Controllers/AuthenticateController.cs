using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerformanceReview.Data.EntityFramework.Entity;
using PerformanceReview.Data.EntityFramework.Repository;
using PerformanceReview.Web.Rest.Models;

namespace PerformanceReview.Web.Rest.Controllers
{
    [Route("api/authenticate")]
    public class AuthenticateController : Controller
    {
        #region Private Properties

        private IPerformanceReviewRepository PerformanceReviewRepository { get; set; }

        #endregion

        #region Constructors

        public AuthenticateController(IPerformanceReviewRepository performanceReviewRepository)
        {
            PerformanceReviewRepository = performanceReviewRepository;
        }

        #endregion

        #region Public Methods

        [HttpPost]
        public IActionResult Login([FromBody]AuthenticateRequestDto authRequest)
        {
            if (authRequest == null)
            {
                return BadRequest();
            }

            // Check if Master Admin account exists
            // If not then create then validate user creds

            if (PerformanceReviewRepository.GetAll<Employee>()
                                          .FirstOrDefault(emp =>
                                            emp.Username.ToUpper() == "ADMIN" &&
                                            emp.Password == "ADMIN") == null) {
                var admin = new Employee {
                    IsAdmin = true,
                    Username = "ADMIN",
                    Password = "ADMIN",
                    FirstName = "ADMIN",
                    Surname = "ADMIN",
                    JobTitle = "Administrator",
                };

                PerformanceReviewRepository.Insert(admin);
            }

            // This part is a stub for a real Authentication Service
            // Find account matching username and password supplied
            // This is the account details client will store as User Logged In
            var authenticatedEmployeeAccountFromRepo = PerformanceReviewRepository.GetAll<Employee>()
                                          .FirstOrDefault(emp =>
                                            emp.Username.ToUpper() == authRequest.Username.ToUpper() &&
                                            emp.Password == authRequest.Password);

            if (authenticatedEmployeeAccountFromRepo == null) {
                return NotFound();
            }

            var authenticatedEmployeeAccount = Mapper.Map<EmployeeDto>(authenticatedEmployeeAccountFromRepo);

            return Ok(authenticatedEmployeeAccount);
            
        }
        
        #endregion
    }
}
