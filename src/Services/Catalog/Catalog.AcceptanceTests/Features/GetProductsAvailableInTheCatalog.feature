Feature: Get products available in the catalog

Display all products using the catalog API

As a consumer of the catalog API
I want to view the products in the catalog
So that I can view Name, Category, Summary, Description, ImageFile, and Price of all the products available

Scenario: View an empty product catalog
	Given I have do not have any products in the catalog
	When I view the products available
	Then I should see no products 