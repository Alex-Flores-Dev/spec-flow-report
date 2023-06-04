Feature: GetAllProducts

A short summary of the feature

@tag1

Scenario: Retrieving all products
    Given the API endpoint "/product"
    When a GET request is sent to the endpoint
    Then a successful response with status code 200 is received