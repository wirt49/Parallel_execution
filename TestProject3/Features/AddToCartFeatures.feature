Feature: 

@Smoke
Scenario Outline: I want to search laptop by name and sort result page from expensive
	Given i open homePage
	When i enter '<laptopName>' in search field
	And  sort the items
	Then i add the most expensive laptop to the cart
	And i open cart
	Then i compare cart bill and the '<sum>'

	Examples: 
	| laptopName | sum |
	|   lenovo   |  50000   |