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
| [Angular 2](https://github.com/angular/quickstart) | Front end client |
| [dotnetcore 2](https://github.com/dotnet/core) | Server side processing |
| [MOQ 4](https://github.com/moq/moq4) | Server side unit testing |
| [Docker](https://www.docker.com/) | Continious Delivery |
| [Travis CI](https://travis-ci.com/) | Continious Integration |


## Assumptions
- Employees can have more than one performance review
- Assigned reviewing employees can leave more than one feedback comment
- Potientially the owner of the performance review can add own feedback to their own performance review

## Travis CI
[RewardPerformanceReview CI](https://travis-ci.org/scarlin90/RewardPerformanceReview)

## Database Design
![Database Design](https://docs.google.com/drawings/d/e/2PACX-1vQCqzKYpezQOlj3oc7pKbzrPkzNbIUc1nCWaMa73LdV-iBWO7gdivyd31M9_6OdvJvQG8PFY05FRPH0/pub?w=960&h=720)
