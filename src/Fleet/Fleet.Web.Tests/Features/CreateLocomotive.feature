@CreateLoco
Feature: CreateLocomotive

    Scenario: POST should succeed
        When http POST /locomotives with body
        """
        {
            "brand": "Pacific",
            "name": "231 G",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 200
        And the json content is 
        """
        {
            "id": 1,
            "brand": "Pacific",
            "name": "231 G",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """

    Scenario: POST should fail on null
        When http POST /locomotives with body
        """
        {
            "name": null,
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "name": [
              "Name must not be null or empty"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """        

    Scenario: POST should fail on empty name
        When http POST /locomotives with body
        """
        {
            "name": "",
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "name": [
              "Name must not be null or empty"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """
        
    Scenario: POST should fail on name too long
        When http POST /locomotives with body
        """
        {
            "name": "name of the locomotive that is way too long: 000000000000000000000000000000000000000",
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "name": [
              "Name length must not exceed 50 characters"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """

    Scenario: POST should fail on null brand
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "brand": [
              "Brand must not be null or empty"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """        

    Scenario: POST should fail on empty brand
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "brand": [
              "Brand must not be null or empty"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """
        
    Scenario: POST should fail on brand too long
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "Pacific 000000000000000000000000000000000000000000000000000000000000000000000000000000000",
            "model": "ModelB",
            "weightInTons": 10.0,
            "maxTractionInTons": 12.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "brand": [
              "Brand length must not exceed 50 characters"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """

    Scenario: POST should fail on traction lesser than weigth
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": 20.0,
            "maxTractionInTons": 10.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "maxTractionInTons": [
              "MaxTraction must be greater than Weight"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """

    Scenario: POST should fail on traction negative
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": 20.0,
            "maxTractionInTons": -10.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "maxTractionInTons": [
              "MaxTractionInTons must be positive"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """

    Scenario: POST should fail on traction null
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": 20.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "maxTractionInTons": [
              "MaxTractionInTons must be positive"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """

    Scenario: POST should fail on weight negative
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "Pacific",
            "model": "ModelB",
            "weightInTons": -20.0,
            "maxTractionInTons": 10.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "weightInTons": [
              "WeightInTons must be positive"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """

    Scenario: POST should fail on weightInTons null
        When http POST /locomotives with body
        """
        {
            "name": "231 G",
            "brand": "Pacific",
            "model": "ModelB",
            "maxTractionInTons": 10.0
        }
        """
        Then the http status is 400
        And the json content is 
        """
        ignoreProperties: traceId
        {
          "errors": {
            "weightInTons": [
              "WeightInTons must be positive"
            ]
          },
          "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          "title": "One or more validation errors occurred.",
          "status": 400
        }
        """