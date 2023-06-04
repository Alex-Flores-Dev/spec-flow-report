Feature: Get categories
@positive @smoke @regression @integration @task-03
Scenario: Get category by id 
	Given I have an id categorie with value 5
	When I send a get request to API
	Then I expected a valid code response (200)

