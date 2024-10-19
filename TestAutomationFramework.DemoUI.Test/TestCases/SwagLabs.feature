Feature: SwagLabs Functionality

A short summary of the feature

@tag1
Scenario: Verify different products of swag labs
	Given Login with valid credentials
		Then user verifies swag lab products
		| Item                              | Price  |	
		| Sauce Labs Bike Light             | $9.99  |
		| Sauce Labs Backpack               | $29.99 |
		| Sauce Labs Bolt T-Shirt           | $15.99 |
		| Sauce Labs Fleece Jacket          | $49.99 |
		| Sauce Labs Onesie                 | $7.99  |
		| Test.allTheThings() T-Shirt (Red) | $15.99 |
