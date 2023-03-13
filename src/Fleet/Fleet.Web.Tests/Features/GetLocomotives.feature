@GetLoco
Feature: GetLocomotives

    Scenario: GET should succeed
        When http GET /locomotives
        Then the http status is 200
        And the json content is 
        """
        [
            {
                "id": 1,
                "brand": "Pacific",
                "name": "231 G",
                "model": "ModelB",
                "weightInTons": 10.0,
                "maxTractionInTons": 10.0
            },
            {
                "id": 2,
                "brand": "Alsthom",
                "name": "CC 6500",
                "model": "ModelA",
                "weightInTons": 10.0,
                "maxTractionInTons": 10.0
            }
        ]
        """