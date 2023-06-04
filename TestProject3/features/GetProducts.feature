Feature: Get products

@positive @smoke @regression @integration @task-03
Scenario: Get by id 
	Given I have an id with value 17
	When I send a get request
	Then I expected a valid code response

