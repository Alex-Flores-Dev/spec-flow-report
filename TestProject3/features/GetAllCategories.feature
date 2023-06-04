Feature: GetAllCategories

A short summary of the feature

@tag1

Scenario: Retrieving all categories
    Given The API endpoint "/category"
    When a GET request is sent to the end point
    Then a successful response with status code