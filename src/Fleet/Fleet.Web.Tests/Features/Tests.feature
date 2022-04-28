@Tests
Feature: Tests

    Scenario: NotFound with inexisting prorata rule
        When http GET /fleet
        Then the http status is 200
        And the http content is Success!!1