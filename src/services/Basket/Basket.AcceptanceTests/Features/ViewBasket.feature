Feature: View Basket

As a website visitor
I want to view the products in my basket
So that I can review all the products I have previously added to my basket before I buy them

@tag1
Scenario: View an empty basket
	Given I have not added any products to my basket
	When I view the basket page
	Then I should see no products in my basket

#Scenario: View basket with iPhoneX in it
#	Given I have added 1 iPhoneX to my basket
#	When I view the basket page
#	Then I should see the iPhoneX
#	And the quantity shown should be 1
#
#Scenario: View basket with 2 iPhoneX in it
#	Given I have added 2 iPhoneX to my basket
#	When I view the basket page
#	Then I should see the iPhoneX
#	And the quantity shown should be 2
#
#Scenario: View basket with an iPhoneX and another product in it
#	Given I have added an iPhoneX and another product to my basket
#	When I view the basket page
#	Then I should see an iPhoneX 
#	And the quantity shown should be 1
#	And another product
#	And the quantity shown should be 1
