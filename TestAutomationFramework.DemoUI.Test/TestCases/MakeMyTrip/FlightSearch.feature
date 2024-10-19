Feature: FlightSearch

A short summary of the feature

@tag1
Scenario: Verify search criteria on the flight listing page
	Given User enters flight search criteria on the flight landing page
	| From                | To                   | DepartureDate | ReturnDate | Travellers |
	| Manila, Philippines | Singapore, Singapore | 2M		     |			  | 1-1      |
	When User navigate to flight listing page
	Then User verifies search criteria on the flight listing page
