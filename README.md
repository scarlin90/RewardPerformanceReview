# Reward Performance Review Challenge
Design a web application that allows employees to submit feedback toward each other's performance review.
Have a look at the [Challenge Requirements](https://github.com/scarlin90/RewardPerformanceReview/blob/master/Challenge.md)

## Proposed Software Stack

Below is a list of the software stack I will use to create the application:

| Tech/Lib | Purpose |
| ------ | ------ |
| [Angular 2](https://github.com/angular/quickstart) | Front end client |
| [Karma](https://karma-runner.github.io/1.0/index.html) | Front end client test runner |
| [Jasmine](https://jasmine.github.io/) | Front end client unit test framework |
| [dotnetcore 2](https://github.com/dotnet/core) | Server side processing |
| [Docker](https://www.docker.com/) | Continious Delivery |
| [Travis CI](https://travis-ci.com/) | Continious Integration |


## Assumptions
- Employees can have more than one performance review
- Assigned reviewing employees can leave more than one feedback comment
- Potientially the owner of the performance review can add own feedback to their own performance review

## Live Demo
Follow the link below to see the current version of the application:

[Deployed App](http://rewardperformancereview.azurewebsites.net)

| Username  | Password  |
| --------- | --------- |
| ADMIN     | ADMIN     |

### Active Functionality
- [x] Admin view all employees
- [x] Admin add employee
- [x] Admin remove employee 
- [x] Admin update employee
- [x] Admin view employee reviews for employee
- [x] Admin add employee review for employee
- [x] Admin remove employee review for employee
- [x] Admin update employee review for employee
- [x] Login and redirect to correct dashboard (Admin/Employee)
- [x] Admin route guards
- [ ] Admin view Assign employees to participate in another employee's performance review
- [ ] Employee View - List of performance reviews requiring feedback
- [ ] Employee View Submit feedback

## Travis CI
[RewardPerformanceReview CI](https://travis-ci.org/scarlin90/RewardPerformanceReview)

## Deployed Rest Api

| Identifier | HttpVerb | Endpoint Url | Dto |
| ------ | ------ | ------ |------ |
| GetEmployees      | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees |N/A |
| GetEmployeeById   | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId} | N/A |
| CreateEmployee    | Post | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/ | CreateEmployeeDto |
| UpdateEmployee    | Put | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId} | UpdateEmployeeDto |
| DeleteEmployee    | Delete | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId} | N/A |
| GetEmployeeReviewsForEmployee      | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews | N/A |
| GetEmployeeReviewForEmployee   | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews/{employeeReviewId} | N/A |
| CreateEmployeeReviewForEmployee    | Post | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews/ | CreateEmployeeReviewDto |
| UpdateEmployeeReviewForEmployee    | Put | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews/{employeeReviewId} | UpdateEmployeeReviewDto |
| DeleteEmployeeReviewForEmployee   | Delete | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews/{employeeReviewId} | N/A |
| GetFeedbackForEmployeeReviews      | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employeereviews/{employeeReviewId}/feedback | N/A |
| GetFeedbackForEmployeeReview   | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employeereviews/{employeeReviewId}/feedback/{feedbackId} | N/A |
| CreateFeedbackEmployeeReviewForEmployee    | Post | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews | CreateFeedbackDto |
| UpdateFeedbackForEmployeeReview    | Put | http://performancereviewwebrest20171107124230.azurewebsites.net/api/api/employeereviews/{employeeReviewId}/feedback/{feedbackId} | UpdateFeedbackDto |
| DeleteFeedbackForEmployeeReview   | Delete | http://performancereviewwebrest20171107124230.azurewebsites.net/api/api/employeereviews/{employeeReviewId}/feedback/{feedbackId} | N/A |
| GetAssignedReviewers      | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/assignedreviewers |N/A |
| GetAssignedReviewerById   | Get | http://performancereviewwebrest20171107124230.azurewebsites.net/api/assignedreviewers/{assignedReviewerId} | N/A |
| CreateAssignedReviewer    | Post | http://performancereviewwebrest20171107124230.azurewebsites.net/api/employees/{employeeId}/employeereviews{employeeReviewId}/assignedreviewers | N/A |
| DeleteEmployee    | Delete | http://performancereviewwebrest20171107124230.azurewebsites.net/api/assignedreviewers/{assignedReviewerId} | N/A |
| Login    | Post | http://performancereviewwebrest20171107124230.azurewebsites.net/api/authenticate | AuthenticateRequestDto |

## Database Design
![Database Design](https://docs.google.com/drawings/d/e/2PACX-1vQCqzKYpezQOlj3oc7pKbzrPkzNbIUc1nCWaMa73LdV-iBWO7gdivyd31M9_6OdvJvQG8PFY05FRPH0/pub?w=960&h=720)
