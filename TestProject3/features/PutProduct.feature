Feature: PutProduct

A short summary of the feature

@positive @smoke @regression @integration @task-03
Scenario: Updating a product
	Given I have an object with value
	      | name           | description   | image             | price  | categoryId |
		  | Purple Glasses | Purple Glasses | purple-glasses.jpg | 19.99  | 7          |
	When I send a get request to update
	Then I expected a valid status code 
