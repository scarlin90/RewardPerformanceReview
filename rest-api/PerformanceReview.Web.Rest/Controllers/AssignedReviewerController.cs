using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerformanceReview.Data.EntityFramework.Entity;
using PerformanceReview.Data.EntityFramework.Repository;

namespace PerformanceReview.Web.Rest.Controllers
{
    [Route("api/assignedreviewers")]
    public class AssignedReviewerController : Controller
    {
        #region Private Properties

        private IPerformanceReviewRepository PerformanceReviewRepository { get; set; }

        #endregion

        #region Constructors

        public AssignedReviewerController(IPerformanceReviewRepository performanceReviewRepository)
        {
            PerformanceReviewRepository = performanceReviewRepository;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult GetAssignedReviewers()
        {
            var assignedReviewerFromRepo = PerformanceReviewRepository.GetAll<AssignedReviewer>();
            var assignedReviewers = Mapper.Map<IEnumerable<AssignedReviewerDto>>(assignedReviewerFromRepo);

            return Ok(assignedReviewers);
        }

        [HttpGet("{id}", Name = "GetAssignedReviewer")]
        public IActionResult GetAssignedReviewerById(int id)
        {
            var assignedReviewerFromRepo = PerformanceReviewRepository.Get<AssignedReviewer>(id);

            if (assignedReviewerFromRepo == null)
            {
                return NotFound();
            }

            var assignedReviewer = Mapper.Map<AssignedReviewerDto>(assignedReviewerFromRepo);

            return Ok(assignedReviewer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var assignedReviewerFromRepo = PerformanceReviewRepository.Get<AssignedReviewer>(id);

            if (assignedReviewerFromRepo == null)
            {
                return NotFound();
            }

            try
            {
                PerformanceReviewRepository.Delete(assignedReviewerFromRepo);
            }
            catch (Exception)
            {
                throw new Exception($"Deleting assigned reviewer {id} failed on commit");
            }

            return NoContent();
        }

        #endregion
    }
}
