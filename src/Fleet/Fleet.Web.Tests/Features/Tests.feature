@Tests
Feature: Tests

    Scenario: GET should succeed
        When http GET /fleet
        Then the http status is 200
        And the http content is Success!!1