using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerformanceReview.Data.EntityFramework.Entity;
using PerformanceReview.Data.EntityFramework.Repository;
using PerformanceReview.Web.Rest.Models;

namespace PerformanceReview.Web.Rest.Controllers
{
    [Route("api/employeereviews/{employeeReviewId}/feedback")]
    public class FeedbackController : Controller
    {
        #region Private Properties

        private IPerformanceReviewRepository PerformanceReviewRepository { get; set; }

        #endregion

        #region Constructors

        public FeedbackController(IPerformanceReviewRepository performanceReviewRepository)
        {
            PerformanceReviewRepository = performanceReviewRepository;
        }

        #endregion

        #region Public Methods

        [HttpGet()]
        public IActionResult GetFeedbackForEmployeeReviews(int employeeReviewId)
        {
            IEnumerable<Feedback> feedbackForEmployeeReviewsFromRepo = null;

            if (!PerformanceReviewRepository.Exists<EmployeeReview>(employeeReviewId))
            {
                return NotFound();
            }

            try
            {
                feedbackForEmployeeReviewsFromRepo = PerformanceReviewRepository.GetFeedbackForEmployeeReviews(employeeReviewId);
            }
            catch (Exception)
            {
                throw new Exception($"Getting feedback for employee review {employeeReviewId} failed");
            }

            var feedbackForEmployeeReviews = Mapper.Map<IEnumerable<FeedbackDto>>(feedbackForEmployeeReviewsFromRepo);

            return Ok(feedbackForEmployeeReviews);
        }

        [HttpGet("{id}", Name = "GetFeedback")]
        public IActionResult GetFeedbackForEmployeeReview(int employeeReviewId, int id)
        {
            Feedback feedbackForEmployeeReviewFromRepo = null;

            if (!PerformanceReviewRepository.Exists<Feedback>(employeeReviewId))
            {
                return NotFound();
            }

            try
            {
                feedbackForEmployeeReviewFromRepo = PerformanceReviewRepository.GetFeedbackForEmployeeReview(employeeReviewId, id);
            }
            catch (Exception)
            {
                throw new Exception($"Getting feedback for employee review {employeeReviewId} failed");
            }

            if (feedbackForEmployeeReviewFromRepo == null)
            {
                return NotFound();
            }

            var feedbackForEmployeeReview = Mapper.Map<FeedbackDto>(feedbackForEmployeeReviewFromRepo);
            return Ok(feedbackForEmployeeReview);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateFeedbackForEmployeeReview(int employeeReviewId, int id, [FromBody] UpdateFeedbackDto feedback)
        {
            Feedback feedbackForEmployeeReviewFromRepo = null;

            if (feedback == null)
            {
                return BadRequest();
            }

            if (!PerformanceReviewRepository.Exists<EmployeeReview>(employeeReviewId))
            {
                return NotFound();
            }

            if (!PerformanceReviewRepository.Exists<Feedback>(id))
            {
                return NotFound();
            }

            try
            {
                feedbackForEmployeeReviewFromRepo = PerformanceReviewRepository.GetFeedbackForEmployeeReview(employeeReviewId, id);
            }
            catch (Exception)
            {
                throw new Exception($"Getting feedback for employee review {employeeReviewId} failed");
            }

            if (feedbackForEmployeeReviewFromRepo == null)
            {
                return NotFound();
            }

            Mapper.Map(feedback, feedbackForEmployeeReviewFromRepo);

            try
            {
                PerformanceReviewRepository.Update(feedbackForEmployeeReviewFromRepo);
            }
            catch (Exception)
            {
                throw new Exception($"Updating feedback {id} for employee review {employeeReviewId} failed on commit");
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeedbackForEmployeeReview(int employeeReviewId, int id)
        {
            Feedback feedbackForEmployeeReviewFromRepo = null;

            if (!PerformanceReviewRepository.Exists<EmployeeReview>(employeeReviewId))
            {
                return NotFound();
            }

            if (!PerformanceReviewRepository.Exists<Feedback>(id))
            {
                return NotFound();
            }

            try
            {
                feedbackForEmployeeReviewFromRepo = PerformanceReviewRepository.GetFeedbackForEmployeeReview(employeeReviewId, id);
            }
            catch (Exception)
            {
                throw new Exception($"Getting feedback for employee review {employeeReviewId} failed");
            }

            if (feedbackForEmployeeReviewFromRepo == null)
            {
                return NotFound();
            }

            try
            {
                PerformanceReviewRepository.Delete(feedbackForEmployeeReviewFromRepo);
            }
            catch (Exception)
            {
                throw new Exception($"Deleting feedback {id} for employee review {employeeReviewId} failed on commit");
            }

            return NoContent();
        }

        #endregion
    }
}
