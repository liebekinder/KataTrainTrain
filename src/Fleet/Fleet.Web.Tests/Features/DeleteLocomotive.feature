@DelLoco
Feature: DeleteLocomotive

    Scenario: DELETE should succeed
        Given http GET /locomotives/1
        Then the http status is 200
        Given http DELETE /locomotives/1
        Then the http status is 204 
        When http GET /locomotives/1
        Then the http status is 404
